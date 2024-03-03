using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string user_name = Console.ReadLine();

        return user_name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favourite number: ");
        int user_number = int.Parse(Console.ReadLine());

        return user_number;
    }

    static int SquareNumber(int user_number)
    {
        int squared_number = user_number * user_number;
        return squared_number;
    }

    static void DisplayResult(string name, int squared_number)
    {
        Console.WriteLine($"{name}, the square of your number is {squared_number}");
    }
}