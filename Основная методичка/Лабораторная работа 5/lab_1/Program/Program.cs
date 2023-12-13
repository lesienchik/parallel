using System;
using System.Threading;

// Метод расчета суммы элементов массива случайных чисел

class Program
{
    static void Main()
    {
        int arraySize = 20;
        int threadCount = 4;

        int[] randomArray = GenerateRandomArray(arraySize);
        Thread[] threads = new Thread[4];

        // Запускаем каждый поток на выполнение
        for (int i = 0; i < threadCount; i++)
        {
            threads[i] = new Thread(() => CalculateSum(randomArray));
            threads[i].Start();
        }

    }

    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(100);
        }
        return array;
    }

    static void CalculateSum(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        Console.WriteLine("Поток: " + Thread.CurrentThread.ManagedThreadId + ", Сумма элементов массива: " + sum);
    }
}
