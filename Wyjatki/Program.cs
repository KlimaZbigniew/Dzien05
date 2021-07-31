using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wyjatki
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    int p = 10, q = 0, t = 0;
                        t = p / q;
                }
                catch 
                {

                    //throw;
                }

                int i = 10, j = 0, k = 0;
                //k = i / j;
                string s = Console.ReadLine();
                i = Int32.Parse(s);
                if (i < 0)
                    throw new Exception("mniejsze od zera");

                byte[] b = new byte[] { 1, 2, 3, 4, 5 };
                byte x = b[i];
            }
            catch (IndexOutOfRangeException exc)
            {
                Console.WriteLine($"Zły indeks\n {exc.Message}");
            }
            catch (FormatException exc)
            {
                Console.WriteLine($"Zły format danych\n{exc.Message}");
            }
            catch (Exception exc)
            {

                Console.WriteLine($"Wystąpił wyjątek\n\n{exc.Message}");
            }
            finally
            {
                //zawsze się wykoana nawet mimo wyjątku.
                Console.WriteLine("Zawsze się wykona");
            }

            Console.ReadKey();


        }
    }
}
