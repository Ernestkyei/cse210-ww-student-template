using System;

class Program
{
    static void Main(string[] args)
    {
        // Parts 1 and 2 = user chooses magic number
        // Console.Write("What is the magic number? ");
        // int magic_number = int.Parse(Console.ReadLine());
        
        // Part 3 = random number generated
        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(0, 101);

        int guess_number = 1;

        // We could also use a do-while loop here...
        while (guess_number != magic_number)
        {
            Console.Write("What is your guess? ");
            guess_number = int.Parse(Console.ReadLine());

            if (magic_number > guess_number)
            {
                Console.WriteLine("Higher");
            }
            else if (magic_number < guess_number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed correctly!");
            }
        }
    }
}