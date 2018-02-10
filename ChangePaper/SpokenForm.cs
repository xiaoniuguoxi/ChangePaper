using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace ChangePaper
{
    public partial class SpokenForm : Form
    {
        string PWD = "hytSpokenExam";
        string filePaper;
        string fileCode;
        string fileResult;
        string fileSign;
        public SpokenForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择试卷文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_paper_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "试卷包文件(*.sjp)|*.sjp;";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePaper = ofd.FileName;
                txt_paper.Text = filePaper;
                fileCode = filePaper.Replace(".sjp", ".code");
                if (File.Exists(fileCode))
                {
                    txt_code.Text = fileCode;
                }
            }
        }

        /// <summary>
        /// 选择授权码文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_code_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "试卷包文件(*.code)|*.code;";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileCode = ofd.FileName;
                txt_code.Text = fileCode;
                filePaper = fileCode.Replace(".code", ".sjp");
                if (File.Exists(fileCode))
                {
                    txt_paper.Text = filePaper;
                }
            }
        }

        /// <summary>
        /// 转换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_change_Click(object sender, EventArgs e)
        {
            string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tempSpoken");
            FileHelper.DeleteFolder(tempPath);
            Directory.CreateDirectory(tempPath);

            if (!File.Exists(filePaper) || !File.Exists(fileCode))
            {
                MessageBox.Show("请选择试卷包和授权码！");
                return;
            }
            //1、复制源文件到临时目录
            string filePaperTemp = Path.Combine(tempPath, new FileInfo(filePaper).Name);
            string fileCodeTemp = Path.Combine(tempPath, new FileInfo(fileCode).Name);
            FileHelper.FileCopy(filePaper, filePaperTemp, true);
            FileHelper.FileCopy(fileCode, fileCodeTemp, true);

            //2、固定密码解密otp，并解压
            string paperTemp = tempPath + "\\paperTemp";
            //校验试卷文件头类型
            Sign(filePaperTemp);
            int result1 = SecModule.FileVerify(PWD, filePaperTemp);
            int unResult1 = FileCompress.DecompressFile(filePaperTemp, paperTemp, PWD, null);




            //3、固定密码解密osqm，并解压
            string codeTemp = tempPath + "\\codeTemp";
            int result2 = SecModule.FileVerify(PWD, fileCodeTemp);
            FileCompress.DecompressFile(fileCodeTemp, codeTemp, PWD, null);



            //4、授权码解密试卷包，并解压
            string strContent= File.ReadAllText(Path.Combine(codeTemp,"Code.ini"));
            string sqmm = strContent.Substring(strContent.IndexOf('=') + 1, strContent.IndexOf("ZIPMd5Code=") - strContent.IndexOf('=') - 3);
           
            FileInfo[] fileList = new DirectoryInfo(paperTemp).GetFiles();
            foreach (FileInfo fi in fileList)
            {
                if (fi.Extension.Equals(".zip"))
                {
                    int a = SecModule.FileVerify(sqmm, fi.FullName);
                    FileCompress.DecompressFile(fi.FullName, paperTemp, PWD, null);
                }
            }


            //5、固定密码解密ksj，并解压
            string kjsForder = "";
            fileList = new DirectoryInfo(paperTemp).GetFiles();
            foreach (FileInfo fi in fileList)
            {
                if (fi.Extension.Equals(".ksj"))
                {
                    int result3 = SecModule.FileVerify(PWD, fi.FullName);
                    kjsForder = paperTemp + "\\" + fi.Name.Replace(".ksj", "");
                    FileCompress.DecompressFile(fi.FullName, kjsForder, PWD, null);
                }
            }

            //DoPaper(paperTemp + "\\PaperInfo.xml", kjsForder + "\\js\\requestData.json");
        }

        /// <summary>
        /// 转换Paper.xml
        /// </summary>
        /// <param name="paperInfo"></param>
        /// <param name="requestData"></param>
        private void DoPaper(string paperInfoPath, string requestData)
        {
            Paper paper = new Paper(paperInfoPath, requestData);

            paper.GetOptionList();

            string xml = "<?xml version=\"1.0\" encoding=\"Utf-8\"?>"
                       + "<Paper><PaperInfo>" + paper.GetPaperInfo() + "</PaperInfo>"
                       + "<QuestionTypeList AutoNo=\"{2}\">{3}</QuestionTypeList>";
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "结果包文件(*.oda)|*.oda;";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileResult = ofd.FileName;
                txt_result.Text = fileResult;
                fileSign = fileResult.Replace(".oda", ".okw");
                if (File.Exists(fileSign))
                {
                    txt_sign.Text = fileSign;
                }
            }
        }

        private void btn_sign_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "结果包签名文件(*.okw)|*.okw;";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileSign = ofd.FileName;
                txt_sign.Text = fileResult;
                fileResult = fileSign.Replace(".oda", ".okw");
                if (File.Exists(fileSign))
                {
                    txt_sign.Text = fileSign;
                }
            }
        }

        private void btn_changeResult_Click(object sender, EventArgs e)
        {
            string odaTemp = "";
            ChangeResultPack.Main.Open(txt_result.Text.Trim(), txt_sign.Text.Trim(), out odaTemp);
        }


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
            catch{}
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
    }





}
