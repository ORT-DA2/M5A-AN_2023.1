using Interfaces;
using System;

namespace MultiplicadoPor3
{
    public class Class1 : IFunction
    {
        public int DoSomething(int input)
        {
            return input * 3;
        }

        public string GetName()
        {
            return "Multiplicar por 3";
        }
    }
}
