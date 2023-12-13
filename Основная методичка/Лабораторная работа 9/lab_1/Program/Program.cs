using System;
using System.Threading;

// Генерация массива случайных чисел (размер задается пользователем)
// Задачи:
// Поиск максимального элемента среди четных
// Подсчет количества элементов массива, отличающихся от заданного пользователем не более чем на 3

class Program
{
    public static void Main()
    {
        Solution sol = new Solution(25);
        Console.Write("Массив:");
        sol.Show();

        Task task = new Task(
            () =>
            {
                Console.WriteLine("Задача №1:");
                sol.FindMaxElement();
                Console.WriteLine("Максимальный элемент среди четных = {0}", sol.max);

            }
        );

        Task taskContinue = task.ContinueWith(
            base_task =>
            {
                Console.WriteLine("Задача №2:");
                sol.FindCounterOddNumber(13);
                Console.WriteLine("Количество элементов массива, отличающихся от заданного пользователем не более чем на 3: " + sol.counterOddNumber);
            }
        );

        task.Start();
        task.Wait();

        Console.ReadKey();
    }
}

public class Solution
{
    private double[] array;
    public double max;
    public double counterOddNumber;

    public Solution(int size)
    {
        this.array = new double[size];

        Random rnd = new Random();
        for (int i = 0; i < size; i++)
        {
            this.array[i] = rnd.Next(100);
        }
    }

    public void FindMaxElement()
    {
        double max = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0)
            {
                if (max < array[i])
                {
                    this.max = array[i];
                }
            }
        }
    }

    public void FindCounterOddNumber(int targetNumber)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (Math.Abs(array[i] - targetNumber) <= 3)
            {
                counterOddNumber++;
            }
        }
    }

    public void Show()
    {
        Console.WriteLine();
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}


