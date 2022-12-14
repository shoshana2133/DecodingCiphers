using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

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

        //פןנקציה המקבלת שורה בטבלה וממלאה את המילון
        public static void Table_Freq(string  str, string name)
        {
            string [] strWords;
            strWords = str.Split(',');
            string spl = strWords[1].Substring(0, strWords[1].Length - 1);
            if (name== "letters.txt") { 
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
            Exelread("letters.txt");
            //ממלא את המילון  ההחלפה לפי הקובץ
            Dic_exchange = new Dictionary<char, char>();
            //קריאה לפונקציה שקוראת מהקובץ
            Exelread("exchange.txt");
            //שליחה לפםונקצית מילוי

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
            string str = File.ReadAllText(@"X:\הנדסאים שנה ב תשפג\פרויקטים\שושנה חיה ישראלוב\frequency\frequency\"+name, Encoding.UTF8);
            string[] strSentense;
            //חותך את הקובץ למשפטים
            strSentense = str.Split('\n');
            //לולאה שעוברת על המשפטים ושולחת אותן לפונקציה שיוצרת טבלת שכיחויות
            foreach (var item in strSentense)
                Table_Freq(item,name);
        }

        // לפונקציה שממלאת את המילון לפי הטקסט
        public static void freq_text(string text,char tav)
        {
            double precent = freq(text, tav);
            //שמירה של 2 ספרות לאחר הנקודה העשרונית
            precent = Math.Round(precent, 2);
            Dic_text_frequency.Add(tav, precent);
        }
        //פענוח
        //מקבלת טקסט מוצפן מחזירה טקסט מפוענח
        public static string deciphering(string text)
        {
            Dic_text_frequency = new Dictionary<char, double>();
            text = text.Replace(" ", "");
            char tav = 'א';
            string answer = text;
            //שולח לפונקציה שממלאת את המילון לפי הטקסט
            while (tav <= 'ת')
                freq_text(text, tav++);
            //שולח לפונקציה שמתאימה בין אחוזים של הטקסט והקובץ
            var sort_dic = Dic_frequency.OrderByDescending(item => item.Value);
            //text.Replace()
            return answer;
      }

       //אילו אותיות יש להחליף באילו אותיות
       //לאחר שמחליטים מה מחליפים במה להחליף את האותיות ע"פ מילון ההחלפה לפי האות שמחליפים בה בערך של האות האנגלית
       //אחרי שהעברנו הכל לאותיות אנגלית להחליף לאותיות עברית על פי הערך במילון ההחלפה

        //לשקול מילוי של מפתח הפיענוח במילון של 
        //char char

    }

}
