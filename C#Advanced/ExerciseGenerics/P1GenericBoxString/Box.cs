using System;
using System.Collections.Generic;
using System.Text;

namespace P1GenericBoxОfString
{
    class Box<T>
    {
        private T data;

        public Box(T data)
        {
            this.data = data;
        }

        public override string ToString()
        {
            return $"{typeof(T).FullName}: {this.data}";
            //return "{class full name: value}"
        }
    }
}
