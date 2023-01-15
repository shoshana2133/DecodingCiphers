using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace frequency
{
    class LetterPairs
    {
        static Dictionary<string, int> Dic_LetterPairs=new Dictionary<string, int>();
        static Dictionary<string, int> bla = new Dictionary<string, int>();


        //פונקציה שמחלקת את הטקסט לזוגות של אותיות ומכניסה אותם למילון עם מונה הופעות של כל זוג
        static public void FillingDic(string text)
        {
            for (int i = 1; i < text.Length-1; i++)
            {
                if (text[i] + "" == " " || text[i + 1] + "" == " ")
                    continue;
                    if(Dic_LetterPairs.ContainsKey(text[i] + "" + text[i + 1]))
                    Dic_LetterPairs[text[i] +""+ text[i + 1]] ++;
                    else
                    Dic_LetterPairs.Add(text[i] + "" + text[i + 1], 1);
            }
               Dic_LetterPairs.Max(x => x.Value);
            List<string> ss = new List<string>();
            foreach (var item in Dic_LetterPairs)
            {
                string s = item.Key;
                if (s[0] == s[1])
                    ss.Add(s);
            }
        }
    }
}
