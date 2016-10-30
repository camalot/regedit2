using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Regedit2.Components {
	public static class TreeNodeCollectionExtension {
		private delegate TreeNodeCollection GetNodesDelegate ( TreeView treeView );
		private delegate TreeNodeCollection GetNodesTreeNodeDelegate ( TreeNode treeNode );
		private delegate int AddNodeDelegate ( TreeNodeCollection tnc, TreeNode tn );
		private delegate void GenericDelegate ( );

		public static TreeNodeCollection GetNodes ( this TreeView tv ) {
			try {
				if ( tv.InvokeRequired ) {
					TreeNodeCollection result = tv.Invoke ( new GetNodesDelegate ( delegate ( TreeView treeView ) {
						return treeView.Nodes;
					} ), tv ) as TreeNodeCollection;
					return result;
				} else {
					return tv.Nodes;
				}
			} catch ( Exception ex ) {
				return null;
			}
		}

		public static TreeNodeCollection GetNodes ( this TreeNode tn ) {
			TreeView tv = tn.TreeView;
			try {
				if ( tv != null && tv.InvokeRequired ) {
					TreeNodeCollection result = tv.Invoke ( new GetNodesTreeNodeDelegate ( delegate ( TreeNode treeNode ) {
						return treeNode.Nodes;
					} ), tn ) as TreeNodeCollection;
					return result;
				} else {
					return tn.Nodes;
				}
			} catch ( Exception ex ) {
				return null;
			}
		}

		public static int AddTreeNode ( this TreeNodeCollection tnc, TreeView treeView, TreeNode treeNode ) {
			try {
				if ( treeView.InvokeRequired ) {
					int result = (int)treeView.Invoke ( new AddNodeDelegate ( delegate ( TreeNodeCollection nodes, TreeNode node ) {
						return nodes.Add ( node );
					} ), tnc, treeNode );
					//treeView.Invoke ( new GenericDelegate ( treeNode.EnsureVisible ) );
					return result;
				} else {
					int result = tnc.Add ( treeNode );
					//treeNode.EnsureVisible ( );
					return result;
				}
			} catch ( Exception ex ) {
				return -1;
			}
		}

		public static int AddTreeNode ( this TreeNodeCollection tnc, TreeNode treeNode ) {
				return tnc.Add ( treeNode );
		}

		public static void ClearEx ( this TreeNodeCollection tnc, TreeView treeView ) {
			try {
				if ( treeView.InvokeRequired ) {
					treeView.Invoke ( new GenericDelegate ( tnc.Clear ) );
				} else {
					tnc.Clear ( );
				}
			} catch ( Exception ex ) {

			}
		}

	}
}
