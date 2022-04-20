using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs.Jp1AjsDef
{
    /// <summary>
    /// JP1/AJSのUNIT情報を扱うクラス
    /// </summary>
    public class AjsDef
    {
        /// <summary>
        /// プロパティ いわゆる AJS名
        /// </summary>
        public string AjsName { get; set; } = "";
        
        /// <summary>
        /// プロパティ AJSPRINTで吐かれる定義ファイルを行単位でList化した物
        /// </summary>
        public  List<string> AjsDefLists { get; set; }
        
        /// <summary>
        /// プロパティ AJS定義をパーサし、Unitを行単位にしてList化した物
        /// </summary>
        public List<Jp1AjsDef.Unit> Units { get; set; }
    }
}
