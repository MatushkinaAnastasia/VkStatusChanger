using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using VkNet;
using VkNet.Exception;
using VkNet.Model;

namespace Vk_App
{
	/// <summary>
	/// Логика взаимодействия для Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		private string auth = "https://oauth.vk.com/authorize?client_id=7597011&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=status,offline&response_type=token&v=5.52";
		public string Token { get; private set; }
		public long User_ID { get; private set; }
		public Login()
		{
			InitializeComponent();

			browser.Navigate(auth);
			browser.Navigated += Browser_Navigated;
		}

		private void Browser_Navigated(object sender, NavigationEventArgs e)
		{
			string url = browser.Source.AbsoluteUri.ToString();
			if (url.Contains("#access_token="))
			{
				browser.Navigated -= Browser_Navigated;
			
				char[] symbols = { '=', '&' };
				string[] slices = url.Split(symbols);

				User_ID = long.Parse(slices[5]);
				Token = slices[1];
				DialogResult = true;

				Close();
			}
		}
	}
}
