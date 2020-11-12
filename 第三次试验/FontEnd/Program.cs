using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project;

namespace project
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Datas.Lexicon.Add(4,Datas.InitLexicon("CET-4.xml"));
            Datas.Lexicon.Add(6,Datas.InitLexicon("CET-6.xml"));
            Datas.CoreWords = Datas.InitLexicon("CORE.xml");
            Datas.InitTitleList();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogingWin());
        }
    }
}
