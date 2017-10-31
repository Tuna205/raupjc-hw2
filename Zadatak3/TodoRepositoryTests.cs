using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak2;

namespace Zadatak3
{
	[TestClass]
	public class TodoRepositoryTests
	{
		[TestMethod]
		public void AddTest()
		{
			TodoRepository repo = new TodoRepository();
			for (int i = 0; i < 100; i++)
			{
				repo.Add(new TodoItem($"test {i}"));
			}
			var test = new TodoItem("test101");
			Assert.AreEqual(test, repo.Add(test));
		}

		[TestMethod]
		[ExpectedException(typeof(DuplicateTodoItemException))]
		public void AddExceptionTest()
		{
			TodoRepository repo = new TodoRepository();
			var test = new TodoItem("test101");
			repo.Add(test);
			repo.Add(test);
		}

		[TestMethod]
		public void GetTest()
		{
			TodoRepository repo = new TodoRepository();
			var test = new TodoItem("test1");
			repo.Add(test);
			Assert.AreEqual(test, repo.Get(test.Id));

			repo = new TodoRepository();
			Assert.IsNull(repo.Get(test.Id));

			repo.Add(test);
			var test2 = new TodoItem("test2");
			Assert.IsNull(repo.Get(test2.Id));
		}


		[TestMethod]
		public void RemoveTest()
		{
			TodoRepository repo = new TodoRepository();
			var test = new TodoItem("test1");
			var test2 = new TodoItem("test2");
			repo.Add(test);
			Assert.IsFalse(repo.Remove(test2.Id));
			Assert.IsTrue(repo.Remove(test.Id));
			Assert.IsFalse(repo.Remove(test.Id));	
		}

		[TestMethod]
		public void UpdateTest()
		{
			TodoRepository repo = new TodoRepository();
			
			var test = new TodoItem("test101");
			Assert.AreEqual(test, repo.Add(test));
		}


		[TestMethod]
		public void MarkAsCompletedTest()
		{
			TodoRepository repo = new TodoRepository();

			var test = new TodoItem("test101");
			repo.Add(test);
		
			Assert.IsTrue(repo.MarkAsCompleted(test.Id));
			Assert.IsFalse(repo.MarkAsCompleted(test.Id));
		}

		[TestMethod]
		public void GetAllTest()
		{
			TodoRepository repo = new TodoRepository();

			var test1 = new TodoItem("test1");
			var test2 = new TodoItem("test2");
			var test3 = new TodoItem("test3");
			repo.Add(test1);
			repo.Add(test2);
			repo.Add(test3);

			//repo.MarkAsCompleted(test.Id);
			//repo.MarkAsCompleted(test3.Id);
			// test2 nije completed
			List<TodoItem> lista = repo.GetAll();

			Assert.AreEqual(lista[0], test1);
			Assert.AreEqual(lista[1], test2);
			Assert.AreEqual(lista[2], test3);

		}


		[TestMethod]
		public void GetActiveTest()
		{
			TodoRepository repo = new TodoRepository();

			var test1 = new TodoItem("test1");
			var test2 = new TodoItem("test2");
			var test3 = new TodoItem("test3");
			repo.Add(test1);
			repo.Add(test2);
			repo.Add(test3);

			repo.MarkAsCompleted(test1.Id);
			repo.MarkAsCompleted(test3.Id);
			// test2 nije completed
			List<TodoItem> lista = repo.GetActive();

			Assert.AreEqual(lista[0], test2);
			//Assert.AreEqual(lista[1], test2);
			//Assert.AreEqual(lista[2], test3);

		}

		[TestMethod]
		public void GetCompletedTest()
		{
			TodoRepository repo = new TodoRepository();

			var test1 = new TodoItem("test1");
			var test2 = new TodoItem("test2");
			var test3 = new TodoItem("test3");
			repo.Add(test1);
			repo.Add(test2);
			repo.Add(test3);

			repo.MarkAsCompleted(test1.Id);
			repo.MarkAsCompleted(test3.Id);
			// test2 nije completed
			List<TodoItem> lista = repo.GetCompleted();

			Assert.AreEqual(lista[0], test1);
			Assert.AreEqual(lista[1], test3);
			//Assert.AreEqual(lista[2], test3);
		}

		[TestMethod]
		public void GetFilteredTest()
		{
			TodoRepository repo = new TodoRepository();

			var test1 = new TodoItem("test1");
			var test2 = new TodoItem("test2");
			var test3 = new TodoItem("test3");
			repo.Add(test1);
			repo.Add(test2);
			repo.Add(test3);

			repo.MarkAsCompleted(test1.Id);
			repo.MarkAsCompleted(test3.Id);
			// test2 nije completed
			List<TodoItem> lista = repo.GetFiltered((f) => String.Compare(f.Text, "test1", StringComparison.Ordinal)>0);
			Assert.AreEqual(lista[0], test2);
			Assert.AreEqual(lista[1], test3);
			//Assert.AreEqual(lista[2], test3);
		}

	}
}