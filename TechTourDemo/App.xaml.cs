using Xamarin.Forms;

namespace TechTourDemo
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var demoPage = new TechTourDemoPage();
			MainPage = new NavigationPage(demoPage);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
