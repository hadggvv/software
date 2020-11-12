using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Record
    {
        //自增主键
        public int RecordId { get; set; }
        //外键
        public int UserId { get; set; }

        //用户是否完成本轮学习的所有任务
        public bool IsDone { get; set; }

        //状态单词模式为1 答题模式为2 阅读模式为3（删）
        //public int State;

        //记录生成时间
        public string CreateTime { get; set; } = DateTime.Now.ToString();

        //本次学习涉及的单词
        [NotMapped]
        public List<Word> RecordWords { get; set; } = new List<Word>();
        [NotMapped]
        //本次学习涉及的文章
        public  List<Para> RecordParas { get; set; } = new List<Para>();
        [NotMapped]
        //本次学习涉及的题目
        public  List<Question> Questions { get; set; } = new List<Question>();
    }
    public class Para
    {
        //自增主键
        public int ParaId { get; set; }

        public int UserId { get; set; }
        public bool IsRead { get; set; }
        //文章题目
        [Required]
        public string ParaTitle { get; set; }

        [NotMapped]
        public string Article { get; set; }

        //文章出现的核心词汇
        
        public List<Word> CoreWords { get; set; } = new List<Word>();

    }
    public class Question
    {
        //主键
        public int QuestionId { get; set; }
        public int UserId { get; set; }

        //题干
        public string Problem { get; set; }
        //四个单词选项
        public virtual List<Option> Options { get; set; } = new List<Option>();
        //标准答案
        public string Answer { get; set; }
        //用户是否做对
        public bool IsPass { get; set; }
        //判断用户是否做对
    }
    public class Option
    {
        public int OptionId { get;set;}
        public int QuestionId { get; set; }
        public string OptionWord { get; set; }
        public Option(string word)
        {
            OptionWord = word;
        }
        public Option()
        {

        }
    }
}
