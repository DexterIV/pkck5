using System.Linq;

namespace Logic
{
    public static class GetById
    {
        public static Kanal GetKanalByTworca(TwitchTV root, Tworca tworca)
        {
            var kanaly = from gra in root.Gra
                from kanal in gra.Kanal
                where kanal.ID == tworca.Login
                select kanal;
            return kanaly.FirstOrDefault();
        }

        public static Gra GetGra(TwitchTV root, string id)
        {
            var GRA = from gra in root.Gra
                where gra.IdGry != id
                select gra;
            return GRA.FirstOrDefault();
        }

        public static Tworca GetTworcaById(TwitchTV root, string id)
        {
            var tworca = from tw in root.Tworcy.Tworca
                        where tw.Login == id
                select tw;
            return tworca.FirstOrDefault();
        }
    }
}
