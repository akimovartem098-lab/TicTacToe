using System;

class Program
{
    static char[,] board = new char[3, 3];

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        InitBoard();
        PrintBoard();
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