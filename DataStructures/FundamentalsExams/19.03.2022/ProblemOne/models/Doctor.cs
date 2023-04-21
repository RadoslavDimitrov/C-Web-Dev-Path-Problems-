﻿using System.Collections.Generic;

namespace VaccTests
{
    public class Doctor
    {
        public Doctor(string name, int popularity)
        {
            this.Name = name;
            this.Popularity = popularity;
            this.patients = new List<Patient>();
        }

        public string Name { get; set; }
        public int Popularity { get; set; }

        private ICollection<Patient> patients { get; set; }
    }
}