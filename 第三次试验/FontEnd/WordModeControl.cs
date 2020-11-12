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
    public partial class WordModeControl : UserControl
    {
        public MainWindow MainWin { get; set; }

        private int WordNum=4;
        WordStudyControl StudyPanel { get; set; }

        //背完所有单词才能进入深度复习模式
        public bool AllLearned { get; set; } = true;
        public List<Word> WordList { get; set; } 
        public WordModeControl(MainWindow mainWindow)
        {
            InitializeComponent();
            this.MainWin = mainWindow;
            WordSource.SelectedIndex = 0;
        }

        //纯背词模式
        private void EasyModeBtn_Click(object sender, EventArgs e)
        {
            this.MainWin.SubView.Controls.Clear();
            switch (WordSource.SelectedIndex)
            {
                //四级
                case 0:
                    if (WordList == null)
                    {
                        MainWin.WordRecord =  RecordService.WordLearning(MainWin.User,4, WordNum);
                        WordList = MainWin.WordRecord.RecordWords;
                        StudyPanel = new WordStudyControl(MainWin,WordList,0);
                    }
                    StudyPanel = new WordStudyControl(MainWin, WordList,0);
                    this.MainWin.SubView.Controls.Add(StudyPanel);
                    break;
                //六级
                case 1:
                    if (WordList == null)
                    {
                        MainWin.WordRecord = RecordService.WordLearning(MainWin.User,6, WordNum);
                        WordList = MainWin.WordRecord.RecordWords;
                        StudyPanel = new WordStudyControl(MainWin,WordList,0);
                    }
                    StudyPanel = new WordStudyControl(MainWin, WordList,0);
                    this.MainWin.SubView.Controls.Add(StudyPanel);
                    break;
            }
        }

        //复习模式
        private void ReviewMode_Click(object sender, EventArgs e)
        {
            if (WordList != null)
            {
                WordList.ForEach(w =>
                {
                    if (w.Translations.Count==0)
                        AllLearned = false;
                });
                if (!AllLearned)
                    MessageBox.Show("请先学习完单词再进行复习！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    new ReviewChoice(MainWin).Show();
            }
            else
                MessageBox.Show("请先学习完单词再进行复习！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void WordAmount_ValueChanged(object sender, EventArgs e)
        {
            WordNum = int.Parse(WordAmount.Value.ToString());
        }

        
    }
}
