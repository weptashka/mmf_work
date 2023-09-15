using System;

namespace BitOperationsTask
{
    /// <summary>
    /// Provides static method for working with integers.
    /// </summary>
    public static class King
    {
        /// <summary>
        /// Inserts first (j - i + 1), (i less or equals j) bits sequence from second number into first number from i to j position.
        /// </summary>
        /// <param name="moves">moves.</param>
        /// <returns>Changed first number (see summary).</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when i or j is less than 0 or more than 31.</exception>
        /// <exception cref="ArgumentException">Thrown when i is more than j.</exception>
        public static int LonelyKing(string moves)
        {
            if (moves.Length < 0)
            {
                throw new NotImplementedException("Number of moves cannot be negative");
            }

            if (moves.Length == 0)
            {
                throw new NotImplementedException("The king didn't budge");
            }

            string[] stringMove = moves.Split(' ');
            List<int> Moves = new List<int>();

            foreach (var step in stringMove)
            {
                bool isNumber = int.TryParse(step, out int numericValue);

                if (isNumber)
                {
                    if ((numericValue > 8) || (numericValue < 1))
                    {
                        throw new NotImplementedException("This direction does not exist.");
                    }
                    else
                    {
                        Moves.Add(numericValue);
                    }
                }
                else
                {
                    throw new NotImplementedException("You entered more than just a numbers");
                }
            }

            int[,] x = new int[2001, 2001];
            int xPos = 1001, yPos = 1001, i = 0;

            foreach (var move in Moves)
            {
                if (x[xPos, yPos] == 1)
                {
                    return i;
                }
                else
                {
                    i++;
                    x[xPos, yPos] = 1;
                }

                if (move == 1)
                {
                    yPos++;
                }

                if (move == 2)
                {
                    xPos++;
                    yPos++;
                }

                if (move == 3)
                {
                    xPos++;
                }

                if (move == 4)
                {
                    xPos++;
                    yPos--;
                }

                if (move == 5)
                {
                    yPos--;
                }

                if (move == 6)
                {
                    xPos--;
                    yPos--;
                }

                if (move == 7)
                {
                    xPos--;
                }

                if (move == 8)
                {
                    xPos--;
                    yPos++;
                }
            }

            throw new NotImplementedException("The king did not step on the cells twice");
        }
    }
}
