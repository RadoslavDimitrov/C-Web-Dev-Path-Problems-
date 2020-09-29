using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P1GenericBoxОfString
{
    public class Box<T> where T : IComparable<T>

    {
        private T data;

        public Box(T data)
        {
            this.data = data;
        }
        public int CompareTo([AllowNull] Box<T> other)
        {
            return this.data.CompareTo(other.data);
        }

        public bool IsLower(Box<T> other)
        {
            if(this.data.CompareTo(other.data) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{typeof(T).FullName}: {this.data}";
            //return "{class full name: value}"
        }

        //public  List<Box<T>> Swap(List<Box<T>> myList, int first, int second)
        //{
        //    var tempBox = myList[first];
        //    myList[first] = myList[second];
        //    myList[second] = tempBox;

        //    return myList;
        //}
    }
}
