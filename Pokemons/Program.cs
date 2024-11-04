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
        Console.WriteLine("                                ,'\\\r\n    _.----.        ____         ,'  _\\   ___    ___     ____\r\n_,-'       `.     |    |  /`.   \\,-'    |   \\  /   |   |    \\  |`.\r\n\\      __    \\    '-.  | /   `.  ___    |    \\/    |   '-.   \\ |  |\r\n \\.    \\ \\   |  __  |  |/    ,','_  `.  |          | __  |    \\|  |\r\n   \\    \\/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |\r\n    \\     ,-'/  /   \\    ,'   | \\/ / ,`.|         /  /   \\  |     |\r\n     \\    \\ |   \\_/  |   `-.  \\    `'  /|  |    ||   \\_/  | |\\    |\r\n      \\    \\ \\      /       `-.`.___,-' |  |\\  /| \\      /  | |   |\r\n       \\    \\ `.__,'|  |`-._    `|      |__| \\/ |  `.__,'|  | |   |\r\n        \\_.-'       |__|    `-._ |              '-.|     '-.| |   |\r\n                                `'                            '-._|");
        Console.WriteLine("Pulsa cualquier tecla para empezar");
        Console.ReadKey(true);
    }

    static void menu()
    {
        Console.WriteLine("\n           MENU PRINCIPAL \n \n");
        Console.WriteLine("Choose and action:");
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
                Console.WriteLine("Pulsa cualquier tecla para return to main menu");
                break;
            case ConsoleKey.D:
                DeletePok();
                Console.WriteLine("Pulsa cualquier tecla para return to main menu");
                break;
            case ConsoleKey.C:
                Explore();
                Console.WriteLine("Pulsa cualquier tecla para return to main menu");
                break;
            case ConsoleKey.W:
                //
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
        Console.Clear();
        Console.WriteLine("Pulsa la tecla para elegir al jugador:\nAsh (Pulsa A)\nGary (Pulsa S)\n");
        ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
        if (KeyInfo.Key == ConsoleKey.A) { player = "Ash"; }
        if (KeyInfo.Key == ConsoleKey.S) { player = "Gary"; }

        switch (player)
        {
            case ("Ash"):
                Console.Clear();
                Console.WriteLine("Los pokemons de Ash son: ");
                for (int i = 0; i < ashPok.Length; ++i) { 
                    string result = String.IsNullOrEmpty(ashPok[i]) ? (i + " - null , ") : (i + " - " + ashPok[i] + ", ");
                    Console.Write(result);
                }
                Console.WriteLine("\n");
                break;

            case ("Gary"):
                Console.Clear();    
                Console.WriteLine("Los pokemons de Gary son: ");
                for (int i = 0; i < garyPok.Length; ++i) { Console.Write(i + " - " + garyPok[i] + ", "); }
                Console.WriteLine("\n");
                break;
        }
        /*Console.WriteLine("Quieres eliminar algún pokemon? \n");
        Console.WriteLine("Si: Y \nNo: N");
        ConsoleKeyInfo KeyInfo2 = Console.ReadKey(true);
        if (KeyInfo2.Key == ConsoleKey.Y) { DeletePok(); }
        else
        {
            Console.WriteLine("\nQuieres buscar mas pokemons?\n");
            Console.Write("Si: Y\nNo: N\n");
            ConsoleKeyInfo KeyInfo3 = Console.ReadKey(true);
            if (KeyInfo3.Key == ConsoleKey.Y) {
                Explore();
            } else { ShowTeam(); }
        }*/
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
        } else { 
            Console.WriteLine("Posicion no valida"); 
            Thread.Sleep(750); 
        }
    }

    static void AddPokemon(string newPok)
    {
        if (player == "Ash")
        {
            for (int i = 0; i < ashPok.Length; ++i) { Console.Write(ashPok[i] + " " + i + ", "); }
            Console.Write("\n\nIntroduce la posicion:");
            int posPok = Convert.ToInt32(Console.ReadLine());
            NewPok(ashPok, posPok);
        }
        else
        {
            for (int i = 0; i < garyPok.Length; ++i) { Console.Write(garyPok[i] + " " + i + ", "); }
            Console.Write("\n\nIntroduce la posicion:");
            int posPok = Convert.ToInt32(Console.ReadLine());
            NewPok(garyPok, posPok);
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
            Console.WriteLine("Posicion no valida");
            Thread.Sleep(750);
            ShowTeam();
        }
    }

    static void LoadScreen()
    {
        Console.Write("Buscando Pokemons... [");
        Thread.Sleep(500);
        for (int i = 0; i < 30; ++i)
        {
            Console.Write("#");
            Thread.Sleep(125);
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
        int probabilidad = random.Next(0,100);
        if (probabilidad > 50)
        {
            Console.Clear();
            Console.WriteLine("¡¡¡HAS CAPTURADO UN POKEMON!!!\n");
            int randomIndex2 = random2.Next(pokemon.Length);
            found[0] = pokemon[randomIndex2];
            Console.WriteLine(Convert.ToString(found[0] + "\n"));
            AddPokemon(found[0]);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("No has encontrado nada");
            Thread.Sleep(2000);
            ShowTeam();
        }
    }
}