using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Matrix.MatrixOperators
{
    public static class MatrixDeserialization
    {
        public static void BinaryDeserialization(out Matrix matrix, string filename)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    matrix = (Matrix)bf.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                throw new MatrixDeserializationException();
            }
        }
        public static void BinaryDeserialization(out List<Matrix> list, string filename)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    list = (List<Matrix>)bf.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                throw new MatrixDeserializationException();
            }
        }
        public static void BinaryDeserialization(out Matrix[] array, string filename)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    array = (Matrix[])bf.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                throw new MatrixDeserializationException();
            }
        }
    }
}
