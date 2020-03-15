namespace DBSchema
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDBToSchema = new System.Windows.Forms.ToolStripButton();
            this.btnSchemaToDB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.btnDBToSchema,
            this.btnSchemaToDB,
            this.toolStripSeparator1,
            this.btnAbout});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(81, 572);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "功能選單";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.toolStripLabel1.Size = new System.Drawing.Size(78, 29);
            this.toolStripLabel1.Text = "功能選單";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(78, 6);
            // 
            // btnDBToSchema
            // 
            this.btnDBToSchema.Image = global::DBSchemaKit.Properties.Resources.Excel;
            this.btnDBToSchema.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDBToSchema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDBToSchema.Name = "btnDBToSchema";
            this.btnDBToSchema.Size = new System.Drawing.Size(78, 51);
            this.btnDBToSchema.Text = "匯出Schema";
            this.btnDBToSchema.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDBToSchema.Click += new System.EventHandler(this.btnDBToSchema_Click);
            // 
            // btnSchemaToDB
            // 
            this.btnSchemaToDB.Image = global::DBSchemaKit.Properties.Resources.Database;
            this.btnSchemaToDB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSchemaToDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSchemaToDB.Name = "btnSchemaToDB";
            this.btnSchemaToDB.Size = new System.Drawing.Size(78, 51);
            this.btnSchemaToDB.Text = "匯入Schema";
            this.btnSchemaToDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSchemaToDB.Click += new System.EventHandler(this.btnSchemaToDB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(78, 6);
            // 
            // btnAbout
            // 
            this.btnAbout.Image = global::DBSchemaKit.Properties.Resources.Info;
            this.btnAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(78, 51);
            this.btnAbout.Text = "關於軟體";
            this.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 572);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB Schema Kit";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnDBToSchema;
        private System.Windows.Forms.ToolStripButton btnSchemaToDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAbout;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStrip toolStrip;
    }
}