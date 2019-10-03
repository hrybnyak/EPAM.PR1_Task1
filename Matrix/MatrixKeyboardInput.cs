using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix.MatrixOperators
{
    public static class MatrixKeyboardInput
    {
        public static Matrix KeyboardInput()
        {
            try
            {
                Console.WriteLine("Press e to exit");
                Console.WriteLine("Please enter number of rows in matrix (it has to be integer):");
                if (Int32.TryParse(Console.ReadLine(), out int rows))
                {
                    Console.WriteLine("Please enter number of collums in matrix (it has to be integer):");
                    if (Int32.TryParse(Console.ReadLine(), out int collums))
                    {
                        Console.WriteLine("Start entering matrix elements (it has to be integer of floating point number):");
                        var matrix = new List<List<double>>();

                        for (int i = 0; i < rows; i++)
                        {
                            var row = new List<double>();
                            int cursorePosition = 0;
                            for (int j = 0; j < collums; j++)
                            {
                                if (Double.TryParse(Console.ReadLine(), out double number))
                                {
                                    row.Add(number);
                                    Console.CursorTop--;
                                    cursorePosition += (number.ToString().Length) + 1;
                                    Console.CursorLeft = cursorePosition;
                                }
                                else
                                {
                                    throw new ArgumentException();
                                }
                            }
                            Console.WriteLine();
                            matrix.Add(row);
                        }
                        Matrix result = new Matrix(matrix);
                        return result;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new MatrixException(ex.Message);
            }
        }
    }
}
