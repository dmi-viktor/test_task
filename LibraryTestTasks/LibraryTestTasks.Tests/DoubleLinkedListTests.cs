using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTestTasks.Tests
{
    [TestClass]
    public class DoubleLinkedListTests
    {
        [TestMethod]
        public void Reverse_expected_01234_actual_43210_reverse_returned_true()
        {
            DoubleLinkedList<int> expected = new DoubleLinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                expected.AddLast(i);
            }

            int start_index = 0;
            int count = 5;

            DoubleLinkedList<int> actual = new DoubleLinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                actual.AddFirst(i);
            }
            actual = actual.Reverse(start_index, count);

            Assert.AreEqual(expected.Count, actual.Count);

            DoubleLinkedListNode<int> source_node = expected.First;
            DoubleLinkedListNode<int> reverse_node = actual.First;

            while (source_node != null && reverse_node != null)
            {
                Assert.AreEqual(reverse_node.Value, source_node.Value);
                source_node = source_node.Next;
                reverse_node = reverse_node.Next;
            } 
        }

        [TestMethod]
        public void AddFirst_returned_true()
        {
            int expected = 5;

            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(5);
            int actual = list.First.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddLast_returned_true()
        {
            int expected = 5;

            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.AddLast(1);
            list.AddLast(5);
            int actual = list.Last.Value;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetEnumerator_returned_true()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                list.AddLast(i);
            }

            DoubleLinkedListNode<int> current = list.First;
            int count = list.Count;
            int index = 0;
            foreach (var node in list)
            {
                Assert.AreEqual(current.Value, node);
                current = current.Next;
                index++;
            }
            Assert.AreEqual(count, index);
        }
        [TestMethod]
        public void ReverseEnumerator_returned_true()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                list.AddLast(i);
            }

            DoubleLinkedListNode<int> current = list.Last;
            int count = list.Count;
            int index = 0;
            foreach (var node in list.ReverseEnumerator())
            {
                Assert.AreEqual(current.Value, node);
                current = current.Prev;
                index++;
            }
            Assert.AreEqual(count, index);
        }
    }
}
