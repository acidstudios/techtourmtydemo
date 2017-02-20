using System;
using Xamarin.Forms;

namespace TechTourDemo
{
	public partial class TechTourDemoPage : ContentPage
	{
		private int times;

		public TechTourDemoPage()
		{
			InitializeComponent();
			times = 0;
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			times++;
			DisplayAlert("Hola", $"Haz tocado el boton {times} veces", "Ok");
		}
	}
}
