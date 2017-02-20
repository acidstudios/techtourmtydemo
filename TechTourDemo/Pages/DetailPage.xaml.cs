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

			Title = item.Name;
			TableSection.Title = $"Detalle de: {item.Name}";

			txtName.Text = item.Name;
			swDone.On = item.IsDone;

			txtName.IsEnabled = false;
			swDone.IsEnabled = true;
		}

		public DetailPage()
		{
			InitializeComponent();
			Title = "Agregar";
			TableSection.Title = "Agregar Item";
		}

		void Handle_Clicked(object sender, EventArgs e)
		{
			var item = new TodoItem 
			{
				Name = txtName.Text,
				IsDone = swDone.On
			};

			MessagingCenter.Send(this, "SaveTodo", item);
		}
	}
}
