using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    public class InvalidMatrixOperationException:MatrixException
    {
        public override string Message { get; }
        public InvalidMatrixOperationException() : base()
        {
            Message = "This operation can't be performed on matrixes";
        }
        public InvalidMatrixOperationException(string str) : base(str) { }
        public InvalidMatrixOperationException(string str, Exception inner) : base(str, inner)
        { }
        protected InvalidMatrixOperationException(System.Runtime.Serialization.SerializationInfo si,
        System.Runtime.Serialization.StreamingContext sc) : base(si, sc) { }
        public override string ToString() { return Message; }
    }
}
