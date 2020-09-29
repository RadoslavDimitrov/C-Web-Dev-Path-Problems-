using P1GenericBoxОfString;
using System;
using System.Collections.Generic;
using System.Text;

namespace P1GenericBoxString
{
    public static class Swap<T> where T : IComparable<T>
    {
        public static List<Box<T>> SwapMe(List<Box<T>> myList, int first, int second)
        {
            var tempBox = myList[first];
            myList[first] = myList[second];
            myList[second] = tempBox;

            return myList;
        }

        //a.compareTo(b)
        //1 - a > b
        //0 - a = b
        //-1 - a < b

        
    }
}
