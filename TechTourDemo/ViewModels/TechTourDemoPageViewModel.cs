using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace TechTourDemo
{
	public class TechTourDemoPageViewModel : BaseViewModel
	{
		public ObservableCollection<TodoItem> TodoItems
		{
			get;
			set;
		}

		public ICommand AddTodoCommand
		{
			get;
			set;
		}

		public ICommand SelectTodoItemCommand
		{
			get;
			set;
		}

		public ICommand DeleteTodoItemCommand
		{
			get;
			set;
		}

		public TechTourDemoPageViewModel()
		{
			TodoItems = new ObservableCollection<TodoItem>(new List<TodoItem>
			{
				new TodoItem { IsDone = true, Name = "Xamarin.Forms - Intro" },
				new TodoItem { IsDone = true, Name = "Xamarin.Forms - Hello World" },
				new TodoItem { IsDone = true, Name = "Xamarin.Forms - ListView" },
				new TodoItem { IsDone = true, Name = "Xamarin.Forms - Data Binding" },
				new TodoItem { IsDone = false, Name = "Xamarin.Forms - SQLite!!" }
			});

			MessagingCenter.Subscribe<DetailPageViewModel, TodoItem>(this, "SaveTodo", HandleAction);

			AddTodoCommand = new Command(() =>
			{
				var page = new DetailPage(new TodoItem());
				Application.Current.MainPage.Navigation.PushAsync(page);
			});

			SelectTodoItemCommand = new Command<TodoItem>((TodoItem obj) =>
			{
				var page = new DetailPage(obj);

				Application.Current.MainPage.Navigation.PushAsync(page);
			});

			DeleteTodoItemCommand = new Command<TodoItem>(async (TodoItem obj) =>
			{
				var confirm = await Application.Current.MainPage.DisplayAlert("Confirmar", $"¿Deseas borrar {obj.Name}?", "Si", "No");

				if (confirm)
				{
					TodoItems.Remove(obj);
				}
			});
		}

		void HandleAction(DetailPageViewModel arg1, TodoItem arg2)
		{
			var exists = TodoItems.Any(x => x.Name == arg2.Name);

			if (!exists)
			{
				TodoItems.Add(arg2);
			}

			Application.Current.MainPage.Navigation.PopAsync(true);
		}
	}
}
