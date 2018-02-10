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
    /// 文件压缩
    /// </summary>
    public class FileCompress
    {
        const string COMPRESS_FILE = "a -ep1 -afzip {2} \"{0}\" \"{1}\"";//压缩参数
        const string DECOMPRESS_FILE = " X -Y {2} \"{0}\" \"{1}\"";//解压参数

        const string SEVEN_COMPRESS_FILE = "a -tzip -r \"{0}\" \"{1}\" {2}";//7z压缩参数
        const string SEVEN_DECOMPRESS_FILE = " x \"{0}\" -y -o\"{1}\" {2}";//7z解压参数

        static string mWinRARFileName = "";//WinRAR.exe路径
        static string mWinRARTemp = "";//工作目录

        public static string spokenCommonPassword = "hytSpokenExam";

        //public static string BasePkgAndKwPkgSpokenCommonPassword = "hytOBTExam";

       



        /// <summary>
        /// 获取加密参数
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
        /// 最多同时开启10个压缩行程，因为每个压缩线程会开启一个WinRAR进程
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
                    return 10;//默认10个
                }
            }
        }

        static int compressingThreadCount = 0;
        static int decompressingThreadCount = 0;


        /// <summary>
        /// 文件压缩7z  Mac 修改 2015年8月5日16:38:27
        /// </summary>
        /// <param name="szFileList">要压缩的原文件</param>
        /// <param name="szSaveFile">压缩包文件</param>
        /// <param name="szPassword">压缩包密码</param>
        /// <param name="prgCompress"></param>
        /// <param name="IsDelFile">压缩完成后是否删除原文件，默认不删除</param>
        /// <returns></returns>
        public static int CompressFiles(string szFileList, string szSaveFile, string szPassword, COMPRESSPRG prgCompress, bool isDelFile = false)
        {
            while (compressingThreadCount >= WinRARMaxThreadCount)//已经有MAX_THREAD_COUNT个线程在压缩，就等待
            {
                Thread.Sleep(200);//如果太多并发压缩，等待200ms
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
                    //LogHelper.Error("压缩包已存在：" + szSaveFile);
                    File.Delete(szSaveFile);
                }
                string compressType = "7z";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string paramWinRar = "";
                string WinRarPath = "";
                string[] files = szFileList.Split(';');
                foreach (string fileName in files)//遍历文件
                {
                    if (string.IsNullOrEmpty(fileName))//文件名不能为空
                    {
                        continue;
                    }
                    if (File.Exists(fileName) || Directory.Exists(fileName))//文件和目录存在
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

                        if (isDelFile)//删除原文件
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
                //LogHelper.Error("压缩失败，WinRAR.exe路径:" + WinRARFileName + ",文件列表：" + szFileList + "，压缩包：" + szSaveFile, se);
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
            while (compressingThreadCount >= WinRARMaxThreadCount)//已经有MAX_THREAD_COUNT个线程在压缩，就等待
            {
                Thread.Sleep(200);//如果太多并发压缩，等待200ms
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
                    //LogHelper.Error("压缩包已存在：" + szSaveFile);
                    File.Delete(szSaveFile);
                }
                string compressType = "7z";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string paramWinRar = "";
                string WinRarPath = "";
                DirectoryInfo di = new DirectoryInfo(szFolder);
                FileInfo[] files = di.GetFiles();
                //string[] files = szFileList.Split(';');
                foreach (FileInfo fileName in files)//遍历文件
                {
                    if (string.IsNullOrEmpty(fileName.FullName))//文件名不能为空
                    {
                        continue;
                    }
                    if (File.Exists(fileName.FullName) || Directory.Exists(fileName.FullName))//文件和目录存在
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

                        if (isDelFile)//删除原文件
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
                //LogHelper.Error("压缩失败，WinRAR.exe路径:" + WinRARFileName + ",文件列表：" + szFileList + "，压缩包：" + szSaveFile, se);
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
            string _ReturnText = _Process.StandardOutput.ReadToEnd();// 得到cmd.exe的输出  
            _Process.Close();
            return _ReturnText;
        }




        //[DllImport(@"FileComp.dll")]
        //[DllImport(@"F:\Test\FileComp\FileComp1\FileComp\Debug\FileComp.dll")]
        //[DllImport(@"F:\a\FileComp.dll")]
        //public static extern int DecompressFile(string szCompFile, string szSaveDir, string szPassword, COMPRESSPRG prgCompress);
        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="szCompFile">解压缩文件</param>
        /// <param name="szSaveDir">解压之后保存文件目录</param>
        /// <param name="szPassword">解压缩密码</param>
        /// <param name="prgCompress"></param>
        /// <returns></returns>
        //public static int DecompressFile(string szCompFile, string szSaveDir, string szPassword, COMPRESSPRG prgCompress)
        //{
        //    while (decompressingThreadCount >= WinRARMaxThreadCount)//已经有MAX_THREAD_COUNT个线程在压缩，就等待
        //    {
        //        Thread.Sleep(1000);//如果太多并发压缩，等待200ms
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
        //        LogHelper.Error("解压缩失败，WinRAR.exe路径:" + WinRARFileName + ",解压路径：" + szSaveDir + "，压缩包：" + szCompFile, ex);
        //        return 0;
        //    }
        //    catch (Exception se)
        //    {
        //        LogHelper.Error("解压缩失败，WinRAR.exe路径:" + WinRARFileName + ",解压路径：" + szSaveDir + "，压缩包：" + szCompFile, se);
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
        /// 解压缩文件7z  Mac 修改 2015年8月5日16:38:27
        /// </summary>
        /// <param name="szCompFile">解压缩文件</param>
        /// <param name="szSaveDir">解压之后保存文件目录</param>
        /// <param name="szPassword">解压缩密码</param>
        /// <param name="prgCompress"></param>
        /// <returns></returns>
        public static int DecompressFile(string szCompFile, string szSaveDir, string szPassword, COMPRESSPRG prgCompress)
        {
            while (decompressingThreadCount >= WinRARMaxThreadCount)//已经有MAX_THREAD_COUNT个线程在压缩，就等待
            {
                Thread.Sleep(1000);//如果太多并发压缩，等待200ms
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
                //LogHelper.Error("解压缩失败，WinRAR.exe路径:" + WinRARFileName + ",解压路径：" + szSaveDir + "，压缩包：" + szCompFile, ex);
                return 0;
            }
            catch (Exception se)
            {
                //LogHelper.Error("解压缩失败，WinRAR.exe路径:" + WinRARFileName + ",解压路径：" + szSaveDir + "，压缩包：" + szCompFile, se);
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
        /// 工作目录目录
        /// </summary>
        private static string WinRARTemp
        {
            get
            {
                if (string.IsNullOrEmpty(mWinRARTemp))
                {
                    string tempFileName;
                    //当前网站的
                    tempFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\WinRARTemp");
                    if (!Directory.Exists(tempFileName))
                    {
                        Directory.CreateDirectory(tempFileName);
                    }
                    mWinRARTemp = tempFileName;
                    return mWinRARTemp;

                    ////web.config配置项
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
