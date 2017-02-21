using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace TechTourDemo
{
	public class DetailPageViewModel : BaseViewModel
	{
		TodoItem _selectedItem;
		public TodoItem SelectedItem
		{
			get { return _selectedItem; }
			set 
			{ 
				_selectedItem = value;
				OnPropertyChanged();
			}
		}

		string _sectionTitle;
		public string SectionTitle
		{
			get { return _sectionTitle; }
			set
			{
				_sectionTitle = value;
				OnPropertyChanged();
			}
		}

		bool _canEdit;
		public bool CanEdit
		{
			get { return _canEdit; }
			set
			{
				_canEdit = value;
				OnPropertyChanged();
			}
		}

		public ICommand SaveTodoCommand
		{
			get;
			set;
		}

		public DetailPageViewModel(TodoItem item)
		{
			SelectedItem = item;

			SaveTodoCommand = new Command(() =>
			{
				MessagingCenter.Send<DetailPageViewModel, TodoItem>(this, "SaveTodo", SelectedItem);
			});

			CanEdit = string.IsNullOrEmpty(item.Name);

			if (!CanEdit)
			{
				SectionTitle = $"Detalle de {SelectedItem.Name}";
				Title = SelectedItem.Name;
			}
			else
			{
				Title = "Agregar Tarea";
			}
		}
	}
}
