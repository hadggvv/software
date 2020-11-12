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
    
    public partial class MainWindow : Form
    {
        public WordModeControl WordModeCtrl { get; set; }
        public List<Word> ParaWordList { get; set; }
        public List<Question> QuestionList { get; set; }
        public Record WordRecord { get; set; }
        public Record ParaRecord { get; set; }
        public Record QuesRecord { get; set; }
        public User User { get; set; }
        public MainWindow(User user)
        {
            User = user;
            WordModeCtrl = new WordModeControl(this);
            InitializeComponent();
        }
        public void ParaMode()
        {
            //打开选择窗口
            var choose = new ParaChooseForm();
            choose.ShowDialog();

            //显示文章学习控件
            ParaWordList = DataProvider.GetPara(choose.choice).CoreWords;
            var study = new ParaStudyControl(this, choose.choice);//把选择的文章标题传给GETPARA
            study.richTextBox1.Text = DataProvider.GetPara(choose.choice).Article;
            study.mark();//单词标记蓝
            if (choose.DialogResult == DialogResult.OK)
            {
                this.SubView.Controls.Clear();
                this.SubView.Controls.Add(study);
            }
        }
        public void ViewRefresh()
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }
        public void ExamMode()
        {
            //打开选择窗口
            var choose = new QuestionChooseForm();
            choose.listBox1.DataSource = Datas.QuesTitleList;
            choose.ShowDialog();

            //显示题目学习控件
            if (choose.DialogResult == DialogResult.OK)
            {
                this.SubView.Controls.Clear();
                QuestionList = DataProvider.GetQuestions(choose.choice);
                QuesRecord = RecordService.QuestionLearning(User, QuestionList);
                var study = new QuestionStudyControl(this);
                this.SubView.Controls.Add(study);
            }
        }
        private void 爱阅读ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParaMode();
        }

        private void 背单词ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SubView.Controls.Clear();
            this.SubView.Controls.Add(WordModeCtrl);
        }

        private void 练真题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExamMode();           
        }

        private void 修改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            this.panel1.Controls.Clear();
            var user = new UserConfigControl();
            this.panel1.Controls.Add(user);
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //打开查询单词的窗口
            string searchWord = richTextBox1.Text;
            var a = new ShowWordForm(this,new Word(searchWord));
            a.ShowDialog();
        }


        private void 回到主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SubView.Controls.Clear();
            this.InitSubView();
            RecordService.SaveRecordOfQestion(User, QuesRecord);
            //this.InitializeComponent();
        }

        private void WordModeBtn_Click(object sender, EventArgs e)
        {
            this.SubView.Controls.Clear();
            this.SubView.Controls.Add(WordModeCtrl);
        }

        private void ParaModeBtn_Click(object sender, EventArgs e)
        {
            ParaMode();
        }

        private void QuesModeBtn_Click(object sender, EventArgs e)
        {
            ExamMode();
        }

        private void 安全退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LogingWin().Show();     
        }

        private void 我的单词ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SubView.Controls.Clear();
            this.SubView.Controls.Add(new MyWordsControl(this));
        }

        private void 学习记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SubView.Controls.Clear();
            this.SubView.Controls.Add(new  RecordControl(this));
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SubView.Controls.Clear();
            this.SubView.Controls.Add(new UserConfigControl(User));
        }
    }
}
