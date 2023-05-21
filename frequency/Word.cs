using System;
using System.Collections.Generic;
using System.Text;

namespace frequency
{
    public class Word
    {
        public string CipherWord { get; set; }//מילה מוצפנת
        public int LettersRemain { get; set; }//אותיות שנותרו
        public string Decoding { get; set; }//מילה מפוענחת
        public Word(string CipherWord,int LettersRemain,string Decoding)
        {
            this.CipherWord = CipherWord;
            this.LettersRemain = LettersRemain;
            this.Decoding = Decoding;
        }
    }
}
