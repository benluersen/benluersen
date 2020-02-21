using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farenheit_Reverse_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            for(double i =0; i <100; i++)
            {
                int j = Convert.ToInt32(Math.Round((i * 9 / 5) + 32));
                string iString = i.ToString();
                string jString = j.ToString();
                var jStringReverse = new String(jString.Reverse().ToArray());
                if(iString == jStringReverse)
                {
                    Console.WriteLine(iString);
                }

            }
            Console.ReadKey();
        }
    }
}
