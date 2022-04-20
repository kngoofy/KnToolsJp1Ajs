using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs.Jp1AjsDef
{
    /// <summary>
    ///  ユニット
    /// </summary>
    public class Unit : IUnit
    {
        //Unit パート
        public string BaseName { get; set; } = "ベース名";
        public string SuperUnitName { get; set; } = "PUnit";
        public string RootUnitName { get; set; } = "Rootユニット名";


        public string UnitName { get; set; } = "Unit";
        public string Ty { get; set; } = "Type";
        public string Cm { get; set; } = "Comment";
        public string Ha { get; set; } = "Hold";

        //Attributes パート
        public string Jp1UserName { get; set; } = "";
        public string ResourceGroupName { get; set; } = "";
        public string PermissionMode { get; set; } = "";

        //jobnet
        public string Sz { get; set; } = "";
        public string Sd { get; set; } = "";
        public string St { get; set; } = "ExecTime";
        public string Cy { get; set; } = "Cycle";
        public string Sh { get; set; } = "";
        public string Shd { get; set; } = "";
        public string De { get; set; } = "";

        //job
        public string Te { get; set; } = "CommandText";
        public string Sc { get; set; } = "Script";
        public string Un { get; set; } = "ExecUser";
        public string Tho { get; set; } = "Thold";
        public string Eu { get; set; } = "exeuser";

        //flwf
        public string Flwf { get; set; } = "File";

        public List<(string, string)> ArList = new List<(string, string)>();//{ get; set; } = null;

        //コンストラクタ
        public Unit()
        {
            ClearReset();
        }
        public Unit(string type)
        {

            switch (type)
            {
                case "Header":
                    break;
                default:
                    ClearReset();
                    break;
            }
        }

        //クラスのコピークーロンを返すメソッド
        public Unit Clone()
        {
            Unit cloned = (Unit)MemberwiseClone();
            if (this.ArList != null)
            {
                cloned.ArList = new List<(string, string)>(ArList);
            }

            return cloned;
        }

        //プロパティをListで返す
        public List<string> GetListValues()
        {
            var list = new List<string>
            {
                 UnitName
                ,Ty
                ,Cm
                ,Ha

                //,Jp1UserName
                //,ResourceGroupName
                //,PermissionMode
                
                //,Sz
                //,Sd
                ,St
                ,Cy
                //,Sh
                //,Shd
                //,De

                ,Te
                ,Sc
                
                //
                ,Flwf

                ,Un
                //,Tho
                //,Eu
                ,SuperUnitName
            };

            return list;
        }

        //クリアリセット
        public void ClearReset()
        {
            BaseName = "";
            SuperUnitName = "";
            RootUnitName = "";

            UnitName = "";
            Ty = "";
            Cm = "";
            Ha = "";

            Jp1UserName = "";
            ResourceGroupName = "";
            PermissionMode = "";

            Sz = "";
            Sd = "";
            St = "";
            Cy = "";
            Sh = "";
            Shd = "";
            De = "";

            Te = "";
            Sc = "";

            Flwf = "";

            Un = "";
            Tho = "";
            Eu = "";

            ArList.Clear();
        }

    }
}
