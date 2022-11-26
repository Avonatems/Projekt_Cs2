using System;

namespace CS2___MujProjekt
{
    public static class OvladaniKonzole
    {
        public static void UvodniHlaska()
        {
            Console.Write("Tohle je program na evidenci dulezitych faktu o znamych, kolezich atd.");
            DotazJakouDalsiAkciProvest();
        }

        public static void DotazJakouDalsiAkciProvest()
        {
            Console.WriteLine(@"
Jakou dalsi akci chcete provest?
Zadejte 
'1' pokud chcete zapsat novou osobu
'2' pokud chcete doplnit udaje k existujici osobe, 
'3' pokud chcete vymazat osobu,
'4' pokud chcete zobrazit udaje nebo 
'5' jestli chcete program ukoncit. Volbu potvrdte Entrem
Vase volba: 
");
        }

        public static int OdpovedVyberAkce()
        {
            string odpovedString = Console.ReadLine();
            int odpoved;
            bool platnaOdpoved = int.TryParse(odpovedString, out odpoved);
            if (platnaOdpoved)
            {
                return odpoved;
            }
            else
            {
                return 0;
            }
        }

        public static void InformaceOmoznostechUVyhledavaniOsob()
        {
            Console.WriteLine("Vybrali jste moznost vyhledavani osob. Prejete si vypis vsech evidovanych osob nebo konkretni osoby?" +
                            "Zadejte '1' pro vypis celeho seznamu nebo '2' pro vypis konkretni osoby.");
        }

        public static void HlaskaPriUkonceniProgramu()
        {
            Console.WriteLine("Dekujeme, nashledanou.");
        }

        public static void HlaskaNeplatnySymbol()
        {
            Console.WriteLine("Zadali jste neplatny symbol, opakujte volbu.");
        }
    }
}
