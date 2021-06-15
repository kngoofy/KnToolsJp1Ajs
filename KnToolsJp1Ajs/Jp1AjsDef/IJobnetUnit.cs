using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs.Jp1AjsDef
{
    /// <summary>
    /// JP1AJSのジョブネットユニット
    /// </summary>
    public interface IJobnetUnit
    {
        //
        string Sz { get; set; }
        //List<string> el = new List<string>();      //=DERIADO501,j,+240+144;
        //List<string> ar = new List<string>();      //=(f=DERIAD0501,t=DERIAD0502, seq);
        string Sd { get; set; }
        string St { get; set; }
        string Cy { get; set; }
        string Sh { get; set; }
        string Shd { get; set; }
        string De { get; set; }

        /*
        [sd=[N,]{[[yyyy/]mm/]{[+|*|@]dd
             |[+|*|@]b[-DD]|[+]{su|mo|tu|we|th|fr|sa}
             [:{n|b}]}|en|ud};]
        [st=[N,][+]hh:mm;]
        [sy=[N,]hh:mm|{M|U|C}mmmm;]
        [ey=[N,]hh:mm|{M|U|C}mmmm;]
        [ln=[N,]n;]
        [cy=[N,](n,{y|m|w|d});]
        [sh=[N,]{be|af|ca|no};]
        [shd=[N,]n;]
        [wt=[N,]{no|hh:mm|mmmm|un};]
        [wc=[N,]{no|n|un};]
        [cftd=[N,]{no|be|af}[,n[,N]];]
        [ed=yyyy/mm/dd;]
        [rg=n;]
        [pr=n;]
        [ni=n;]
        [ha={y|w|a|n};]
        [ejn=排他ジョブネット名;]
        [cd={no|un|n};]
        [de={y|n};]
        [ms={sch|mlt};]
        [mp={y|n};]
        [jc=ジョブグループ完全名;]
        [rh="実行マネージャー名";]
        [ex="実行ホスト名";]
        [fd=実行所要時間;]
        [ar=(f=先行ユニット名,t=後続ユニット名[,接続種別]);]
        [ncl={y|n};]
        [ncn=ジョブネットコネクタ名;]
        [ncs={y|n};]
        [ncex={y|n};]
        [nchn="接続ホスト名";]
        [ncsv=接続サービス名;]
        */

    }
}
