using System;
using System.Linq;
using spam.Classes;
using spam.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace spam
{
	static class Test
	{
		static void Main()
		{
			List<IVehicle> vehicles = new List<IVehicle>();

			Init(vehicles, "data.txt");

			string command;
			while (true)
			{
				Choose();

				command = Console.ReadLine();

				switch (command)
				{
					case "1":
						PrintList(vehicles);
						break;
					case "2":
						vehicles.Sort();
						break;
					case "3":
						CountVehicles(vehicles);
						break;
					case "4":
						SortedTrains(vehicles);
						break;
					case "5":
						Console.Clear();
						break;
					case "0":
						return;
				}

				while (true)
				{
					Console.Write("Continue?[y/n]: ");
					var continue_ = Console.ReadLine();

					if (continue_ == "y")
					{
						break;
					}
					else if (continue_ == "n")
					{
						return;
					}
				}
			}
		}

		static void Choose()
		{
			Console.WriteLine("* Choose your option:");
			Console.Write("\n\t 1 - Show all list" +
						  "\n\t 2 - Sort all list" +
						  "\n\t 3 - Count the transport" +
						  "\n\t 4 - Sort all trains" +
						  "\n\t 5 - Clear console" +
						  "\n\t 0 - Exit\n* ");
		}

		static void Init(List<IVehicle> vehicles, string filePath)
		{
			foreach (var line in File.ReadAllLines(filePath))
			{
				string[] pieces = line.Split(' ');

				switch (pieces[0])
				{
					case "C":
						vehicles.Add(new Car(pieces[1], Convert.ToUInt32(pieces[2])));
						break;
					case "T":
						vehicles.Add(new Train(pieces[1], Convert.ToDouble(pieces[2])));
						break;
					default:
						throw new Exception("Wrong data!");
				}
			}
		}

		static void PrintList<T>(List<T> items)
		{
			foreach (var item in items)
			{
				Console.WriteLine(item);
			}
		}

		static int Count(List<IVehicle> vehicles, Type type)
		{
			return vehicles.Count(x => x.GetType() == type);
		}
		static void CountVehicles(List<IVehicle> vehicles)
		{
			int amount = Count(vehicles, typeof(Car));
			if (amount > 0)
			{
				Console.WriteLine($"* The number of the cars in the list : {amount}");
			}
			else
			{
				Console.WriteLine("* There are no cars in the list");
			}

			amount = Count(vehicles, typeof(Train));
			if (amount > 0)
			{
				Console.WriteLine($"* The number of the trains in the list : {amount}");
			}
			else
			{
				Console.WriteLine("* There are no train in the list");
			}
		}

		static void SortedTrains(List<IVehicle> vehicles)
		{
			Console.WriteLine("Sorted by both price and name:");
			foreach (var train in 
				vehicles
				.OfType<Train>()
				.OrderBy(x => x.Price)
				.ThenBy(x => x.Name))
			{
				Console.WriteLine(train);
			}
		}
	}
}