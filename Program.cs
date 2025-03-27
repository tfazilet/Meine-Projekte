using System;
using System.Collections.Generic;

namespace TodoList
{
  class Program
  {
    // Eine Liste, um die Aufgaben zu speichern
    static List<string> todoList = new List<string>();

    static void Main(string[] args)
    {
      bool running = true;

      while (running)
      {
        Console.Clear();
        Console.WriteLine("To-Do Liste");
        Console.WriteLine("1. Neue Aufgabe hinzufügen");
        Console.WriteLine("2. Aufgaben anzeigen");
        Console.WriteLine("3. Aufgabe löschen");
        Console.WriteLine("4. Beenden");
        Console.Write("Wähle eine Option: ");

        string eingabe = Console.ReadLine();

        if (eingabe == "1")
        {
          AufgabeHinzufügen();
        }
        else if (eingabe == "2")
        {
          AlleAufgabenZeigen();
        }
        else if (eingabe == "3")
        {
          AufgabeLöschen();
        }
        else if (eingabe == "4")
        {
          running = false;
        }
        else
        {
          Console.WriteLine("Ungültige Eingabe. Bitte versuche es erneut.");
        }
      }
      Console.WriteLine("Programm beendet.");
    }

    // Methode, um eine neue Aufgabe hinzuzufügen
    static void AufgabeHinzufügen()
    {
      Console.Write("Gib die neue Aufgabe ein: ");
      string aufgabe = Console.ReadLine();
      todoList.Add(aufgabe);
      Console.WriteLine("Aufgabe hinzugefügt!");
      Console.WriteLine("Drücke eine Taste, um fortzufahren...");
      Console.ReadKey();
    }

    // Methode, um alle Aufgaben anzuzeigen
    static void AlleAufgabenZeigen()
    {
      if (todoList.Count == 0)
      {
        Console.WriteLine("Keine Aufgaben in der Liste.");
      }
      else
      {
        Console.WriteLine("Deine Aufgaben:");
        for (int i = 0; i < todoList.Count; i++)
        {
          Console.WriteLine($"{i + 1}. {todoList[i]}");
        }
      }
      Console.WriteLine("Drücke eine Taste, um fortzufahren...");
      Console.ReadKey();
    }

    // Methode, um eine Aufgabe zu löschen
    static void AufgabeLöschen()
    {
      if (todoList.Count == 0)
      {
        Console.WriteLine("Keine Aufgaben zum Löschen.");
      }
      else
      {
        AlleAufgabenZeigen();
        Console.Write("Gib die Nummer der Aufgabe ein, die du löschen möchtest: ");
        int aufgabenNr;

        if (int.TryParse(Console.ReadLine(), out aufgabenNr) && aufgabenNr > 0 && aufgabenNr <= todoList.Count)
        {
          todoList.RemoveAt(aufgabenNr - 1);
          Console.WriteLine("Aufgabe gelöscht!");
        }
        else
        {
          Console.WriteLine("Ungültige Aufgabe Nummer.");
        }
      }
      Console.WriteLine("Drücke eine Taste, um fortzufahren...");
      Console.ReadKey();
    }
  }
}
