namespace Resulter.Example
{
    using System;
    using Extensions;
    using Factories;

    class Program
    {
        static void Main(string[] args)
        {
            var r = ResultFactory.CreateFailure<string>("tes", "a");

            if (r.IsFailure(out var f))
            {
            }
        }
    }
}