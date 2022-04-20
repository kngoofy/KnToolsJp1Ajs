using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs.Jp1AjsDef
{
    /// <summary>
    ///  ユニット インターフェース
    /// </summary>
    public interface IUnit : IAttribute, IJobnetUnit, IJobUnit, IFlwjUnit
    {
        /// <summary>
        /// プロパティ ベース名
        /// </summary>
        string BaseName { get; set; }


        /// <summary>
        /// プロパティ 親ユニット名
        /// </summary>
        string SuperUnitName { get; set; }


        /// <summary>
        /// プロパティ ルート・トップのユニット名
        /// </summary>
        string RootUnitName { get; set; }


        /// <summary>
        /// プロパティ ユニット名
        /// </summary>
        string UnitName { get; set; }


        /// <summary>
        /// プロパティ ユニットタイプ
        /// </summary>
        string Ty { get; set; }

        /// <summary>
        /// プロパティ コメント
        /// </summary>
        string Cm { get; set; }

        /// <summary>
        /// プロパティ 保留
        /// </summary>
        string Ha { get; set; }

        //クラスのコピークーロンを返すメソッド
        /// <summary>
        /// プロパティ
        /// </summary>
        Unit Clone();

        /// <summary>
        /// プロパティをListで返す
        /// </summary>
        /// <returns></returns>
        List<string> GetListValues();

        /// <summary>
        /// クリアリセット
        /// </summary>
        void ClearReset();
    }
}
