using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strumienie
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(@"c:\tmp\test.txt");
                sw.AutoFlush = false;

                for (int i = 1; i <= 5; i++)
                {
                    sw.WriteLine($"Linia nr: {i}");
                }

                sw.Flush();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }


            //Resource manager - using
            try
            {

                using (StreamWriter sw1 = new StreamWriter(@"c:\tmp\test1.txt"))
                {
                      sw1.WriteLine($"Dodatkowa linia. literka ą");
                    //sw1.Colse () - nie potrzeba zamykania close: using sam to zamknie.
                }

            }
            catch (Exception exc)
            {

         
            }


            //Odczyt ze strumienia plikowwgo
            string s;

            string filename = @"c:\tmp\test.txt";
            
            FileStream fs = new FileStream(filename, FileMode.Open);
            byte[] data = new byte[fs.Length];
            fs.Seek(2,SeekOrigin.Begin);
            fs.Read(data, 0, (int)fs.Length);

            //Konwersja tablicy bajtów na string
            s = Encoding.UTF8.GetString(data);
            Console.WriteLine(s);
            s = Encoding.ASCII.GetString(data);
            Console.WriteLine(s);
            s = Encoding.UTF7.GetString(data);
            Console.WriteLine(s);

            fs.Close();

            Console.WriteLine("Sekwencyjne odczytywanie pliku txt");
            //Sekwencyjne odczytywanie pliku txt
            using (StreamReader sr = new StreamReader(@"c:\tmp\test.txt"))
            {
                string line;
                do
                {
                    line = sr.ReadLine();
                    Console.WriteLine(line);
                } while (line != null);
                
            }


            //Metody I/O dla klasy File
            File.ReadAllText(@"c:\tmp\test.txt");
            //File.ReadAllText(@"c:\tmp\test.txt", "dfSDfdsfsd ");
           

                Console.ReadKey();
        }
    }
}
