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
    /// JP1AJS定義ブックのテンプレート作成
    /// </summary>
    class CreateNewTemplateBook
    {
        //コンストラクタ
        public CreateNewTemplateBook()
        {
        }

        public static bool NewExcelBook(string bookName)
        {
            //JP1/AJS定義のBookのテンプレートを新規作成
            IWorkbook book = new XSSFWorkbook();

            //Bookのスタイル作成
            var styles = CreateBookStyles.createBookStyles(book);

            //定型シートを作成挿入
            var sheetIndex = book.CreateSheet(ConstJP1AJS.SHEETNAME_INDEX);
            var sheetUnit = book.CreateSheet(ConstJP1AJS.SHEETNAME_UNIT);
            var sheetFile = book.CreateSheet(ConstJP1AJS.SHEETNAME_FILE);
            var sheetNext = book.CreateSheet(ConstJP1AJS.SHEETNAME_NEXT);
            var sheetAjsprint = book.CreateSheet(ConstJP1AJS.SHEETNAME_AJSPRINT);

            //定型シートの中身を整える
            FormatSheetIndex(book, sheetIndex, styles);
            FormatSheetUnit(book, sheetUnit, styles);
            FormatSheetFile(book, sheetFile, styles);
            FormatSheetNext(book, sheetNext, styles);
            FormatSheetAjsprint(book, sheetAjsprint, styles);

            try
            {
                //テンプレートBookを書き出す
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

        private static bool FormatSheetIndex(IWorkbook book, ISheet sheet, Dictionary<String, ICellStyle> styles)
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
            (int y, int x) p = (1, 1);
            //
            foreach (var t in titles)
            {
                WriteCell(sheet, styles["indexBoxNo"], (p.y + t.no, p.x), t.no.ToString());
                var link = new XSSFHyperlink(HyperlinkType.Document);
                link.Address = t.name + "!A1";
                WriteCell(sheet, styles["indexBoxTitle"], (p.y + t.no, p.x + 1), t.name, link);
            }

            for (int i = 0; i < 3; i++)
            {
                sheet.AutoSizeColumn(i, true);
            }
            return true;
        }
        private static bool FormatSheetUnit(IWorkbook book, ISheet sheet, Dictionary<String, ICellStyle> styles)
        {
            //メモリ線(枠線)を非表示
            sheet.DisplayGridlines = false;
            //TopLeft シートタイトル埋め込み
            WriteCell(sheet, styles["topleft"], (0, 0), "Unit");

            //ヘッダーの組み立て
            var unit = new Unit("Header");
            var list = unit.getListValues();

            // データヘッダーブロックの書き出し
            (int y, int x) p = (2, 1);
            list.Insert(0, "#");
            for (int x = 0; x < list.Count; x++)
            {
                WriteCell(sheet, styles["indexBoxTitle"], (p.y, p.x + x), list[x]);
                WriteCell(sheet, styles["BlankCell"], (p.y + 1, p.x + x), " ");
                sheet.AutoSizeColumn(p.x + x, true);
            }
            var region = new CellRangeAddress(p.y, p.y, p.x, (p.x + list.Count - 1));
            sheet.SetAutoFilter(region);
            sheet.AutoSizeColumn(0, true);
            return true;
        }
        private static bool FormatSheetFile(IWorkbook book, ISheet sheet, Dictionary<String, ICellStyle> styles)
        {
            //メモリ線(枠線)を非表示
            sheet.DisplayGridlines = false;
            //TopLeft シートタイトル埋め込み
            WriteCell(sheet, styles["topleft"], (0, 0), "File");
            //エクセルの行と列 のポイント指定 タプルです。
            (int y, int x) p = (2, 1);
            WriteCell(sheet, styles["indexBoxTitle"], (p.y, p.x), "#");
            WriteCell(sheet, styles["indexBoxTitle"], (p.y, p.x + 1), "FLCKジョブ");
            WriteCell(sheet, styles["indexBoxTitle"], (p.y, p.x + 2), "ファイル名");
            WriteCell(sheet, styles["indexBoxTitle"], (p.y, p.x + 3), "親ユニット");

            WriteCell(sheet, styles["BlankCell"], (p.y + 1, p.x), " ");
            WriteCell(sheet, styles["BlankCell"], (p.y + 1, p.x + 1), " ");
            WriteCell(sheet, styles["BlankCell"], (p.y + 1, p.x + 2), " ");
            WriteCell(sheet, styles["BlankCell"], (p.y + 1, p.x + 3), " ");

            var region = new CellRangeAddress(p.y, p.y, p.x, (p.x + 3));
            sheet.SetAutoFilter(region);
            for (int i = 0; i < 5; i++)
            {
                sheet.AutoSizeColumn(i, true);
            }

            return true;
        }
        private static bool FormatSheetNext(IWorkbook book, ISheet sheet, Dictionary<String, ICellStyle> styles)
        {
            //メモリ線(枠線)を非表示
            sheet.DisplayGridlines = false;
            //TopLeft シートタイトル埋め込み
            WriteCell(sheet, styles["topleft"], (0, 0), "next");
            //エクセルの行と列 のポイント指定 タプルです。
            (int y, int x) p = (2, 1);
            WriteCell(sheet, styles["indexBoxTitle"], (p.y, p.x), "#");
            WriteCell(sheet, styles["indexBoxTitle"], (p.y, p.x + 1), "前提");
            WriteCell(sheet, styles["indexBoxTitle"], (p.y, p.x + 2), "後続");
            WriteCell(sheet, styles["indexBoxTitle"], (p.y, p.x + 3), "ユニット");

            WriteCell(sheet, styles["BlankCell"], (p.y + 1, p.x), " ");
            WriteCell(sheet, styles["BlankCell"], (p.y + 1, p.x + 1), " ");
            WriteCell(sheet, styles["BlankCell"], (p.y + 1, p.x + 2), " ");
            WriteCell(sheet, styles["BlankCell"], (p.y + 1, p.x + 3), " ");

            var region = new CellRangeAddress(p.y, p.y, p.x, (p.x + 3));
            sheet.SetAutoFilter(region);
            for (int i = 0; i < 5; i++)
            {
                sheet.AutoSizeColumn(i, true);
            }
            return true;
        }
        private static bool FormatSheetAjsprint(IWorkbook book, ISheet sheet, Dictionary<String, ICellStyle> styles)
        {
            //メモリ線(枠線)を非表示
            sheet.DisplayGridlines = false;
            //TopLeft シートタイトル埋め込み
            WriteCell(sheet, styles["topleft"], (0, 0), "ajsprint");
            //エクセルの行と列 のポイント指定 タプルです。
            (int y, int x) p = (2, 1);
            WriteCell(sheet, styles["indexBoxTitle"], (p.y, p.x), "#");
            WriteCell(sheet, styles["BlankCell"], (p.y + 1, p.x), " ");
            WriteCell(sheet, styles["indexBoxTitle"], (p.y, p.x + 1), "ajsprint define");
            WriteCell(sheet, styles["BlankCell"], (p.y + 1, p.x + 1), " ");

            for (int i = 0; i < 2; i++)
            {
                sheet.AutoSizeColumn(i, true);
            }
            return true;
        }

        //
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
