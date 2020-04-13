using System;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] tableArray;
            Console.WriteLine("Welcome to Mobile App-Program 1!");
            // Asks user the the number between 3 and 9
            Console.Write("Please enter a number between 3 and 9: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                // Create a times table using that number
                tableArray=CreateTimesTable(num);
                TransformTimes[] xOperation = { new Horizontal(), new Vertical(), new DiagonalLeft(), new DiagonalRight() };
                Boolean done = false;
                while (!done)
                {
                    // Output a menu "Flip on 1) Horizon, 2) Vertical, 3) Diagonal Left, 4) Diagonal Right, 5) To End: "
                    // I read the instructions as meaning transform the original table.
                    // But the table itself is passed into the transform functions.
                    // To transform the table in sequence, write the new transformed table into the 2D array
                    // and update the transform methods to return the array.
                    Console.WriteLine("Transform the table (will always transform the *original* table)");
                    Console.WriteLine("Flip on ");
                    Console.Write("  1) Horizon, 2) Vertical, 3) Diagonal Left, 4) Diagonal Right, 5) To End: ");
                    if (int.TryParse(Console.ReadLine(), out int flipChoice))
                    {
                        if (flipChoice==5)
                        {
                            done = true;
                        } else if (flipChoice > 0 && flipChoice < 5)
                        {
                            // Based upon selection, output the table with the new orientation, followed by the menu unless 5 is selected.
                            xOperation[flipChoice - 1].OutputTransform(tableArray);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid flip choice.");
                    }

                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer between 3 and 9.");
            }

        }

        private static int[,] CreateTimesTable(int num)
        {
            int[,] tableArray = new int[num, num];
            for (int i=0; i<num; i++)
            {
                for (int j=0; j<num; j++)
                {
                    tableArray[i, j] = (i+1) * (j+1);
                    Console.Write($"{tableArray[i, j]}\t");
                }
                Console.WriteLine();
            }
            return tableArray;
        }
    }

    abstract class TransformTimes
    {
        public abstract void OutputTransform(int[,] tableArray);
    }

    class Horizontal: TransformTimes
    {
        override public void OutputTransform(int[,] tableArray)
        {
            int num = tableArray.GetLength(0);
            Console.WriteLine("Outputting horizontal transform");
            for (int i = num-1; i >= 0; i--)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write($"{tableArray[i,j]}\t");
                }
                Console.WriteLine();
            }

        }
    }
    class Vertical : TransformTimes
    {
        override public void OutputTransform(int[,] tableArray)
        {
            int num = tableArray.GetLength(0);
            Console.WriteLine("Outputting vertical transform");
            for (int i = 0; i < num; i++)
            {
                for (int j = num-1; j >= 0; j--)
                {
                    Console.Write($"{tableArray[i, j]}\t");
                }
                Console.WriteLine();
            }

        }
    }

    class DiagonalLeft : TransformTimes
    {
        override public void OutputTransform(int[,] tableArray)
        {
            int num = tableArray.GetLength(0);
            Console.WriteLine("Outputting diagonal left transform (flipping around left-leaning diagonal)");
            for (int j = 0; j < num; j++)
            {
                for (int i = 0; i < num; i++)
                {
                    Console.Write($"{tableArray[i, j]}\t");
                }
                Console.WriteLine();
            }

        }
    }

    class DiagonalRight : TransformTimes
    {
        override public void OutputTransform(int[,] tableArray)
        {
            int num = tableArray.GetLength(0);
            Console.WriteLine("Outputting diagonal right transform (flipping around forward slash diagonal)");
            for (int j = num-1; j >= 0; j--)
            {
                for (int i = num - 1; i >= 0; i--)
                {
                    Console.Write($"{tableArray[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }

}

