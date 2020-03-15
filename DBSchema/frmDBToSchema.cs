using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace DBSchema
{
    /// <summary>
    /// DB To Schema
    /// </summary>
    public partial class frmDBToSchema : Form
    {
        public frmDBToSchema()
        {
            InitializeComponent();

            // 控制元件初始化
            BreakButton.Enabled = false;
            DBExport.Enabled = false;
            Information.Enabled = false;
            DBFields.Enabled = false;
            DatabaseCombo.Enabled = false;
            // 進度列初始化
            progressBar.Value = 0;
            StatusLabel.Text = "就緒";

            // 初始值
            DocumentNameText.Text = DateTime.Now.ToString("yyMMdd") + "_DBSchema";
            FillingText.Text = "Nelson Yang";
            DescriptionText.Text = "DataBase 架構文件";
            ServerText.Text = "";
            AccountText.Text = "";
            PasswordText.Text = "";
        }

        #region 資料庫設定

        /// <summary>
        /// 資料庫連線字串
        /// </summary>
        /// <returns></returns>
        public string ConnectionDB()
        {
            return "Data Source=" + ServerText.Text + ";Persist Security Info=True;User ID=" + AccountText.Text + ";Password=" + PasswordText.Text + "";
        }

        /// <summary>
        /// 資料庫連線
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            // 控制項按鈕設定
            ConnectButton.Enabled = false;

            // 資料庫列表
            string _QuerySQL = "select name, database_id, create_date FROM sys.databases order by name";

            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                {
                    Conn.Open();

                    using (SqlCommand Command = new SqlCommand(_QuerySQL, Conn))
                    {
                        SqlDataReader Reader = Command.ExecuteReader();
                        try
                        {
                            while (Reader.Read())
                            {
                                DatabaseCombo.Items.Add(Reader[0]);
                            }
                        }
                        finally
                        {
                            Reader.Close();
                            BreakButton.Enabled = true;
                            DatabaseCombo.Enabled = true;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("登入失敗!");
                ConnectButton.Enabled = true;
                BreakButton.Enabled = false;
            }


        }

        /// <summary>
        /// 資料庫斷線
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BreakButton_Click(object sender, EventArgs e)
        {
            BreakButton.Enabled = false;
            ConnectButton.Enabled = true;
            DBExport.Enabled = false;
            Information.Enabled = false;
            DBFields.Enabled = false;
            DatabaseCombo.Enabled = false;
            DatabaseCombo.Items.Clear();
            TableList.Rows.Clear();
            SPList.Rows.Clear();
            ViewList.Rows.Clear();
        }

        /// <summary>
        /// 資料表資訊列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 資料表列表
            // 清空資料表清單
            TableList.Rows.Clear();

            // 設定目前選擇到資料庫名稱
            SelectedDatabase = DatabaseCombo.SelectedItem.ToString();

            // 目前使用者在目前資料庫中可以存取的資料表
            string SQLString = "use " + SelectedDatabase + " SELECT name '資料表名稱', (SELECT value FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'table', name, NULL, NULL)) '中文名稱' FROM sys.tables order by name";
            
            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                {
                    Conn.Open();

                    using (SqlCommand Command = new SqlCommand(SQLString, Conn))
                    {
                        SqlDataReader Reader = Command.ExecuteReader();
                        try
                        {
                            int i = 1;
                            while (Reader.Read())
                            {
                                //標頭設定
                                TableList.ColumnCount = 3;

                                //第 1 欄 - 編號
                                TableList.Columns[0].HeaderText = "編號";
                                TableList.Columns[0].Name = "number";
                                TableList.Columns[0].Width = 43;
                                TableList.Columns[0].HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                                TableList.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                TableList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                TableList.Columns[0].ReadOnly = true;

                                //第 2 欄 - 名稱
                                TableList.Columns[1].HeaderText = "名稱";
                                TableList.Columns[1].Name = "name";
                                TableList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                TableList.Columns[1].HeaderCell.Style.WrapMode = DataGridViewTriState.False;                                
                                TableList.Columns[1].ReadOnly = true;

                                //第 3 欄 - 描述
                                TableList.Columns[2].HeaderText = "描述";
                                TableList.Columns[2].Name = "description";
                                TableList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                TableList.Columns[2].HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                                TableList.Columns[2].DefaultCellStyle.ForeColor = Color.DarkGreen;

                                //標頭塞值
                                TableList.Rows.Add(i, Reader["資料表名稱"].ToString(), Reader["中文名稱"].ToString());

                                //選擇欄位
                                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                                TableList.Columns.Add(chk);
                                chk.HeaderText = "選擇";
                                chk.Name = "chk";
                                chk.Visible = false;
                                TableList.Columns[3].Width = 40;
                                TableList.Columns[3].HeaderCell.Style.WrapMode = DataGridViewTriState.False;

                                i++;
                            }
                        }
                        finally
                        {
                            Reader.Close();
                            DBExport.Enabled = true;
                            Information.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("【溫馨提示】\n\r Oops! 好像發生一些問題了! 請稍後在試看看唷! \n\r\n\r【以下為恐怖的錯誤訊息】\n\r" + ex.ToString());
            }
            #endregion

            #region 預存程式列表

            SPList.Rows.Clear();

            string SPListSQLString = "use " + SelectedDatabase + " select name '名稱' from sys.sysobjects where xtype in ('P') order by name";

            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                {
                    Conn.Open();

                    using (SqlCommand Command = new SqlCommand(SPListSQLString, Conn))
                    {
                        SqlDataReader Reader = Command.ExecuteReader();
                        try
                        {
                            int i = 1;
                            while (Reader.Read())
                            {
                                //標頭設定
                                SPList.ColumnCount = 2;

                                //第 1 欄 - 編號
                                SPList.Columns[0].HeaderText = "編號";
                                SPList.Columns[0].Name = "number";
                                SPList.Columns[0].Width = 43;
                                SPList.Columns[0].HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                                SPList.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                SPList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                                //第 2 欄 - 名稱
                                SPList.Columns[1].HeaderText = "名稱";
                                SPList.Columns[1].Name = "name";
                                SPList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                SPList.Columns[1].HeaderCell.Style.WrapMode = DataGridViewTriState.False;

                                //標頭塞值
                                SPList.Rows.Add(i, Reader["名稱"].ToString());

                                //選擇欄位
                                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                                SPList.Columns.Add(chk);
                                chk.HeaderText = "選擇";
                                chk.Name = "chk";
                                chk.Visible = false;
                                SPList.Columns[2].Width = 40;
                                SPList.Columns[2].HeaderCell.Style.WrapMode = DataGridViewTriState.False;

                                i++;
                            }
                        }
                        finally
                        {
                            Reader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("【溫馨提示】\n\r Oops! 好像發生一些問題了! 請稍後在試看看唷! \n\r\n\r【以下為恐怖的錯誤訊息】\n\r" + ex.ToString());
            }
            #endregion

            #region 檢視列表

            ViewList.Rows.Clear();

            string ViewListSQLString = "use " + SelectedDatabase + " SELECT TABLE_NAME '名稱' FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'VIEW' order by TABLE_NAME";

            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                {
                    Conn.Open();

                    using (SqlCommand Command = new SqlCommand(ViewListSQLString, Conn))
                    {
                        SqlDataReader Reader = Command.ExecuteReader();
                        try
                        {
                            int i = 1;
                            while (Reader.Read())
                            {
                                //標頭設定
                                ViewList.ColumnCount = 2;

                                //第 1 欄 - 編號
                                ViewList.Columns[0].HeaderText = "編號";
                                ViewList.Columns[0].Name = "number";
                                ViewList.Columns[0].Width = 43;
                                ViewList.Columns[0].HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                                ViewList.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                ViewList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                                //第 2 欄 - 名稱
                                ViewList.Columns[1].HeaderText = "名稱";
                                ViewList.Columns[1].Name = "name";
                                ViewList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                ViewList.Columns[1].HeaderCell.Style.WrapMode = DataGridViewTriState.False;

                                //標頭塞值
                                ViewList.Rows.Add(i, Reader["名稱"].ToString());

                                //選擇欄位
                                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                                ViewList.Columns.Add(chk);
                                chk.HeaderText = "選擇";
                                chk.Name = "chk";
                                chk.Visible = false;
                                ViewList.Columns[2].Width = 40;
                                ViewList.Columns[2].HeaderCell.Style.WrapMode = DataGridViewTriState.False;

                                i++;
                            }
                        }
                        finally
                        {
                            Reader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("【溫馨提示】\n\r Oops! 好像發生一些問題了! 請稍後在試看看唷! \n\r\n\r【以下為恐怖的錯誤訊息】\n\r" + ex.ToString());
            }
            #endregion
        }

        #endregion

        #region 資料表資訊

        /// <summary>
        /// 點選資料表顯示資料欄位清單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DBFields.Enabled = true;

            //清空資料表清單
            FieldsDataGridView.Rows.Clear();

            //只允許點選資料表名稱後，讀取資料表詳情欄位
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                // 設定目前選擇到的資料表名稱
                SelectedTable = TableList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                #region 撈出資料表詳情SQL語法
                string _SQLString =  "use " + SelectedDatabase + @" SELECT tab.name '資料表名稱',
                               col.colid '識別碼', 
                               col.name '欄位名稱', 
                               (SELECT VALUE 
                                FROM   Fn_listextendedproperty (NULL, 'schema', 'dbo', 'table', 
                               tab.name, 
                               'column',
                               col.name)) '欄位中文名稱',
                               typ.name '型態', 
                               col.prec '有效位數', 
                               col.scale '資料範圍', 
                               col.length '長度', 
                               com.TEXT '預設值', 
                               CASE 
                                   WHEN 
                                   (Select COUNT(Column_Name) FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where TABLE_NAME = '" + SelectedTable + @"' and Column_Name = col.name and CONSTRAINT_NAME like 'PK%') = 1 THEN 'PK' 
                                   WHEN 
                                   (Select COUNT(Column_Name) FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where TABLE_NAME = '" + SelectedTable + @"' and Column_Name = col.name and CONSTRAINT_NAME like 'FK%') = 1 THEN 'FK' 
                                   ELSE '' 
                               END '鍵值',
                               CASE 
                                 WHEN col.isnullable = 1 THEN 'V' 
                                 ELSE '' 
                               END '空值', 
                               CASE 
                                 WHEN col.status & 0X80 = 0X80 THEN 'V' 
                                 ELSE '' 
                               END 'Identity' 
                                FROM   sysobjects tab, 
                               syscolumns col 
                               LEFT OUTER JOIN syscomments com 
                                               INNER JOIN sysobjects obj 
                                                 ON com.id = obj.id 
                                 ON col.cdefault = com.id 
                                    AND com.colid = 1, 
                               systypes typ 
                                WHERE  tab.id = col.id 
                               AND tab.xtype = 'U' 
                               AND col.xusertype = typ.xusertype
                               and tab.name = '" + SelectedTable + @"'";
                #endregion

                try
                {
                    using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                    {
                        Conn.Open();

                        using (SqlCommand Command = new SqlCommand(_SQLString, Conn))
                        {
                            SqlDataReader Reader = Command.ExecuteReader();
                            try
                            {
                                while (Reader.Read())
                                {
                                    //標頭設定
                                    FieldsDataGridView.ColumnCount = 10;
                                    FieldsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                                    //標頭名稱
                                    FieldsDataGridView.Columns[0].Name = "欄位名稱";
                                    FieldsDataGridView.Columns[1].Name = "中文名稱";
                                    FieldsDataGridView.Columns[2].Name = "型態";
                                    FieldsDataGridView.Columns[3].Name = "長度";
                                    FieldsDataGridView.Columns[4].Name = "鍵值";
                                    FieldsDataGridView.Columns[5].Name = "空值";
                                    FieldsDataGridView.Columns[6].Name = "Identity";
                                    FieldsDataGridView.Columns[7].Name = "預設值";
                                    FieldsDataGridView.Columns[8].Name = "說明";
                                    FieldsDataGridView.Columns[9].Name = "備註";

                                    //標頭塞值
                                    FieldsDataGridView.Rows.Add(Reader["欄位名稱"].ToString(),
                                                                Reader["欄位中文名稱"].ToString(),
                                                                Reader["型態"].ToString(),
                                                                GetColumnLength(Reader["型態"].ToString(), Reader["有效位數"].ToString(), Reader["資料範圍"].ToString()),
                                                                Reader["鍵值"].ToString(),
                                                                Reader["空值"].ToString(),
                                                                Reader["Identity"].ToString(),
                                                                Reader["預設值"].ToString(),
                                                                "",
                                                                ""
                                                                );
                                }
                            }
                            finally
                            {
                                Reader.Close();
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("【溫馨提示】\n\r Oops! 好像發生一些問題了! 請稍後在試看看唷! \n\r\n\r【以下為恐怖的錯誤訊息】\n\r" + ex.ToString());
                }
            }
        }

        #endregion

        #region 匯出設定

        /// <summary>
        /// 匯出 Excel (DB Schema)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.Description = "請選擇產生Excel檔案的目錄";
            path.ShowNewFolderButton = true;

            // 預設輸出目錄在桌面
            path.RootFolder = Environment.SpecialFolder.Desktop;

            // 跳出選擇路徑視窗
            if (path.ShowDialog() == DialogResult.OK)
            {
                #region 防呆
                // 鎖定主框架選單
                frmMain _LockToolStrip = (frmMain)this.MdiParent;
                _LockToolStrip.toolStrip.Enabled = false;

                // 防呆裝置
                DBSetting.Enabled = false;
                DBExport.Enabled = false;
                DBFields.Enabled = false;
                btnExport.Enabled = false;
                #endregion

                // 進度列初始化
                progressBar.Value = 0;
                StatusLabel.Text = "就緒";

                // 參數值
                ExcelParam.FilePath = path.SelectedPath + "\\";
                ExcelParam.FileName = DocumentNameText.Text + ".xlsx";
                ExcelParam.DatabaseName = SelectedDatabase;

                // 背景執行緒
                BackgroundWorker Synchronous = new BackgroundWorker();
                Synchronous.DoWork += new DoWorkEventHandler(DoWork);
                Synchronous.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
                Synchronous.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);
                Synchronous.WorkerReportsProgress = true;
                Synchronous.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 輸出主作業
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
           
            // 檔案路徑
            string _FilePath = ExcelParam.FilePath;

            // 檔案名稱
            string _FileName = ExcelParam.FileName;

            // 資料庫名稱
            string _DatabaseName = ExcelParam.DatabaseName;

            // DB Schema 範例 檔案路徑
            System.IO.FileInfo filePath = new System.IO.FileInfo(_FilePath + _FileName);

            // 開啟範例
            using (FileStream fs = new FileStream(@"Templates/DBSchemaTemplates.xlsx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //載入Excel檔案
                using (ExcelPackage ep = new ExcelPackage(fs))
                {
                    // 更新進度列
                    Thread.Sleep(500);
                    worker.ReportProgress(10);
                    StatusLabel.Text = "讀取資料庫，取得資料表清單中...";

                    #region 取得Table 清單
                    // 資料表清單
                    List<string> TableList = new List<string>();

                    // 資料庫列表
                    using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                    {
                        Conn.Open();

                        using (SqlCommand Command = new SqlCommand("use " + _DatabaseName + " SELECT name FROM sys.tables", Conn))
                        {
                            SqlDataReader Reader = Command.ExecuteReader();
                            while (Reader.Read())
                            {
                                // 加入資料表清單
                                TableList.Add(Reader[0].ToString());
                            }
                            Reader.Close();
                        }
                    }
                    #endregion

                    // 更新進度列
                    Thread.Sleep(500);
                    worker.ReportProgress(25);
                    StatusLabel.Text = "生成DB Schema總表中...";

                    #region DB Schema 總表
                    ExcelWorksheet _SummaryTable = ep.Workbook.Worksheets["SummaryTable"];

                    // 文件名稱
                    _SummaryTable.Cells["C8"].Value = DocumentNameText.Text;

                    // 文字自動換行
                    _SummaryTable.Cells["C8"].Style.WrapText = true;

                    // 資料庫名稱
                    _SummaryTable.Cells["C9"].Value = _DatabaseName;
                    _SummaryTable.Cells["C9"].Style.WrapText = true;

                    // 說明
                    _SummaryTable.Cells["C10"].Value = DescriptionText.Text;
                    _SummaryTable.Cells["C10"].Style.WrapText = true;
                    #endregion

                    // 更新進度列
                    Thread.Sleep(500);
                    worker.ReportProgress(30);
                    StatusLabel.Text = "更新修改紀錄中...";

                    #region 修改紀錄
                    ExcelWorksheet _HistoryRecord = ep.Workbook.Worksheets["HistoryRecord"];

                    // 項次
                    _HistoryRecord.Cells["A3"].Value = 1;
                    _HistoryRecord.Cells["A3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    _HistoryRecord.Cells["A3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    // 異動日期
                    _HistoryRecord.Cells["B3"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    _HistoryRecord.Cells["B3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    _HistoryRecord.Cells["B3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    // 異動者
                    _HistoryRecord.Cells["C3"].Value = FillingText.Text;
                    _HistoryRecord.Cells["C3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    _HistoryRecord.Cells["C3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    // 異動項目
                    _HistoryRecord.Cells["D3"].Value = "建立文件";
                    _HistoryRecord.Cells["D3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    _HistoryRecord.Cells["D3"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    #endregion

                    // 更新進度列
                    worker.ReportProgress(55);
                    StatusLabel.Text = "生成各個資料表中...(資料表若較多處理時間會比較久，請耐心稍等)";

                    #region 各個資料表 詳情
                    foreach (string _TableName in TableList)
                    {
                        // 判斷Sheet是否存在，不存在才會進行建置
                        if (ep.Workbook.Worksheets[_TableName] == null)
                        {
                            //複製 樣板 Sheet 同時命名為 該Table名稱
                            ExcelWorksheet _Table = ep.Workbook.Worksheets.Copy("Template", _TableName);

                            using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                            {
                                string SQLString = "use " + _DatabaseName + " ";

                                #region 撈出資料表詳情SQL語法
                                SQLString += @"SELECT tab.name '資料表名稱',
                               col.colid '識別碼', 
                               col.name '欄位名稱', 
                               (SELECT VALUE 
                                FROM   Fn_listextendedproperty (NULL, 'schema', 'dbo', 'table', 
                               tab.name, 
                               'column',
                               col.name)) '欄位中文名稱',
                               typ.name '型態', 
                               col.prec '有效位數', 
                               col.scale '資料範圍', 
                               col.length '長度', 
                               com.TEXT '預設值', 
                               CASE 
                                   WHEN 
                                   (Select COUNT(Column_Name) FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where TABLE_NAME = '" + _TableName + @"' and Column_Name = col.name and CONSTRAINT_NAME like 'PK%') = 1 THEN 'PK' 
                                   WHEN 
                                   (Select COUNT(Column_Name) FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where TABLE_NAME = '" + _TableName + @"' and Column_Name = col.name and CONSTRAINT_NAME like 'FK%') = 1 THEN 'FK' 
                                   ELSE '' 
                               END '鍵值',
                               CASE 
                                 WHEN col.isnullable = 1 THEN 'V' 
                                 ELSE '' 
                               END '空值', 
                               CASE 
                                 WHEN col.status & 0X80 = 0X80 THEN 'V' 
                                 ELSE '' 
                               END 'Identity' 
                                FROM   sysobjects tab, 
                               syscolumns col 
                               LEFT OUTER JOIN syscomments com 
                                               INNER JOIN sysobjects obj 
                                                 ON com.id = obj.id 
                                 ON col.cdefault = com.id 
                                    AND com.colid = 1, 
                               systypes typ 
                                WHERE  tab.id = col.id 
                               AND tab.xtype = 'U' 
                               AND col.xusertype = typ.xusertype
                               and tab.name = '" + _TableName + @"'";
                                #endregion

                                Conn.Open();

                                using (SqlCommand Command = new SqlCommand(SQLString, Conn))
                                {
                                    SqlDataReader Reader = Command.ExecuteReader();
                                    // 開始欄位
                                    int i = 7;
                                    while (Reader.Read())
                                    {
                                        #region 資料表資訊
                                        // 中文名稱
                                        _Table.Cells["B2"].Value = GetCTTableName(_TableName, _DatabaseName);

                                        // 填表人
                                        _Table.Cells["G2"].Value = FillingText.Text;

                                        // Table Name
                                        _Table.Cells["B3"].Value = _TableName;

                                        // Primary Key
                                        _Table.Cells["B4"].Value = LookupKey(_TableName, "PRIMARY KEY", _DatabaseName);

                                        // Foreign Key
                                        _Table.Cells["B5"].Value = LookupKey(_TableName, "FOREIGN KEY", _DatabaseName);
                                        #endregion

                                        #region 欄位清單
                                        // 欄位名稱
                                        _Table.Cells["A" + i].Value = Reader["欄位名稱"];
                                        // 欄位置中
                                        _Table.Cells["A" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                        // 儲存格框線
                                        _Table.Cells["A" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                        _Table.Cells["A" + i].Style.WrapText = true;

                                        // 中文名稱
                                        _Table.Cells["B" + i].Value = Reader["欄位中文名稱"];
                                        _Table.Cells["B" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                        _Table.Cells["B" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                        _Table.Cells["B" + i].Style.WrapText = true;

                                        // 型態
                                        _Table.Cells["C" + i].Value = Reader["型態"];
                                        _Table.Cells["C" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                        _Table.Cells["C" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                                        // 長度
                                        _Table.Cells["D" + i].Value = GetColumnLength(Reader["型態"].ToString(), Reader["有效位數"].ToString(), Reader["資料範圍"].ToString());
                                        _Table.Cells["D" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                        _Table.Cells["D" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                                        // 鍵值
                                        _Table.Cells["E" + i].Value = Reader["鍵值"];
                                        _Table.Cells["E" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                        _Table.Cells["E" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                                        // 空值
                                        _Table.Cells["F" + i].Value = Reader["空值"];
                                        _Table.Cells["F" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                        _Table.Cells["F" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                                        // Identity
                                        _Table.Cells["G" + i].Value = Reader["Identity"];
                                        _Table.Cells["G" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                        _Table.Cells["G" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                                        // 預設值
                                        _Table.Cells["H" + i].Value = Reader["預設值"].ToString().Replace("(", "").Replace(")", "").Replace("'", "");
                                        _Table.Cells["H" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                        _Table.Cells["H" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                                        // 說明                                     
                                        _Table.Cells["I" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                        _Table.Cells["I" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                        _Table.Cells["I" + i].Style.WrapText = true;

                                        // 備註                                    
                                        _Table.Cells["J" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                        _Table.Cells["J" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                        _Table.Cells["J" + i].Style.WrapText = true;
                                        #endregion

                                        i++;
                                    }
                                    Reader.Close();
                                }
                            }
                        }
                    }
                    #endregion

                    // 更新進度列
                    Thread.Sleep(500);
                    worker.ReportProgress(65);
                    StatusLabel.Text = "生成資料表清單中...";

                    #region 資料表 (Table) 列表
                    ExcelWorksheet _TableList = ep.Workbook.Worksheets["TableList"];
                    using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                    {
                        Conn.Open();

                        string SQLString = "use " + _DatabaseName + " SELECT name '資料表名稱', (SELECT value FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'table', name, NULL, NULL)) '中文名稱' FROM sys.tables order by name";
                        using (SqlCommand Command = new SqlCommand(SQLString, Conn))
                        {
                            SqlDataReader Reader = Command.ExecuteReader();
                            // 開始欄位
                            int i = 3;
                            while (Reader.Read())
                            {
                                // 項次
                                _TableList.Cells["A" + i].Value = i - 2;
                                // 欄位置中
                                _TableList.Cells["A" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                // 儲存格框線
                                _TableList.Cells["A" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _TableList.Cells["A" + i].Style.WrapText = true;

                                // 名稱
                                _TableList.Cells["B" + i].Value = Reader["資料表名稱"].ToString();
                                _TableList.Cells["B" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                _TableList.Cells["B" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _TableList.Cells["B" + i].Hyperlink = new ExcelHyperLink(Reader["資料表名稱"].ToString() + "!B" + i, Reader["資料表名稱"].ToString());
                                _TableList.Cells["B" + i].Style.WrapText = true;

                                // 說明 & 備註
                                _TableList.Cells["C" + i].Value = Reader["中文名稱"].ToString();
                                _TableList.Cells["C" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                _TableList.Cells["C" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _TableList.Cells["C" + i].Style.WrapText = true;

                                _TableList.Cells["D" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                _TableList.Cells["D" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _TableList.Cells["D" + i].Style.WrapText = true;

                                i++;
                            }
                            Reader.Close();
                        }
                    }
                    #endregion

                    // 更新進度列
                    Thread.Sleep(500);
                    worker.ReportProgress(75);
                    StatusLabel.Text = "生成預存程序清單中...";

                    #region 預存程序 (StoredProcedure) 列表
                    ExcelWorksheet _SPList = ep.Workbook.Worksheets["StoredProcedureList"];
                    using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                    {
                        Conn.Open();

                        using (SqlCommand Command = new SqlCommand("use " + _DatabaseName + " select name 'SP名稱' from sys.sysobjects where xtype in ('P') order by name", Conn))
                        {
                            SqlDataReader Reader = Command.ExecuteReader();
                            // 開始欄位
                            int i = 3;
                            while (Reader.Read())
                            {
                                // 項次
                                _SPList.Cells["A" + i].Value = i - 2;
                                // 欄位置中
                                _SPList.Cells["A" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                // 儲存格框線
                                _SPList.Cells["A" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _SPList.Cells["A" + i].Style.WrapText = true;

                                // 名稱
                                _SPList.Cells["B" + i].Value = Reader["SP名稱"];
                                _SPList.Cells["B" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                _SPList.Cells["B" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _SPList.Cells["B" + i].Style.WrapText = true;

                                // 說明 & 備註
                                _SPList.Cells["C" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                _SPList.Cells["C" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _SPList.Cells["C" + i].Style.WrapText = true;

                                _SPList.Cells["D" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                _SPList.Cells["D" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _SPList.Cells["D" + i].Style.WrapText = true;

                                i++;
                            }
                            Reader.Close();
                        }
                    }
                    #endregion

                    // 更新進度列
                    Thread.Sleep(500);
                    worker.ReportProgress(95);
                    StatusLabel.Text = "生成檢視表清單中...";

                    #region 檢視 (View) 列表
                    ExcelWorksheet _ViewList = ep.Workbook.Worksheets["ViewList"];
                    using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                    {
                        Conn.Open();

                        using (SqlCommand Command = new SqlCommand("use " + _DatabaseName + " SELECT TABLE_NAME 'View名稱' FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'VIEW' order by TABLE_NAME", Conn))
                        {
                            SqlDataReader Reader = Command.ExecuteReader();
                            // 開始欄位
                            int i = 3;
                            while (Reader.Read())
                            {
                                // 項次
                                _ViewList.Cells["A" + i].Value = i - 2;
                                // 欄位置中
                                _ViewList.Cells["A" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                // 儲存格框線
                                _ViewList.Cells["A" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _ViewList.Cells["A" + i].Style.WrapText = true;

                                // 名稱
                                _ViewList.Cells["B" + i].Value = Reader["View名稱"];
                                _ViewList.Cells["B" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                _ViewList.Cells["B" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _ViewList.Cells["B" + i].Style.WrapText = true;

                                // 說明 & 備註
                                _ViewList.Cells["C" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                _ViewList.Cells["C" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _ViewList.Cells["C" + i].Style.WrapText = true;

                                _ViewList.Cells["D" + i].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                _ViewList.Cells["D" + i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                _ViewList.Cells["D" + i].Style.WrapText = true;

                                i++;
                            }
                            Reader.Close();
                        }
                    }
                    #endregion

                    // 更新進度列
                    Thread.Sleep(500);
                    worker.ReportProgress(99);
                    StatusLabel.Text = "建立檔案...";

                    #region 建立檔案
                    try
                    {
                        using (FileStream createStream = new FileStream(_FilePath + _FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                        {
                            // 存檔
                            ep.SaveAs(createStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Oops! 您好像正在使用該程式產生的Excel檔案，請您先關閉在試看看唷! \n\r\n\r【以下為問題訊息】\n\r" + ex.ToString(), "提示");
                    }
                    #endregion
                    StatusLabel.Text = "建立檔案...";

                    // 更新進度列
                    worker.ReportProgress(100);
                    StatusLabel.Text = "完成!";
                }
            }
        }

        /// <summary>
        /// 輸出進度更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// 輸出完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompletedWork(object sender, RunWorkerCompletedEventArgs e)
        {
            // 鎖定主框架選單
            frmMain _LockToolStrip = (frmMain)this.MdiParent;
            _LockToolStrip.toolStrip.Enabled = true;

            // 防呆裝置
            DBSetting.Enabled = true;
            DBExport.Enabled = true;
            DBFields.Enabled = true;
            btnExport.Enabled = true;

            MessageBox.Show("匯出成功!", "提示");
        }

        /// <summary>
        /// 匯出 Excel 共用參數，由於執行緒不能與原本Class 共存
        /// </summary>
        public class ExcelParam
        {
            /// <summary>
            /// 檔案路徑
            /// </summary>
            public static string FilePath { get; set; }

            /// <summary>
            /// 檔案名稱
            /// </summary>
            public static string FileName { get; set; }

            /// <summary>
            ///資料庫名稱
            /// </summary>
            public static string DatabaseName { get; set; }
        }
        #endregion

        #region 共用方法

        /// <summary>
        /// 取得資料表中文名稱
        /// </summary>
        /// <param name="_TableName"></param>
        /// <returns></returns>
        public string GetCTTableName(string _TableName, string _DatabaseName)
        {
            using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
            {
                Conn.Open();

                using (SqlCommand Command = new SqlCommand("use " + _DatabaseName + " SELECT value FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'table', '" + _TableName + "', NULL, NULL)", Conn))
                {
                    SqlDataReader Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        return Reader[0].ToString();
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// 取得資料表 PRIMARY KEY, FOREIGN KEY, UNIQUE
        /// </summary>
        /// <param name="_TableName"></param>
        /// <param name="_Type"></param>
        /// <returns></returns>
        public string LookupKey(string _TableName, string _Type, string _DatabaseName)
        {
            string _PKList = "";

            using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
            {
                Conn.Open();

                // 撈出資料表PK 或 FK 或 UNIQUE
                string _SQLPK = @"use " + _DatabaseName + @" SELECT Col.Column_Name from 
                                INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab, 
                                INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col 
                            WHERE 
                                Col.Constraint_Name = Tab.Constraint_Name
                                AND Col.Table_Name = Tab.Table_Name
                                AND Constraint_Type = '" + _Type + @"'
                                AND Col.Table_Name = '" + _TableName + @"'
                            ";
                using (SqlCommand Command = new SqlCommand(_SQLPK, Conn))
                {
                    SqlDataReader Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        // 增加分隔逗號
                        _PKList += (_PKList != "") ? ", " : "";
                        
                        _PKList += (Reader[0] != null) ?  Reader[0].ToString() : "";
                    }
                }
            }

            return _PKList;
        }

        /// <summary>
        /// 取得欄位型態長度
        /// </summary>
        /// <returns></returns>
        public string GetColumnLength(string _Type, string _Length, string _Range)
        {
            // 類型為「nvarchar」，且長度為「-1」，則回傳「MAX」
            if (_Type == "nvarchar" && _Length == "-1")
            {
                return "MAX";
            }

            // 類型為「decimal」，則回傳「長度, 範圍」
            if (_Type == "decimal")
            {
                return _Length + "," + _Range;
            }

            // 類型為「numeric」，則回傳「長度, 範圍」
            if (_Type == "numeric")
            {
                return _Length + "," + _Range;
            }

            // 類型為「datetime」，則回傳「空值」
            if (_Type == "datetime")
            {
                return "";
            }

            return _Length;
        }

        #endregion

        #region 共用變數

        /// <summary>
        /// 目前選擇到的資料庫
        /// </summary>
        public string SelectedDatabase = "";

        /// <summary>
        /// 目前選擇到的資料表
        /// </summary>
        public string SelectedTable = "";

        #endregion

        #region 更新描述

        /// <summary>
        /// 更新資料表描述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableDescribeButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in TableList.Rows)
            {
                // 更新資料表描述
                string _SQLString = "use " + SelectedDatabase + @" IF not exists(SELECT * FROM fn_listextendedproperty (NULL, 'user', 'dbo', 'table', '" + row.Cells[1].Value.ToString() + @"', NULL, NULL))  
                                    BEGIN
                                      exec sp_addextendedproperty 'MS_Description', '" + ((row.Cells[2].Value == null) ? "" : row.Cells[2].Value.ToString()) + @"', 'user', 'dbo', 'table', '" + row.Cells[1].Value.ToString() + @"'
                                    END
                                    ELSE
                                    BEGIN
                                      exec sp_updateextendedproperty 'MS_Description', '" + ((row.Cells[2].Value == null)? "" : row.Cells[2].Value.ToString()) + @"', 'user', 'dbo', 'table', '" + row.Cells[1].Value.ToString() + @"'
                                    END
                                    ";

                using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                {
                    Conn.Open();
                    SqlCommand Command = new SqlCommand(_SQLString, Conn);
                    Command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("更新完成!");
        }

        /// <summary>
        /// 更新資料欄位描述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FieldsDescribeButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in FieldsDataGridView.Rows)
            {
                // 更新資料表描述
                string _SQLString = "use " + SelectedDatabase + @" IF not exists(SELECT * FROM ::fn_listextendedproperty ('MS_Description', 'user', 'dbo', 'table', '" + SelectedTable + @"', 'column', '" + row.Cells[0].Value.ToString() + @"')) 
                                    BEGIN
                                      exec sp_addextendedproperty 'MS_Description', '" + ((row.Cells[1].Value == null) ? "" : row.Cells[1].Value.ToString()) + @"', 'user', 'dbo', 'table', '" + SelectedTable + @"', 'column', '" + row.Cells[0].Value.ToString() + @"'
                                    END
                                    ELSE
                                    BEGIN
                                      exec sp_updateextendedproperty 'MS_Description', '" + ((row.Cells[1].Value == null) ? "" : row.Cells[1].Value.ToString()) + @"', 'user', 'dbo', 'table', '" + SelectedTable + @"', 'column', '" + row.Cells[0].Value.ToString() + @"'
                                    END";

                using (SqlConnection Conn = new SqlConnection(ConnectionDB()))
                {
                    Conn.Open();
                    SqlCommand Command = new SqlCommand(_SQLString, Conn);
                    Command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("更新完成!");
            
        }

        #endregion
        
    }
}
