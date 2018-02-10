using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ChangePaper
{
   public static class SecModule
    {

        [DllImport("SecModule.dll", EntryPoint = "FileVerify", CallingConvention = CallingConvention.Cdecl)]
        public extern static int FileVerify(string szPass, string szSourceFile);

        [DllImport("SecModule.dll", EntryPoint = "FileSign", CallingConvention = CallingConvention.Cdecl)]
        public extern static int FileSign(string szPass, string szSourceFile);

        [DllImport("SecModule.dll", EntryPoint = "FileEncrypt", CallingConvention = CallingConvention.Cdecl)]
        public extern static int FileEncrypt(string szPass, string szSourceFile, string szTargetFile);

        [DllImport("SecModule.dll", EntryPoint = "CheckFile", CallingConvention = CallingConvention.Cdecl)]
        public extern static int CheckFile(string szPass, string szSourceFile);

        [DllImport("SecModule.dll", EntryPoint = "GetFileSignMD5", CallingConvention = CallingConvention.Cdecl)]
        public extern static int GetFileSignMD5(StringBuilder szSourceFile, StringBuilder  md5);




    }
}
