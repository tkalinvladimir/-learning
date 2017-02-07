using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sort
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] arraytosort = new int[] { 3, 7, 4, 4, 6, 5, 8 };
            Methods<int>.printArray(arraytosort);
            Methods<int>.sort_puzir(arraytosort);
            Methods<int>.printArray(arraytosort);
            arraytosort = new int[] { 3, 7, 4, 4, 6, 5, 8 };
            Methods<int>.sort_insertion(arraytosort);
            Methods<int>.printArray(arraytosort);
            arraytosort = new int[] { 3, 7, 4, 4, 6, 5, 8 };
            Methods<int>.sort_vibor(arraytosort);
            Methods<int>.printArray(arraytosort);
            arraytosort = new int[] { 3, 7, 4, 4, 6, 5, 8 };
            Console.WriteLine("Сортировка слиянием.");
            Methods<int>.sort_sliyanie(arraytosort);
            Methods<int>.printArray(arraytosort);
            Console.ReadKey();
        }
    }
}
