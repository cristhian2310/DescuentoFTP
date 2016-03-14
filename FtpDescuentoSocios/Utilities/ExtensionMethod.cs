using System;
using System.IO;

namespace FtpDescuentoSocios.Utilities
{
    public static class ExtensionMethod
    {
        
            public static string AppendTimeStamp(this string fileName)
            {
                return string.Concat(
                    Path.GetFileNameWithoutExtension(fileName),
                    DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"),
                    Path.GetExtension("-"+fileName)
                    );
            }
        
    }
}
