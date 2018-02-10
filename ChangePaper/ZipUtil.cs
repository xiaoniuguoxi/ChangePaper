using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ChangePaper
{
    public class ZipUtil
    {
        public static bool UnZipFile(string zipFilePath, string unZipDir, out string response, string password = null)
        {
            response = string.Empty;
            if(zipFilePath == string.Empty)
            {
                response = "压缩文件路径不能为空！";
                return false;
            }

            if(!File.Exists(zipFilePath))
            {
                response = "压缩文件不存在！";
                return false;
            }

            if(unZipDir == string.Empty)
            {
                unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
            }

            if(!unZipDir.EndsWith("\\"))
            {
                unZipDir += "\\";
            }

            if(!Directory.Exists(unZipDir))
            {
                Directory.CreateDirectory(unZipDir);
            }

            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
                {
                    if(!string.IsNullOrWhiteSpace(password))
                    {
                        s.Password = password;
                    }

                    ZipEntry theEntry;
                    while((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(theEntry.Name);
                        string fileName = Path.GetFileName(theEntry.Name);
                        if(directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(unZipDir + directoryName);
                        }

                        if(!directoryName.EndsWith("\\"))
                        {
                            directoryName += "\\";
                        }

                        if(fileName != string.Empty)
                        {
                            string filePath = Path.Combine(unZipDir, theEntry.Name);
                            if(File.Exists(filePath))
                            {
                                File.SetAttributes(filePath, FileAttributes.Normal);
                            }

                            using (FileStream streamWriter = File.Create(filePath))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];
                                while(true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if(size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }
            return true;
        }
    }
}
