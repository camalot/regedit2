using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading;

namespace Regedit2.Components {
	public class RegistryKeyTreeNode : FolderTreeNode {

		public RegistryKeyTreeNode ( string keyName, RegistryKey read, RegistryKey write )
			: base ( keyName ) {
			RegistryKeyWrite = write;
			RegistryKeyRead = read;
			CanWrite = RegistryKeyWrite != null;
			CanRead = RegistryKeyRead != null;
			if ( CanRead && RegistryKeyRead.GetSubKeyNames ( ).Length > 0 ) {
				this.GetNodes ( ).Add ( new Dummy ( ) );
			}


		}
		public RegistryKey RegistryKeyWrite { get; private set; }
		public RegistryKey RegistryKeyRead { get; private set; }

		private Thread RunningThread { get; set; }

		private bool _canWrite = true;
		public bool CanWrite {
			get {
				return _canWrite && RegistryKeyWrite != null;
			}
			private set {
				_canWrite = value;
			}
		}

		private bool _canRead = true;
		public bool CanRead {
			get {
				return _canRead && RegistryKeyRead != null;
			}
			private set {
				_canRead = value;
			}
		}

		public override void OnBeforeCollapse ( System.Windows.Forms.TreeViewCancelEventArgs e ) {
			if ( !e.Cancel ) {
				if ( RunningThread != null && RunningThread.IsAlive ) {
					try {
						RunningThread.Abort ( );
					} catch ( ThreadAbortException tae ) {

					}
				}
				this.Nodes.Clear ( );
				if ( CanRead && RegistryKeyRead.GetSubKeyNames ( ).Length > 0 ) {
					this.GetNodes ( ).AddTreeNode ( new Dummy ( ) );
				}
			}
			base.OnBeforeCollapse ( e );

		}

		public override void OnBeforeExpand ( System.Windows.Forms.TreeViewCancelEventArgs e ) {
			base.OnBeforeExpand ( e );
			if ( RunningThread != null && RunningThread.IsAlive ) {
				e.Cancel = true;
			}

			if ( !e.Cancel ) {
				RunningThread = new Thread ( new ParameterizedThreadStart ( delegate ( object state ) {
					RegistryKeyTreeNode rktn = state as RegistryKeyTreeNode;
					if ( rktn != null ) {
						this.GetNodes ( ).ClearEx ( this.TreeView );

						foreach ( var item in rktn.RegistryKeyRead.GetSubKeyNames ( ) ) {
							RegistryKey swkey = null;
							RegistryKey srkey = null;
							RegistryKeyTreeNode srktn = null;
							try {
								swkey = rktn.CanWrite ? rktn.RegistryKeyWrite.OpenSubKey(item,true) : rktn.RegistryKeyRead.OpenSubKey ( item, true );
							} catch ( Exception ex ) {
								Console.WriteLine ( ex.ToString ( ) );
							}

							try {
								srkey = rktn.RegistryKeyRead.OpenSubKey ( item, false );
							} catch ( Exception ex ) {
								Console.WriteLine ( ex.ToString ( ) );
							}
							srktn = new RegistryKeyTreeNode ( item, srkey, swkey );
							srktn.CanWrite = swkey != null;

							this.GetNodes ( ).AddTreeNode ( this.TreeView, srktn );
						}
					}
				} ) );
				RunningThread.Start ( this );
			}
		}
	}
}
