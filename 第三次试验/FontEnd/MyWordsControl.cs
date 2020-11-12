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
    public partial class MyWordsControl : UserControl
    {
        public MainWindow MainWin{ get; set; }
        public List<string> FavorWords { get; set; } = new List<string>();
        public List<string> CustomWords { get; set; } = new List<string>();
        public MyWordsControl(MainWindow mainWin)
        {
            InitializeComponent();
            MainWin = mainWin;
            if (MainWin.User != null)
            {
                RecordService.ShowUserWords(MainWin.User, 2).ForEach(r => FavorWords.Add(r.KeyWord));
                RecordService.ShowUserWords(MainWin.User, 3).ForEach(r => CustomWords.Add(r.KeyWord));
            }
            this.listBox1.DataSource = FavorWords;
            this.listBox2.DataSource = CustomWords;
        }


        private void StartLearn_Click(object sender, EventArgs e)
        {
            if (CustomWords.Count!=0)
            {
                this.MainWin.SubView.Controls.Clear();
                MainWin.WordRecord = new Record();
                WordStudyControl study = new WordStudyControl(MainWin, RecordService.ShowUserWords(MainWin.User, 3), 0);
                this.MainWin.SubView.Controls.Add(study);
            }
        }

        private void lbCustom_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var choose = listBox2.SelectedItem;
            Word word = new Word(choose.ToString());
            word.IsCustom = true;
            new ShowWordForm(MainWin, word).ShowDialog();
        }
    }
}
