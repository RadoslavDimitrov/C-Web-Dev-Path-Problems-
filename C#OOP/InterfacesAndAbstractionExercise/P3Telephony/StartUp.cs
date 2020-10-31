using System;

namespace P3Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumber = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < phoneNumber.Length; i++)
            {
                try
                {
                    string currNumber = phoneNumber[i];

                    if (currNumber.Length == 10)
                    {
                        ICallable currSmartPhone = new Smartphone(currNumber, "");
                        Console.WriteLine(currSmartPhone.Call());
                    }
                    else
                    {
                        ICallable stationaryPhone = new StationaryPhone(currNumber);
                        Console.WriteLine(stationaryPhone.Call());
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            for (int i = 0; i < sites.Length; i++)
            {
                try
                {
                    string currUrl = sites[i];
                    IWebSearchable SPhone = new Smartphone("", currUrl);
                    Console.WriteLine(SPhone.SearchWeb());
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);

                }
            }
            
        }
    }
}
