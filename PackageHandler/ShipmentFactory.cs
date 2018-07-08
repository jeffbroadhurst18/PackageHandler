using System;
using System.Collections.Generic;
using System.Text;
using static PackageHandler.ShipmentDecorator;

namespace PackageHandler
{
    public class ShipmentFactory
    {
		private static ShipmentFactory _instance = new ShipmentFactory();
		public static readonly double MAX_WEIGHT_LETTER_OZ = 15;
		public static readonly double MAX_WEIGHT_PACKAGE_OZ = 160;

		private PackageHandlerMediator myMediator = PackageHandlerMediator.getInstance();

		private ShipmentFactory()
		{

		}

		public static ShipmentFactory getInstance()
		{
			return _instance;
		}

		public Shipment getShipment(int shipmentId, string toAddress, string fromAddress, string toZipCode, string fromZipCode, double weight, bool fragile, bool leave, bool receipt)
		{
			Shipment basePackage = getBasePackage(shipmentId, toAddress, fromAddress, toZipCode, fromZipCode, weight, fragile, leave, receipt);
			Shipment decoratedPackage = decoratePackage(basePackage);
			return decoratedPackage;
		}

		private Shipment getBasePackage(int shipmentId, string toAddress, string fromAddress, string toZipCode, string fromZipCode, double weight, bool fragile, bool leave, bool receipt)
		{
			if (weight > MAX_WEIGHT_PACKAGE_OZ)
			{
				return new Oversized(shipmentId, toAddress, fromAddress, toZipCode, fromZipCode, weight,fragile, leave, receipt);
			}
			else if (weight > MAX_WEIGHT_LETTER_OZ)
			{
				return new Package(shipmentId, toAddress, fromAddress, toZipCode, fromZipCode, weight,fragile, leave, receipt);
			}
			return new Letter(shipmentId, toAddress, fromAddress, toZipCode, fromZipCode, weight, fragile, leave, receipt);
		}

		private Shipment decoratePackage(Shipment basePackage)
		{
			Shipment returnPackage = basePackage;
			
			if (basePackage.Fragile) returnPackage = new FragileDecorator(returnPackage); //This creates new package object with the previous package as one of the attributes
			if (basePackage.Leave) returnPackage = new DoNotLeaveDecorator(returnPackage);//Creates a hierarchy of decorator classes with the previous decorator class as an attribute
			if (basePackage.Receipt) returnPackage = new ReturnReceiptDecorator(returnPackage);

			return returnPackage;
		}
	}
}
