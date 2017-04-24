using System;

namespace spam.Interfaces
{
	interface IVehicle : IComparable<IVehicle>
	{
		string Name { get; set; }
	}
}
