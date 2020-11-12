using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public class RecordService
    {
  
        //判断是否有未学完的学习记录，如果返回null则表示没有
       /* public static Record StartLearning(User user)
        {
            Record learning_record = null;

            TimeSpan timeSpan = new TimeSpan();
            TimeSpan min_timeSpan = new TimeSpan();
            
            DateTime time = new DateTime();
            min_timeSpan = time - DateTime.MinValue;

            using (var userContext = new AppDbContext())
            {
                var query = userContext.Records.Where(w => w.UserId == user.UserId);
                if(query != null) 
                foreach (Record record in query)
                {
                    //如果没有学习完
                    if (!record.IsDone)
                    {
                        //找到最近的学习记录
                        timeSpan = time - record.CreateTime;
                        if (timeSpan < min_timeSpan)
                        {
                            min_timeSpan = timeSpan;
                            learning_record = record;
                        }
                    }
                }
            }
  
            return learning_record;
        }
        */
        //创建新的学习记录，获取单词范围
        public static Record WordLearning(User user, int grade,int number)
        {
            //获取单词范围
            List<Word> words = new List<Word>();
            if (grade==4)
                words = DataProvider.GetCET4Words(user,number);
            else if(grade==6)
                words = DataProvider.GetCET6Words(user, number);
            Record new_record = new Record();
            new_record.IsDone = false;
            //new_record.state = 1;

            new_record.RecordWords = words;
            return new_record;          
        }
        //重载单词学习模式，创建新的学习记录，一个单词的记录
        public static Record WordLearning(User user, Word word)
        {
            Record new_record = new Record();
            new_record.UserId = user.UserId;
            new_record.IsDone = false;
            //new_record.state = 1;
            new_record.RecordWords.Add(word);
            return new_record;
        }
        //重载单词学习模式，创建新的学习记录，多个单词的记录
        public static Record WordLearning(User user, List<Word> words)
        {
            Record new_record = new Record();
            new_record.UserId = user.UserId;
            new_record.IsDone = false;
            //new_record.state = 2;
            foreach (Word word in words)
                new_record.RecordWords.Add(word);
            return new_record;
        }
        //存储单词学习的记录
        public static void SaveRecordOfWord(User user,Record record)
        {
            using (var userContext = new AppDbContext())
            {
                var user1 = userContext.Users.FirstOrDefault
                (w => w.UserName == user.UserName && w.Password == user.Password);   
               user1.Records.Add(record);
                record.RecordWords.ForEach(w => {
                    if (w.IsLearned == true && !user1.Contains(w,0))
                        user1.LearnedWords.Add(w);
                });
                record.RecordWords.ForEach(w => {
                    if (w.IsLearned == false && !user1.Contains(w,1))
                        user1.LearningWords.Add(w);
                });
                userContext.SaveChanges();
            }
        }
        public static List<Word> ShowUserWords(User user,int mode)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var user1 = context.Users.FirstOrDefault
                (w => w.UserName == user.UserName && w.Password == user.Password);
                switch (mode)
                {
                    case 0:
                        return user1.LearnedWords;
                    case 1:
                        return user1.LearningWords;
                    case 2:
                        return user1.FavorWords;
                    case 3:
                        return user1.CustomWords;
                    case 4:
                        return user1.AnnotationWords;
                    default:
                        return null;
                }
            }
        }
        public static List<string> ShowReadPara(User user)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var user1 = context.Users.FirstOrDefault
                (w => w.UserName == user.UserName && w.Password == user.Password);
                List<string> ParaList = new List<string>();
                user1.ReadParas.ForEach(p => ParaList.Add(p.ParaTitle));
                return ParaList;
            }
        }
        public static List<Question> ShowQuesSet(User user)
        {
            using (AppDbContext context = new AppDbContext())
            {
               // MessageBox.Show(user.UserName + user.Password);
                var user1 = context.Users.FirstOrDefault<User>
                (w => w.UserName == user.UserName && w.Password == user.Password);
               /* var Questions = context.Questions.Include("Options").FirstOrDefault
                (q=>q.UserId==user.UserId);*/
                return user1.QuestionSet;
            }
        }
        public static Question ShowQues(User user,string problem)
        {
            using (AppDbContext context = new AppDbContext())
            {
                 var ques = context.Questions.Include("Options").FirstOrDefault
                 (q=>q.UserId==user.UserId&&q.Problem==problem);
                return ques;
            }
        }
        //收藏单词
        public static void AddFavorWord(User user,Word word)
        {
            using(var userContext = new AppDbContext())
            {
                var user1 = userContext.Users.FirstOrDefault
                (w => w.UserName == user.UserName && w.Password == user.Password);
                
                if (!user1.Contains(word, 3))
                    user1.FavorWords.Add(word);
                userContext.SaveChanges();
            }
        }
        //单词注释
        public static void AnnoWord(User user, Word word)
        {
            using (var userContext = new AppDbContext())
            {
                var user1 = userContext.Users.FirstOrDefault
                (w => w.UserName == user.UserName && w.Password == user.Password);
                if (!user1.Contains(word, 4))
                    user1.AnnotationWords.Add(word);
                else
                    user1.AnnotationWords.ForEach(w =>
                    {
                        if (w.KeyWord == word.KeyWord)
                            w.Annotation = word.Annotation;
                    });
                userContext.SaveChanges();
            }
        }
        //将单词添加到自定义词库
        public static void AddCustomWord(User user, Word word)
        {
            using (var userContext = new AppDbContext())
            {
                var user1 = userContext.Users.FirstOrDefault
                (w => w.UserName == user.UserName && w.Password == user.Password);
                if (!user1.Contains(word,2))
                    user1.CustomWords.Add(word);
                userContext.SaveChanges();
            }
        }
        public static void RemoveCustomWord(User user, Word word)
        {
            using (var userContext = new AppDbContext())
            {
                var user1 = userContext.Users.FirstOrDefault
                (w => w.UserName == user.UserName && w.Password == user.Password);
                for (int i = user1.CustomWords.Count - 1; i >= 0; i--)
                    if (user1.CustomWords[i].KeyWord == word.KeyWord)
                    {
                        user1.CustomWords.RemoveAt(i);
                        break;
                    }
                userContext.SaveChanges();
            }
        }
        //阅读学习模式,创建新的学习记录,一篇文章的记录
        public static Record ParaLearning(User user,string title)
        {
            Para para = DataProvider.GetPara(title);
            Record new_record = new Record();
            new_record.IsDone = false;
            //new_record.state = 2;
            new_record.RecordParas.Add(para);
            return new_record;
        }
        //重载阅读学习模式，多篇文章的记录
        public static Record ParaLearning(User user, List<string> title)
        {
            Record new_record = new Record();
            new_record.UserId = user.UserId;
            new_record.IsDone = false;
            //new_record.state = 2;
            foreach(string parat in title)
                new_record.RecordParas.Add(DataProvider.GetPara(parat));
            return new_record;
        }
        //储存阅读文章的记录
        public static void SaveRecordOfPara(User user, Record record)
        {
            using (var userContext = new AppDbContext())
            {
                var query = userContext.Records.
                    FirstOrDefault<Record>(r => r.RecordId == record.RecordId)
                    as Record;
                var user1 = userContext.Users.FirstOrDefault
                (w =>  w.UserName == user.UserName && w.Password == user.Password);
                if (query != null)
                    query = record;
                else
                    user1.Records.Add(record);
                record.RecordParas.ForEach(p =>
                {
                    if (p.IsRead == true && !user1.Contains(p))
                        user1.ReadParas.Add(p);
                });
                record.RecordParas[0].CoreWords.ForEach(w =>
                {
                    if (w.IsLearned == true && !user1.Contains(w, 0))
                        user1.LearnedWords.Add(w);
                });
                record.RecordParas[0].CoreWords.ForEach(w =>
                {
                    if (w.IsLearned == false && !user1.Contains(w, 1))
                        user1.LearningWords.Add(w);
                });
                userContext.SaveChanges();
            }
        }
        //习题学习模式，创建新的学习记录
        public static Record QuestionLearning(User user,Question question)
        {
            Record new_record = new Record();
            new_record.UserId = user.UserId;
            new_record.IsDone = false;
            //new_record.state = 3;
            new_record.Questions.Add(question);
            return new_record;
        }
        //重载习题学习模式，创建新的学习记录,多个题目的记录
        public static Record QuestionLearning(User user, List<Question> questions)
        {
            Record new_record = new Record();
            new_record.IsDone = false;
            //new_record.state = 3;
            foreach (Question question in questions)
                new_record.Questions.Add(question);
            using(AppDbContext context = new AppDbContext())
            {
                var user1 = context.Users.FirstOrDefault
                (w => w.UserName == user.UserName && w.Password == user.Password);
                user1.Records.Add(new_record);
                foreach (Question question in questions)
                    user1.QuestionSet.Add(question);
                context.SaveChanges();
            }
            return new_record;
        }
        //储存习题记录
        public static void SaveRecordOfQestion(User user, Record record)
        {
            using (var userContext = new AppDbContext())
            {
                var user1 = userContext.Users.FirstOrDefault
                (w => w.UserName == user.UserName && w.Password == user.Password);
                //添加新记录
                user1.Records.Add(record);
                record.Questions.ForEach(q =>
                {
                    if (user1.Contains(q) == null)
                        user1.QuestionSet.Add(q);
                    else
                        user1.Contains(q).IsPass = q.IsPass;
                });
                userContext.SaveChanges();
            }
        }
    }
}
