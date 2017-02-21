using System;
using System.IO;
using TechTourDemo.Droid;
using Xamarin.Forms;

[assembly:Dependency(typeof(DatabaseFile_Droid))]
namespace TechTourDemo.Droid
{
	public class DatabaseFile_Droid : IDatabaseFile
	{

		public string GetDatabaseFile(string file)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, file);
		}
	}
}
