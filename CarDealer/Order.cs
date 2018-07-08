using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer
{
    public class Order
    {
		private readonly int orderId;
		private string manufacturer;
		private string model;
		private bool airCon;
		private bool alloys;
		private static int lastId = 0;

		private Order(int orderId,string manufacturer,string model,bool airCon, bool alloys, LastId lastId)
		{
			if (orderId == 0)
			{
				this.orderId = lastId.getNextOrderId();
			}
			else
			{
				this.orderId = orderId;
			}
			this.manufacturer = manufacturer;
			this.model = model;
			this.airCon = airCon;
			this.alloys = alloys;
		}

				public static Order getInstance(int orderId, string manufacturer, string model, bool airCon, bool alloys, LastId lastId)
		{
			return new Order(orderId, manufacturer, model, airCon, alloys, lastId);
		}

		public string fulfillOrder(Dealer dealerToUse)
		{
			double cost = calculateCost(dealerToUse, model, airCon, alloys);
			string extras = string.Empty;
			extras = ListExtras();
			return "The order for a " + manufacturer + " " + model + " with " + extras + ", will cost £" + cost;
		}

		private double calculateCost(Dealer dealerToUse, string model, bool airCon, bool alloys)
		{
			return dealerToUse.getCost(model, airCon, alloys);
		}

		private string ListExtras()
		{
			if (airCon && alloys)
			{
				return "Air Con and Alloys";
			}

			if (airCon && !alloys)
			{
				return "Air Con";
			}

			if (!airCon && alloys)
			{
				return "Alloys";
			}

			return "No Extras";
		}

		public int OrderId {
			get { return orderId; }
		}

		public string Manufacturer
		{
			get { return manufacturer; }
			set { manufacturer = value; }
		}

		public string Model
		{
			get { return model; }
			set { model = value; }
		}

		public bool AirCon
		{
			get { return airCon; }
			set { airCon = value; }
		}

		public bool Alloys
		{
			get { return alloys; }
			set { alloys = value; }
		}
	}
}
