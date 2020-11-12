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
    public partial class RecordControl : UserControl
    {
        public MainWindow MainWin { get; set; }
        public User User { get; set; }
        public List<string> LearnedWords { get; set; } = new List<string>();
        public List<string> LearningWords { get; set; } = new List<string>();
        public List<string> QuesSet { get; set; } = new List<string>();
        public List<string> ParaTittles { get; set; } = new List<string>();
        public RecordControl(MainWindow mainWindow)
        {
            InitializeComponent();
            User = mainWindow.User;
            MainWin = mainWindow;
            if (User != null)
            {
                RecordService.ShowUserWords(User, 0).ForEach(r => LearnedWords.Add(r.KeyWord));
                RecordService.ShowUserWords(User, 1).ForEach(r => LearningWords.Add(r.KeyWord));
                this.listBox1.DataSource = LearnedWords;
                this.listBox2.DataSource = Datas.Lexicon[6];//暂定
                this.listBox3.DataSource = RecordService.ShowReadPara(User);
                List<string> quesList = new List<string>();
                RecordService.ShowQuesSet(User).ForEach(q =>
                {
                    if (q.IsPass == true)
                        quesList.Add("√" + q.Problem);
                    else
                        quesList.Add("×" + q.Problem);
                });
                this.listBox4.DataSource = quesList;
            }
        }

        private void lbQues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var problem = listBox4.SelectedItem.ToString().Substring(1);
            Question ques = RecordService.ShowQues(User, problem);

            MainWin.QuestionList = new List<Question>();
            MainWin.QuestionList.Add(ques);
            MainWin.QuesRecord = new Record();
            MainWin.QuesRecord.Questions = MainWin.QuestionList;
            var study = new QuestionStudyControl(MainWin);
            this.MainWin.SubView.Controls.Clear();
            MainWin.SubView.Controls.Add(study);
        }
    }
}
