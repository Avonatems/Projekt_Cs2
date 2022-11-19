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
        string adresarProSeznam;
        string seznamXmlSCestou;

        public SeznamOsob()
        {
            SeznamZnamych = new List<Osoba>();
        }

        public void NacteniExtSeznamu()
        {
            {
                adresarProSeznam = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MujProjektCS2");
                seznamXmlSCestou = Path.Combine(adresarProSeznam, "MujSeznamNaProjekt.xml");

                if (!Directory.Exists(Path.GetDirectoryName(seznamXmlSCestou)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(seznamXmlSCestou));
                }
            }

            using (StreamReader ctecka = new StreamReader(seznamXmlSCestou))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Osoba>));
                SeznamZnamych = serializer.Deserialize(ctecka) as List<Osoba>;
            }
        }

        public void ZapisDoExtSeznamu()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Osoba>));
            using (StreamWriter writer = new StreamWriter(seznamXmlSCestou))
            {
                serializer.Serialize(writer, SeznamZnamych);
            }
        }

        public void PridejNovouOsobu()
        {
            Console.WriteLine("Vybrali jste moznost Zadani nove osoby. Zadejte prijmeni pro overeni, zda se uz osoba v seznamu nenachazi.");
            Osoba kontaktNaPorovnani = VyhledejOsobu();
            if (kontaktNaPorovnani != null)
            {
                Console.WriteLine("Zadali jste existujici kontakt. Pokud presto chcete kontakt zadat, doplnte za prijmeni rozlisovaci znak. Napr. 'Novak-starsi'.");
                Console.WriteLine($"Vyhledana osoba je {kontaktNaPorovnani.Jmeno} {kontaktNaPorovnani.Prijmeni}");
            }

            else
            {
                Kontakt = new Osoba();
                Console.WriteLine("Tenhle kontakt se jeste v seznamu nenachazi.");
                Console.WriteLine("Zadejte prijmeni jeste jednou: ");
                Kontakt.Prijmeni = Console.ReadLine();
                Console.WriteLine("Zadejte jmeno: ");
                Kontakt.Jmeno = Console.ReadLine();
                Console.WriteLine("Zadejte rodne prijemni: ");
                Kontakt.RodnePrijmeni = Console.ReadLine();
                Console.WriteLine("Zadejte alergie na jidlo. Pokud nechcete doplnit zadnou, zadejte 'hotovo'. ");
                string odpovedNaAlergie = Console.ReadLine();
                while (odpovedNaAlergie != "hotovo")
                {
                    Kontakt.AlergieNaJidlo.Add(odpovedNaAlergie);
                    Console.WriteLine("Zadejte dalsi alergii, nebo zadejte 'hotovo'.");
                    odpovedNaAlergie = Console.ReadLine();
                }

                Console.WriteLine("Zadejte oblibena jidla. Pokud nechcete doplnit zadne, zadejte 'hotovo'. ");
                string odpovedNaOblibeneJidlo = Console.ReadLine();
                while (odpovedNaOblibeneJidlo != "hotovo")
                {
                    Kontakt.OblibenaJidla.Add(odpovedNaOblibeneJidlo);
                    Console.WriteLine("Zadejte dalsi oblibene jidlo, nebo zadejte 'hotovo'.");
                    odpovedNaOblibeneJidlo = Console.ReadLine();
                }

                Console.WriteLine("Zadejte jmeno prvniho ditete. Pokud nechcete doplnit zadne, zadejte 'hotovo'. ");
                string odpovedJmenaDeti = Console.ReadLine();
                while (odpovedJmenaDeti != "hotovo")
                {
                    Kontakt.JmenaDeti.Add(odpovedJmenaDeti);
                    Console.WriteLine("Zadejte jmeno dalsiho ditete, nebo zadejte 'hotovo'.");
                    odpovedJmenaDeti = Console.ReadLine();
                }

                Console.WriteLine("Zadejte jmeno polovicky: ");
                Kontakt.JmenoPolovicky = Console.ReadLine();

                Console.WriteLine("Zadejte random fakty. Pokud nechcete doplnit zadne, zadejte 'hotovo'. ");
                string odpovedRandomFakty = Console.ReadLine();
                while (odpovedRandomFakty != "hotovo")
                {
                    Kontakt.RandomFakty.Add(odpovedRandomFakty);
                    Console.WriteLine("Zadejte dalsi fakt, nebo zadejte 'hotovo'.");
                    odpovedRandomFakty = Console.ReadLine();
                }

                Console.WriteLine("Chcete vlozit datum narozeni dane osoby? Zadejte 'ano' nebo 'ne'.");
                string odpovedDatumNarozeni = Console.ReadLine();
                if (odpovedDatumNarozeni == "ano")
                {
                    Console.WriteLine("Zadejte datum narozeni ve formatu mm/dd/rrrr: ");
                    DateTime dateResult;
                    bool zapsaniDatumu = false;

                    while (!zapsaniDatumu)
                    {
                        if (DateTime.TryParse(Console.ReadLine(), out dateResult))
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

                SeznamZnamych.Add(Kontakt);
                ZapisDoExtSeznamu();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nPridali jste nasledujici osobu: ");
                Console.ForegroundColor = ConsoleColor.White;
                Kontakt.VypisUdajeOOsobe();
                VypisVsechnyOsoby();
            }
        }

        public void VymazOsobu()
        {
            VypisVsechnyOsoby();

            Console.WriteLine("Vybrali jste moznost vymazu osoby. Zadejte prijmeni osoby, kterou si prejete smazat.");
            Kontakt = VyhledejOsobu();
            if (Kontakt == null)
            {
                Console.WriteLine("Zadali jste neexistujici kontakt.");
            }
            else
            {
                Console.WriteLine($"Vyhledana osoba je: \n");

                Kontakt.VypisUdajeOOsobe();
                Console.WriteLine("Prejete si vymazat dany kontakt? Zadejte 'ano' nebo 'ne'. ");
                string odpovedNaDotaz = Console.ReadLine();
                if (odpovedNaDotaz != "ano")
                {
                    Console.WriteLine("Akce vymazani neprobehla.");
                }
                else
                {
                    SeznamZnamych.Remove(Kontakt);
                    ZapisDoExtSeznamu();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Osoba {Kontakt.Jmeno} {Kontakt.Prijmeni} byla vymazana ze seznamu.");
                    Console.ForegroundColor = ConsoleColor.White;
                    VypisVsechnyOsoby();
                }
            }
        }

        public void EditujOsobu()
        {
            VypisVsechnyOsoby();

            Console.WriteLine("Vybrali jste moznost doplneni udaju. Zadejte prijmeni osoby, kterou si prejete editovat.");
            Kontakt = VyhledejOsobu();

            if (Kontakt == null)
            {
                Console.WriteLine("Zadali jste neexistujici kontakt.");
            }
            else
            {
                Console.WriteLine($"Vyhledana osoba je: ");
                Kontakt.VypisUdajeOOsobe();

                Console.WriteLine("Prejete si editovat dany kontakt? Zadejte 'ano' nebo 'ne'. ");
                string odpovedNaDotaz = Console.ReadLine();
                if (odpovedNaDotaz == "ano")
                {
                    Console.WriteLine("Zadejte nove prijmeni osoby. Pokud ho nechcete menit, zadejte 'hotovo'. ");
                    odpovedNaDotaz = Console.ReadLine();
                    if (odpovedNaDotaz != "hotovo")
                    {
                        Kontakt.Prijmeni = odpovedNaDotaz;
                    }

                    Console.WriteLine("Zadejte alergii na jidlo. Pokud nechcete doplnit zadnou, zadejte 'hotovo'. ");
                    odpovedNaDotaz = Console.ReadLine();
                    while (odpovedNaDotaz != "hotovo")
                    {
                        Kontakt.AlergieNaJidlo.Add(odpovedNaDotaz);
                        Console.WriteLine("Zadejte alergii na jidlo. Pokud nechcete doplnit dalsi, zadejte 'hotovo'. ");
                        odpovedNaDotaz = Console.ReadLine();
                    }

                    Console.WriteLine("Zadejte oblibene jidlo. Pokud nechcete doplnit zadne, zadejte 'hotovo'.");
                    odpovedNaDotaz = Console.ReadLine();
                    while (odpovedNaDotaz != "hotovo")
                    {
                        Kontakt.OblibenaJidla.Add(odpovedNaDotaz);
                        Console.WriteLine("Zadejte dalsi jidlo. Pokud nechcete doplnit zadne, zadejte 'hotovo'. ");
                        odpovedNaDotaz = Console.ReadLine();
                    }

                    Console.WriteLine("Doplnte jmena deti. Pokud nechcete doplnit zadne, zadejte 'hotovo'. ");
                    odpovedNaDotaz = Console.ReadLine();
                    while (odpovedNaDotaz != "hotovo")
                    {
                        Kontakt.JmenaDeti.Add(odpovedNaDotaz);
                        Console.WriteLine("Pridejte dalsi jmeno. Pokud nechcete doplnit zadne, zadejte 'hotovo'. ");
                        odpovedNaDotaz = Console.ReadLine();
                    }

                    Console.WriteLine("Zmente jmeno polovicky. Pokud ho nechcete menit, zadejte 'hotovo'. ");
                    odpovedNaDotaz = Console.ReadLine();
                    if (odpovedNaDotaz != "hotovo")
                    {
                        Kontakt.JmenoPolovicky = odpovedNaDotaz;
                    }

                    Console.WriteLine("Doplnte random fakty. Pokud nechcete doplnit zadne, zadejte 'hotovo'.  ");
                    odpovedNaDotaz = Console.ReadLine();
                    while (odpovedNaDotaz != "hotovo")
                    {
                        Kontakt.RandomFakty.Add(odpovedNaDotaz);
                        Console.WriteLine("Pridejte dalsi fakt. Pokud nechcete doplnit zadne, zadejte 'hotovo'. ");
                        odpovedNaDotaz = Console.ReadLine();
                    }

                    Console.WriteLine("Chcete doplnit datum narozeni? Zadejte 'ano' nebo 'ne'. ");
                    odpovedNaDotaz = Console.ReadLine();
                    if (odpovedNaDotaz == "ano")
                    {
                        Console.WriteLine("Zadejte datum narozeni ve formatu mm/dd/rrrr: ");
                        DateTime dateResult;
                        bool zapsaniDatumu = false;

                        while (!zapsaniDatumu)
                        {
                            if (DateTime.TryParse(Console.ReadLine(), out dateResult))
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


                    Console.WriteLine($"Zmenili jste kontakt {Kontakt.Jmeno} {Kontakt.Prijmeni} nasledovne:\n\n\n *****");
                    ZapisDoExtSeznamu();
                    Kontakt.VypisUdajeOOsobe();
                }
            }
        }

        public Osoba VyhledejOsobu()
        {
            string prijmeniOsoby = Console.ReadLine();
            Kontakt = SeznamZnamych.Find(o => o.Prijmeni.Equals(prijmeniOsoby, StringComparison.OrdinalIgnoreCase));
            return Kontakt;
        }


        public void VypisJedneOsoby()
        {
            Kontakt = VyhledejOsobu();
            if (Kontakt != null)
            {
                Console.WriteLine($"Vyhledana osoba je: ");
                Kontakt.VypisUdajeOOsobe();
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
    }

}

