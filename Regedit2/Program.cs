using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Regedit2.Configuration;

namespace Regedit2 {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main ( ) {
			Application.EnableVisualStyles ( );
			Application.SetCompatibleTextRenderingDefault ( false );
			Application.Run ( new MainForm ( ) );
		}

		private static ApplicationSettings _settings;
		public static ApplicationSettings Settings {
			get {
				if ( _settings == null ) {
					_settings = ApplicationSettings.Load ( );
				}
				return _settings;
			}
		}

		public static void ResetSettings ( ) {
			_settings = null;
		}
	}
}
