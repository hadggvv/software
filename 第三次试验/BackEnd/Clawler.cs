using Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Project
{
    public class Clawler
    {
        //公有静态接口，用于获取某个单词的信息
        public static Word DownLoad(string keyword)
        {
            string Url = "http://www.youdao.com/w/eng/" + keyword + "/#keyfrom=dict2.index";
            string AmericaAudio = "http://dict.youdao.com/dictvoice?audio=" + keyword + "&type=1";
            string EnglishAudio = "http://dict.youdao.com/dictvoice?audio=" + keyword + "&type=2";
            string jsonFileUrl = "https://picdict.youdao.com/search?q=" + keyword + "&le=en";
            string html = "";

            WebClient webClient = new WebClient();

            //request headers配置
            webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36 SE 2.X MetaSr 1.0");
            webClient.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            webClient.Headers.Add("keep-alive", "true");
            webClient.Headers.Add("Host", "www.youdao.com");
            webClient.Headers.Add("Referer", "http://www.youdao.com/");
            webClient.Encoding = Encoding.UTF8;
            try
            {
                //html
                html = webClient.DownloadString(Url);

                ///获取图片url
                /*原网页通过js代码ajax异步抓取图片url，静态爬虫得到的html中不含动态元素信息。
                分析js代码得到以下url模板，该url返回一个包含图片url的json文件。                     */
                string json = webClient.DownloadString(jsonFileUrl);
                Match imgMatch = new Regex(@"pic"":\[{""image"":""(?<imgUrl>[^,""]*)"",").Match(json);
                string imgUrl = imgMatch.Groups["imgUrl"].Value;
                webClient.DownloadFile(imgUrl, keyword + ".png");
                //下载单词的美音音频到本地
                webClient.DownloadFile(AmericaAudio, keyword + "_America.mp3");
                //下载单词的英音到本地
                webClient.DownloadFile(EnglishAudio, keyword + "_English.mp3");
            }
            //下载图片到本地,一些单词没有图片捕获异常
            catch (System.ArgumentException)
            {
                Console.WriteLine("{0} no photo!", keyword);
            }
            catch (Exception e)
            {
              //  MessageBox.Show(e.Message + "stop at" + keyword );
            }
            return Parse(keyword, html);
        }
        //解析html
        private static Word Parse(string keyword, string html)
        {
            if (html != "")
            {
                //解析词意
                string transPattern1 = @"trans-container"">[^=]*=";
                string transPattern2 = @"<li>.*</li>";
                string ul = "";
                var trimedHtml = new Regex(transPattern1).Match(html).Value;
                List<string> transList = new List<string>();
                ul = trimedHtml.Substring(trimedHtml.IndexOf('<')).Trim('\r', '\n', '\t');
                var transMatches2 = new Regex(transPattern2).Matches(ul);
                foreach (Match match in transMatches2)
                {
                    transList.Add(match.Value.Trim('<', '>', 'l', 'i', '/'));
                }

                //解析发音
                string phoneticPattern1 = @"span class=""phonetic[^<]*<";
                string EngPhonetic = "";
                string AmeriPhonetic = "";
                var originMatches = new Regex(phoneticPattern1).Matches(html);
                //有的单词可能只有英音或美音一个
                try
                {
                    EngPhonetic = originMatches[0].Value.Substring(originMatches[0].Value.IndexOf('[')).Trim('<');
                }
                catch (Exception)
                {
                    try
                    {
                        AmeriPhonetic = originMatches[1].Value.Substring(originMatches[1].Value.IndexOf('[')).Trim('<');
                    }
                    catch(Exception)
                    {
                        return null;
                    }
                    EngPhonetic = AmeriPhonetic;
                    //MessageBox.Show(e.Message + "stop at" + keyword);
                }
                finally
                {
                    try
                    {
                        AmeriPhonetic = originMatches[1].Value.Substring(originMatches[1].Value.IndexOf('[')).Trim('<');
                    }
                    catch (Exception)
                    {
                        AmeriPhonetic=EngPhonetic;
                    }
                }
                //      Console.OutputEncoding = Encoding.UTF8;//解决音标乱码utf-8


                //解析例句
                string examplePattern1 = @"examples"">[^/]*</p>[^/]*";
                string examplePattern2 = @">.*<";
                string examplePattern3 = @"[^<p>\n\s][\S\W]*";
                var firstMatches = new Regex(examplePattern1).Matches(html);
                List<string> EngStnsList = new List<string>();
                List<string> ChiStnsList = new List<string>();
                foreach (Match match1 in firstMatches)
                {
                    string EngStn = "";
                    string ChiStn = "";
                    string example1 = match1.Value.Substring(match1.Value.IndexOf('<')).TrimEnd('<');
                    string[] examples = example1.Split('/');
                    //英语例句
                    var EngMatches = new Regex(examplePattern2).Matches(examples[0]);
                    foreach (Match match2 in EngMatches)
                    {
                        EngStn = match2.Value.Trim('>', '<');
                    }
                    //对应的中文例句
                    var ChiMatches = new Regex(examplePattern3).Matches(examples[1].Replace(" ", "").Trim('\n', '\t'));
                    foreach (Match match2 in ChiMatches)
                    {
                        ChiStn = match2.Value.Replace(" ", "");
                    }
                    //同时存到list
                    if (EngStn != "" && ChiStn != "")
                    {
                        EngStnsList.Add(EngStn);
                        ChiStnsList.Add(ChiStn);
                    }
                }


                //解析词组
                string GroupPattern1 = @"<p class=""wordGroup"">[\s]*<span class=""contentTitle"">[\s]*<a class=""search-js"" href=""[^""]*"">(?<WordGroup>[^<]*)</a>[\s]*</span>(?<GroupTrans>[^<]*)<";
                var firstMatch = new Regex(GroupPattern1).Matches(html);
                List<string> wordGroups = new List<string>();
                List<string> groupTrans = new List<string>();
                foreach (Match match3 in firstMatch)
                {
                    wordGroups.Add(match3.Groups["WordGroup"].Value);
                    string[] tmpTrans1 = match3.Groups["GroupTrans"].Value.Replace(" ", "").Trim('\n').Split(';');
                    string groupTran = "";
                    Array.ForEach(tmpTrans1, t => groupTran = groupTran + t.Replace('\n', ';').Trim(';') + " ");
                    groupTrans.Add(groupTran);
                }


                //返回Word实例
                Word word = new Word();
                word.KeyWord = keyword;
                transList.ForEach(t =>
                    word.Translations.Add(t));
                if (EngStnsList.Count == ChiStnsList.Count)
                    for (int i = 0; i < EngStnsList.Count - 1; i++)
                        word.Examples.Add(new Example(EngStnsList[i], ChiStnsList[i]));
                if (wordGroups.Count == groupTrans.Count)
                    for (int i = 0; i < wordGroups.Count - 1; i++)
                        word.Collocations.Add(new Collocation(wordGroups[i], groupTrans[i]));
                word.Phonetics = new Phonetic(EngPhonetic, AmeriPhonetic);
                return word;
            }
            return null;
        }
    }
}
