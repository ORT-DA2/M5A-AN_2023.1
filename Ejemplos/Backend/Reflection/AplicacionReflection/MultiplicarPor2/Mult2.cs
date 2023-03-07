using Interfaces;
using System;

namespace MultiplicarPor2
{
    public class Mult2 : IFunction
    {
        public int DoSomething(int input)
        {
            return (input * 2);
        }

        public string GetName()
        {
            return "Multiplicar por 2";
        }
    }
}
