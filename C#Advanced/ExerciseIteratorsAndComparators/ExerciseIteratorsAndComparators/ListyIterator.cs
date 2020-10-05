using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExerciseIteratorsAndComparators
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> elements;
        private int index;

        public ListyIterator()
        {
            this.elements = new List<T>();
            this.index = 0;
        }

        public ListyIterator(IEnumerable<T> elements)
        {
            this.elements = new List<T>(elements);
        }
        //public void Create(List<T> elements)
        //{

        //}

        public bool Move()
        {
            this.index++;
            if( this.index < this.elements.Count)
            {
                return true;
            }
            else
            {
                index--;
                return false;
            }
        }

        public void Print()
        {
            //if (this.index < this.elements.Count)
            //{
            //    Console.WriteLine(this.elements[this.index]);
            //}
            //else
            //{

            //    throw new ArgumentException("Invalid Operation!");
            //}

            try
            {

                Console.WriteLine(this.elements[this.index]);

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Invalid Operation!");
            }

        }

        public bool HasNext()
        {
            if (this.index + 1 < this.elements.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.elements)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
