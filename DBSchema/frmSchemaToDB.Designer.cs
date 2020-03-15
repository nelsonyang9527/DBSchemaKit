namespace DBSchema
{
    partial class frmSchemaToDB
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnGenerator = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnLinkFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.gboxGenerator = new System.Windows.Forms.GroupBox();
            this.cobSelectMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gboxResults = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.gboxTableList = new System.Windows.Forms.GroupBox();
            this.cbxAllTable = new System.Windows.Forms.CheckBox();
            this.dgvTableSchema = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.gboxGenerator.SuspendLayout();
            this.gboxResults.SuspendLayout();
            this.gboxTableList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableSchema)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "檔案路徑:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtFilePath.Location = new System.Drawing.Point(89, 29);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(177, 23);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnGenerator
            // 
            this.btnGenerator.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnGenerator.Image = global::DBSchemaKit.Properties.Resources.script;
            this.btnGenerator.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGenerator.Location = new System.Drawing.Point(660, 22);
            this.btnGenerator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerator.Name = "btnGenerator";
            this.btnGenerator.Size = new System.Drawing.Size(84, 62);
            this.btnGenerator.TabIndex = 3;
            this.btnGenerator.Text = "一鍵產生";
            this.btnGenerator.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerator.UseVisualStyleBackColor = true;
            this.btnGenerator.Click += new System.EventHandler(this.btnGenerator_Click);
            // 
            // txtResults
            // 
            this.txtResults.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtResults.Location = new System.Drawing.Point(12, 37);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(732, 390);
            this.txtResults.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectFile);
            this.groupBox1.Controls.Add(this.btnLinkFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDBName);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 93);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DB Schema 連結資訊";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSelectFile.Location = new System.Drawing.Point(272, 28);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(74, 24);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "選擇檔案";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnLinkFile
            // 
            this.btnLinkFile.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLinkFile.Location = new System.Drawing.Point(272, 62);
            this.btnLinkFile.Name = "btnLinkFile";
            this.btnLinkFile.Size = new System.Drawing.Size(74, 24);
            this.btnLinkFile.TabIndex = 2;
            this.btnLinkFile.Text = "連結檔案";
            this.btnLinkFile.UseVisualStyleBackColor = true;
            this.btnLinkFile.Click += new System.EventHandler(this.btnLinkFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(11, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "資料庫名稱:";
            // 
            // txtDBName
            // 
            this.txtDBName.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDBName.Location = new System.Drawing.Point(89, 61);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(177, 23);
            this.txtDBName.TabIndex = 1;
            // 
            // gboxGenerator
            // 
            this.gboxGenerator.Controls.Add(this.cobSelectMode);
            this.gboxGenerator.Controls.Add(this.btnGenerator);
            this.gboxGenerator.Controls.Add(this.label4);
            this.gboxGenerator.Controls.Add(this.label3);
            this.gboxGenerator.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gboxGenerator.Location = new System.Drawing.Point(376, 12);
            this.gboxGenerator.Name = "gboxGenerator";
            this.gboxGenerator.Size = new System.Drawing.Size(756, 93);
            this.gboxGenerator.TabIndex = 4;
            this.gboxGenerator.TabStop = false;
            this.gboxGenerator.Text = "資料表建置 SQL Script 語法";
            // 
            // cobSelectMode
            // 
            this.cobSelectMode.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cobSelectMode.FormattingEnabled = true;
            this.cobSelectMode.ItemHeight = 17;
            this.cobSelectMode.Location = new System.Drawing.Point(100, 26);
            this.cobSelectMode.Name = "cobSelectMode";
            this.cobSelectMode.Size = new System.Drawing.Size(552, 25);
            this.cobSelectMode.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(21, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(554, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "注意事項: 本程式只協助產生Create Table, 資料表與欄位描述, 主鍵值設定, 不包含外鍵關聯設定.\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(21, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "資料庫類型:";
            // 
            // gboxResults
            // 
            this.gboxResults.Controls.Add(this.btnCopy);
            this.gboxResults.Controls.Add(this.txtResults);
            this.gboxResults.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gboxResults.Location = new System.Drawing.Point(376, 111);
            this.gboxResults.Name = "gboxResults";
            this.gboxResults.Size = new System.Drawing.Size(756, 440);
            this.gboxResults.TabIndex = 4;
            this.gboxResults.TabStop = false;
            this.gboxResults.Text = "產生結果";
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCopy.Location = new System.Drawing.Point(648, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(98, 25);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "複製至剪貼簿";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // gboxTableList
            // 
            this.gboxTableList.Controls.Add(this.cbxAllTable);
            this.gboxTableList.Controls.Add(this.dgvTableSchema);
            this.gboxTableList.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gboxTableList.Location = new System.Drawing.Point(12, 111);
            this.gboxTableList.Name = "gboxTableList";
            this.gboxTableList.Size = new System.Drawing.Size(358, 440);
            this.gboxTableList.TabIndex = 5;
            this.gboxTableList.TabStop = false;
            this.gboxTableList.Text = "資料表清單";
            // 
            // cbxAllTable
            // 
            this.cbxAllTable.AutoSize = true;
            this.cbxAllTable.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxAllTable.Location = new System.Drawing.Point(292, 15);
            this.cbxAllTable.Name = "cbxAllTable";
            this.cbxAllTable.Size = new System.Drawing.Size(53, 21);
            this.cbxAllTable.TabIndex = 1;
            this.cbxAllTable.Text = "全選";
            this.cbxAllTable.UseVisualStyleBackColor = true;
            this.cbxAllTable.CheckedChanged += new System.EventHandler(this.cbxAllTable_CheckedChanged);
            // 
            // dgvTableSchema
            // 
            this.dgvTableSchema.AllowUserToAddRows = false;
            this.dgvTableSchema.AllowUserToDeleteRows = false;
            this.dgvTableSchema.AllowUserToOrderColumns = true;
            this.dgvTableSchema.AllowUserToResizeRows = false;
            this.dgvTableSchema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableSchema.Location = new System.Drawing.Point(12, 37);
            this.dgvTableSchema.Name = "dgvTableSchema";
            this.dgvTableSchema.RowHeadersVisible = false;
            this.dgvTableSchema.RowTemplate.Height = 24;
            this.dgvTableSchema.Size = new System.Drawing.Size(332, 391);
            this.dgvTableSchema.TabIndex = 0;
            // 
            // frmSchemaToDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 555);
            this.ControlBox = false;
            this.Controls.Add(this.gboxTableList);
            this.Controls.Add(this.gboxResults);
            this.Controls.Add(this.gboxGenerator);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSchemaToDB";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxGenerator.ResumeLayout(false);
            this.gboxGenerator.PerformLayout();
            this.gboxResults.ResumeLayout(false);
            this.gboxResults.PerformLayout();
            this.gboxTableList.ResumeLayout(false);
            this.gboxTableList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableSchema)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnGenerator;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLinkFile;
        private System.Windows.Forms.GroupBox gboxGenerator;
        private System.Windows.Forms.ComboBox cobSelectMode;
        private System.Windows.Forms.GroupBox gboxResults;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.GroupBox gboxTableList;
        private System.Windows.Forms.DataGridView dgvTableSchema;
        private System.Windows.Forms.CheckBox cbxAllTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}