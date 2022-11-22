using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
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

        public void NacteniExternihoSeznamu()
        {
            adresarProSeznam = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MujProjektCS2");
            seznamXmlSCestou = Path.Combine(adresarProSeznam, "MujSeznamNaProjekt.xml");

            if (!Directory.Exists(adresarProSeznam))
            {
                Directory.CreateDirectory(adresarProSeznam);
                return;
            }

            if (!File.Exists(seznamXmlSCestou)) return;

            using (var ctecka = new StreamReader(seznamXmlSCestou))
            {
                var serializer = new XmlSerializer(typeof(List<Osoba>));
                SeznamZnamych = serializer.Deserialize(ctecka) as List<Osoba>;
            }
        }

        public void ZapisDoExternihoSeznamu()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Osoba>));
            using (StreamWriter writer = new StreamWriter(seznamXmlSCestou))
            {
                serializer.Serialize(writer, SeznamZnamych);
            }
        }

        public void PridejNovouOsobu()
        {
            // Celé tohle bych zjednodušil a šel bych tímto postupem:
            // 1. Vytvořil bych osobu (o vytvoření ještě níže)
            // 2. Zkontroloval bych, jestli už v seznamu je, pokud opravdu chceš kontrolovat. Je sice málo pravděpodobné, že budeš mít 2 kamarády stejného jméno i příjmení a stejného data narození, ale myslím, že je to úplně v pořádku.
            //    Nicméně, pokud chceš kontrolovat, tak bych to prostě zkontroloval a pokud tam je, tak prostě chyba a return.
            // 3. Přidal bych osobu.

            // Pro přidání bych postupoval iterativně, ale nepoužíval bych cykly.
            // Pokud chce někdo přidat alergie, tak by to mohl přidat např. pomocí "lepek, sójá, mléko" a rozdělil bych to podle čárky na 3 alergie a přidal.
            // A pokud uživatel zadá prázdný řetězec (nic nenapíše a dá prostě enter), tak bych to bral jako OK, žádné nejsou a šel bych dál.
            // Díky tomu se Ti to značně zjednodušší.
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

                Console.WriteLine("Zmente jmeno polovicky. Pokud ho nechcete zadat, zadejte 'hotovo'. ");
                string odpovedNaDotaz = Console.ReadLine();
                if (odpovedNaDotaz != "hotovo")
                {
                    Kontakt.JmenoPolovicky = odpovedNaDotaz;
                }

                Console.WriteLine("Zadejte zajimavost. Pokud nechcete doplnit zadnou, zadejte 'hotovo'. ");
                string odpovedRandomFakty = Console.ReadLine();
                while (odpovedRandomFakty != "hotovo")
                {
                    Kontakt.Zajimavosti.Add(odpovedRandomFakty);
                    Console.WriteLine("Zadejte dalsi zajimavost, nebo zadejte 'hotovo'.");
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
                ZapisDoExternihoSeznamu();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nPridali jste nasledujici osobu: ");
                Console.ForegroundColor = ConsoleColor.White;
                Kontakt.VypisUdajeOsoby();
                VypisVsechnyOsoby();

               

            }
            Console.WriteLine("Chcete pridat dalsi osobu? Zadejte 'ano' nebo zmacknete libovolnou klavesu pro navrat k moznostem vyberu. ");
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
            Console.WriteLine("Chcete vymazat jinou osobu? Zadejte 'ano' nebo zmacknete libovolnou klavesu pro navrat k moznostem vyberu. ");
        }

        public void EditujOsobu()
        {
            VypisVsechnyOsoby();

            Console.WriteLine("Vybrali jste moznost doplneni udaju. Zadejte prijmeni osoby, kterou si prejete editovat.");
            Kontakt = VyhledejOsobu();

            if (Kontakt == null)
            {
                Console.WriteLine("Zadali jste neexistujici kontakt.");
                // Tady když dáš return; do tak vůbec nepotřebuješ ten else.
            }
            else
            {
                Console.WriteLine($"Vyhledana osoba je: ");
                Kontakt.VypisUdajeOsoby();

                // Tahle otázka je zbytečné. Uživatel si už jednou zvolil editaci osoby, tak budiž.
                // Už bych se na to znova neptal a normálně pokračoval.
                Console.WriteLine("Prejete si editovat dany kontakt? Zadejte 'ano' nebo 'ne'. ");
                string odpovedNaDotaz = Console.ReadLine();
                if (odpovedNaDotaz == "ano")
                {
                    // Změnil bych to na to jednodušší: Pokud se zadá prázdný řetězec, nic se nezmění, pokud něco zadá, tak se to upraví.
                    // Dá se to napsat jednoduše
                    // string odpoved = Console.ReadLine();
                    // Kontakt.Prijmeni = odpoved == "" ? Kontakt.Prijmeni : odpoved;
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
                        Kontakt.Zajimavosti.Add(odpovedNaDotaz);
                        Console.WriteLine("Pridejte dalsi fakt. Pokud nechcete doplnit zadne, zadejte 'hotovo'. ");
                        odpovedNaDotaz = Console.ReadLine();
                    }

                    // Zase bych to jednodušil.
                    // Postupoval bych takto:
                    // 1. Vypsal bych: Napište datum ve formátu mm/dd/rrrr, nebo pokračujte Enterem.
                    // Pokud Enter (prázdný string), pokračoval bych a nic nepřepisoval.
                    // Pokud uživatel něco zadal, zkusil bych zparsovat.
                    // Pokud uspěch, vrátil bych datum.
                    // Pokud to selže, opakoval bych vstup.
                    // Pokud Enter...
                    // Vidíš, že je to cyklus. Dá se to napsat nějakou funkcí jako tato.
                    /*DateTime? GetDate()
                    {
                        DateTime? result = null;
                        string userInput;
                        do
                        {
                            userInput = Console.ReadLine();
                            if (userInput == "")
                            {
                                return result;
                            }
                        } while (!DateTime.TryParseExact(userInput, "mm/dd/yyyy", Thread.CurrentThread.CurrentCulture, DateTimeStyles.AssumeLocal , out result));
                    };
                    Kontakt.DatumNarozeni = GetDate() ?? Kontakt.DatumNarozeni;*/
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
                    ZapisDoExternihoSeznamu();
                    Kontakt.VypisUdajeOsoby();
                }
            }
            Console.WriteLine("Chcete editovat jinou osobu? Zadejte 'ano' nebo zmacknete libovolnou klavesu pro navrat k moznostem vyberu. ");
        }

        public Osoba VyhledejOsobu()
        {
            string prijmeniOsoby = Console.ReadLine(); // Tady asi nebudu vědět, na co se mne ptáš.
            Kontakt = SeznamZnamych.Find(o => o.Prijmeni.Equals(prijmeniOsoby, StringComparison.OrdinalIgnoreCase));
            return Kontakt;
        }


        public void VyhledejAVypisJednuOsobu()
        {
            Console.WriteLine("Vybrali jste moznost zobrazeni udaju konkretni osoby. Zadejte prijmeni osoby, kterou si prejete vypsat.");
            Kontakt = VyhledejOsobu();
            if (Kontakt != null)
            {
                Console.WriteLine($"Vyhledana osoba je: ");
                Kontakt.VypisUdajeOsoby();
            }
            else
            {
                Console.WriteLine("Zadali jste neexistujici kontakt.");
            }
            Console.WriteLine("Chcete vyhledat jinou osobu? Zadejte 'ano' nebo zmacknete libovolnou klavesu pro navrat k moznostem vyberu. ");
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

        public bool PrevodAnoNeNaBool(string odpovedUzivatela)
        {
            if (odpovedUzivatela == "ano")
            {
                return true;
            }
            return false;
        }
    }

}

