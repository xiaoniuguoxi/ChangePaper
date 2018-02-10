using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace ChangePaper
{
    public class Paper
    {
        string paperInfoPath;
        string requestData;
        public Paper(string _paperInfoPath, string _requestData)
        {
            this.paperInfoPath = _paperInfoPath;
            this.requestData = _requestData;
        }


        //试卷信息{6}
        string PaperInfo = "<PaperName name=\"PaperName\">{0}</PaperName><!--//试卷名称-->"
                                                     + "<PaperNO name=\"PaperNO\">{1}</PaperNO><!--//试卷编号-->"
                                                     + "<PaperMemo name=\"PaperMemo\">{2}</PaperMemo><!--//试卷说明-->"
                                                     + "<PaperType name=\"PaperType\">{3}</PaperType><!--//试卷类别(暂没用到,预设)-->"
                                                     + "<ExamTime name=\"ExamTime\">{4}</ExamTime><!--//考试总时长(单位：分钟)-->"
                                                     + "<ShowModel name=\"ShowModel\">{5}</ShowModel><!--//试卷显示模式, ShowModel值为(1或2) 1为：800*600；2：1024*768-->"
                                                     + "<Times name=\"Times\">{6}</Times>";

        //题型{3}
        string QuestionType = "<QuestionTypeNO name=\"QuestionTypeNO\">{0}</QuestionTypeNO>"
                                                       + "<ParentNO name=\"ParentNO\">{1}</ParentNO>"
                                                       + "<QuestionTypeName name=\"QuestionTypeName\">{2}</QuestionTypeName>"
                                                       + "<QuestionMemo name=\"QuestionMemo\">"
                                                       + "</QuestionMemo><Index name=\"Index\">{3}</Index>";


        //题目{13}
        string Question = "<QuestionNO name=\"QuestionNO\">{0}</QuestionNO>"
                                                   + "<SectionNO name=\"SectionNO\">{1}</SectionNO>"
                                                   + "<QuestionTypeNO name=\"QuestionTypeNO\">{2}</QuestionTypeNO>"
                                                   + "<QuestionName name=\"QuestionName\">{3}</QuestionName>"
                                                   + "<StandardAnswer name=\"StandardAnswer\">{4}</StandardAnswer>"
                                                   + "<TxtAnswerPath name=\"TxtAnswerPath\">{5}</TxtAnswerPath>"
                                                   + "<AudioAnswerPath name=\"AudioAnswerPath\">{6}</AudioAnswerPath>"
                                                   + "<StandardScore name=\"StandardScore\">{7}</StandardScore>"
                                                   + "<QuestionMemo name=\"QuestionMemo\">{8}</QuestionMemo>"
                                                   + "<CheckNumber name=\"CheckNumber\">{9}</CheckNumber>"
                                                   + "<PageNO name=\"PageNO\">{10}</PageNO>"
                                                   + "<GlobalIndex name=\"GlobalIndex\">{11}</GlobalIndex>"
                                                   + "<Index name=\"Index\">{12}</Index>"
                                                   + "<MaxFontCount name=\"MaxFontCount\">{13}</MaxFontCount>";

        //章节{4}
        string Section = "<ParentNO name=\"ParentNO\">{0}</ParentNO>"
                                                  + "<SectionNO name=\"SectionNO\">{1}</SectionNO>"
                                                  + "<SectionName name=\"SectionName\">{2}</SectionName>"
                                                  + "<StandardScore name=\"StandardScore\">{3}<StandardScore>"
                                                  + "<SectionMemo name=\"SectionMemo\"/>"
                                                  + "<SectionSavePath name=\"SectionSavePath\"/>"
                                                  + "<Index name=\"Index\">{4}</Index>";
        //试卷{1}
        string Page = "<PageNO name=\"PageNO\">{0}</PageNO>"
                                               + "<PageName name=\"PageName\">{1}</PageName>"
                                               + "<SectionNO name=\"SectionNO\"/>"
                                               + "<PageMemo name=\"PageMemo\"/>";

        //章节{6}
        string Option = "<OptionNO name=\"OptionNO\">{0}</OptionNO>"
                                                 + "<FileName name=\"FileName\"/>"
                                                 + "<PageNO name=\"PageNO\">{1}</PageNO>"
                                                 + "<WaitTime name=\"WaitTime\">{2}</WaitTime>"
                                                 + "<QuestionNO name=\"QuestionNO\">{3}</QuestionNO>"
                                                 + "<OptionName name=\"OptionName\">{4}</OptionName>"
                                                 + "<Index name=\"Index\">{5}</Index>"
                                                 + "<BIndex name=\"BIndex\">{6}</BIndex>";
        //字体
        string FontList = "<FontList AutoNo=\"0\"><Font id=\"0\"><FontNO name=\"FontNO\">1</FontNO><FontName name=\"FontName\">宋体</FontName><Index name=\"Index\"></Index><IsSystemFont name=\"IsSystemFont\">1</IsSystemFont></Font><Font id=\"0\"><FontNO name=\"FontNO\">2</FontNO><FontName name=\"FontName\">黑体</FontName><Index name=\"Index\"></Index><IsSystemFont name=\"IsSystemFont\">1</IsSystemFont></Font></FontList>";

        //字幕
        string Caption = "<QuestionNO name=\"QuestionNO\">QT-698258</QuestionNO>"
                                                + "<CaptionNO name=\"CaptionNO\">QT-698258_1</CaptionNO>"
                                                + "<CaptionName name=\"CaptionName\">A</CaptionName>"
                                                + "<CaptionValue name=\"CaptionValue\">1</CaptionValue>"
                                                + "<Sign name=\"Sign\">1</Sign>"
                                                + "<Index name=\"Index\">10</Index>";



        public string GetPaperInfo()
        {
            string PaperName = XmlHelper.Read(paperInfoPath, "PaperInfo/PackList/PackData/zbwjm", "");//试卷名称
            string PaperNO = XmlHelper.Read(paperInfoPath, "PaperInfo/PaperList/PaperData/sjdm", "");//试卷代码
            string PaperMemo = "";//试卷说明
            string PaperType = XmlHelper.Read(paperInfoPath, "PaperInfo/PaperList/PaperData/sjlx", "");
            string ExamTime = "";//考试时间
            string ShowModel = "0";//试卷显示模式, ShowModel值为(1或2) 1为：800*600；2：1024*768
            //（新增)试卷所使用的考试场次,默认值为0,表示可用于任何考试场次,用于多个场次时，中间用逗号隔开，比如：1,3,5 
            string Times = XmlHelper.Read(paperInfoPath, "PaperInfo/PaperList/PaperData/kspc", "");
            string Version = "";
            string CreateTime = "";
            string EditTime = "";
            return string.Format(PaperInfo, PaperName, PaperNO, PaperMemo, PaperType, ExamTime, ShowModel, Times, Version, CreateTime, EditTime);
        }


        public string GetQuestionTypeList()
        {
            string QuestionTypeNO = XmlHelper.Read(paperInfoPath, "PaperInfo/PackList/PackData/zbwjm", "");//试卷名称
            string ParentNO = XmlHelper.Read(paperInfoPath, "PaperInfo/PaperList/PaperData/sjdm", "");//试卷代码
            string QuestionTypeName = "";//试卷说明
            string QuestionMemo = XmlHelper.Read(paperInfoPath, "PaperInfo/PaperList/PaperData/sjlx", "");
            return string.Format(PaperInfo, QuestionTypeNO, ParentNO, QuestionTypeName, QuestionMemo);
        }

        /// <summary>
        /// 获取小题列表
        /// </summary>
        /// <returns></returns>
        public string GetQuestionList()
        {
            StringBuilder sb = new StringBuilder();
            XmlElement list = XmlHelper.GetXmlElement(paperInfoPath, "PaperInfo/ItemList");
            foreach (XmlNode node in list)
            {
                string QuestionNO = node.SelectSingleNode("xtdm").InnerText;//小题代码
                string SectionNO = node.SelectSingleNode("dth").InnerText;//大题号
                string QuestionTypeNO = node.SelectSingleNode("xtlx").InnerText;
                string QuestionName = "";// node.SelectSingleNode("xtdm").InnerText;
                string StandardAnswer = node.SelectSingleNode("rightKey").InnerText;
                string TxtAnswerPath = node.SelectSingleNode("xtdm").InnerText;
                string AudioAnswerPath = "";// node.SelectSingleNode("xtdm").InnerText;
                string StandardScore = node.SelectSingleNode("mf").InnerText;//满分
                string QuestionMemo = node.SelectSingleNode("xtms").InnerText;//小题描述
                string CheckNumber = "";// node.SelectSingleNode("xtdm").InnerText;
                string PageNO = "";// node.SelectSingleNode("xtdm").InnerText;
                string GlobalIndex = "";// node.SelectSingleNode("xtdm").InnerText;
                string Index = node.SelectSingleNode("xth").InnerText;//小题号
                string MaxFontCount = "";// node.SelectSingleNode("xth").InnerText;//
                sb.Append("<Question name=\"Question\" id=\"" + Index + "\">");
                sb.Append(string.Format(Question, QuestionNO, SectionNO, QuestionTypeNO, QuestionName, StandardAnswer, TxtAnswerPath, AudioAnswerPath, StandardScore, QuestionMemo, CheckNumber, PageNO, GlobalIndex, Index, MaxFontCount));
                sb.Append("</Question>");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取章节列表
        /// </summary>
        /// <returns></returns>
        public string GetSectionList()
        {
            StringBuilder sb = new StringBuilder();
            XmlElement list = XmlHelper.GetXmlElement(paperInfoPath, "PaperInfo/PaperQuesList ");
            foreach (XmlNode node in list)
            {
                string ParentNO = "0";
                string SectionNO = node.SelectSingleNode("dth").InnerText;//大题号
                string SectionName = node.SelectSingleNode("dtmc").InnerText;//大题/章节名称
                string StandardScore = node.SelectSingleNode("mf").InnerText;//满分
                string SectionMemo = "";
                string SectionSavePath ="";
                string Index = SectionNO;
               
                sb.Append("<Section name=\"Section\" id=\"1\">");
                sb.Append(string.Format(Section, ParentNO, SectionNO, SectionName, StandardScore, Index));
                sb.Append("</Section>");
            }
            return sb.ToString();
        }


        /// <summary>
        /// 获取步骤列表
        /// </summary>
        /// <returns></returns>
        public string GetOptionList()
        {
            return "";
        }
    }


}
