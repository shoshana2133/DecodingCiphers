using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace frequency
{
    public class CutWords
    {

        static Stack<int> Spaces = new Stack<int>();
        static int basic = 0;
        static int index=2, max = 10, x, y;
        static string[] HebrewDictionary;
        static bool flag = false;

        //בנאי סטטי 
        static CutWords()
        {
            Exelread();
            int size = HebrewDictionary.Length;
        }
        //פונקציה לניהול חלוקת מילים
        public static string DivisionIntoProfits(string text)
        {
            string copyText = text;

            while (copyText.Length > 0)
            {
                copyText= pushStack(copyText,index);
                //אם לא מצאת מילה וגם לא ניסית כבר לפענח אחרת
                if (Spaces!=null && index==max && Spaces.Peek()!= index + basic && flag== false)
                {
                    flag= true;
                    //כנראה המילה הקודמת לא חולקה נכון
                    //נשלוף את המיקום של המילה האחרונה
                    x= Spaces.Pop();
                    //נשלח שוב את הטקסט לפיענוח חדש; אינדקס פיענוח החל מאורך מילה איקס והלאה 
                    copyText = pushStack(text.Substring(Spaces.Peek()),x-Spaces.Peek()+1);
                }
                index = 2;
                basic = Spaces.Peek() + 1;
                flag= false;
            }

            return copyText;
        }

        //פונקציה למציאת מילים ודחיפת מיקום סוף מילה למחסנית
        public static string pushStack(string text, int i)
        {
            while (text.Length > 0 && index != max)
            {
                if (isExists(text.Substring(0, index)))
                {
                    Spaces.Push(index+basic);
                    text= text.Substring(index+1);
                    return text;
                }
                index++;
            }
            return text;
        }

        //פונקציה שבודקת האם מילה מסוימת קיימת במילון
        public static bool isExists(string word)
        {
            for (int i = 0; i < HebrewDictionary.Length; i++)
            {
                if (HebrewDictionary[i] == word)
                    return true;
            }
            return false;
        }

        public static void Exelread()
        {
            //קורא את הקובץ מילון עברי
            string str = File.ReadAllText(@"C:\Hebrew dictionary.txt", Encoding.UTF8);
            //חותך את הקובץ למילים
            HebrewDictionary = str.Split('\n');
            for (int i = 0; i < HebrewDictionary.Length; i++)
            {
                HebrewDictionary[i] = HebrewDictionary[i].Substring(0, HebrewDictionary[i].Length - 1);
            }
        }
    }
}
