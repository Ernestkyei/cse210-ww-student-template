using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
    
        int user_integer = -1;
        while (user_integer != 0)
        {
            Console.Write("Enter a number: ");
            
            string number_entered = Console.ReadLine();
            user_integer = int.Parse(number_entered);
            
            if (user_integer != 0)
            {
                numbers.Add(user_integer);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum integers in list is: {sum}");

        
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average integers in list is: {average}");

        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }

}