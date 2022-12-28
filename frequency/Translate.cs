using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Data;
using System.Windows;
namespace frequency
{
   public class  Translate
    {
        //מילון של האותיות ושכיחות של כל אות
        static Dictionary<char, double> Dic_frequency;
        //מילון של שכיחות של כל אות בטקסט
        static Dictionary<char, double> Dic_text_frequency;
        //מילון החלפות
        static Dictionary<char, char> Dic_exchange;
        //מילון נסיון של החלפות
        static Dictionary<char, char> Dic_exper_exchange;
        static Dictionary<char, double> sort_dic_text;
        static Dictionary<char, double> sort_dic;


        //פןנקציה המקבלת שורה בטבלה וממלאה את המילון
        public static void Table_Freq(string  str, string name)
        {
            string [] strWords;
            strWords = str.Split(',');
            string spl = strWords[1].Substring(0, strWords[1].Length - 1);
            if (name== "letters_avg.txt") { 
            double num = double.Parse(spl);
            //מילוי המילון של השכיחיות
            Dic_frequency.Add(char.Parse(strWords[0]), num);}
            else
                //מילוי המילון של ההחלפות
            Dic_exchange.Add(char.Parse(strWords[0]), char.Parse(spl));
        }
    
        
        //פונקציה שמקבלת שכיחות ומחזירה אות משוערת 

        static Translate()
        {
            //ממלא את המילון לפי הקובץ
            Dic_frequency = new Dictionary<char, double>();
            //קריאה לפונקציה שקוראת מהקובץ
            Exelread("letters_avg.txt");
            //ממלא את המילון  ההחלפה לפי הקובץ
            Dic_exchange = new Dictionary<char, char>();
            //קריאה לפונקציה שקוראת מהקובץ
            Exelread("exchange.txt");
        }
      

        //פונקציה שמקבלת אות וטקסט ומחזירה את השכיחות של האות בטקסט באחוזים
        public static double freq(string text, char ch)
        {
            int count = 0;
            //לולאה שעוברת על הטקסט וסופרת את מספר המופעים של האות בטקסט
            for (int i = 0; i < text.Length; i++)
                if (text[i] == ch)
                    count++;
            //מחזירה את השכיחות של האות בטקסט באחוזים
            double p = count *100;
            return p/text.Length;
           
        }


        public static void Exelread( string name)
        {
            //קורא את הקובץ שכיחויות
            string str = File.ReadAllText(@"C:\" + name, Encoding.UTF8);
            string[] strSentense;
            //חותך את הקובץ למשפטים
            strSentense = str.Split('\n');
            //לולאה שעוברת על המשפטים ושולחת אותן לפונקציה שיוצרת טבלת שכיחויות
            foreach (var item in strSentense)
                Table_Freq(item,name);
        }


        //אפשר לקצר את הפונקציה?
        //לבדוק אותיות סופיות בטקסט המתקבל//
        //לפונקציה שממלאת את המילון לפי הטקסט
        public static void freq_text(string text,char tav)
        {
            double precent;
            //switch (tav)
            //{
            //    case 'ך':
            //        precent= freq(text, 'כ'); break;
            //    case 'ם':
            //        precent= freq(text, 'מ'); break;
            //    case 'ן':
            //        precent= freq(text, 'נ'); break;
            //    case 'ף':
            //        precent = freq(text, 'פ'); break;
            //    case 'ץ':
            //        precent = freq(text, 'צ'); break;
            //    default:
                    precent = freq(text, tav); //break;
            //}
            //שמירה של 2 ספרות לאחר הנקודה העשרונית
            precent = Math.Round(precent, 2);
            Dic_text_frequency.Add(tav, precent);
        }

        // ממינת את המילון לפי הערך
        public static Dictionary<char, double> sort_dict(Dictionary<char, double> dict_to_sort)
        {
            return new Dictionary<char, double>(
                from entry in dict_to_sort orderby entry.Value ascending select entry);
        }


        //פענוח
        //מקבלת טקסט מוצפן מחזירה טקסט מפוענח
        public static string deciphering(string text)
        {
            Dic_text_frequency = new Dictionary<char, double>();
            //text = text.Replace(" ", "");
            char tav = 'א';
            string answer = text;
            //שולח לפונקציה שממלאת את המילון לפי הטקסט
            while (tav <= 'ת') {
                if (tav == 'ם' || tav == 'ך' || tav == 'ץ' || tav == 'ן' || tav == 'ף')
                {
                    tav++;
                    continue;
                }
                freq_text(text, tav++);
            }
            //שולח לפונקציה שמתאימה בין אחוזים של הטקסט והקובץ
            //text.Replace()
            //מיון של מילון הטקסט והשכיחויות לפי הערך
             sort_dic_text = sort_dict(Dic_text_frequency);
             sort_dic = sort_dict(Dic_frequency);
            //פונקציה שמתאימה בין האותיות להחלפה
            Match();
            answer = ReplaceText(answer);
            return answer;
        }


        //אילו אותיות יש להחליף באילו אותיות
        //לאחר שמחליטים מה מחליפים במה להחליף את האותיות ע"פ מילון ההחלפה לפי האות שמחליפים בה בערך של האות האנגלית
        //אחרי שהעברנו הכל לאותיות אנגלית להחליף לאותיות עברית על פי הערך במילון ההחלפה

        //לשקול מילוי של מפתח הפיענוח במילון של 
        //char char

        public static void Match()
        {
            Dic_exper_exchange = new Dictionary<char, char>();
            for (int i = sort_dic.Count - 1; i >= 0; i--)
            {
                Dic_exper_exchange.Add( sort_dic_text.ElementAt(i).Key,sort_dic.ElementAt(i).Key);
            }
        }


        public static string ReplaceText(string answer)
        {
            foreach (var item in Dic_exper_exchange)
            {
                char ch = Dic_exchange[item.Value]; 
                answer = answer.Replace(item.Key, ch);
            }
            foreach (var item in Dic_exchange)
            {
                answer = answer.Replace(item.Value,item.Key);
            }
            return answer;
        }

       
        // לכתוב פונקציה שבונה מילון חדש המורכב מאיחוד המפתחות של המילונים הממוינים
        // לכתוב פונקציה שמקבלת מילון הממוין שלעיל ומחליפה את הטקסט בהתאם
        // פונקציה זו תיעזר בפונקציה נוספת של מילון העזר בשביל החלפת אות
        // עוברים בלולאה על המילון לעיל ועבור כל מפתח מבצעים את ההחלפה בטקסט בפועל בעזרת הפונקציה לעיל של החלפת אות
        // בדיקת הקוד על הרבה טקסטים ושמירת התוצאות........
    }

}
