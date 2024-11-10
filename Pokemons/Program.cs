using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

public class Lospokemons
{
    static string[,] pokemon = {
    { "Bulbasaur", "0" },
    { "Pikachu", "1" },
    { "Charmander", "0" },
    { "Onix", "0" },
    { "Squirtle", "0" },
    { "Jigglypuff", "0" },
    { "Meowth", "0" },
    { "Psyduck", "0" },
    { "Snorlax", "0" },
    { "Gengar", "0" },
    { "Machop", "0" },
    { "Geodude", "0" },
    { "Eevee", "0" },
    { "Vulpix", "0" },
    { "Magikarp", "1" }
};

    static string[,] moves = {
    { "Tackle", "1" },
    { "Ember", "5" },
    { "Quick Attack", "10" },
    { "Water Gun", "15" },
    { "Vine Whip", "20" },
    { "Thunderbolt", "25" },
    { "Scratch", "30" },
    { "Flamethrower", "35" },
    { "Ice Beam", "40" },
    { "Earthquake", "45" },
    { "Pound", "50" },
    { "Dragon Claw", "55" },
    { "Surf", "60" },
    { "Shadow Ball", "65" },
    { "Hyper Beam", "70" },
    { "Leaf Blade", "75" },
    { "Solar Beam", "80" },
    { "Sludge Bomb", "85" },
    { "Iron Tail", "90" },
    { "Hyper Fang", "95" },
    { "Thunder", "100" }
};
    static string[,] ashPok = new string[5, 2];
    static string[,] garyPok = new string[5, 2];
    static string[,] ashMove = new string[15, 3];
    static string[,] garyMove = new string[15, 3];
    static string[,] found = new string[1, 1];
    static string player;
    static int ashPower = 0;
    static int garyPower = 0;
    static string shiny = "";
    static int poknum = 1;

    public static void Main(string[] args)
    {
        Character();

        static void Character()
        {
            Console.Clear();
            Console.WriteLine("Press a key to choose the player:\nAsh (Press A)\nGary (Press S)\n");
            ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
            if (KeyInfo.Key == ConsoleKey.A) { player = "Ash"; }
            else if (KeyInfo.Key == ConsoleKey.S) { player = "Gary"; }
            else { Character(); }
        }

        ConsoleKeyInfo keyInfo;
        splashScreen();
        InitPokedex();
        InitMove();
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
                Console.Clear();
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
        for (int i = 0; i < ashPok.GetLength(0); i++)
        {
            for (int j = 0; j < pokemon.GetLength(1); j++)
            {
                int randomIndexAsh = random.Next(pokemon.GetLength(0));
                int randomIndexGary = random.Next(pokemon.GetLength(0));
                ashPok[i, j] = pokemon[randomIndexAsh, j];
                garyPok[i, j] = pokemon[randomIndexGary, j];
            }
        }
    }

    static void InitMove()
    {
        Random random = new Random();
        Random random2 = new Random();
        for (int l = 0; l < ashMove.GetLength(0); l++)
        {
            for (int k = 0; k < moves.GetLength(1); k++)
            {
                int random2IndexMoveash = random.Next(moves.GetLength(0));
                int random2IndexMovegary = random.Next(moves.GetLength(0));
                ashMove[l, k] = moves[random2IndexMoveash, k];
                garyMove[l, k] = moves[random2IndexMovegary, k];
                if (poknum < 8)
                {
                    ashMove[l, 2] = "1";
                    garyMove[l, 2] = "1";
                }
                else if (poknum < 14)
                {
                    ashMove[l, 2] = "2";
                    garyMove[l, 2] = "2";
                }
                else if (poknum < 20)
                {
                    ashMove[l, 2] = "3";
                    garyMove[l, 2] = "3";
                }
                else if (poknum < 26)
                {
                    ashMove[l, 2] = "4";
                    garyMove[l, 2] = "4";
                }
                else
                {
                    ashMove[l, 2] = "5";
                    garyMove[l, 2] = "5";
                }
                poknum++;
            }
        }
    }

