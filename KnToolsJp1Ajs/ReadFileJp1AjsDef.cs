using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KnToolsJp1Ajs
{
    /// <summary>
    /// ユニット定義ファイルを読み込んでstring型 or List型に組み立てる
    /// </summary>
    public class ReadFile
    {
        
        /// <summary>
        /// ユニット定義ファイルを読み込みString型に格納
        /// </summary>
        /// <param name="filePath">ユニット定義ファイル</param>
        /// <returns></returns>
        public static string ReadFileToString(string filePath)
        {
            var text = File.ReadAllText(filePath, Encoding.Default);
            //Console.WriteLine(text);
            
            return text;
        }

        /// <summary>
        /// ユニット定義ファイルを読み込みList型に格納
        /// </summary>
        /// <param name="filePath">ユニット定義ファイル</param>
        /// <returns></returns>
        public static List<string> ReadFileToList(string filePath)
        {
            var lines = File.ReadAllLines(filePath, Encoding.Default);
            //Console.WriteLine(lines);
            
            return lines.ToList();
        }
    }
}
