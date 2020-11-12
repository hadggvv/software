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
    public partial class UserConfigControl : System.Windows.Forms.UserControl
    {
        public User User { get; set; }
        public UserConfigControl(User user)
        {
            User = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == User.Password)
                MessageBox.Show(LoginService.ModifyPaw(textBox2.Text, User));
            else
                MessageBox.Show("原密码不匹配", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
