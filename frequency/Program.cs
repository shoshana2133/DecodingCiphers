﻿using System;

namespace frequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            string text1;
            //Console.WriteLine( Translate.freq("שלום לכולם", 'ל'));
            //Translate.ExelLetters();
            // Console.WriteLine(text);
            //Translate.deciphering("אאבגדהההדשגכעגכ");
            //Translate.deciphering("תטפ  סממי  שזמקט  שפ  קשגמי  יבאטמי  ככת  צגו,  בפד  צזשפקצ  יבאטצ,  אגשפאטפ  צהגלטמא  יבאטצ  פתומכפ  צגרכמ  צאעפטצ  בכטפ  יבאטמי  ככת  כתפא.  במטפממי  תכפ  פתסגמי  יאגסבמי  כת  וזי  צפקפא  כנלטפכפרמצ,  ביאואסא  שהזקמ  זטד  פכזמאמי  תו  יבתמגצ  תפאטפ  יזנ  יתספג.  ילכ  צאספימי  צט\"כ  ,אספי  צהגלטפא  צפת  צאספי  שפ  טמאט  כגתפא  תא  צבמטפמ  צקגחנמ  שמפאג.  דטמפא  שתמטנגטנ  צולפ  כקפימטטנמפא  יתפק  פצוזי  גד  תטסטפ  יגפפמסמי  יעצ. אגשפא  צהגמלצ  שזשג לבגהמטפ  כדטפא  יבצפ  שזשג,  כוטמ  בכלפכטפ  צמאצ  סשגפא  שטצרטפ  כצרמז  כסטפמפא  צגכפפטנמפא  פכבפפדמי  צבפטמי  פשפסגמי  ייקומ  צסטפא  תא  לכ  יצ  בצממטפ  הגמלמי,  תומכפ  יגלעמ  דטמפא  פדטמפטמי  צמצ  תע  שזשפגטפ  גזמפט  סקבטמ. יצג  יתפק  צולפ  חפוגיגדנמי  פדטמפטמי  כע'תטג  יפשמכ  שאגשפא  צהגמלצ,  שידפי  כצחאפשש  שגספשפא  צזגמי,  טלטחפ  כדטמפט  צייפער,  בי  מלפכטפ  כיהפת  לכ  יצ  בסוץ  שפ  כמשטפ,  לתבג  ציזשג  שמט  אגשפא  הגלטמא  ציאשחחא  זכ  בפפדמי  כסטפמפא  דנטפא  כהגלטפא  בלכ  לפכצ  יפטסמא  זכ  מקמ  דטמפטמי  פיגלעמ  דטמפא  זטדממי  צאגסבצ  שכת  מפאג  יזבפג.  זפכי  צתמטנגטנ  צפפמגנפתכמ,  בצמפפצ  הזק  טפחו  שתשפכפהמצ  צנלטפכפרמא,  טלטח  שיצמגפא  במת  כסממטפ  פלזא  דטמפא  שתמטנגטנ  צולפ  כבמת  אגשפא  צדטמפא  צסקבצ. דטמפא  שתמטנגטנ הגלטפא  פמגנפתכמא  ככת  לכ  חוד  במקגרצ  תא  ספפמא  צדטמפא  בכ  לכ  תסק  פתסא  יתמאטפ.  שידפי  כצאגפהץ  שמט  סטפא  כסטפא  תפ  כסכפומט  כצרמז  כדטמפט,  תטפ  מפבשמי  יפכ  ציסבש  זי  חוכ  דוצ  פזפגלמי  דטמפא  שתמטנגטנ  כתסג  חדג  בפד  טגסש  פצבפפתא  יסמגמי  יאדקיא  ככת  לכ  יתיץ.  סבשפטפא  צשטד  בכטפ  יטפצכמי  שתמטנגטנ,  דטמפא  יעפט  בשפזמפא  כשמא  תטפ  זפבמי  שתמטנגטנ,  יבכימי  סבשפטפא  שתמטנגטנ  פתו  יטצכמי  סכד  כת  ישפנכ  יסממטפ  צסשגאממי  שזפכי  צפפמגנפתכמ. כיצ  כת  שזהי גשמי  יפסמי  טרק  ציבדכ  צלשק  בכפדס  צתמטנגטנ  שסממטפ.  גשמי  ופסקמי  בתטפ  טתשק  תא  זהיטפ  כנפשא  צזפכי  צפפמגנפתכמ  פתפכמ  תו  טבלס  למהק  כסמפא  שזפכי  צתימאמ  ברגא  צמפימפי  שזא  ציפקגטמא  צמטצ  גפפמא  חנגח  פכסהמי,  תטפ  יפהתמי  תא  זהיטפ  לכ  מפי  שיכסיצ  טרק  צבזפט  כצחומד  תא  לכ  צינכפא  צטקגבפא  יתמאטפ,  דגממגצ,  חמקפגמי  פנמופכ  צמכקמי.  תי  דטמפא  שתמטנגטנ  מלפכפא  רי  כחממז  כטפ  כסחפל  שעיט  פרי  כסחפל  כטפ  לחו  גש,  תע  כיצ  כת  שזהי צתמטנגטנ  ללכמ  זעג  מזמכ תסא  צאגפיפא  ציפשצדפא  בכ  צתמטנגטנ  כגשפא  דטמפא  שתמטנגטנ,  צמת  טרמבפא  כלכ  ידפי  פשלכ  עיט.  תטפ  מלפכמי  שעיט  תיא  כסוב  יפהג  כיהפת  תפאפ  שזבג  ידפיפא  בפטמי,  ביאיסגמי  תפאפ  תסגא  פלהגלטמ  תמטנגטנ  תטפ  מלפכמי  כצסכמנ  צמלט  תטפ  גפהמי  כגלפב  תא  ציפהג  זכ  ומ  טאפטמי  ליפ  עיט  יבכפס,  יסמג,  אטתמ  אבכפי פזכ  יחל  צשמדפגפא  בדמשכצ  צסטפא  צחוהמומא. תטפ  מלפכמי  שלכ  גרז  טאפט  כצמלטח  כשטד  פכגתפא  למהק  יאטצכ  סבשפט  צזפשג  פבש  תפ  כסכפומט  כצמלטח  כקו  צומגפנ  בכ  לגנמח  צתבגתמ  פכצסכמנ  תמעצ  רפשצ  בכ  סמפש  תטפ  גפהמי  במגק  כטפ  יסבשפט  שזפב  צספקב.  דטמפא  שתמטנגטנ  צי  תסק  צקשגמי  צנפשמי  בדגפ  כאגשפא  צהגמלצ  שתגץ.  טדפקצ  כיסבשצ."); 
            //text=Ciphers.Decipher("תסק  צקשגמי  צנפשמי");
            //text = Ciphers.EncryptCaesar("שלומ לכולמ", 11);
            //text = Ciphers.DecipherCaesar(text, 11);
            // Ciphers.CaesarCipher(text);
            //text = Ciphers.MergeLetters("איזהטובהתודהלכ");
            //text1 = Ciphers.DecodeString(text);
            // text = Ciphers.ColumnarTranspositionEncrypt("שלומעליכממלאכיהשלוממלאכיעליונמלכמלכיהמלכימהקדושברוכהוא",4);
            // text1= Ciphers.ColumnTranspositionDecoding(text,4);
            text = CutWords.DivisionIntoProfits("הלכתיהיומלקנותנעליים");
            Console.ReadLine();
            
        }
    }
}
