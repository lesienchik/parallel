using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

// Метод находит подмножество элементов массива случайных чисел, которые отличаются от заданного числа не более чем на 4.

class Program
{
    static void Main()
    {
        int targetNumber = 10;
        RandomArrayManager arrayManager = new RandomArrayManager();

        List<int> resultSubset = arrayManager.FindSubset(targetNumber);

        Console.WriteLine("Исходный массив случайных чисел:");
        arrayManager.PrintArray();

        Console.WriteLine($"\nПодмножество элементов, отличающихся от {targetNumber} не более чем на 4:");
        foreach (var item in resultSubset)
        {
            Console.Write($"{item} ");
        }

        Console.ReadLine();
    }
}

class RandomArrayManager
{
    private int[] randomArray;
    public RandomArrayManager()
    {
        randomArray = new int[20];
        Random random = new Random();

        for (int i = 0; i < randomArray.Length; i++)
        {
            randomArray[i] = random.Next(20);
        }
    }

    public void PrintArray()
    {
        foreach (var item in randomArray)
        {
            Console.Write(item + " ");
        }
    }

    public List<int> FindSubset(int targetNumber)
    {
        List<int> subset = new List<int>();
        ThreadPoolManager threadPoolManager = new ThreadPoolManager();
        threadPoolManager.ProcessItems(randomArray, targetNumber, subset);

        return subset;
    }
}

class ThreadPoolManager
{
    public void ProcessItems(int[] array, int targetNumber, List<int> subset)
    {
        Parallel.ForEach(array, item =>
        {
            if (Math.Abs(item - targetNumber) <= 4)
            {
                lock (subset)
                {
                    subset.Add(item);
                }
            }
        });
    }
}
