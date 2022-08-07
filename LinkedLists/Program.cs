using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedLists
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }

    public class MyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private int _count;
        private Node<T> _root;

        public int Lentgh => _count;

        public MyLinkedList()
        {
        }

        public void AddFront(T element)
        {
            if (_root != null)
            {
                Node<T> temp = new Node<T> { Value = element, Next = _root };
                _root = temp;
            }
            else
            {
                _root = new Node<T> { Value = element };
            }
            _count++;
        }

        public void AddBack(T element)
        {
            Node<T> newNode = new Node<T>();
            newNode.Value = element;
            newNode.Next = null;

            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                Node<T> temp = new Node<T>();

                temp = _root;

                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = newNode;
            }
            _count++;
        }

        public void AddByIndex(T element, int index)
        {
            Node<T> newNode = new Node<T>();
            newNode.Value = element;
            newNode.Next = null;

            if (index == 1)
            {
                newNode.Next = _root;
                _root = newNode;
            }
            else
            {

                Node<T> temp = new Node<T>();
                temp = _root;

                for (int i = 1; i < index - 1; i++)
                {
                    if (temp != null)
                    {
                        temp = temp.Next;
                    }
                }

                if (temp != null)
                {
                    newNode.Next = temp.Next;
                    temp.Next = newNode;
                }
            }
            _count++;
        }

        public void RemoveFront()
        {
            if (_root != null)
            {
                Node<T> temp = _root;
                _root = _root.Next;
                temp = null;
            }
            _count--;
        }

        public void RemoveBack()
        {
            if (_root.Next == null)
            {
                Node<T> temp = _root;
                temp = null;
            }
            else
            {
                Node<T> temp = new Node<T>();

                temp = _root;

                while (temp.Next.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = null;
            }
            _count--;
        }

        public void RemoveByIndex(int index)
        {
            if (index == 1 && _root != null)
            {
                Node<T> nodeToDelete = _root;
                _root = _root.Next;
                nodeToDelete = null;
            }
            else
            {
                Node<T> temp = new Node<T>();
                temp = _root;

                for (int i = 1; i < index - 1; i++)
                {
                    if (temp != null)
                    {
                        temp = temp.Next;
                    }
                }

                if (temp != null && temp.Next != null)
                {
                    Node<T> nodeToDelete = temp.Next;
                    temp.Next = temp.Next.Next;
                    nodeToDelete = null;
                }
            }
            _count--;
        }

        public void RemoveNValuesFront(int n)
        {
            Node<T> temp = new Node<T>();

            temp = _root;

            for (int i = 0; i < n; i++)
            {
                temp = temp.Next;
            }

            _root = temp;
            _count -= n;

            // or by cycle RemoveFront() n times
        }

        public void RemoveNValuesBack(int n)
        {
            int start = (_count - n);
            int localCount = 0;
            Node<T> temp = new Node<T>();
            temp = _root;

            while (localCount != start - 1)
            {
                temp = temp.Next;
                localCount++;
            }

            for (int i = 0; i < n; i++)
            {
                temp.Next = null;
            }

            _count -= n;

            // or by cycle RemoveBack() n times
        }

        public void RemoveNValuesByIndex(int n, int index)
        {
            for (int i = 0; i < n; i++)
            {
                RemoveByIndex(index);
            }
        }

        public int IndexOfElement(T element)
        {
            Node<T> temp = new Node<T>();
            temp = _root;
            int localCount = -1;
            for (int i = 0; i < _count - 1; i++)
            {
                temp = temp.Next;
                if (temp.Value.Equals(element))
                {
                    localCount = i;
                }
            }

            return localCount;
        }

        public void Reverse()
        {
            if (_root != null)
            {
                Node<T> previous = _root;
                Node<T> temp = _root;
                Node<T> current = _root.Next;

                previous.Next = null;

                while (current != null)
                {
                    temp = current.Next;
                    current.Next = previous;
                    previous = current;
                    current = temp;
                }

                _root = previous;
            }
        }

        public T Min()
        {
            Node<T> temp = new Node<T>();
            temp = _root;
            T min = temp.Value;
            for (int i = 0; i < _count - 1; i++)
            {
                temp = temp.Next;
                if (min.CompareTo(temp.Value) == 1)
                {
                    min = temp.Value;
                }
            }

            return min;
        }

        public T Max()
        {
            Node<T> temp = new Node<T>();
            temp = _root;
            T max = temp.Value;
            for (int i = 0; i < _count - 1; i++)
            {
                temp = temp.Next;
                if (max.CompareTo(temp.Value) == -1)
                {
                    max = temp.Value;
                }
            }

            return max;
        }

        public int MinIndex()
        {
            Node<T> temp = new Node<T>();
            temp = _root;
            T min = temp.Value;
            int minIndex = 0;
            for (int i = 0; i < _count - 1; i++)
            {
                temp = temp.Next;
                if (min.CompareTo(temp.Value) == 1)
                {
                    minIndex = i + 1;
                    min = temp.Value;
                }
            }

            return minIndex;
        }

        public int MaxIndex()
        {
            Node<T> temp = new Node<T>();
            temp = _root;
            T max = temp.Value;
            int maxIndex = 0;
            for (int i = 0; i < _count - 1; i++)
            {
                temp = temp.Next;
                if (max.CompareTo(temp.Value) == -1)
                {
                    maxIndex = i + 1;
                    max = temp.Value;
                }
            }

            return maxIndex;
        }

        public void Sort(bool ascending = true)
        {
            if (ascending == true)
            {
                Node<T> _current = _root;
                Node<T> _previous = _current;

                Node<T> _min = _current;
                Node<T> _minPrevious = _min;

                Node<T> _sortedListHead = null;
                Node<T> _sortedListTail = _sortedListHead;

                for (int i = 0; i < _count; i++)
                {
                    _current = _root;
                    _min = _current;
                    _minPrevious = _min;

                    while (_current != null)
                    {
                        if (_current.Value.CompareTo(_min.Value) == -1)
                        {
                            _min = _current;
                            _minPrevious = _previous;
                        }
                        _previous = _current;
                        _current = _current.Next;
                    }

                    if (_min == _root)
                    {
                        _root = _root.Next;
                    }
                    else if (_min.Next == null)
                    {
                        _minPrevious.Next = null;
                    }
                    else
                    {
                        _minPrevious.Next = _minPrevious.Next.Next;
                    }

                    if (_sortedListHead != null)
                    {
                        _sortedListTail.Next = _min;
                        _sortedListTail = _sortedListTail.Next;
                    }
                    else
                    {
                        _sortedListHead = _min;
                        _sortedListTail = _sortedListHead;
                    }
                }
                _root = _sortedListHead;
            }
            else
            {
                Node<T> _current = _root;
                Node<T> _previous = _current;

                Node<T> _max = _current;
                Node<T> _maxPrevious = _max;

                Node<T> _sortedListHead = null;
                Node<T> _sortedListTail = _sortedListHead;

                for (int i = 0; i < _count; i++)
                {
                    _current = _root;
                    _max = _current;
                    _maxPrevious = _max;

                    while (_current != null)
                    {
                        if (_current.Value.CompareTo(_max.Value) == 1)
                        {
                            _max = _current;
                            _maxPrevious = _previous;
                        }
                        _previous = _current;
                        _current = _current.Next;
                    }

                    if (_max == _root)
                    {
                        _root = _root.Next;
                    }
                    else if (_max.Next == null)
                    {
                        _maxPrevious.Next = null;
                    }
                    else
                    {
                        _maxPrevious.Next = _maxPrevious.Next.Next;
                    }

                    if (_sortedListHead != null)
                    {
                        _sortedListTail.Next = _max;
                        _sortedListTail = _sortedListTail.Next;
                    }
                    else
                    {
                        _sortedListHead = _max;
                        _sortedListTail = _sortedListHead;
                    }
                }
                _root = _sortedListHead;
            }
        }

        public void RemoveByValue(T value)
        {
            Node<T> temp = new Node<T>();
            temp = _root;
            int localCount = -1;

            for (int i = 0; i < _count - 1; i++)
            {
                temp = temp.Next;
                if (temp.Value.Equals(value))
                {
                    localCount = i;
                }
            }

            Node<T> temp1 = new Node<T>();
            temp1 = _root;

            for (int i = 0; i < localCount; i++)
            {
                if (temp1 != null)
                {
                    temp1 = temp1.Next;
                }
            }

            if (temp != null && temp1.Next != null)
            {
                Node<T> nodeToDelete = temp1.Next;
                temp1.Next = temp1.Next.Next;
                nodeToDelete = null;
            }
            _count--;
        }

        public void RemoveByValueAll(T value)
        {
            for (int i = 0; i < _count; i++)
            {
                RemoveByValue(value);
            }
        }

        public void AddFront(IEnumerable<T> itemss)
            {
            foreach (var item in itemss)
            {
                AddFront(item);

            }
        }

        public void AddBack(IEnumerable<T> itemss)
        {
            foreach (var item in itemss)
            {
                AddBack(item);
            }

        }

        public void AddByIndex(int index, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                AddByIndex(item, index);
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            Node<T> temp = _root;
            while (temp != null)
            {
                yield return temp.Value;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }

    public static class Program
    {
        static void Main(string[] args)
        {
            int[] itemss = new int[] { 1, 3, 5, 7, 9 };
            MyLinkedList<int> items = new MyLinkedList<int>();
            items.AddFront(10);
            items.AddFront(20);
            items.AddFront(30);
            items.AddFront(40);
            items.AddByIndex(1, itemss);
            items.AddFront(50);
            items.AddFront(60);
            foreach (var item in items)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine("");
            Console.WriteLine($"Lentgh of linked list : {items.Lentgh} ");
            Console.WriteLine($"Min element index : {items.MinIndex()}");
        }
    }
}
