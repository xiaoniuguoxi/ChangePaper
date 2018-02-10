using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Security.Cryptography;

namespace ChangePaper
{
    public partial class Main : Form
    {
        string NETSPWD = "hytOBTExam";
        string SPOKENPWD = "hytSpokenExam";
        //
        List<PaperEntity> listPaperEntity = new List<PaperEntity>();
        public Main()
        {
            InitializeComponent();
        }

        #region 路径设定
        /// <summary>
        /// 设定nets试卷路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_brw_nets_paper_Click(object sender, EventArgs e)
        {
            txt_nets_paper.Text = selectPath();
        }
        /// <summary>
        /// 设定人机对话试卷路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_brw_spoken_paper_Click(object sender, EventArgs e)
        {
            txt_spoken_paper.Text = selectPath();
        }

        /// <summary>
        /// 设定nets考试结果路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_brw_nets_result_Click(object sender, EventArgs e)
        {
            txt_nets_result.Text = selectPath();
        }

        /// <summary>
        /// 设定转换结果保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            txt_save.Text = selectPath();
        }

        /// <summary>
        /// 选择路径
        /// </summary>
        /// <returns></returns>
        private string selectPath()
        {
            string path = "";
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }
            return path;
        }

        #endregion

        #region 试卷解压修改
        /// <summary>
        /// 解压nets试卷包
        /// </summary>
        /// <param name="filePaper"></param>
        /// <param name="fileCode"></param>
        /// <param name="tempPath"></param>
        private void unZipNetsPaper(FileInfo[] netsPaperFileList)
        {
            string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "netsTemp");
            FileHelper.DeleteFolder(tempPath);
            Directory.CreateDirectory(tempPath);

            foreach (FileInfo f in netsPaperFileList)
            {
                string filePaper = f.FullName;
                string fileCode = filePaper.Replace(".otp", ".osqm");
                if (f.Extension.Equals(".otp"))
                {
                    //1、复制源文件到临时目录
                    string filePaperTemp = Path.Combine(tempPath, new FileInfo(filePaper).Name);
                    string fileCodeTemp = Path.Combine(tempPath, new FileInfo(fileCode).Name);
                    FileHelper.FileCopy(filePaper, filePaperTemp, true);
                    FileHelper.FileCopy(fileCode, fileCodeTemp, true);

                    //2、固定密码解密otp，并解压
                    string fileName = f.Name.Replace(".otp", "");
                    string paperTemp = tempPath + "\\paperTemp\\" + fileName;
                    int result1 = SecModule.FileVerify(NETSPWD, filePaperTemp);
                    FileCompress.DecompressFile(filePaperTemp, paperTemp, NETSPWD, null);

                    //3、固定密码解密osqm，并解压
                    string codeTemp = tempPath + "\\codeTemp\\" + fileName;
                    int result2 = SecModule.FileVerify(NETSPWD, fileCodeTemp);
                    FileCompress.DecompressFile(fileCodeTemp, codeTemp, NETSPWD, null);

                    //4、授权码解密试卷包，并解压
                    string sqmm = XmlHelper.Read(codeTemp + "\\Codeinfo.xml", "CodeInfo/CodeData/sqmm", "");
                    FileInfo[] fileList = new DirectoryInfo(paperTemp).GetFiles();
                    foreach (FileInfo fi in fileList)
                    {
                        if (fi.Extension.Equals(".zip"))
                        {
                            int a = SecModule.FileVerify(sqmm, fi.FullName);
                            FileCompress.DecompressFile(fi.FullName, paperTemp, NETSPWD, null);
                        }
                    }

                    //5、固定密码解密kjs，并解压
                    string kjsForder = "";
                    fileList = new DirectoryInfo(paperTemp).GetFiles();
                    foreach (FileInfo fi in fileList)
                    {
                        if (fi.Extension.Equals(".kjs"))
                        {
                            int result3 = SecModule.FileVerify(NETSPWD, fi.FullName);
                            kjsForder = paperTemp + "\\" + fi.Name.Replace(".kjs", "");
                            FileCompress.DecompressFile(fi.FullName, kjsForder, NETSPWD, null);

                            //提取nets试卷xml中数据
                            FileInfo[] filePaperXmlList = new DirectoryInfo(paperTemp).GetFiles("PaperInfo.xml");
                            FileInfo filePaperXml = filePaperXmlList[0];
                            XmlElement xe = XmlHelper.GetXmlElement(filePaperXml.FullName, "/PaperInfo/PaperList");
                            XmlNodeList xnl = xe.ChildNodes;
                            PaperEntity pe = new PaperEntity(); ;
                            foreach (XmlNode xn in xnl)
                            {
                                pe.paperNo = xn.SelectSingleNode("sjdm").InnerText;
                            }

                            XmlElement xe1 = XmlHelper.GetXmlElement(filePaperXml.FullName, "/PaperInfo/ItemList");
                            XmlNodeList xnl1 = xe1.ChildNodes;
                            List<string> lists = new List<string>();
                            foreach (XmlNode xn1 in xnl1)
                            {
                                lists.Add(xn1.SelectSingleNode("xtdm").InnerText);
                            }
                            pe.questionNo = lists;

                            listPaperEntity.Add(pe);


                        }
                    }
                }

                //DoPaper(paperTemp + "\\PaperInfo.xml", kjsForder + "\\js\\requestData.json");
            }
        }

        /// <summary>
        /// 解压spoken试卷包
        /// </summary>
        /// <param name="filePaper"></param>
        /// <param name="fileCode"></param>
        /// <param name="tempPath"></param>
        private void unZipSpokenPaper(FileInfo[] spokenPaperFileList)
        {
            string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "spokenTemp");
            FileHelper.DeleteFolder(tempPath);
            Directory.CreateDirectory(tempPath);


            foreach (FileInfo f in spokenPaperFileList)
            {
                string filePaper = f.FullName;
                string fileCode = filePaper.Replace(".sjp", ".code");
                if (f.Extension.Equals(".sjp"))
                {
                    //1、复制源文件到临时目录
                    string filePaperTemp = Path.Combine(tempPath, f.Name);
                    string fileCodeTemp = Path.Combine(tempPath, new FileInfo(fileCode).Name);
                    FileHelper.FileCopy(filePaper, filePaperTemp, true);
                    FileHelper.FileCopy(fileCode, fileCodeTemp, true);

                    //2、固定密码解密otp，并解压
                    string fileName = f.Name.Replace(".sjp", "");
                    string paperTemp = tempPath + "\\paperTemp\\" + fileName;
                    //校验试卷文件头类型
                    UnSign(filePaperTemp);
                    int result1 = SecModule.FileVerify(SPOKENPWD, filePaperTemp);
                    int unResult1 = FileCompress.DecompressFile(filePaperTemp, paperTemp, SPOKENPWD, null);

                    //3、固定密码解密osqm，并解压
                    string codeTemp = tempPath + "\\codeTemp\\" + fileName;
                    int result2 = SecModule.FileVerify(SPOKENPWD, fileCodeTemp);
                    FileCompress.DecompressFile(fileCodeTemp, codeTemp, SPOKENPWD, null);



                    //4、授权码解密试卷包，并解压
                    string strContent = File.ReadAllText(Path.Combine(codeTemp, "Code.ini"));
                    string sqmm = strContent.Substring(strContent.IndexOf('=') + 1, strContent.IndexOf("ZIPMd5Code=") - strContent.IndexOf('=') - 3);

                    FileInfo[] fileList = new DirectoryInfo(paperTemp).GetFiles();
                    foreach (FileInfo fi in fileList)
                    {
                        if (fi.Extension.Equals(".zip"))
                        {
                            int a = SecModule.FileVerify(sqmm, fi.FullName);
                            FileCompress.DecompressFile(fi.FullName, paperTemp, SPOKENPWD, null);
                        }
                    }

                    //5、固定密码解密ksj，并解压
                    string kjsForder = "";
                    fileList = new DirectoryInfo(paperTemp).GetFiles();
                    int i = 0;
                    foreach (FileInfo fi in fileList)
                    {
                        if (fi.Extension.Equals(".ksj"))
                        {
                            int result3 = SecModule.FileVerify(SPOKENPWD, fi.FullName);
                            kjsForder = paperTemp + "\\" + fi.Name.Replace(".ksj", "");
                            FileCompress.DecompressFile(fi.FullName, kjsForder, SPOKENPWD, null);

                            //修改Spoken试卷包xml
                            editSpokenPaper(kjsForder, sqmm, listPaperEntity[i]);
                            i++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 修改Spoken试卷包xml
        /// </summary>
        /// <param name="kjsForder"></param>
        private void editSpokenPaper(string kjsForder, string sqmm, PaperEntity pe)
        {
            //修改paper.xml
            FileInfo[] filePaperXmlList = new DirectoryInfo(kjsForder).GetFiles("paper.xml");
            FileInfo filePaperXml = filePaperXmlList[0];
            //修改试卷代码
            XmlHelper.Update(filePaperXml.FullName, "/Paper/PaperInfo/PaperNO", "", pe.paperNo);

            //修改试卷小题代码
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePaperXml.FullName);
                XmlElement xe = doc.SelectSingleNode("/Paper/QuestionList") as XmlElement;
                XmlNodeList xnl = xe.ChildNodes;
                int i = 0;
                foreach (XmlNode xn in xnl)
                {
                    XmlNode xnQuestionNO = xn.SelectSingleNode("QuestionNO");
                    XmlElement xe01 = (XmlElement)xnQuestionNO;
                    xe01.InnerText = pe.questionNo[i];
                    doc.Save(filePaperXml.FullName);
                    i++;
                }

                //压缩加密spoken试卷包
                DirectoryInfo di = new DirectoryInfo(kjsForder);
                string saveFile = txt_save.Text.Trim() + "\\" + di.Name + ".ksj";
                //压缩ksj
                FileCompress.CompressFiles(kjsForder, saveFile, SPOKENPWD, null, true);
                //固定密码加密kjs
                int result3 = SecModule.FileVerify(SPOKENPWD, saveFile);


                //第二次压缩成zip
                string saveFile1 = saveFile.Replace(".ksj", ".zip");
                FileCompress.CompressFiles(saveFile, saveFile1, SPOKENPWD, null, true);
                //授权码加密zip
                int result2 = SecModule.FileVerify(sqmm, saveFile1);

                //第三压缩成zip
                string saveFile2 = saveFile.Replace(".ksj", ".zip");

                FileCompress.CompressFiles(saveFile1, txt_save.Text.Trim(), SPOKENPWD, null, true);
                //授权码加密zip
                //int result2 = SecModule.FileVerify(sqmm, saveFile1);
            }
            catch { }

        }
        #endregion

        #region 工具方法
        public static int ByteConvertInt(byte[] b, int count = 0)
        {
            if (b != null && b.Length > 0)
            {
                int num = 0;
                int len = (count == 0) ? b.Length : (count < b.Length) ? count : b.Length;
                for (int i = 0; i < len; i++)
                {
                    num = (b[i] & 0xff) << (i * 8) | num;
                }
                return num;
            }
            else
            {
                return 0;
            }
        }

        private bool Sign(string tempFile)
        {
            List<int> listSplitNum = new List<int>();
            listSplitNum.Add(4);//读取文件系统标识需要的字节长度 SPK
            listSplitNum.Add(2);//读取文件标志总长度需要的字节长度 201
            listSplitNum.Add(2);//读取文件类型需要的字节长度 1
            listSplitNum.Add(4);//读取文件版本号需要的字节长度
            listSplitNum.Add(8);//读取文件主体大小需要的字节长度 
            listSplitNum.Add(32);//读取文件主体MD5需要的字节长度
            listSplitNum.Add(100);//读取文件内部文件名需要的字节长度

            FileInfo fi = new FileInfo("D:\\test.txt");

            byte[] l4 = Encoding.Default.GetBytes("SPK ");
            byte[] l2 = BitConverter.GetBytes((short)201);
            byte[] ll2 = BitConverter.GetBytes((short)1);
            byte[] ll4 = Encoding.Default.GetBytes("1.01");
            byte[] l8 = BitConverter.GetBytes((long)fi.Length);
            byte[] l32 = Encoding.Default.GetBytes(GetMD5HashFromFile(fi.FullName));
            byte[] l10 = Encoding.Default.GetBytes("0123456789");

            Stream s = new MemoryStream();
            s.Write(l4, 0, 4);
            s.Write(l2, 0, 2);
            s.Write(ll2, 0, 2);
            s.Write(ll4, 0, 4);
            s.Write(l8, 0, 8);
            s.Write(l32, 0, 32);
            s.Write(l10, 0, 10);

            byte[] content = new byte[fi.Length];
            FileStream fs = new FileStream(fi.FullName, FileMode.Open);
            fs.Read(content, 0, (int)fi.Length);

            s.Write(content, 0, (int)fi.Length);

            s.Position = 0;
            int size = 62 + (int)fi.Length;
            byte[] full = new byte[size];
            int r = s.Read(full, 0, size);

            return true;
        }

        private bool UnSign(string tempFile)
        {
            bool flag = false;
            List<byte[]> ListSpiltBytes = new List<byte[]>();
            List<string> ListSpiltStr = new List<string>();
            List<int> listSplitNum = new List<int>();
            listSplitNum.Add(4);//读取文件系统标识需要的字节长度
            listSplitNum.Add(2);//读取文件标志总长度需要的字节长度
            listSplitNum.Add(2);//读取文件类型需要的字节长度
            listSplitNum.Add(4);//读取文件版本号需要的字节长度
            listSplitNum.Add(8);//读取文件主体大小需要的字节长度
            listSplitNum.Add(32);//读取文件主体MD5需要的字节长度
            listSplitNum.Add(100);//读取文件内部文件名需要的字节长度

            List<string> listSpiltStr = new List<string>();
            FileStream fs = null;
            try
            {
                fs = new FileStream(tempFile, FileMode.Open);
                int offset = 0;
                int temp = 0;
                int beginMd5Size = 0;
                foreach (int num in listSplitNum)
                {
                    temp++;
                    byte[] bt = new byte[num];
                    fs.Seek(offset, SeekOrigin.Begin);
                    fs.Read(bt, 0, num);
                    if (temp <= 5)
                    {
                        beginMd5Size += num;
                    }
                    if (temp == 2 || temp == 3 || temp == 5)
                    {
                        listSpiltStr.Add(ByteConvertInt(bt, num).ToString());
                    }
                    else
                    {
                        listSpiltStr.Add(Encoding.Default.GetString(bt));
                    }
                    offset += num;
                }

                ListSpiltStr = listSpiltStr;
                List<byte[]> listSpiltBytes = new List<byte[]>();
                int Size = 0;
                int.TryParse(listSpiltStr[1], out Size);
                //Size += 16;
                byte[] btCodeMd5 = new byte[32];//存储试卷授权码文件md5信息的字节流
                fs.Seek(Size - 32, SeekOrigin.Begin);
                fs.Read(btCodeMd5, 0, 32);


                byte[] btJtp = new byte[fs.Length - Size];//存储整个jtp文件的字节流
                fs.Seek(Size, SeekOrigin.Begin);
                fs.Read(btJtp, 0, (int)fs.Length - Size);

                byte[] btJtpHead = new byte[Size];//存储jtp文件所有头部信息的字节流
                fs.Seek(0, SeekOrigin.Begin);
                fs.Read(btJtpHead, 0, Size);
                listSpiltBytes.Add(btJtpHead);
                ListSpiltBytes = listSpiltBytes;

                if (fs != null)
                {
                    fs.Flush();
                    fs.Close();
                    fs = null;
                }
                FileInfo fi = new FileInfo(tempFile);
                if (fi.Exists)
                {
                    fi.Delete();
                }
                FileStream fsJtp = null;

                fsJtp = new FileStream(tempFile, FileMode.CreateNew);
                if (fsJtp != null)
                {
                    fsJtp.Write(btJtp, 0, btJtp.Length);
                    fsJtp.Flush();
                    fsJtp.Close();
                    fsJtp = null;
                }
                if (fsJtp != null)
                {
                    fsJtp.Flush();
                    fsJtp.Close();
                    fsJtp = null;
                }

                flag = true;
            }
            catch { }
            finally
            {
                if (fs != null)
                {
                    fs.Flush();
                    fs.Close();
                    fs = null;
                }
            }
            return flag;
        }

        public string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, System.IO.FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// 开始转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_change_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nets_paper.Text.Trim()))
            {
                MessageBox.Show("请选择NETS试卷路径！");
                return;
            }
            if (string.IsNullOrEmpty(txt_spoken_paper.Text.Trim()))
            {
                MessageBox.Show("请选择SPOKEN试卷路径！");
                return;
            }
            if (string.IsNullOrEmpty(txt_nets_paper.Text.Trim()))
            {
                MessageBox.Show("请选择NETS试卷路径！");
                return;
            }

            //nets试卷列表
            FileInfo[] netsPaperFileList = new DirectoryInfo(txt_nets_paper.Text).GetFiles();
            //spoken试卷列表
            FileInfo[] spokenPaperFileList = new DirectoryInfo(txt_spoken_paper.Text).GetFiles();
            if (netsPaperFileList.Count() != spokenPaperFileList.Count() || netsPaperFileList.Count() <= 0)
            {
                MessageBox.Show("NETS试卷路径下文件数与SPOKEN路径下不符，或者文件数为零！");
                return;
            }


            //解开nets试卷包
            //unZipNetsPaper(netsPaperFileList);
            //解开Spoken试卷包
            //unZipSpokenPaper(spokenPaperFileList);

            //解开结果包

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stuTemp = "C:\\stuTemp";
            FileHelper.DeleteFolder(stuTemp);
            Directory.CreateDirectory(stuTemp);
            string resultTemp = "C:\\resultTemp";
            FileHelper.DeleteFolder(resultTemp);
            Directory.CreateDirectory(resultTemp);
            string signTemp = "C:\\signTemp";
            FileHelper.DeleteFolder(signTemp);
            Directory.CreateDirectory(signTemp);
            string resultFolder = txt_nets_result.Text.Trim();
            if (string.IsNullOrEmpty(resultFolder))
            {
                MessageBox.Show("请选择NETS结果包路径！");
                return;
            }
            string saveFolder = txt_save.Text.Trim();
            if (string.IsNullOrEmpty(saveFolder))
            {
                MessageBox.Show("请选择转换后路径！");
                return;
            }
            FileHelper.DeleteFolder(saveFolder);
            Directory.CreateDirectory(saveFolder);

            DirectoryInfo di = new DirectoryInfo(resultFolder);
            FileInfo[] fileList = di.GetFiles();
            foreach (FileInfo f in fileList)
            {
                string odaTemp = "";
                string oda = "";
                string okw = "";
                if (f.Extension == ".oda")
                {
                    oda = f.FullName;
                    okw = oda.Replace(".oda", ".okw");
                    //解开nets结果包
                    ChangeResultPack.Main.Open(oda, okw, out odaTemp);
                    //创建spoken结果包ccda.xml
                    ChangeResultPack.Main.CreateCcdaXml(odaTemp + "\\ExamData.xml", odaTemp + "\\ExamAnswer.xml", resultTemp);
                    //创建spoken结果包cckw.xml
                    ChangeResultPack.Main.CreateCckwXml(odaTemp + "\\ExamData.xml", odaTemp + "\\ExamAnswer.xml", signTemp);

                    DirectoryInfo diSpoken = new DirectoryInfo(odaTemp + "\\SPOKEN");
                    DirectoryInfo[] stusFolder = diSpoken.GetDirectories();
                    foreach (DirectoryInfo sf in stusFolder)
                    {
                        if (sf.Name == "temp")
                            continue;
                        FileHelper.FolderCreate(stuTemp);
                        DirectoryInfo diStu = new DirectoryInfo(sf.FullName);

                        FileInfo[] queFolder = diStu.GetFiles();
                        foreach (FileInfo qf in queFolder)
                        {
                            //将考生小题下的录音文件解压到stuTemp
                            FileCompress.DecompressFile(qf.FullName, stuTemp, null, null);
                        }
                        //创建Answer.xml到stuTemp
                        ChangeResultPack.Main.CreateAnswerXml(sf.FullName, odaTemp + "\\ExamAnswer.xml", stuTemp);

                        FileCompress.CompressFolder(stuTemp, Path.Combine(resultTemp, diStu.Name + ".zip"), null, null);

                        FileHelper.DeleteFolder(stuTemp);
                    }
                    //压缩考试结果包cdp
                    string zipFile = Path.Combine(saveFolder, f.Name.Replace(".oda", ".zip"));
                    int result1 = FileCompress.CompressFolder(resultTemp, zipFile, SPOKENPWD, null);
                    //固定密码加密结果包cdp
                    int result2 = SecModule.FileSign(SPOKENPWD, zipFile);
                    string cdpFile= Path.ChangeExtension(zipFile, ".cdp");
                    FileHelper.FileMove(zipFile, cdpFile);


                    //压缩考试结果签名包ckp
                    zipFile = Path.Combine(saveFolder, f.Name.Replace(".oda", ".zip"));
                    int result3 = FileCompress.CompressFolder(signTemp, zipFile, SPOKENPWD, null);
                    //固定密码加密结果签名包ckp
                    int result4 = SecModule.FileSign(SPOKENPWD, zipFile);
                    string ckpFile= Path.ChangeExtension(zipFile, ".ckp");
                    FileHelper.FileMove(zipFile, ckpFile);

                    FileHelper.FileDel(zipFile);

                }
            }


        }
    }

    public struct PaperEntity
    {
        public string paperNo;
        public List<string> questionNo;
    }
}