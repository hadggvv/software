using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class User
    {
        //自增主键
        public int UserId { get; set; }
        //用户名
        public string UserName { get; set; }
        //密码
        public string Password { get; set; }
        //邮箱地址
        public string EmailAddr { get; set; }

        //已学单词0
        public virtual List<Word> LearnedWords { get; set; } = new List<Word>();
        //未学完单词1
        public virtual List<Word> LearningWords { get; set; } = new List<Word>();

        //已学文章
        public virtual List<Para> ReadParas { get; set; } = new List<Para>();

        //用户记录（导航属性）
        public virtual List<Record> Records { get; set; }
        
        //我的收藏(导航属性)2
        public virtual List<Word> FavorWords { get; set; }
        //自定义词库（导航属性）3
        public virtual List<Word> CustomWords { get; set; }
        public virtual List<Question> QuestionSet { get; set; } = new List<Question>();
        //带注释单词4
        public virtual List<Word> AnnotationWords { get; set; } = new List<Word>();
        public bool Contains(Word w,int flag)
        {   
            if(flag==0)
                for(int i=0;i<LearnedWords.Count;i++)
                {
                    if (LearnedWords[i].KeyWord == w.KeyWord)
                        return true;
                }
            else if(flag==1)
                for (int i = 0; i < LearningWords.Count; i++)
                {
                    if (LearningWords[i].KeyWord == w.KeyWord)
                        return true;
                }
            else if (flag==2)
                for(int i = 0; i < CustomWords.Count; i++)
                {
                    if (CustomWords[i].KeyWord == w.KeyWord)
                        return true;
                }
            else if (flag == 3)
                for (int i = 0; i < FavorWords.Count; i++)
                {
                    if (FavorWords[i].KeyWord == w.KeyWord)
                        return true;
                }
            else if (flag == 4)
                for (int i = 0; i < AnnotationWords.Count; i++)
                {
                    if (AnnotationWords[i].KeyWord == w.KeyWord)
                        return true;
                }
            return false;
        }
        public bool Contains(Para p)
        {
            for (int i = 0; i < ReadParas.Count; i++)
            {
                if (ReadParas[i].ParaTitle == p.ParaTitle)
                    return true;
            }
            return false;
        }
        public Question Contains(Question q)
        {
            for (int i = 0; i < QuestionSet.Count; i++)
            {
                if (QuestionSet[i].Problem== q.Problem)
                    return QuestionSet[i];
            }
            return null;
        }

        //判断一个单词是否学过
        public bool IsLearned(Word word)
        {
            foreach (Record record in Records)
            {
                foreach (Word word1 in record.RecordWords)
                {
                    if (word1.KeyWord == word.KeyWord&&word1.IsLearned==true)
                        return true;
                    else continue;
                }
            } 
            return false;
        }
        //判断一个文章是否学过
        public bool IsLearned(Para para)
        {
                foreach (Record record in Records)
                {
                    foreach (Para para1 in record.RecordParas)
                    {
                        if (para1.ParaId == para.ParaId)
                        return true;
                        else continue;
                    }
                }
                return false;

        }
        
        //判断一个题目是否学过
        public bool IsLearned(Question question)
        {
            foreach (Record record in Records)
            {
                foreach (Question question1 in record.Questions)
                {
                    if (question1.QuestionId == question.QuestionId)
                        return true;
                    else continue;
                }
            }
            return false;
        }
    }

    
}
