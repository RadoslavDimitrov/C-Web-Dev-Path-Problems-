using System;

namespace Person
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("pesho", -2);
            Console.WriteLine(person);
            Child ch = new Child("goshko", 16);
            Console.WriteLine(ch);
        }
    }
}
