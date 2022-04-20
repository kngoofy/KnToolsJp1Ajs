using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.IO;
using KnToolsJp1Ajs.Jp1AjsDef;

namespace KnToolsJp1Ajs
{
    /// <summary>
    /// Jp1Ajs定義ブックのテンプレート作成
    /// </summary>
    public class CreateNewTemplateBook
    {
        /// <summary>
        /// Jp1AjsBookテンプレートの作成
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns>bool</returns>
        public static bool CreateBook(string bookName)
        {
            try
            {
                //JP1/AJS定義のBookのテンプレートを新規作成
                IWorkbook book = new XSSFWorkbook();

                //Bookのスタイル作成
                var styles = BookStyles.CreateBookStyles(book);

                //定型シートを作成挿入
                var sheetIndex = book.CreateSheet(ConstJP1AJS.SHEETNAME_INDEX);
                var sheetUnit = book.CreateSheet(ConstJP1AJS.SHEETNAME_UNIT);
                var sheetFile = book.CreateSheet(ConstJP1AJS.SHEETNAME_FILE);
                var sheetNext = book.CreateSheet(ConstJP1AJS.SHEETNAME_NEXT);
                var sheetAjsprint = book.CreateSheet(ConstJP1AJS.SHEETNAME_AJSPRINT);

                //定型シートの中身を整える
                MakeSheetIndex(sheetIndex, styles);
                MakeSheetUnit(sheetUnit, styles);
                MakeSheetFile(sheetFile, styles);
                MakeSheetNext(sheetNext, styles);
                MakeSheetAjsprint(sheetAjsprint, styles);

                //    //テンプレートBookを書き出す
                using (var fs = new FileStream(bookName, FileMode.Create))
                {
                    book.Write(fs);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return true;
        }

        /// <summary>
        /// Indexシートの作成
        /// </summary>
        /// <param name="sheet">Indexシート</param>
        /// <param name="styles">Cellスタイル定義</param>
        /// <returns></returns>
        private static bool MakeSheetIndex(ISheet sheet, Dictionary<String, ICellStyle> styles)
        {
            //メモリ線(枠線)を非表示
            sheet.DisplayGridlines = false;

            //TopLeft シートタイトル埋め込み
            WriteCell(sheet, styles["topleft"], (0, 0), "Index");

            //Index シート一覧埋め込み Listに組み立て
            var titles = new List<(int no, string name)> //※タプルです。
            {
                 (1 ,ConstJP1AJS.SHEETNAME_UNIT)
               , (2 ,ConstJP1AJS.SHEETNAME_FILE)
               , (3 ,ConstJP1AJS.SHEETNAME_NEXT)
               , (4 ,ConstJP1AJS.SHEETNAME_AJSPRINT)
            };

            //エクセルの行と列 のポイント指定 タプルです。
            (int y, int x) = (1, 1);
            //Indexパネルの配置
            foreach (var (no, name) in titles)
            {
                WriteCell(sheet, styles["indexBoxNo"], (y + no, x), no.ToString());
                var link = new XSSFHyperlink(HyperlinkType.Document)
                {
                    Address = name + "!A1"
                };
                WriteCell(sheet, styles["indexBoxTitle"], (y + no, x + 1), name, link);
            }

            //カラムのAutoSize
            for (int i = 0; i < 3; i++)
            {
                sheet.AutoSizeColumn(i, true);
            }

            return true;
        }

        /// <summary>
        /// Unitシートの作成
        /// </summary>
        /// <param name="sheet">Unitシート</param>
        /// <param name="styles">Cellスタイル定義</param>
        /// <returns></returns>
        private static bool MakeSheetUnit(ISheet sheet, Dictionary<String, ICellStyle> styles)
        {
            //メモリ線(枠線)を非表示
            sheet.DisplayGridlines = false;
            //TopLeft シートタイトル埋め込み
            WriteCell(sheet, styles["topleft"], (0, 0), "Unit");

            //ヘッダーの組み立て
            var unit = new Unit("Header");
            var list = unit.GetListValues();

            // データヘッダーブロックの書き出し
            (int y, int x) = (2, 1);
            list.Insert(0, "#");
            for (int z = 0; z < list.Count; z++)
            {
                WriteCell(sheet, styles["indexBoxTitle"], (y, x + z), list[z]);
                WriteCell(sheet, styles["BlankCell"], (y + 1, x + z), " ");
                //sheet.AutoSizeColumn(x + z, true);
            }

            //Filter設定とカラムのAutoSize
            var region = new CellRangeAddress(y, y, x, (x + list.Count - 1));
            sheet.SetAutoFilter(region);
            for (int i = 0; i < list.Count; i++)
            {
                sheet.AutoSizeColumn(i, true);
            }

            return true;
        }

        /// <summary>
        /// Fileシートの作成
        /// </summary>
        /// <param name="sheet">Fileシート</param>
        /// <param name="styles">Cellスタイル定義</param>
        /// <returns></returns>
        private static bool MakeSheetFile(ISheet sheet, Dictionary<String, ICellStyle> styles)
        {
            //メモリ線(枠線)を非表示
            sheet.DisplayGridlines = false;
            //TopLeft シートタイトル埋め込み
            WriteCell(sheet, styles["topleft"], (0, 0), "File");

            //エクセルの行と列 のポイント指定 タプルです。
            (int y, int x) = (2, 1);
            WriteCell(sheet, styles["indexBoxTitle"], (y, x), "#");
            WriteCell(sheet, styles["indexBoxTitle"], (y, x + 1), "FLCKジョブ");
            WriteCell(sheet, styles["indexBoxTitle"], (y, x + 2), "ファイル名");
            WriteCell(sheet, styles["indexBoxTitle"], (y, x + 3), "親ユニット");

            WriteCell(sheet, styles["BlankCell"], (y + 1, x), " ");
            WriteCell(sheet, styles["BlankCell"], (y + 1, x + 1), " ");
            WriteCell(sheet, styles["BlankCell"], (y + 1, x + 2), " ");
            WriteCell(sheet, styles["BlankCell"], (y + 1, x + 3), " ");

            //Filter設定とカラムのAutoSize
            var region = new CellRangeAddress(y, y, x, (x + 3));
            sheet.SetAutoFilter(region);
            for (int i = 0; i < 5; i++)
            {
                sheet.AutoSizeColumn(i, true);
            }

            return true;
        }

        /// <summary>
        /// Nextシートの作成
        /// </summary>
        /// <param name="sheet">Nextシート</param>
        /// <param name="styles">Cellスタイル定義</param>
        /// <returns></returns>
        private static bool MakeSheetNext(ISheet sheet, Dictionary<String, ICellStyle> styles)
        {
            //メモリ線(枠線)を非表示
            sheet.DisplayGridlines = false;
            //TopLeft シートタイトル埋め込み
            WriteCell(sheet, styles["topleft"], (0, 0), "next");

            //エクセルの行と列 のポイント指定 タプルです。
            (int y, int x) = (2, 1);
            WriteCell(sheet, styles["indexBoxTitle"], (y, x), "#");
            WriteCell(sheet, styles["indexBoxTitle"], (y, x + 1), "前提");
            WriteCell(sheet, styles["indexBoxTitle"], (y, x + 2), "後続");
            WriteCell(sheet, styles["indexBoxTitle"], (y, x + 3), "ユニット");

            WriteCell(sheet, styles["BlankCell"], (y + 1, x), " ");
            WriteCell(sheet, styles["BlankCell"], (y + 1, x + 1), " ");
            WriteCell(sheet, styles["BlankCell"], (y + 1, x + 2), " ");
            WriteCell(sheet, styles["BlankCell"], (y + 1, x + 3), " ");

            //Filter設定とカラムのAutoSize
            var region = new CellRangeAddress(y, y, x, (x + 3));
            sheet.SetAutoFilter(region);
            for (int i = 0; i < 6; i++)
            {
                sheet.AutoSizeColumn(i, true);
            }

            return true;
        }

        /// <summary>
        /// Ajsprintシートの作成
        /// </summary>
        /// <param name="sheet">Ajsprintシート</param>
        /// <param name="styles">Cellスタイル定義</param>
        /// <returns></returns>
        private static bool MakeSheetAjsprint(ISheet sheet, Dictionary<String, ICellStyle> styles)
        {
            //メモリ線(枠線)を非表示
            sheet.DisplayGridlines = false;
            //TopLeft シートタイトル埋め込み
            WriteCell(sheet, styles["topleft"], (0, 0), "ajsprint");

            //エクセルの行と列 のポイント指定 タプルです。
            (int y, int x) = (2, 1);
            WriteCell(sheet, styles["indexBoxTitle"], (y, x), "#");
            WriteCell(sheet, styles["BlankCell"], (y + 1, x), " ");
            WriteCell(sheet, styles["indexBoxTitle"], (y, x + 1), "ajsprint define");
            WriteCell(sheet, styles["BlankCell"], (y + 1, x + 1), " ");

            //カラムのAutoSize
            for (int i = 0; i < 3; i++)
            {
                sheet.AutoSizeColumn(i, true);
            }

            return true;
        }

        /// <summary>
        /// Cellの設定
        /// </summary>
        /// <param name="sheet">Cell設定のシート</param>
        /// <param name="style">Cellスタイル定義</param>
        /// <param name="s">Cellの位置</param>
        /// <param name="value">Cellの値</param>
        public static void WriteCell(ISheet sheet, ICellStyle style, (int y, int x) s, string value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.SetCellValue(value);
            cell.CellStyle = style;
        }

        /// <summary>
        /// Cellの設定
        /// </summary>
        /// <param name="sheet">Cell設定のシート</param>
        /// <param name="style">Cellスタイル定義</param>
        /// <param name="s">Cellの位置</param>
        /// <param name="value">Cellの値</param>
        /// <param name="link">Cellのリンク先</param>
        public static void WriteCell(ISheet sheet, ICellStyle style, (int y, int x) s, string value, IHyperlink link)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.Hyperlink = link;
            cell.SetCellValue(value);
            cell.CellStyle = style;
        }

    }
}
