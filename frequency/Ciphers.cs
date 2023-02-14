using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace frequency
{
    public class Ciphers
    {
        //את בש
        public static string Decipher(string cipher)
        {
            string deciphered_text = "";
            string alphabet = "אבגדהוזחטיכלמנסעפצקרשת";
            int index;
            foreach (char letter in cipher)
            {
                if (!alphabet.Contains(letter))
                    deciphered_text += letter;
                else
                {
                    index = alphabet.IndexOf(letter);
                    deciphered_text += alphabet[21 - index];
                }
            }
            return deciphered_text;
        }
        //קיסר פיענוח
        public static string DecipherCaesar(string cipher, int shift)
        {
            StringBuilder decipheredText = new StringBuilder();
            string alphabet = "אבגדהוזחטיכלמנסעפצקרשת";

            foreach (char letter in cipher)
            {
                if (alphabet.Contains(letter))
                {
                    int index = (alphabet.IndexOf(letter) - shift + 22) % 22;
                    decipheredText.Append(alphabet[index]);
                }
                else
                {
                    decipheredText.Append(letter);
                }
            }

            return decipheredText.ToString();
        }
        //הצפנת קיסר
        public static string EncryptCaesar(string plainText, int shift)
        {
            StringBuilder encryptedText = new StringBuilder();
            string alphabet = "אבגדהוזחטיכלמנסעפצקרשת";

            foreach (char letter in plainText)
            {
                if (alphabet.Contains(letter))
                {
                    int index = (alphabet.IndexOf(letter) + shift) % 22;
                    encryptedText.Append(alphabet[index]);
                }
                else
                {
                    encryptedText.Append(letter);
                }
            }

            return encryptedText.ToString();
        }
        //פונקציה שמנסה את כל האפשרויות של צופן קיסר
        public static void CaesarCipher(string text)
        {
            for (int i = 1; i < 22; i++)
            {
                string decryptedText = DecipherCaesar(text, i);

                Console.WriteLine("Shift: " + i + " | Decrypted: " + decryptedText);
            }
        }
        //הצפנה גדר
        public static string MergeLetters(string text)
        {
            int len = text.Length;

            // Divide the string into two parts
            string leftPart = text.Substring(0, len / 2);
            string rightPart = text.Substring(len / 2);

            StringBuilder sb = new StringBuilder();

            // Merge letters from both parts
            for (int i = 0; i < len / 2; i++)
            {
                sb.Append(leftPart[i]);
                sb.Append(rightPart[i]);
            }

            return sb.ToString();
        }
        //פיענוח גדר
        public static string DecodeString(string text)
        {
            int len = text.Length;

            // Divide the string into two parts
            StringBuilder leftPart = new StringBuilder();
            StringBuilder rightPart = new StringBuilder();

            StringBuilder sb = new StringBuilder();

            // Merge letters from both parts
            for (int i = 0; i < len; i += 2)
            {
                leftPart.Append(text[i]);
                rightPart.Append(text[i + 1]);
            }
            sb.Append(leftPart.ToString());
            sb.Append(rightPart.ToString());
            return sb.ToString();
        }
        //פוונקציה העמודה הצפנה
        public static string ColumnarTranspositionEncrypt(string plaintext, int key)
        {
            // Calculate number of rows needed 
            int numRows = plaintext.Length / key;
            //אם יש שארית תוסיף עמודה
            if (plaintext.Length % key != 0)
            {
                // Fill the matrix with plaintext 
                numRows++;
            }

            // Create empty matrix for encryption 
            char[,] matrix = new char[numRows, key];

            int i = 0, j = 0;
            foreach (char c in plaintext)
            {
                matrix[i, j] = c;
                j++;
                //אם סיימת שורה עבור שורה
                if (j == key)
                {
                    i++;
                    j = 0;
                }
            }
            string ciphertext = "";

            for (int k = 0; k < key; k++)
            {
                for (i = 0; i < numRows; i++)
                {
                    ciphertext += matrix[i, k];
                }
            }

            return ciphertext;

        }

        //פונקציה העמודה פיענוח
        public static string ColumnTranspositionDecoding(string plaintext, int key)
        {
            int numColumn = plaintext.Length / key;

            // Create empty matrix for encryption 
            char[,] matrix = new char[key, numColumn];

            int i = 0, j = 0;
            foreach (char c in plaintext)
            {
                matrix[i, j] = c;
                j++;
                //אם סיימת שורה עבור שורה
                if (j == numColumn)
                {
                    i++;
                    j = 0;
                }
            }
            string ciphertext = "";

            for (int k = 0; k < numColumn; k++)
            {
                for (i = 0; i < key; i++)
                {
                    ciphertext += matrix[i, k];
                }
            }

            return ciphertext;

        }
        // צופן א"ט ב"ח
        //העיקרון המנחה של צופן זה הוא החלפת אותיות בעלות ערך מספרי כולל של עשר / מאה / 500.כאשר האותיות ה,נ שאין להן בן זוג מאותה המשפחה, מתחלפות ביניהן.
        //כגון: 10 = 1+9, 2+8, 3+7.
        //100 = 10+90, 20+80.

        //צופן ויז'נר
        //הוא צופן החלפה רב-אלפביתי, המחליף כל אות במסר באות אחרת מתוך אלפבית שונה, קרי במפתח שונה.
        //השימוש במפתח נעשה באופן מחזורי. לאחר שימוש בכל האלפביתים חוזרים לאלפבית הראשון.
        //מיקומה של כל אות במסר המקורי קובע באיזה אלפבית מתוך קבוצת האלפבית של מפתח הצופן להצפינה.
        //בכל מפתח אלפבית סדר האותיות שונה, כך שכל אות זהה במסר תוצפן לאות אחרת בצופן,
        //על כן לא נשמרת תדירות האותיות שבמסר המקורי. בניגוד לצופן חד-אלפביתי המבצע הזזה או החלפה של כל אותיות המסר במרחק קבוע.

        //צופן פלייפייר (Playfair)
    }


}