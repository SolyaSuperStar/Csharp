using spam.Interfaces;
using System;
using System.Collections;
using System.IO;

namespace spam.Classes
{
	class VehicleContainer : IEnumerable
	{
		private readonly IVehicle[] trans;
		public VehicleContainer(IVehicle[] trans)
		{
			this.trans = trans;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)(new VehicleEnum(trans));
		}

		public static VehicleContainer ReadFile(VehicleContainer cnt, string filePath)
		{
			var lines = File.ReadAllLines(filePath);
			IVehicle[] arr = new IVehicle[lines.Length];
			int index = 0;

			foreach (var line in lines)
			{
				string[] pieces = line.Split(' ');

				switch (pieces[0])
				{
					case "C":
						arr[index++] = new Car(pieces[1], Convert.ToUInt32(pieces[2]));
						break;
					case "T":
						arr[index++] = new Train(pieces[1], Convert.ToDouble(pieces[2]));
						break;
					default:
						throw new Exception("Wrong data!");
				}
			}

			return new VehicleContainer(arr);
		}
		public static void WriteFile(VehicleContainer cnt, string filePath)
		{
			File.WriteAllText(filePath, String.Join("\n", cnt));
		}
		public void Sort()
		{
			Array.Sort(trans);
		}
		public IVehicle Find(IVehicle vehicle)
		{
			return Array.Find(trans, x => x == vehicle);
		}
	}
}
