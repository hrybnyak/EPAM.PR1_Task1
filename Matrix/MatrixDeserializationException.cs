using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    public class MatrixDeserializationException:MatrixException
    {
        public override string Message { get; }
        public MatrixDeserializationException() : base()
        {
            Message = "There is problem with matrix serialization";
        }
        public MatrixDeserializationException(string str) : base(str) { }
        public MatrixDeserializationException(string str, Exception inner) : base(str, inner)
        { }
        protected MatrixDeserializationException(System.Runtime.Serialization.SerializationInfo si,
        System.Runtime.Serialization.StreamingContext sc) : base(si, sc) { }
        public override string ToString() { return Message; }
    }
}
