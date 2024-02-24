using System;
using MathematicClass.Properties.utils;

namespace MathematicClass
{
    internal class MathClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Add meg az (a) értéket!");
            var a = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Add meg a (b) értéket!");
            var b = Convert.ToInt32(Console.ReadLine());
            
            //TransformationFunction.GetValues(a, b);
        }
    }
}