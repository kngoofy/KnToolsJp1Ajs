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
    /// JP1AJSの定義ファイルのパーサー
    /// </summary>
    class ParseJp1Def
    {
        //コンスタラクタ
        public ParseJp1Def()
        {
        }

        public static List<Jp1AjsDef.Unit> ParseJp1DefFromString(string strdef, out string ajsname)
        {

            Unclazz.Jp1ajs2.Unitdef.IUnit jp1Unit = Unclazz.Jp1ajs2.Unitdef.Unit.Parse(strdef);

            ajsname = jp1Unit.Name;

            IEnumerable<Unclazz.Jp1ajs2.Unitdef.IUnit> jobNets = jp1Unit.SubUnits;

            List<Jp1AjsDef.Unit> list = new List<Jp1AjsDef.Unit>();

            IEnumerable<Unclazz.Jp1ajs2.Unitdef.IUnit> jobs;

            var s = new Jp1AjsDef.Unit();
            s.ClearReset();
            s.UnitName = jp1Unit.Attributes.UnitName;
            s.Jp1UserName = jp1Unit.Attributes.Jp1UserName;
            s.Cm = jp1Unit.Comment;
            s.Ty = jp1Unit.Type.Name;
            s.SuperUnitName = "/";
            foreach (var para in jp1Unit.Parameters)
            {
                if (para.Name == "ar")
                    s.ArList.Add((para.Values[0].TupleValue.Values[0], para.Values[0].TupleValue.Values[1]));
            }
            list.Add(s.Clone());

            foreach (var jobNet in jobNets)
            {
                s.ClearReset();
                s.UnitName = jobNet.Attributes.UnitName;
                s.Jp1UserName = jobNet.Attributes.Jp1UserName;
                s.Cm = jobNet.Comment;
                s.Ty = jobNet.Type.Name;
                s.SuperUnitName = jobNet.FullName.SuperUnitName.ToString();
                foreach (var para in jobNet.Parameters)
                {
                    if (para.Name == "de") s.De = para.Values[0].StringValue;
                    if (para.Name == "ha") s.Ha = para.Values[0].StringValue;
                    if (para.Name == "st")
                        s.St = para.Values[1].StringValue;
                    if (para.Name == "cy")
                        s.Cy = para.Values[1].StringValue;
                    if (para.Name == "ar") s.ArList.Add((para.Values[0].TupleValue.Values[0], para.Values[0].TupleValue.Values[1]));
                }
                list.Add(s.Clone());

                jobs = jobNet.SubUnits;
                foreach (var job in jobs)
                {
                    s.ClearReset();
                    s.UnitName = job.Attributes.UnitName;
                    s.Cm = job.Comment;
                    s.Ty = job.Type.Name;
                    s.SuperUnitName = job.FullName.SuperUnitName.ToString();
                    foreach (var para in job.Parameters)
                    {
                        if (para.Name == "un") s.Un = para.Values[0].StringValue;
                        if (para.Name == "te") s.Te = para.Values[0].StringValue;
                        if (para.Name == "sc") s.Sc = para.Values[0].StringValue;
                        if (para.Name == "tho") s.Tho = para.Values[0].StringValue;
                        if (para.Name == "eu") s.Eu = para.Values[0].StringValue;
                        if (para.Name == "ha") s.Ha = para.Values[0].StringValue;
                        if (para.Name == "flwf") s.Flwf = para.Values[0].StringValue;
                    }
                    list.Add(s.Clone());
                }

            }

            return list;
        }

    }
}
