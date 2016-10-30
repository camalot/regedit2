using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Regedit2.Components {
	/// <summary>
	/// 
	/// </summary>
	public class RootTreeNode : EventTreeNode {

		/// <summary>
		/// Initializes a new instance of the <see cref="RootTreeNode"/> class.
		/// </summary>
		public RootTreeNode ( ) : this(Environment.MachineName) {
			HasAccess = true;
		}



		/// <summary>
		/// Initializes a new instance of the <see cref="RootTreeNode"/> class.
		/// </summary>
		/// <param name="remoteHostName">Name of the remote host.</param>
		public RootTreeNode ( String remoteHostName ) {
			RemoteHostName = remoteHostName;
			this.Text = string.Format ( "{0}{1}", remoteHostName.Substring ( 0, 1 ).ToUpper ( ), remoteHostName.Substring ( 1 ).ToLower ( ) );
			int i = SystemImageListHost.Instance.SmallSystemImageList.IconIndex ( Environment.GetFolderPath ( Environment.SpecialFolder.MyComputer ), false );
			this.ImageIndex = this.SelectedImageIndex = i;
			this.IsLocalHive = string.Compare ( remoteHostName, Environment.MachineName, true ) == 0;
			LoadBaseHive ( );

		}

		public bool IsLocalHive { get; private set; }

		/// <summary>
		/// Loads the base hive.
		/// </summary>
		private void LoadBaseHive ( ) {
			try {
				RegistryKey cr = this.IsLocalHive ? Registry.ClassesRoot : RegistryKey.OpenRemoteBaseKey ( RegistryHive.ClassesRoot, RemoteHostName );
				RegistryKey cu = this.IsLocalHive ? Registry.CurrentUser : RegistryKey.OpenRemoteBaseKey ( RegistryHive.CurrentUser, RemoteHostName );
				RegistryKey lm = this.IsLocalHive ? Registry.LocalMachine : RegistryKey.OpenRemoteBaseKey ( RegistryHive.LocalMachine, RemoteHostName );
				RegistryKey u = this.IsLocalHive ? Registry.Users : RegistryKey.OpenRemoteBaseKey ( RegistryHive.Users, RemoteHostName );
				RegistryKey cc = this.IsLocalHive ? Registry.CurrentConfig : RegistryKey.OpenRemoteBaseKey ( RegistryHive.CurrentConfig, RemoteHostName );


				this.Nodes.Add ( new RegistryKeyTreeNode ( "HKEY_CLASSES_ROOT", cr, cr ) );
				this.Nodes.Add ( new RegistryKeyTreeNode ( "HKEY_CURRENT_USER", cu, cu ) );
				this.Nodes.Add ( new RegistryKeyTreeNode ( "HKEY_LOCAL_MACHINE", lm, lm ) );
				this.Nodes.Add ( new RegistryKeyTreeNode ( "HKEY_USERS", u, u ) );
				this.Nodes.Add ( new RegistryKeyTreeNode ( "HKEY_CURRENT_CONFIG", cc, cc ) );
			} catch ( Exception ex ) {
				this.HasAccess = false;
				Console.WriteLine ( ex.ToString ( ) );
			}
		}


		/// <summary>
		/// Gets or sets the name of the remote host.
		/// </summary>
		/// <value>The name of the remote host.</value>
		public String RemoteHostName { get; private set; }

		public bool HasAccess { get;private set; }
	}
}
