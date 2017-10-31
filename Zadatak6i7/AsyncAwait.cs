using System;
using System.Threading.Tasks;

namespace Zadatak6i7
{
	public class AsyncAwait
	{
		private static async Task LetsSayUserClickedAButtonOnGuiMethod()
		{
			var result = await GetTheMagicNumber();
			Console.WriteLine(result);
		}
		private static async Task<int> GetTheMagicNumber()
		{
			return await IKnowIGuyWhoKnowsAGuy();
		}
		private static async Task<int> IKnowIGuyWhoKnowsAGuy()
		{
			int rez1 = await IKnowWhoKnowsThis(10);
			int rez2 = await IKnowWhoKnowsThis(5);
			return rez1 + rez2;
		}
		private static async Task<int> IKnowWhoKnowsThis(int n)
		{
			int rez = await MagicNumber.FactorialDigitSum(n);
			return rez;
		}
		// Ignore this part .
		public static void Main(string[] args)
		{
			// Main method is the only method that
			// can ’t be marked with async .
			// What we are doing here is just a way for us to simulate
			// async - friendly environment you usually have with
			// other . NET application types ( like web apps , win apps etc .)
			// Ignore main method , you can just focus on
			// LetsSayUserClickedAButtonOnGuiMethod() as a
			// first method in the call hierarchy .
			var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
			Console.Read();
		}
	}
}