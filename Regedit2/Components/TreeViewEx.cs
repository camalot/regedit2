using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Regedit2.Components {
	/// <summary>
	/// A double buffered treeview
	/// </summary>
	public class TreeViewEx : TreeView {
		/// <summary>
		/// Initializes a new instance of the <see cref="TreeViewEx"/> class.
		/// </summary>
		public TreeViewEx ( )
			: base ( ) {
			this.SetStyle ( ControlStyles.OptimizedDoubleBuffer, true );
			this.DrawMode = TreeViewDrawMode.OwnerDrawText;
			this.SetVistaExplorerStyle ( false );
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.TreeView.AfterCheck"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.TreeViewEventArgs"/> that contains the event data.</param>
		protected override void OnAfterCheck ( TreeViewEventArgs e ) {
			base.OnAfterCheck ( e );
			if ( e.Node is EventTreeNode ) {
				( e.Node as EventTreeNode ).OnAfterCheck ( e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.TreeView.AfterCollapse"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.TreeViewEventArgs"/> that contains the event data.</param>
		protected override void OnAfterCollapse ( TreeViewEventArgs e ) {
			base.OnAfterCollapse ( e );
			if ( e.Node is EventTreeNode ) {
				( e.Node as EventTreeNode ).OnAfterCollapse ( e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.TreeView.AfterExpand"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.TreeViewEventArgs"/> that contains the event data.</param>
		protected override void OnAfterExpand ( TreeViewEventArgs e ) {
			base.OnAfterExpand ( e );
			if ( e.Node is EventTreeNode ) {
				( e.Node as EventTreeNode ).OnAfterExpand ( e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.TreeView.AfterLabelEdit"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.NodeLabelEditEventArgs"/> that contains the event data.</param>
		protected override void OnAfterLabelEdit ( NodeLabelEditEventArgs e ) {
			base.OnAfterLabelEdit ( e );
			if ( e.Node is EventTreeNode ) {
				( e.Node as EventTreeNode ).OnAfterLabelEdit ( e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.TreeView.AfterSelect"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.TreeViewEventArgs"/> that contains the event data.</param>
		protected override void OnAfterSelect ( TreeViewEventArgs e ) {
			base.OnAfterSelect ( e );
			if ( e.Node is EventTreeNode ) {
				( e.Node as EventTreeNode ).OnAfterSelect ( e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.TreeView.BeforeCheck"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.TreeViewCancelEventArgs"/> that contains the event data.</param>
		protected override void OnBeforeCheck ( TreeViewCancelEventArgs e ) {
			base.OnBeforeCheck ( e );
			if ( e.Node is EventTreeNode ) {
				( e.Node as EventTreeNode ).OnBeforeCheck ( e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.TreeView.BeforeCollapse"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.TreeViewCancelEventArgs"/> that contains the event data.</param>
		protected override void OnBeforeCollapse ( TreeViewCancelEventArgs e ) {
			base.OnBeforeCollapse ( e );
			if ( e.Node is EventTreeNode ) {
				( e.Node as EventTreeNode ).OnBeforeCollapse ( e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.TreeView.BeforeExpand"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.TreeViewCancelEventArgs"/> that contains the event data.</param>
		protected override void OnBeforeExpand ( TreeViewCancelEventArgs e ) {
			base.OnBeforeExpand ( e );
			if ( e.Node is EventTreeNode ) {
				( e.Node as EventTreeNode ).OnBeforeExpand ( e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.TreeView.BeforeLabelEdit"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.NodeLabelEditEventArgs"/> that contains the event data.</param>
		protected override void OnBeforeLabelEdit ( NodeLabelEditEventArgs e ) {
			base.OnBeforeLabelEdit ( e );
			if ( e.Node is EventTreeNode ) {
				( e.Node as EventTreeNode ).OnBeforeLabelEdit ( e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.TreeView.BeforeSelect"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.TreeViewCancelEventArgs"/> that contains the event data.</param>
		protected override void OnBeforeSelect ( TreeViewCancelEventArgs e ) {
			base.OnBeforeSelect ( e );
			if ( e.Node is EventTreeNode ) {
				( e.Node as EventTreeNode ).OnBeforeSelect ( e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.TreeView.DrawNode"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DrawTreeNodeEventArgs"/> that contains the event data.</param>
		protected override void OnDrawNode ( DrawTreeNodeEventArgs e ) {
			Image overlayImage = GetOverlayImage ( e.Node );
			// you have to move the X value left a bit, 
			// otherwise it will draw over your node text
			// I'm also adjusting to move the overlay down a bit
			if ( overlayImage != null ) {
				e.Graphics.DrawImage ( overlayImage,
						e.Node.Bounds.X - 11, e.Node.Bounds.Y + 9 );
			}
			//e.DrawDefault = ( e.State & TreeNodeStates.Default ) == 0 && ( e.State & TreeNodeStates.Focused ) == 0 && ( e.State & TreeNodeStates.Hot ) == 0 && ( e.State & TreeNodeStates.Selected ) == 0;
			bool explorerState = ( e.State & TreeNodeStates.Focused ) != 0 || ( e.State & TreeNodeStates.Hot ) != 0|| ( e.State & TreeNodeStates.Selected ) != 0;
			e.DrawDefault = false;

			if ( !explorerState ) {
				using ( var brush = new SolidBrush ( SystemColors.WindowText ) ) {
					e.Graphics.DrawString ( e.Node.Text, this.Font, brush, e.Node.Bounds.X, e.Node.Bounds.Y + 3 );
				}
			}
			base.OnDrawNode ( e );
		
		}

		/// <summary>
		/// Gets the overlay image.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns></returns>
		private Image GetOverlayImage ( TreeNode node ) {
			if ( node != null && node is RegistryKeyTreeNode ) {
				if ( !( node as RegistryKeyTreeNode ).CanWrite && !(node as RegistryKeyTreeNode).CanRead ) {
					return Properties.Resources.Disable10;
				} else if ( !( node as RegistryKeyTreeNode ).CanWrite || !( node as RegistryKeyTreeNode ).CanRead ) {
					return Properties.Resources.Unavailable10;
				}
			} else if ( node != null && node is RootTreeNode ) {
				if ( !( node as RootTreeNode ).HasAccess ) {
					return Properties.Resources.Disable10;
				}
			}

			return null;
		}
	}
}
