using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Regedit2.Components {
	public class FolderTreeNode : EventTreeNode {
		public FolderTreeNode ( String name ) {
			int i = SystemImageListHost.Instance.SmallSystemImageList.IconIndex ( Environment.GetFolderPath ( Environment.SpecialFolder.System ), true );
			this.ImageIndex = this.SelectedImageIndex = i;
			this.Text = name;
		}

		public class Dummy : TreeNode {
			public Dummy ( ) {
				this.Text = "dummy";
			}
		}
	}
}
