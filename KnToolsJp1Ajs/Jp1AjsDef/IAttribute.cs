using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs.Jp1AjsDef
{
    /// <summary>
    ///  JP1AJS のユニット属性
    /// </summary>
    public interface IAttribute
    {
        //string UnitName { get; set; }
        string Jp1UserName { get; set; }
        string ResourceGroupName { get; set; }
        string PermissionMode { get; set; }
    }
}
