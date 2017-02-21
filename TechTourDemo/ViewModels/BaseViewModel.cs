using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TechTourDemo
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public string Title
		{
			get;
			set;
		}

		public BaseViewModel()
		{
		}


		protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
