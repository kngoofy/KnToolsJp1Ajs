using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs.Jp1AjsDef
{
    /// <summary>
    /// ファイル受信ユニット インターフェース
    /// </summary>
    public interface IFlwjUnit
    {
        //[flwf="監視対象ファイル名";]
        
        /// <summary>
        /// プロパティ 監視対象ファイル
        /// </summary>
        string Flwf { get; set; }

        /*
        [flwf="監視対象ファイル名";]
        [flwc=c[:d[:{s|m}]];]
        [flwi=監視間隔;]
        [flco={y|n};]
        [jpoif=?マクロ変数名?:引き継ぎ情報名;]
        [etm=n;]
        [fd=実行所要時間;]
        [ex="実行ホスト名";]
        [ha={y|n};]
        [eu={ent|def};]
        [ets={kl|nr|wr|an};]
        */

    }
}
