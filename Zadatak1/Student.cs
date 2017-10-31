namespace Zadatak1
{
	public class Student
	{
		public string Name { get; set; }
		public string Jmbag { get; set; }
		public Gender Gender { get; set; }
		public Student(string name, string jmbag)
		{
			Name = name;
			Jmbag = jmbag;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Student objAStudent)) return false;
			return Jmbag.Equals(objAStudent.Jmbag);
		}

		public override int GetHashCode()
		{
			return Jmbag.GetHashCode();
		}

		public static bool operator ==(Student std1, Student std2)
		{
			return std1.Jmbag.Equals(std2.Jmbag);
		}

		public static bool operator !=(Student std1, Student std2)
		{
			if (std1 == null) return true;
			return !(std1 == std2);
		}
	}
	public enum Gender
	{
		Male, Female
	}	
}
