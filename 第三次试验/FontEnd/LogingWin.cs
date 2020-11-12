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
    public partial class LogingWin : Form
    {
        static public int code;
        public LogingWin()
        {
            InitializeComponent();
            this.judge.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        //用户登陆
        //这里有点问题，我觉得登陆函数要改一下
        //返回类型已经改为User
        private void logining_Click(object sender, EventArgs e)
        {

            User user = LoginService.Logging(getAccount.Text, getPassword_2.Text);
            if (user!=null)
            {
                this.Hide();
                var test1 = new MainWindow(user);
                test1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        //发送验证码
        private void sendConfirm_Click(object sender, EventArgs e)
        {
            if (getMailbox.Text == null || getPassword_1.Text == null || getUserName.Text == null || getConfirm.Text == null)
            {
                MessageBox.Show("输入不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //邮箱输入格式是否正确
            if (System.Text.RegularExpressions.Regex.IsMatch(getMailbox.Text, @"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.com$"))
            {
                judge.ForeColor = Color.Green;
                judge.Text = "√";
                judge.Visible = true;
                code=LoginService.GetVeriCode(getMailbox.Text); //返回0的话邮箱错误
                sendConfirm.Text = "已发送";
            }
            else
            {
                judge.ForeColor = Color.Red;
                judge.Text = "×";
                judge.Visible = true;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(getPassword_1.Text, @"^[a-zA-Z0-9]{6}[a-zA-Z0-9]*$"))
            {
                tip.ForeColor = Color.Green;
                tip.Text = "√";
            }
            else
            {
                tip.ForeColor = Color.Red;
                tip.Text = "密码格式错误";
            }
        }

        //注册
        private void registering_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(getConfirm.Text) == code)
            {
                LoginService.Register(getUserName.Text, getPassword_1.Text, getMailbox.Text);
                MessageBox.Show("注册成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TabControl.SelectedIndex = 0;
                getAccount.Text = getUserName.Text;
                getPassword_2.Text = getPassword_1.Text;
            }
            else
            {
                MessageBox.Show("验证码错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //游客登录
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var test1 = new MainWindow(null);
            test1.ShowDialog();
            this.Close();
        }
    }
}
