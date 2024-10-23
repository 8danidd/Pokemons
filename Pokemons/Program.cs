using System;
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
        if (KeyInfo.Key == ConsoleKey.Q) {ShowTeam();}
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
        if (KeyInfo.Key == ConsoleKey.A) {player = "Ash";}
        if (KeyInfo.Key == ConsoleKey.S) {player = "Gary";}

        if (player == "Ash")
        {
            Console.Clear();
            Console.WriteLine("Los pokemons de Ash son: ");
            for (int i = 0; i < ashPok.Length; ++i) { Console.Write(ashPok[i] + ", "); }
            Console.WriteLine("\n");
            player = "none";
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Los pokemons de Gary son: ");
            for (int i = 0; i < garyPok.Length; ++i) { Console.Write(garyPok[i] + ", "); }
            Console.WriteLine("\n");
            player = "none";
        }
    }
}