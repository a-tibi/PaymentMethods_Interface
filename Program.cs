using System;

namespace PaymentMethods_Interface
{
	class Program
	{
		static void Main(string[] args)
		{
			Cashier cashier1 = new Cashier(new Cash());
			cashier1.Checkout(99999.99m);

			Cashier cashier2 = new Cashier(new Debit());
			cashier2.Checkout(99999.99m);

			Cashier cashier3 = new Cashier(new MasterCard());
			cashier3.Checkout(99999.99m);

			Cashier cashier4 = new Cashier(new VisaCard());
			cashier4.Checkout(99999.99m);

			Console.ReadKey();
		}
	}

	interface IPayment
	{
		void Pay(decimal amount);	
	}

	class Cashier
	{
		private IPayment _payment;

		public Cashier(IPayment payment)
		{
			_payment = payment;
		}

		public void Checkout(decimal amount)
		{
			_payment.Pay(amount);
		}
	}

	class Cash: IPayment
	{
		public void Pay(decimal amount)
		{
			Console.WriteLine($"Cash Payment: ${Math.Round(amount,2):N0}");
		}
	}

	class Debit: IPayment
	{
		public void Pay(decimal amount)
		{
			Console.WriteLine($"Debit Payment: ${Math.Round(amount, 2):N0}");
		}
	}

	class MasterCard: IPayment
	{
		public void Pay(decimal amount)
		{
			Console.WriteLine($"MasterCard Payment: ${Math.Round(amount, 2):N0}");
		}
	}

	class VisaCard: IPayment
	{
		public void Pay(decimal amount)
		{
			Console.WriteLine($"VisaCard Payment: ${Math.Round(amount, 2):N0}");
		}
	}
}
