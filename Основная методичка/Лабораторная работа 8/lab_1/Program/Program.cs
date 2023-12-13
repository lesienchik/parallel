using System;
using System.Diagnostics.Metrics;
using System.Threading;

// Метод подсчета количества четных элементов в матрице.

class Program
{
    public static void Main()
    {
        Matrix matrix = new Matrix(6);
        Console.Write("Матрица:");
        matrix.Show();

        Task task = new Task(matrix.FindCountEvenNumbers);

        task.Start();
        task.Wait();

        Console.WriteLine("Количество четных элементов в матрице: " + matrix.counter);
    }
}

public class Matrix
{
    private double[,] matrix;
    private int rows, cols;
    public int counter = 0;

    public Matrix(int countRowsCols)
    {
        this.rows = countRowsCols;
        this.cols = countRowsCols;
        this.matrix = new double[rows, cols];

        Random rnd = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rnd.Next(100);
            }
        }
    }

    public void FindCountEvenNumbers()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] % 2 == 0)
                {
                    counter++;
                }

            }
        }
    }

    public void Show()
    {
        Console.WriteLine();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}


