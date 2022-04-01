using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Temel voidler için yazılır
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }



    }
}
