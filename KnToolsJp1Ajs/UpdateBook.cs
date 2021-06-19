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
    class UpdateBook
    {
        public static bool UpdateExcelBook(string templateFile, List<Unit> lists, List<string> lines, string outputFile)
        {
            try
            {
                var book = WorkbookFactory.Create(templateFile);

                //Bookのスタイル作成
                Dictionary<String, ICellStyle> styles = BookStyles.CreateBookStyles(book);

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
        public static bool UpdateSheetUnit(IWorkbook book, List<Unit> lists, Dictionary<String, ICellStyle> styles)
        {

            var sheet = book.GetSheet(ConstJP1AJS.SHEETNAME_UNIT);

            // データヘッダーブロックの書き出し
            (int y, int x) p = (3, 1);
            //lists.Insert(0, "#");
            List<string> list;
            for (int y = 0; y < lists.Count; y++)
            {
                list = lists[y].getListValues();
                list.Insert(0, (y + 1).ToString());
                for (int x = 0; x < list.Count; x++)
                {
                    WriteCell(sheet, styles["leftBox"], (p.y + y, p.x + x), list[x]);
                    //sheet.AutoSizeColumn(p.x + x, true);
                }
            }

            for (int i = 0; i < lists[0].getListValues().Count +1; i++)
            {
                sheet.AutoSizeColumn(i, true);
            }

            return true;

        }
        public static bool UpdateSheetFile(IWorkbook book, List<Unit> lists, Dictionary<String, ICellStyle> styles)
        {
            var sheet = book.GetSheet(ConstJP1AJS.SHEETNAME_FILE);

            var file = lists.Where(x => x.Ty == "flwj").ToList();

            // データヘッダーブロックの書き出し
            (int y, int x) p = (3, 1);
            //Unit unit;
            for (int y = 0; y < file.Count; y++)
            {
                WriteCell(sheet, styles["leftBox"], (p.y + y, p.x), (y + 1).ToString());
                WriteCell(sheet, styles["leftBox"], (p.y + y, p.x + 1), file[y].UnitName);
                WriteCell(sheet, styles["leftBox"], (p.y + y, p.x + 2), file[y].Flwf);
                WriteCell(sheet, styles["leftBox"], (p.y + y, p.x + 3), file[y].SuperUnitName);
            }
            sheet.AutoSizeColumn(p.x, true);
            sheet.AutoSizeColumn(p.x + 1, true);
            sheet.AutoSizeColumn(p.x + 2, true);
            sheet.AutoSizeColumn(p.x + 3, true);

            return true;

        }

        public static bool UpdateSheetNext(IWorkbook book, List<Unit> lists, Dictionary<String, ICellStyle> styles)
        {
            var sheet = book.GetSheet(ConstJP1AJS.SHEETNAME_NEXT);

            //var arlists = lists.Where(x => x.ArList.Count >= 0);

            // データヘッダーブロックの書き出し
            (int y, int x) p = (3, 1);

            int y = 0;
            foreach (var arlist in lists)
            {
                for (int i = 0; i < arlist.ArList.Count; i++, y++)
                {
                    WriteCell(sheet, styles["leftBox"], (p.y + y, p.x), (y + 1).ToString());
                    WriteCell(sheet, styles["leftBox"], (p.y + y, p.x + 1), arlist.ArList[i].Item1);
                    WriteCell(sheet, styles["leftBox"], (p.y + y, p.x + 2), arlist.ArList[i].Item2);
                    WriteCell(sheet, styles["leftBox"], (p.y + y, p.x + 3), "/" + arlist.UnitName);
                }
            }

            sheet.AutoSizeColumn(p.x, true);
            sheet.AutoSizeColumn(p.x + 1, true);
            sheet.AutoSizeColumn(p.x + 2, true);
            sheet.AutoSizeColumn(p.x + 3, true);

            return true;

        }
        public static bool UpdateSheetAjsprint(IWorkbook book, List<string> lines, Dictionary<String, ICellStyle> styles)
        {
            var sheet = book.GetSheet(ConstJP1AJS.SHEETNAME_AJSPRINT);

            // データヘッダーブロックの書き出し
            (int y, int x) p = (3, 1);

            //List<string> list;
            for (int y = 0; y < lines.Count; y++)
            {
                WriteCell(sheet, styles["leftBox"], (p.y + y, p.x), (y + 1).ToString());
                WriteCell(sheet, styles["leftBox"], (p.y + y, p.x + 1), lines[y]);
            }
            sheet.AutoSizeColumn(p.x, true);
            sheet.AutoSizeColumn(p.x + 1, true);

            return true;

        }

        public static void WriteCell(ISheet sheet, ICellStyle style, (int y, int x) s, string value)
        {
            var row = sheet.GetRow(s.y) ?? sheet.CreateRow(s.y);
            var cell = row.GetCell(s.x) ?? row.CreateCell(s.x);
            cell.SetCellValue(value);
            cell.CellStyle = style;
        }

        //
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
