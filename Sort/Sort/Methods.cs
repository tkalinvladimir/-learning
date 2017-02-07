using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public static class Methods<T> where T : IComparable
    {
        public static void Swap(T[] items, int left, int right)
        {
            T temp = items[left];
            items[left] = items[right];
            items[right] = temp;
        }

        public static void sort_puzir(T[] items)
        {
            bool swapped;
            Console.WriteLine("Сортировка пузырьком.");
            do
            {
                swapped = false;
                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i - 1].CompareTo(items[i]) > 0)
                    {
                        Swap(items, i - 1, i);
                        swapped = true;
                    }
                }
            } while (swapped == false);

        }

        public static void printArray(T[] items)
        {
            foreach (var smth in items)
            {
                Console.Write(smth + " ");
            }
            Console.WriteLine();
        }

        public static int FindInsertionIndex(T[] items, T valueToInsert)
        {
            for (int index = 0; index < items.Length; index++)
            {
                if (items[index].CompareTo(valueToInsert) > 0)
                {
                    return index;
                }
            }

            throw new InvalidOperationException("The insertion index was not found");
        }

        public static void Insert(T[] itemArray, int indexInsertingAt, int indexInsertingFrom)
        {
            // itemArray =       0 1 2 4 5 6 3 7
            // insertingAt =     3
            // insertingFrom =   6
            // 
            // Действия:
            //  1: Сохраняем индекс в temp     temp = 4
            //  2: Поменять индекс на  -&gt; 0 1 2 3 5 6 3 7   temp = 4
            //  3: Перейти от индекса от к индексу к + 1.
            //     Сдвинуть элементы влево на один.
            //     0 1 2 3 5 6 6 7   temp = 4
            //     0 1 2 3 5 5 6 7   temp = 4
            //  4: Записать temp на позицию от + 1.
            //     0 1 2 3 4 5 6 7   temp = 4

            // Шаг 1.
            T temp = itemArray[indexInsertingAt];

            // Шаг 2.

            itemArray[indexInsertingAt] = itemArray[indexInsertingFrom];

            // Шаг 3.
            for (int current = indexInsertingFrom; current > indexInsertingAt; current--)
            {
                itemArray[current] = itemArray[current - 1];
            }

            // Шаг 4.
            itemArray[indexInsertingAt + 1] = temp;
        }

        public static void sort_insertion(T[] items)
        {
            int sortedRangeEndIndex = 1;
            Console.WriteLine("Сортировка вставками.");


            while (sortedRangeEndIndex < items.Length)
            {
                if (items[sortedRangeEndIndex].CompareTo(items[sortedRangeEndIndex - 1]) < 0)
                {
                    int insertIndex = FindInsertionIndex(items, items[sortedRangeEndIndex]);
                    Insert(items, insertIndex, sortedRangeEndIndex);
                }

                sortedRangeEndIndex++;
            }
        }

        public static int FindIndexOfSmallestFromIndex(T[] items, int sortedRangeEnd)
        {
            T currentSmallest = items[sortedRangeEnd];
            int currentSmallestIndex = sortedRangeEnd;

            for (int i = sortedRangeEnd + 1; i < items.Length; i++)
            {
                if (currentSmallest.CompareTo(items[i]) > 0)
                {
                    currentSmallest = items[i];
                    currentSmallestIndex = i;
                }
            }

            return currentSmallestIndex;
        }

        public static void sort_vibor(T[] items)
        {
            int sortedRangeEnd = 0;
            Console.WriteLine("Сортировка выбором.");

            while (sortedRangeEnd < items.Length)
            {
                int nextIndex = FindIndexOfSmallestFromIndex(items, sortedRangeEnd);
                Swap(items, sortedRangeEnd, nextIndex);

                sortedRangeEnd++;
            }
        }

        public static void sort_sliyanie(T[] items)
        {

            if (items.Length <= 1)
            {
                return;
            }
            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;
            T[] left = new T[leftSize];
            T[] right = new T[rightSize];
            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);
            sort_sliyanie(left);
            sort_sliyanie(right);
            Merge(items, left, right);
        }
        public static void Merge(T[] items, T[] left, T[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int remaining = left.Length + right.Length;
            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else
                {
                    items[targetIndex] = right[rightIndex++];
                }

                targetIndex++;
                remaining--;
            }
        }
    }
}
