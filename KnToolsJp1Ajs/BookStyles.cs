using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;

namespace KnToolsJp1Ajs
{
    class BookStyles
    {
        /// <summary>
        /// 使用スタイルを作成する。
        /// </summary>
        /// <param name="wb">Book</param>
        /// <returns></returns>
        public static Dictionary<string, ICellStyle> CreateBookStyles(IWorkbook wb)
        {
            //作成したセルのスタイルをディクショナリで返すコレクションを作成
            var styles = new Dictionary<string, ICellStyle>();

            //fontとstyle
            IFont font;         // = wb.CreateFont();
            ICellStyle style;   // = wb.CreateCellStyle();

            // (a)スタイルエイリアス[topleft]ディクショナリに追加
            font = CreateFont(wb);
            font.FontName = "Meiryo UI";
            font.FontHeightInPoints = (short)10;
            font.IsBold = true;
            font.Color = IndexedColors.White.Index;
            style = CreateBorderedStyle(wb);
            style.SetFont(font);
            style.Alignment = HorizontalAlignment.Left;
            style.VerticalAlignment = VerticalAlignment.Center;
            style.FillForegroundColor = IndexedColors.DarkBlue.Index;
            style.FillPattern = FillPattern.SolidForeground;
            styles.Add("topleft", style);

            // (b)スタイルエイリアス[indexBoxNo]ディクショナリに追加
            font = CreateFont(wb);
            font.FontName = "Meiryo UI";
            font.FontHeightInPoints = (short)10;
            font.IsBold = true;
            font.Color = IndexedColors.DarkBlue.Index;
            style = CreateBorderedStyle(wb);
            style.SetFont(font);
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;
            //style.FillForegroundColor = (IndexedColors.Blue.Index);
            //style.FillPattern = (FillPattern.SolidForeground);
            styles.Add("indexBoxNo", style);

            // (c)スタイルエイリアス[indexBoxTitle]ディクショナリに追加
            font = CreateFont(wb);
            font.FontName = "Meiryo UI";
            font.FontHeightInPoints = (short)9;
            font.IsBold = false;
            font.Color = IndexedColors.White.Index;
            style = CreateBorderedStyle(wb);
            style.SetFont(font);
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;
            style.FillForegroundColor = IndexedColors.DarkBlue.Index;
            style.FillPattern = FillPattern.SolidForeground;
            styles.Add("indexBoxTitle", style);

            // (d)スタイルエイリアス[BlankCell]ディクショナリに追加
            font = CreateFont(wb);
            font.FontName = "Meiryo UI";
            font.FontHeightInPoints = (short)9;
            font.IsBold = false;
            font.Color = IndexedColors.White.Index;
            style = CreateBorderedStyle(wb);
            style.SetFont(font);
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;
            //style.FillForegroundColor = (IndexedColors.DarkBlue.Index);
            //style.FillPattern = (FillPattern.SolidForeground);
            styles.Add("BlankCell", style);

            // (e)スタイルエイリアス[leftBox]ディクショナリに追加
            font = CreateFont(wb);
            font.FontName = "Meiryo UI";
            font.FontHeightInPoints = (short)9;
            font.IsBold = false;
            font.Color = IndexedColors.Black.Index;
            style = CreateBorderedStyle(wb);
            style.SetFont(font);
            style.Alignment = HorizontalAlignment.Left;
            style.VerticalAlignment = VerticalAlignment.Center;
            //style.FillForegroundColor = (IndexedColors.DarkBlue.Index);
            //style.FillPattern = (FillPattern.SolidForeground);
            styles.Add("leftBox", style);

            // (f)スタイルエイリアス[Box]ディクショナリに追加
            font = CreateFont(wb);
            font.FontName = "Meiryo UI";
            font.FontHeightInPoints = (short)9;
            font.IsBold = false;
            font.Color = IndexedColors.Black.Index;
            style = CreateBorderedStyle(wb);
            style.SetFont(font);
            //style.Alignment = HorizontalAlignment.Left;
            style.VerticalAlignment = VerticalAlignment.Center;
            //style.FillForegroundColor = (IndexedColors.DarkBlue.Index);
            //style.FillPattern = (FillPattern.SolidForeground);
            styles.Add("Box", style);

            return styles;
        }

        /// <summary>
        /// フォント作成
        /// </summary>
        /// <param name="wb">Book</param>
        /// <returns></returns>
        private static IFont CreateFont(IWorkbook wb)
        {
            return wb.CreateFont();
        }

        /// <summary>
        /// セルスタイル作成
        /// </summary>
        /// <param name="wb">Book</param>
        /// <returns></returns>
        //private static ICellStyle CreateStyle(IWorkbook wb)
        //{
        //    return wb.CreateCellStyle();
        //}

        /// <summary>
        /// セルスタイル作成 枠あり
        /// </summary>
        /// <param name="wb">Book</param>
        /// <returns></returns>
        private static ICellStyle CreateBorderedStyle(IWorkbook wb)
        {
            ICellStyle style = wb.CreateCellStyle();
            style.BorderRight = BorderStyle.Thin;
            style.RightBorderColor = (IndexedColors.Black.Index);
            style.BorderBottom = BorderStyle.Thin;
            style.BottomBorderColor = (IndexedColors.Black.Index);
            style.BorderLeft = BorderStyle.Thin;
            style.LeftBorderColor = (IndexedColors.Black.Index);
            style.BorderTop = BorderStyle.Thin;
            style.TopBorderColor = (IndexedColors.Black.Index);

            return style;
        }

    }
}
