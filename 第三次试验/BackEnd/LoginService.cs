using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public class LoginService
    {
        //登录账户
        public static User Logging(string UserName, string Password)
        {
            using (var userContext = new AppDbContext())
            {
                var user = userContext.Users.Include("Records").Include("LearnedWords").
                    Include("LearningWords").Include("FavorWords").Include("CustomWords")
                   .FirstOrDefault(w => w.UserName == UserName && w.Password == Password);
                /*user.CustomWords.ForEach(w => MessageBox.Show(w.KeyWord+" c"));
                 user.FavorWords.ForEach(w => MessageBox.Show(w.KeyWord+" f"));
                 user.QuestionSet.ForEach(q =>
                 {
                     if (q.IsPass == true)
                         MessageBox.Show(q.Problem + 1);
                     MessageBox.Show(q.Problem + 2);
                 });
                 */
            
                if (user != null)
                {
                    return user;
                }
                return null;
            }
            
        }

        //注册账户
        public static void Register(string UserName0, string Password0, string EmailAddr0)
        {
            using (var userContext = new AppDbContext())
            {
                var user = new User() {
                    UserName = UserName0,
                    Password = Password0,
                    EmailAddr = EmailAddr0 };

                //初始化学习记录
                user.FavorWords = new List<Word>();
                user.CustomWords = new List<Word>();

                user.Records = new List<Record>();
                userContext.Users.Add(user);
                userContext.SaveChanges();
            }
        }

        //成功发送时返回验证码(返回0说明用户邮箱地址不对注册失败)
        public static int GetVeriCode(string userEmail)
        {
            string host = "smtp.126.com";// SMTP服务器
            string userName = "ggyyemail@126.com";// 发送端账号
            string password = "THZLMPCEIEHSBACY";//开启SMTP服务获得客户端授权密码
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            client.Host = host;//邮件服务器
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(userName, password);//用户名、密码
            string strFrom = userName;
            string strTo = userEmail;
            string subject = "用户注册身份验证";//邮件的主题
            Random rd = new Random();//随机生成四位验证码
            int veriCode = rd.Next(1000, 10000);//发送的邮件正文
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(strFrom, "C# Project");
            msg.To.Add(strTo);
            msg.Subject = subject;//邮件标题
            msg.Body = "您的验证码为： " + veriCode.ToString();//邮件内容
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码
            msg.IsBodyHtml = true;//是否是HTML邮件
            msg.Priority = MailPriority.High;//邮件优先级
            try
            {
                client.Send(msg);
                return veriCode;
            }
            catch (SmtpException )
            {
                return 0;
                //   MessageBox.Show(e.Message);
            }
        }
        //返回类型为string修改成功返回“修改密码成功”
        public static string ModifyPaw(string newpaw, User u)
        {
            using (var userContext = new AppDbContext())
            {
                string result;
                var user = userContext.Users.FirstOrDefault<User>(w => w.UserId == u.UserId);
                if (user != null)
                {
                    user.Password = newpaw;
                    userContext.SaveChanges();
                    result = "修改密码成功";
                    return result;
                }
                result = "修改失败";
                return result;
            }
        }
    }
}
