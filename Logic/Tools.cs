using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Logic
{
    public static class Tools
    {
        public static string WriteTab(int howMany)
        {
            return new string('\t', howMany);
        }


        
        public static void AddGame(TwitchTV root)
        {
            Console.WriteLine("Podaj kolejno nazwe, id i dostepnosc gry: ");
            ZdefiniowanaGra gra = new ZdefiniowanaGra();
            gra.Nazwa = Console.ReadLine();
            if(gra.Nazwa.Length < 3)
                throw new Exception("Invalid Name");
            string id = Console.ReadLine();
            gra.Id = id;
            if (gra.Id == "")
                gra.Id = gra.Nazwa.Substring(0, 3).ToUpper();
            gra.Dostepna = Convert.ToBoolean(Console.ReadLine()).ToString().ToLower();

            root.ListaGier.ZdefiniowanaGra.Add(gra);
            Gra gra1 = new Gra();
            gra1.IdGry = id;
            gra1.Kanal = new List<Kanal>();
            root.Gra.Add(gra1);
            
        }

        public static void AddChannel(TwitchTV root)
        {
            Console.WriteLine("Podaj id gry: ");
            string idGame = Console.ReadLine();
            Console.WriteLine("Podaj id gracza: ");
            string idArtist = Console.ReadLine();
            if (GetById.GetGra(root, idGame) == null || GetById.GetTworcaById(root, idArtist) == null)
                throw new Exception("Gra lub tworca nie istnieja");
            Console.WriteLine("Podaj kolejno ID, data, podmiot, jezyk, rodzaj kanalu: ");
            Kanal kanal = new Kanal();
            kanal.ID = idArtist;
            kanal.DataPowstania = Console.ReadLine();
            kanal.Podmiot = Console.ReadLine();
            Jezyk jez = new Jezyk();
            jez.Kod = Console.ReadLine();
            RodzajKanalu rod = new RodzajKanalu();
            rod.Typ = Console.ReadLine();
            kanal.Jezyk = jez;
            kanal.RodzajKanalu = rod;


            GetById.GetGra(root, idGame).Kanal.Add(kanal);
        }

        public static void AddTworca(TwitchTV root)
        {
            Console.WriteLine("Podaj kolejno login, nazwa, link, #subów, œr. obejrzeñ: ");
            Tworca tw = new Tworca();
            tw.Login = Console.ReadLine();
            tw.Nazwa = Console.ReadLine();
            tw.Link = Console.ReadLine();
            tw.Subskrybenci = Console.ReadLine();
            tw.SredniaObejrzen = Console.ReadLine();

            root.Tworcy.Tworca.Add(tw);
        }
    }
}
