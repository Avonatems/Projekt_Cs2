using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CS2___MujProjekt
{
    public class SeznamOsob
    {
        public List<Osoba> SeznamZnamych;
        public Osoba Kontakt;
        string adresarProSeznam = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MujProjektCS2");
        string nazevXmlSouboru = "MujSeznamNaProjekt.xml";

        public SeznamOsob()
        {
            SeznamZnamych = new List<Osoba>();
        }

        public void NacteniExternihoSeznamu()
        {
            string seznamXmlSCestou = Path.Combine(adresarProSeznam, nazevXmlSouboru);

            if (!Directory.Exists(adresarProSeznam))
            {
                Directory.CreateDirectory(adresarProSeznam);
                return;
            }

            if (!File.Exists(seznamXmlSCestou))
            {
                return;
            }

            using (var ctecka = new StreamReader(seznamXmlSCestou))
            {
                var serializer = new XmlSerializer(typeof(List<Osoba>));
                SeznamZnamych = serializer.Deserialize(ctecka) as List<Osoba>;
            }
        }

        private void ZapisDoExternihoSeznamu()
        {
            string seznamXmlSCestou = Path.Combine(adresarProSeznam, nazevXmlSouboru);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Osoba>));
            using (StreamWriter writer = new StreamWriter(seznamXmlSCestou))
            {
                serializer.Serialize(writer, SeznamZnamych);
            }
        }

        public void PridejNovouOsobu()
        {
            string uvodniDotaz = "Vybrali jste moznost Zadani nove osoby. Zadejte prijmeni pro overeni, zda se uz osoba v seznamu nenachazi.";
            Osoba kontaktNaPorovnani = VyhledejOsobu(uvodniDotaz);
            if (kontaktNaPorovnani != null)
            {
                Console.WriteLine("Zadali jste existujici kontakt. Pokud presto chcete kontakt zadat, doplnte za prijmeni rozlisovaci znak. Napr. 'Novak-starsi'.");
                Console.WriteLine($"Vyhledana osoba je {kontaktNaPorovnani.Jmeno} {kontaktNaPorovnani.Prijmeni}");
                return;
            }
            Kontakt = new Osoba();
            Console.WriteLine("Tenhle kontakt se jeste v seznamu nenachazi.");
            Console.WriteLine("Zadejte prijmeni jeste jednou: ");
            Kontakt.Prijmeni = Console.ReadLine();

            Console.WriteLine("Zadejte jmeno: ");
            Kontakt.Jmeno = Console.ReadLine();

            Console.WriteLine("Zadejte rodne prijemni: ");
            Kontakt.RodnePrijmeni = Console.ReadLine();

            Console.WriteLine("Zadejte alergie na jidlo. Kazdou alergii oddelte carkou. Pokud nechcete doplnit zadnou, stisknete Enter. ");
            string odpovedNaAlergie = Console.ReadLine();
            DoplnUdajeDoKonkretnihoSeznamu(odpovedNaAlergie, Kontakt.AlergieNaJidlo);

            Console.WriteLine("Zadejte oblibena jidla. Kazde jidlo oddelte carkou. Pokud nechcete doplnit zadne, stisknete Enter. ");
            string odpovedNaOblibeneJidlo = Console.ReadLine();
            DoplnUdajeDoKonkretnihoSeznamu(odpovedNaOblibeneJidlo, Kontakt.OblibenaJidla);

            Console.WriteLine("Zadejte jmena deti. Kazde jmeno oddelte carkou. Pokud nechcete doplnit zadne, stisknete Enter. ");
            string odpovedJmenaDeti = Console.ReadLine();
            DoplnUdajeDoKonkretnihoSeznamu(odpovedJmenaDeti, Kontakt.JmenaDeti);

            Console.WriteLine("Zadejte jmeno polovicky. Pokud ho nechcete zadat, stisknete Enter. ");
            Kontakt.JmenoPolovicky = Console.ReadLine();

            Console.WriteLine("Zadejte zajimavosti o osobe. Kazdou oddelte carkou. Pokud nechcete doplnit zadnou, stisknete Enter. ");
            string odpovedZajimavosti = Console.ReadLine();
            DoplnUdajeDoKonkretnihoSeznamu(odpovedZajimavosti, Kontakt.Zajimavosti);

            VlozDatumNarozeni();

            SeznamZnamych.Add(Kontakt);
            ZapisDoExternihoSeznamu();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nPridali jste nasledujici osobu: ");
            Console.ForegroundColor = ConsoleColor.White;
            Kontakt.VypisUdajeOsoby();
            VypisVsechnyOsoby();
        }

        public void EditujOsobu()
        {
            VypisVsechnyOsoby();

            string uvodniDotaz = "Vybrali jste moznost doplneni udaju. Zadejte prijmeni osoby, kterou si prejete editovat.";
            Kontakt = VyhledejOsobu(uvodniDotaz);

            if (Kontakt == null)
            {
                Console.WriteLine("Zadali jste neexistujici kontakt.");
                return;
            }

            Console.WriteLine($"Vyhledana osoba je: ");
            Kontakt.VypisUdajeOsoby();

            Console.WriteLine("Zadejte nove prijmeni osoby. Pokud ho nechcete menit, stisknete Enter. ");
            string odpovedNaDotaz = Console.ReadLine();
            if (!string.IsNullOrEmpty(odpovedNaDotaz))
            {
                Kontakt.Prijmeni = odpovedNaDotaz;
            }

            Console.WriteLine("Zadejte alergii na jidlo. Pokud nechcete doplnit zadnou, stisknete Enter. ");
            string odpovedNaAlergie = Console.ReadLine();
            DoplnUdajeDoKonkretnihoSeznamu(odpovedNaAlergie, Kontakt.AlergieNaJidlo);

            Console.WriteLine("Zadejte oblibene jidlo. Kazde jidlo oddelte carkou. Pokud nechcete doplnit zadne, stisknete Enter. ");
            string odpovedNaOblibeneJidlo = Console.ReadLine();
            DoplnUdajeDoKonkretnihoSeznamu(odpovedNaOblibeneJidlo, Kontakt.OblibenaJidla);

            Console.WriteLine("Doplnte jmena deti. Kazde jmeno oddelte carkou. Pokud nechcete doplnit zadne, stisknete Enter. ");
            string odpovedJmenaDeti = Console.ReadLine();
            DoplnUdajeDoKonkretnihoSeznamu(odpovedJmenaDeti, Kontakt.JmenaDeti);

            Console.WriteLine("Zmente jmeno polovicky.Pokud ho nechcete menit, stisknete Enter.");
            Kontakt.JmenoPolovicky = Console.ReadLine();

            Console.WriteLine("Doplnte zajimavosti o osobe. Kazdou oddelte carkou. Pokud nechcete doplnit zadnou, stisknete Enter. ");
            string odpovedZajimavosti = Console.ReadLine();
            DoplnUdajeDoKonkretnihoSeznamu(odpovedZajimavosti, Kontakt.Zajimavosti);

            VlozDatumNarozeni();

            Console.WriteLine($"Zmenili jste kontakt {Kontakt.Jmeno} {Kontakt.Prijmeni} nasledovne:\n\n\n *****");
            ZapisDoExternihoSeznamu();
            Kontakt.VypisUdajeOsoby();
        }

        public void VymazOsobu()
        {
            VypisVsechnyOsoby();

            string uvodniDotaz = "Vybrali jste moznost vymazu osoby. Zadejte prijmeni osoby, kterou si prejete smazat.";
            Kontakt = VyhledejOsobu(uvodniDotaz);
            if (Kontakt == null)
            {
                Console.WriteLine("Zadali jste neexistujici kontakt.");
            }
            else
            {
                Console.WriteLine($"Vyhledana osoba je: \n");

                Kontakt.VypisUdajeOsoby();
                Console.WriteLine("Prejete si vymazat dany kontakt? Zadejte 'ano' nebo 'ne'. ");
                string odpovedNaDotaz = Console.ReadLine();
                if (odpovedNaDotaz != "ano")
                {
                    Console.WriteLine("Akce vymazani neprobehla.");
                }
                else
                {
                    SeznamZnamych.Remove(Kontakt);
                    ZapisDoExternihoSeznamu();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Osoba {Kontakt.Jmeno} {Kontakt.Prijmeni} byla vymazana ze seznamu.");
                    Console.ForegroundColor = ConsoleColor.White;
                    VypisVsechnyOsoby();
                }
            }
        }
      
        public void VyhledejAVypisJednuOsobu()
        {
            string uvodniDotaz = "Vybrali jste moznost zobrazeni udaju konkretni osoby. Zadejte prijmeni osoby, kterou si prejete vypsat.";
            Kontakt = VyhledejOsobu(uvodniDotaz);
            if (Kontakt != null)
            {
                Console.WriteLine($"Vyhledana osoba je: ");
                Kontakt.VypisUdajeOsoby();
            }
            else
            {
                Console.WriteLine("Zadali jste neexistujici kontakt.");
            }
        }

        public void VypisVsechnyOsoby()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n*******");
            Console.WriteLine("Seznam obsahuje tyhle osoby:");
            Console.WriteLine("*******\n");
            foreach (var osoba in SeznamZnamych.OrderBy(o => o.Prijmeni))
            {
                Console.WriteLine(osoba.Prijmeni);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private Osoba VyhledejOsobu(string uvodniDotaz)
        {
            Console.WriteLine(uvodniDotaz);
            string prijmeniOsoby = Console.ReadLine();
            Kontakt = SeznamZnamych.Find(o => o.Prijmeni.Equals(prijmeniOsoby, StringComparison.OrdinalIgnoreCase));
            return Kontakt;
        }

        private void DoplnUdajeDoKonkretnihoSeznamu(string odpovedNaDotaz, List<string> seznamDanychUdaju)
        {
            if (!string.IsNullOrEmpty(odpovedNaDotaz))
            {
                foreach (string slovo in odpovedNaDotaz.Split(','))
                {
                    seznamDanychUdaju.Add(slovo);
                }
            }
        }

        private void VlozDatumNarozeni()
        {
            Console.WriteLine("Zadejte datum dane osoby ve formatu mm/dd/rrrr, nebo stisknete Enter pokud ho nechcete zadat ted.");
            string odpovedDatumNarozeni = Console.ReadLine();
            DateTime dateResult;
            bool zapsaniDatumu = false;

            if (!string.IsNullOrEmpty(odpovedDatumNarozeni))
               {
                while (!zapsaniDatumu)
                {
                    if (DateTime.TryParse(odpovedDatumNarozeni, out dateResult))
                    {
                        Kontakt.DatumNarozeni = dateResult;
                        zapsaniDatumu = true;
                    }
                    else
                    {
                        Console.WriteLine("Zadali jste nespravny format.");
                        Console.WriteLine("Zadejte datum narozeni ve formatu mm/dd/rrrr: ");
                    }
                }
            }
        }
    }
}

