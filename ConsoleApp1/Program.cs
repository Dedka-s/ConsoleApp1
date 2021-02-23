using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string allText = File.ReadAllText("E:\\text.txt");
            Regex reg_exp = new Regex("[^a-zA-Zа-яА-Я]");
            allText = reg_exp.Replace(allText, " ");

            string[] words = allText.Split(
            new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);
            var wordList = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
                if (wordList.ContainsKey(words[i]))
                {
                    wordList[words[i]]++;
                } else
                {
                    wordList.Add(words[i], 1);
                }
            }

            wordList = wordList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

          
            using (FileStream fs = new FileStream("E:\\textResalt.txt", FileMode.OpenOrCreate))
            {
                using (TextWriter tw = new StreamWriter(fs))

                    foreach (KeyValuePair<string, int> kvp in wordList)
                    {
                        tw.WriteLine(string.Format("{0};{1}", kvp.Key, kvp.Value));
                    }
            }



        }
    }
}
