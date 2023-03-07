using Interfaces;
using System;

namespace AlCuadrado
{
    public class AlCuadrado : IFunction
    {
        public int DoSomething(int input)
        {
            return (input * input);
        }

        public string GetName()
        {
            return "Al cuadrado";
        }
    }
}
