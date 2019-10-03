using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    
    public class UnmatchedMatrixSizesException:MatrixException
    {
        public override string Message { get; } 
        public UnmatchedMatrixSizesException() : base()
        {
            Message = "Matrixes' sizes mismatch";
        }
        public UnmatchedMatrixSizesException(string str) : base(str) {}
        public UnmatchedMatrixSizesException(string str, Exception inner) : base(str, inner)
        { }
        protected UnmatchedMatrixSizesException(System.Runtime.Serialization.SerializationInfo si,
        System.Runtime.Serialization.StreamingContext sc) : base(si, sc) {}
        public override string ToString() { return Message; }
    }
   
}
