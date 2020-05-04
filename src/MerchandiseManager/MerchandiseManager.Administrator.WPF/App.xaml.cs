using MerchandiseManager.Administrator.WPF.DI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MerchandiseManager.Administrator.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		string filename = "App.txt";

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			IoC.Setup();

			Properties["Username"] = string.Empty;
			
			InitStorage();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			// Persist application-scope property to isolated storage
			IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForDomain();
			using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(filename, FileMode.Create, storage))
			using (StreamWriter writer = new StreamWriter(stream))
			{
				// Persist each application-scope property individually
				foreach (string key in this.Properties.Keys)
				{
					writer.WriteLine("{0},{1}", key, this.Properties[key]);
				}
			}
		}

		private void InitStorage()
		{
			// Restore application-scope property from isolated storage
			IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForDomain();
			try
			{
				using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(filename, FileMode.Open, storage))
				using (StreamReader reader = new StreamReader(stream))
				{
					// Restore each application-scope property individually
					while (!reader.EndOfStream)
					{
						string[] keyValue = reader.ReadLine().Split(new char[] { ',' });
						this.Properties[keyValue[0]] = keyValue[1];
					}
				}
			}
			catch (FileNotFoundException ex)
			{
				// Handle when file is not found in isolated storage:
				// * When the first application session
				// * When file has been deleted
			}
		}
	}
}
