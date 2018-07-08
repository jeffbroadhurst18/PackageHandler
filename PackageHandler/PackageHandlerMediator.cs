using System;

namespace PackageHandler
{
	public class PackageHandlerMediator
	{
		private static PackageHandlerMediator _instance = new PackageHandlerMediator();

		private PackageHandlerMediator()
		{

		}

		public static PackageHandlerMediator getInstance()
		{
			return _instance; //returns a static instance of object (singleton)
		}

		public bool markFragile()
		{
			return false;
		}

		public bool markDoNotLeave()
		{
			return false;
		}

		public bool markReturnReceiptRequested()
		{
			return false;
		}
	}
}