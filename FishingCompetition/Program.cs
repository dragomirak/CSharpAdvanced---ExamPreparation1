namespace FishingCompetition;

public class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char[,] matrix = new char[size, size];
        CreateMatrix(matrix);

        int currentRow = 0;
        int currentCol = 0;
        int fishCaught = 0;
        bool quotaReached = false;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'S')
                {
                    currentRow = row;
                    currentCol = col;
                }
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "collect the nets")
        {
            matrix[currentRow, currentCol] = '-';

            if (command == "up")
            {
                currentRow--;
                if (currentRow < 0)
                {
                    currentRow = matrix.GetLength(0) - 1;
                }
            }
            else if (command == "down")
            {
                currentRow++;
                if (currentRow > matrix.GetLength(0) - 1)
                {
                    currentRow = 0;
                }
            }
            else if (command == "left")
            {
                currentCol--;
                if (currentCol < 0)
                {
                    currentCol = matrix.GetLength(1) - 1;
                }
            }
            else if (command == "right")
            {
                currentCol++;
                if (currentCol > matrix.GetLength(1) - 1)
                {
                    currentCol = 0;
                }
            }

            if (matrix[currentRow, currentCol] == '-')
            {
                matrix[currentRow, currentCol] = 'S';
                continue;
            }
            else if (matrix[currentRow, currentCol] == 'W')
            {
                Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. " +
                    $"Last coordinates of the ship: [{currentRow},{currentCol}]");
                return;
            }
            else
            {
                fishCaught += int.Parse(matrix[currentRow, currentCol].ToString());
                if (fishCaught >= 20)
                {
                    quotaReached = true;
                }
                matrix[currentRow, currentCol] = 'S';
                continue;
            }
        }

        if (quotaReached)
        {
            Console.WriteLine("Success! You managed to reach the quota!");
        }
        else
        {
            Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! " +
                $"You need {20 - fishCaught} tons of fish more.");
        }

        if (fishCaught > 0)
        {
            Console.WriteLine($"Amount of fish caught: {fishCaught} tons.");
        }

        PrintMatrix(matrix);

    }

    private static void CreateMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] charArray = Console.ReadLine().ToCharArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = charArray[col];
            }
        }
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}