using System.Collections.Generic;

namespace spam.Classes
{
	sealed class Train : Vehicle, IComparer<Train>
	{
		public double Price { get; set; }

		public Train() : base() { }
		public Train(string name, double price)
			: base(name)
		{
			Price = price;
		}

		public int Compare(Train a, Train b)
		{
			if (a.Price.Equals(b.Price) && a.CompareTo(b) == 0)
				return 0;

			if (a.Price <= b.Price && a.CompareTo(b) < 0)
				return -1;

			return 1;
		}

		public override string ToString()
		{
			return " * Train\n" + base.ToString() + $"\t 2) Price : {Price}\n";
		}
	}
}
