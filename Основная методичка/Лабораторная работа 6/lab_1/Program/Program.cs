using System;
using System.Threading;

// Метод находит логическое значение, указывающее существует ли заданное число в массиве целых случайных чисел

class Program
{
    static void Main()
    {
        int arraySize = 20;
        int targetElement = 13;

        int[] randomArray = GenerateRandomArray(arraySize);

        Thread searchThread = new Thread(() =>
        {
            bool exists = CheckElementExists(randomArray, targetElement);

            if (exists)
            {
                Console.WriteLine("\nЭлемент: " + targetElement + ", существует в массиве");
            }
            else
            {
                Console.WriteLine("\nЭлемент: " + targetElement + ", не существует в массиве");
            }
        });

        searchThread.Start();

        Console.ReadLine();
    }

    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];

        Console.Write("Созданный массив: ");
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(100);
            Console.Write(array[i] + " ");
        }



        return array;
    }

    static bool CheckElementExists(int[] array, int target)
    {
        foreach (int element in array)
        {
            if (element == target)
            {
                return true;
            }
        }

        return false;
    }
}
