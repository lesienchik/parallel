using System;
using System.Collections.Generic;

// Использовать делегат Func<Action<List<int>>, bool>

class Program
{
    static void Main()
    {
        Func<Action<List<int>>, bool> customDelegate = CustomFunction;

        // Создаем список чисел
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        Action<List<int>> action = list => PrintNumbers(list);

        bool result = customDelegate(action);
        Console.WriteLine("Значение bool: " + result);
    }

    static void PrintNumbers(List<int> numbers)
    {
        Console.WriteLine("Числа из списка:");
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }

    static bool CustomFunction(Action<List<int>> action)
    {
        action(new List<int> { 10, 20, 30 });

        return true;
    }
}
