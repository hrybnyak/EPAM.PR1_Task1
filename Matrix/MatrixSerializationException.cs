using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    public class MatrixSerializationException:MatrixException
    {
        public override string Message { get; }
        public MatrixSerializationException() : base()
        {
            Message = "There is problem with matrix serialization";
        }
        public MatrixSerializationException(string str) : base(str) { }
        public MatrixSerializationException(string str, Exception inner) : base(str, inner)
        { }
        protected MatrixSerializationException(System.Runtime.Serialization.SerializationInfo si,
        System.Runtime.Serialization.StreamingContext sc) : base(si, sc) { }
        public override string ToString() { return Message; }
    }
}
