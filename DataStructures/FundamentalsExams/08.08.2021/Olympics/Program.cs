using System;
using System.Collections.Generic;
using System.Data.Common;

public class Program
{
    public static void Main(string[] args)
    {
        var olympics = new Olympics();
        var competitor = new Competitor(5, "Ani");

        //Act

        olympics.AddCompetition(1, "SoftUniada", 500);

        olympics.AddCompetitor(5, "Ani");
        olympics.Compete(5, 1);

        Console.WriteLine(olympics.Contains(1, competitor));

        //var list = new List<Competitor>();

        //var comp = new Competitor(2, "Gosho");
        //list.Add(comp);
        //Console.WriteLine(list.Contains(comp));
    }
}
