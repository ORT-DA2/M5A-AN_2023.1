using Interfaces;
using System;

namespace MultiplicadoPor10
{
    public class Class1 : IFunction
    {
        public int DoSomething(int input)
        {
            return input * 10;
        }

        public string GetName()
        {
            return "Multiplicar por 10";
        }
    }
}
