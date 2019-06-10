using Model;
using System;

namespace TUI
{
    class Program
    {


        public static void PrintTwitch(TwitchTV root)
        {
            int level = 0;
            Console.WriteLine(Tools.WriteTab(level) + "Autorzy: ");
            level++;
            foreach (var autor in root.Autorzy.Autor)
            {
                Console.WriteLine(Tools.WriteTab(level) + autor.Indeks + ": " + autor.Imie + " " + autor.Nazwisko);
            }

            level = 0;
            Console.WriteLine(Tools.WriteTab(level) + "Tworcy: ");
            level++;
            foreach (var tworca in root.Tworcy.Tworca)
            {
                Console.WriteLine(Tools.WriteTab(level) + tworca);
            }

            level = 0;
            Console.WriteLine(Tools.WriteTab(level) + "Zdefiniowane Gry: ");
            level++;
            foreach (var gra in root.ListaGier.ZdefiniowanaGra)
            {
                Console.WriteLine(Tools.WriteTab(level) + gra);
            }

            level = 0;
            Console.WriteLine(Tools.WriteTab(level) + "Gry: ");
            level++;
            foreach (var gra in root.Gra)
            {
                Console.WriteLine(Tools.WriteTab(level) + gra);
            }
        }

        static void Main(string[] args)
        {
            string projectPath = @"..\..\..\";

            var root = Serialization.DeserializeFile(projectPath + @"twitch.xml");

            bool goOn = true;
            while (goOn)
            {
                try
                {

                Console.WriteLine("1.Pokaz wszystko");
                Console.WriteLine("2.Dodaj gre");
                Console.WriteLine("3.Dodaj tworce");
                Console.WriteLine("4.Dodaj kanal;");
                Console.WriteLine("5.Pokaz kanal");
                Console.WriteLine("6.Zapisz");
                Console.WriteLine("7.Wczytaj i uzyj transformacji XSL");
                Console.WriteLine("8.Wyjdz");
                var choice = ReadUserChoice();
                switch (choice)
                {
                    case 1:
                        PrintTwitch(root);
                        break;
                    case 2:
                        Tools.AddGame(root);
                        break;
                    case 3:
                        Tools.AddTworca(root);
                        break;
                    case 4:
                        Tools.AddChannel(root);
                        break;
                    case 5:
                        Console.WriteLine("Podaj ID tworcy");
                        Console.WriteLine(GetById.GetKanalByTworca(root, GetById.GetTworcaById(root, Console.ReadLine())));
                        break;
                    case 6:
                        @Console.WriteLine("Podaj nazwe wyjsciowego pliku");
                        Serialization.SerializeToFile(projectPath + @Console.ReadLine(), root);
                        break;
                    case 7:
                        Serialization.TransformXSL(projectPath);
                        break;
                    case 8:
                        goOn = false;
                        break;
                }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }           
        }

        public static int ReadUserChoice()
        {
            var userInput = Console.ReadKey();

            Console.WriteLine();

            if (char.IsDigit(userInput.KeyChar))
            {
                return int.Parse(userInput.KeyChar.ToString());
            }
            else
            {
                return -1;
            }
        }
    }
}
