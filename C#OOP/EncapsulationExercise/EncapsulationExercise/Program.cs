using System;
using System.Xml;

namespace EncapsulationExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);

            double boxSA = box.SurfaceArea();
            double boxLSA = box.LateralSurfaceArea();
            double boxVolume = box.Volume();

            if(boxSA > 0 && boxLSA > 0 && boxVolume > 0)
            {
                Console.WriteLine($"Surface Area - {boxSA:F2}");
                Console.WriteLine($"Lateral Surface Area - {boxLSA:F2}");
                Console.WriteLine($"Volume - {boxVolume:F2}");

            }

        }
    }
}
