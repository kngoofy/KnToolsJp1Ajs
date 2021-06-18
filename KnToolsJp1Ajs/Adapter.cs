using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs
{
    /// <summary>
    /// WinForms用アダプタクラス
    /// </summary>
    public class Adapter
    {
        /// <summary>
        /// WinFormsから呼び出し用のアダプタクラス AJSブック作成 ファイルから
        /// </summary>
        /// <param name="unitfile">ajsユニット定義ファイル名</param>
        public static void CreateFromFile(string unitfile, string bookFile)
        {
            //テンプレートであるブックを新規作成
            string templateBook = "NewTemplateJP1AJS.xlsx";
            CreateNewTemplateBook.NewExcelBook(templateBook);

            //ajsユニット定義ファイルを読み込んでstring型へ
            string strDef = ReadFile.ReadFileToString(unitfile);
            //ajsユニット定義ファイルをパース string型から
            var units = ParseJp1Def.ParseJp1DefFromString(strDef, out string ajsname);

            //ajsユニット定義ファイルを読み込んでList型へ
            List<string> lines = ReadFile.ReadFileToList(unitfile);

            //作成するブック名
            string CreatedBook = bookFile ?? $@"Jp1Ajs-{ajsname}.xlsx";
            //AJSブック作成実行
            UpdateBook.UpdateExcelBook(templateBook, units, lines, CreatedBook);

            return;
        }

        /// <summary>
        /// WinFormsから呼び出し用のアダプタクラス AJSブック作成 文字列から
        /// </summary>
        /// <param name="strDef">ユニット定義文字列</param>
        /// <param name="bookName">ajsユニット定義ファイル名</param>
        public static void CreateFromString(string strDef, string bookName)
        {
            //テンプレートであるブックを新規作成
            string templateBook = "NewTemplateJP1AJS.xlsx";
            CreateNewTemplateBook.NewExcelBook(templateBook);

            //ajsユニット定義ファイルをパース string型から
            var units = ParseJp1Def.ParseJp1DefFromString(strDef, out string ajsname);

            //List型へ
            List<string> lines = strDef.Split('\n').ToList();

            //作成するブック名
            string CreatedBook = bookName ?? $@"Jp1Ajs-{ajsname}.xlsx";
            //AJSブック作成実行
            UpdateBook.UpdateExcelBook(templateBook, units, lines, CreatedBook);

            return;
        }

    }
}
