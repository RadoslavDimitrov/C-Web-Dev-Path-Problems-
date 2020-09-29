using System;
using System.Collections.Generic;
using System.Text;

namespace P7.Tuple
{
    public class MyTuple<T, V>
    {
        private T item1;

        private V item2;

        public V Item2
        {
            get { return item2; }
            set { item2 = value; }
        }

        public T Item1
        {
            get { return item1; }
            set { item1 = value; }
        }

       

        public MyTuple(T item1, V item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}
