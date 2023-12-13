// Вариант 14 - Реализовать функцию возведения в квадрат суммы двух вещественных чисел

public class Program
{

    public static void Main(string[] args)
    {
        double num1 = 5;
        double num2 = 10;

        // Вызов функции
        Square(num1, num2);
    }

    public static void Square(double num1, double num2)
    {
        double sum = num1 + num2;
        double square = sum * sum;

        Console.WriteLine("Результат возведения в квадрат суммы двух вещественных чисел = " + square);
    }
}