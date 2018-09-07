namespace StringerExpress.Forms
{
    partial class ItemViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemViewer));
            this.itemView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.çalıştırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.favorilereEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favorilerdenÇıkarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemView
            // 
            this.itemView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.Type});
            this.itemView.ContextMenuStrip = this.contextMenuStrip1;
            this.itemView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemView.FullRowSelect = true;
            this.itemView.Location = new System.Drawing.Point(0, 20);
            this.itemView.Name = "itemView";
            this.itemView.Size = new System.Drawing.Size(433, 236);
            this.itemView.TabIndex = 0;
            this.itemView.UseCompatibleStateImageBehavior = false;
            this.itemView.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "İsim";
            this.name.Width = 344;
            // 
            // Type
            // 
            this.Type.Text = "Tip";
            this.Type.Width = 74;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çalıştırToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.silToolStripMenuItem,
            this.toolStripSeparator1,
            this.favorilereEkleToolStripMenuItem,
            this.favorilerdenÇıkarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 120);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // çalıştırToolStripMenuItem
            // 
            this.çalıştırToolStripMenuItem.Name = "çalıştırToolStripMenuItem";
            this.çalıştırToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.çalıştırToolStripMenuItem.Text = "Çalıştır";
            this.çalıştırToolStripMenuItem.Click += new System.EventHandler(this.çalıştırToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // favorilereEkleToolStripMenuItem
            // 
            this.favorilereEkleToolStripMenuItem.Name = "favorilereEkleToolStripMenuItem";
            this.favorilereEkleToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.favorilereEkleToolStripMenuItem.Text = "Favorilere ekle";
            this.favorilereEkleToolStripMenuItem.Click += new System.EventHandler(this.favorilereEkleToolStripMenuItem_Click);
            // 
            // favorilerdenÇıkarToolStripMenuItem
            // 
            this.favorilerdenÇıkarToolStripMenuItem.Name = "favorilerdenÇıkarToolStripMenuItem";
            this.favorilerdenÇıkarToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.favorilerdenÇıkarToolStripMenuItem.Text = "Favorilerden çıkar";
            this.favorilerdenÇıkarToolStripMenuItem.Click += new System.EventHandler(this.favorilerdenÇıkarToolStripMenuItem_Click);
            // 
            // searchBox
            // 
            this.searchBox.AccessibleName = "";
            this.searchBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchBox.Location = new System.Drawing.Point(0, 0);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(433, 20);
            this.searchBox.TabIndex = 1;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // ItemViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 256);
            this.Controls.Add(this.itemView);
            this.Controls.Add(this.searchBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stringer 1.0 Kayıt Listesi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemViewer_FormClosing);
            this.Load += new System.EventHandler(this.ItemViewer_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.TextBox searchBox;
        public System.Windows.Forms.ListView itemView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem çalıştırToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem favorilereEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favorilerdenÇıkarToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Type;
    }
}