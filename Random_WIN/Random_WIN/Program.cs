using System;
using System.Diagnostics;

string name_Player1 = "Player 1";
string name_Player2 = "Player 2";

Console.Write("Wie viele Runden sollen gespielt werden? ");
int AnzahlSpiele = Convert.ToInt32(Console.ReadLine());

Console.Write("Name Player 1: ");
name_Player1 = Console.ReadLine();


Console.Write("Name Player 2: ");
name_Player2 = Console.ReadLine();

int counter1 = 0;
int counter2 = 0;

Gewinnspiel.TWO_Player(AnzahlSpiele, name_Player1, name_Player2, counter1, counter2);
Console.ReadLine();

class Gewinnspiel
{
    public static void Ausgabe(int random, string Player, int nummer_Player,int dif, int counter)
    {
        Console.WriteLine(Repeat('#', 40));
        Console.WriteLine("");
        Console.WriteLine($"Die gesuchte Zahl ist: {random}");
        Console.WriteLine($"Gewonnen hat das Spiel: {Player}");
        Console.WriteLine($"Seine Zahl ist: {nummer_Player}");
        Console.WriteLine($"Die Differenz beträgt: {dif}");
        Console.WriteLine($"");
        Console.WriteLine($"{Player} hat {counter} Mal gewonnen");
        Console.WriteLine(Repeat('#', 40));
        Console.WriteLine($"");
    }

    public static void AusgabeGenau(int random, string Player, int nummer_Player, int counter)
    {
        Console.WriteLine(Repeat('#', 40));
        Console.WriteLine("");
        Console.WriteLine($"Die gesuchte Zahl ist: {random}");
        Console.WriteLine($"Gewonnen hat das Spiel: {Player}");
        Console.WriteLine($"Seine Zahl ist: {nummer_Player}");
        Console.WriteLine($"{Player} hat genau die Zahl {random} getippt.");
        Console.WriteLine($"");
        Console.WriteLine($"{Player} hat {counter} Mal gewonnen");
        Console.WriteLine(Repeat('#', 40));
        Console.WriteLine($"");
    }

   private static string Repeat(char character, int numberOfIterations)
    {
        return "".PadLeft(numberOfIterations, character);
    }

    public static void TWO_Player(int AnzahlSpiele, string name_Player1, string name_Player2, int counter1, int counter2)
    {
        while (1 <= AnzahlSpiele)
        {

            
            Console.Write($"{name_Player1}, was ist dein Tipp? ");
            int nummer_Player1 = Convert.ToInt32(Console.ReadLine());

            Console.Write($"{name_Player2}, was ist dein Tipp? ");
            int nummer_Player2 = Convert.ToInt32(Console.ReadLine());


            var nummer_win = new Random();
            int random = nummer_win.Next(1, 101);

            int dif1 = Math.Abs(random - nummer_Player1);
            int dif2 = Math.Abs(random - nummer_Player2);

            if (dif1 < dif2)
            {
                counter1 += 1;
                AnzahlSpiele -= 1;
                Ausgabe(random, name_Player1, nummer_Player1, dif1, counter1);
            }

            if (dif2 < dif1)
            {
                counter2 += 1;
                AnzahlSpiele -= 1;
                Ausgabe(random, name_Player2, nummer_Player2, dif2, counter2);
            }
            if (dif1 == random)
            {
                counter1 += 1;
                AusgabeGenau(random, name_Player1, nummer_Player1, counter1);
            }
            if (dif2 == random)
            {
                counter2 += 1;
                AusgabeGenau(random, name_Player2, nummer_Player2, counter2);
            }
        }
        if(AnzahlSpiele == 0)
        {
            Console.WriteLine(Repeat('#', 40));
            Console.WriteLine("");
            if(counter1 > counter2)
            {
                Console.WriteLine($"{name_Player1} hat das Spiel mit {counter1} Punkt/e gewonnen");
            }
            if (counter2 > counter1)
            {
                Console.WriteLine($"{name_Player2} hat das Spiel mit {counter2} Punkt/e gewonnen");
            }
            Console.WriteLine("");
        }
    }
}