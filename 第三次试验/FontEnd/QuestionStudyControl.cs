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
    public partial class QuestionStudyControl : System.Windows.Forms.UserControl
    {
        public List<Question> questionList;//问题列表
        public int Index;//索引
        public string studyWord;//学习的单词
        public Word searchWord { get; set; }
        public List<bool> Flag { get; set; } = new List<bool> () ;//标识用户有没有做出选择
        MainWindow MainWin { get; set; }
        public QuestionStudyControl(MainWindow mainWin)
        {
            InitializeComponent();
            this.MainWin = mainWin;
            this.questionList = MainWin.QuesRecord.Questions;
            questionList.ForEach(q => Flag.Add(false));
            Index = 0;
            showTheQuestion();
        }

        //显示题目的函数
        public void showTheQuestion()
        {
            linkLabel1.Enabled = true;
            linkLabel2.Enabled = true;
            linkLabel3.Enabled = true;
            linkLabel4.Enabled = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel2.BackColor = Color.Transparent;
            linkLabel3.BackColor = Color.Transparent;
            linkLabel4.BackColor = Color.Transparent;
            this.richTextBox1.Text = questionList[Index].Problem;
            this.linkLabel1.Text = questionList[Index].Options[0].OptionWord;
            this.linkLabel2.Text = questionList[Index].Options[1].OptionWord;
            this.linkLabel3.Text = questionList[Index].Options[2].OptionWord;
            this.linkLabel4.Text = questionList[Index].Options[3].OptionWord;

            this.richTextBox1.Refresh();
            this.linkLabel1.Refresh();
            this.linkLabel2.Refresh();
            this.linkLabel3.Refresh();
            this.linkLabel4.Refresh();
        }


        //显示下一个
        private void next()
        {
            if (Index < questionList.Count&&Flag[Index])
            {
                Index++;
                if (Index != questionList.Count)
                {
                   // MainWin.SubView.Controls.Clear();
                 //   this.InitializeComponent();
                    showTheQuestion();
                }
            }
            else if(Index<questionList.Count && !Flag[Index])
            {
                MessageBox.Show("请做出选择");
            }
            else if (Index == questionList.Count)
            {
                MessageBox.Show("恭喜你完成本轮复习！");
                MainWin.SubView.Controls.Clear();
                MainWin.InitSubView();
                RecordService.SaveRecordOfQestion(MainWin.User, MainWin.QuesRecord);
            }
        }


        //点击标签之后通过这个函数判断结果
        private void toJudge(object sender)
        {
            LinkLabel a = sender as LinkLabel;
            if(a.Text.Substring(1,1)== questionList[Index].Answer.Substring(1, 1))
            {
                a.BackColor = Color.Green;
                questionList[Index].IsPass = true;
            }
            else
            {
                a.BackColor = Color.Red;
                questionList[Index].IsPass = false;               
            }

            //4种情况
            if (linkLabel1.Text.Substring(1, 1) == questionList[Index].Answer.Substring(1, 1))
            {
                linkLabel1.BackColor = Color.Green;
                studyWord = linkLabel1.Text.Substring(4);             
            }
            if (linkLabel2.Text.Substring(1, 1) == questionList[Index].Answer.Substring(1, 1))
            {
                linkLabel2.BackColor = Color.Green;
                studyWord = linkLabel2.Text.Substring(4);
               
            }
            if (linkLabel3.Text.Substring(1, 1) == questionList[Index].Answer.Substring(1, 1))
            {
                linkLabel3.BackColor = Color.Green;
                studyWord = linkLabel3.Text.Substring(4);
                
            }
            if (linkLabel4.Text.Substring(1, 1) == questionList[Index].Answer.Substring(1, 1))
            {
                linkLabel4.BackColor = Color.Green;
                studyWord = linkLabel4.Text.Substring(4);
              
            }
            showTheInfo();
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            linkLabel3.Enabled = false;
            linkLabel4.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            toJudge(sender);
            Flag[Index] = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            toJudge(sender);
            Flag[Index] = true;
        }

        private void QuestionStudyControl_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                toJudge(sender);
                Flag[Index] = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                toJudge(sender);
                Flag[Index] = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            next();
        }

        private void button3_Click(object sender, EventArgs e)
        {                     
                this.axWindowsMediaPlayer1.URL = studyWord + "_America.mp3";
                this.axWindowsMediaPlayer1.Ctlcontrols.play();         
        }

        //显示左边单词框中的信息
        public void showTheInfo()
        {
            string show = studyWord + ":\n ";
            searchWord = Clawler.DownLoad(studyWord);
            searchWord.Translations.ForEach(x => show = show + x + "\n");
            this.richTextBox2.Text = show;
            lblKeyword.Text = studyWord;
            lblEng.Text = searchWord.Phonetics.EngPhonetic;
            lblAmeri.Text = searchWord.Phonetics.AmeriPhonetic;
            try
            {
                this.pictureBox1.Load(studyWord + ".png");
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "加入单词本")
            {
                RecordService.AddCustomWord(MainWin.User, searchWord);
                button2.Text = "移出单词本";
            }
            else
            {
                RecordService.RemoveCustomWord(MainWin.User, searchWord);
                button2.Text = "加入单词本";
            }
        }
    }
}
