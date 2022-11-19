using System;
using System.Collections.Generic;

namespace CS2___MujProjekt
{
    public class Osoba
    {

        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string RodnePrijmeni { get; set; }
        public List<string> AlergieNaJidlo { get; set; }
        public List<string> OblibenaJidla { get; set; }
        public List<string> JmenaDeti { get; set; }
        public string JmenoPolovicky { get; set; }
        public List<string> RandomFakty { get; set; }
        public DateTime DatumNarozeni { get; set; }


        public Osoba()
        {
            AlergieNaJidlo = new List<string>();
            OblibenaJidla = new List<string>();
            JmenaDeti = new List<string>();
            RandomFakty = new List<string>();
        }


        public void VypisUdajeOOsobe()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n___________________________________");
            Console.WriteLine($"{Jmeno} {Prijmeni}, Rodne prijmeni: {RodnePrijmeni}. ");

            if (AlergieNaJidlo.Count > 0)
            {
                Console.WriteLine("Ma tyhle alergie na jidlo: ");
                Console.Write(String.Join(", ", AlergieNaJidlo));
            }

            if (OblibenaJidla.Count > 0)
            {
                Console.WriteLine("\nMa tyhle oblibena jidla: ");
                Console.Write(String.Join(", ", OblibenaJidla));
            }

            if (JmenaDeti.Count > 0)
            {
                Console.WriteLine("\nMa deti, ktere se jmenujou: ");
                Console.Write(String.Join(", ", JmenaDeti));
            }

            if (RandomFakty.Count > 0)
            {
                Console.WriteLine("\nVime o nem/ni tyhle informace ");
                foreach (string fakt in RandomFakty)
                {
                    Console.WriteLine(fakt);
                }
            }

            Console.WriteLine("\nJeho/jeji polovickou je: " + JmenoPolovicky);


            DateTime aktualniDen = DateTime.Now;
            int vek = aktualniDen.Year - DatumNarozeni.Year;
            if (DatumNarozeni.Month > aktualniDen.Month)
            {
                vek -= 1;
            }
            else if (DatumNarozeni.Month == aktualniDen.Month)
            {
                if (DatumNarozeni.Day > aktualniDen.Day)
                    vek -= 1;
            }

            if (vek < 200)
            {
                Console.WriteLine("\nDatum narozeni je: " + DatumNarozeni.ToShortDateString());
                Console.WriteLine($"{Jmeno} ma {vek} let.");
            }
            Console.WriteLine("___________________________________");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
