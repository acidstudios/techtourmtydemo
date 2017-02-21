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
			var items = Database.GetAll();
			TodoItems = new ObservableCollection<TodoItem>(items);

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
					var deleted = Database.Delete(obj);

					if (deleted > 0)
					{
						TodoItems.Remove(obj);
					}
				}
			});
		}

		void HandleAction(DetailPageViewModel arg1, TodoItem arg2)
		{
			var isInsert = arg2.Id == 0;
			var exists = Database.Upsert(arg2);

			if (exists > 0 && isInsert)
			{
				TodoItems.Add(arg2);
			}

			Application.Current.MainPage.Navigation.PopAsync(true);
		}
	}
}
