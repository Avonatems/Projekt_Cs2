using System;


namespace CS2___MujProjekt
{
    internal class Program
    {
        enum Moznosti
        {
            PridaniOsoby = 1,
            EditaceOsoby,
            VymazaniOsoby,
            VyhledaniOsoby,
            UkonceniProgramu
        }

        static void Main(string[] args)
        {
            SeznamOsob seznamOsob = new SeznamOsob();
            seznamOsob.NacteniExternihoSeznamu();

            OvladaniKonzole.UvodniHlaska();
            int odpoved = OvladaniKonzole.OdpovedVyberAkce();

            do
            {
                switch (odpoved)
                {
                    case (int)Moznosti.PridaniOsoby:
                        seznamOsob.PridejNovouOsobu();
                        break;

                    case (int)Moznosti.EditaceOsoby:
                        seznamOsob.EditujOsobu();
                        break;

                    case (int)Moznosti.VymazaniOsoby:
                        seznamOsob.VymazOsobu();
                        break;

                    case (int)Moznosti.VyhledaniOsoby:
                        OvladaniKonzole.InformaceOmoznostechUVyhledavaniOsob();
                        int odpovedNaDotaz = OvladaniKonzole.OdpovedVyberAkce();
                        switch (odpovedNaDotaz)
                        {

                            case 1:
                                seznamOsob.VypisVsechnyOsoby();
                                break;

                            case 2:
                                seznamOsob.VyhledejAVypisJednuOsobu();
                                break;

                            default:
                                OvladaniKonzole.HlaskaNeplatnySymbol();
                                break;
                        }
                        break;

                    case (int)Moznosti.UkonceniProgramu:
                        OvladaniKonzole.HlaskaPriUkonceniProgramu();
                        Console.ReadLine();
                        return;

                    default:
                        OvladaniKonzole.HlaskaNeplatnySymbol();
                        break;
                }
                OvladaniKonzole.DotazJakouDalsiAkciProvest();
                odpoved = OvladaniKonzole.OdpovedVyberAkce();
            } while (true);
        }
    }
}


