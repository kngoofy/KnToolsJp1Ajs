using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KnToolsJp1Ajs
{
    public class ReadFile
    {
        /*public ReadFileJp1AjsDef()
        {
        }
        */

        //
        public static string ReadFileToString(string filePath)
        {
            var text = File.ReadAllText(filePath, Encoding.Default);
            //Console.WriteLine(text);
            
            return text;
        }
        //
        public static List<string> ReadFileToList(string filePath)
        {
            var lines = File.ReadAllLines(filePath, Encoding.Default);
            //Console.WriteLine(lines);
            
            return lines.ToList();
        }
    }
}
