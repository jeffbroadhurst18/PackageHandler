using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageHandler;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
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
			var toAddress = "22 Carr Road, Sheffield";
			var toZipCode = "12345";
			var fromAddress = "103 Brook Lance, Altrincham";
			var fromZipCode = "23451";
			var weight = 12.5;

			//The Shipper GetInstance method returns the appropriate class using ZipCode
			//Can be extended to include further sub classes
			//Shipper shipper1 = Shipper.GetInstance(fromZipCode);
			//Assert.AreEqual(12.5 * .39, shipper1.GetLetterCost(12.5));

			var shipment = Shipment.getInstance(0, toAddress, fromAddress, "99999", "90125", 999, true,true,true);
			var shipper = Shipper.GetInstance("90125");
			var response = shipment.ship(shipper);
			Assert.IsNotNull(response);

		}
	}
}
