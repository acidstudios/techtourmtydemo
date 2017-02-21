using System.Collections.Generic;
using Xamarin.Forms;

using System.Linq;
using System.Collections.ObjectModel;

namespace TechTourDemo
{
	public partial class TechTourDemoPage : ContentPage
	{
		public TechTourDemoPage()
		{
			InitializeComponent();
			BindingContext = new TechTourDemoPageViewModel();

		}
	}
}
