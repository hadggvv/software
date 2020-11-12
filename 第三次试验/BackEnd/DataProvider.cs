using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Project
{
    public class DataProvider
    {
        //返回指定数量的未学四级词汇（注意某个单词的具体信息需要调用Clawer.Download获取）
        public static List<Word> GetCET4Words(User user, int ammount) {
            List<Word> wordList = new List<Word>();
            List<string> words = new List<string>();
            List<Word> learnedWords = new List<Word>();
            Random rd = new Random();
            if (user != null)
            {
                using (var context = new AppDbContext())
                {
                    learnedWords = context.Users.Include("LearnedWords").FirstOrDefault(u => u.Password == user.Password &&
                    u.UserName == user.UserName).LearnedWords;
                }//这里有改动
                 //从词库中随机取一个单词，已学则重新取，反之加入List至满足取词要求
                while (words.Count < ammount)
                {
                    bool flag = true;
                    string word = Datas.Lexicon[4][rd.Next(0, Datas.Lexicon[4].Count)];
                    learnedWords.ForEach(lw =>
                    {
                        if (lw.KeyWord == word) flag = false;
                    });
                    if (flag&&!words.Contains(word))
                        words.Add(word);
                }
            }
            else
            {
                while (words.Count < ammount)
                {
                    string word = Datas.Lexicon[4][rd.Next(0, Datas.Lexicon[4].Count)];
                    if(!words.Contains(word))
                        words.Add(word);
                }
            }
            words.ForEach(w => wordList.Add(new Word(w)));
            //wordList.ForEach(w => MessageBox.Show(w.KeyWord));
            return wordList;
        }
        //返回指定数量的未学六级词汇（注意某个单词的具体信息需要调用Clawer.Download获取）
        public static List<Word> GetCET6Words(User user,int ammount)
        {
            List<Word> wordList = new List<Word>();
             List<string> words = new List<string>();
            List<Word> learnedWords = new List<Word>();
            Random rd = new Random();
            if (user != null)
            {
                using (var context = new AppDbContext())
                {
                    learnedWords = context.Users.Include("LearnedWords").FirstOrDefault(u => u.Password == user.Password &&
                    u.UserName == user.UserName).LearnedWords;
                }//这里有改动
                 //从词库中随机取一个单词，已学则重新取，反之加入List至满足取词要求
                while (words.Count < ammount)
                {
                    bool flag = true;
                    string word = Datas.Lexicon[6][rd.Next(0, Datas.Lexicon[6].Count)];
                    learnedWords.ForEach(lw =>
                    {
                        if (lw.KeyWord == word) flag = false;
                    });
                    if (flag && !words.Contains(word))
                        words.Add(word);
                }
            }
            else
            {
                while (words.Count < ammount)
                {
                    string word = Datas.Lexicon[6][rd.Next(0, Datas.Lexicon[4].Count)];
                    if (!words.Contains(word))
                        words.Add(word);
                }
            }
            words.ForEach(w => wordList.Add(new Word(w)));
            //wordList.ForEach(w => MessageBox.Show(w.KeyWord));
            
           
            return wordList;
        }

        //根据文章题目获得某篇文章的信息
        public static Para GetPara(string paraTitle)
        {
            Para para = new Para();
            para.ParaTitle = paraTitle;
            para.Article = File.ReadAllText("./../../Resource/Paragraphes/"+paraTitle+".txt");
            string[] words = para.Article.Split(' ').Distinct().ToArray();
            Array.ForEach(words, w=>{
                if (Datas.CoreWords.Contains(w))
                    para.CoreWords.Add(new Word(w));
            });
            return para;
        }

        //返回某一年词汇真题
        public static List<Question> GetQuestions(string title)
        {
            List<Question> quesList = new List<Question>();
            List<string> problems = new List<string> ();
            List<string> options = new List<string>();
            List<string> answers = new List<string>();
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("./../../Resource/Questions/" + title + ".xml");
                XmlNode root = xd.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("/questions/problem");
                foreach (XmlNode node in nodes)
                {
                    problems.Add(node.InnerText);
                }
                nodes = root.SelectNodes("/questions/options");
                foreach (XmlNode node in nodes)
                {
                    options.Add(node.InnerText);
                }
                nodes = root.SelectNodes("/questions/answer");
                foreach (XmlNode node in nodes)
                {
                    answers.Add(node.InnerText);
                }
            }
            catch (XmlException e)
            {
                MessageBox.Show("Exception caught:  " + e);
                return null;
            }
            // problems.ForEach(o => MessageBox.Show(o));
            //   answers.ForEach(o => MessageBox.Show(o));
            //   options.ForEach(o => MessageBox.Show(o));
            if(problems.Count==answers.Count&& answers.Count == options.Count)
                for(int i =0;i<problems.Count;i++)
                {
                    Question ques = new Question();
                    ques.Answer = answers[i];
                    ques.Problem = problems[i];
                    string[] choices = options[i].Split('.');
                    for (int j = 0; j < choices.Count() - 1; j++)
                        ques.Options.Add(new Option(choices[j]));
                    quesList.Add(ques);
                }
            return quesList;
        }
    }
}
