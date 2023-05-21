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
        public static List<Function> ReadFromJsonFile(string filePath)
        {
            // Read the JSON data from the file
            string json = File.ReadAllText(filePath);

            // Deserialize the JSON data into a list of Function objects
            List<Function> data = JsonConvert.DeserializeObject<List<Function>>(json);
            data= data.OrderBy(c=>c.NumPlates).ToList();
            return data;
            
        }

        public static void Load()
        {
            m = typeof(ProjectManagement).GetMethods();
            List<Function> data=ReadFromJsonFile(@"D:\file.json");
            for (int i = 0; i <data.Count; i++)
            {
                D_F +=(d) m.FirstOrDefault(item => item.Name == data[i].NameFunc).CreateDelegate(typeof(d));
           

            }
        }

        public string DivisionIntoProfits(string text)
        {
            return CutWords.DivisionIntoProfits(text);
        }
        public string DecipherATBS(string text)
        {
            return Ciphers.DecipherATBS(text);
        }
        //מה לעשות עם צופן קיסר יש לו הרבה הסטים
        public void CaesarCipher(string text)
        {
            Ciphers.CaesarCipher(text);
        }

        public string DecodeStringGader(string text)
        {
            return Ciphers.DecodeStringGader(text);
        }

        //מה לעשות מקבל מספר
        public void ColumnTranspositionDecoding(string text)
        {
             Ciphers.ColumnTranspositionDecoding(text,1);
        }

        public string DecodingManagment(string text)
        {
            return Replacement.DecodingManagment(text);
        }
        string start(string name,string text)
        { 
            var l = D_F.GetInvocationList();
           return (string) l.First(func => func.GetMethodInfo().Name == name).DynamicInvoke(text);
        
        }
    }
}
