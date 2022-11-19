using System;


namespace CS2___MujProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SeznamOsob instanceSeznamuOsob = new SeznamOsob();
            string odpovedNaDotazAnoNe = "ano";
            bool breakProWhileCyklus = false;

            instanceSeznamuOsob.NacteniExtSeznamu();

            OvladaniKonzole.UvodniHlaska();
            string odpoved = Console.ReadLine();

            while (breakProWhileCyklus == false)
            {
                switch (odpoved)
                {
                    case "1":
                        // program pokracuje v zadavani udaju o nove osobe
                        instanceSeznamuOsob.PridejNovouOsobu();
                        Console.WriteLine("Chcete pridat dalsi osobu? Zadejte 'ano' nebo zmacknete libovolnou klavesu pro navrat k moznostem vyberu. ");
                        odpovedNaDotazAnoNe = Console.ReadLine();
                        if (odpovedNaDotazAnoNe == "ano")
                        {
                            odpoved = "1";
                        }
                        else
                        {
                            OvladaniKonzole.DotazJakouDalsiAkciProvest();
                            odpoved = Console.ReadLine();
                        }
                        break;

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
                            instanceSeznamuOsob.VypisJedneOsoby();
                            Console.WriteLine("Chcete vyhledat jinou osobu? Zadejte 'ano' nebo zmacknete libovolnou klavesu pro navrat k moznostem vyberu. ");
                            odpovedNaDotaz = Console.ReadLine();
                            while (odpovedNaDotaz == "ano")
                            {
                                Console.WriteLine("Zadejte prijmeni osoby, kterou si prejete vypsat.");
                                instanceSeznamuOsob.VypisJedneOsoby();
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

                    case "5":
                        // program konci
                        Console.WriteLine("Dekujeme, nashledanou.");
                        breakProWhileCyklus = true;
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
