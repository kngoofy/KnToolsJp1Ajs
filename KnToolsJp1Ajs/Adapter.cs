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
        /// WinFormsから呼び出し用のアダプタクラス AjsDefブック作成 ファイルから
        /// </summary>
        /// <param name="unitFile">ajsユニット定義ファイル名</param>
        public static void CreateFromFile(string unitFile, string bookFile)
        {
            //テンプレートであるブックを新規作成
            string templateBook = "TemplateJP1AJS.xlsx";
            CreateNewTemplateBook.CreateBook(templateBook);

            //ユニット定義ファイルを読み込んでstring型へ変換してからパース 
            //string strAjsDef = ReadFile.ReadFileToString(unitFile);
            //var units = ParseJp1Def.ParseAjsDefFromString(strAjsDef, out string ajsname);

            //ユニット定義ファイルを読み込んでList型へ
            //List<string> lines = ReadFile.ReadFileToList(unitFile);

            //作成するブック名
         //   string CreatedBook = bookFile ?? $@"Jp1Ajs-{ajsname}.xlsx";
            
            //AjsDefブック作成実行
            //UpdateBook.UpdateExcelBook(templateBook, units, lines, CreatedBook);

            return;
        }

        /// <summary>
        /// WinFormsから呼び出し用のアダプタクラス AjsDefブック作成 文字列から
        /// </summary>
        /// <param name="strAjsDef">ユニット定義文字列</param>
        /// <param name="bookName">ajsユニット定義ファイル名</param>
        public static void CreateFromString(string strAjsDef, string bookName)
        {
            //テンプレートであるブックを新規作成
            string templateBook = "TemplateJP1AJS.xlsx";
            CreateNewTemplateBook.CreateBook(templateBook);

            //ajsユニット定義ファイルをパース string型からパース
            //var units = ParseJp1Def.ParseAjsDefFromString(strAjsDef, out string ajsname);

            //string型のユニット定義をList型へ
            //List<string> lines = strAjsDef.Split('\n').ToList();

            //作成するブック名
            //string CreatedBook = bookName ?? $@"Jp1Ajs-{ajsname}.xlsx";
            
            //AjsDefブック作成実行
            //UpdateBook.UpdateExcelBook(templateBook, units, lines, CreatedBook);

            return;
        }

    }
}
