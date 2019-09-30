using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Matrix.MatrixOperators
{
    public static class MatrixSerializer
    {
        public static void BinarySerialization(Matrix matrix, string filename)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    bf.Serialize(fs, matrix);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't serialize matrix");
            }
        }
        public static void BinarySerialization(List<Matrix> list, string filename)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    bf.Serialize(fs, list);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't serialize list of matrixes");
            }
        }
        public static void BinarySerialization(Matrix[] array, string filename)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    bf.Serialize(fs, array);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't serialize list of matrixes");
            }
        }
    }
}
