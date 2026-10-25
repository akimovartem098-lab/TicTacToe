using System;

class Program
{
    static char[,] board = new char[3, 3];

           static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        InitBoard();

        char currentPlayer = 'X';

        while (true)
        {
            PrintBoard();
            Console.WriteLine($"Ход игрока {currentPlayer}");

            var (row, col) = ReadMove();
            board[row, col] = currentPlayer;

            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }
    static (int row, int col) ReadMove()
    {
        while (true)
        {
            Console.Write("Введите строку и столбец через пробел (например, 2 3): ");

            string[] parts = (Console.ReadLine() ?? "")
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int row) ||
                !int.TryParse(parts[1], out int col))
            {
                Console.WriteLine("Ошибка: введите два числа через пробел.");
                continue; 
            }

            if (row < 1 || row > 3 || col < 1 || col > 3)
            {
                Console.WriteLine("Ошибка: числа должны быть от 1 до 3.");
                continue;
            }

            row--;
            col--;

            if (board[row, col] != ' ')
            {
                Console.WriteLine("Ошибка: эта клетка уже занята.");
                continue;
            }

            return (row, col); // всё корректно
        }
    }
    static void InitBoard()
    {
        for (int r = 0; r < 3; r++)
            for (int c = 0; c < 3; c++)
                board[r, c] = ' ';
    }

    static void PrintBoard()
    {
        Console.WriteLine();
        Console.WriteLine("    1   2   3");
        for (int r = 0; r < 3; r++)
        {
            Console.WriteLine($"{r + 1}   {board[r, 0]} | {board[r, 1]} | {board[r, 2]}");
            if (r < 2) Console.WriteLine("   ---+---+---");
        }
        Console.WriteLine();
    }
}