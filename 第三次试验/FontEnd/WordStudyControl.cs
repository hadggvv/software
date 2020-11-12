using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace project
{
    public partial class WordStudyControl : System.Windows.Forms.UserControl
    {
        public List<Word> WordList;//要学习的单词列表
        public int Index { get; set; } = 0;//索引
        public string ShowStr;//展示的字符串
        public int Sum;//要学习的单词总数
        public int ProcessCount { get; set; } = 0;
        public MainWindow MainWin { get; set; }
        public int PreCount { get; set; } = 0;
        public bool AllowProcess { get; set; } = true;
        public int Mode{get;set;}//0单词模式，1文章学词

        public WordStudyControl(MainWindow mainWin,List<Word> WordList,int mode)
        {
            InitializeComponent();
            Mode = mode;
            this.MainWin = mainWin;
            this.WordList = WordList;
            Sum = WordList.Count;
            this.progressBar1.Maximum = Sum*3;
            this.progressBar1.Value = ProcessCount;
            Loop1();
            ShowThePicture();
        }
        

        public void Loop1()
        {
        //    MessageBox.Show(Index.ToString() + ProcessCount.ToString());
            lblWord.Text = WordList[Index].KeyWord;
            if (WordList[Index].Translations.Count == 0)
            {
                WordList[Index].LearnTimes = 1;
                Word word = Clawler.DownLoad(WordList[Index].KeyWord);
                WordList[Index].Annotation = word.Annotation;
                WordList[Index].Examples = word.Examples;
                WordList[Index].Collocations = word.Collocations;
                WordList[Index].Translations = word.Translations;
                WordList[Index].Phonetics = word.Phonetics;
            }
            WordList[Index].Translations.ForEach(a => ShowStr = ShowStr + a + " \n");
            lblEng.Text = WordList[Index].Phonetics.EngPhonetic;
            lblAmeri.Text = WordList[Index].Phonetics.AmeriPhonetic;
            this.richTextBox1.Text = ShowStr;
            this.richTextBox1.Refresh();
            if (Index < WordList.Count)
            {
                this.axWindowsMediaPlayer1.URL = WordList[Index].KeyWord + "_EngLish.mp3";
                this.axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
        public void Loop2()
        {
            ChiOrEngCtrl chiOrEngCtrl = new ChiOrEngCtrl(MainWin,WordList ,1);
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(chiOrEngCtrl);
            chiOrEngCtrl.ProcessOn += ProcessOn;
            
        }
        public void Loop3()
        {
            ChiOrEngCtrl chiOrEngCtrol = new ChiOrEngCtrl(MainWin,WordList, 0);
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(chiOrEngCtrol);
            chiOrEngCtrol.ProcessOn += ProcessOn;
        }
        public void ProcessOn()
        {
            //MessageBox.Show(Index.ToString() + ProcessCount.ToString());
            if(ProcessCount++<progressBar1.Maximum)
                this.progressBar1.Value = ProcessCount;
            this.progressBar1.Refresh();
            if (ProcessCount == 2 * Sum)
                Loop3();
            if (ProcessCount >= 3 * Sum)
            {
                MessageBox.Show("恭喜你完成本轮复习！");
                if (MainWin.User != null && Mode == 0)
                    RecordService.SaveRecordOfWord(MainWin.User, MainWin.WordRecord);
                if (MainWin.User != null && Mode == 1)
                    RecordService.SaveRecordOfPara(MainWin.User, MainWin.ParaRecord);
                this.MainWin.SubView.Controls.Clear();
                this.MainWin.SubView.Controls.Add(MainWin.WordModeCtrl);
            }
        }
        //展示图片
        public void ShowThePicture()
        {

            try
            {
                this.pictureBox1.Load(WordList[Index].KeyWord + ".png");
            }
            catch
            {
                this.pictureBox1.Load("./../../Resources/empty.jpg");
            }
            finally
            {
                this.pictureBox1.Refresh();
            }

        }
                

        private void RetnBtn_Click(object sender, EventArgs e)
        {
            if (MainWin.User != null && Mode == 0)
                RecordService.SaveRecordOfWord(MainWin.User, MainWin.WordRecord);
            if (MainWin.User != null && Mode == 1)
                RecordService.SaveRecordOfPara(MainWin.User, MainWin.ParaRecord);
            this.MainWin.SubView.Controls.Clear();
            this.MainWin.SubView.Controls.Add(MainWin.WordModeCtrl);
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if(Index!=0)
                 PreCount++;
            AllowProcess = false;
            if (Index >= 1&&Index<Sum)
            {
                Index--;
                ShowStr = null;
                lblWord.Text = WordList[Index].KeyWord;
                WordList[Index].Translations.ForEach(a => ShowStr = ShowStr + a + " \n");
                lblEng.Text = WordList[Index].Phonetics.EngPhonetic;
                lblAmeri.Text = WordList[Index].Phonetics.AmeriPhonetic;
                this.richTextBox1.Text = ShowStr;
                this.richTextBox1.Refresh();
                lblWord.Refresh();
                lblAmeri.Refresh();
                lblEng.Refresh();
                ShowThePicture();
            }
        }


        private void Nxet_Click(object sender, EventArgs e)
        {
            if (PreCount != 0)
                PreCount--;
            ShowStr = null;
            if (PreCount == 0 && AllowProcess)
                ProcessCount++;
            AllowProcess = true;
            this.progressBar1.Value = ProcessCount;
            this.progressBar1.Refresh();
            Index++;
            if (Index < Sum)
            {
                Loop1();
                ShowThePicture();
            }
            if (ProcessCount >= Sum && ProcessCount < Sum * 2)
                Loop2();
        }

        private void EngBtn_Click(object sender, EventArgs e)
        {
            if (Index < WordList.Count)
            {
                this.axWindowsMediaPlayer1.URL = WordList[Index].KeyWord + "_EngLish.mp3";
                this.axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void AmeriBtn_Click(object sender, EventArgs e)
        {
            if (Index < WordList.Count)
            {
                this.axWindowsMediaPlayer1.URL = WordList[Index].KeyWord + "_America.mp3";
                this.axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
    }
}
