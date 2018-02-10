using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Security;


using System.Web;
using System.Threading;


namespace ChangePaper
{
    /// <summary>
    /// �ļ�ѹ��
    /// </summary>
    public class FileCompress
    {
        const string COMPRESS_FILE = "a -ep1 -afzip {2} \"{0}\" \"{1}\"";//ѹ������
        const string DECOMPRESS_FILE = " X -Y {2} \"{0}\" \"{1}\"";//��ѹ����

        const string SEVEN_COMPRESS_FILE = "a -tzip -r \"{0}\" \"{1}\" {2}";//7zѹ������
        const string SEVEN_DECOMPRESS_FILE = " x \"{0}\" -y -o\"{1}\" {2}";//7z��ѹ����

        static string mWinRARFileName = "";//WinRAR.exe·��
        static string mWinRARTemp = "";//����Ŀ¼

        public static string spokenCommonPassword = "hytSpokenExam";

        //public static string BasePkgAndKwPkgSpokenCommonPassword = "hytOBTExam";

       



        /// <summary>
        /// ��ȡ���ܲ���
        /// </summary>
        static string GetCompressPwdArg(string pwd)
        {
            if (string.IsNullOrEmpty(pwd))
            {
                return "";
            }
            else
            {
                return " -hp" + pwd;
            }
        }

        static string GetSevenCompressPwdArg(string pwd)
        {
            if (string.IsNullOrEmpty(pwd))
            {
                return "";
            }
            else
            {
                return " -p" + pwd;
            }
        }

        /// <summary>
        /// ���ͬʱ����10��ѹ���г̣���Ϊÿ��ѹ���̻߳Ὺ��һ��WinRAR����
        /// </summary>
        static int WinRARMaxThreadCount
        {
            get
            {
                int winRARMaxThreadCount = 0;
                int.TryParse("10", out winRARMaxThreadCount);
                if (winRARMaxThreadCount > 0)
                {
                    return winRARMaxThreadCount;
                }
                else
                {
                    return 10;//Ĭ��10��
                }
            }
        }

        static int compressingThreadCount = 0;
        static int decompressingThreadCount = 0;


