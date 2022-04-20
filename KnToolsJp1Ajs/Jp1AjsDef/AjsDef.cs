using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs.Jp1AjsDef
{
    public class AjsDef
    {
        public string ajsName { get; set; } = "";
        public  List<string> ajsDefLists { get; set; }
        public List<Jp1AjsDef.Unit> units { get; set; }

    }
}
