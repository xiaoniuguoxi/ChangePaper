using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ChangePaper
{
    public class FileSecurity
    {
        public const string SPOKEN_COMMON_PASSWORD = "hytSpokenExam";
        public const string SPOKEN_ZIP_PASSWORD = "HXSpokenExam";
        private static string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lib\\SecModule.dll");

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("lib/SecModule.dll", EntryPoint = "FileVerify", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileEncrypt(string pwd, string sourceFile, string targetFile);

        [DllImport("lib/SecModule.dll", EntryPoint = "FileDecrypt", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileDecrypt(string pwd, string sourceFile, string targetFile);

        [DllImport("lib/SecModule.dll", EntryPoint = "FileVerify", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FileVerify(string pwd, string sourceFile, Int32 idog);



        

        [DllImport("lib/SecModule.dll", EntryPoint = "EncrypString", CallingConvention = CallingConvention.Cdecl)]
        public static extern int EncrypString(StringBuilder szSource, StringBuilder szTarget);

        [DllImport("lib/SecModule.dll", EntryPoint = "DecrypString", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DecrypString(StringBuilder szSource, StringBuilder szTarget);

        #region 声明方法代理
        public delegate int FileEncryptDelegate(string pwd, string sourceFile, string targetFile);
        public delegate int FileDecryptDelegate(string pwd, string sourceFile, string targetFile);
        public delegate int EncrypStringDelegate(StringBuilder szSource, StringBuilder szTarget);
        public delegate int DecrypStringDelegate(string szSource, string szTarget);
        #endregion 声明方法代理

        //public static int FileEncrypt(string pwd, string sourceFile, string destFile)
        //{
        //    IntPtr pDll = LoadLibrary(dllPath);
        //    IntPtr pAddressOfFunctionToCall = GetProcAddress(pDll, "FileEncrypt");
        //    FileEncryptDelegate fileEncryptDelegate = (FileEncryptDelegate)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(FileEncryptDelegate));
        //    return fileEncryptDelegate(pwd, sourceFile, destFile);
        //}

        //public static int FileDecrypt(string pwd, string sourceFile, string destFile)
        //{
        //    IntPtr pDll = LoadLibrary(dllPath);
        //    IntPtr pAddressOfFunctionToCall = GetProcAddress(pDll, "FileDecrypt");
        //    FileDecryptDelegate fileDecryptDelegate = (FileDecryptDelegate)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(FileDecryptDelegate));
        //    return fileDecryptDelegate(pwd, sourceFile, destFile);
        //}

        public static string EncryptString(string source)
        {
            StringBuilder sbSource = new StringBuilder(source);
            StringBuilder sbDest = new StringBuilder();
            //IntPtr pDll = LoadLibrary(dllPath);
            //IntPtr pAddressOfFunctionToCall = GetProcAddress(pDll, "EncrypString");

            //EncrypStringDelegate enCryptStringDelegate = (EncrypStringDelegate)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(EncrypStringDelegate));
            //enCryptStringDelegate(sbSource, sbDest);
            EncrypString(sbSource, sbDest);
            return sbDest.ToString();
        }

        public static string DecryptString(string strSource)
        {
            StringBuilder sbSource = new StringBuilder(strSource);
            StringBuilder strDest = new StringBuilder();
            //string strDest = string.Empty;
            //IntPtr pDll = LoadLibrary(dllPath);
            //IntPtr pAddressOfFunctionToCall = GetProcAddress(pDll, "DecrypString");

            //DecrypStringDelegate decryptStringDelegate = (DecrypStringDelegate)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(DecrypStringDelegate));
            //decryptStringDelegate(strSource, strDest);
            DecrypString(sbSource, strDest);
            return strDest.ToString();
        }
    }
}
