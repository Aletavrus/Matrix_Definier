using System.Diagnostics.Metrics;
using System.Numerics;

class HelloWorld
{
    static void Main()
    {
        string input = Console.ReadLine();
        int size = int.Parse(input);
        int[,] matrix = Create_Matrix(size, "");
        Print(matrix);
        int total = 0;
        int counter = 0;
        int definer = Split_Matrix(matrix, total, counter);
        Console.WriteLine(definer);
    }

    public static int Split_Matrix(int[,] matrix, int total, int counter)
    {
        int size_of_matrix = matrix.GetLength(0);
        int new_size = size_of_matrix - 1;
        if (size_of_matrix == 2)
        {
            return Find_Definitor(matrix);
        }
        else
        {
            for (int n = 0; n < size_of_matrix; n++)
            {
                int[,] new_matrix = new int[new_size, new_size];
                for (int line = 1; line < size_of_matrix; line++)
                {
                    for (int col = 0; col < size_of_matrix; col++)
                    {
                        if (col != n)
                        {
                            if (n == size_of_matrix - 1)
                            {
                                new_matrix[line - 1, col] = matrix[line, col];
                            }
                            else
                            {
                                if (col == 0 || col == 1 & n != 0)
                                {
                                    new_matrix[line - 1, col] = matrix[line, col];
                                }
                                else
                                {
                                    new_matrix[line - 1, col - 1] = matrix[line, col];
                                }
                            }
                        }
                    }
                }
                int k = 0;
                if (counter % 2 == 0)
                {
                    k = 1;
                }
                else
                {
                    k = -1;
                }
                counter += 1;
                if (new_size == 2)
                {

                    int definer = Two_Mansion(matrix, new_matrix, n, k);
                    total += definer;
                }
                else
                {
                    if (n % 2 == 0)
                    {
                        Split_Matrix(new_matrix, total, 2);
                    }
                    else
                    {
                        Split_Matrix(new_matrix, total, 1);
                    }
                }
            }
        }
        return total;
    }
    public static int Two_Mansion(int[,] old_matrix, int[,] new_matrix, int n,int k)
    {
        Console.Write($"{old_matrix[0, n]*k} Matrix: \n");
        //Print(new_matrix);
        int definitor = Find_Definitor(new_matrix);
        definitor = old_matrix[0, n] * k * definitor;
        return definitor;
    }
    public static void Print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static int[,] Create_Matrix(int size, string command)
    {
        int[,] matrix = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            string input = Console.ReadLine();
            string[] input_split = input.Split();
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = int.Parse(input_split[j]);
            }
        }
        Console.WriteLine();
        return matrix;
    }

    public static int Find_Definitor(int[,] matrix)
    {
        int definitor = (matrix[0, 0] * matrix[1, 1]) - (matrix[1, 0] * matrix[0, 1]);
        return definitor;
    }

    public static int[,] Create_Matrix(int size)
    {
        int[,] matrix = new int[size, size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = random.Next(1, 10);
            }
        }
        return matrix;
    }
}