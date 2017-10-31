using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak2;

namespace Zadatak3
{
	[TestClass]
	public class TodoItemTests
	{
		[TestMethod]
		public void MarkAsCompletedTest()
		{
			TodoItem item = new TodoItem("test");
			//item.DateCompleted = DateTime.UtcNow;
			Assert.IsTrue(item.MarkAsCompleted());
			Assert.IsFalse(item.MarkAsCompleted());
		}

		[TestMethod]
		public void EqualsTest()
		{
			TodoItem item1 = new TodoItem("test");
			TodoItem item2 = new TodoItem("test");

			Assert.IsFalse(item1.Equals(item2));
			Assert.AreNotEqual(new TodoItem("test1"),new TodoItem("test1"));
		}
	}
}
