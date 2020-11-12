using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Project;

namespace project
{
    public partial class ParaStudyControl : System.Windows.Forms.UserControl
    {
        public List<Word> WordList;
        public MainWindow MainWin { get; set; }
        public Record TempRecord { get; set; }
        public ParaStudyControl(MainWindow MainWin,string title)
        {
            InitializeComponent();
            this.WordList = MainWin.ParaWordList;
            this.label1.Text = title;
            this.MainWin = MainWin;
            TempRecord = RecordService.ParaLearning(MainWin.User, this.label1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //选择文章里的词点击查词之后
            var a = new ShowWordForm(MainWin,new Word( this.richTextBox1.SelectedText));           
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //开始学习文章里的单词
            WordStudyControl studyWord = null;
            MainWin.ParaRecord = TempRecord;

            this.MainWin.SubView.Controls.Clear();
            MainWin.ParaRecord.RecordParas.ForEach(p =>
            {
                if (p.ParaTitle == this.label1.Text)
                    p.IsRead = true;
            });
            MainWin.ParaRecord.RecordParas.ForEach(p =>
            {
                if (p.ParaTitle == this.label1.Text)
                    studyWord = new WordStudyControl(MainWin, p.CoreWords, 1);
                this.MainWin.SubView.Controls.Add(studyWord);
            });
        }

        //将要学的单词标蓝
        public void mark()
        {
            foreach(Word word in WordList)
            {
                Regex rx = new Regex(word.KeyWord);
                Match m = rx.Match(this.richTextBox1.Text);                             
                this.richTextBox1.Focus();
                this.richTextBox1.Select(m.Index, m.Length);               
                this.richTextBox1.SelectionColor = Color.CornflowerBlue;
            }
        }
        /*
        private void BtnIsRead_Click(object sender, EventArgs e)
        {
            BtnIsRead.BackColor = Color.CornflowerBlue;
            BtnIsRead.Text = "已读";
            MainWin.ParaRecord = TempRecord;
            MainWin.ParaRecord.RecordParas.ForEach(p =>
            {
                if (p.ParaTitle == this.label1.Text)
                    p.IsRead = true;
            });
        }
        */

        private void BtnReturn_Click(object sender, EventArgs e)
        {

        }
    }
}
