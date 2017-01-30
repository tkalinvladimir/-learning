using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsComplexity
{
    class Methods
    {
        public int GetCount(int[] items) // константный порядок роста O(1) - вычислительная сложность алгоритма не зависит от размера входных данных
        {
            return items.Length;
        }

        public long GetSum(int[] items) // линейный порядок роста - сложность алгоритма растет линейно с увеличением входного массива
        {
            long sum = 0;
            foreach (int i in items)
            {
                sum += i;
            }
            return sum;
        }
    }
}
