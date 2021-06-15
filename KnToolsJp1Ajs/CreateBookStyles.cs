using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;

namespace KnToolsJp1Ajs
{
    class CreateBookStyles
    {
        /// <summary>
        /// 使用スタイルを作成する。 static methodです。
        /// </summary>
        /// <param name="wb"></param>
        /// <returns></returns>
        public static Dictionary<String, ICellStyle> createBookStyles(IWorkbook wb)
        {
            //作成したセルのスタイルをディクショナリで返すコレクションを作成
            Dictionary<String, ICellStyle> styles = new Dictionary<String, ICellStyle>();

            //
            IFont font = wb.CreateFont();
            ICellStyle style = wb.CreateCellStyle();

            // (a)スタイルエイリアス[topleft]ディクショナリに追加
            font = CreateFont(wb);
            font.FontHeightInPoints = ((short)14);
            font.IsBold = true;
            font.Color = (IndexedColors.White.Index);
            style = CreateBorderedStyle(wb);
            style.SetFont(font);
            style.Alignment = (HorizontalAlignment.Left);
            style.VerticalAlignment = VerticalAlignment.Center;
            style.FillForegroundColor = (IndexedColors.DarkBlue.Index);
            style.FillPattern = (FillPattern.SolidForeground);
            styles.Add("topleft", style);

            // (b)スタイルエイリアス[indexBoxNo]ディクショナリに追加
            font = CreateFont(wb);
            font.FontHeightInPoints = ((short)14);
            font.IsBold = true;
            font.Color = (IndexedColors.DarkBlue.Index);
            style = CreateBorderedStyle(wb);
            style.SetFont(font);
            style.Alignment = (HorizontalAlignment.Center);
            style.VerticalAlignment = VerticalAlignment.Center;
            //style.FillForegroundColor = (IndexedColors.Blue.Index);
            //style.FillPattern = (FillPattern.SolidForeground);
            styles.Add("indexBoxNo", style);

            // (c)スタイルエイリアス[indexBoxTitle]ディクショナリに追加
            font = CreateFont(wb);
            font.FontHeightInPoints = ((short)14);
            font.IsBold = true;
            font.Color = (IndexedColors.White.Index);
            style = CreateBorderedStyle(wb);
            style.SetFont(font);
            style.Alignment = (HorizontalAlignment.Center);
            style.VerticalAlignment = VerticalAlignment.Center;
            style.FillForegroundColor = (IndexedColors.DarkBlue.Index);
            style.FillPattern = (FillPattern.SolidForeground);
            styles.Add("indexBoxTitle", style);

            // (d)スタイルエイリアス[BlankCell]ディクショナリに追加
            font = CreateFont(wb);
            font.FontHeightInPoints = ((short)14);
            font.IsBold = true;
            font.Color = (IndexedColors.White.Index);
            style = CreateBorderedStyle(wb);
            style.SetFont(font);
            style.Alignment = (HorizontalAlignment.Center);
            style.VerticalAlignment = VerticalAlignment.Center;
            //style.FillForegroundColor = (IndexedColors.DarkBlue.Index);
            //style.FillPattern = (FillPattern.SolidForeground);
            styles.Add("BlankCell", style);

            // (e)スタイルエイリアス[leftBox]ディクショナリに追加
            font = CreateFont(wb);
            font.FontHeightInPoints = ((short)14);
            font.IsBold = true;
            font.Color = (IndexedColors.Black.Index);
            style = CreateBorderedStyle(wb);
            style.SetFont(font);
            style.Alignment = (HorizontalAlignment.Left);
            style.VerticalAlignment = VerticalAlignment.Center;
            //style.FillForegroundColor = (IndexedColors.DarkBlue.Index);
            //style.FillPattern = (FillPattern.SolidForeground);
            styles.Add("leftBox", style);

            return styles;

        }

        private static IFont CreateFont(IWorkbook wb)
        {
            return wb.CreateFont();
        }

        private static ICellStyle CreateStyle(IWorkbook wb)
        {
            return wb.CreateCellStyle();
        }

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
