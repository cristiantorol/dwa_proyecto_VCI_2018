using System;

namespace VCI.Exceptions
{
    public class BatAssignmentException : Exception
    {
        public BatAssignmentException() : base("Mala asignación de variables") { }
    }
}
