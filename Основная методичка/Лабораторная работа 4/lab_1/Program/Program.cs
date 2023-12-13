using System;
using System.Threading.Tasks;

// Метод возвращает среднее арифметическое элементов матрицы случайных чисел
class Program
{
    static async Task Main(string[] args)
    {
        var matrixProcessor = new MatrixProcessor(5);
        var result = await matrixProcessor.WriteMatrix();
    }
}

public class MatrixProcessor
{
    private int[,] matrix;
    private int rows, cols;

    public MatrixProcessor(int countRowsCols)
    {
        this.rows = countRowsCols;
        this.cols = countRowsCols;
        this.matrix = new int[rows, cols];

        Random rnd = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rnd.Next(1000);
            }
        }
    }

    public async Task<double> WriteMatrix()
    {
        Console.WriteLine("Матрица:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // Асинхронный вызов метода для расчета среднего арифметического
        return await CalculateAverageAsync(matrix);
    }

    private async Task<double> CalculateAverageAsync(int[,] matrix)
    {
        // Расчет среднего арифметического элементов матрицы
        double sum = 0;
        int count = matrix.Length;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
            }
        }

        double average = sum / count;

        Console.Write("\nОбратный вызов с использованием лямбда-выражения. Среднее ариф. элементов матрицы равно: " + average);
        return average;
    }
}
