using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoirthmsComplexity
{
    public class LinkedListv2<T> : ICollection<T>
    {
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;



        public void ProcessItems()
        {
            foreach (T i in this)
            {
                Console.Write(i + " ");
            }
        }

        public int NextValue()
        {
            string s = Console.ReadLine();
            int i = Convert.ToInt32(s);
            return i;
        }

        public LinkedListNode<T> Head
        {
            get
            {
                return _head;
            }
        }

        public LinkedListNode<T> Tail
        {
            get
            {
                return _tail;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                // До:    Head -&gt; 3  5
                // После: Head -------&gt; 5

                // Head -&gt; 3 -&gt; null
                // Head ------&gt; null
                _head = _head.Next;

                Count--;

                if (Count == 0)
                {
                    _tail = null;
                }
                else
                {
                    // 5.Previous было 3; теперь null.
                    _head.Previous = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    // До:    Head --&gt; 3 --&gt; 5 --&gt; 7
                    //        Tail = 7
                    // После: Head --&gt; 3 --&gt; 5 --&gt; null
                    //        Tail = 5
                    // Обнуляем 5.Next
                    _tail.Previous.Next = null;
                    _tail = _tail.Previous;
                }

                Count--;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(item);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }

            Count++;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = _head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = _head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }




        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = _head;

            // 1: Пустой список: ничего не делать.
            // 2: Один элемент: установить Previous = null.
            // 3: Несколько элементов:
            //    a: Удаляемый элемент первый.
            //    b: Удаляемый элемент в середине или конце.

            while (current != null)
            {
                // Head -&gt; 3 -&gt; 5 -&gt; 7 -&gt; null
                // Head -&gt; 3 ------&gt; 7 -&gt; null
                if (current.Value.Equals(item))
                {
                    // Узел в середине или в конце.
                    if (previous != null)
                    {
                        // Случай 3b.
                        previous.Next = current.Next;

                        // Если в конце, то меняем _tail.
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                        else
                        {
                            // До:    Head -&gt; 3  5  7 -&gt; null
                            // После: Head -&gt; 3  7 -&gt; null

                            // previous = 3
                            // current = 5
                            // current.Next = 7
                            // Значит... 7.Previous = 3
                            current.Next.Previous = previous;
                        }

                        Count--;
                    }
                    else
                    {
                        // Случай 2 или 3a.
                        RemoveFirst();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public void AddFirst(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);

            // Сохраняем ссылку на первый элемент.
            LinkedListNode<T> temp = _head;

            // _head указывает на новый узел.
            _head = node;

            // Вставляем список позади первого элемента.
            _head.Next = temp;

            if (Count == 0)
            {
                // Если список был пуст, то head and tail должны
                // указывать на новой узел.
                _tail = _head;
            }
            else
            {
                // До:    head -------&gt; 5  7 -&gt; null
                // После: head  -&gt; 3  5  7 -&gt; null
                temp.Previous = _head;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);

            if (Count == 0)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;

                // До:    Head -&gt; 3  5 -&gt; null
                // После:Head -&gt; 3  5  7 -&gt; null
                // 7.Previous = 5
                node.Previous = _tail;
            }

            _tail = node;
            Count++;
        }

    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    public class LinkedListNode<T>
    {
        ///
        /// Конструктор нового узла со значением Value.
        ///
        public LinkedListNode(T value)
        {
            Value = value;
        }

        ///
        /// Поле Value.
        ///
        public T Value { get; internal set; }

        ///
        /// Ссылка на следующий узел списка (если узел последний, то null).
        ///
        public LinkedListNode<T> Next { get; internal set; }
        public LinkedListNode<T> Previous { get; internal set; }


    }


}
