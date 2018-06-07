using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace prime
{
    class Program
    {
        static bool IsPrime(long n)
        {          
            for (long u = 3; u < Math.Sqrt(n); u += 2)
             {
                    if (n % u == 0)
                    {
                        return false;
                    }                   
             }
            return true;
        }

        static bool IsPrimeMult(long n)
        {
            bool result = false;

            if (n==30 || n==105 ) // чтобы не прописывать в isPrime() условие (n<4)
            {
                result = true;            
            }
            long first = 1;
            long second = 1;            

            for (int i= 5; i< Math.Pow(n, 1.0/3); i+=2)
            {
                if (IsPrime(i) == true && n%i==0)
                {
                    first = i;
                    break;
                }                
            }
            if (first!=1)
            {
                for (int i = (int)first + 2; i < Math.Pow(n / first, 1.0 / 2); i += 2)
                {
                    if (IsPrime(i) == true && n%i==0) 
                    {
                        second = i;
                        break;
                    }
                }
            }

            if (second!=1 && n%(first*second)==0) 
            {
                if (IsPrime(n/(first*second)))
                {
                    result = true;
                }
            }           
            return result;
        }


        static void Main(string[] args)
        {
            long N; // вводимое число
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите число для проверки");
                if (long.TryParse(Console.ReadLine(), out N) && N>0)
                {
                    break;
                }
                else Console.WriteLine("введите натуральное число");
                Thread.Sleep(1000);
            }
            bool prime = IsPrimeMult(N);
            if (prime)
            {
                Console.WriteLine("Число является произведением трех последовательных простых чисел");
            }
            else
            {
                Console.WriteLine("Число не является произведением трех последовательных простых чисел");
            }           
            Console.ReadLine();
        }
    }
}
