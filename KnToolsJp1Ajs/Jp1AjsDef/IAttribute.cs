using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs.Jp1AjsDef
{
    /// <summary>
    /// ユニット属性パラメーター Attribute インターフェース
    /// </summary>
    public interface IAttribute
    {
        /// <summary>
        /// プロパティ ユニット名
        /// </summary>
        /// <value>string ユニット名</value>
        //string UnitName { get; set; }

        /// <summary>
        /// プロパティ JP1ユーザ名
        /// </summary>
        /// <value>string JP1ユーザ名</value>
        string Jp1UserName { get; set; }

        /// <summary>
        /// プロパティ 資源グループ名
        /// </summary>
        /// <value>string 資源グループ名</value>
        string ResourceGroupName { get; set; }

        /// <summary>
        /// プロパティ 許可モード
        /// </summary>
        /// <value>string 許可モード</value>
        string PermissionMode { get; set; }
    }
}
