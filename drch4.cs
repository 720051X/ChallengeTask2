using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


public class Rolls
{
public static List<int> storeRolls = new List<int>();
//public static List<string> logList = new List<string>();
//public static List<int> intList = new List<int>();

public static void listRolls() // prints each roll in the list
    {   
        Console.WriteLine("Rolls:");
        foreach(var roll in storeRolls)
        {
            Console.WriteLine(roll);
        }
      //   Console.WriteLine("Historic Rolls:");
      //  foreach(var roll2 in intList)
      //  {
      //      Console.WriteLine(roll2);
     //   }
    }

public static void avgRolls() // calculate and print average of rolls
    {
        double avg = Queryable.Average(storeRolls.AsQueryable());
        //double avg2 = Queryable.Average(intList.AsQueryable());
        Console.WriteLine("Average = " + avg);
        //Console.WriteLine("Historic Average = " + avg2);


    }

public static void sumRolls() // calculate and print total of rolls
    {
        var sum = storeRolls.Sum();
        Console.WriteLine("Sum = " + sum);
        //var sum2 = intList.Sum();
        //Console.WriteLine("Historic Sum = " + sum2);
    }

public static void readText()
{
List<string> logList = System.IO.File.ReadLines("rolls.txt").ToList();
var intList = logList.Select(s => Convert.ToInt32(s)).ToList();
}

}
public class Program
{
    
	public static void Main()
	{    
		string restart;
		do
		{
			Random rnd = new Random();
			int dieRoll = rnd.Next(1, 6);
			int counter = 1;


			Console.WriteLine("How many dice would you like to roll?");
			int numberDies = int.Parse(Console.ReadLine());
				if (numberDies < 1)
				{
					Console.WriteLine("Please enter a valid number");
				};
			while (counter <= numberDies)
			{
				dieRoll = rnd.Next(1, 6);
				Console.WriteLine(dieRoll);
                Rolls.storeRolls.Add(dieRoll);
                using (StreamWriter writer = new StreamWriter("rolls.txt", append: true))  
                {
                writer.WriteLine(dieRoll);
                }
            counter++;
			}



			Console.WriteLine("Would you like to roll again (Y/N)?");
			restart = Console.ReadLine().ToUpper();
			while ((restart != "Y") && (restart != "N"))
			{
				Console.WriteLine("Would you like to roll again (Y/N)?");
				restart = Console.ReadLine().ToUpper();
			}
		}
		while (restart == "Y");

        Rolls.listRolls();
        Rolls.avgRolls();
        Rolls.sumRolls();
        Console.WriteLine("Rolls appended to text file.");
        Rolls.readText();
}
}
