using Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class ReviewChoice : Form
    {
        List<Word> WordList { get; set; }
        MainWindow MainWin { get; set; }
        public ReviewChoice(MainWindow parent)
        {
            this.MainWin = parent;
            this.WordList = parent.WordModeCtrl.WordList;
            InitializeComponent();
        }
        
        

        private void GapFillMode_Click(object sender, EventArgs e)
        {
            MainWin.SubView.Controls.Clear();
            MainWin.SubView.Controls.Add(new ChiOrEngCtrl(MainWin,MainWin.WordRecord.RecordWords,3));
            this.Hide();
        }

        private void FullFillMode_Click(object sender, EventArgs e)
        {
            MainWin.SubView.Controls.Clear();
            MainWin.SubView.Controls.Add(new FullFillControl(MainWin,0));
            this.Hide();
        }

        private void QuestionMode_Click(object sender, EventArgs e)
        {
            MainWin.SubView.Controls.Clear();
            MainWin.SubView.Controls.Add(new ChiOrEngCtrl(MainWin, MainWin.WordRecord.RecordWords, 2));
            this.Hide();
        }

        private void WordGroup_Click(object sender, EventArgs e)
        {
            MainWin.SubView.Controls.Clear();
            MainWin.SubView.Controls.Add(new FullFillControl(MainWin,1));
            this.Hide();
        }
    }
}
