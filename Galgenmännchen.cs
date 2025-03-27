using System;
using System.Collections.Generic;

class Hangman
{
  private static string[] wörterliste = { "entwickler", "programmierung", "computer", "software", "algorithmus", "cloud", "datenbank" };

  private static string gesuchtesWort;

  private static List<char> richtigeBuchstaben;

  private static int anzahlFehlversuche;

  private const int maxAnzahlFehlversuche = 6;

  public static void Main(string[] args)
  {
    Console.WriteLine("Willkommen bei Hangman!");

    StartNeuRunde();

    SpielStarten();
  }

  // Funktion, um ein neues Spiel zu starten
  private static void StartNeuRunde()
  {
    
    Random random = new Random();
    gesuchtesWort = wörterliste[random.Next(wörterliste.Length)];

    richtigeBuchstaben = new List<char>();

    anzahlFehlversuche = 0;

    Console.Clear();
    Console.WriteLine("Neues Spiel gestartet!");
    Console.WriteLine("Das Wort hat " + gesuchtesWort.Length + " Buchstaben.");
  }

  // Funktion, die den Spielablauf verwaltet
  private static void SpielStarten()
  {
    while (anzahlFehlversuche < maxAnzahlFehlversuche)
    {
      WortAnzeigen();

      Console.WriteLine($"Fehlversuche: {anzahlFehlversuche}/{maxAnzahlFehlversuche}");
      GalgenmännchenZeichnen();

      Console.Write("Gib einen Buchstaben ein: ");
      char guessedLetter = Char.ToLower(Console.ReadKey().KeyChar); 
      Console.WriteLine();

      if (richtigeBuchstaben.Contains(guessedLetter))
      {
        Console.WriteLine("Du hast diesen Buchstaben bereits geraten!");
        continue; 
      }

      richtigeBuchstaben.Add(guessedLetter);

      // Überprüfen, ob der Buchstabe im Wort enthalten ist
      if (gesuchtesWort.Contains(guessedLetter))
      {
        Console.WriteLine("Richtig!");

        if (WortÜberprüfen())
        {
          Console.Clear();
          WortAnzeigen();
          Console.WriteLine("Herzlichen Glückwunsch, du hast das Wort erraten!");
          break;
        }
      }
      else
      {
        anzahlFehlversuche++; 
        Console.WriteLine("Falsch! Versuche es nochmal.");
      }
    }

    // Wenn die maximale Anzahl an Fehlversuchen erreicht ist, verliert der Spieler
    if (anzahlFehlversuche == maxAnzahlFehlversuche)
    {
      Console.Clear();
      WortAnzeigen();
      Console.WriteLine($"Du hast verloren! Das Wort war: {gesuchtesWort}");
      GalgenmännchenZeichnen(); 
    }
  }
  // Funktion um das Wort anzuzeigen
  private static void WortAnzeigen()
  {
    foreach (char letter in gesuchtesWort)
    {
      if (richtigeBuchstaben.Contains(letter))
      {
        Console.Write(letter + " ");
      }
      else
      {
        Console.Write("_ ");
      }
    }
    Console.WriteLine(); 
  }

  // Funktion, um zu überprüfen, ob das gesamte Wort erraten wurde
  private static bool WortÜberprüfen()
  {
    foreach (char letter in gesuchtesWort)
    {
      if (!richtigeBuchstaben.Contains(letter))
      {
        return false;
      }
    }
    return true;
  }
  // Funktion, um das Galgenmännchen zu zeichnen
  private static void GalgenmännchenZeichnen()
  {
    switch (anzahlFehlversuche)
    {
      case 0:
        Console.WriteLine("   -----");
        Console.WriteLine("   |   |");
        Console.WriteLine("       |");
        Console.WriteLine("       |");
        Console.WriteLine("       |");
        Console.WriteLine("       |");
        Console.WriteLine("   =======");
        break;
      case 1:
        Console.WriteLine("   -----");
        Console.WriteLine("   |   |");
        Console.WriteLine("   O   |");
        Console.WriteLine("       |");
        Console.WriteLine("       |");
        Console.WriteLine("       |");
        Console.WriteLine("   =======");
        break;
      case 2:
        Console.WriteLine("   -----");
        Console.WriteLine("   |   |");
        Console.WriteLine("   O   |");
        Console.WriteLine("   |   |");
        Console.WriteLine("       |");
        Console.WriteLine("       |");
        Console.WriteLine("   =======");
        break;
      case 3:
        Console.WriteLine("   -----");
        Console.WriteLine("   |   |");
        Console.WriteLine("   O   |");
        Console.WriteLine("  /|   |");
        Console.WriteLine("       |");
        Console.WriteLine("       |");
        Console.WriteLine("   =======");
        break;
      case 4:
        Console.WriteLine("   -----");
        Console.WriteLine("   |   |");
        Console.WriteLine("   O   |");
        Console.WriteLine("  /|\\  |");
        Console.WriteLine("       |");
        Console.WriteLine("       |");
        Console.WriteLine("   =======");
        break;
      case 5:
        Console.WriteLine("   -----");
        Console.WriteLine("   |   |");
        Console.WriteLine("   O   |");
        Console.WriteLine("  /|\\  |");
        Console.WriteLine("  /    |");
        Console.WriteLine("       |");
        Console.WriteLine("   =======");
        break;
      case 6:
        Console.WriteLine("   -----");
        Console.WriteLine("   |   |");
        Console.WriteLine("   O   |");
        Console.WriteLine("  /|\\  |");
        Console.WriteLine("  / \\  |");
        Console.WriteLine("       |");
        Console.WriteLine("   =======");
        break;
    }
  }
}
