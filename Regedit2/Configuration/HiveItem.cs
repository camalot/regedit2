using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Regedit2.Configuration {
	public class HiveItem {
		/// <summary>
		/// Initializes a new instance of the <see cref="HiveItem"/> class.
		/// </summary>
		public HiveItem ( ) {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HiveItem"/> class.
		/// </summary>
		/// <param name="hostName">Name of the host.</param>
		public HiveItem (String hostName ) {
			this.HostName = hostName;
		}
		/// <summary>
		/// Gets or sets the name of the host.
		/// </summary>
		/// <value>The name of the host.</value>
		[XmlAttribute("HostName")]
		public String HostName { get; set; }
	}
}
