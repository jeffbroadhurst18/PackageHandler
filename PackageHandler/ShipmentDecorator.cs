using System;
using System.Collections.Generic;
using System.Text;

namespace PackageHandler
{
	public abstract class ShipmentDecorator : Shipment
	{
		private Shipment nextShipment;//This is an additional property that is added to the Decorator version of the class.
									  //Adds a shipment instance as one of the properties of the class

		public ShipmentDecorator(Shipment nextShipment)
		{
			this.nextShipment = nextShipment;
		}

		public override string ship(Shipper shipper)
		{
			return nextShipment.ship(shipper);
		}

		protected override double calculateCost(double weight, Shipper shipper)
		{
			return 0;
		}

		public class FragileDecorator : ShipmentDecorator
		{
			public FragileDecorator(Shipment nextShipment) : base(nextShipment)
			{
				
			}

			public override string ship(Shipper shipper)
			{
				string rval = base.ship(shipper);
				return rval + "**MARK FRAGILE**";
			}
		}

		public class DoNotLeaveDecorator : ShipmentDecorator
		{
			public DoNotLeaveDecorator(Shipment nextShipment) : base(nextShipment)
			{

			}

			public override string ship(Shipper shipper)
			{
				string rval = base.ship(shipper);
				return rval + "**MARK DO NOT LEAVE IF ADDRESS NOT AT HOME**";
			}
		}

		public class ReturnReceiptDecorator : ShipmentDecorator
		{
			public ReturnReceiptDecorator(Shipment nextShipment) : base(nextShipment)
			{

			}

			public override string ship(Shipper shipper)
			{
				string rval = base.ship(shipper);
				return rval + "**MARK RETURN RECEIPT REQUESTED**";
			}
		}
	}
}
