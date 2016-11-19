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
            int length = 15;
            byte ii = 75;
            try
            {
                sciezka = new FileStream(@"c:\test\test.txt", FileMode.OpenOrCreate); //otwarcie lub utworzenie pliku
                for (int i = 0; i < length; i++)
                {
                    ii++;
                    sciezka.WriteByte((byte)ii); // zapis do pliku znakow typu byte
                }

                sciezka.Position = 0; // powrot do poczatku pliku

                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine(sciezka.ReadByte() + " ");  //odczyt pliku od pozycji 0
                }

                StreamWriter sw = new StreamWriter(sciezka,Encoding.UTF8); // zapis tekstu do pliku 
                sw.WriteLine("Krótki tekst");
                sw.Flush();
            }
            catch(FileNotFoundException e) // wyjatek -  jezeli nie ma pliku
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e) // wyjatek - ogolne bledy najnizszy w hierarchi (najbardziej ogolny)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sciezka != null) sciezka.Close();
            }

            //odczyt pliku

            string[] zawartosc_pliku = File.ReadAllLines(@"c:\test\test.txt");
            Console.WriteLine("Zawartosc pliku test.txt \n");
            foreach (string tresc in zawartosc_pliku)
            {
                Console.WriteLine("\t" + tresc);
            }

            //skopiowanie zawartosci 1 pliku do 2 i zmina na duze litery
            try
            {

                sciezka = new FileStream(@"c:\test\test2.txt", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(sciezka, Encoding.UTF8); // zapis tekstu do pliku 
                
                int calosc = 0;
                foreach (string tresc in zawartosc_pliku)
                {
                    sw.WriteLine(tresc.ToUpper());
                    string[] licznik = tresc.Split(' ');
                    calosc += licznik.Length;
                }
                
                sw.Flush();
                Console.WriteLine("Liczba znakow: "+calosc);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
