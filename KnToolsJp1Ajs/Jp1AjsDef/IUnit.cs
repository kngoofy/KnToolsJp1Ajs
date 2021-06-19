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
        //ベース名
        string BaseName { get; set; }

        //親ユニット名
        string SuperUnitName { get; set; }

        //ルート・トップのユニット名
        string RootUnitName { get; set; }

        //ユニット名
        string UnitName { get; set; }

        //ユニットタイプ
        string Ty { get; set; }

        //コメント
        string Cm { get; set; }
        //保留
        string Ha { get; set; }

        //クラスのコピークーロンを返すメソッド
        Unit Clone();

        //プロパティをListで返す
        List<string> getListValues();

        //クリアリセット
        void ClearReset();

        }
    }
