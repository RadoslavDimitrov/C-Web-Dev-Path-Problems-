using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P2.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> elements;
        public int Count { get; private set; }

        public MyStack()
        {
            this.elements = new List<T>();
            this.Count = 0;
        }
        public void Push(T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.elements.Add(elements[i]);
                this.Count++;
            }
        }

        public T Pop()
        {
            T currEle = this.elements[this.elements.Count - 1];
            this.elements.RemoveAt(this.elements.Count - 1);
            this.Count--;
            return currEle;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.elements.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
