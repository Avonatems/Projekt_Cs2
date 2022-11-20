using System;


namespace CS2___MujProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SeznamOsob instanceSeznamuOsob = new SeznamOsob(); // Nepsal bych instance, ale prostě seznam osob. Ty už víš, co je instance a ostatní to asi budou vědět také.
            string odpovedNaDotazAnoNe = "ano"; // Lepší by bylo použít datový typ bool a mít k tomu nějakou obslužnou třídu/funkci, která Ti převede vstup od uživatele z textu ano/ne na true/false.
            bool breakProWhileCyklus = false;   // Tady máš anglické pojmenování. Obecně bych doporučil používat jenom angličtinu, nikdy nevíš, kdo Tvé kódy uvidí a komu je budeš ukazovat. Ale co je špatně, tak je to kombinovat dohromady.

            instanceSeznamuOsob.NacteniExtSeznamu(); // Asi bych to vypsal celé, tj. nezkracoval to na Ext.

            OvladaniKonzole.UvodniHlaska();
            string odpoved = Console.ReadLine(); // Jak jsem již psal, tohle volání bych nahradil nějakou statickou metodou, která to přečte z konzolze, ale vrátí Ti číslo.
    
            // Myslím si, že cyklus do {} while() by Ti fungoval na tuto logiku lépe.
            while (breakProWhileCyklus == false) // Tohle není moc dobrá logika. Sice jsi použila za mne lepší zápis, než !breakProWhileCyklus, ale nebylo by lepší, kdybys tohle vůbec nemusela dělat, aby to ten bool fungoval bez toho? Tzn. mít tam rovnou takovou hodnotu, kteoru potřebuji.
            {
                switch (odpoved)
                {
                    case "1": // ideální dělat switch nad číselnou hodnotou, než nad číslem v textu.
                        // program pokracuje v zadavani udaju o nove osobe
                        instanceSeznamuOsob.PridejNovouOsobu();
                        Console.WriteLine("Chcete pridat dalsi osobu? Zadejte 'ano' nebo zmacknete libovolnou klavesu pro navrat k moznostem vyberu. ");
                        odpovedNaDotazAnoNe = Console.ReadLine(); // Použil bych nějakou pomocnou metodu, co vrátí ten bool.
                        if (odpovedNaDotazAnoNe == "ano") // viz předchozí komentář
                        {
                            odpoved = "1"; // Opět - pracoval bych s čísly, ne s číslem v textu.
                        }
                        else
                        {
                            OvladaniKonzole.DotazJakouDalsiAkciProvest();
                            odpoved = Console.ReadLine();
                        }
                        break; // Nešlo by to nějak vymyslel, aby tento if/else tady vůbec nemusel být?
                        // Celý obsah tohoto a všech dalších case bych změnil tak, že to dám do nějaké vlastní metody, kde potřebné proměnné budou na vstupu a tady v case uvidím pouze 1 řádek s názvem metody a tu pojmenuji vhodně tak, aby dobře popsala, co se bude v metodě dít.
                    case "2":
                        // program pokracuje k doplneni udaju 
                        instanceSeznamuOsob.EditujOsobu();
                        Console.WriteLine("Chcete editovat jinou osobu? Zadejte 'ano' nebo zmacknete libovolnou klavesu pro navrat k moznostem vyberu. ");
                        odpovedNaDotazAnoNe = Console.ReadLine();
                        if (odpovedNaDotazAnoNe == "ano")
                        {
                            odpoved = "2";
                        }
                        else
                        {
                            OvladaniKonzole.DotazJakouDalsiAkciProvest();
                            odpoved = Console.ReadLine();
                        }
                        break;

                    case "3":
                        // program pokracuje k vymazu osoby
                        instanceSeznamuOsob.VymazOsobu();
                        Console.WriteLine("Chcete vymazat jinou osobu? Zadejte 'ano' nebo zmacknete libovolnou klavesu pro navrat k moznostem vyberu. ");
                        odpovedNaDotazAnoNe = Console.ReadLine();
                        if (odpovedNaDotazAnoNe == "ano")
                        {
                            odpoved = "3";
                        }
                        else
                        {
                            OvladaniKonzole.DotazJakouDalsiAkciProvest();
                            odpoved = Console.ReadLine();
                        }
                        break;

                    case "4":
                        // program pokracuje k vyhledavani osob
                        Console.WriteLine("Vybrali jste moznost vyhledavani osob. Prejete si vypis vsech evidovanych osob nebo konkretni osoby?" +
                            "Zadejte '1' pro vypis celeho seznamu nebo '2' pro vypis konkretni osoby.");
                        // Tady bych opět zkusil použít nějaké ovládání konzole. Je to totiž nekonzistentní.
                        // Na jednom místě voláš pomocné metody, které dělají něco podobného, co máš nahoře a tady naopak používáš Console.WriteLine()
                        // napřímo.
                        // Něco podobného jsem říkal i Janě. Jsou to vlastně dvě úrovně detailů. První, vyšší úroveň je Tvá pomocná funkce OvládáníKonzole,
                        // uvnitř voláš Console.WriteLine() a pak tady, ve stejném souboru voláš Console.WriteLine() napřímo.
                        // Ne, že by to nešlo, ne že by to bylo vyloženě špatně, někdy to tak budeš muset mít, ale jde o tu nekonzistenci. Snad to dává trochu smysl.
                        string odpovedNaDotaz = Console.ReadLine();
                        if (odpovedNaDotaz == "1")
                        {
                            instanceSeznamuOsob.VypisVsechnyOsoby();
                            OvladaniKonzole.DotazJakouDalsiAkciProvest();
                            odpoved = Console.ReadLine();
                        }
                        else if (odpovedNaDotaz == "2")
                        {
                            Console.WriteLine("Vybrali jste moznost zobrazeni udaju konkrenti osoby. Zadejte prijmeni osoby, kterou si prejete vypsat.");
                            instanceSeznamuOsob.VypisJedneOsoby(); // Tohle volání je lehce matoucí.
                            // Tady bych čekal, že tady budou kroky: 1. Zadej nějaký údaj, 2. Najdi kontakt, 3. Vypiš udáje.
                            // Tahle metoda to sice dělá, ale skrytě a to není dobře. Musel jsem si přeskákat přes 2 soubory a 3 metody, abych zjistil, jak to máš namyšlené.
                            Console.WriteLine("Chcete vyhledat jinou osobu? Zadejte 'ano' nebo zmacknete libovolnou klavesu pro navrat k moznostem vyberu. ");
                            odpovedNaDotaz = Console.ReadLine();
                            while (odpovedNaDotaz == "ano")
                            {
                                Console.WriteLine("Zadejte prijmeni osoby, kterou si prejete vypsat.");
                                instanceSeznamuOsob.VypisJedneOsoby(); // Tady se mi to také moc nelíbí. Tady hrozí nebezpečí, že někdo zavolá VyisJedneOsoby() bez toho, aniž by se mu zobrazila ta vyzva na předchozím řádku. Takovým závislostem se snažíme vyhnout.
                                Console.WriteLine("Chcete vyhledat jinou osobu? Zadejte 'ano' nebo zmacknete libovolnou klavesu pro navrat k moznostem vyberu. ");
                                odpovedNaDotaz = Console.ReadLine();
                            }
                            OvladaniKonzole.DotazJakouDalsiAkciProvest();
                            odpoved = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Zadali jste neplatny symbol, opakujte volbu.");
                        }
                        break;
                    // Celé tohle if/else if/ else bych zase nahradit switchem. Je to opravdu nepřehledné.

                    case "5":
                        // program konci
                        Console.WriteLine("Dekujeme, nashledanou.");
                        breakProWhileCyklus = true; // Šlo by to zjednodušit tak, že použiješ return a to přímo program ukončí, ale z mých dalších připomínek to asi nevyužiješ.
                        break;

                    default:
                        // info, ze byl zadan neplatny symbol, a vyzva, aby uzivatel opakoval akci
                        Console.WriteLine("Zadali jste neplatny symbol, opakujte volbu.");
                        OvladaniKonzole.DotazJakouDalsiAkciProvest();
                        odpoved = Console.ReadLine();
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
