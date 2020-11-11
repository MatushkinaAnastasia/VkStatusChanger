using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using VkNet;
using VkNet.Exception;
using VkNet.Model;

namespace Vk_App
{
	/// <summary>
	/// Логика взаимодействия для VkStatus.xaml
	/// </summary>
	public partial class VkStatus : Window
	{
		private readonly long user_id;
		private readonly VkApi vkApi;
		private readonly string filename;
		public VkStatus(VkApi vkApi, long user_id, string filename)
		{
			InitializeComponent();
			this.vkApi = vkApi;
			this.user_id = user_id;
			this.filename = filename;

			var p = vkApi.Users.Get(new long[] { user_id }).FirstOrDefault();
			welcomuser.Content = "Приветствую, " + p.FirstName + "!";
		}

		private void GetStatus(object sender, RoutedEventArgs e)
		{
			status_text.Text = vkApi.Status.Get(user_id).Text;
		}

		private void NewStatus(object sender, RoutedEventArgs e)
		{
			bool result = vkApi.Status.Set(status_text.Text);
			if (result)
			{
				MessageBox.Show("Новый статус создан. Можете проверить в вк :)");
			}
			else
			{
				MessageBox.Show("Что-то пошло не так...");
			}
			status_text.Text = "";
		}

		private void DeleteStatus(object sender, RoutedEventArgs e)
		{
			bool result = vkApi.Status.Set("");
			status_text.Text = "";

			if (result)
			{
				MessageBox.Show("Статус удален. Можете проверить в вк :)");
			}
			else
			{
				MessageBox.Show("Что-то пошло не так...");
			}
		}

		private void magicStatus(object sender, RoutedEventArgs e)
		{
			string status = vkApi.Status.Get(user_id).Text;

		/*	var reverse_status = "";
			for (int i = status.Length - 1; i >= 0; i--)
			{
				reverse_status += status[i];
			}
		*/

			bool result = vkApi.Status.Set(Flip(status)+"😜");
			status_text.Text = "";
			if (result)
			{
				MessageBox.Show("Магия есть! Можете проверить в вк :)");
			}
			else
			{
				MessageBox.Show("Что-то пошло не так...");
			}

			//  😀 😇 😈 😎 😐 😑 😕 😗 😙 😛 😟 😦 😧 😬 😮 😯 😴 😶 😁 😂 😃 😄 😅 😆 😉 😊 😋 😌 😍 😏 😒 😓 😔 😖 😘 😚 😜 😝 😞 😠 😡 😢 😣 😤 😥 😨 😩 😪 😫 😭 😰 😱 😲 😳 😵 😷
			//  🙅 🙆 🙇 🙈 🙉 🙊 🙋 🙌 🙍 🙎 🙏 🗿 👤 👦 👧 👨 👩 👪 👫 👮 👯 👰 👱 👲 👳 👴 👵 👶 👷 👸 👹 👺 👻 👼 👽 👾 👿 💀 💁 💂 💃 💆

		}

		private static readonly Dictionary<char, char> flipTable = new Dictionary<char, char>
		{
			['а'] = 'ɐ',
			['б'] = 'ƍ',
			['в'] = 'ʚ',
			['г'] = 'ɹ',
			['д'] = 'ɓ',
			['е'] = 'ǝ',
			['ё'] = 'ǝ',
			['ж'] = 'ж',
			['з'] = 'ε',
			['и'] = 'и',
			['й'] = 'ņ',
			['к'] = 'ʞ',
			['л'] = 'v',
			['м'] = 'w',
			['н'] = 'н',
			['о'] = 'о',
			['п'] = 'u',
			['р'] = 'd',
			['с'] = 'ɔ',
			['т'] = 'ɯ',
			['у'] = 'ʎ',
			['ф'] = 'ȸ',
			['х'] = 'х',
			['ц'] = 'ǹ',
			['ч'] = 'Һ',
			['ш'] = 'm',
			['щ'] = 'm',
			['ъ'] = 'q',
			['ы'] = 'ы',
			['ь'] = 'q',
			['э'] = 'є',
			['ю'] = 'd',
			['я'] = 'ʁ',
			['a'] = '\u0250',
			['b'] = 'q',
			['c'] = '\u0254',
			['d'] = 'p',
			['e'] = '\u01DD',
			['f'] = '\u025F',
			['g'] = '\u0183',
			['h'] = '\u0265',
			['i'] = '\u0131',
			['j'] = '\u027E',
			['k'] = '\u029E',
			//l = '\u0283',
			['m'] = 'ɯ',
			['n'] = 'u',
			['p'] = 'd',
			['q'] = 'ᕹ',
			['r'] = '\u0279',
			['t'] = '\u0287',
			['u'] = 'n',
			['v'] = '\u028C',
			['w'] = '\u028D',
			['y'] = '\u028E',
			['.'] = '\u02D9',
			['['] = ']',
			['('] = ')',
			[']'] = '[',
			[')'] = '(',
			['{'] = '}',
			['}'] = '{',
			['?'] = '\u00BF',
			['!'] = '\u00A1',
			['<'] = '>',
			['_'] = '\u203E',
			['\u203F'] = '\u2040',
			['\u2045'] = '\u2046',
			['\u2234'] = '\u2235'
		};
		private string Flip(string str)
		{
			var last = str.Length - 1;
			string result_str = "";
			for (int i = last; i >= 0; i--)
			{
				if (flipTable.ContainsKey(str[i]))
				{
					var flip_symbol = flipTable[str[i]];
					result_str += flip_symbol;
				}
				else
				{
					result_str += str[i];
				}
			}
			return result_str;
		}

		private void outFromAcc(object sender, RoutedEventArgs e)
		{
			deleteCookie();
			File.Delete(filename);
			Close();
		}

		private void deleteCookie()
		{
			Process.Start("cmd.exe", "/C RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 255");
			string[] Cookies = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
			int notDeleted = 0;
			foreach (string CookieFile in Cookies)
			{
				try
				{
					File.Delete(CookieFile);
				}
				catch (Exception ex)
				{
					notDeleted++;
				}
			}
			//MessageBox.Show((Cookies.Length - notDeleted).ToString() + " Cookies Deleted, " + notDeleted.ToString() + " Cookies Not Deleted", "Cookies");
		}
	}
}
