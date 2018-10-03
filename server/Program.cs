using System;

namespace dotnettest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello There!");
            var name= Console.ReadLine();
            
            Console.WriteLine("Hello {0}!!!", name);
        }
    }
}
