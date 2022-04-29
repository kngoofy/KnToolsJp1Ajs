using KnToolsJp1Ajs.Jp1AjsDef;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs
{
    /// <summary>
    /// テンプレートブックにデータを配置して、Jp1Ajsブックを作成する。
    /// </summary>
    public class UpdateBook
    {
        //public static bool UpdateExcelBook(string templateFile, List<Unit> lists, List<string> lines, string outputFile)

        /// <summary>
        /// Bookの中身をデータ更新
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="ajsDef"></param>
        /// <returns></returns>
        public static bool UpdateExcelBook(string outputFile, Jp1AjsDef.AjsDef ajsDef)
        {
            List<Unit> lists = ajsDef.Units;
            List<string> lines = ajsDef.AjsDefLists;

            try
            {
                var book = WorkbookFactory.Create(outputFile);

                //Bookのスタイル作成
                Dictionary<string, ICellStyle> styles = BookStyles.CreateBookStyles(book);

                UpdateSheetUnit(book, lists, styles);
                UpdateSheetFile(book, lists, styles);
                UpdateSheetNext(book, lists, styles);
                UpdateSheetAjsprint(book, lines, styles);

                // UpdateしたExcelファイルを閉じる
                using (var fs = new FileStream(outputFile, FileMode.Create))
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
        /// Unitシートのコンテンツ組み立て
        /// </summary>
        /// <param name="book">ブック</param>
        /// <param name="lists">ユニット</param>
        /// <param name="styles">Cellスタイル定義</param>
        /// <returns></returns>
        public static bool UpdateSheetUnit(IWorkbook book, List<Unit> lists, Dictionary<string, ICellStyle> styles)
        {
            var sheet = book.GetSheet(ConstJP1AJS.SHEETNAME_UNIT);

            // データヘッダーブロックの書き出し
            (int y, int x) = (3, 1);

            //
            //List<string> list;
            for (int z = 0; z < lists.Count; z++)
            {
                var list = lists[z].GetListValues();
                list.Insert(0, (z + 1).ToString());
                for (int u = 0; u < list.Count; u++)
                {
                    WriteCell(sheet, styles["Box"], (y + z, x + u), list[u]);
                }
            }

            //カラムのAutoSize
            for (int i = 0; i < lists[0].GetListValues().Count + 1; i++)
            {
                sheet.AutoSizeColumn(x + i, true);
            }

            return true;
        }

        /// <summary>
        /// Fileシートのコンテンツ組み立て
        /// </summary>
        /// <param name="book">ブック</param>
        /// <param name="lists">ユニット</param>
        /// <param name="styles">Cellスタイル定義</param>
        /// <returns></returns>
        public static bool UpdateSheetFile(IWorkbook book, List<Unit> lists, Dictionary<string, ICellStyle> styles)
        {
            var sheet = book.GetSheet(ConstJP1AJS.SHEETNAME_FILE);

            //flwjに絞りってList作成
            var flwjs = lists.Where(f => f.Ty == "flwj").ToList();

            // データヘッダーブロックの書き出し
            (int y, int x) = (3, 1);

            for (int z = 0; z < flwjs.Count; z++)
            {
                WriteCell(sheet, styles["Box"], (y + z, x), (z + 1).ToString());
                WriteCell(sheet, styles["leftBox"], (y + z, x + 1), flwjs[z].UnitName);
                WriteCell(sheet, styles["leftBox"], (y + z, x + 2), flwjs[z].Flwf);
                WriteCell(sheet, styles["leftBox"], (y + z, x + 3), flwjs[z].SuperUnitName);
            }

            //カラムのAutoSize
            sheet.AutoSizeColumn(x, true);
            sheet.AutoSizeColumn(x + 1, true);
            sheet.AutoSizeColumn(x + 2, true);
            sheet.AutoSizeColumn(x + 3, true);

            return true;
        }

        /// <summary>
        /// Nextシートのコンテンツ組み立て
        /// </summary>
        /// <param name="book">ブック</param>
        /// <param name="lists">ユニット</param>
        /// <param name="styles">Cellスタイル定義</param>
        /// <returns></returns>
        public static bool UpdateSheetNext(IWorkbook book, List<Unit> lists, Dictionary<string, ICellStyle> styles)
        {
            var sheet = book.GetSheet(ConstJP1AJS.SHEETNAME_NEXT);


            // データヘッダーブロックの書き出し
            (int y, int x) = (3, 1);

            //arがあるものに絞り
            var ars = lists.Where(a => a.ArList.Count > 0);

            int z = 0;
            foreach (var arlist in ars)
            {
                for (int i = 0; i < arlist.ArList.Count; i++, z++)
                {
                    WriteCell(sheet, styles["Box"], (y + z, x), (z + 1).ToString());
                    WriteCell(sheet, styles["leftBox"], (y + z, x + 1), arlist.ArList[i].Item1);
                    WriteCell(sheet, styles["leftBox"], (y + z, x + 2), arlist.ArList[i].Item2);
                    WriteCell(sheet, styles["leftBox"], (y + z, x + 3), "/" + arlist.UnitName);
                }
            }

            //カラムのAutoSize
            sheet.AutoSizeColumn(x, true);
            sheet.AutoSizeColumn(x + 1, true);
            sheet.AutoSizeColumn(x + 2, true);
            sheet.AutoSizeColumn(x + 3, true);

            return true;
        }

        /// <summary>
        /// Ajsprintシートのコンテンツ組み立て
        /// </summary>
        /// <param name="book">ブック</param>
        /// <param name="lines">ユニット定義</param>
        /// <param name="styles">Cellスタイル定義</param>
        /// <returns></returns>
        public static bool UpdateSheetAjsprint(IWorkbook book, List<string> lines, Dictionary<string, ICellStyle> styles)
        {
            var sheet = book.GetSheet(ConstJP1AJS.SHEETNAME_AJSPRINT);

            // データヘッダーブロックの書き出し
            (int y, int x) = (3, 1);

            //List<string> list;
            for (int z = 0; z < lines.Count; z++)
            {
                WriteCell(sheet, styles["Box"], (y + z, x), (z + 1).ToString());
                WriteCell(sheet, styles["leftBox"], (y + z, x + 1), lines[z]);
            }

            //カラムのAutoSize
            sheet.AutoSizeColumn(x, true);
            sheet.AutoSizeColumn(x + 1, true);

            return true;
        }

        /// <summary>
        /// セルにデータをセット
        /// </summary>
        /// <param name="sheet">シート</param>
        /// <param name="style">セルスタイル</param>
        /// <param name="s">セル位置</param>
        /// <param name="value">セットするデータ値</param>
        public static void WriteCell(ISheet sheet, ICellStyle style, (int y, int x) s, string value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            
            cell.CellStyle = style;

            //セルが数値の場合の対応
            bool result;
            result = int.TryParse(value, out int intvalue);
            if (result)
            {
                cell.SetCellType(CellType.Numeric);
                cell.SetCellValue(intvalue);
            }
            else
            {
                cell.SetCellType(CellType.String);
                cell.SetCellValue(value);
            }

        }

        /// <summary>
        /// セルにデータをセット リンク付き
        /// </summary>
        /// <param name="sheet">シート</param>
        /// <param name="style">セルスタイル</param>
        /// <param name="s">セル位置</param>
        /// <param name="value">セットする値</param>
        /// <param name="link">シートのリンク</param>
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
