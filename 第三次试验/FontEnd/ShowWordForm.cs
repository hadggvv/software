using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project;

namespace project
{
    public partial class ShowWordForm : Form
    {
        public Word searchWord;
        public MainWindow MainWin { get; set; }
        public ShowWordForm(MainWindow mainWindow, Word searchWord)
        {
            InitializeComponent();
            this.searchWord = searchWord;
            //searchWord是单词
            MainWin = mainWindow;
            if(searchWord.Translations.Count==0)
                this.searchWord = Clawler.DownLoad(searchWord.KeyWord);
            ShowInfo();
            if (MainWin.User != null)
            {
                RecordService.ShowUserWords(MainWin.User, 3).ForEach(w =>
                {
                    if (w.KeyWord == searchWord.KeyWord)
                        button5.Text = "移出单词本";
                });
            }
        }
        public void ShowInfo()
        {
            string show = searchWord.KeyWord + ":\n";
            searchWord.Translations.ForEach(a => show = show + a + "\n");
            this.richTextBox1.Text = show;
            lblKeyword.Text = searchWord.KeyWord;
            lblEng.Text = searchWord.Phonetics.EngPhonetic;
            lblAmeri.Text = searchWord.Phonetics.AmeriPhonetic;
            this.axWindowsMediaPlayer1.URL = searchWord.KeyWord + "_America.mp3";
            this.axWindowsMediaPlayer1.Ctlcontrols.play();
            //显示图片
            try
            {
                this.pictureBox1.Load(searchWord.KeyWord + ".png");
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.URL = searchWord.KeyWord + "_America.mp3";
            this.axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.URL = searchWord.KeyWord + "_English.mp3";
            this.axWindowsMediaPlayer1.Ctlcontrols.play();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "加入单词本")
            {
                button5.Text = "移出单词本";
                RecordService.AddCustomWord(MainWin.User, searchWord);
            }
            else
            {
                button5.Text = "加入单词本";
                RecordService.RemoveCustomWord(MainWin.User, searchWord);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecordService.AddFavorWord(MainWin.User, searchWord);

            if (button3.Text == "取消收藏")
                button3.Text = "收藏";
            else
                button3.Text = "取消收藏";
        }

        private void button4_Click(object sender, EventArgs e)

        {
            new AnnoForm(MainWin, searchWord).ShowDialog();
        }
    }
}
