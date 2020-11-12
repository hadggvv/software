using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project;

namespace project
{
    public partial class FullFillControl : UserControl
    {
        List<Word> WordList { get; set; }
        int Index { get; set; } = 0;
        MainWindow MainWin { get; set; }
        int ModeFlag { get; set; }//0是例句填空，1是词组搭配
        public FullFillControl(MainWindow ParentCtrl,int modeFlag)
        {
            ModeFlag = modeFlag;
            this.MainWin = ParentCtrl;
            this.WordList = MainWin.WordModeCtrl.WordList;
            InitializeComponent();
            StudyLoop();
        }
        public void StudyLoop()
        {
            if (Index < WordList.Count)
            {
                try
                {
                    this.pictureBox1.Load(WordList[Index].KeyWord + ".png");
                }
                catch
                {
                    this.pictureBox1.Load("./../../Resources/empty.jpg");
                }
                if (ModeFlag == 0)
                {
                    lblTrans.Text = WordList[Index].Translations[0];
                    try
                    {
                        lblStc.Text = WordList[Index].Examples[0].EngStn.Replace(WordList[Index].KeyWord, "___");
                    }
                    catch
                    {
                        Index++;
                        StudyLoop();
                    }
                }
                else
                {
                    lblTrans.Text = WordList[Index].Collocations[0].WordGroup.ToLower().Replace(WordList[Index].KeyWord, "___");
                    string trans = WordList[Index].Collocations[0].GroupTran;
                    lblStc.Text = trans.Substring(0,trans.IndexOf(" "));
                }
            }
        }

        private void BtnSure_Click(object sender, EventArgs e)
        {
            if (tbInput.Text == WordList[Index].KeyWord && Index < WordList.Count - 1)
            {
                Index++;
                StudyLoop();
            }
            else if (tbInput.Text != WordList[Index].KeyWord)
                new ShowWordForm(MainWin,WordList[Index]).ShowDialog();
            else if (Index == WordList.Count - 1)
            {
                MessageBox.Show("恭喜你完成本轮复习！");
                MainWin.SubView.Controls.Clear();
                MainWin.SubView.Controls.Add(MainWin.WordModeCtrl);
            }
            tbInput.Text = "";
        }


        private void RetnBtn_Click(object sender, EventArgs e)
        {
            MainWin.SubView.Controls.Clear();
            MainWin.SubView.Controls.Add(MainWin.WordModeCtrl);
        }
    }
}
