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
    public partial class QuestionChooseForm : Form
    {
        public string choice;

        public QuestionChooseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = this.listBox1.SelectedItem;
            choice = a.ToString();        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}

