using System;
using System.Collections.Generic;
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
        //קיסר
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
                numRows++;
            }

            // Create empty matrix for encryption 
            char[,] matrix = new char[numRows, key];

            // Fill the matrix with plaintext 
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
            string ciphertext="";
            
            for (int k = 0; k < key; k++)
            {
                for (i = 0; i < numRows; i++)
                {
                    ciphertext += matrix[i, k];
                }
            }

            return ciphertext;

        }
    }
}