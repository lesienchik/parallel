using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// Добавить Тайм-аут
public delegate int[] SubsetDelegate(int arraySize, int targetNumber);

class Program
{
    static async Task Main()
    {
        int arraySize = 10;
        int targetNumber = 5;

        SubsetDelegate subsetDelegate = GetSubset;

        // Устанавливаем тайм-аут в 5 секунд
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        Task timeoutTask = Task.Delay(1, cancellationTokenSource.Token);
        var resultTask = Task.Run(() => subsetDelegate(arraySize, targetNumber));
        var completedTask = await Task.WhenAny(resultTask, timeoutTask);

        if (completedTask == timeoutTask)
        {
            cancellationTokenSource.Cancel();
            Console.WriteLine("Тайм-аут! Метод прерван.");
        }
        else
        {
            Console.WriteLine("Исходный массив: " + string.Join(", ", resultTask.Result));
        }
    }

    static int[] GetSubset(int arraySize, int targetNumber)
    {
        Thread.Sleep(1000);
        Random random = new Random();
        int[] array = new int[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            array[i] = random.Next(1, 10);
        }

        Console.WriteLine("Исходный массив: " + string.Join(", ", array));

        // Возвращаем подмножество элементов, отличающихся не более чем на 4 от заданного числа
        return array.Where(x => Math.Abs(x - targetNumber) <= 4).ToArray();
    }
}
