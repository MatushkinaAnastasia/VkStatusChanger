using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using VkNet;
using VkNet.Exception;
using VkNet.Model;

namespace Vk_App
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly string filename = "token.txt";
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OK_click(object sender, RoutedEventArgs e)
		{
			if (!IsFileExistsAndNotEmpty())
			{
				var browser = new Login();
				browser.ShowDialog();

				if (browser.DialogResult == true)
				{
					WriteDataToFile(browser.Token, browser.User_ID);
				}
				else
				{
					return;
				}
			}

			var token = GetTokenFromFile();
			var user_ID = GetUserIDFromFile();

			Authorize(token, user_ID, filename);

			Close();
		}

		private void Authorize(string token, long user_ID, string filename)
		{
			try
			{
				VkApi vkApi = new VkApi();
				vkApi.Authorize(new ApiAuthParams
				{
					AccessToken = token
				});
				MessageBox.Show("Вход выполнен!");
				new VkStatus(vkApi, user_ID, filename).Show();
			}
			catch (VkAuthorizationException er)
			{ 
				MessageBox.Show("Ошибка " + er);
			}
		}

		private void WriteDataToFile(string token, long user_ID)
		{
			using (var writer = new StreamWriter(filename))
			{
				writer.WriteLine(Cryptographer.Encrypt(token));
				writer.Write(Cryptographer.Encrypt(user_ID.ToString()));
			}
		}

		private bool IsFileExistsAndNotEmpty()
		{
			if (!File.Exists(filename)) return false;
			using (var file = File.OpenRead(filename))
			{
				return file.Length != 0;
			}
		}

		private long GetUserIDFromFile()
		{
			using (var reader = new StreamReader(filename))
			{
				reader.ReadLine();
				var str = reader.ReadLine();
				var id_str = Cryptographer.Decrypt(str);
				return long.Parse(id_str);
			}
		}

		private string GetTokenFromFile()
		{
			using (var reader = new StreamReader(filename))
			{
				var token = reader.ReadLine();
				return Cryptographer.Decrypt(token);
			}	
		}
	}
}
