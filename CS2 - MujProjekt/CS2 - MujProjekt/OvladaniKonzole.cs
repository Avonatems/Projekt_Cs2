using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2___MujProjekt
{
    public static class OvladaniKonzole
    {
        // Ty texty tady jsou dost nepřehledné. Přeformátoval jsem to aspoň do tzn. Here stringů,
        // mrkni do dokumentace nebo na web jaká je přesně syntaxe a k čemu to slouží.
        // Nicméně, napad je to dobrý (OvladaniKonzole), jenom bych si pohlídal, aby ty řádky nebyly duplicitní.
        // Všimni si, jak jsem tento problém vyřešil.
        
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
    }
}
