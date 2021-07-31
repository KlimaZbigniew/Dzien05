using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlikiFoldery
{
    class Program
    {
        static void Main(string[] args)
        {

            CopyDir(@"c:\tmp\", @"c:\tmp2\");
            Console.ReadKey();
            return;

            string path = @"c:\tmp\test.txt";
            string path2 = @"c:\tmp\test2.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }


            //StreamWriter sw = File.CreateText(path2);
            //sw.Close();
            File.CreateText(path2).Close();//

            File.WriteAllText(path2, "Ala ma kota, kon ma kleszcze");
            File.Copy(path2, path2 + "a");
            File.Move(path2 + "a", @"c:\tmp\nowy_plik.txt");

            Console.WriteLine(File.ReadAllText(path2));

            Console.ReadKey();

            string folderName = @"c:\tmp\alx";
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            Directory.Move(folderName, @"c:\tmp\csharp");
            Directory.Delete(@"c:\tmp\csharp", true);

        }

        static void CopyDir(string sourceDir, string targetDir)
        {
            
            sourceDir += sourceDir.EndsWith(@"\") ? "" : @"\";
            targetDir += targetDir.EndsWith(@"\") ? "" : @"\";



            //ponierz wszystki pliki i podfoldry z sourceDir
            string[] files = Directory.GetFileSystemEntries(@sourceDir);

            Directory.CreateDirectory(targetDir);

            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(files[i]);
                string srcFile = files[i];
                FileAttributes attr = File.GetAttributes(srcFile);
                if (attr == FileAttributes.Directory)
                {
                    //Obdługa obdługa
                    
                    string newFolder = targetDir + Path.GetFileName(srcFile);
                    CopyDir(srcFile, newFolder);
                }
                else
                {
                    //Kopiowanie pliku
                    string dstFile = targetDir + Path.GetFileName(srcFile);
                    File.Copy(srcFile, dstFile, true);
                }
            }


        }
    }
}
