using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    public class MatrixMinorException:MatrixException
    {
        public override string Message { get; }
        public MatrixMinorException() : base()
        {
            Message = "Couldn't find minor";
        }
        public MatrixMinorException(string str) : base(str) { }
        public MatrixMinorException(string str, Exception inner) : base(str, inner)
        { }
        protected MatrixMinorException(System.Runtime.Serialization.SerializationInfo si,
        System.Runtime.Serialization.StreamingContext sc) : base(si, sc) { }
        public override string ToString() { return Message; }
    }
}
