using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs.Jp1AjsDef
{
    /// <summary>
    /// ユニット属性パラメーター インターフェース
    /// </summary>
    public interface IAttribute
    {
        /// <summary>
        /// ユニット名です。
        /// </summary>
        /// <value>ユニット名</value>
        //string UnitName { get; set; }

        /// <summary>
        /// JP1ユーザ名です。
        /// </summary>
        /// <value>JP1ユーザ名</value>
        string Jp1UserName { get; set; }

        /// <summary>
        /// 資源グループ名です。
        /// </summary>
        /// <value>資源グループ名</value>
        string ResourceGroupName { get; set; }

        /// <summary>
        /// 許可モードです。
        /// </summary>
        /// <value>許可モード</value>
        string PermissionMode { get; set; }

    }
}
