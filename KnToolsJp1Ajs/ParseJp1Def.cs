using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnToolsJp1Ajs.Jp1AjsDef;
using Unclazz.Jp1ajs2.Unitdef;
using Unclazz.Jp1ajs2.Unitdef.Parser;

namespace KnToolsJp1Ajs
{
    /// <summary>
    /// 定義ファイルのパーサー
    /// </summary>
    class ParseJp1Def
    {
        //public static List<Jp1AjsDef.Unit> ParseAjsDefFromString(string strAjsDef, out string ajsname)
        public static Jp1AjsDef.AjsDef ParseAjsDefFromString(string strAjsDef, out string ajsname)
        {

            //パース実行
            Unclazz.Jp1ajs2.Unitdef.IUnit unit = Unclazz.Jp1ajs2.Unitdef.Unit.Parse(strAjsDef);

            //AJS名 out string 
            ajsname = unit.Name;

            //一段下のネット
            IEnumerable<Unclazz.Jp1ajs2.Unitdef.IUnit> jobNets = unit.SubUnits;

            //AJS定義のList型
            List<Jp1AjsDef.Unit> list = new List<Jp1AjsDef.Unit>();

            //ネットの一段下のジョブ
            IEnumerable<Unclazz.Jp1ajs2.Unitdef.IUnit> jobs;

            //AJSユニット組み立て
            var s = new Jp1AjsDef.Unit();
            s.ClearReset();
            s.UnitName = unit.Attributes.UnitName;
            s.Jp1UserName = unit.Attributes.Jp1UserName;
            s.Cm = unit.Comment;
            s.Ty = unit.Type.Name;
            s.SuperUnitName = "/";
            foreach (var para in unit.Parameters)
            {
                if (para.Name == "ha") s.Ha = para.Values.FirstOrDefault().StringValue;
                if (para.Name == "st") s.St = para.Values.Skip(1).FirstOrDefault().StringValue;
                if (para.Name == "cy") s.Cy = para.Values.Skip(1).FirstOrDefault().StringValue;
                if (para.Name == "ar")
                    s.ArList.Add((para.Values.FirstOrDefault().TupleValue.Values[0]
                               , para.Values.FirstOrDefault().TupleValue.Values[1]));
            }
            list.Add(s.Clone());

            //ジョブネット
            foreach (var jobNet in jobNets)
            {
                //ジョブネット処理
                s.ClearReset();
                s.UnitName = jobNet.Attributes.UnitName;
                s.Jp1UserName = jobNet.Attributes.Jp1UserName;
                s.Cm = jobNet.Comment;
                s.Ty = jobNet.Type.Name;
                s.SuperUnitName = jobNet.FullName.SuperUnitName.ToString();
                foreach (var para in jobNet.Parameters)
                {
                    if (para.Name == "de") s.De = para.Values.FirstOrDefault().StringValue;
                    if (para.Name == "ha") s.Ha = para.Values.FirstOrDefault().StringValue;
                    if (para.Name == "st") s.St = para.Values.Skip(1).FirstOrDefault().StringValue;
                    if (para.Name == "cy") s.Cy = para.Values.Skip(1).FirstOrDefault().StringValue;
                    if (para.Name == "ar")
                        s.ArList.Add((para.Values.FirstOrDefault().TupleValue.Values[0]
                               , para.Values.FirstOrDefault().TupleValue.Values[1]));
                }
                list.Add(s.Clone());

                //ジョブ
                jobs = jobNet.SubUnits;
                foreach (var job in jobs)
                {
                    //ジョブ処理
                    s.ClearReset();
                    s.UnitName = job.Attributes.UnitName;
                    s.Cm = job.Comment;
                    s.Ty = job.Type.Name;
                    s.SuperUnitName = job.FullName.SuperUnitName.ToString();
                    foreach (var para in job.Parameters)
                    {
                        if (para.Name == "un") s.Un = para.Values.FirstOrDefault().StringValue;
                        if (para.Name == "te") s.Te = para.Values.FirstOrDefault().StringValue;
                        if (para.Name == "sc") s.Sc = para.Values.FirstOrDefault().StringValue;
                        if (para.Name == "tho") s.Tho = para.Values.FirstOrDefault().StringValue;
                        if (para.Name == "eu") s.Eu = para.Values.FirstOrDefault().StringValue;
                        if (para.Name == "ha") s.Ha = para.Values.FirstOrDefault().StringValue;
                        if (para.Name == "flwf") s.Flwf = para.Values.FirstOrDefault().StringValue;
                    }
                    list.Add(s.Clone());
                }
            }


            var ajsDef = new Jp1AjsDef.AjsDef();
            ajsDef.ajsName = ajsname;
            ajsDef.ajsDefLists = strAjsDef.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None).ToList();
            ajsDef.units = list;

            return ajsDef;
            //return list;
        }

    }
}
