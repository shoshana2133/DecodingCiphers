using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace frequency
{
    public class CutWords
    {

        static Stack<int> Spaces = new Stack<int>();
        static int basic = 0;
        static int index=2, max = 10, x;
        static string[] HebrewDictionary = {"הלכ","הלכת","הלכתי","לק","הי","היומ","לקנות","נעל","נעליים","נותנ","שר","חם","ילד","מודה","לד","שרה","הילדה","הכי","כי","חמודה","יהיו"};
        //   static bool flag = false;
        static string copyText="";
        //בנאי סטטי 
        static CutWords()
        {
        //    Exelread();
            int size = HebrewDictionary.Length;
        }
        //פונקציה לניהול חלוקת מילים
        public static string DivisionIntoProfits(string text)
        {
            copyText = text;

            while (copyText.Length > 0)
            { 
                string previusText = copyText;
                copyText = pushStack(copyText, index);
                //אם לא מצאת מילה וגם לא ניסית כבר לפענח אחרת עד שנסיים את המשפט
                //           if (Spaces.Count != 0 && index == max && Spaces.Peek() != index + basic) //&& flag== false)
                while (copyText==previusText)
                {
                    if(Spaces.Count==0)
                        return "not found";
                    //  flag= true;
                    //כנראה המילה הקודמת לא חולקה נכון
                    //נשלוף את המיקום של המילה האחרונה
                    x = Spaces.Pop();
                    //נשלח שוב את הטקסט לפיענוח חדש; אינדקס פיענוח החל מאורך מילה איקס והלאה 
                    if (Spaces.Count != 0)
                        basic = Spaces.Peek()+1;
                    else
                        basic = 0;
                    //שמירת הקודם
                    previusText = text.Substring(basic);
                    copyText = pushStack(text.Substring(basic), x - basic + 2);
                }
                


            
            index = 2;
            basic = Spaces.Peek()+1;
            //  flag= false;
        }

            return copyText;
        }

        //פונקציה למציאת מילים ודחיפת מיקום סוף מילה למחסנית
        public static string pushStack(string text, int i)
        {// לבדוק את הערך של אינדקס
            while (i <=text.Length && i != max)
            {
                if (isExists(text.Substring(0, i)))
                {
                    Spaces.Push(i+basic-1);
                    text= text.Substring(i);
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
           // string str = File.ReadAllText(@"C:\Hebrew dictionary.txt", Encoding.UTF8);
            //חותך את הקובץ למילים
            //HebrewDictionary = str.Split('\n');
            //for (int i = 0; i < HebrewDictionary.Length; i++)
            //{
            //    HebrewDictionary[i] = HebrewDictionary[i].Substring(0, HebrewDictionary[i].Length - 1);
            //}
        }
    }
}
