using System;
using System.Collections.Generic;
using System.Text;

namespace PackageHandler
{
    public class Shipment
    {
		private int myShipmentId;
		private string myToAddress;
		private string myFromAddress;
		private string myToZipCode;
		private string myFromZipCode;
		private double myWeight;

		private Shipment(int ShipmentId, string toAddress, string fromAddress, string toZipCode, string fromZipCode, double weight)
		{
			// private contstructor, run when the Shipment object is instantiated.
			if (ShipmentId == 0)
			{
				ShipmentId = getShipmentId();
			}
			this.myShipmentId = ShipmentId;
			this.myToAddress = toAddress;
			this.myFromAddress = fromAddress;
			this.myToZipCode = toZipCode;
			this.myFromZipCode = fromZipCode;
			this.myWeight = weight;
		}

		public static Shipment getInstance(int shipmentId, string toAddress, string fromAddress, string toZipCode, string fromZipCode, double weight)
		{
			return new Shipment(shipmentId, toAddress, fromAddress, toZipCode, fromZipCode, weight);
			//static method returns a new instance of Shipment
			//rather than instantiating and doing this in the Constructor a
		}

		virtual public int ShipmentId
		{
			get { return myShipmentId; }
		}

		virtual public string ToAddress
		{
			get { return myToAddress; }
			set { myToAddress = value; }
		}

		virtual public string FromZipCode
		{
			get { return myFromZipCode; }
			set { myFromZipCode = value; }
		}

		virtual public string ToZipCode
		{
			get { return myToZipCode; }
			set { myToZipCode = value; }
		}

		virtual public string FromAddress
		{
			get { return myFromAddress; }
			set { myFromAddress = value; } // set the value of the internal variable using value
		}

		private static int LastId = 0;

		private int getShipmentId()
		{
			LastId = LastId + 1; //remember you don't have to pass the variable into/out of the method as it is in the same class
			return LastId;
		}

		// protected = only available in this class and derived classes
		//virtual = can be overridden
		//the derived Shipper class can be passed to an instance of the Shipper class as it implements all of its properties.
		virtual protected double calculateCost(double weight,Shipper shipper)
		{
			return shipper.GetCost(weight);
		}

		virtual public string ship(Shipper shipper)
		{
			double cost = calculateCost(this.myWeight,shipper);
			string response;
			response = "Your shipment with the ID " + this.myShipmentId;
			response += "\nwill be picked up from " + this.myFromAddress + " " + this.myFromZipCode;
			response += "\nand shipped to " + this.myToAddress + " " + this.myToZipCode;
			response += "\nCost = " + cost;
			return response;
		}
	}
}
