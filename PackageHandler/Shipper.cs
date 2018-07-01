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

		public abstract double GetPackageCost(double weight); //abstract methods must be overridden
		public abstract double GetLetterCost(double weight);
		public abstract double GetOversizeSurcharge(double weight);
		//don't decide which price band to charge in the GetCost method.  Instead we work out the price band and call the rquired method on the shipper object.

	}

	//Open for extension but not modification
	//If you add a new shipper type you don't have to amend a method that might break now existing shippers work
	//you just add a new class and so the existing classes are kept untouched.
	public class AirEastShipper : Shipper
	{
		public override double GetLetterCost(double weight)
		{
			return weight * .39;
		}

		public override double GetOversizeSurcharge(double weight)
		{
			return 10;
		}

		public override double GetPackageCost(double weight)
		{
			return weight * .24;
		}
	}

	public class ChicagoSprintShipper : Shipper
	{
		public override double GetLetterCost(double weight)
		{
			return weight * .42;
		}

		public override double GetOversizeSurcharge(double weight)
		{
			return 0;
		}

		public override double GetPackageCost(double weight)
		{
			return weight * .20;
		}
	}

	public class PacificParcelShipper : Shipper
	{
		public override double GetLetterCost(double weight)
		{
			return weight * .51;
		}

		public override double GetOversizeSurcharge(double weight)
		{
			return weight * .02;
		}

		public override double GetPackageCost(double weight)
		{
			return weight * .19;
		}
	}
}
