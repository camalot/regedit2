namespace Regedit2 {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( ) {
			this.components = new System.ComponentModel.Container ( );
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager ( typeof ( MainForm ) );
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer ( );
			this.statusStrip1 = new System.Windows.Forms.StatusStrip ( );
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel ( );
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel ( );
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel ( );
			this.splitContainer1 = new System.Windows.Forms.SplitContainer ( );
			this.hive = new Regedit2.Components.TreeViewEx ( );
			this.values = new Regedit2.Components.ListViewEx ( );
			this.nameColumnHeader = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader ( ) ) );
			this.typeColumnHeader = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader ( ) ) );
			this.dataColumnHeader = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader ( ) ) );
			this.imageList = new System.Windows.Forms.ImageList ( this.components );
			this.menuStrip1 = new System.Windows.Forms.MenuStrip ( );
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
			this.favoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ( );
			this.toolStrip1 = new System.Windows.Forms.ToolStrip ( );
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton ( );
			this.toolStripContainer1.BottomToolStripPanel.SuspendLayout ( );
			this.toolStripContainer1.ContentPanel.SuspendLayout ( );
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout ( );
			this.toolStripContainer1.SuspendLayout ( );
			this.statusStrip1.SuspendLayout ( );
			( (System.ComponentModel.ISupportInitialize)( this.splitContainer1 ) ).BeginInit ( );
			this.splitContainer1.Panel1.SuspendLayout ( );
			this.splitContainer1.Panel2.SuspendLayout ( );
			this.splitContainer1.SuspendLayout ( );
			this.menuStrip1.SuspendLayout ( );
			this.toolStrip1.SuspendLayout ( );
			this.SuspendLayout ( );
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.BottomToolStripPanel
			// 
			this.toolStripContainer1.BottomToolStripPanel.Controls.Add ( this.statusStrip1 );
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add ( this.splitContainer1 );
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size ( 802, 424 );
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point ( 0, 0 );
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size ( 802, 497 );
			this.toolStripContainer1.TabIndex = 0;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add ( this.menuStrip1 );
			this.toolStripContainer1.TopToolStripPanel.Controls.Add ( this.toolStrip1 );
			// 
			// statusStrip1
			// 
			this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip1.Items.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1} );
			this.statusStrip1.Location = new System.Drawing.Point ( 0, 0 );
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size ( 802, 24 );
			this.statusStrip1.TabIndex = 0;
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size ( 599, 19 );
			this.statusLabel.Spring = true;
			this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.BorderSides = ( (System.Windows.Forms.ToolStripStatusLabelBorderSides)( ( ( ( System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top )
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right )
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom ) ) );
			this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.toolStripStatusLabel2.Image = global::Regedit2.Properties.Resources.Unavailable10;
			this.toolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripStatusLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size ( 107, 19 );
			this.toolStripStatusLabel2.Text = "No Write Access";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.BorderSides = ( (System.Windows.Forms.ToolStripStatusLabelBorderSides)( ( ( ( System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top )
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right )
									| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom ) ) );
			this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.toolStripStatusLabel1.Image = global::Regedit2.Properties.Resources.Disable10;
			this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripStatusLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding ( 0, 3, 2, 2 );
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding ( 3, 0, 0, 0 );
			this.toolStripStatusLabel1.Size = new System.Drawing.Size ( 79, 19 );
			this.toolStripStatusLabel1.Text = "No Access";
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point ( 0, 0 );
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add ( this.hive );
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add ( this.values );
			this.splitContainer1.Size = new System.Drawing.Size ( 802, 424 );
			this.splitContainer1.SplitterDistance = 255;
			this.splitContainer1.TabIndex = 0;
			// 
			// hive
			// 
			this.hive.BackColor = System.Drawing.SystemColors.Window;
			this.hive.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hive.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
			this.hive.ItemHeight = 20;
			this.hive.Location = new System.Drawing.Point ( 0, 0 );
			this.hive.Name = "hive";
			this.hive.Size = new System.Drawing.Size ( 255, 424 );
			this.hive.TabIndex = 1;
			// 
			// values
			// 
			this.values.Columns.AddRange ( new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.typeColumnHeader,
            this.dataColumnHeader} );
			this.values.ColumnsOrder = ( (System.Collections.Generic.Dictionary<string, int>)( resources.GetObject ( "values.ColumnsOrder" ) ) );
			this.values.Dock = System.Windows.Forms.DockStyle.Fill;
			this.values.FullRowSelect = true;
			this.values.Location = new System.Drawing.Point ( 0, 0 );
			this.values.MultiSelect = false;
			this.values.Name = "values";
			this.values.SelectedSortColumn = -1;
			this.values.Size = new System.Drawing.Size ( 543, 424 );
			this.values.SmallImageList = this.imageList;
			this.values.SortStyle = Regedit2.Components.ListViewEx.SortStyles.SortDefault;
			this.values.TabIndex = 0;
			this.values.UseCompatibleStateImageBehavior = false;
			this.values.View = System.Windows.Forms.View.Details;
			this.values.WatermarkImage = null;
			// 
			// nameColumnHeader
			// 
			this.nameColumnHeader.Text = "Name";
			this.nameColumnHeader.Width = 172;
			// 
			// typeColumnHeader
			// 
			this.typeColumnHeader.Text = "Type";
			this.typeColumnHeader.Width = 144;
			// 
			// dataColumnHeader
			// 
			this.dataColumnHeader.Text = "Data";
			this.dataColumnHeader.Width = 198;
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList.ImageSize = new System.Drawing.Size ( 16, 16 );
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Items.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.favoritesToolStripMenuItem,
            this.helpToolStripMenuItem} );
			this.menuStrip1.Location = new System.Drawing.Point ( 0, 0 );
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size ( 802, 24 );
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size ( 37, 20 );
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size ( 39, 20 );
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size ( 44, 20 );
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// favoritesToolStripMenuItem
			// 
			this.favoritesToolStripMenuItem.Name = "favoritesToolStripMenuItem";
			this.favoritesToolStripMenuItem.Size = new System.Drawing.Size ( 66, 20 );
			this.favoritesToolStripMenuItem.Text = "F&avorites";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size ( 44, 20 );
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange ( new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton} );
			this.toolStrip1.Location = new System.Drawing.Point ( 3, 24 );
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size ( 35, 25 );
			this.toolStrip1.TabIndex = 1;
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ( (System.Drawing.Image)( resources.GetObject ( "saveToolStripButton.Image" ) ) );
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size ( 23, 22 );
			this.saveToolStripButton.Text = "Save";
			this.saveToolStripButton.Click += new System.EventHandler ( this.saveToolStripButton_Click );
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size ( 802, 497 );
			this.Controls.Add ( this.toolStripContainer1 );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject ( "$this.Icon" ) ) );
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Registry Editor 2";
			this.toolStripContainer1.BottomToolStripPanel.ResumeLayout ( false );
			this.toolStripContainer1.BottomToolStripPanel.PerformLayout ( );
			this.toolStripContainer1.ContentPanel.ResumeLayout ( false );
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout ( false );
			this.toolStripContainer1.TopToolStripPanel.PerformLayout ( );
			this.toolStripContainer1.ResumeLayout ( false );
			this.toolStripContainer1.PerformLayout ( );
			this.statusStrip1.ResumeLayout ( false );
			this.statusStrip1.PerformLayout ( );
			this.splitContainer1.Panel1.ResumeLayout ( false );
			this.splitContainer1.Panel2.ResumeLayout ( false );
			( (System.ComponentModel.ISupportInitialize)( this.splitContainer1 ) ).EndInit ( );
			this.splitContainer1.ResumeLayout ( false );
			this.menuStrip1.ResumeLayout ( false );
			this.menuStrip1.PerformLayout ( );
			this.toolStrip1.ResumeLayout ( false );
			this.toolStrip1.PerformLayout ( );
			this.ResumeLayout ( false );

		}

		#endregion

		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem favoritesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private Regedit2.Components.ListViewEx values;
		private System.Windows.Forms.ColumnHeader nameColumnHeader;
		private System.Windows.Forms.ColumnHeader typeColumnHeader;
		private System.Windows.Forms.ColumnHeader dataColumnHeader;
		private Regedit2.Components.TreeViewEx hive;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
	}
}

