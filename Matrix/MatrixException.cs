using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    public class MatrixException : Exception
    {
        public override string Message { get; }
        public MatrixException() : base()
        {
            Message = "There is problem with matrix";
        }
        public MatrixException(string str) : base(str) { }
        public MatrixException(string str, Exception inner) : base(str, inner)
        { }
        protected MatrixException(System.Runtime.Serialization.SerializationInfo si,
        System.Runtime.Serialization.StreamingContext sc) : base(si, sc) { }
        public override string ToString() { return Message; }
    }
}
