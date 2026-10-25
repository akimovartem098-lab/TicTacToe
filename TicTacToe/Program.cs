using System;

class Program
{
    static char[,] board = new char[3, 3];

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        do
        {
            PlayGame();
        } while (AskRestart());

        Console.WriteLine("Спасибо за игру!");
    }

    static void PlayGame()
    {
        InitBoard();
        char currentPlayer = 'X';

        while (true)
        {
            PrintBoard();
            Console.WriteLine($"Ход игрока {currentPlayer}");

            var (row, col) = ReadMove();
            board[row, col] = currentPlayer;

            if (CheckWin(currentPlayer))
            {
                PrintBoard();
                Console.WriteLine($"Победил игрок {currentPlayer}!");
                return;
            }

            if (IsDraw())
            {
                PrintBoard();
                Console.WriteLine("Ничья!");
                return;
            }

            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }

    static bool AskRestart()
    {
        while (true)
        {
            Console.Write("Сыграть ещё раз? (y/n): ");
            string answer = (Console.ReadLine() ?? "").Trim().ToLower();

            if (answer == "y") return true;
            if (answer == "n") return false;

            Console.WriteLine("Введите y или n.");
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

            return (row, col);
        }
    }

    static bool CheckWin(char p)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == p && board[i, 1] == p && board[i, 2] == p) return true;
            if (board[0, i] == p && board[1, i] == p && board[2, i] == p) return true;
        }

        if (board[0, 0] == p && board[1, 1] == p && board[2, 2] == p) return true;
        if (board[0, 2] == p && board[1, 1] == p && board[2, 0] == p) return true;

        return false;
    }

    static bool IsDraw()
    {
        for (int r = 0; r < 3; r++)
            for (int c = 0; c < 3; c++)
                if (board[r, c] == ' ')
                    return false;

        return true;
    }
}