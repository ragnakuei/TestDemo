using System;

namespace TestDemo
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { Detail = $"Detail:{message}"; }

        public string Detail { get; private set; }
    }
}