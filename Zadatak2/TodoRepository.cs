using System;
using System.Collections.Generic;
using RaupjcHW1_zad3;
using System.Linq;

namespace Zadatak2
{
	/// <summary >
	/// Class that encapsulates all the logic for accessing TodoTtems .
	/// </summary >
	public class TodoRepository : ITodoRepository
	{
		/// <summary >
		/// Repository does not fetch todoItems from the actual database ,
		/// it uses in memory storage for this excersise .
		/// </summary >
		private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
		public TodoRepository(IGenericList<TodoItem> initialDbState = null)
		{
			if (initialDbState != null)
			{
				_inMemoryTodoDatabase = initialDbState;
			}
			else
			{
				_inMemoryTodoDatabase = new GenericList<TodoItem>();
			}
			// Shorter way to write this in C# using ?? operator :
			// x ?? y = > if x is not null , expression returns x. Else it will return y.
			// _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
		}

		public TodoItem Get(Guid todoId)
		{
			if (_inMemoryTodoDatabase.Count == 0) return null;
			TodoItem t = _inMemoryTodoDatabase.FirstOrDefault(i =>
			{
				if (i == null) return false;  //nisam siguran jel najbolje
				return i.Id == todoId;
			});
			return t;

		}

		public TodoItem Add(TodoItem todoItem)
		{
			if (_inMemoryTodoDatabase.Contains(todoItem))
				throw new DuplicateTodoItemException($"duplicate Id: {todoItem.Id}");
			_inMemoryTodoDatabase.Add(todoItem);
			return todoItem;

		}

		public bool Remove(Guid todoId)
		{
			if (_inMemoryTodoDatabase.Count == 0) return false;
			TodoItem t = _inMemoryTodoDatabase.FirstOrDefault(i =>
			{
				if (i == null) return false;  //nisam siguran jel najbolje
				return i.Id == todoId;
			});
			if (t == null) return false;
			_inMemoryTodoDatabase.Remove(t);
			return true;

		}

		public TodoItem Update(TodoItem todoItem)
		{
			return Add(todoItem); //mozda sam skroz krivo shvatio
		}

		public bool MarkAsCompleted(Guid todoId)
		{
			var temp = Get(todoId);
			if (temp != null && temp.IsCompleted == false)
			{
				temp.DateCompleted = DateTime.UtcNow;
				return true;
			}
			return false;
		}

		public List<TodoItem> GetAll()
		{
			var notNullDatabase = _inMemoryTodoDatabase.Where(x => x != null).ToList();
			return notNullDatabase.OrderByDescending(d => d.DateCreated).ToList();
		}

		public List<TodoItem> GetActive()
		{
			var notNullDatabase = _inMemoryTodoDatabase.Where(x => x != null).ToList();
			return notNullDatabase.Where(s => !s.IsCompleted)
								  .OrderByDescending(d => d.DateCreated)
								  .ToList();
		}

		public List<TodoItem> GetCompleted()
		{
			var notNullDatabase = _inMemoryTodoDatabase.Where(x => x != null).ToList();
			return notNullDatabase.Where(s => s.IsCompleted)
								  .OrderByDescending(d => d.DateCreated)
								  .ToList();
		}

		public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
		{
			var notNullDatabase = _inMemoryTodoDatabase.Where(x => x != null).ToList();
			return notNullDatabase.Where(filterFunction)
								  .OrderByDescending(d => d.DateCreated)
								  .ToList();
		}
	}

	public class DuplicateTodoItemException : Exception
	{
		public DuplicateTodoItemException(string message) : base(message)
		{			
		}
	}
}