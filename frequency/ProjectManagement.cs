using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace frequency
{
    public delegate string d(string text);
    public class ProjectManagement
    {
        public static d D_F { get; set; }
        static MethodInfo[] m;
        static List<Function> data;
        public static void ReadFromJsonFile(string filePath)
        {
            // Read the JSON data from the file
            string json = File.ReadAllText(filePath);

            // Deserialize the JSON data into a list of Function objects
            data = JsonConvert.DeserializeObject<List<Function>>(json);
            data = data.OrderBy(c => c.NumPlates).ToList();
            //return data;

        }

        public static void Load()
        {
            m = typeof(ProjectManagement).GetMethods();
            ReadFromJsonFile(@"D:\file.json");

            D_F += DivisionIntoProfits;
            D_F += DecipherATBS;
            D_F += CaesarCipher;
            D_F += DecodeStringGader;
            D_F += ColumnTranspositionDecoding;
            D_F += DecodingManagment;


        }
        public static string Manage(string text)
        {
            string decode = "";
            for (int i = 0; i < data.Count; i++)
            {
                decode = start(data[i].NameFunc, text);
                if (decode != "")
                {   //עדכון מספר פעמים ותאריך אחרון לקובץ
                    // Increment the 'num' field by 1
                    data[i].NumPlates++;
                    // Set the 'date' field to the current date
                    data[i].DatePlate = DateTime.Now.ToString("yyyy-MM-dd");
                    // Serialize the updated object back to JSON and write it to the file
                    File.WriteAllText(@"D:\file.json", JsonConvert.SerializeObject(data));
                    return decode;
                }
            }
            return "not found";
        }
        public static string DivisionIntoProfits(string text)
        {
            return CutWords.DivisionIntoProfits(text);
        }
        public static string DecipherATBS(string text)
        {
            return Ciphers.DecipherATBS(text);
        }
        // צופן קיסר יש לו הרבה הסטים
        public static string CaesarCipher(string text)
        {
            for (int i = 1; i < 22; i++)
            {
                text = Ciphers.DecipherCaesar(text, i);
                text = CutWords.DivisionIntoProfits(text);
                if (text != "")
                    return text;

            }
            return "";
        }

        public static string DecodeStringGader(string text)
        {
            return Ciphers.DecodeStringGader(text);
        }

        public static string ColumnTranspositionDecoding(string text)
        {//מנסה מספר אפשרויות של חלוקת השורות
            for (int i = 2; i < 10; i++)
            {
                text = Ciphers.ColumnTranspositionDecoding(text, i);
                text = CutWords.DivisionIntoProfits(text);
                if (text != "")
                    return text;

            }
            return "";
        }

        public static string DecodingManagment(string text)
        {
            return Replacement.DecodingManagment(text);
        }
        static string start(string name, string text)
        {
            var l = D_F.GetInvocationList();
            return (string)l.First(func => func.GetMethodInfo().Name == name).DynamicInvoke(text);

        }
    }
}
