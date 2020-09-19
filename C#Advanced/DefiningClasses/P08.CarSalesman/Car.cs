using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CarSalesman
{
    public class Car
    {
        //•	Model
        //•	Engine
        //•	Weight  -- optional
        //•	Color -- optional

        private string model;

        private Engine engine;

        private int weight;

        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.weight = int.MinValue;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight) :this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }


        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        //        {CarModel}:
        //          {EngineModel}:
        //    Power: {EnginePower}
        //    Displacement: {EngineDisplacement} or "n/a"
        //    Efficiency: {EngineEfficiency} or "n/a"
        //  Weight: {CarWeight} or "n/a"
        //  Color: {CarColor} or "n/a"
        public override string ToString()
        {
            
            if(this.Engine.Displacement == int.MinValue && this.Weight == int.MinValue) //no displacement and no carWeight
            {
                return $"{this.Model}:\n" + 
                    $"\t{this.Engine.Model}:\n" +
                     $"\t\tPower: {this.Engine.Power}\n" +
                     $"\t\tDisplacement: n/a\n" +
                     $"\t\tEfficiency: {this.Engine.Efficiency}\n" +
                    $"\tWeight: n/a\n" +
                    $"\tColor: {this.Color}";
            }
            else if(this.Engine.Displacement == int.MinValue)
            {
                return $"{this.Model}:\n" +
                    $"\t{this.Engine.Model}:\n" +
                     $"\t\tPower: {this.Engine.Power}\n" +
                     $"\t\tDisplacement: n/a\n" +
                     $"\t\tEfficiency: {this.Engine.Efficiency}\n" +
                    $"\tWeight: {this.Weight}\n" +
                    $"\tColor: {this.Color}";
            }
            else if(this.Weight == int.MinValue)
            {
                return $"{this.Model}:\n" +
                    $"\t{this.Engine.Model}:\n" +
                     $"\t\tPower: {this.Engine.Power}\n" +
                     $"\t\tDisplacement: {this.Engine.Displacement}\n" +
                     $"\t\tEfficiency: {this.Engine.Efficiency}\n" +
                    $"\tWeight: n/a\n" +
                    $"\tColor: {this.Color}";
            }
            else
            {
                return $"{this.Model}:\n" +
                    $"\t{this.Engine.Model}:\n" +
                     $"\t\tPower: {this.Engine.Power}\n" +
                     $"\t\tDisplacement: {this.Engine.Displacement}\n" +
                     $"\t\tEfficiency: {this.Engine.Efficiency}\n" +
                    $"\tWeight: {this.Weight}\n" +
                    $"\tColor: {this.Color}";
            }


            //return $"{this.Model}:" +
            //        $"{this.Engine.Model}:" +
            //         $"Power: {this.Engine.Power}" +
            //         $"Displacement: {this.Engine.Displacement}" +
            //         $"Efficiency: {this.Engine.Efficiency}" +
            //        $"Weight: {this.Weight}" +
            //        $"Color: {this.Color}";

        }
    }
}
