using System;
using spam.Interfaces;

namespace spam.Classes
{
	abstract class Vehicle : IVehicle
	{
		public string Name { get; set; }

		protected Vehicle() { }
		protected Vehicle(string name)
		{
			Name = name;
		}

		public int CompareTo(IVehicle another)
		{
			return String.CompareOrdinal(Name, another.Name);
		}
		public override string ToString()
		{
			return $"\t 1) Name : {Name}\n";
		}
	}
}
