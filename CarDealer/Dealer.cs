using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer
{
    public abstract class Dealer
    {
		public static Dealer getInstance(string manufacturer)
		{
			switch(manufacturer)
			{
				case ("Honda"):
					return new Honda();
				case ("VW"):
					return new Volkswagen();
				case ("Ford"):
					return new Ford();
				default:
					return new Honda();
			}
		}

		public abstract double getCost(string model, bool airCon, bool alloys);
    }

	internal class Ford : Dealer
	{
		public override double getCost(string model, bool airCon, bool alloys)
		{
			double cost = 0;
			cost += model == "Focus" ? 15000 : 0;
			cost += airCon ? 1000 : 0;
			cost += alloys ? 500 : 0;
			return cost;
		}
	}

	internal class Volkswagen : Dealer
	{
		public override double getCost(string model, bool airCon, bool alloys)
		{
			double cost = 0;
			cost += model == "Golf" ? 18000 : 0;
			cost += airCon ? 1500 : 0;
			cost += alloys ? 800 : 0;
			return cost;
		}
	}

	internal class Honda : Dealer
	{
		public override double getCost(string model, bool airCon, bool alloys)
		{
			double cost = 0;
			cost += model == "Civic" ? 17000 : 0;
			cost += airCon ? 1200 : 0;
			cost += alloys ? 500 : 0;
			return cost;
		}
	}
}
