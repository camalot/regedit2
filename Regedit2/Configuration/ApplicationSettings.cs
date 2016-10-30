using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;

namespace Regedit2.Configuration {
	/// <summary>
	/// 
	/// </summary>
	[XmlRoot ( "Regedit" )]
	public class ApplicationSettings {
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationSettings"/> class.
		/// </summary>
		public ApplicationSettings ( ) {
			Title = "Registry Editor 2";
			DefaultValueName = "(Default)";
			ShowTreeLines = true;
			LastNode = string.Empty;
			Hives = new List<HiveItem> ( );
			NullValue = "(value not set)";
		}

		/// <summary>
		/// Gets or sets the null value.
		/// </summary>
		/// <value>The null value.</value>
		[XmlElement("NullValue")]
		public String NullValue { get; set; }

		/// <summary>
		/// Gets or sets the default name of the value.
		/// </summary>
		/// <value>The default name of the value.</value>
		[XmlElement("DefaultValueName")]
		public String DefaultValueName { get; set; }
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		[XmlElement ( "Title" )]
		public String Title { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether [show tree lines].
		/// </summary>
		/// <value><c>true</c> if [show tree lines]; otherwise, <c>false</c>.</value>
		[XmlElement ( "ShowTreeLines" )]
		public bool ShowTreeLines { get; set; }
		/// <summary>
		/// Gets or sets the last node.
		/// </summary>
		/// <value>The last node.</value>
		[XmlElement ( "LastNode" )]
		public String LastNode { get; set; }
		/// <summary>
		/// Gets or sets the hives.
		/// </summary>
		/// <value>The hives.</value>
		[XmlArray ( "Hives" ), XmlArrayItem ( "Hive" )]
		public List<HiveItem> Hives { get; set; }

		/// <summary>
		/// Gets the configuration file.
		/// </summary>
		/// <value>The configuration file.</value>
		public static FileInfo ConfigurationFile {
			get {
				Assembly asm = typeof ( ApplicationSettings ).Assembly;
				String path = Path.GetDirectoryName ( asm.Location );
				String configFile = Path.GetFileNameWithoutExtension ( Assembly.GetCallingAssembly ( ).Location );
				return new FileInfo ( Path.Combine ( path, string.Format ( "{0}.config", configFile ) ) );
			}
		}


		/// <summary>
		/// Loads the settings file
		/// </summary>
		/// <returns></returns>
		public static ApplicationSettings Load ( ) {
			FileInfo cf = ConfigurationFile;
			ApplicationSettings settings = null;
			if ( cf.Exists ) {
				try {
					XmlSerializer ser = new XmlSerializer ( typeof ( ApplicationSettings ) );
					using ( var fs = new FileStream ( cf.FullName, FileMode.Open, FileAccess.Read ) ) {
						settings = ser.Deserialize ( fs ) as ApplicationSettings;
					}
				} catch ( Exception ex ) {
					Console.WriteLine ( ex.ToString ( ) );
					settings = new ApplicationSettings ( );
				}
			} else {
				settings = new ApplicationSettings ( );
			}

			return settings;
		}

		/// <summary>
		/// Saves the settings to disk.
		/// </summary>
		public void Save ( ) {
			FileInfo cf = ConfigurationFile;
				try {
					XmlSerializer ser = new XmlSerializer ( typeof ( ApplicationSettings ) );
					using ( var fs = new FileStream ( cf.FullName, FileMode.Create, FileAccess.Write ) ) {
						ser.Serialize ( fs, this );
					}
				} catch ( Exception ex ) {
					Console.WriteLine ( ex.ToString ( ) );
				}
		}
	}
}
