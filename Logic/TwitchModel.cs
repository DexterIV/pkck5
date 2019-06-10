
using System.Collections.Generic;
using System.Xml.Serialization;
using static Model.Tools;
namespace Model
{
    [XmlRoot(ElementName = "Autor")]
    public class Autor
    {
        [XmlElement(ElementName = "Imię")]
        public string Imie { get; set; }
        [XmlElement(ElementName = "Nazwisko")]
        public string Nazwisko { get; set; }
        [XmlAttribute(AttributeName = "Indeks")]
        public string Indeks { get; set; }

        public override string ToString()
        {
            return Indeks + ": " + Imie + " " + Nazwisko;
        }

    }

    [XmlRoot(ElementName = "Autorzy")]
    public class Autorzy
    {
        [XmlElement(ElementName = "Autor")]
        public List<Autor> Autor { get; set; }
    }

    [XmlRoot(ElementName = "Twórca")]
    public class Tworca
    {
        [XmlElement(ElementName = "Nazwa")]
        public string Nazwa { get; set; }
        [XmlElement(ElementName = "Link")]
        public string Link { get; set; }
        [XmlElement(ElementName = "Subskrybenci")]
        public string Subskrybenci { get; set; }
        [XmlElement(ElementName = "ŚredniaObejrzeń")]
        public string SredniaObejrzen { get; set; }
        [XmlAttribute(AttributeName = "Login")]
        public string Login { get; set; }

        public override string ToString()
        {
            return Login + ": " + Nazwa + ", " + Link + ", Subs: " + Subskrybenci + ", Views: " +
                   SredniaObejrzen;
        }
    }

    [XmlRoot(ElementName = "Twórcy")]
    public class Tworcy
    {
        [XmlElement(ElementName = "Twórca")]
        public List<Tworca> Tworca { get; set; }
    }

    [XmlRoot(ElementName = "ZdefiniowanaGra")]
    public class ZdefiniowanaGra
    {
        [XmlAttribute(AttributeName = "Nazwa")]
        public string Nazwa { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "Dostępna")]
        public string Dostepna { get; set; }

        public override string ToString()
        {
            return Id + ": " + Nazwa + " Dostepna: " + Dostepna;
        }
    }

    [XmlRoot(ElementName = "ListaGier")]
    public class ListaGier
    {
        [XmlElement(ElementName = "ZdefiniowanaGra")]
        public List<ZdefiniowanaGra> ZdefiniowanaGra { get; set; }
    }

    [XmlRoot(ElementName = "Język")]
    public class Jezyk
    {
        [XmlAttribute(AttributeName = "Kod")]
        public string Kod { get; set; }
        public override string ToString()
        {
            return Kod;
        }
    }

    [XmlRoot(ElementName = "RodzajKanału")]
    public class RodzajKanalu
    {
        [XmlAttribute(AttributeName = "Typ")]
        public string Typ { get; set; }
        public override string ToString()
        {
            return "Typ: " + Typ;
        }
    }

    [XmlRoot(ElementName = "Kanał")]
    public class Kanal
    {
        [XmlElement(ElementName = "DataPowstania")]
        public string DataPowstania { get; set; }
        [XmlElement(ElementName = "Podmiot")]
        public string Podmiot { get; set; }
        [XmlElement(ElementName = "Język")]
        public Jezyk Jezyk { get; set; }
        [XmlElement(ElementName = "RodzajKanału")]
        public RodzajKanalu RodzajKanalu { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "Nazwa")]
        public string Nazwa { get; set; }
        public override string ToString()
        {
            return ID + ": " + Nazwa + ", " + Podmiot + ", " + DataPowstania + ", "
                   + Jezyk + ", " + RodzajKanalu;
        }

    }

    [XmlRoot(ElementName = "Gra")]
    public class Gra
    {
        [XmlElement(ElementName = "Kanał")]
        public List<Kanal> Kanal { get; set; }
        [XmlAttribute(AttributeName = "IdGry")]
        public string IdGry { get; set; }

        public override string ToString()
        {
            var result = IdGry + ": ";
            foreach (var kanal in Kanal)
            {
                result += WriteTab(1) + kanal.ToString() + "\n";
            }

            return result;
        }
    }

    [XmlRoot(ElementName = "TwitchTV")]
    public class TwitchTV
    {
        [XmlElement(ElementName = "Autorzy")]
        public Autorzy Autorzy { get; set; }
        [XmlElement(ElementName = "Twórcy")]
        public Tworcy Tworcy { get; set; }
        [XmlElement(ElementName = "ListaGier")]
        public ListaGier ListaGier { get; set; }
        [XmlElement(ElementName = "Gra")]
        public List<Gra> Gra { get; set; }

    }

}
