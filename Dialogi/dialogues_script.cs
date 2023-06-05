using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string filePath = "dialogues.csv";
        Dialogue[] dialogues = LoadDialogues(filePath);

        SetConsoleEncoding();

        // Symulacja wykrycia kolizji z NPC
        bool collisionDetected = true;

        if (collisionDetected)
        {
            InteractWithNPC(dialogues);
        }
    }

    static void SetConsoleEncoding()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
    }

    static void InteractWithNPC(Dialogue[] dialogues)
    {
        foreach (Dialogue dialogue in dialogues)
        {
            Console.WriteLine(dialogue.Character + ": " + dialogue.Line);
            Console.ReadLine();
        }
    }

    static Dialogue[] LoadDialogues(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
        Dialogue[] dialogues = new Dialogue[lines.Length - 1];

        for (int i = 1; i < lines.Length; i++) // Rozpoczynamy od indeksu 1, aby pominąć nagłówek kolumn
        {
            string[] parts = lines[i].Split(',');

            if (parts.Length == 2)
            {
                string character = parts[0].Trim();
                string line = parts[1].Trim();
                Dialogue dialogue = new Dialogue(character, line);
                dialogues[i - 1] = dialogue;
            }
        }

        return dialogues;
    }
}

class Dialogue
{
    public string Character { get; }
    public string Line { get; }

    public Dialogue(string character, string line)
    {
        Character = character;
        Line = line;
    }
}