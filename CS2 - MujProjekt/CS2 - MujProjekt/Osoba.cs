using System;
using System.Collections.Generic;

namespace CS2___MujProjekt
{
    public class Osoba
    {

        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string RodnePrijmeni { get; set; }
        public List<string> AlergieNaJidlo { get; } // U žádného z těchto seznamů nepotřebuješ set; OPRAVENE. Je to vyslovene chyba, alebo to len zbytocne berie pamat, alebo..?
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


        public void VypisUdajeOsoby() // co třeba VypisUdajeOsoby ? OPRAVENE
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n___________________________________");
            Console.WriteLine($"{Jmeno} {Prijmeni}, Rodne prijmeni: {RodnePrijmeni}. ");

            // Všechny tyto ify bych refaktoroval do samostatných metod, které budou např. VypisAlergieNaJidlo - OPRAVENE
            VypisAlergieNaJidlo();
            VypisOblibenaJidla();
            VypisJmenaDeti();
            VypisZajimavosti();
            VypisJmenoPolovicky();
            VypisVek();        
            Console.WriteLine("___________________________________");
            Console.ForegroundColor = ConsoleColor.White;
        
        
        }
        public void VypisAlergieNaJidlo()
        {
            if (AlergieNaJidlo.Count > 0)
            {
                Console.WriteLine("Ma tyhle alergie na jidlo: ");
                Console.Write(string.Join(", ", AlergieNaJidlo));
            }
        }

        public void VypisOblibenaJidla()
        {
            if (OblibenaJidla.Count > 0)
            {
                Console.WriteLine("\nMa tyhle oblibena jidla: ");
                Console.Write(string.Join(", ", OblibenaJidla));
            }
        }

        public void VypisJmenaDeti()
        {
            if (JmenaDeti.Count > 0)
            {
                Console.WriteLine("\nMa deti, ktere se jmenujou: ");
                Console.Write(string.Join(", ", JmenaDeti)); // správně by se mělo používat string.Join (string s malým s, protože je to klíčové slovo a nemůže být interpretováno jinak)
                                                             // OPRAVENE
            }
        }

        public void VypisZajimavosti()
        {
            if (Zajimavosti.Count > 0)
            {
                Console.WriteLine("\nVime o nem/ni tyhle informace ");
                // Tohle by šlo také nahradit string.Join - OPRAVENE
                Console.WriteLine(string.Join("\n", Zajimavosti));
            }
        }

        public void VypisJmenoPolovicky()
        {
            if (!string.IsNullOrEmpty(JmenoPolovicky))
            {
                Console.WriteLine("Jeho/jeji polovickou je: " + JmenoPolovicky); // Co když jméno polovičky není?  - OSETRENE
            }
        }

        public void VypisVek()
        {
            // Celý tento kód bych opět refaktoroval do nějaké metody VypisVek().
            // V ní bych použil aritmetiku datového typu DateTime. Zkus si najít co se stane, resp. jaký datový typ
            // se Ti vrátí, když odečteš DateTime od DateTime. ;) Pak se Ti ten výpočet značně zjednodušší.

            // Daniela - presunute do osobitnej metody.
            // No, tu prave neviem ako to spravit. Neviem, ci hovoris o TimeSpan, alebo je este nieco ine? V TimeSpan by to ale nejde prepocitat na roky, max na dni, nie?

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
