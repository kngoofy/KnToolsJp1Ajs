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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool CreateBookFromFilePath(string filePath,string fileName)
        {
            Adapter.CreateFromFile(filePath,fileName);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CreateNewBook()
        {
            return true;
        }
    }
}
