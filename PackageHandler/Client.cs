using System;

namespace PackageHandler
{
    class Client
    {
		private int ShipmentId;
		private string toAddress;
		private string fromAddress;
		private string toZipCode;
		private string fromZipCode;
		private Shipment myShipment;
		private double weight;

        static void Main(string[] args)
        {
			Client.getInstance().executeStatement();
        }

		private Client ()
		{

		}

		public static Client getInstance() { return new Client(); }

		public void executeStatement()
		{
			//getShipmentDetails();
			myShipment = Shipment.getInstance(ShipmentId, toAddress, fromAddress, toZipCode, fromZipCode, weight);
			//getInstance is a static method so you don't have to instantiate class.
			//to access statis method you don't have to instantiate class
		}

		//private void getShipmentDetails()
		//{
		//	ShipmentId = 17263; //declared in class so accessible in the method
		//	toAddress = "1313 Mockingbird Lane, Tulsa, OK";
		//	toZipCode = "67721";
		//	fromAddress = "12292 4th Ave SE, Bellevue, WA";
		//	fromZipCode = "92021";
		//	weight = 10.00;

		//}
    }
}
