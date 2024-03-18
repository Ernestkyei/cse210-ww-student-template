using System;

public class Scripture
{
    public string Reference { get; }
    public string Text { get; }
    private List<string> hiddenWords;
    
    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
        hiddenWords = new List<string>();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{Reference}:");
        foreach (string word in Text.Split(' '))
        {
            if (hiddenWords.Contains(word))
            {
                Console.Write("***** ");
            }
            else
            {
                Console.Write($"{word} ");
            }
        }
        Console.WriteLine("\n\nPress Enter to reveal more words or type 'quit' to exit.");
    }

    public bool HideRandomWords()
    {
        List<string> words = Text.Split(' ').ToList();
        words.RemoveAll(w => hiddenWords.Contains(w));
        if (words.Count == 0)
        {
            return false;
        }

        Random random = new Random();
        int wordsToHide = random.Next(1, Math.Min(5, words.Count + 1));
        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count);
            hiddenWords.Add(words[index]);
            words.RemoveAt(index);
        }
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (true)
        {
            scripture.Display();
            string input = Console.ReadLine().ToLower();
            if (input == "quit")
            {
                break;
            }
            else if (input == "")
            {
                if (!scripture.HideRandomWords())
                {
                    Console.WriteLine("All words are hidden. Press Enter to exit.");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
