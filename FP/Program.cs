using System;
using System.Collections.Generic;
using System.Linq;

namespace FP
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<int> { 27, 99, 69, 34, 32, 30, 73, 28, 39, 82, 5, 54, 32, 66, 82, 46, 9, 15, 21, 15, 61, 13, 1, 94, 48, 77, 14, 1, 44, 84, 25, 68, 47, 49, 96, 47, 38, 95, 98, 52, 23, 21, 37, 95, 59, 74, 94, 61, 50, 50, 14, 75, 89, 82, 73, 39, 29, 8, 96, 91, 40, 6, 63, 90, 12, 31, 86, 51, 13, 76, 53, 38, 78, 29, 34, 49, 45, 67, 85, 3, 43, 29, 56, 20, 59, 80, 38, 49, 51, 7, 76, 51, 70, 21, 97, 36, 5, 67, 89, 44 };
            
            //: int -> int -> int
            Func<int, Func<int, int>> add = x => y => x + y;
            
            var add1To = add(1);

            //: int -> int -> int
            Func<List<int>, int> length = x => x.Aggregate((current, next) => add1To(current));
            //: int -> int -> int
            Func<int, Func<int, int>> divideBy = x => y => y / x;
            
            //: List<int> -> int
            Func<List<int>, int> sum = x => x.Aggregate((current, next) => add(current)(next));
            
            //: List<int> -> int
            Func<List<int>, int> avg = list => sum(list) / length(list);

            //: int -> int -> int
            Func<int, Func<int, int>> multiplyBy = x => y => x * y;

            //: int -> int -> bool
            Func<int, Func<int, bool>> isMultipleOf = x => y => y % x == 0;


            // Do whatever you want here
            Console.WriteLine(avg(input));

            Console.ReadKey();
        }
    }

    

    public static class FP
    {
        public static Func<T2> Compose<T1, T2>(Func<T1> f1, Func<T1, T2> f2)
        {
            return () => f2(f1());
        }

        public static Func<T1, T3> Compose<T1, T2, T3>(Func<T1, T2> f1, Func<T2, T3> f2)
        {
            return v => f2(f1(v));
        }
    }
}
