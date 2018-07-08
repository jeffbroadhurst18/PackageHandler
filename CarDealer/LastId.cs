using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer
{
    public class LastId
    {
		public static int lastId;

		private LastId()
		{

		}


		public static LastId getInstance()
		{
			return new LastId();
		}

		public int getNextOrderId()
		{
			lastId++;
			return lastId;
		}
	}
}
