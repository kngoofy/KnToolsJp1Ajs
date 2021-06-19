using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unclazz.Jp1ajs2.Unitdef;
using Unclazz.Jp1ajs2.Unitdef.Parser;

namespace KnToolsJp1Ajs
{
    class Program
    {
        /// <summary>
        /// コンソールアプリ用のエントリポイント
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //テンプレートであるブックを新規作成
            string templateBook = "TemplateJP1AJS.xlsx";
            TemplateBook.CreateBook(templateBook);

            return;

            //
            var file = @"E:\02.Kazu-Development\01.VisualStudio\KnToolsJp1Ajs\KnToolsJp1Ajs\Data\jp1def-test02.txt";

            //ajsユニット定義ファイルを読み込んでstring型へ
            string strDef = ReadFile.ReadFileToString(file);
            //ajsユニット定義ファイルをパース string型から
            var units = ParseJp1Def.ParseJp1DefFromString(strDef, out string ajsname);

            //ajsユニット定義ファイルを読み込んでList型へ
            List<string> lines = ReadFile.ReadFileToList(file);

            //作成するブック名
            string CreatedBook = $@"Jp1Ajs-{ajsname}.xlsx";
            //AJSブック作成実行
            UpdateBook.UpdateExcelBook(templateBook, units, lines, CreatedBook);

            return;

        }

    }
}
