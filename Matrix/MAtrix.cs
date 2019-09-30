using System;
using System.Runtime.Serialization;
using System.Runtime;
using System.Text;
using System.Collections.Generic;

namespace Matrix
{
    [Serializable]
    public class Matrix
        : ICloneable, IComparable, IEquatable<Matrix>
    {
        public int NumberOfRows { get; }
        public int NumberOfCollums { get; }
        public List<List<double>> MatrixBody { get; }
        public Matrix(){}
        public Matrix(List<List<double>> matrix)
        {
            MatrixBody = new List<List<double>>();
            for (int i = 0; i < matrix.Count; i++)
            {
                MatrixBody.Add(new List<double>(matrix[i]));
            }
            NumberOfRows =MatrixBody.Count;
            NumberOfCollums = MatrixBody[0].Count;
        }
        public object Clone() => new Matrix(MatrixBody);
        public bool Equals(Matrix other)
        {
            try
            {
                if (other.NumberOfRows != this.NumberOfRows || other.NumberOfCollums != this.NumberOfCollums)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < this.NumberOfRows; i++)
                    {
                        for (int j = 0; j < this.NumberOfCollums; j++)
                        {
                            if (this[i, j] != other[i, j])
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public double Determinant() => Determinant(MatrixBody);
        public Matrix Minor(int excludedElementRow, int excludedElementCollumn) => new Matrix(Minor(excludedElementRow, excludedElementCollumn, MatrixBody));
        private double Determinant(List<List<double>> matrix)
        {
            try
            {
                if (matrix != null)
                {
                    double determinant = 0.0;
                    if (matrix.Count != 2)
                    {
                        for (int i = 0; i < matrix.Count; i++)
                        {
                            determinant += Math.Pow((-1), (i + 2)) * matrix[0][i] * Determinant(Minor(0, i, matrix));
                        }
                    }
                    else
                    {
                        determinant = matrix[0][0] * matrix[matrix.Count - 1][matrix.Count - 1] - matrix[matrix.Count - 1][0] * matrix[0][matrix.Count - 1];
                    }
                    return determinant;
                }
                else
                {
                    throw new ArgumentNullException("The matrix body is empty");
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("This matrix is empty.");
                return 0;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't find determinant");
                return 0;
            }
        }
        private List<List<double>> Minor(int z, int x, List<List<double>> matrix)
        {
            try
            {
                if (z >= NumberOfRows || x >= NumberOfCollums)
                {
                    throw new ArgumentOutOfRangeException("Excluded row and collumn can't be larger than matrix size");
                }
                else
                {
                    List<List<double>> A = new List<List<double>>();
                    for (int i = 0; i < matrix.Count - 1; i++)
                    {
                        List<double> row = new List<double>();
                        for (int j = 0; j < matrix.Count - 1; j++)
                        {
                            row.Add(0.0);
                        }
                        A.Add(row);
                    }
                    for (int h = 0, i = 0; i < matrix.Count - 1; i++, h++)
                    {
                        if (i == z) h++;
                        for (int k = 0, j = 0; j < matrix.Count - 1; j++, k++)
                        {
                            if (k == x) k++;
                            A[i][j] = matrix[h][k];
                        }
                    }
                    return A;
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't find minor");
                return null;
            }
        }
        public int CompareTo(object obj)
        {
            try
            {
                if (obj == null) return 1;
                Matrix otherMatrix = obj as Matrix;
                if (otherMatrix != null)
                {
                    return this.Determinant().CompareTo(otherMatrix.Determinant());
                }
                else
                {
                    throw new ArgumentException("This object is not a matrix");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't compare objects");
                return 0;
            }
        }
        public static Matrix operator +(Matrix left, Matrix right)
        {
            try
            {
                if (left == null || right == null)
                {
                    throw new ArgumentNullException("One or both matrixes are empty.");
                }
                else if (left.NumberOfRows != right.NumberOfRows || left.NumberOfCollums != right.NumberOfCollums)
                {
                    throw new UnmatchedMatrixSizesException("Addition can't be done on matrixes with different size");
                }
                else
                {
                    var result = new List<List<double>>();
                    for (int i = 0; i < left.NumberOfRows; i++)
                    {
                        var row = new List<double>();
                        for (int j = 0; j < left.NumberOfCollums; j++)
                        {
                            row.Add(left[i, j] + right[i, j]);
                        }
                        result.Add(row);
                    }
                    return new Matrix(result);
                }
            }
            catch (UnmatchedMatrixSizesException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't add matrixes");
                return null;
            }
        }
        public static Matrix operator -(Matrix left, Matrix right)
        {
            try
            {
                if (left == null || right == null)
                {
                    throw new ArgumentNullException("One or both matrixes are empty.");
                }
                else if (left.NumberOfRows != right.NumberOfRows || left.NumberOfCollums != right.NumberOfCollums)
                {
                    throw new UnmatchedMatrixSizesException("Substraction can't be done on matrixes with different size");
                }
                else
                {
                    var result = new List<List<double>>();
                    for (int i = 0; i < left.NumberOfRows; i++)
                    {
                        var row = new List<double>();
                        for (int j = 0; j < left.NumberOfCollums; j++)
                        {
                            row.Add(left[i, j] - right[i, j]);
                        }
                        result.Add(row);
                    }
                    return new Matrix(result);
                }
            }
            catch (UnmatchedMatrixSizesException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't add matrixes");
                return null;
            }
        }
        public static Matrix operator *(Matrix left, Matrix right)
        {
            try
            {
                if (left == null || right == null)
                {
                    throw new ArgumentNullException("One or both matrixes are empty.");
                }
                else if (left.NumberOfCollums != right.NumberOfRows)
                {
                    throw new UnmatchedMatrixSizesException("Multiplying can't be perfommed when left matrix number of collums and right matrix number of rows don't match");
                }
                else
                {
                    var result = new List<List<double>>();
                    for (int i = 0; i < left.NumberOfRows; i++)
                    {
                        var row = new List<double>();
                        for (int j = 0; j < right.NumberOfCollums; j++)
                        {
                            row.Add(0.0);
                            for (int k = 0; k < right.NumberOfRows; k++)
                            {
                                row[j] += left[i, k] * right[k, j];
                            }
                        }
                        result.Add(row);
                    }
                    return new Matrix(result);
                }
            }
            catch (UnmatchedMatrixSizesException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't add matrixes");
                return null;
            }
        }
        public static Matrix operator *(int number, Matrix matrix)
        {
            try
            {
                if (matrix == null)
                {
                    throw new ArgumentNullException("The matrix is empty");
                }
                else
                {
                    var result = new List<List<double>>();
                    for (int i = 0; i < matrix.NumberOfRows; i++)
                    {
                        var row = new List<double>();
                        for (int j = 0; j < matrix.NumberOfCollums; j++)
                        {
                            row.Add(matrix[i, j] * number);
                        }
                        result.Add(row);
                    }
                    return new Matrix(result);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't add matrixes");
                return null;
            }
        }
        public static Matrix operator *(Matrix matrix, int number) => number * matrix;
        public static Matrix operator *(double number, Matrix matrix)
        {
            try
            {
                if (matrix == null)
                {
                    throw new ArgumentNullException("The matrix is empty");
                }
                else
                {
                    var result = new List<List<double>>();
                    for (int i = 0; i < matrix.NumberOfRows; i++)
                    {
                        var row = new List<double>();
                        for (int j = 0; j < matrix.NumberOfCollums; j++)
                        {
                            row.Add(matrix[i, j] * number);
                        }
                        result.Add(row);
                    }
                    return new Matrix(result);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't add matrixes");
                return null;
            }
        }
        public static Matrix operator *(Matrix matrix, double number) => number * matrix;
        public static Matrix operator *(float number, Matrix matrix)
        {
            try
            {
                if (matrix == null)
                {
                    throw new ArgumentNullException("The matrix is empty");
                }
                else
                {
                    var result = new List<List<double>>();
                    for (int i = 0; i < matrix.NumberOfRows; i++)
                    {
                        var row = new List<double>();
                        for (int j = 0; j < matrix.NumberOfCollums; j++)
                        {
                            row.Add(matrix[i, j] * number);
                        }
                        result.Add(row);
                    }
                    return new Matrix(result);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't add matrixes");
                return null;
            }
        }
        public static Matrix operator *(Matrix matrix, float number) => number * matrix;
        public static Matrix operator *(Matrix matrix, byte number) => (int)number * matrix;
        public static Matrix operator *(byte number, Matrix matrix) => matrix * number;
        public static Matrix operator *(Matrix matrix, short number) => (int)number * matrix;
        public static Matrix operator *(short number, Matrix matrix) => matrix * number;
        public List<double> this[int i] => this.MatrixBody[i];
        public double this[int i, int j] => this.MatrixBody[i][j];
        public override string ToString()
        {
            try
            {
                if (this == null)
                {
                    throw new ArgumentNullException();
                }
                var sb = new StringBuilder();
                for (int i = 0; i < NumberOfRows; i++)
                {
                    for (int j = 0; j < NumberOfCollums; j++)
                    {
                        sb.Append($"{this[i, j]} ");
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("This matrix is empty");
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't convert to string");
                return null;
            }
        }
    }
}
