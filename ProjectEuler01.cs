/**
If we list all the natural numbers below 10 that are multiples of 3 or 5,

we get 3, 5, 6 and 9. The sum of these multiples is 23. 

Find the sum of all the multiples of 3 or 5 below 1000.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//multiply 3 until it gets to 100 while saving every multiple in an array.
namespace Project_Euler01
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 div3 = (1000 + 3 - 1) / 3 ; //VERY IMPORTANT. HOW TO ROUND UP
            
            Int64 div5 = (1000 + 5 - 1) / 5;
            Int64[] arr3 = new Int64[div3];
            Int64[] arr5 = new Int64[div5];
            fillarr3(arr3);
           dupe();
           
            Console.ReadKey();

        }
        static void fillarr3(Int64[] arr)
        {
            Int64 in3 = 3;
            Int64 x = 1;
            Int64 y = (1000 + 3 - 1) / 3;
            for (Int64 i = 1; i <= y; i++)
            {
                arr[i-1] = x;
                x = i * in3;
                
            }
        }
        static void fillarr5(Int64[] arr)
        {
            Int64 in5 = 5;
            Int64 x = 1;
            Int64 y = (1000 + 5 - 1) / 5;
            for (Int64 i = 1; i <= y; i++)
            {
                arr[i-1] = x;
                x = i * in5;
                
            }
        }
        static void dupe()
        {
            
            Int64 div3 = (1000 + 3 - 1) / 3 ; //VERY IMPORTANT. HOW TO ROUND UP
            Int64 div5 = (1000 + 5 - 1) / 5;
            Int64[] arr1 = new Int64[div3];
            Int64[] arr2 = new Int64[div5];
            Int64[] arr3 = new Int64[Math.Abs(arr1.Length + arr2.Length) / 2];
            fillarr3(arr1);
            fillarr5(arr2);
            //int[] a3 = new int[arr1.Length + arr2.Length];
            //arr1.CopyTo(a3, 0);
            //arr2.CopyTo(a3, arr1.Length);
            //var result = arr1.Union(arr2).ToArray();
            //result = arr1.Concat(arr2).OrderBy(v =>Math.Abs(v)).ToArray();
            var result = arr1.Concat(arr2).Distinct().OrderBy(v =>Math.Abs(v)).ToArray();

            Int64 sum = result.Sum();
            Console.WriteLine(sum);
            foreach (int i in result)
                Console.WriteLine(i);

            Console.WriteLine(sum - 1);
        }
    }
}
