using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Plikistrumien
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream sciezka = null;
            int length = 10;
            byte ii = 1;
            try
            {
                sciezka = new FileStream(@"c:\test\test.txt", FileMode.OpenOrCreate); //otwarcie lub utworzenie pliku
                for (int i = 0; i < length; i++)
                {
                    ii++;
                    sciezka.WriteByte(ii);
                }
            }
            catch(FileNotFoundException e) // wyjatek jezeli nie ma pliku
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e) // ogolne bledy njnizszy w hierarchi (najbardziej ogolny)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sciezka != null) sciezka.Close();
            }
           
            
        }
    }
}
