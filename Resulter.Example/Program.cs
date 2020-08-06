namespace Resulter.Example
{
    using System;
    using Extensions;
    using Resulter.Fabrics;

    class Program
    {
        private static void Main(string[] args)
        {
            var result = ResultFabric.CreateSuccess<Program, String>(new Program());
        }
    }
}