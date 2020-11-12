using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Project;

namespace project
{
    public partial class ParaChooseForm : Form
    {
        public string choice;
        public List<Word> WordList;//要显示的单词列表
        public ParaChooseForm()
        {
            
            InitializeComponent();
            this.listBox1.SelectedIndex = 0;
            ShowTheTittles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = this.listBox1.SelectedItem;
            ShowTheTittles();
        }

        void ShowTheTittles()
        {
            var index = this.listBox1.SelectedIndex;
            List<string> tittles=new List<string>();
            tittles.Add(Datas.ParaTitleList[index]);
            tittles.Add(Datas.ParaTitleList[(index+1)% Datas.ParaTitleList.Count]);
            this.listBox2.DataSource = tittles;
            this.listBox2.Refresh();
            choice = this.listBox2.SelectedItem.ToString();
            WordList = DataProvider.GetPara(choice).CoreWords;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
