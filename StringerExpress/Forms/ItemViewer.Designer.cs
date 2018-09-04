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
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Favoriler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Tümü", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemViewer));
            this.itemView = new System.Windows.Forms.ListView();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.Isim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // itemView
            // 
            this.itemView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Isim});
            this.itemView.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup5.Header = "Favoriler";
            listViewGroup5.Name = "Favoriler";
            listViewGroup6.Header = "Tümü";
            listViewGroup6.Name = "Tümü";
            this.itemView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5,
            listViewGroup6});
            this.itemView.Location = new System.Drawing.Point(0, 20);
            this.itemView.Name = "itemView";
            this.itemView.Size = new System.Drawing.Size(433, 236);
            this.itemView.TabIndex = 0;
            this.itemView.UseCompatibleStateImageBehavior = false;
            this.itemView.View = System.Windows.Forms.View.Details;
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
            // Isim
            // 
            this.Isim.Text = "İsim";
            this.Isim.Width = 409;
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
            this.Text = "Stringer Kayıt Listesi";
            this.Load += new System.EventHandler(this.ItemViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader Isim;
        private System.Windows.Forms.TextBox searchBox;
        public System.Windows.Forms.ListView itemView;
    }
}