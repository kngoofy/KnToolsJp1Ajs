using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnToolsJp1Ajs;

namespace KnToolsJp1AjsForms
{
    class CreateBookFromForms
    {
        //
        public static bool CreateBookFromFilePath(string filePath,string fileName)
        {
            AdapterMain.MakeJp1DefBookAdapter(filePath,fileName);
            return true;
        }
        public static bool CreateNewBook()
        {
            return true;
        }
    }
}
