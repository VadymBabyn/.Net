using MatrixTraversalAlgorithms.Common;

namespace MatrixTraversalAlgorithms 
{

    public class Task1V08
    {
        public MinListLeftRightResponse Calculate(int[,] matrix, int k)
        {        
                int rows = matrix.GetLength(0);
                int cols = matrix.Length / matrix.GetLength(0);
                int halfCols = cols / 2; // Знайдемо середину по горизонталі
                int[] arrayK = new int[matrix.Length];
                int count = 0;
                // Виводимо матрицю "змійкою" по діагоналі в першій половині
                for (int diag = rows + halfCols - 2; diag >= 0; diag--)
                {
                    if (diag % 2 != 0)
                    {
                        for (int i = Math.Min(diag, rows - 1); i >= Math.Max(0, diag - halfCols + 1); i--)
                        {
                            int j = halfCols - 1 - (diag - i);
                            Console.Write(matrix[i, j] + " ");
                            if (matrix[i, j] < k)
                            {
                                arrayK[count] = matrix[i, j];
                                count++;
                            }
                        }
                    }
                    else
                    {
                        for (int i = Math.Max(0, diag - halfCols + 1); i <= Math.Min(diag, rows - 1); i++)
                        {
                            int j = halfCols - 1 - (diag - i);
                            Console.Write(matrix[i, j] + " ");
                            if (matrix[i, j] < k)
                            {
                                arrayK[count] = matrix[i, j];
                                count++;
                            }
                        }
                    }
                }


                // Розділюємо половини пропуском
                Console.WriteLine();
                // Виводимо другу половину матриці "змійкою" по горизонталі (починаємо з 5)
                int startRow = 0;
                int startCol = halfCols;

                for (int i = startRow; i < rows; i++)
                {
                    if (i % 2 == 0)
                    {
                        for (int j = startCol; j < cols; j++)
                        {
                            Console.Write(matrix[i, j] + " ");
                            if (matrix[i, j] < k)
                            {
                                arrayK[count] = matrix[i, j];
                                count++;
                            }
                        }
                    }
                    else
                    {
                        for (int j = cols - 1; j >= startCol; j--)
                        {
                            Console.Write(matrix[i, j] + " ");
                            if (matrix[i, j] < k)
                            {
                                arrayK[count] = matrix[i, j];
                                count++;
                            }
                        }
                    }
                }
                Console.WriteLine();
                for (int i = 0; i < arrayK.Length; i++)
                {
                    if (arrayK[i] != 0)
                    {
                        Console.WriteLine(arrayK[i]);
                    }

                }
                throw new NotImplementedException();
        }     
    }
}

