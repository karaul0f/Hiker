using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;

namespace HikerEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private static List<CultureInfo> _languages = new List<CultureInfo>();

        public static List<CultureInfo> Languages => _languages;

		public App()
		{
			_languages.Clear();
			_languages.Add(new CultureInfo("en-US"));
			_languages.Add(new CultureInfo("ru-RU"));

		}

		public static Window CurrentMainWindow => Current.MainWindow;
    }
}
