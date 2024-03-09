using System;


namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();

            while (true)
            {
                Console.WriteLine("\n********** Journal Menu **********");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice){
                    case 1:
                        Console.WriteLine("\nWrite a new entry:");
                        journal.WriteNewEntry();
                        break;
                    case 2:
                        Console.WriteLine("\nDisplaying the journal:");
                        journal.DisplayJournal();
                        break;
                    case 3:
                        Console.WriteLine("\nSaving the journal to a file:");
                        journal.SaveJournalToFile();
                        break;
                    case 4:
                        Console.WriteLine("\nLoading the journal from a file:");
                        journal.LoadJournalFromFile();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a valid option.");
                        break;
                }
            }
        }
    }

    class Journal
    {
        private List<Entry> entries;
        private List<string> prompts;

        public Journal()
        {
            entries = new List<Entry>();
            prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };
        }

        public void WriteNewEntry()
        {
            Console.WriteLine("Select a prompt for your entry:");
            for (int i = 0; i < prompts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {prompts[i]}");
            }
            Console.Write("Enter the number of the prompt: ");
            int promptIndex = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Enter your response: ");
            string response = Console.ReadLine();

            entries.Add(new Entry(prompts[promptIndex], response, DateTime.Now));
            Console.WriteLine("Entry added successfully!");
        }

        public void DisplayJournal()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries found in the journal.");
            }
            else
            {
                foreach (var entry in entries)
                {
                    Console.WriteLine($"{entry.Date}: {entry.Prompt}\n{entry.Response}\n");
                }
            }
        }

        public void SaveJournalToFile()
        {
            Console.Write("Enter the filename to save the journal to: ");
            string filename = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date}: {entry.Prompt}\n{entry.Response}");
                }
            }
            Console.WriteLine($"Journal saved to {filename} successfully!");
        }

        public void LoadJournalFromFile()
        {
            Console.Write("Enter the filename to load the journal from: ");
            string filename = Console.ReadLine();
            entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    string prompt = parts[1].Trim();
                    string response = reader.ReadLine().Trim();
                    DateTime date = DateTime.Parse(parts[0].Trim());
                    entries.Add(new Entry(prompt, response, date));
                }
            }
            Console.WriteLine($"Journal loaded from {filename} successfully!");
        }
    }

    class Entry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public DateTime Date { get; set; }

        public Entry(string prompt, string response, DateTime date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }
    }
}
