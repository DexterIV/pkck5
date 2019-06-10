using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace Model
{
    public static class Serialization
    {
        public static TwitchTV DeserializeFile(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TwitchTV));

            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                return (TwitchTV)serializer.Deserialize(reader);
            }            
        }

        public static void SerializeToFile(string filename, TwitchTV root)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TwitchTV));
            TextWriter writer = new StreamWriter(filename);

            serializer.Serialize(writer, root);
            writer.Close();
        }

        public static void TransformXSL(string directory)
        {
            Console.WriteLine("Podaj nazwe przekształcanego pliku: ");
            string toTransform = directory + @Console.ReadLine();
            Console.WriteLine("Podaj nazwe pliku xsl: ");
            string xsl = directory + @Console.ReadLine();
            Console.WriteLine("Podaj nazwe pliku wyjsciowego: ");
            string outFile = directory + @Console.ReadLine();
            XslCompiledTransform myXslTransform = new XslCompiledTransform();
            var settings = new XsltSettings();
            settings.EnableScript = true;
            myXslTransform.Load(xsl, settings, null);
            myXslTransform.Transform(toTransform, outFile);
        }
    }


}
