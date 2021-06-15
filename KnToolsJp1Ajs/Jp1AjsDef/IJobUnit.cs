using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs.Jp1AjsDef
{
    /// <summary>
    /// JP1AJSのジョブユニット
    /// </summary>
    public interface IJobUnit
    {

        //[te="コマンドテキスト";]
        string Te { get; set; }

        //[sc="スクリプトファイル名";]
        string Sc { get; set; }

        //[un="実行ユーザー名";]
        string Un { get; set; }

        //[tho=n;]異常終了のしきい値
        string Tho { get; set; }

        //[eu={ent|def};]ジョブ実行時のJP1ユーザーを定義
        string Eu { get; set; }

        /*
          [te="コマンドテキスト";]
          [sc="スクリプトファイル名";]
          [prm="パラメーター";]
          [wkp="作業用パス名";]
          [ev="環境変数ファイル名";]
          [env="環境変数";]...
          [si="標準入力ファイル名";]
          [so="標準出力ファイル名";]
          [se="標準エラー出力ファイル名";]
          [soa={new|add};]
          [sea={new|add};]
          [etm=n;]
          [fd=実行所要時間;]
          [pr=n;]
          [ex="実行ホスト名";]
          [un="実行ユーザー名";]
          [jd={nm|ab|cod|mdf|exf};]
          [wth=n;]
          [tho=n;]
          [jdf="終了判定ファイル名";]
          [ts1="転送元ファイル名1";]
          [td1="転送先ファイル名1";]
          [top1={sav|del};]
          [ts2="転送元ファイル名2";]
          [td2="転送先ファイル名2";]
          [top2={sav|del};]
          [ts3="転送元ファイル名3";]
          [td3="転送先ファイル名3";]
          [top3={sav|del};]
          [ts4="転送元ファイル名4";]
          [td4="転送先ファイル名4";]
          [top4={sav|del};]
          [ha={y|n};]
          [eu={ent|def};]
          [jty={q|n};]
        */

    }
}
