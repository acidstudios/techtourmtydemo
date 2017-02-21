using System;
using System.IO;
using TechTourDemo.iOS;
using Xamarin.Forms;

[assembly:Dependency(typeof(DatabaseFile_IOS))]
namespace TechTourDemo.iOS
{
	public class DatabaseFile_IOS : IDatabaseFile
	{
		public string GetDatabaseFile(string file)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}

			return Path.Combine(libFolder, file);
		}
	}
}
