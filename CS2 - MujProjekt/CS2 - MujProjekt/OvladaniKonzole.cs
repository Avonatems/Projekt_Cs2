using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2___MujProjekt
{
    public static class OvladaniKonzole
    {
        public static void UvodniHlaska()
        {
            Console.WriteLine("Tohle je program na evidenci dulezitych faktu o znamych, kolezich atd.");
            Console.WriteLine("Jakou akci chcete provest?\nZadejte \n'1' pokud chcete zapsat novou osobu" +
                "\n'2' pokud chcete doplnit udaje k existujici osobe, \n'3' pokud chcete vymazat osobu, \n'4' " +
                "pokud chcete zobrazit udaje nebo \n'5' jestli chcete program ukoncit. Volbu potvrdte Entrem");
            Console.WriteLine("Vase volba: ");
        }

        public static void DotazJakouDalsiAkciProvest()
        {
            Console.WriteLine("Jakou dalsi akci chcete provest?\nZadejte \n'1' pokud chcete zapsat novou osobu" +
                "\n'2' pokud chcete doplnit udaje k existujici osobe, \n'3' pokud chcete vymazat osobu, \n'4' " +
                "pokud chcete zobrazit udaje nebo \n'5' jestli chcete program ukoncit. Volbu potvrdte Entrem");
            Console.WriteLine("Vase volba: ");
        }
    }
}
