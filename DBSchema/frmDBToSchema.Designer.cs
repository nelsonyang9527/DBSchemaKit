namespace DBSchema
{
    partial class frmDBToSchema
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBToSchema));
            this.DBSetting = new System.Windows.Forms.GroupBox();
            this.BreakButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DatabaseCombo = new System.Windows.Forms.ComboBox();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.AccountText = new System.Windows.Forms.TextBox();
            this.ServerText = new System.Windows.Forms.TextBox();
            this.DatabaseLab = new System.Windows.Forms.Label();
            this.PasswordLab = new System.Windows.Forms.Label();
            this.AccountLab = new System.Windows.Forms.Label();
            this.ServerLab = new System.Windows.Forms.Label();
            this.DBExport = new System.Windows.Forms.GroupBox();
            this.TableDescribeButton = new System.Windows.Forms.Button();
            this.DBTab = new System.Windows.Forms.TabControl();
            this.Table = new System.Windows.Forms.TabPage();
            this.TableList = new System.Windows.Forms.DataGridView();
            this.StoredProcedure = new System.Windows.Forms.TabPage();
            this.SPList = new System.Windows.Forms.DataGridView();
            this.View = new System.Windows.Forms.TabPage();
            this.ViewList = new System.Windows.Forms.DataGridView();
            this.FieldsDescribeButton = new System.Windows.Forms.Button();
            this.DBFields = new System.Windows.Forms.GroupBox();
            this.FieldsDataGridView = new System.Windows.Forms.DataGridView();
            this.SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChineseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowNull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Default = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Explain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.GroupBox();
            this.DescriptionText = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.DocumentNameText = new System.Windows.Forms.TextBox();
            this.DocumentNameLab = new System.Windows.Forms.Label();
            this.FillingText = new System.Windows.Forms.TextBox();
            this.DescriptionLab = new System.Windows.Forms.Label();
            this.FillingLab = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DBSetting.SuspendLayout();
            this.DBExport.SuspendLayout();
            this.DBTab.SuspendLayout();
            this.Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableList)).BeginInit();
            this.StoredProcedure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPList)).BeginInit();
            this.View.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewList)).BeginInit();
            this.DBFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FieldsDataGridView)).BeginInit();
            this.Information.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DBSetting
            // 
            this.DBSetting.Controls.Add(this.BreakButton);
            this.DBSetting.Controls.Add(this.ConnectButton);
            this.DBSetting.Controls.Add(this.DatabaseCombo);
            this.DBSetting.Controls.Add(this.PasswordText);
            this.DBSetting.Controls.Add(this.AccountText);
            this.DBSetting.Controls.Add(this.ServerText);
            this.DBSetting.Controls.Add(this.DatabaseLab);
            this.DBSetting.Controls.Add(this.PasswordLab);
            this.DBSetting.Controls.Add(this.AccountLab);
            this.DBSetting.Controls.Add(this.ServerLab);
            this.DBSetting.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DBSetting.Location = new System.Drawing.Point(11, 13);
            this.DBSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DBSetting.Name = "DBSetting";
            this.DBSetting.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DBSetting.Size = new System.Drawing.Size(342, 153);
            this.DBSetting.TabIndex = 0;
            this.DBSetting.TabStop = false;
            this.DBSetting.Text = "資料庫連線設定";
            // 
            // BreakButton
            // 
            this.BreakButton.Location = new System.Drawing.Point(256, 71);
            this.BreakButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BreakButton.Name = "BreakButton";
            this.BreakButton.Size = new System.Drawing.Size(76, 42);
            this.BreakButton.TabIndex = 10;
            this.BreakButton.Text = "斷線";
            this.BreakButton.UseVisualStyleBackColor = true;
            this.BreakButton.Click += new System.EventHandler(this.BreakButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(256, 27);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(76, 41);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "連線";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DatabaseCombo
            // 
            this.DatabaseCombo.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DatabaseCombo.FormattingEnabled = true;
            this.DatabaseCombo.Location = new System.Drawing.Point(65, 119);
            this.DatabaseCombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DatabaseCombo.Name = "DatabaseCombo";
            this.DatabaseCombo.Size = new System.Drawing.Size(267, 25);
            this.DatabaseCombo.TabIndex = 5;
            this.DatabaseCombo.SelectedIndexChanged += new System.EventHandler(this.DatabaseCombo_SelectedIndexChanged);
            // 
            // PasswordText
            // 
            this.PasswordText.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PasswordText.Location = new System.Drawing.Point(65, 88);
            this.PasswordText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(184, 25);
            this.PasswordText.TabIndex = 3;
            // 
            // AccountText
            // 
            this.AccountText.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AccountText.Location = new System.Drawing.Point(65, 56);
            this.AccountText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AccountText.Name = "AccountText";
            this.AccountText.Size = new System.Drawing.Size(184, 25);
            this.AccountText.TabIndex = 2;
            // 
            // ServerText
            // 
            this.ServerText.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ServerText.Location = new System.Drawing.Point(65, 27);
            this.ServerText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ServerText.Name = "ServerText";
            this.ServerText.Size = new System.Drawing.Size(184, 25);
            this.ServerText.TabIndex = 1;
            // 
            // DatabaseLab
            // 
            this.DatabaseLab.AutoSize = true;
            this.DatabaseLab.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DatabaseLab.Location = new System.Drawing.Point(11, 122);
            this.DatabaseLab.Name = "DatabaseLab";
            this.DatabaseLab.Size = new System.Drawing.Size(50, 17);
            this.DatabaseLab.TabIndex = 0;
            this.DatabaseLab.Text = "資料庫:";
            // 
            // PasswordLab
            // 
            this.PasswordLab.AutoSize = true;
            this.PasswordLab.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PasswordLab.Location = new System.Drawing.Point(23, 93);
            this.PasswordLab.Name = "PasswordLab";
            this.PasswordLab.Size = new System.Drawing.Size(37, 17);
            this.PasswordLab.TabIndex = 0;
            this.PasswordLab.Text = "密碼:";
            // 
            // AccountLab
            // 
            this.AccountLab.AutoSize = true;
            this.AccountLab.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AccountLab.Location = new System.Drawing.Point(23, 61);
            this.AccountLab.Name = "AccountLab";
            this.AccountLab.Size = new System.Drawing.Size(37, 17);
            this.AccountLab.TabIndex = 0;
            this.AccountLab.Text = "帳號:";
            // 
            // ServerLab
            // 
            this.ServerLab.AutoSize = true;
            this.ServerLab.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ServerLab.Location = new System.Drawing.Point(11, 31);
            this.ServerLab.Name = "ServerLab";
            this.ServerLab.Size = new System.Drawing.Size(50, 17);
            this.ServerLab.TabIndex = 0;
            this.ServerLab.Text = "伺服器:";
            // 
            // DBExport
            // 
            this.DBExport.Controls.Add(this.TableDescribeButton);
            this.DBExport.Controls.Add(this.DBTab);
            this.DBExport.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DBExport.Location = new System.Drawing.Point(11, 171);
            this.DBExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DBExport.Name = "DBExport";
            this.DBExport.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DBExport.Size = new System.Drawing.Size(342, 360);
            this.DBExport.TabIndex = 0;
            this.DBExport.TabStop = false;
            this.DBExport.Text = "資料表資訊";
            // 
            // TableDescribeButton
            // 
            this.TableDescribeButton.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TableDescribeButton.Location = new System.Drawing.Point(212, 13);
            this.TableDescribeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TableDescribeButton.Name = "TableDescribeButton";
            this.TableDescribeButton.Size = new System.Drawing.Size(120, 27);
            this.TableDescribeButton.TabIndex = 2;
            this.TableDescribeButton.Text = "更新資料表描述";
            this.TableDescribeButton.UseVisualStyleBackColor = true;
            this.TableDescribeButton.Click += new System.EventHandler(this.TableDescribeButton_Click);
            // 
            // DBTab
            // 
            this.DBTab.Controls.Add(this.Table);
            this.DBTab.Controls.Add(this.StoredProcedure);
            this.DBTab.Controls.Add(this.View);
            this.DBTab.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DBTab.Location = new System.Drawing.Point(12, 37);
            this.DBTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DBTab.Name = "DBTab";
            this.DBTab.SelectedIndex = 0;
            this.DBTab.Size = new System.Drawing.Size(321, 315);
            this.DBTab.TabIndex = 4;
            // 
            // Table
            // 
            this.Table.Controls.Add(this.TableList);
            this.Table.Location = new System.Drawing.Point(4, 26);
            this.Table.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Table.Name = "Table";
            this.Table.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Table.Size = new System.Drawing.Size(313, 285);
            this.Table.TabIndex = 0;
            this.Table.Text = "資料表";
            this.Table.UseVisualStyleBackColor = true;
            // 
            // TableList
            // 
            this.TableList.AllowUserToAddRows = false;
            this.TableList.AllowUserToDeleteRows = false;
            this.TableList.AllowUserToOrderColumns = true;
            this.TableList.AllowUserToResizeRows = false;
            this.TableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableList.Location = new System.Drawing.Point(0, 0);
            this.TableList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TableList.Name = "TableList";
            this.TableList.RowHeadersVisible = false;
            this.TableList.RowTemplate.Height = 24;
            this.TableList.Size = new System.Drawing.Size(317, 289);
            this.TableList.TabIndex = 1;
            this.TableList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableList_CellContentClick);
            // 
            // StoredProcedure
            // 
            this.StoredProcedure.Controls.Add(this.SPList);
            this.StoredProcedure.Location = new System.Drawing.Point(4, 26);
            this.StoredProcedure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StoredProcedure.Name = "StoredProcedure";
            this.StoredProcedure.Size = new System.Drawing.Size(313, 285);
            this.StoredProcedure.TabIndex = 3;
            this.StoredProcedure.Text = "預存程式";
            this.StoredProcedure.UseVisualStyleBackColor = true;
            // 
            // SPList
            // 
            this.SPList.AllowUserToAddRows = false;
            this.SPList.AllowUserToDeleteRows = false;
            this.SPList.AllowUserToResizeRows = false;
            this.SPList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SPList.Location = new System.Drawing.Point(0, 0);
            this.SPList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SPList.Name = "SPList";
            this.SPList.RowHeadersVisible = false;
            this.SPList.RowTemplate.Height = 24;
            this.SPList.Size = new System.Drawing.Size(313, 285);
            this.SPList.TabIndex = 2;
            // 
            // View
            // 
            this.View.Controls.Add(this.ViewList);
            this.View.Location = new System.Drawing.Point(4, 26);
            this.View.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.View.Name = "View";
            this.View.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.View.Size = new System.Drawing.Size(313, 285);
            this.View.TabIndex = 1;
            this.View.Text = "檢視";
            this.View.UseVisualStyleBackColor = true;
            // 
            // ViewList
            // 
            this.ViewList.AllowUserToAddRows = false;
            this.ViewList.AllowUserToDeleteRows = false;
            this.ViewList.AllowUserToResizeRows = false;
            this.ViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewList.Location = new System.Drawing.Point(1, 1);
            this.ViewList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ViewList.Name = "ViewList";
            this.ViewList.RowHeadersVisible = false;
            this.ViewList.RowTemplate.Height = 24;
            this.ViewList.Size = new System.Drawing.Size(312, 284);
            this.ViewList.TabIndex = 5;
            // 
            // FieldsDescribeButton
            // 
            this.FieldsDescribeButton.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FieldsDescribeButton.Location = new System.Drawing.Point(631, 12);
            this.FieldsDescribeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FieldsDescribeButton.Name = "FieldsDescribeButton";
            this.FieldsDescribeButton.Size = new System.Drawing.Size(129, 25);
            this.FieldsDescribeButton.TabIndex = 2;
            this.FieldsDescribeButton.Text = "更新資料欄位描述";
            this.FieldsDescribeButton.UseVisualStyleBackColor = true;
            this.FieldsDescribeButton.Click += new System.EventHandler(this.FieldsDescribeButton_Click);
            // 
            // DBFields
            // 
            this.DBFields.Controls.Add(this.FieldsDescribeButton);
            this.DBFields.Controls.Add(this.FieldsDataGridView);
            this.DBFields.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DBFields.Location = new System.Drawing.Point(365, 110);
            this.DBFields.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DBFields.Name = "DBFields";
            this.DBFields.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DBFields.Size = new System.Drawing.Size(769, 421);
            this.DBFields.TabIndex = 3;
            this.DBFields.TabStop = false;
            this.DBFields.Text = "資料表欄位資訊";
            // 
            // FieldsDataGridView
            // 
            this.FieldsDataGridView.AllowUserToAddRows = false;
            this.FieldsDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FieldsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FieldsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FieldsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SN,
            this.FieldName,
            this.Type,
            this.Length,
            this.ChineseName,
            this.AllowNull,
            this.Identity,
            this.Default,
            this.Explain,
            this.Note});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FieldsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.FieldsDataGridView.Location = new System.Drawing.Point(12, 37);
            this.FieldsDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FieldsDataGridView.Name = "FieldsDataGridView";
            this.FieldsDataGridView.RowHeadersVisible = false;
            this.FieldsDataGridView.RowTemplate.Height = 24;
            this.FieldsDataGridView.Size = new System.Drawing.Size(748, 376);
            this.FieldsDataGridView.TabIndex = 1;
            // 
            // SN
            // 
            this.SN.HeaderText = "欄位名稱";
            this.SN.Name = "SN";
            this.SN.ReadOnly = true;
            // 
            // FieldName
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkGreen;
            this.FieldName.DefaultCellStyle = dataGridViewCellStyle2;
            this.FieldName.HeaderText = "中文名稱";
            this.FieldName.Name = "FieldName";
            // 
            // Type
            // 
            this.Type.FillWeight = 80F;
            this.Type.HeaderText = "型態";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 80;
            // 
            // Length
            // 
            this.Length.FillWeight = 60F;
            this.Length.HeaderText = "長度";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            this.Length.Width = 60;
            // 
            // ChineseName
            // 
            this.ChineseName.FillWeight = 45F;
            this.ChineseName.HeaderText = "鍵值";
            this.ChineseName.Name = "ChineseName";
            this.ChineseName.ReadOnly = true;
            this.ChineseName.Width = 45;
            // 
            // AllowNull
            // 
            this.AllowNull.FillWeight = 45F;
            this.AllowNull.HeaderText = "空值";
            this.AllowNull.Name = "AllowNull";
            this.AllowNull.ReadOnly = true;
            this.AllowNull.Width = 45;
            // 
            // Identity
            // 
            this.Identity.FillWeight = 65F;
            this.Identity.HeaderText = "Identity";
            this.Identity.Name = "Identity";
            this.Identity.ReadOnly = true;
            this.Identity.Width = 65;
            // 
            // Default
            // 
            this.Default.FillWeight = 80F;
            this.Default.HeaderText = "預設值";
            this.Default.Name = "Default";
            this.Default.ReadOnly = true;
            this.Default.Width = 80;
            // 
            // Explain
            // 
            this.Explain.HeaderText = "說明";
            this.Explain.Name = "Explain";
            // 
            // Note
            // 
            this.Note.HeaderText = "備註";
            this.Note.Name = "Note";
            // 
            // Information
            // 
            this.Information.Controls.Add(this.DescriptionText);
            this.Information.Controls.Add(this.btnExport);
            this.Information.Controls.Add(this.DocumentNameText);
            this.Information.Controls.Add(this.DocumentNameLab);
            this.Information.Controls.Add(this.FillingText);
            this.Information.Controls.Add(this.DescriptionLab);
            this.Information.Controls.Add(this.FillingLab);
            this.Information.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Information.Location = new System.Drawing.Point(364, 13);
            this.Information.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Information.Name = "Information";
            this.Information.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Information.Size = new System.Drawing.Size(769, 91);
            this.Information.TabIndex = 0;
            this.Information.TabStop = false;
            this.Information.Text = "匯出資訊";
            // 
            // DescriptionText
            // 
            this.DescriptionText.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DescriptionText.Location = new System.Drawing.Point(365, 41);
            this.DescriptionText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DescriptionText.Multiline = true;
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(293, 41);
            this.DescriptionText.TabIndex = 8;
            // 
            // btnExport
            // 
            this.btnExport.AutoSize = true;
            this.btnExport.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExport.Image = global::DBSchemaKit.Properties.Resources.ExportExcel;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(671, 18);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(85, 65);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "輸出檔案";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // DocumentNameText
            // 
            this.DocumentNameText.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DocumentNameText.Location = new System.Drawing.Point(79, 27);
            this.DocumentNameText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DocumentNameText.Name = "DocumentNameText";
            this.DocumentNameText.Size = new System.Drawing.Size(275, 25);
            this.DocumentNameText.TabIndex = 6;
            // 
            // DocumentNameLab
            // 
            this.DocumentNameLab.AutoSize = true;
            this.DocumentNameLab.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DocumentNameLab.Location = new System.Drawing.Point(14, 30);
            this.DocumentNameLab.Name = "DocumentNameLab";
            this.DocumentNameLab.Size = new System.Drawing.Size(63, 17);
            this.DocumentNameLab.TabIndex = 0;
            this.DocumentNameLab.Text = "文件名稱:";
            // 
            // FillingText
            // 
            this.FillingText.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FillingText.Location = new System.Drawing.Point(79, 57);
            this.FillingText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FillingText.Name = "FillingText";
            this.FillingText.Size = new System.Drawing.Size(275, 25);
            this.FillingText.TabIndex = 7;
            // 
            // DescriptionLab
            // 
            this.DescriptionLab.AutoSize = true;
            this.DescriptionLab.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DescriptionLab.Location = new System.Drawing.Point(365, 21);
            this.DescriptionLab.Name = "DescriptionLab";
            this.DescriptionLab.Size = new System.Drawing.Size(63, 17);
            this.DescriptionLab.TabIndex = 0;
            this.DescriptionLab.Text = "文件說明:";
            // 
            // FillingLab
            // 
            this.FillingLab.AutoSize = true;
            this.FillingLab.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FillingLab.Location = new System.Drawing.Point(27, 60);
            this.FillingLab.Name = "FillingLab";
            this.FillingLab.Size = new System.Drawing.Size(50, 17);
            this.FillingLab.TabIndex = 0;
            this.FillingLab.Text = "填表人:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 527);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1128, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(32, 17);
            this.StatusLabel.Text = "就緒";
            // 
            // frmDBToSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 549);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Information);
            this.Controls.Add(this.DBExport);
            this.Controls.Add(this.DBSetting);
            this.Controls.Add(this.DBFields);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDBToSchema";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.DBSetting.ResumeLayout(false);
            this.DBSetting.PerformLayout();
            this.DBExport.ResumeLayout(false);
            this.DBTab.ResumeLayout(false);
            this.Table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableList)).EndInit();
            this.StoredProcedure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SPList)).EndInit();
            this.View.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ViewList)).EndInit();
            this.DBFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FieldsDataGridView)).EndInit();
            this.Information.ResumeLayout(false);
            this.Information.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox DBSetting;
        private System.Windows.Forms.ComboBox DatabaseCombo;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.TextBox AccountText;
        private System.Windows.Forms.TextBox ServerText;
        private System.Windows.Forms.Label DatabaseLab;
        private System.Windows.Forms.Label PasswordLab;
        private System.Windows.Forms.Label AccountLab;
        private System.Windows.Forms.Label ServerLab;
        private System.Windows.Forms.GroupBox DBExport;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button TableDescribeButton;
        private System.Windows.Forms.Button FieldsDescribeButton;
        private System.Windows.Forms.DataGridView TableList;
        private System.Windows.Forms.GroupBox DBFields;
        private System.Windows.Forms.DataGridView FieldsDataGridView;
        private System.Windows.Forms.GroupBox Information;
        private System.Windows.Forms.TextBox DescriptionText;
        private System.Windows.Forms.TextBox DocumentNameText;
        private System.Windows.Forms.Label DocumentNameLab;
        private System.Windows.Forms.TextBox FillingText;
        private System.Windows.Forms.Label FillingLab;
        private System.Windows.Forms.Label DescriptionLab;
        private System.Windows.Forms.TabControl DBTab;
        private System.Windows.Forms.TabPage Table;
        private System.Windows.Forms.TabPage View;
        private System.Windows.Forms.TabPage StoredProcedure;
        private System.Windows.Forms.Button BreakButton;
        private System.Windows.Forms.DataGridView SPList;
        private System.Windows.Forms.DataGridView ViewList;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChineseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllowNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Default;
        private System.Windows.Forms.DataGridViewTextBoxColumn Explain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
    }
}

