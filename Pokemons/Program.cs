using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public class Lospokemons
{
    static string[] pokemon = { "Bulbasaur", "Pikachu", "Charmander", "Onix", "Squirtle", "Jigglypuff", "Meowth", "Psyduck", "Snorlax", "Gengar", "Machop", "Geodude", "Eevee", "Vulpix", "Magikarp" };
    static string[] ashPok = new string[5];
    static string[] garyPok = new string[5];
    static string[] found = new string[1];
    static string player;


    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Press a key to choose the player:\nAsh (Press A)\nGary (Press S)\n");
        ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
        if (KeyInfo.Key == ConsoleKey.A) { player = "Ash"; }
        if (KeyInfo.Key == ConsoleKey.S) { player = "Gary"; }

        ConsoleKeyInfo keyInfo;
        splashScreen();
        InitPokedex();
        do
        {
            Console.Clear();
            menu();
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.W);

    }

    static void splashScreen()
    {
        Console.Clear();
        Console.WriteLine("                                ,'\\\r\n    _.----.        ____         ,'  _\\   ___    ___     ____\r\n_,-'       `.     |    |  /`.   \\,-'    |   \\  /   |   |    \\  |`.\r\n\\      __    \\    '-.  | /   `.  ___    |    \\/    |   '-.   \\ |  |\r\n \\.    \\ \\   |  __  |  |/    ,','_  `.  |          | __  |    \\|  |\r\n   \\    \\/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |\r\n    \\     ,-'/  /   \\    ,'   | \\/ / ,`.|         /  /   \\  |     |\r\n     \\    \\ |   \\_/  |   `-.  \\    `'  /|  |    ||   \\_/  | |\\    |\r\n      \\    \\ \\      /       `-.`.___,-' |  |\\  /| \\      /  | |   |\r\n       \\    \\ `.__,'|  |`-._    `|      |__| \\/ |  `.__,'|  | |   |\r\n        \\_.-'       |__|    `-._ |              '-.|     '-.| |   |\r\n                                `'                            '-._|");
        Console.WriteLine("\n\r\n  _____                                              _                  _                _                _   \r\n |  __ \\                                            | |                | |              | |              | |  \r\n | |__) |_ __  ___  ___  ___    __ _  _ __   _   _  | | __ ___  _   _  | |_  ___    ___ | |_  __ _  _ __ | |_ \r\n |  ___/| '__|/ _ \\/ __|/ __|  / _` || '_ \\ | | | | | |/ // _ \\| | | | | __|/ _ \\  / __|| __|/ _` || '__|| __|\r\n | |    | |  |  __/\\__ \\\\__ \\ | (_| || | | || |_| | |   <|  __/| |_| | | |_| (_) | \\__ \\| |_| (_| || |   | |_ \r\n |_|    |_|   \\___||___/|___/  \\__,_||_| |_| \\__, | |_|\\_\\\\___| \\__, |  \\__|\\___/  |___/ \\__|\\__,_||_|    \\__|\r\n                                              __/ |              __/ |                                        \r\n                                             |___/              |___/                                         \r\n");
        Console.ReadKey(true);
    }

    static void menu()
    {
        Console.WriteLine("\r\n███╗   ███╗ █████╗ ██╗███╗   ██╗    ███╗   ███╗███████╗███╗   ██╗██╗   ██╗\r\n████╗ ████║██╔══██╗██║████╗  ██║    ████╗ ████║██╔════╝████╗  ██║██║   ██║\r\n██╔████╔██║███████║██║██╔██╗ ██║    ██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║\r\n██║╚██╔╝██║██╔══██║██║██║╚██╗██║    ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║\r\n██║ ╚═╝ ██║██║  ██║██║██║ ╚████║    ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝\r\n╚═╝     ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝    ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ \r\n                                                                          \r\n\n");
        Console.WriteLine("Q - Show Team");
        Console.WriteLine("D - Delete Pokemon");
        Console.WriteLine("C - Catch Pokemon");
        Console.WriteLine("W - Exit Game");
        ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
        Console.Clear();
        switch (KeyInfo.Key)
        {
            case ConsoleKey.Q:
                ShowTeam();
                Console.WriteLine("\nPress any key to return to main menu");
                break;
            case ConsoleKey.D:
                DeletePok();
                Console.WriteLine("\nPokemon deleted.\nPress any key to return to main menu");
                break;
            case ConsoleKey.C:
                Explore();
                Console.WriteLine("\nPress any key to return to main menu");
                break;
            case ConsoleKey.W:
                Environment.Exit(0);
                break;
        }

    }

    static void InitPokedex()
    {
        Random random = new Random();
        Random random2 = new Random();
        for (int i = 0; i < ashPok.Length; i++)
        {
            int randomIndex = random.Next(pokemon.Length);
            int randomIndex2 = random2.Next(pokemon.Length);
            ashPok[i] = pokemon[randomIndex];
            garyPok[i] = pokemon[randomIndex2];
        }
    }

    static void ShowTeam()
    {
        switch (player)
        {
            case ("Ash"):
                Console.Clear();
                Console.WriteLine("Ash's Pokemons are: ");
                for (int i = 0; i < ashPok.Length; ++i)
                {
                    string result = String.IsNullOrEmpty(ashPok[i]) ? (i + " - EMPTY , ") : (i + " - " + ashPok[i] + ", ");
                    Console.Write(result);
                }
                Console.WriteLine("\n");
                break;

            case ("Gary"):
                Console.Clear();
                Console.WriteLine("Gary's Pokemons are: ");
                for (int i = 0; i < garyPok.Length; ++i)
                {
                    string result = String.IsNullOrEmpty(garyPok[i]) ? (i + " - EMPTY , ") : (i + " - " + garyPok[i] + ", ");
                    Console.Write(result);
                }
                Console.WriteLine("\n");
                break;
        }
    }

    static void DeletePok()
    {
        ShowTeam();
        Console.WriteLine("Select the position of Pokemon to delete");
        int pos = Convert.ToInt32(Console.ReadLine());

        if (pos >= 0 && pos < ashPok.Length)
        {
            if (!String.IsNullOrEmpty(ashPok[pos]))
            {
                ashPok[pos] = null;
            }
            else
            {
                Console.WriteLine("The position is empty");
            }
        }
        else
        {
            Console.WriteLine("Invalid position");
            Thread.Sleep(750);
        }
    }

    static void AddPokemon(string newPok)
    {
        if (player == "Ash")
        {
            for (int i = 0; i < ashPok.Length; ++i) { Console.Write(ashPok[i] + " " + i + ", "); }
            Console.Write("\n\nIntroduce the position:");
            int posPok = Convert.ToInt32(Console.ReadLine());
            NewPok(ashPok, posPok);
        }
        else if (player == "Gary")
        {
            for (int i = 0; i < garyPok.Length; ++i) { Console.Write(garyPok[i] + " " + i + ", "); }
            Console.Write("\n\nIntroduce the position:");
            int posPok = Convert.ToInt32(Console.ReadLine());
            NewPok(garyPok, posPok);
        }
        else
        {
            ShowTeam();
        }
    }

    static void NewPok(string[] pokemons, int posPok)
    {
        if (posPok >= 0 && posPok < pokemons.Length)
        {
            pokemons[posPok] = found[0];
            ShowTeam();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid position");
            Thread.Sleep(750);
            ShowTeam();
        }
    }

    static void LoadScreen()
    {
        Console.Write("Searching Pokemons... [");
        Thread.Sleep(500);
        for (int i = 0; i < 30; ++i)
        {
            Console.Write("#");
            Thread.Sleep(100);
        }
        Console.Write("]");
        Thread.Sleep(1500);
    }

    static void Explore()
    {
        Console.Clear();
        LoadScreen();
        Random random = new Random();
        Random random2 = new Random();
        int probabilidad = random.Next(0, 100);
        if (probabilidad > 50)
        {
            Console.Clear();
            Console.WriteLine("You found a Pokemon!\n");
            int randomIndex2 = random2.Next(pokemon.Length);
            found[0] = pokemon[randomIndex2];
            Console.WriteLine(Convert.ToString(found[0] + "\n"));
            AddPokemon(found[0]);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("You didn't find anything.\n\nDo you want to try again? Y/N");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Y)
            {
                Explore();
            }
            else
            {
                Console.Clear();
                menu();
            }
        }
    }
}