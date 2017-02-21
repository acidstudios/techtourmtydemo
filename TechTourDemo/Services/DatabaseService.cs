using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace TechTourDemo
{
	public class DatabaseService
	{
		private SQLiteConnection _connection;

		public DatabaseService()
		{
			var fileLocation = DependencyService.Get<IDatabaseFile>().GetDatabaseFile("TodoDatabase.db3");

			_connection = new SQLiteConnection(fileLocation);
			_connection.CreateTable<TodoItem>();
		}

		public List<TodoItem> GetAll()
		{
			return _connection.Table<TodoItem>().ToList();
		}

		public int Upsert(TodoItem item)
		{
			if (item.Id == 0)
			{
				return _connection.Insert(item);
			}

			return _connection.Update(item);
		}

		public int Delete(TodoItem item)
		{
			return _connection.Delete(item);
		}
	}
}
