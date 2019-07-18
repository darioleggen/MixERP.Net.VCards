using System;   
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MixERP.Net.VCards.Helpers
{
    public static class VCardHelper
    {
        public static int CheckOccurrences(string str1, string pattern)
        {
            int count = 0;
            int a = 0;

            while ((a = str1.IndexOf(pattern, a)) != -1)
            {
                a += pattern.Length;
                count++;
            }
            return count;
        }
        public static string[] SplitCards(string contents)
        {
            string buffer = contents;
            List<string> cards=new List<string>();
            string card = "";
            string tagstart = "BEGIN:VCARD";
            string tagend = "END:VCARD";
            int n = 0;
            int i = 0;


            n = CheckOccurrences(buffer, tagend);

            for (i = 0; i < n; i++) { 
                
                card = buffer.Substring(buffer.IndexOf(tagstart), buffer.IndexOf(tagend) + tagend.Length);
                cards.Add(card);
                buffer= buffer.Substring(card.Length,buffer.Length-card.Length);
            }
    

            return cards.ToArray();

            //return Regex.Split(contents, "((BEGIN:VCARD)(.+?)(END:VCARD))");

            
        }
    }

    
}