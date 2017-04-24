namespace spam.Classes
{
	sealed class Car : Vehicle
	{
		public uint Speed { get; set; }

		public Car() : base() { }
		public Car(string name, uint speed) : base(name)
		{
			Speed = speed;
		}

		public override string ToString()
		{
			return " * Car\n" + base.ToString() + $"\t 2) Speed : {Speed}\n";
		}
	}
}
