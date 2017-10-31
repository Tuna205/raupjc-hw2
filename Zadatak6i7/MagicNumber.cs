using System.Threading.Tasks;

namespace Zadatak6i7
{
    public class MagicNumber
    {
	    public static async Task<int> FactorialDigitSum(int n)
	    {
		    int faktorijel = await Factorial(n);
		    int rez = await DigitSum(faktorijel);

		    return rez;
	    }

	   

	    private static async Task<int> Factorial(int n)
	    {
		    int rez = 1;
		    for (int i = 2; i <= n; i++)
		    {
			    rez *= i;
		    }
		    return rez;
	    }

	    private static async Task<int> DigitSum(int faktorijel)
	    {
		    int rez = 0;
		    while (faktorijel > 0)
		    {
			    int temp = faktorijel % 10;
			    faktorijel /= 10;
			    rez += temp;
		    }

		    return rez;
	    }
	}
}
