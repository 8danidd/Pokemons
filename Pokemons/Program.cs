using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public class Lospokemons
{
    static string[] pokemon = { "Bulbasaur", "Pikachu", "Charmander", "Onix", "Squirtle", "Jigglypuff", "Meowth", "Psyduck", "Snorlax", "Gengar", "Machop", "Geodude", "Eevee", "Vulpix", "Magikarp" };
    static string[] ashPok = new string[5];
    static string[] garyPok = new string[5];
    static string player = "none";

    public static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.Clear();
            Console.WriteLine("POKEMON");
            Console.WriteLine("Pulsa cualquier tecla para empezar");
            Console.ReadKey(true);
            InitGame();
            keyInfo = Console.ReadKey(true);
        } while (keyInfo.Key != ConsoleKey.W);

    }
    static void InitGame()
    {
        Console.Clear();
        Console.WriteLine("\n           MENU PRINCIPAL \n \n");
        InitPokedex();
        Console.WriteLine("Pulsa Q para mostrar los equipos \nPulsa W para salir \n");
        ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
        if (KeyInfo.Key == ConsoleKey.Q) { ShowTeam(); }
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
        Console.WriteLine("Pulsa la tecla para elegir al jugador:\n Ash (Pulsa A)\n Gary (Pulsa S)\n");
        ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
        if (KeyInfo.Key == ConsoleKey.A) { player = "Ash"; }
        if (KeyInfo.Key == ConsoleKey.S) { player = "Gary"; }

        switch (player)
        {
            case ("Ash"):
                Console.Clear();
                Console.WriteLine("Los pokemons de Ash son: ");
                for (int i = 0; i < ashPok.Length; ++i) { Console.Write(ashPok[i] + ", "); }
                Console.WriteLine("\n");
                break;

            case ("Gary"):
                Console.Clear();
                Console.WriteLine("Los pokemons de Gary son: ");
                for (int i = 0; i < garyPok.Length; ++i) { Console.Write(garyPok[i] + ", "); }
                Console.WriteLine("\n");
                break;
        }
        Console.WriteLine("Quieres eliminar algún pokemon? \n");
        Console.WriteLine("Si: Y \nNo: N");
        ConsoleKeyInfo KeyInfo2 = Console.ReadKey(true);
        if (KeyInfo2.Key == ConsoleKey.Y) { DeletePok(); }
        else
        {
            ShowTeam();
        }
    }

    static void DeletePok()
    {
        Console.Clear();
        Console.WriteLine("Elige el Pokemon a eliminar \n");
        if (player == "Ash")
        {
            for (int i = 0; i < ashPok.Length; ++i) { Console.Write(ashPok[i] + " " + i + ", "); }
            Console.Write("\n\nIntroduce el numero del pokemon:");
            int posicion = Convert.ToInt32(Console.ReadLine());
            BorrarPok(ashPok, posicion);
        }
        else
        {
            for (int i = 0; i < garyPok.Length; ++i) { Console.Write(garyPok[i] + " " + i + ", "); }
            Console.Write("\n\nIntroduce el numero del pokemon:");
            int posicion = Convert.ToInt32(Console.ReadLine());
            BorrarPok(garyPok, posicion);
        }

    }

    static void BorrarPok(string[] pokemons, int pos)
    {
        if (pos >= 0 && pos < pokemons.Length)
        {
            pokemons[pos] = "(VACIO)";
            ShowTeam();
        } else { Console.Clear(); Console.WriteLine("Posicion no valida"); Thread.Sleep(750); DeletePok(); }
    }
}