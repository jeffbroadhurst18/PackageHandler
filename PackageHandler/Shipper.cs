using System;
using System.Collections.Generic;
using System.Text;

namespace PackageHandler
{
	//abstract class so you can never instantiate the class
	//however you can implement static methods on the class.
    public abstract class Shipper
    {
		//The class takes in the zipcode and returns a derived class.
		//The derived class can substitute for Shipper in all methods.
		public static Shipper GetInstance(string fromZipCode)
		{
			Shipper rval;
			switch(fromZipCode.Substring(0,1))
			{
				case ("1"):
				case ("2"):
				case ("3"):
					rval = new AirEastShipper();
					break;
				case ("4"):
				case ("5"):
				case ("6"):
					rval = new ChicagoSprintShipper();
					break;
				case ("7"):
				case ("8"):
				case ("9"):
					rval = new PacificParcelShipper();
					break;
				default:
					rval = new AirEastShipper();
					break;
			}
			return rval;
		}

		public abstract double GetCost(double weight);
		
    }

	public class AirEastShipper : Shipper
	{
		public override double GetCost(double weight)
		{
			return weight * 0.39;
		}
	}

	public class ChicagoSprintShipper : Shipper
	{
		public override double GetCost(double weight)
		{
			return weight * 0.42;
		}
	}

	public class PacificParcelShipper : Shipper
	{
		public override double GetCost(double weight)
		{
			return weight * 0.51;
		}
	}
}
