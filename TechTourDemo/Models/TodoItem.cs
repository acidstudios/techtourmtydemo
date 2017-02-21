using System;
using SQLite;

namespace TechTourDemo
{
	[Table("TodoItems")]
	public class TodoItem
	{
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id
		{
			get;
			set;
		}

		[Column("Name")]
		public string Name
		{
			get;
			set;
		}

		[Column("IsDone")]
		public bool IsDone
		{
			get;
			set;
		}
	}
}
