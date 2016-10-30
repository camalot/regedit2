using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Regedit2.Components;
using System.Threading;
using Microsoft.Win32;

namespace Regedit2 {
	public partial class MainForm : Form {


		/// <summary>
		/// Initializes a new instance of the <see cref="MainForm"/> class.
		/// </summary>
		public MainForm ( ) {
			InitializeComponent ( );
			this.Text = Program.Settings.Title;
			this.hive.ShowLines = Program.Settings.ShowTreeLines;
			SystemImageList.SetImageList ( hive, SystemImageListHost.Instance.SmallSystemImageList, false );
			SystemImageList.SetImageList ( hive, SystemImageListHost.Instance.SmallSystemImageList, true );

			AlphaImageList.AddFromImage ( Properties.Resources.TextboxHS, imageList );
			AlphaImageList.AddFromImage ( Properties.Resources.PageNumber, imageList );
			AlphaImageList.AddFromImage ( Properties.Resources.AttachFileHS, imageList );
			AlphaImageList.AddFromImage ( Properties.Resources.DocumentHS, imageList );

			this.values.SmallImageList = imageList;

			this.hive.AfterSelect += delegate ( object sender, TreeViewEventArgs e ) {
				if ( e.Node != null ) {
					this.statusLabel.Text = e.Node.FullPath;
					if ( e.Node is RegistryKeyTreeNode ) {
						SetSelectedKey ( ( e.Node as RegistryKeyTreeNode ) );
					} else {
						SetSelectedKey ( null );
					}
				}
			};
			new System.Threading.Thread ( new ThreadStart ( BuildHiveCore ) ).Start ( );
		}

		private void SetSelectedKey ( RegistryKeyTreeNode registryKeyTreeNode ) {
			this.values.Items.Clear ( );
			if ( registryKeyTreeNode == null || !registryKeyTreeNode.CanRead ) {
				return;
			} else {

				List<String> valueNames = new List<String> ( registryKeyTreeNode.RegistryKeyRead.GetValueNames ( ) );
				if ( !valueNames.Contains ( "" ) ) {
					valueNames.Add ( "" );
				}
				valueNames.Sort();

				foreach ( var item in valueNames ) {
					object data = registryKeyTreeNode.RegistryKeyRead.GetValue ( item, null );
					Microsoft.Win32.RegistryValueKind rvk = data == null ? Microsoft.Win32.RegistryValueKind.String : registryKeyTreeNode.RegistryKeyRead.GetValueKind ( item );
					String name = string.IsNullOrWhiteSpace ( item ) ? Program.Settings.DefaultValueName : item;
					RegistryKeyValue rkv = new RegistryKeyValue ( ) {
						TypeName = rvk,
						Name = name,
						Data = data
					};
					this.values.Items.Add ( new RegistryValueListViewItem ( rkv, registryKeyTreeNode ) );
				}

			}
		}

		/// <summary>
		/// Builds the hive core.
		/// </summary>
		private void BuildHiveCore ( ) {
			this.hive.GetNodes ( ).AddTreeNode ( this.hive, new RootTreeNode ( ) );
			foreach ( var item in Program.Settings.Hives ) {
				this.hive.GetNodes ( ).AddTreeNode ( this.hive, new RootTreeNode ( item.HostName ) );
			}
		}

		private void saveToolStripButton_Click ( object sender, EventArgs e ) {
			Registry.CurrentUser.ExportKey(@"c:\Users\Ryan\Desktop\cu2.hive");
		}


	}
}
