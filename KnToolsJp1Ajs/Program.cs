using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unclazz.Jp1ajs2.Unitdef;
using Unclazz.Jp1ajs2.Unitdef.Parser;

namespace KnToolsJp1Ajs
{
    class Program
    {
        /// <summary>
        /// コンソールアプリ用のエントリポイント
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // コマンドラインのオプションパラメータの解釈
            args = args.Concat(new string[] { "" }).ToArray(); // オプションのみと　そもそも入っていないの識別
            var options = new string[] { "-ajs", "-o", "-h" };
            var target = options.ToDictionary(p => p.Substring(1), p => args.SkipWhile(a => a != p).Skip(1).FirstOrDefault());

            //オプションで生成Jp1AjsBook名指定している場合と指定していない場合
            var OutPutBookName = "NewJp1AjsBook.xlsx";
            if (target["o"] != null)
            {
                OutPutBookName = target["o"];
            }

            // usage 表示
            if (target["h"] != null || args.Length < 2)
            {
                Console.WriteLine("Help:");
                Console.WriteLine(" -ajs  JP1/AJSの定義ファイル");
                Console.WriteLine(" -o    生成されるJp1AjsBookファイル 指定がない場合は[" + OutPutBookName + "]");
                Console.WriteLine(" -h    このヘルプ");
                Console.WriteLine(" 引数がない場合もこのヘルプが表示されます。[" + args.Length + "]");
                return;
            }

            //テンプレートであるブックを新規作成
            CreateNewTemplateBook.CreateBook(OutPutBookName);

            //中身肉付け オプションでファイルが指定されていたら
            if (target["ajs"] != null && File.Exists(target["ajs"]))
            {
                var ajsdef = BuildJp1AjsDef.StreamBuildJp1AjsDefUnits(target["ajs"]);
                UpdateBook.UpdateExcelBook(OutPutBookName, ajsdef);
            }
        }

    }
}