    static void ShowTeam()
    {
        int rep = 0;
        switch (player)
        {
            case ("Ash"):
                Console.Clear();
                Console.WriteLine("Ash's Pokemons are: ");
                for (int i = 0; i < ashPok.GetLength(0); i++)
                {
                    int n = -1;
                    if (n < 1)
                    {
                        n++;
                    }
                    if (ashPok[i, 1] == "1")
                    {
                        shiny = "SHINY ";
                    }
                    Console.WriteLine(i + 1 + " - " + shiny + ashPok[i, 0]);
                    shiny = "";
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(ashMove[j + rep, 0] + " - Power: ");
                        for (int k = 0; k < ashMove.GetLength(1) - 2; k++)
                        {
                            Console.Write(ashMove[j + rep, 1] + "\n");
                        }
                    }
                    rep += 3;
                    Console.WriteLine();
                }
                break;

            case ("Gary"):
                Console.Clear();
                Console.WriteLine("Gary's Pokemons are: ");
                for (int i = 0; i < garyPok.GetLength(0); i++)
                {
                    int n = -1;
                    if (n < 1)
                    {
                        n++;
                    }
                    if (garyPok[i, 1] == "1")
                    {
                        shiny = "SHINY ";
                    }
                    Console.WriteLine(i + 1 + " - " + shiny + garyPok[i, 0]);
                    shiny = "";
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(garyMove[j + rep, 0] + " - Power: ");
                        for (int k = 0; k < garyMove.GetLength(1) - 2; k++)
                        {
                            Console.Write(garyMove[j + rep, 1] + "\n");
                        }
                    }
                    rep += 3;
                    Console.WriteLine();
                }
                break;
        }
    }

    static void DeletePok()
    {
        ShowTeam();
        Console.WriteLine("Select the position of Pokemon to delete");
        int pos = Convert.ToInt32(Console.ReadLine());
        if (player == "Ash")
        {
            if (pos >= 1 && pos < ashPok.Length)
            {
                if (!String.IsNullOrEmpty(ashPok[pos - 1, 0]))
                {
                    ashPok[pos - 1, 0] = null;
                    if (pos - 1 == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                ashMove[i, j] = null;

                            }
                        }
                    }
                    if (pos - 1 == 1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                ashMove[i + 3, j] = null;

                            }
                        }
                    }
                    if (pos - 1 == 2)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                ashMove[i + 6, j] = null;

                            }
                        }
                    }
                    if (pos - 1 == 3)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                ashMove[i + 9, j] = null;

                            }
                        }
                    }
                    if (pos - 1 == 4)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                ashMove[i + 12, j] = null;

                            }
                        }
                    }
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
        if (player == "Gary")
        {
            if (pos >= 1 && pos < garyPok.Length)
            {
                if (!String.IsNullOrEmpty(garyPok[pos, 0]))
                {
                    garyPok[pos - 1, 0] = null;
                    if (pos - 1 == 0)
                    {
                        garyPok[pos - 1, 0] = null;
                        if (pos - 1 == 0)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    garyMove[i, j] = null;

                                }
                            }
                        }
                        if (pos - 1 == 1)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    garyMove[i + 3, j] = null;

                                }
                            }
                        }
                        if (pos - 1 == 2)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    garyMove[i + 6, j] = null;

                                }
                            }
                        }
                        if (pos - 1 == 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    garyMove[i + 9, j] = null;

                                }
                            }
                        }
                        if (pos - 1 == 4)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    garyMove[i + 12, j] = null;

                                }
                            }
                        }
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
        }
    }

    static void AddPokemon(string newPok)
    {
        if (player == "Ash")
        {
            for (int i = 0; i < 5; ++i) { Console.Write(ashPok[i, 0] + " " + i + ", "); }
            Console.Write("\n\nIntroduce the position:");
            int posPok = Convert.ToInt32(Console.ReadLine());
            NewPok(ashPok, posPok, ashMove);
        }
        else if (player == "Gary")
        {
            for (int i = 0; i < 5; ++i) { Console.Write(garyPok[i, 0] + " " + i + ", "); }
            Console.Write("\n\nIntroduce the position:");
            int posPok = Convert.ToInt32(Console.ReadLine());
            NewPok(garyPok, posPok, garyMove);
        }
        else
        {
            ShowTeam();
        }
    }

    static void NewPok(string[,] pokemons, int posPok, string[,] playMoves)
    {
        Random random = new Random();
        int Index = posPok * 3;

        if (posPok >= 0 && posPok < pokemons.GetLength(0))
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int randomIndex = random.Next(moves.GetLength(0));
                    playMoves[Index + i, j] = moves[randomIndex, j];
                }
            }
            pokemons[posPok, 0] = found[0, 0];
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
            int randomIndex2 = random2.Next(pokemon.GetLength(0));
            found[0, 0] = pokemon[randomIndex2, 0];
            Console.WriteLine(Convert.ToString(found[0, 0] + "\n"));
            AddPokemon(found[0, 0]);
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