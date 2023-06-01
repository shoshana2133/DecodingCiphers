using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

namespace frequency
{
    public class CutWords
    {

        static Stack<int> Spaces = new Stack<int>();
        static int basic = 0;
        static int index = 2, max = 10, x;
        static string[] HebrewDictionary;
        //   static string[] HebrewDictionary = {"הלכ","הלכת","הלכתי","לק","הי","היומ","לקנות","נעל","נעליים","נותנ","שר","חם","ילד","מודה","לד","שרה","הילדה","הכי","כי","חמודה","יהיו"};
        static string copyText = "";
        //בנאי סטטי 
        static CutWords()
        {
            Exelread();
            int size = HebrewDictionary.Length;
        }
        //פונקציה לניהול חלוקת מילים
        public static string DivisionIntoProfits(string text)
        {
            copyText = text;
            //כל עוד לא סיימת לחלק את הטקסט
            while (copyText.Length > 0)
            {
                //שמירת המילה הקודמת
                string previusText = copyText;
                //פונקציה למציאת מילה ודחיפת מיקום סוף מילה למחסנית
                copyText = pushStack(copyText, index);
                while (copyText == previusText)
                {  // אם אין מיקומים המחסנית - אין אופציות נוספות לחיתוך
                    if (Spaces.Count == 0)
                        return "not found";
                    //אם נכנס ללולאה
                    //כנראה המילה הקודמת לא חולקה נכון
                    //נשלוף את המיקום של המילה האחרונה
                    x = Spaces.Pop();
                    //נשלח שוב את הטקסט לפיענוח חדש; אינדקס פיענוח החל מאורך מילה איקס והלאה 
                    if (Spaces.Count != 0)
                        basic = Spaces.Peek() + 1;
                    else
                        basic = 0;
                    //שמירת הקודם
                    previusText = text.Substring(basic);
                    //נשלח למציאת מילה שוב
                    copyText = pushStack(text.Substring(basic), x - basic + 2);
                }
                //לאחר מציאת מילה נוריד את מינימום אורך המילה הבאה ל-2
                index = 2;
                basic = Spaces.Peek() + 1;
            }
            return PutSpace(text);
        }

        //פונקציה למציאת מילים ודחיפת מיקום סוף מילה למחסנית
        public static string pushStack(string text, int i)
        {
            while (i <= text.Length && i != max)
            {
                //בדיקה הם המילה קיימת
                if (isExists(text.Substring(0, i)))
                {
                    Spaces.Push(i + basic - 1);
                    text = text.Substring(i);
                    return text;
                }
                i++;
            }
            index = i;

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
            string str = File.ReadAllText(@"D:\ee.txt", Encoding.UTF8);
            // if(str.Contains('ף')
            //use the non end leters file
            //  חותך את הקובץ למילים
            HebrewDictionary = str.Split('\n');
            for (int i = 0; i < HebrewDictionary.Length; i++)
            {
                HebrewDictionary[i] = HebrewDictionary[i].Substring(0, HebrewDictionary[i].Length - 1);
            }

        }
        public void ChangeEnd()
        {

            //File.ReadAllText();
            //string str = "וף ןל מם";
            //str = str.Replace('ף', 'פ');
            //File.WriteAllText(path, str);
        }
        public static string PutSpace(string text)
        {
            int i = Spaces.Count - 1;
            int buf = 0;
            string str = null;
            while (text != null)
            {
                str += text.Substring(0, Spaces.ElementAt(i) + 1 - (buf));
                text = text.Substring(Spaces.ElementAt(i) + 1 - buf);
                buf = Spaces.ElementAt(i) + 1;
                str += " ";
                i--;
            }

            return str;
        }
    }
}
