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
using System.Threading;

namespace project
{
    
    public partial class ChiOrEngCtrl : UserControl
    {
        public event Action ProcessOn;
        List<Word> WordList { get; set; }
        //0为给中文选英文，1为给英文选中文,2为选择题,3听音选义
        int ModeFlag { get; set; }
        int Index { get; set; } = 0;
        MainWindow MainWin { get; set; }
        public ChiOrEngCtrl(MainWindow ParentCtrl, List<Word> WordList ,int mode)
        {
            
            this.MainWin = ParentCtrl;
            this.WordList = WordList; 
            ModeFlag = mode;
            InitializeComponent();
            if (mode == 1 || mode == 0)
                this.Return.Hide();
            StudyLoop();
            if(mode!=3)
                pictureBox1.Hide();
            if (mode == 3)
                rbChiOrEng.Hide();
            pictureBox1.Load("./../../Resources/音量.png");
        }
        public void StudyLoop()
        {
            if (Index<WordList.Count)
            {
                if (++WordList[Index].LearnTimes == 3)
                    WordList[Index].IsLearned = true;
                int index1=0, index2=0, index3=0, index4=0;
                switch(Index%4)
                {
                    case 0:
                        index1 = Index;
                        index2 = (Index + 1) % WordList.Count;
                        index3 = (Index + 2) % WordList.Count;
                        index4 = (Index + 3) % WordList.Count;
                        break;
                    case 1:
                        index3 = Index;
                        index2 = (Index + 1) % WordList.Count;
                        index1 = (Index + 2) % WordList.Count;
                        index4 = (Index + 3) % WordList.Count;
                        break;
                    case 2:
                        index2 = Index;
                        index3 = (Index + 1) % WordList.Count;
                        index1 = (Index + 2) % WordList.Count;
                        index4 = (Index + 3) % WordList.Count;
                        break;
                    case 3:
                        index4 = Index;
                        index2 = (Index + 1) % WordList.Count;
                        index3 = (Index + 2) % WordList.Count;
                        index1 = (Index + 3) % WordList.Count;
                        break;
                }
                if (ModeFlag == 0)
                {
                    rbChiOrEng.Text = WordList[Index].Translations[0];
                    button1.Text = WordList[index1].KeyWord;
                    button2.Text = WordList[index2].KeyWord;
                    button3.Text = WordList[index3].KeyWord;
                    button4.Text = WordList[index4].KeyWord;
                }
                else if(ModeFlag==1)
                {
                    rbChiOrEng.Text = WordList[Index].KeyWord;
                    button1.Text = WordList[index1].Translations[0];
                    button2.Text = WordList[index2].Translations[0];
                    button3.Text = WordList[index3].Translations[0];
                    button4.Text = WordList[index4].Translations[0];
                }
                else if(ModeFlag==2)
                {
                    try
                    {
                        rbChiOrEng.Text = WordList[Index].Examples[0].EngStn.Replace(WordList[Index].KeyWord, "___");
                    }
                    catch
                    {
                        Index++;
                        StudyLoop();
                    }
                    button1.Text = WordList[index1].KeyWord;
                    button2.Text = WordList[index2].KeyWord;
                    button3.Text = WordList[index3].KeyWord;
                    button4.Text = WordList[index4].KeyWord;
                }
                else
                {
                    rbChiOrEng.Hide();
                    pictureBox1.Show();
                    this.VoiceContorl.URL = WordList[Index].KeyWord + "_America.mp3";
                    this.VoiceContorl.Ctlcontrols.play();
                    button1.Text = WordList[index1].Translations[0];
                    button2.Text = WordList[index2].Translations[0];
                    button3.Text = WordList[index3].Translations[0];
                    button4.Text = WordList[index4].Translations[0];
                }
                button1.BackColor = Color.Transparent;
                button2.BackColor = Color.Transparent;
                button3.BackColor = Color.Transparent;
                button4.BackColor = Color.Transparent;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ModeFlag==0||ModeFlag==1)
                 ProcessOn();
            if (ModeFlag == 0||ModeFlag==2)
            {
                if (button1.Text == WordList[Index].KeyWord)
                    button1.BackColor = Color.CornflowerBlue;
                else
                    button1.BackColor = Color.PaleVioletRed;
            }
            else if (ModeFlag == 1 || ModeFlag == 3)
            {
                if (button1.Text == WordList[Index].Translations[0])
                    button1.BackColor = Color.CornflowerBlue;
                else
                    button1.BackColor = Color.PaleVioletRed;
            }
            ChangeBtnColor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ModeFlag == 0 || ModeFlag == 1)
                ProcessOn();
            if (ModeFlag == 0||ModeFlag==2)
            {
                if (button2.Text == WordList[Index].KeyWord)
                    button2.BackColor = Color.CornflowerBlue;
                else
                    button2.BackColor = Color.PaleVioletRed;
            }
            else if (ModeFlag == 1 || ModeFlag == 3)
            {
                if (button2.Text == WordList[Index].Translations[0])
                    button2.BackColor = Color.CornflowerBlue;
                else
                    button2.BackColor = Color.PaleVioletRed;
            }
            ChangeBtnColor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ModeFlag == 0 || ModeFlag == 1)
                ProcessOn();
            if (ModeFlag == 0 || ModeFlag == 2)
            {
                if (button3.Text == WordList[Index].KeyWord)
                    button3.BackColor = Color.CornflowerBlue;
                else
                    button3.BackColor = Color.PaleVioletRed;
            }
            else if (ModeFlag == 1 || ModeFlag == 3)
            {
                if (button3.Text == WordList[Index].Translations[0])
                    button3.BackColor = Color.CornflowerBlue;
                else
                    button3.BackColor = Color.PaleVioletRed;
            }
            ChangeBtnColor();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ModeFlag == 0 || ModeFlag == 1)
                ProcessOn();
            if (ModeFlag == 0 || ModeFlag == 2)
            {
                if (button4.Text == WordList[Index].KeyWord)
                    button4.BackColor = Color.CornflowerBlue;
                else
                    button4.BackColor = Color.PaleVioletRed;
            }
            else if (ModeFlag == 1||ModeFlag==3)
            {
                if (button4.Text == WordList[Index].Translations[0])
                    button4.BackColor = Color.CornflowerBlue;
                else
                    button4.BackColor = Color.PaleVioletRed;
            }
            ChangeBtnColor();
        }

        private void Return_Click(object sender, EventArgs e)
        {     
            MainWin.SubView.Controls.Clear();
            MainWin.SubView.Controls.Add(MainWin.WordModeCtrl);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.VoiceContorl.URL = WordList[Index].KeyWord + "_America.mp3";
            this.VoiceContorl.Ctlcontrols.play();
        }

        
        private void ChangeBtnColor()
        {
            string Answer = null;
            if (ModeFlag == 0 || ModeFlag == 2)
                Answer = WordList[Index].KeyWord;
            else if (ModeFlag == 1 || ModeFlag == 3)
                Answer = WordList[Index].Translations[0];
            if (button1.Text == Answer)
                button1.BackColor = Color.CornflowerBlue;
            else if (button2.Text == Answer)
                button2.BackColor = Color.CornflowerBlue;
            else if (button3.Text == Answer)
                button3.BackColor = Color.CornflowerBlue;
            else if (button4.Text == Answer)
                button4.BackColor = Color.CornflowerBlue;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (Index < WordList.Count && Index != WordList.Count - 1)
            {
                Index++;
                StudyLoop();
            }
        }
    }
}
