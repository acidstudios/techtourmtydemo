using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TechTourDemo
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage(TodoItem item)
		{
			InitializeComponent();
			BindingContext = new DetailPageViewModel(item);
		}
	}
}
