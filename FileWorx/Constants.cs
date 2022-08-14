using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileWorx
{
    public static class Constants
    {
        public static string GetDirectory()
        {
            //removing /bin/Debug path to get to FileWorx Folder.
            return Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
        }

        public static string ComplexSeparator()
        {
            return "%%$$##";
        }

        public static string NewsFlag()
        {
            return "newsFlag";
        }

        public static string PhotoFlag()
        {
            return "photoFlag";
        }
    }
}
