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
            CreateNewTemplateBook.CreateBook(bookFile);

            //ユニット定義ファイルを読み込んでパース 
            var ajsdef = BuildJp1AjsDef.StreamBuildJp1AjsDefUnits(unitFile);
            
            UpdateBook.UpdateExcelBook(bookFile, ajsdef);
                        
            return;
        }

        /// <summary>
        /// WinFormsから呼び出し用のアダプタクラス AjsDefブック作成 文字列から
        /// </summary>
        /// <param name="strAjsDef">ユニット定義文字列</param>
        /// <param name="bookName">ajsユニット定義ファイル名</param>
        public static void CreateFromString(string strAjsDef, string bookFile)
        {
            //テンプレートであるブックを新規作成
            CreateNewTemplateBook.CreateBook(bookFile);

            //ユニット定義文字列を読み込んでパース 
            var ajsdef = BuildJp1AjsDef.StringBuildJp1AjsDefUnits(strAjsDef);

            UpdateBook.UpdateExcelBook(bookFile, ajsdef);

            return;
        }

    }
}
