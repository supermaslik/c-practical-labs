using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Небезопасный_код
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            var mass = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, -9, 2 };
            var pointerToMaxModElement = PositionOfMaxModElement(mass);

            Console.WriteLine(*pointerToMaxModElement);
            Console.WriteLine(SumAfterFirstPositive(mass));
            Console.ReadKey();
        }

        public static unsafe int* PositionOfMaxModElement(int[] mass)
        {
            var sell = 0;
            int* maxModValue = &sell;
            *maxModValue = 0;
            for (int i = 0; i < mass.Length; i++)
                if (Math.Abs(mass[i]) >= Math.Abs(*maxModValue))
                    *maxModValue = mass[i];


            return maxModValue;
        }
        public static int SumAfterFirstPositive(int[] mass)
        {
            int sum = 0;
            for(int i = 0; i < mass.Length; i++)
                if(mass[i] >= 0)
                {
                    for (int j = i; j < mass.Length; j++)
                        sum += mass[j];
                    break;
                }
            return sum;
        }

    }
}
