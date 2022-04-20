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

            //オプションで生成HulftBook名指定している場合と指定していない場合
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
            //string templateBook = "TemplateJP1AJS.xlsx";
            CreateNewTemplateBook.CreateBook(OutPutBookName);

            //return;

            //(1) Sndシート[snd] 中身肉付け オプションでファイルが指定されていたら
            if (target["ajs"] != null && File.Exists(target["ajs"]))
            {
                ;
                var units =BuildJp1AjsDef.StreamBuildJp1AjsDefUnits(target["ajs"]);
                //var lines = BuildJp1AjsDef.StreamBuildJp1AjsDef(target["ajs"]);

                //UpdateBook.UpdateExcelBook(OutPutBookName, units, lines, CreatedBook);
                UpdateBook.UpdateExcelBook(OutPutBookName, units);

                //ajsユニット定義ファイルを読み込んでstring型へ
                //string strDef = ReadFile.ReadFileToString(target["ajs"]);
                //ajsユニット定義ファイルをパース string型から
                //var units = ParseJp1Def.ParseAjsDefFromString(strDef, out string ajsname);

                //ajsユニット定義ファイルを読み込んでList型へ
                //List<string> lines = ReadFile.ReadFileToList(file);


                //UpdateExcelBook(string templateFile, List<Unit> lists, List<string> lines, string outputFile)


                //List<HulftSndDef> hulftSndDatas = BuildHulftSndDef.StreamBuildHulftSndDef(target["ajs"]);
                //var updateBookSndSheet = new UpdateBook(OutPutBookName, hulftSndDatas);
            }


            ////
            //var file = @"E:\02.Kazu-Development\01.VisualStudio\KnToolsJp1Ajs\KnToolsJp1Ajs\Data\jp1def-test02.txt";

            ////ajsユニット定義ファイルを読み込んでstring型へ
            //string strDef = ReadFile.ReadFileToString(file);
            ////ajsユニット定義ファイルをパース string型から
            //var units = ParseJp1Def.ParseAjsDefFromString(strDef, out string ajsname);

            ////ajsユニット定義ファイルを読み込んでList型へ
            //List<string> lines = ReadFile.ReadFileToList(file);

            //////作成するブック名
            //string CreatedBook = $@"Jp1Ajs-{ajsname}.xlsx";
            ////AJSブック作成実行
            //UpdateBook.UpdateExcelBook(OutPutBookName, units, lines, CreatedBook);

            return;

        }

    }
}
