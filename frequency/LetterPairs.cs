using System;
using System.Collections.Generic;
using System.Text;

namespace frequency
{
    class LetterPairs
    {
        static Dictionary<string, int> Dic_LetterPairs;
        static public void FillingDic(string text)
        {
            for (int i = 0; i < text.Length-1; i++)
            {
                Dic_LetterPairs.TryAdd(text[i] + text[i + 1], 1);
            }
        }
    }
}
