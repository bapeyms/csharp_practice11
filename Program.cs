namespace csharp_practice11;

public delegate void ArrayDelegate(int[] array);

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 33, 41, 55, 61, 7, 83, 9, 10, 11, 12, 13, 14, 15 };
        Console.Write("Array: ");
        PrintArray(numbers);

        ArrayDelegate[] multiDel = { ShowEvenElements, ShowOddElements, ShowPrimeElements, ShowFibonacciElements};
        int choice;

        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Show Even Elements");
            Console.WriteLine("2. Show Odd Elements");
            Console.WriteLine("3. Show Prime Elements");
            Console.WriteLine("4. Show Fibonacci Elements");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("[ERROR] Enter a number!");
                continue;
            }

            if (choice >= 1 && choice <= multiDel.Length)
            {
                multiDel[choice - 1](numbers);
            }
            else if (choice == 0)
            {
                Console.WriteLine("Exiting...");
            }
            else
            {
                Console.WriteLine("[ERROR] Non-existing choice!");
            }
        } while (choice != 0);
    }

    public static void ShowEvenElements(int[] array)
    {
        Console.Write("Even elements: ");
        foreach (int number in array)
        {
            if (number % 2 == 0)
                Console.Write(number + " ");
        }
        Console.WriteLine("");
    }

    public static void ShowOddElements(int[] array)
    {
        Console.Write("Odd elements: ");
        foreach (int number in array)
        {
            if (number % 2 != 0)
                Console.Write(number + " ");
        }
        Console.WriteLine("");
    }
    
    public static void ShowPrimeElements(int[] array)
    {
        Console.Write("Prime elements: ");
        // Where() - метод, що відбирає елементи колекції за певною умовою
        foreach (int number in array.Where(number =>
                 {
                     if (number < 2)
                         return false;
                     for (int i = 2; i <= number / i; i++)
                     {
                         if (number % i == 0)
                             return false;
                     }

                     return true;
                 }))
        {
            Console.Write(number + " ");
        }
        Console.WriteLine("");
    }

    public static void ShowFibonacciElements(int[] array)
    {
        Console.Write("Fibonacci elements: ");
        foreach (int number in array.Where(number =>
                 {
                     if (number < 0)
                         return false;
                     long a = 0;
                     long b = 1;
                     while (a < number)
                     {
                         long temp = a + b;
                         a = b;
                         b = temp;
                     }

                     return a == number;
                 }))
        {
            Console.Write(number + " ");
        }
        Console.WriteLine("");
    }

    public static void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine("");
    }
}