using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Regedit2.Components {
	public class RegistryValueListViewItem : ListViewItem {
		private bool _canWrite = true;
		private bool _canRead = true;

		public RegistryValueListViewItem ( RegistryKeyValue keyValue, RegistryKeyTreeNode parent ) {
			RegistryKeyValue = keyValue;
			RegistryKeyRead = parent.RegistryKeyRead;
			RegistryKeyWrite = parent.RegistryKeyWrite;
			CanRead = parent.CanRead;
			CanWrite = parent.CanWrite;
			this.Text = RegistryKeyValue.Name;
			this.SubItems.Add ( RegistryKeyValue.TypeName.ToString ( ) );
			this.SubItems.Add ( RegistryKeyValue.DataString );
			this.ImageIndex = this.StateImageIndex = (int)RegistryKeyValue.Type;
		}

		/// <summary>
		/// Gets or sets the registry key value.
		/// </summary>
		/// <value>The registry key value.</value>
		public RegistryKeyValue RegistryKeyValue { get; private set; }
		/// <summary>
		/// Gets or sets the registry key read.
		/// </summary>
		/// <value>The registry key read.</value>
		public RegistryKey RegistryKeyRead { get; private set; }
		/// <summary>
		/// Gets or sets the registry key write.
		/// </summary>
		/// <value>The registry key write.</value>
		public RegistryKey RegistryKeyWrite { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance can write.
		/// </summary>
		/// <value><c>true</c> if this instance can write; otherwise, <c>false</c>.</value>
		public bool CanWrite {
			get {
				return _canWrite && RegistryKeyWrite != null;
			}
			private set {
				_canWrite = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance can read.
		/// </summary>
		/// <value><c>true</c> if this instance can read; otherwise, <c>false</c>.</value>
		public bool CanRead {
			get {
				return _canRead && RegistryKeyRead != null;
			}
			private set {
				_canRead = value;
			}
		}

	}
}
