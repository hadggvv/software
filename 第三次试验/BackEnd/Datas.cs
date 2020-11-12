using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Project
{
    public class Datas
    {
        //词库
        public static Dictionary<int, List<string>> Lexicon { get; set; } = new Dictionary<int, List<string>>();
        //核心词汇
        public static List<string> CoreWords { get; set; }
        //资源文件中所有文章的题目（获取文章详情由DataProvider类提供接口）
        public static List<string> ParaTitleList { get; set; } = new List<string>();

        //资源文件中所有词汇真题（获取题目详情由DataProvider类提供接口）
        public static List<string> QuesTitleList { get; set; } = new List<string>();
        //从xml文件提取词库
        public static List<string> InitLexicon(string xmlFileName)
        {
            List<string> WordList = new List<string>();
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("./../../Resource/" + xmlFileName);
                XmlNode root = xd.DocumentElement;
                // Console.WriteLine(root.InnerText);
                XmlNodeList nodes = root.SelectNodes("/wordbook/item/word");
                foreach (XmlNode node in nodes)
                {
                    WordList.Add(node.InnerText);
                }

            }
            catch (XmlException e)
            {
                MessageBox.Show("Exception caught:  " + e);
                return null;
            }
            return WordList;
        }

        //初始化ParaTitleList和QuesTitleList
        public static void InitTitleList()
        {
            FileSystemInfo info = new DirectoryInfo(@"./../../Resource/Paragraphes");
            FileSystemInfo info1 = new DirectoryInfo(@"./../../Resource/Questions");
            if (!info.Exists || !info1.Exists)
                return;
            FileSystemInfo[] files = ((DirectoryInfo)info).GetFileSystemInfos();
            Array.ForEach(files, finfo =>
            ParaTitleList.Add(finfo.Name.Substring(0, finfo.Name.LastIndexOf('.'))));
            files = ((DirectoryInfo)info1).GetFileSystemInfos();
            Array.ForEach(files, finfo =>
            QuesTitleList.Add(finfo.Name.Substring(0, finfo.Name.LastIndexOf('.'))));
        }
    }
}