        /// <summary>
        /// �ļ�ѹ��7z  Mac �޸� 2015��8��5��16:38:27
        /// </summary>
        /// <param name="szFileList">Ҫѹ����ԭ�ļ�</param>
        /// <param name="szSaveFile">ѹ�����ļ�</param>
        /// <param name="szPassword">ѹ��������</param>
        /// <param name="prgCompress"></param>
        /// <param name="IsDelFile">ѹ����ɺ��Ƿ�ɾ��ԭ�ļ���Ĭ�ϲ�ɾ��</param>
        /// <returns></returns>
        public static int CompressFiles(string szFileList, string szSaveFile, string szPassword, COMPRESSPRG prgCompress, bool isDelFile = false)
        {
            while (compressingThreadCount >= WinRARMaxThreadCount)//�Ѿ���MAX_THREAD_COUNT���߳���ѹ�����͵ȴ�
            {
                Thread.Sleep(200);//���̫�ಢ��ѹ�����ȴ�200ms
            }
            ProcessStartInfo ps = null;
            Process p = null;
            try
            {
                compressingThreadCount++;
                //ConnectLan(@"\\192.168.20.164\utDir","NewAccount","123");
                //KillWinRAR();
                if (File.Exists(szSaveFile))
                {
                    //LogHelper.Error("ѹ�����Ѵ��ڣ�" + szSaveFile);
                    File.Delete(szSaveFile);
                }
                string compressType = "7z";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string paramWinRar = "";
                string WinRarPath = "";
                string[] files = szFileList.Split(';');
                foreach (string fileName in files)//�����ļ�
                {
                    if (string.IsNullOrEmpty(fileName))//�ļ�������Ϊ��
                    {
                        continue;
                    }
                    if (File.Exists(fileName) || Directory.Exists(fileName))//�ļ���Ŀ¼����
                    {
                        if (compressType.Equals("7z"))
                        {
                            WinRarPath = path + @"lib\7z.exe";
                            paramWinRar = string.Format(SEVEN_COMPRESS_FILE, szSaveFile, fileName, GetSevenCompressPwdArg(szPassword));
                        }
                      
                        ps = new ProcessStartInfo(WinRarPath, paramWinRar);
                        ps.WindowStyle = ProcessWindowStyle.Hidden;
                        ps.WorkingDirectory = WinRARTemp;
                        p = new Process();
                        p.StartInfo = ps;
                        p.Start();
                        if (p != null)
                        {
                            p.WaitForExit();
                            //p.Close();                            
                        }

                        if (isDelFile)//ɾ��ԭ�ļ�
                        {
                            if (File.Exists(fileName))
                            {
                                File.Delete(fileName);
                            }
                            else if (Directory.Exists(fileName))
                            {
                                Directory.Delete(fileName, true);
                            }
                        }
                    }
                }
                return 1;
            }
            catch (Exception se)
            {
                //LogHelper.Error("ѹ��ʧ�ܣ�WinRAR.exe·��:" + WinRARFileName + ",�ļ��б�" + szFileList + "��ѹ������" + szSaveFile, se);
                return 0;
            }
            finally
            {
                if (p != null)
                {
                    p.WaitForExit();
                    p.Close();
                }
                if (compressingThreadCount > 0)
                {
                    compressingThreadCount--;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szFolder"></param>
        /// <param name="szSaveFile"></param>
        /// <param name="szPassword"></param>
        /// <param name="prgCompress"></param>
        /// <param name="isDelFile"></param>
        /// <returns></returns>
        public static int CompressFolder(string szFolder, string szSaveFile, string szPassword, COMPRESSPRG prgCompress, bool isDelFile = false)
        {
            while (compressingThreadCount >= WinRARMaxThreadCount)//�Ѿ���MAX_THREAD_COUNT���߳���ѹ�����͵ȴ�
            {
                Thread.Sleep(200);//���̫�ಢ��ѹ�����ȴ�200ms
            }
            ProcessStartInfo ps = null;
            Process p = null;
            try
            {
                compressingThreadCount++;
                //ConnectLan(@"\\192.168.20.164\utDir","NewAccount","123");
                //KillWinRAR();
                if (File.Exists(szSaveFile))
                {
                    //LogHelper.Error("ѹ�����Ѵ��ڣ�" + szSaveFile);
                    File.Delete(szSaveFile);
                }
                string compressType = "7z";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string paramWinRar = "";
                string WinRarPath = "";
                DirectoryInfo di = new DirectoryInfo(szFolder);
                FileInfo[] files = di.GetFiles();
                //string[] files = szFileList.Split(';');
                foreach (FileInfo fileName in files)//�����ļ�
                {
                    if (string.IsNullOrEmpty(fileName.FullName))//�ļ�������Ϊ��
                    {
                        continue;
                    }
                    if (File.Exists(fileName.FullName) || Directory.Exists(fileName.FullName))//�ļ���Ŀ¼����
                    {
                        if (compressType.Equals("7z"))
                        {
                            WinRarPath = path + @"lib\7z.exe";
                            paramWinRar = string.Format(SEVEN_COMPRESS_FILE, szSaveFile, fileName.FullName, GetSevenCompressPwdArg(szPassword));
                        }

                        ps = new ProcessStartInfo(WinRarPath, paramWinRar);
                        ps.WindowStyle = ProcessWindowStyle.Hidden;
                        ps.WorkingDirectory = WinRARTemp;
                        p = new Process();
                        p.StartInfo = ps;
                        p.Start();
                        if (p != null)
                        {
                            p.WaitForExit();
                            //p.Close();                            
                        }

                        if (isDelFile)//ɾ��ԭ�ļ�
                        {
                            if (File.Exists(fileName.FullName))
                            {
                                File.Delete(fileName.FullName);
                            }
                            else if (Directory.Exists(fileName.FullName))
                            {
                                Directory.Delete(fileName.FullName, true);
                            }
                        }
                    }
                }
                return 1;
            }
            catch (Exception se)
            {
                //LogHelper.Error("ѹ��ʧ�ܣ�WinRAR.exe·��:" + WinRARFileName + ",�ļ��б�" + szFileList + "��ѹ������" + szSaveFile, se);
                return 0;
            }
            finally
            {
                if (p != null)
                {
                    p.WaitForExit();
                    p.Close();
                }
                if (compressingThreadCount > 0)
                {
                    compressingThreadCount--;
                }
            }
        }

        public static string ConnectLan(string p_Path, string p_UserName, string p_PassWord)
        {
            System.Diagnostics.Process _Process = new System.Diagnostics.Process();
            _Process.StartInfo.FileName = "cmd.exe";
            _Process.StartInfo.UseShellExecute = false;
            _Process.StartInfo.RedirectStandardInput = true;
            _Process.StartInfo.RedirectStandardOutput = true;
            _Process.StartInfo.CreateNoWindow = true;
            _Process.Start();
            //NET USE \\192.168.0.1 PASSWORD /USER:UserName 
            _Process.StandardInput.WriteLine("net use " + p_Path + " " + p_PassWord + " /user:" + p_UserName);
            _Process.StandardInput.WriteLine("exit");
            _Process.WaitForExit();
            string _ReturnText = _Process.StandardOutput.ReadToEnd();// �õ�cmd.exe�����  
            _Process.Close();
            return _ReturnText;
        }




        //[DllImport(@"FileComp.dll")]
        //[DllImport(@"F:\Test\FileComp\FileComp1\FileComp\Debug\FileComp.dll")]
        //[DllImport(@"F:\a\FileComp.dll")]
        //public static extern int DecompressFile(string szCompFile, string szSaveDir, string szPassword, COMPRESSPRG prgCompress);
        /// <summary>
        /// ��ѹ���ļ�
        /// </summary>
        /// <param name="szCompFile">��ѹ���ļ�</param>
        /// <param name="szSaveDir">��ѹ֮�󱣴��ļ�Ŀ¼</param>
        /// <param name="szPassword">��ѹ������</param>
        /// <param name="prgCompress"></param>
        /// <returns></returns>
        //public static int DecompressFile(string szCompFile, string szSaveDir, string szPassword, COMPRESSPRG prgCompress)
        //{
        //    while (decompressingThreadCount >= WinRARMaxThreadCount)//�Ѿ���MAX_THREAD_COUNT���߳���ѹ�����͵ȴ�
        //    {
        //        Thread.Sleep(1000);//���̫�ಢ��ѹ�����ȴ�200ms
        //    }
        //    ProcessStartInfo ps = null;
        //    Process p = null;
        //    try
        //    {
        //        decompressingThreadCount++;
        //        //KillWinRAR();
        //        if (!File.Exists(szCompFile))
        //        {
        //            return 0;
        //        }
        //        if (!Directory.Exists(szSaveDir))
        //        {
        //            Directory.CreateDirectory(szSaveDir);
        //        }
        //        string paramWinRar = string.Format(DECOMPRESS_FILE, szCompFile, szSaveDir, GetCompressPwdArg(szPassword));

        //        ps = new ProcessStartInfo(WinRARFileName, paramWinRar);
        //        ps.WindowStyle = ProcessWindowStyle.Hidden;
        //        ps.WorkingDirectory = WinRARTemp;
        //        p = new Process();
        //        p.StartInfo = ps;
        //        p.Start();

        //        return 1;
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        LogHelper.Error("��ѹ��ʧ�ܣ�WinRAR.exe·��:" + WinRARFileName + ",��ѹ·����" + szSaveDir + "��ѹ������" + szCompFile, ex);
        //        return 0;
        //    }
        //    catch (Exception se)
        //    {
        //        LogHelper.Error("��ѹ��ʧ�ܣ�WinRAR.exe·��:" + WinRARFileName + ",��ѹ·����" + szSaveDir + "��ѹ������" + szCompFile, se);
        //        return 0;
        //    }
        //    finally
        //    {
        //        if (p != null)
        //        {
        //            p.WaitForExit();
        //            p.Close();
        //        }
        //        if (decompressingThreadCount > 0)
        //        {
        //            decompressingThreadCount--;
        //        }
        //    }
        //}

        /// <summary>
        /// ��ѹ���ļ�7z  Mac �޸� 2015��8��5��16:38:27
        /// </summary>
        /// <param name="szCompFile">��ѹ���ļ�</param>
        /// <param name="szSaveDir">��ѹ֮�󱣴��ļ�Ŀ¼</param>
        /// <param name="szPassword">��ѹ������</param>
        /// <param name="prgCompress"></param>
        /// <returns></returns>
        public static int DecompressFile(string szCompFile, string szSaveDir, string szPassword, COMPRESSPRG prgCompress)
        {
            while (decompressingThreadCount >= WinRARMaxThreadCount)//�Ѿ���MAX_THREAD_COUNT���߳���ѹ�����͵ȴ�
            {
                Thread.Sleep(1000);//���̫�ಢ��ѹ�����ȴ�200ms
            }
            ProcessStartInfo ps = null;
            Process p = null;
            try
            {
                decompressingThreadCount++;
                //KillWinRAR();
                if (!File.Exists(szCompFile))
                {
                    return 0;
                }
                if (!Directory.Exists(szSaveDir))
                {
                    Directory.CreateDirectory(szSaveDir);
                }
                string compressType ="7z";
                //string path = HttpRuntime.AppDomainAppPath.ToString();
                string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string paramWinRar = "";
                string WinRarPath = "";
                if (compressType.Equals("7z"))
                {
                    WinRarPath = path + @"lib\7z.exe";
                    paramWinRar = string.Format(SEVEN_DECOMPRESS_FILE, szCompFile, szSaveDir, GetSevenCompressPwdArg(szPassword));
                }
               
                ps = new ProcessStartInfo(WinRarPath, paramWinRar);
                ps.WindowStyle = ProcessWindowStyle.Hidden;
                ps.WorkingDirectory = WinRARTemp;
                p = new Process();
                p.StartInfo = ps;
                p.Start();

                return 1;
            }
            catch (InvalidOperationException ex)
            {
                //LogHelper.Error("��ѹ��ʧ�ܣ�WinRAR.exe·��:" + WinRARFileName + ",��ѹ·����" + szSaveDir + "��ѹ������" + szCompFile, ex);
                return 0;
            }
            catch (Exception se)
            {
                //LogHelper.Error("��ѹ��ʧ�ܣ�WinRAR.exe·��:" + WinRARFileName + ",��ѹ·����" + szSaveDir + "��ѹ������" + szCompFile, se);
                return 0;
            }
            finally
            {
                if (p != null)
                {
                    p.WaitForExit();
                    p.Close();
                }
                if (decompressingThreadCount > 0)
                {
                    decompressingThreadCount--;
                }
            }
        }


        /// <summary>
        /// ����Ŀ¼Ŀ¼
        /// </summary>
        private static string WinRARTemp
        {
            get
            {
                if (string.IsNullOrEmpty(mWinRARTemp))
                {
                    string tempFileName;
                    //��ǰ��վ��
                    tempFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\WinRARTemp");
                    if (!Directory.Exists(tempFileName))
                    {
                        Directory.CreateDirectory(tempFileName);
                    }
                    mWinRARTemp = tempFileName;
                    return mWinRARTemp;

                    ////web.config������
                    //tempFileName = ConfigurationManager.AppSettings["WinRARTemp"];
                    //if (!string.IsNullOrEmpty(tempFileName))
                    //{
                    //    if (Directory.Exists(tempFileName))
                    //    {
                    //        mWinRARTemp = tempFileName;
                    //        return mWinRARTemp;
                    //    }
                    //}

                }
                else
                {
                    return mWinRARTemp;
                }
                //return ConfigurationManager.AppSettings["WinRARTemp"];
            }
        }

       
    }

    public delegate bool COMPRESSPRG(int a, int b, string handle);
    public struct COMP
    {
        public string szFileName;
        public int nTotalSize;
        public int nCurrentSize;
    }
}
