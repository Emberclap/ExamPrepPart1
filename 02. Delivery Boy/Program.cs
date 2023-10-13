using System.Security.AccessControl;

namespace _02._Delivery_Boy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];
            int startRowIndex = 0;
            int startColIndex = 0;
            int deliveryBoyRowIndex = 0;
            int deliveryBoyColIndex = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] col = Console.ReadLine().ToArray();


                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = col[cols];
                    if (col[cols] == 'B')
                    {
                        deliveryBoyRowIndex = rows;
                        deliveryBoyColIndex = cols;
                        startRowIndex = rows;
                        startColIndex = cols;
                    }
                }
            }
            string command = Console.ReadLine();
            bool delivery = true;
            while (delivery)
            {
                switch (command)
                {
                    case "up":
                        if (BoundaryCheck(deliveryBoyRowIndex - 1, deliveryBoyColIndex, matrix))
                        {
                            if (Obstacle(deliveryBoyRowIndex - 1, deliveryBoyColIndex, matrix))
                            {
                                deliveryBoyRowIndex--;
                                PositionActions(deliveryBoyRowIndex, deliveryBoyColIndex, matrix);
                            }
                        }
                        else
                        {
                            delivery = false;
                        }
                        break;
                    case "down":
                        if (BoundaryCheck(deliveryBoyRowIndex + 1, deliveryBoyColIndex, matrix))
                        {
                            if (Obstacle(deliveryBoyRowIndex + 1, deliveryBoyColIndex, matrix))
                            {
                                 deliveryBoyRowIndex++;
                                 PositionActions(deliveryBoyRowIndex, deliveryBoyColIndex, matrix);
                            }
                        }
                        else
                        {
                            delivery = false;
                        }
                        break;
                    case "right":
                        if (BoundaryCheck(deliveryBoyRowIndex, deliveryBoyColIndex + 1, matrix))
                        {
                            if (Obstacle(deliveryBoyRowIndex, deliveryBoyColIndex + 1, matrix))
                            {
                                deliveryBoyColIndex++;
                                PositionActions(deliveryBoyRowIndex, deliveryBoyColIndex, matrix);
                            }
                        }
                        else
                        {
                            delivery = false;
                        }
                        break;
                    case "left":
                        if (BoundaryCheck(deliveryBoyRowIndex, deliveryBoyColIndex - 1, matrix))
                        {
                            if (Obstacle(deliveryBoyRowIndex, deliveryBoyColIndex - 1, matrix))
                            {
                                deliveryBoyColIndex--;
                                PositionActions(deliveryBoyRowIndex, deliveryBoyColIndex, matrix);
                            }
                        }
                        else
                        {
                            delivery = false;
                        }
                        break;
                }
                if (matrix[deliveryBoyRowIndex, deliveryBoyColIndex] == 'P'|| delivery == false)
                {
                    break;
                }
                
                command = Console.ReadLine();
            }
            if (!delivery)
            {
                matrix[startRowIndex, startRowIndex] = ' ';
                Console.WriteLine("The delivery is late. Order is canceled.");
            }
            


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }

        public static bool BoundaryCheck(int rowIndex, int colIndex, char[,] matrix)
        {
            if (rowIndex >= 0 && colIndex >= 0 && rowIndex < matrix.GetLength(0) && colIndex < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static char[,] PositionActions(int rowIndex, int colIndex, char[,] matrix)
        {
            if (matrix[rowIndex, colIndex] == 'P')
            {
                matrix[rowIndex, colIndex] = 'R';
                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
            }
            else if (matrix[rowIndex, colIndex] == 'A')
            {
                matrix[rowIndex, colIndex] = 'P';
                Console.WriteLine("Pizza is delivered on time! Next order...");
            }
            else if(matrix[rowIndex, colIndex] == '-')
            {
                matrix[rowIndex, colIndex] = '.';
            }
            return matrix;
        }
        public static bool Obstacle(int rowIndex, int colIndex, char[,] matrix)
        {
            if (matrix[rowIndex, colIndex] == '*')
            {
                return false;
            }
            else { return true; }
        }
    }
}