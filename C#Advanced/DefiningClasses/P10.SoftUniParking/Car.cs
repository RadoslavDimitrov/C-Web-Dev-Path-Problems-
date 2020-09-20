using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        
        private string make;

        private string model;

        private int horsePower;

        private string registrationNumber;


        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public override string ToString()
        {

            return $"Make: {this.Make}" + Environment.NewLine +
                    $"Model: {this.Model}" +Environment.NewLine +
                    $"HorsePower: {this.HorsePower}" + Environment.NewLine +
                    $"RegistrationNumber: {this.RegistrationNumber}";



        }
    }
}
