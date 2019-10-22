using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLavoratori2
{
    public class MyListLavoratori<T> : IEnumerable<T>
    {
        private class Node 
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data) 
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;
        public MyListLavoratori()
        {
            head = null;
        }

        public void AddHead(T t)
        {
            Node n = new Node(t)
            {
                Next = head
            };
            head = n;
        }

        public T GetHead()
        {
            return head.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null) 
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
