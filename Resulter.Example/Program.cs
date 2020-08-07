using System;

namespace Resulter.Example
{
    class Program
    {
        private static void Main(string[] args)
        {
            var program = new Program();
            Test((object)program);
        }

        private static void Test<T>(T t)
        {
            var r = t is Program;
        }
    }
}