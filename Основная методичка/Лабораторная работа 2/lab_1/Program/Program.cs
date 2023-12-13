using System;
using System.Threading.Tasks;

// Метод возвращает подмножество элементов массива случайных чисел, которые отличаются от заданного числа не более чем на 4.
public delegate int[] SubsetDelegate(int arraySize, int targetNumber);

class Program
{
    static async Task Main()
    {
        int arraySize = 10;
        int targetNumber = 0;

        SubsetDelegate subsetDelegate = GetSubset;

        // Асинхронно вызываем метод
        var result = await Task.Run(() => subsetDelegate(arraySize, targetNumber));
        Console.WriteLine("Подмножество элементов, которые отличаются от заданного числа не более чем на 4: " + string.Join(", ", result));
    }

    static int[] GetSubset(int arraySize, int targetNumber)
    {
        Random random = new Random();
        int[] array = new int[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            array[i] = random.Next(1, 10);
        }

        Console.WriteLine("Исходный массив: " + string.Join(", ", array));

        return array.Where(x => Math.Abs(x - targetNumber) <= 4).ToArray();
    }
}
