using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace Regedit2.Components {
	public class EventTreeNode : TreeNode {

		public event EventHandler<TreeViewEventArgs> AfterCheck;
		public event EventHandler<TreeViewEventArgs> AfterCollapse;
		public event EventHandler<TreeViewEventArgs> AfterExpand;
		public event EventHandler<NodeLabelEditEventArgs> AfterLabelEdit;
		public event EventHandler<TreeViewEventArgs> AfterSelect;

		public event EventHandler<TreeViewCancelEventArgs> BeforeCheck;
		public event EventHandler<TreeViewCancelEventArgs> BeforeCollapse;
		public event EventHandler<TreeViewCancelEventArgs> BeforeExpand;
		public event EventHandler<NodeLabelEditEventArgs> BeforeLabelEdit;
		public event EventHandler<TreeViewCancelEventArgs> BeforeSelect;


		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="EventTreeNode"/> class.
		/// </summary>
		public EventTreeNode ( )
			: base ( ) {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EventTreeNode"/> class.
		/// </summary>
		/// <param name="text">The text.</param>
		public EventTreeNode ( string text )
			: base ( text ) {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EventTreeNode"/> class.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="children">The children.</param>
		public EventTreeNode ( string text, TreeNode[] children )
			: base ( text, children ) {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EventTreeNode"/> class.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="imageIndex">Index of the image.</param>
		/// <param name="selectedImageIndex">Index of the selected image.</param>
		public EventTreeNode ( string text, int imageIndex, int selectedImageIndex )
			: base ( text, imageIndex, selectedImageIndex ) {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EventTreeNode"/> class.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="imageIndex">Index of the image.</param>
		/// <param name="selectedImageIndex">Index of the selected image.</param>
		/// <param name="children">The children.</param>
		public EventTreeNode ( string text, int imageIndex, int selectedImageIndex, TreeNode[] children )
			: base ( text, imageIndex, selectedImageIndex, children ) {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EventTreeNode"/> class.
		/// </summary>
		/// <param name="serializationInfo">A <see cref="T:System.Runtime.Serialization.SerializationInfo"/> containing the data to deserialize the class.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> containing the source and destination of the serialized stream.</param>
		public EventTreeNode ( SerializationInfo serializationInfo, StreamingContext context )
			: base ( serializationInfo, context ) {

		}
		#endregion

		/// <summary>
		/// Raises the <see cref="E:AfterCheck"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
		public virtual void OnAfterCheck ( TreeViewEventArgs e ) {
			if ( this.AfterCheck != null ) {
				this.AfterCheck ( this, e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:AfterCollapse"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
		public virtual void OnAfterCollapse ( TreeViewEventArgs e ) {
			if ( this.AfterCollapse != null ) {
				this.AfterCollapse ( this, e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:AfterExpand"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
		public virtual void OnAfterExpand ( TreeViewEventArgs e ) {
			if ( this.AfterExpand != null ) {
				this.AfterExpand ( this, e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:AfterLabelEdit"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.Windows.Forms.NodeLabelEditEventArgs"/> instance containing the event data.</param>
		public virtual void OnAfterLabelEdit ( NodeLabelEditEventArgs e ) {
			if ( this.AfterLabelEdit != null ) {
				this.AfterLabelEdit ( this, e );
			}
		}

		/// <summary>
		/// Raises the <see cref="E:AfterSelect"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
		public virtual void OnAfterSelect ( TreeViewEventArgs e ) {
			if ( this.AfterSelect != null ) {
				this.AfterSelect ( this, e );
			}
		}

		public virtual void OnBeforeCheck ( TreeViewCancelEventArgs e ) {
			if ( this.BeforeCheck != null ) {
				this.BeforeCheck ( this, e );
			}
		}

		public virtual void OnBeforeCollapse ( TreeViewCancelEventArgs e ) {
			if ( this.BeforeCollapse != null ) {
				this.BeforeCollapse ( this, e );
			}
		}

		public virtual void OnBeforeExpand ( TreeViewCancelEventArgs e ) {
			if ( this.BeforeExpand != null ) {
				this.BeforeExpand ( this, e );
			}
		}

		public virtual void OnBeforeLabelEdit ( NodeLabelEditEventArgs e ) {
			if ( this.BeforeLabelEdit != null ) {
				this.BeforeLabelEdit ( this, e );
			}
		}

		public virtual void OnBeforeSelect ( TreeViewCancelEventArgs e ) {
			if ( this.BeforeSelect != null ) {
				this.BeforeSelect ( this, e );
			}
		}
	}
}
