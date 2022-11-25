using System;


namespace CS2___MujProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SeznamOsob seznamOsob = new SeznamOsob();
            bool odpovedNaDotazAnoNe = true;

            seznamOsob.NacteniExternihoSeznamu();

            OvladaniKonzole.UvodniHlaska();
            int odpoved = OvladaniKonzole.OdpovedVyberAkce();

            do
            {
                switch (odpoved)
                {
                    case 1:
                        // program pokracuje v zadavani udaju o nove osobe
                        seznamOsob.PridejNovouOsobu();
                        odpovedNaDotazAnoNe = seznamOsob.PrevodAnoNeNaBool(Console.ReadLine());
                        if (odpovedNaDotazAnoNe)
                        {
                            odpoved = 1;
                        }
                        else
                        {
                            OvladaniKonzole.DotazJakouDalsiAkciProvest();
                            odpoved = OvladaniKonzole.OdpovedVyberAkce();
                        }
                        break;
                    case 2:
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

                        int odpovedNaDotaz = OvladaniKonzole.OdpovedVyberAkce();
                        switch (odpovedNaDotaz)
                        {

                            case 1:
                                seznamOsob.VypisVsechnyOsoby();
                                OvladaniKonzole.DotazJakouDalsiAkciProvest();
                                odpoved = OvladaniKonzole.OdpovedVyberAkce();
                                break;

                            case 2:
                                seznamOsob.VyhledejAVypisJednuOsobu();
                                odpovedNaDotazAnoNe = seznamOsob.PrevodAnoNeNaBool(Console.ReadLine());
                                while (odpovedNaDotazAnoNe)
                                {
                                    seznamOsob.VyhledejAVypisJednuOsobu();
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

                    case 5:
                        break;

                    default:
                        // info, ze byl zadan neplatny symbol, a vyzva, aby uzivatel opakoval akci
                        OvladaniKonzole.HlaskaNeplatnySymbol();
                        OvladaniKonzole.DotazJakouDalsiAkciProvest();
                        odpoved = OvladaniKonzole.OdpovedVyberAkce();
                        break;
                }
            } while (odpoved != 5);
            OvladaniKonzole.HlaskaPriUkonceniProgramu();
            Console.ReadLine();
        }
    }
}
