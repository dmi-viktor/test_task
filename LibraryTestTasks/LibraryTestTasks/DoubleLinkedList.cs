using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LibraryTestTasks
{
    public class DoubleLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }
        public DoubleLinkedListNode<T> Prev { get; set; }

        public DoubleLinkedListNode(T value)
        {
            Value = value;
        }
    }
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        
        public DoubleLinkedListNode<T> First { get; set; }
        public DoubleLinkedListNode<T> Last { get; set; }
        public int Count { get; private set; }

        public DoubleLinkedList<T> Reverse(int start_index, int count)
        {
            DoubleLinkedList<T> temp = new DoubleLinkedList<T>();
            start_index = start_index < 0 ? 0 : start_index;
            if (start_index >= Count)
                return temp;
            int finish_index = start_index + count - 1;
            finish_index = finish_index > Count - 1 ? Count - 1 : finish_index;
            int index = 0;

            foreach (var node in this)
            {
                if (index >= start_index && index <= finish_index)
                {
                    temp.AddFirst(node);
                }
                index++;
            }
            return temp;
        }
        //insert new DoubleLinkedListNode with given value at the start of the list
        public DoubleLinkedList<T> AddFirst(T value)
        {
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(value);
            DoubleLinkedListNode<T> temp = First;
            node.Next = temp;
            First = node;
            if (Count > 0)
            {
                temp.Prev = node;
            }
            else
            {
                Last = First;
            }
            Count++;
            return this;
        }
        //insert new DoubleLinkedListNode with given value at the end of the list
        public DoubleLinkedList<T> AddLast(T value)
        {
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(value);
            if (Count > 0)
            {
                Last.Next = node;
                node.Prev = Last;
            }
            else
            {
                First = node;
            }
            Last = node;
            Count++;
            return this;
        }
        public void Clear()
        {
            Count = 0;
            First = null;
            Last = null;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoubleLinkedListNode<T> current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public IEnumerable<T> ReverseEnumerator()
        {
            DoubleLinkedListNode<T> current = Last;
            while (current != null)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }
    }
}
