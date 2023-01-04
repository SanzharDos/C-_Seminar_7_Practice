// Задача HARD SORT необязательная. Считается за три обязательных
// Задайте двумерный массив из целых чисел. Количество строк и столбцов задается с клавиатуры. Отсортировать элементы по возрастанию слева направо и сверху вниз.
// Например, задан массив:
// 1 4 7 2
// 5 9 10 3
// После сортировки
// 1 2 3 4
// 5 7 9 10


void FillArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(0, 21);
        }
    }
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("{ ");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j],3}\t");
        }
        Console.Write("}");
        Console.WriteLine();
    }
}

void SortArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int min_pos_row = i;
            int min_pos_col = j;
            for (int k = i; k < array.GetLength(0); k++)
            {
                int col_start = j + 1;
                if (k != i)
                {
                    col_start = 0;
                }
                for (int l = col_start; l < array.GetLength(1); l++)
                {
                    if (array[k, l] < array[min_pos_row, min_pos_col])
                    {
                        min_pos_row = k;
                        min_pos_col = l;
                    }
                }
            }
            int temp = array[i, j];
            array[i, j] = array[min_pos_row, min_pos_col];
            array[min_pos_row, min_pos_col] = temp;
        }
    }
}

Console.WriteLine("Введите количество строк двумерного массива:");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов двумерного массива");
int cols = Convert.ToInt32(Console.ReadLine());
int[,] array = new int[rows, cols];
FillArray(array);
Console.WriteLine($"Сгенерирован массив из {array.GetLength(0)} строк и {array.GetLength(1)} столбцов:");
PrintArray(array);
SortArray(array);
Console.WriteLine($"Отсортирован сгенерированный массив из {array.GetLength(0)} строк и {array.GetLength(1)} столбцов:");
PrintArray(array);