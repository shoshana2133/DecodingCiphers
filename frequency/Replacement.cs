using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace frequency
{
    static public class Replacement
    {
        //רשימה מסוג מחלקת מילה למעקב אחר כל מילה 
        static List<Word> Words = new List<Word>();
        //מילון החלפות
        static Dictionary<char, char> Dic_exchange = new Dictionary<char, char>();
        static Queue<int>[] Queue = new Queue<int>[11];
        //מונה האותיות שפוענחו
        static int cou = 7;


        //פונקציה לניהול הפיענוח
        public static string DecodingManagment(string text)
        {
            jj();
            //איתחול רשימת מילים
            InitList(text);
            //פונקציה חישוב שכיחויות אותיות
            Translate.deciphering(text);
            //פונקציה הממקמת את אותיות יומהלרש 
            PopularLetters();
            //פונקציה המטפלת בשאר האותיות
            DecipheringLetters();
            //החלפת האותיות בטקסט
            return Change(text);
        }
        //איתחול רשימת המילים
        public static void InitList(string text)
        {
            int i = 0;
            int index = 0;
            while (index!=-1)
            {
                index = text.IndexOf(" ");
                if (index != -1)
                {
                    Words.Add(new Word(text.Substring(0,index), text.Substring(0,index).Length, ch(i, text.Substring(0, index).Length)));
                    text = text.Substring(index + 1);
                }
                else
                    Words.Add(new Word(text, text.Length, ch(i,text.Length)));
                i++;
            }
        }

        //פונקציה הממקמת את אותיות יומהלרש 
        public static void PopularLetters()
        {
            Dic_exchange['י'] = Translate.Dic_exper_exchange.ElementAt(0).Key;
            LocationAndUpdate('י', Dic_exchange['י']);
            Dic_exchange['ו'] = Translate.Dic_exper_exchange.ElementAt(1).Key;
            LocationAndUpdate('ו', Dic_exchange['ו']);
            Dic_exchange['מ'] = Translate.Dic_exper_exchange.ElementAt(2).Key;
            LocationAndUpdate('מ', Dic_exchange['מ']);
            Dic_exchange['ה'] = Translate.Dic_exper_exchange.ElementAt(3).Key;
            LocationAndUpdate('ה', Dic_exchange['ה']);
            Dic_exchange['ל'] = Translate.Dic_exper_exchange.ElementAt(4).Key;
            LocationAndUpdate('ל', Dic_exchange['ל']);
            Dic_exchange['ר'] = Translate.Dic_exper_exchange.ElementAt(6).Key;
            LocationAndUpdate('ר', Dic_exchange['ר']);
            Dic_exchange['ש'] = Translate.Dic_exper_exchange.ElementAt(8).Key;
            LocationAndUpdate('ש', Dic_exchange['ש']);

        }
        //פונקציה המשנה את רשימת המילים ואת מילון ההחלפות
        public static void LocationAndUpdate(char tav, char tav2)

        {
            for (int i = 0; i < Words.Count(); i++)
            {
                if (Words[i].CipherWord.Contains(tav2))
                //שליחה לפונקציה שממקמת את האות
                { Words[i].LettersRemain -= Location(tav, tav2, i);
                }
                // בדיקה האם הגענו למילה עם אות אחת נעלמת 
                if (Words[i].LettersRemain == 1)
                {
                    Queue[2].Enqueue(i);

                    //דחיפה לתור באורך המילה את אינדקס המילה
                    // Queue[Words[i].Decoding.Length].Enqueue(i);
                }
            }
        }
        //פונקציה שממקמת את התור
        public static int Location(char tav, char tav2, int j)
        {
            int caunt = 0;
            if (Words[j].CipherWord[0] == tav2)
                Words[j].Decoding = tav+ Words[j].Decoding.Substring(1);


                for (int i = 1; i < Words[j].CipherWord.Length; i++)
            {
                if (Words[j].CipherWord[i] == tav2)
                {
                    Words[j].Decoding = Words[j].Decoding.Substring(0, i ) + tav + Words[j].Decoding.Substring(i + 1);
                    caunt++;
                }
            }
            return caunt;
        }

        //פונקציה שממקמת את ? לפי אורך המילה
        public static string ch(int j,int k)
        {
            string str = "";
            for (int i = 0; i < k; i++)
            {
                str += "?";
            }
            return str;
        }

        //פונקציה שמטפלת באותיות שיש בהם אות נעלמת אחת
        public static bool Try(int ind)
        {
            string copyWord = Words[ind].Decoding;
            int count = 0;
            int index = 0;
            for (int i = 0; i < Dic_exchange.Count; i++)
            {
                //לודא שהאות לא פוענחה עדיין
                copyWord.Replace('?', Dic_exchange.ElementAt(i).Key);
                if (CutWords.isExists(copyWord) == true) {
                    count++;
                    index = i;
                }
            }
            if (count == 1)
            {

                Dic_exchange[Dic_exchange.ElementAt(index).Key] = copyWord[Words[ind].Decoding.IndexOf('?')];
                cou++;
                //שליחה לפונקציית עדכון המילים
                LocationAndUpdate(Dic_exchange.ElementAt(index).Key, copyWord[Words[ind].Decoding.IndexOf('?')]);
                return true;
            }
            return false;
        }

        //פונקציה שמטפלת בפיענוח שאר האותיות
        public static void DecipheringLetters() {
            bool flag = false;
            //כל עוד לא פוענחו כל האותיות במילון האותיות
            while (cou <= 22)
            {
                if (Queue[2].Count != 0)
                    QueuingCare(2);
                for (int i = 10; i >= 3 && flag == false; i--)
                {
                    //שולח את מספר התור לטיפול
                    flag = QueuingCare(i);
                }
            }
        }

        //פונקציה טיפול בתור
        public static bool QueuingCare(int i)
        {
            while (Queue[i].Count != 0)  
                if (Try(Queue[i].Dequeue()) == true)
                    return true;

            return false;
        }
        //פונקציה להחלפת האותיות לפיענוח סופי
        public static string Change(string text)
        {
            for (int i = 0; i < Dic_exchange.Count; i++)
            {
                text.Replace(Dic_exchange.ElementAt(i).Value, Dic_exchange.ElementAt(i).Key);
            }
            return text;
        }
        public static void jj()
        {
            for (int i = 2; i < 11; i++)
            {
                Queue[i] = new Queue<int>();
            }
        }
    }
    
}
