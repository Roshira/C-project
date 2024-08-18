using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryList
{
    public class Calculator
    {
        public void Calc()
        {
            long result = 0;
            Console.WriteLine("Calcularor");
            int oneNumber;
            int twoNumber;
            while (true)
            {
                Console.Clear();
                
                Console.WriteLine("Calcularor\n -------------------------------------------------\n");
                oneNumber =int.Parse(Console.ReadLine());
                char plus = char.Parse(Console.ReadLine());
                twoNumber = int.Parse(Console.ReadLine());
                switch (plus)
                {
                    case '+':
                        result = oneNumber + twoNumber;
                        break;
                    case '-':
                        result = oneNumber - twoNumber;
                        break;
                    case '*':
                        result = oneNumber * twoNumber;
                        break;
                    case '/':
                        result = oneNumber / twoNumber;
                        break;
                    case '%':
                        result = oneNumber % twoNumber;
                        break;

                }
                Console.WriteLine($"Your result: {result}");
                Console.WriteLine("Writing 1 for exit");
                byte next = byte.Parse(Console.ReadLine());
                if (next == 1)
                    break;

            }
        }

    }
}
