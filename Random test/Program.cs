using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Random_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(random.Next(0, 4));
            }
            Console.Read();
        }
    }
}
