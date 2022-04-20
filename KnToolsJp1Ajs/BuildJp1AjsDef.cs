using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs
{
    /// <summary>
    /// JP1/AJS定義を扱い組み立てるクラス
    /// </summary>
    public static class BuildJp1AjsDef
    {
        public static Jp1AjsDef.AjsDef StreamBuildJp1AjsDefUnits(string filename)
        {
            string htmlText = File.ReadAllText(filename);
            return StringBuildJp1AjsDefUnits(htmlText);
        }
        
        public static Jp1AjsDef.AjsDef StringBuildJp1AjsDefUnits(string text)
        {

            
            var units = ParseJp1Def.ParseAjsDefFromString(text, out string ajsname);

            return units;
        }

        public static List<string> StreamBuildJp1AjsDef(string fileName)
        {
            return ReadFile.ReadFileToList(fileName);
        }

        public static List<string> StringBuildJp1AjsDef(string str)
        {
            return str.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None).ToList();
        }


    }

}
