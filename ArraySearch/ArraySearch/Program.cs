using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }.OrderBy(t => t).ToArray();
            var values = new[] { 5, 3, -1, 18, 1, 7 };
            var subCol = new[] { 2, 4, 8 };

            foreach (var col in subCol)
            {
                foreach (var value in values)
                {
                    var idx = Search(arr, col, value);

                    Console.WriteLine($"Index of {value}: {idx}");
                }

                Console.WriteLine("------------------------");
            }

            Console.ReadKey();
        }

        static int Search(int[] array, int ncol, int value) => Search(array, 0, ncol, value);

        static int Search(int[] array, int index, int ncol, int value)
        {
            if (ncol == 0 || !array.Any() || array.FirstOrDefault() > value) return -1;
            if (array.FirstOrDefault() == value) return index;

            var skip = 0;
            int[] subArr = null;

            do
            {
                if (skip > array.Length) return -1;

                var firstNext = array.Skip(ncol + skip).FirstOrDefault();

                if (firstNext > value)
                    subArr = array.Skip(skip).Take(ncol).ToArray();
                else if (firstNext == value)
                    return index + skip + ncol;
                else
                {
                    if (skip + ncol >= array.Length)
                        subArr = array.Skip(skip).Take(ncol).ToArray();
                    else
                        skip += ncol;
                }
            }
            while (subArr == null);

            return Search(subArr, index + skip, ncol / 2, value);
        }
    }
}
