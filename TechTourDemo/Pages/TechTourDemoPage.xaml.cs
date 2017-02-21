using System.Collections.Generic;
using Xamarin.Forms;

using System.Linq;
using System.Collections.ObjectModel;

namespace TechTourDemo
{
	public partial class TechTourDemoPage : ContentPage
	{
		public ObservableCollection<TodoItem> TodoItems
		{
			get;
			set;
		}

		public TechTourDemoPage()
		{
			InitializeComponent();

			TodoItems = new ObservableCollection<TodoItem>(new List<TodoItem>
			{
				new TodoItem { IsDone = true, Name = "Xamarin.Forms - Intro" },
				new TodoItem { IsDone = true, Name = "Xamarin.Forms - Hello World" },
				new TodoItem { IsDone = false, Name = "Xamarin.Forms - ListView" },
				new TodoItem { IsDone = false, Name = "Xamarin.Forms - Data Binding" },
				new TodoItem { IsDone = false, Name = "Xamarin.Forms - SQLite!!" }
			});

			TodoList.ItemsSource = TodoItems;

			MessagingCenter.Subscribe<DetailPage, TodoItem>(this, "SaveTodo", HandleAction);
		}

		void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var selectedItem = e.SelectedItem as TodoItem;
			var page = new DetailPage(selectedItem);

			Navigation.PushAsync(page);
		}

		void HandleAction(DetailPage arg1, TodoItem arg2)
		{
			var exists = TodoItems.Any(x => x.Name == arg2.Name);

			if (!exists)
			{
				TodoItems.Add(arg2);
			}
			else
			{
				var item = TodoItems.First(x => x.Name == arg2.Name);
				item.IsDone = arg2.IsDone;
			}

			Navigation.PopAsync(true);
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			var page = new DetailPage();
			Navigation.PushAsync(page);
		}
	}
}
