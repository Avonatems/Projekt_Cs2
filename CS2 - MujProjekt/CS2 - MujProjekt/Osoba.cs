using System;
using System.Collections.Generic;

namespace CS2___MujProjekt
{
    public class Osoba
    {

        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string RodnePrijmeni { get; set; }
        public List<string> AlergieNaJidlo { get; } 
        public List<string> OblibenaJidla { get; }
        public List<string> JmenaDeti { get; }
        public string JmenoPolovicky { get; set; }
        public List<string> Zajimavosti { get; }
        public DateTime DatumNarozeni { get; set; }


        public Osoba()
        {
            AlergieNaJidlo = new List<string>();
            OblibenaJidla = new List<string>();
            JmenaDeti = new List<string>();
            Zajimavosti = new List<string>();
        }


        public void VypisUdajeOsoby() 
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n___________________________________");
            Console.WriteLine($"{Jmeno} {Prijmeni}, Rodne prijmeni: {RodnePrijmeni}. ");

            VypisAlergieNaJidlo();
            VypisOblibenaJidla();
            VypisJmenaDeti();
            VypisZajimavosti();
            VypisJmenoPolovicky();
            VypisVek();        
            Console.WriteLine("\n___________________________________");
            Console.ForegroundColor = ConsoleColor.White;
        
        
        }
        private void VypisAlergieNaJidlo()
        {
            if (AlergieNaJidlo.Count > 0)
            {
                Console.WriteLine("Ma tyhle alergie na jidlo: ");
                Console.Write(string.Join(", ", AlergieNaJidlo));
            }
        }

        private void VypisOblibenaJidla()
        {
            if (OblibenaJidla.Count > 0)
            {
                Console.WriteLine("\nMa tyhle oblibena jidla: ");
                Console.Write(string.Join(", ", OblibenaJidla));
            }
        }

        private void VypisJmenaDeti()
        {
            if (JmenaDeti.Count > 0)
            {
                Console.WriteLine("\nMa deti, ktere se jmenujou: ");
                Console.Write(string.Join(", ", JmenaDeti)); 
            }
        }

        private void VypisZajimavosti()
        {
            if (Zajimavosti.Count > 0)
            {
                Console.WriteLine("\nVime o nem/ni tyhle informace ");
                Console.WriteLine(string.Join("\n", Zajimavosti));
            }
        }

        private void VypisJmenoPolovicky()
        {
            if (!string.IsNullOrEmpty(JmenoPolovicky))
            {
                Console.WriteLine("\nJeho/jeji polovickou je: " + JmenoPolovicky);
            }
        }

        private void VypisVek()
        {
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
                Console.WriteLine("Datum narozeni je: " + DatumNarozeni.ToShortDateString());
                Console.WriteLine($"{Jmeno} ma {vek} let.");
            }
        }
    }
}
