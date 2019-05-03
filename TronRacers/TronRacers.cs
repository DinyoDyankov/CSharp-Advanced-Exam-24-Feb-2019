namespace TronRacers
{
    using System;
    using System.Linq;

    public class TronRacers
    {
        public static void Main()
        {
            var matrixRows = int.Parse(Console.ReadLine());

            var matrix = new char[matrixRows][];

            var playerOneRow = -1;
            var playerOneColumn = -1;
            var playerOneSymbol = 'f';

            var playerTwoRow = -1;
            var playerTwoColumn = -1;
            var playerTwoSymbol = 's';


            for (int row = 0; row < matrixRows; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                if (currentRow.Contains('f'))
                {
                    playerOneRow = row;
                    playerOneColumn = Array.IndexOf(currentRow,'f');
                }

                if (currentRow.Contains('s'))
                {
                    playerTwoRow = row;
                    playerTwoColumn = Array.IndexOf(currentRow, 's');
                }

                matrix[row] = currentRow;
            }

            var isPlayerDead = false;

            while (true)
            {
                var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var firstPlayerCommand = command[0];
                var secondPlayerCommand = command[1];

                var playerNewOneCoordinates = PlayerMoves(matrix, firstPlayerCommand, playerOneRow, playerOneColumn);
                playerOneRow = playerNewOneCoordinates.Item1;
                playerOneColumn = playerNewOneCoordinates.Item2;

                matrix = UpdateMatrix(matrix, playerOneRow, playerOneColumn, playerOneSymbol);

                isPlayerDead = CheckIfPlayerIsDead(matrix, playerOneRow, playerOneColumn);

                if (isPlayerDead)
                {
                    break;
                }

                var playerTwoCoordinates = PlayerMoves(matrix, secondPlayerCommand, playerTwoRow, playerTwoColumn);
                playerTwoRow = playerTwoCoordinates.Item1;
                playerTwoColumn = playerTwoCoordinates.Item2;

                matrix = UpdateMatrix(matrix, playerTwoRow, playerTwoColumn, playerTwoSymbol);

                isPlayerDead = CheckIfPlayerIsDead(matrix, playerTwoRow, playerTwoColumn);

                if (isPlayerDead)
                {
                    break;
                }
            }

            Print(matrix);
        }

        private static bool CheckIfPlayerIsDead(char[][] matrix, int playerRow, int playerColumn)
        {
            if (matrix[playerRow][playerColumn] == 'x')
            {
                return true;
            }

            return false;
        }

        private static char[][] UpdateMatrix(char[][] matrix, int playerRow, int playerColumn, char playerSymbol)
        {
            char enemyPlayer = playerSymbol == 'f' ? 's' : 'f';

            if (matrix[playerRow][playerColumn] == enemyPlayer)
            {
                matrix[playerRow][playerColumn] = 'x';
                return matrix;
            }
                
            matrix[playerRow][playerColumn] = playerSymbol;
            return matrix;
        }

        private static Tuple<int, int> PlayerMoves(char[][] matrixFields, string playerCommand, int playerRow, int playerColumn)
        {
            switch (playerCommand)
            {
                case "up":
                    if (PlayerIsInMatrixBounds(matrixFields, playerRow - 1, playerColumn))
                    {
                        playerRow -= 1;
                    }
                    else
                    {
                        playerRow = matrixFields.Length - 1;
                    }
                    break;
                case "down":
                    if (PlayerIsInMatrixBounds(matrixFields, playerRow + 1, playerColumn))
                    {
                        playerRow += 1;
                    }
                    else
                    {
                        playerRow = 0;
                    }
                    break;
                case "left":
                    if (PlayerIsInMatrixBounds(matrixFields, playerRow, playerColumn - 1))
                    {
                        playerColumn -= 1;
                    }
                    else
                    {
                        playerColumn = matrixFields[playerRow].Length - 1;
                    }
                    break;
                case "right":
                    if (PlayerIsInMatrixBounds(matrixFields, playerRow, playerColumn + 1))
                    {
                        playerColumn += 1;
                    }
                    else
                    {
                        playerColumn = 0;
                    }
                    break;
            }

            return new Tuple<int, int>(playerRow, playerColumn);
        }

        private static bool PlayerIsInMatrixBounds(char[][] matrix, int playerRow, int playerColumn)
        {
            return playerRow < matrix.Length && playerRow >= 0 && playerColumn < matrix[playerRow].Length && playerColumn >= 0;
        }

        public static void Print(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
