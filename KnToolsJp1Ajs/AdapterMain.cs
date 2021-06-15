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
    public class AdapterMain
    {

        /// <summary>
        /// WinFormsから呼び出し用のアダプタクラス AJSブック作成
        /// </summary>
        /// <param name="filePath">ajsユニット定義ファイル名</param>
        public static void MakeJp1DefBookAdapter(string filePath,string fileName)
        {

            //テンプレートブック名
            string templateBook = "NewTemplateJP1AJS.xlsx";
            //テンプレートであるブックを新規作成
            //var makeSheet = new CreateNewTemplateBook(templateBook);
            CreateNewTemplateBook.NewExcelBook(templateBook);

            //ajsユニット定義ファイルを読み込んでstring型へ
            string strDef = ReadFile.ReadFileToString(filePath);
            //ajsユニット定義ファイルをパース string型から
            var units = ParseJp1Def.ParseJp1DefFromString(strDef, out string ajsname);

            //ajsユニット定義ファイルを読み込んでList型へ
            List<string> lines = ReadFile.ReadFileToList(filePath);

            //作成するブック名
            string CreatedBook = fileName ?? $@"Jp1Ajs-{ajsname}.xlsx";
            //AJSブック作成実行
            UpdateBook.UpdateExcelBook(templateBook, units, lines, CreatedBook);

            return;
        }

    }
}
