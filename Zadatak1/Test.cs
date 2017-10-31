using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadatak1
{
	public class Test
	{
		public static void Main(String[] args)
		{
			Case1();
			Case2();
			Case3();
		}


		static void Case1()
		{
			var topStudents = new List<Student>()
			{
				new Student(" Ivan ", jmbag: " 001234567 "),
				new Student(" Luka ", jmbag: " 3274272 "),
				new Student("Ana", jmbag: " 9382832 ")
			};
			var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
			// false :(
			bool isIvanTopStudent = topStudents.Contains(ivan); //contains nevalja
			Console.WriteLine("Case1: " + isIvanTopStudent );
		}

		static void Case2()
		{
			var list = new List<Student>()
			{
				new Student(" Ivan ", jmbag: " 001234567 "),
				new Student(" Ivan ", jmbag: " 001234567 ")
			};
			// 2 :(
			var distinctStudentsCount = list.Distinct().Count(); // printa ih duplo makar je distinct
			Console.WriteLine("Case2: " + distinctStudentsCount);
		}

		static void Case3()
		{
			var topStudents = new List<Student>()
			{
				new Student(" Ivan ", jmbag: " 001234567 "),
				new Student(" Luka ", jmbag: " 3274272 "),
				new Student("Ana", jmbag: " 9382832 ")
			};
			var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
			// false :(
			// == operator is a different operation from . Equals ()
			// Maybe it isn ’t such a bad idea to override it as well
			bool isIvanTopStudent = topStudents.Any(s => s == ivan); //promijeniti == u equals
			Console.WriteLine("Case3: " + isIvanTopStudent);
		}
	}
}