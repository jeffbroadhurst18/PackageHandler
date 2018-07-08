using CarDealer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageHandler;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest2
	{
		[Ignore]
		[TestMethod]
		public void TestMethod1()
		{
			var toAddress = "22 Carr Road, Sheffield";
			var toZipCode = "12345";
			var fromAddress = "103 Brook Lance, Altrincham";
			var fromZipCode = "23451";
			var weight = 12.5;
			var shipment1 = Shipment.getInstance(0, toAddress, fromAddress, toZipCode, fromZipCode, weight, true, true, true);
			var response = shipment1.ship(Shipper.GetInstance(fromZipCode));
			Assert.IsNotNull(response);
		}

		[TestMethod]
		public void TestMethod2()
		{
			var manufacturer = "Honda";
			var model = "Civic";
			var airCon = true;
			var alloys = true;

			LastId lastId = LastId.getInstance();

			Order order = Order.getInstance(0, manufacturer, model, airCon, alloys, lastId);
			Dealer dealer = Dealer.getInstance(manufacturer);

			var response = order.fulfillOrder(dealer);

			Assert.IsNotNull(response);


			manufacturer = "Ford";
			model = "Focus";
			airCon = false;
			alloys = false;

			order = Order.getInstance(0, manufacturer, model, airCon, alloys,lastId);
			dealer = Dealer.getInstance(manufacturer);
			response = order.fulfillOrder(dealer);

			Assert.IsNotNull(response);
		}
	}
}
