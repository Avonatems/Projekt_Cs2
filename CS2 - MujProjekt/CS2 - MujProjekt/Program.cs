using System;


namespace CS2___MujProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SeznamOsob seznamOsob = new SeznamOsob(); // Nepsal bych instance, ale prostě seznam osob. Ty už víš, co je instance a ostatní to asi budou vědět také. - OPRAVENE
            bool odpovedNaDotazAnoNe = true; // Lepší by bylo použít datový typ bool a mít k tomu nějakou obslužnou třídu/funkci, která Ti převede vstup od uživatele z textu ano/ne na true/false.
                                             // Daniela - zmeneny datovy typ a vytvorena metoda v SeznamOsob. 

            //  bool breakProWhileCyklus = false;   // Tady máš anglické pojmenování. Obecně bych doporučil používat jenom angličtinu, nikdy nevíš, kdo Tvé kódy uvidí a komu je budeš ukazovat. Ale co je špatně, tak je to kombinovat dohromady.
            // Daniela / Ok. diky, noted. Nakoniec som to vyhodila, pretoze som zjednodusila kod, a neni uz tato premenna potrebna.

            seznamOsob.NacteniExternihoSeznamu(); // Asi bych to vypsal celé, tj. nezkracoval to na Ext.  - OPRAVENE

            OvladaniKonzole.UvodniHlaska();
            // string odpoved = Console.ReadLine(); // Jak jsem již psal, tohle volání bych nahradil nějakou statickou metodou, která to přečte z konzolze, ale vrátí Ti číslo.
            // Daniela - skusila som to prerobit, je to nahradene, vid nizsie.
            int odpoved = OvladaniKonzole.OdpovedVyberAkce();

            // Myslím si, že cyklus do {} while() by Ti fungoval na tuto logiku lépe. // Daniela: tento syntax nepoznam, ale vyuzila som tvoj iny navrh nizsie, aby som
            // vyuzila Return na vyskocenie z cyklu.
            while (true) // Tohle není moc dobrá logika. Sice jsi použila za mne lepší zápis, než !breakProWhileCyklus, ale nebylo by lepší, kdybys tohle vůbec nemusela dělat, aby to ten bool fungoval bez toho? Tzn. mít tam rovnou takovou hodnotu, kteoru potřebuji.
                         // Daniela / opravila som to, vratila som while (true), ktory som tam mala predtym, nez som pouzila switch. 
            {
                switch (odpoved)
                {
                    case 1: // ideální dělat switch nad číselnou hodnotou, než nad číslem v textu. - OPRAVENE
                        // program pokracuje v zadavani udaju o nove osobe
                        seznamOsob.PridejNovouOsobu();
                        //  odpovedNaDotazAnoNe = Console.ReadLine(); // Použil bych nějakou pomocnou metodu, co vrátí ten bool. OPRAVENE
                        odpovedNaDotazAnoNe = seznamOsob.PrevodAnoNeNaBool(Console.ReadLine());
                        if (odpovedNaDotazAnoNe) // viz předchozí komentář
                        {
                            odpoved = 1; // Opět - pracoval bych s čísly, ne s číslem v textu. OPRAVENE
                        }
                        else
                        {
                            OvladaniKonzole.DotazJakouDalsiAkciProvest();
                            odpoved = OvladaniKonzole.OdpovedVyberAkce();
                        }
                        break; // Nešlo by to nějak vymyslel, aby tento if/else tady vůbec nemusel být?  // Daniela : No tu mi nenapadol uz ziadny rychly fix :(
                               // Celý obsah tohoto a všech dalších case bych změnil tak, že to dám do nějaké vlastní metody, kde potřebné proměnné budou na vstupu a tady v case uvidím pouze 1 řádek s názvem metody a tu pojmenuji vhodně tak, aby dobře popsala, co se bude v metodě dít.
                    case 2:
                        // program pokracuje k doplneni udaju 
                        seznamOsob.EditujOsobu();
                        odpovedNaDotazAnoNe = seznamOsob.PrevodAnoNeNaBool(Console.ReadLine());
                        if (odpovedNaDotazAnoNe)
                        {
                            odpoved = 2;
                        }
                        else
                        {
                            OvladaniKonzole.DotazJakouDalsiAkciProvest();
                            odpoved = OvladaniKonzole.OdpovedVyberAkce();
                        }
                        break;

                    case 3:
                        // program pokracuje k vymazu osoby
                        seznamOsob.VymazOsobu();
                        odpovedNaDotazAnoNe = seznamOsob.PrevodAnoNeNaBool(Console.ReadLine());
                        if (odpovedNaDotazAnoNe)
                        {
                            odpoved = 3;
                        }
                        else
                        {
                            OvladaniKonzole.DotazJakouDalsiAkciProvest();
                            odpoved = OvladaniKonzole.OdpovedVyberAkce();
                        }
                        break;

                    case 4:
                        // program pokracuje k vyhledavani osob
                        OvladaniKonzole.InformaceOmoznostechUVyhledavaniOsob();
                        // Tady bych opět zkusil použít nějaké ovládání konzole. Je to totiž nekonzistentní. - OPRAVENE
                        // Na jednom místě voláš pomocné metody, které dělají něco podobného, co máš nahoře a tady naopak používáš Console.WriteLine()
                        // napřímo.
                        // Něco podobného jsem říkal i Janě. Jsou to vlastně dvě úrovně detailů. První, vyšší úroveň je Tvá pomocná funkce OvládáníKonzole,
                        // uvnitř voláš Console.WriteLine() a pak tady, ve stejném souboru voláš Console.WriteLine() napřímo.
                        // Ne, že by to nešlo, ne že by to bylo vyloženě špatně, někdy to tak budeš muset mít, ale jde o tu nekonzistenci. Snad to dává trochu smysl.
                        // Daniela - skusila som tie Console.WriteLine() upratat a schovat do funkcii v triede SeznamOsob a OvladaniKonzole.

                        int odpovedNaDotaz = OvladaniKonzole.OdpovedVyberAkce();
                        switch (odpovedNaDotaz)
                        {

                            case 1:
                                seznamOsob.VypisVsechnyOsoby();
                                OvladaniKonzole.DotazJakouDalsiAkciProvest();
                                odpoved = OvladaniKonzole.OdpovedVyberAkce();
                                break;

                            case 2:
                                seznamOsob.VyhledejAVypisJednuOsobu(); // Tohle volání je lehce matoucí.
                                                                       // Tady bych čekal, že tady budou kroky: 1. Zadej nějaký údaj, 2. Najdi kontakt, 3. Vypiš udáje.
                                                                       // Tahle metoda to sice dělá, ale skrytě a to není dobře. Musel jsem si přeskákat přes 2 soubory a 3 metody, abych zjistil, jak to máš namyšlené.

                                // Daniela: No, tu som premyslala, ako to urobit. Ta metoda, co je vnorena, je totiz pouzita i v ostatnych metodach (v PridejNovouOsobu, VymazOsobu, EditujOsobu).
                                // Takze som ju chcela nechat tak ako je, aby bola nadalej pouzitelna i inde. Z toho mi vyplynulo, ze by som musela rozsekat metodu VypisJednuOsobu, alebo? :D
                                // Tak neviem, bolo by riesenim i lepsie popisat metodu, ako som teraz skusila urobit? :D Before: VypisJednuOsobu Now: VyhledejAVypisJednuOsobu
                      


                                odpovedNaDotazAnoNe = seznamOsob.PrevodAnoNeNaBool(Console.ReadLine());
                                while (odpovedNaDotazAnoNe)
                                {
                                    seznamOsob.VyhledejAVypisJednuOsobu(); // Tady se mi to také moc nelíbí. Tady hrozí nebezpečí, že někdo zavolá VyisJedneOsoby() bez toho, aniž by se mu zobrazila ta vyzva na předchozím řádku. Takovým závislostem se snažíme vyhnout.
                                                                  // Daniela: upravila som to, ale neviem, ci takto si to myslel.
                                    odpovedNaDotazAnoNe = seznamOsob.PrevodAnoNeNaBool(Console.ReadLine());
                                }
                                OvladaniKonzole.DotazJakouDalsiAkciProvest();
                                odpoved = OvladaniKonzole.OdpovedVyberAkce();
                                break;

                            default:
                                OvladaniKonzole.HlaskaNeplatnySymbol();
                                break;
                        }                   
                        break;
                    // Celé tohle if/else if/ else bych zase nahradit switchem. Je to opravdu nepřehledné. - OPRAVENE

                    case 5:
                        // program konci
                        OvladaniKonzole.HlaskaPriUkonceniProgramu();
                        // breakProWhileCyklus = true; // Šlo by to zjednodušit tak, že použiješ return a to přímo program ukončí, ale z mých dalších připomínek to asi nevyužiješ.
                        // Daniela: Zjednodusene s Returnom. Uz ked som to prehodila z if/else if na switch, tak som premyslala, ako to zjednodusit, len som o tomto nevedela.
                        Console.ReadLine();
                        return;

                    default:
                        // info, ze byl zadan neplatny symbol, a vyzva, aby uzivatel opakoval akci
                        OvladaniKonzole.HlaskaNeplatnySymbol();
                        OvladaniKonzole.DotazJakouDalsiAkciProvest();
                        odpoved = OvladaniKonzole.OdpovedVyberAkce();
                        break;
                }
            }
        }
    }
}
