using System;
using System.Linq;
using Zadatak1;

namespace Zadatak4
{
    public class HomeworkLinqQueries
    {
		public static string[] Linq1(int[] intArray)
	    {

		    string[] rez = intArray.GroupBy(i => i)
			    .Select(s => $"Broj {s.Key} ponavlja se {s.Count()} puta")
			    .OrderBy(i => i)
			    .ToArray();

		    return rez;
	    }
	    public static University[] Linq2_1(University[] universityArray)
	    {
		    University[] rez = universityArray.Where(u => u.Students.All(s => s.Gender == Gender.Male)).ToArray();

		    return rez;
	    }
	    public static University[] Linq2_2(University[] universityArray)
	    {
		    double prosBroj = universityArray.Average(s => s.Students.Length);

		    University[] rez = universityArray.Where(u => u.Students.Length < prosBroj).ToArray();

		    return rez;

	    }
	    public static Student[] Linq2_3(University[] universityArray)
	    {
		    Student[] studenti = universityArray.SelectMany(u => u.Students)
												.Distinct()
												.ToArray();
		    return studenti;
	    }

	    public static Student[] Linq2_4(University[] universityArray)
	    {

		    Student[] studenti = universityArray
			    .Select(u => u.Students)
			    .Where(u => u.All(s => s.Gender == Gender.Male))
			    .Union(universityArray
				    .Select(u => u.Students)
				    .Where(u => u.All(s => s.Gender == Gender.Female)))
			    .SelectMany(s => s).Distinct()
			    .ToArray();

		    return studenti;

	    }
	    public static Student[] Linq2_5(University[] universityArray)
	    {
		    Student[] studenti = universityArray.SelectMany(u => u.Students)
												.GroupBy(s => s).Where(s => s.Count() > 1)
												.Select(s => s.Key).ToArray();


		    return studenti;
	    }



	}



	public class University
	{
		public string Name { get; set; }
		public Student[] Students { get; set; }
	}

	

}
