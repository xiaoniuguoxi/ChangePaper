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
using System.Xml;

namespace ChangePaper
{
    public partial class UpdatePaper : Form
    {
        string PWD = "hytOBTExam";
        string filePaper;
        string fileCode;
        string workPath;
        FileInfo updateFile;
        Dictionary<string, object> nets_dict;
        Dictionary<string, object> spoken_dict;
        Dictionary<string, object> nets_section_dict;
        Dictionary<string, object> spoken_section_dict;
        public UpdatePaper()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择制卷工作区目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_work_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                workPath = dialog.SelectedPath;
                txt_work.Text = workPath;
            }
        }

        /// <summary>
        /// 选择nets试卷包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_netsPaper_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "试卷包文件(*.otp)|*.otp;";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePaper = ofd.FileName;
                txt_netsPaper.Text = filePaper;
                fileCode = filePaper.Replace(".otp", ".osqm");
                if (File.Exists(fileCode))
                {
                    txt_netsCode.Text = fileCode;
                }
            }
        }

        /// <summary>
        /// 选择nets授权码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_netsCode_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "试卷包文件(*.osqm)|*.osqm;";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileCode = ofd.FileName;
                txt_netsCode.Text = fileCode;
                filePaper = fileCode.Replace(".osqm", ".otp");
                if (File.Exists(fileCode))
                {
                    txt_netsPaper.Text = filePaper;
                }
            }
        }

        /// <summary>
        /// 解密nets试卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_decode_Click(object sender, EventArgs e)
        {
            string tempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp_nets_paper");
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
            int result1 = SecModule.FileVerify(PWD, filePaperTemp);
            FileCompress.DecompressFile(filePaperTemp, paperTemp, PWD, null);

            //3、固定密码解密osqm，并解压
            string codeTemp = tempPath + "\\codeTemp";
            int result2 = SecModule.FileVerify(PWD, fileCodeTemp);
            FileCompress.DecompressFile(fileCodeTemp, codeTemp, PWD, null);

            //4、授权码解密试卷包，并解压
            string sqmm = XmlHelper.Read(codeTemp + "\\Codeinfo.xml", "CodeInfo/CodeData/sqmm", "");
            FileInfo[] fileList = new DirectoryInfo(paperTemp).GetFiles();
            foreach (FileInfo fi in fileList)
            {
                if (fi.Extension.Equals(".zip"))
                {
                    int a = SecModule.FileVerify(sqmm, fi.FullName);
                    FileCompress.DecompressFile(fi.FullName, paperTemp, PWD, null);
                }
            }

            //5、固定密码解密kjs，并解压
            string kjsForder = "";
            fileList = new DirectoryInfo(paperTemp).GetFiles();
            foreach (FileInfo fi in fileList)
            {
                if (fi.Extension.Equals(".kjs"))
                {
                    int result3 = SecModule.FileVerify(PWD, fi.FullName);
                    kjsForder = paperTemp + "\\" + fi.Name.Replace(".kjs", "");
                    FileCompress.DecompressFile(fi.FullName, kjsForder, PWD, null);
                }
            }

            ShowPaper(paperTemp + "\\PaperInfo.xml");
        }


        /// <summary>
        /// 展示nets和spoken试卷结构
        /// </summary>
        /// <param name="paperInfo"></param>
        /// <param name="requestData"></param>
        private void ShowPaper(string paperInfoPath)
        {
            string NetsPaperNO = XmlHelper.Read(paperInfoPath, "PaperInfo/PaperList/PaperData/sjdm", "");//试卷代码
            string workPath = txt_work.Text.Trim();
            DirectoryInfo diWork = new DirectoryInfo(workPath);
            DirectoryInfo[] diList = diWork.GetDirectories();
            bool flag = false;
            foreach (DirectoryInfo di in diList)
            {
                FileInfo[] fiList = di.GetFiles();
                foreach (FileInfo fi in fiList)
                {
                    if (fi.Name == "paper.xml")
                    {
                        updateFile = fi;
                        string SpokenPaperNo = XmlHelper.Read(fi.FullName, "Paper/PaperInfo/PaperNO", "");//试卷代码
                        string SpokenPaperName = XmlHelper.Read(fi.FullName, "Paper/PaperInfo/PaperName", "");//试卷代码

                        //nets树结构
                        string netsPaperName = XmlHelper.Read(paperInfoPath, "PaperInfo/PaperList/PaperData/sjmc", "");//试卷代码
                        TreeNode parentNode = new TreeNode(netsPaperName);
                        treeView2.Nodes.Clear();
                        treeView2.Nodes.Add(parentNode);
                        parentNode.Nodes.Add(NetsPaperNO);

                        XmlElement xe = XmlHelper.GetXmlElement(paperInfoPath, "PaperInfo/PaperQuesList");
                        XmlNodeList xnl = xe.ChildNodes;

                        List<string> sectionList = new List<string>();
                        List<string> list = new List<string>();

                        foreach (XmlNode xn in xnl)
                        {
                            TreeNode tnode = new TreeNode(xn.SelectSingleNode("dtmc").InnerText + "(" + xn.SelectSingleNode("dth").InnerText + ")");

                            xe = XmlHelper.GetXmlElement(paperInfoPath, "PaperInfo/ItemList");
                            xnl = xe.ChildNodes;
                            foreach (XmlNode xn1 in xnl)
                            {
                                if (xn1.SelectSingleNode("dth").InnerText == xn.SelectSingleNode("dth").InnerText)
                                {
                                    //剔除掉1-5，6-10这种小题
                                    if (xn1.SelectSingleNode("xtlx").InnerText == "SINGLE" || xn1.SelectSingleNode("xtlx").InnerText == "SPOKEN")
                                    {
                                        TreeNode tnode1 = new TreeNode(xn1.SelectSingleNode("xtdm").InnerText);
                                        tnode.Nodes.Add(tnode1);
                                        list.Add(xn1.SelectSingleNode("xtdm").InnerText);
                                    }
                                }
                            }
                            sectionList.Add(xn.SelectSingleNode("dth").InnerText);
                            parentNode.Nodes.Add(tnode);
                        }
                        treeView2.ExpandAll();
                        nets_dict = new Dictionary<string, object>();
                        nets_dict.Add("paperNo", NetsPaperNO);
                        nets_dict.Add("paperName", netsPaperName);
                        nets_dict.Add("questionList", list);
                        nets_dict.Add("sectionList", sectionList);

                        txt_paperNO.Text = NetsPaperNO;

                        if (NetsPaperNO == SpokenPaperNo)
                        {
                            parentNode = new TreeNode(SpokenPaperName);
                            treeView1.Nodes.Clear();
                            treeView1.Nodes.Add(parentNode);
                            parentNode.Nodes.Add(SpokenPaperNo);
                            //spoken树结构
                            xe = XmlHelper.GetXmlElement(fi.FullName, "Paper/SectionList");
                            xnl = xe.ChildNodes;
                            sectionList = new List<string>();
                            list = new List<string>();
                            foreach (XmlNode xn in xnl)
                            {
                                TreeNode tnode = new TreeNode(xn.SelectSingleNode("SectionName").InnerText + "(" + xn.SelectSingleNode("SectionNO").InnerText + ")");

                                xe = XmlHelper.GetXmlElement(fi.FullName, "Paper/QuestionList");
                                xnl = xe.ChildNodes;
                                foreach (XmlNode xn1 in xnl)
                                {
                                    if (xn1.SelectSingleNode("SectionNO").InnerText == xn.SelectSingleNode("SectionNO").InnerText)
                                    {
                                        TreeNode tnode1 = new TreeNode(xn1.SelectSingleNode("QuestionNO").InnerText);
                                        tnode.Nodes.Add(tnode1);
                                        list.Add(xn1.SelectSingleNode("QuestionNO").InnerText);
                                    }
                                }
                                sectionList.Add(xn.SelectSingleNode("SectionNO").InnerText);
                                parentNode.Nodes.Add(tnode);
                            }
                            treeView1.ExpandAll();
                            spoken_dict = new Dictionary<string, object>();
                            spoken_dict.Add("paperNo", SpokenPaperNo);
                            spoken_dict.Add("paperName", SpokenPaperName);
                            spoken_dict.Add("questionList", list);
                            spoken_dict.Add("sectionList", sectionList);

                            flag = true;
                            break;
                        }

                    }
                    if (flag)
                        break;
                }

            }
        }

        /// <summary>
        /// 修改spoken试卷xml中的试卷代码、小题代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count <= 0 || treeView2.Nodes.Count <= 0)
            {
                MessageBox.Show("试卷解析失败，无法更新！");
                return;
            }

            List<string> netsList = (List<string>)nets_dict["questionList"];
            List<string> spokenList = (List<string>)spoken_dict["questionList"];

            List<string> netsSectionList = (List<string>)nets_dict["sectionList"];
            List<string> spokenSectionList = (List<string>)spoken_dict["sectionList"];
            if (netsList.Count != spokenList.Count)
            {
                MessageBox.Show("两套试卷的小题数量不一致，请检查后再更新！");
                return;
            }
            DialogResult dr = MessageBox.Show("确定两套试卷结构及内容相同吗？", "信息确认", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(updateFile.FullName);
                string sourceStr = xdoc.InnerXml;

                //修改试卷名称
                sourceStr = sourceStr.Replace(spoken_dict["paperName"].ToString(), nets_dict["paperName"].ToString());
                //修改小题代码
                for (int i = 0; i < netsList.Count; i++)
                {
                    sourceStr = sourceStr.Replace(spokenList[i], netsList[i]);
                }

                //修改章节代码
                for (int i = 0; i < netsSectionList.Count; i++)
                {
                    sourceStr = sourceStr.Replace(spokenSectionList[i], netsSectionList[i]);
                }

                xdoc.LoadXml(sourceStr);
                xdoc.Save(updateFile.Directory + "\\paper.xml");

                string paperTemp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp_nets_paper\\paperTemp");
                ShowPaper(paperTemp + "\\PaperInfo.xml");
            }
        }

        private void btn_more_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }
    }
}
