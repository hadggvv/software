using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project
{
    //单词类
    public class Word
    {
        //主键
        public long WordId { get; set; }

        public int UserId { get; set; }
        public int RecordId { get; set; }

        [Required]
        public string KeyWord { get; set; }

        //用户添加的单词注释,default:null
        public string Annotation { get; set; }
        [NotMapped]
        public bool IsLearned { get; set; } = false;
        [NotMapped]
        public bool IsCustom { get; set; } = false;
        [NotMapped]
        public bool IsFavor { get; set; } = false;
        [NotMapped]
        //学习次数超过三次标注为已学，单词学习一轮寻为3种循环
        public int LearnTimes { get; set; } 
        //词意
        [NotMapped]
        public List<string> Translations { get; set; } = new List<string>();

        //英文例句
        [NotMapped]
        public List<Example> Examples { get; set; } = new List<Example>();

        //词组搭配
        [NotMapped]
        public List<Collocation> Collocations { get; set; } = new List<Collocation>();
        //音标
        [NotMapped]
        public Phonetic Phonetics { get; set; }
        public Word()
        {
            
        }
        public Word(string s)
        {
            this.KeyWord = s;
        }

    }
    //音标类
    public class Phonetic
    {

        //英文例句
        public string EngPhonetic { get; set; }

        //例句翻译
        public string AmeriPhonetic { get; set; }
        public Phonetic(string e, string a)
        {
            EngPhonetic = e;
            AmeriPhonetic = a;
        }
    }
    //例句类
    public class Example
    {

        //英文例句
        public string EngStn { get; set; }

        //例句翻译
        public string ChiStn { get; set; }
        public Example(string e, string c)
        {
            EngStn = e;
            ChiStn = c;
        }
    }
    //词组类
    public class Collocation
    {
        //英文词组
        public string WordGroup { get; set; }
        //词组翻译
        public string GroupTran { get; set; }
        public Collocation(string wg, string gt)
        {
            WordGroup = wg;
            GroupTran = gt;
        }
    }
}
