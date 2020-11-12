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
    public partial class AnnoForm : Form
    {

        public MainWindow MainWin { get; set; }
        public Word Word { get; set; }
        public AnnoForm(MainWindow mainWindow,Word word)
        {
            MainWin = mainWindow;
            Word = word;
            InitializeComponent();
            if (mainWindow.User != null)
            {
                RecordService.ShowUserWords(mainWindow.User, 4).ForEach(w =>
                {
                    if (w.KeyWord == word.KeyWord)
                        Word.Annotation = w.Annotation;
                });
            }
            lblKeyword.Text = word.KeyWord;
            richTextBox1.Text = Word.Annotation;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            Word.Annotation = richTextBox1.Text;
            RecordService.AnnoWord(MainWin.User, Word);
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
