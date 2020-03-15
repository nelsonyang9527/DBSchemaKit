using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace DBSchema
{
    /// <summary>
    /// Schema To DB
    /// </summary>
    public partial class frmSchemaToDB : Form
    {
        public frmSchemaToDB()
        {
            InitializeComponent();

            gboxGenerator.Enabled = false;
            gboxTableList.Enabled = false;
            gboxResults.Enabled = false;
        }

        /// <summary>
        /// 選擇檔案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            gboxGenerator.Enabled = false;
            gboxTableList.Enabled = false;
            gboxResults.Enabled = false;

            OpenFileDialog FilePath = new OpenFileDialog();
            FilePath.Filter = "Office Excel 2007 以上|*.xlsx";
            FilePath.InitialDirectory = @"C:\";
            FilePath.Title = "請選擇 DB Schema 文件";
            FilePath.ShowDialog();
            txtFilePath.Text = FilePath.FileName;
        }

        /// <summary>
        /// 連結
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLinkFile_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text == "")
            {
                MessageBox.Show("請選擇檔案路徑!", "提示");
                txtFilePath.Focus();
                return;
            }

            if (txtDBName.Text == "")
            {
                MessageBox.Show("請填寫資料庫名稱!", "提示");
                txtDBName.Focus();
                return;
            }

            if (File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("讀取成功!", "提示");
                gboxGenerator.Enabled = true;
                gboxTableList.Enabled = true;
                gboxResults.Enabled = true;
                ReadMethod();
                ReadTableSchema();
            }
            else
            {
                MessageBox.Show("讀取失敗!", "提示");
            }
        }

        /// <summary>
        /// 產生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerator_Click(object sender, EventArgs e)
        {
            switch (cobSelectMode.SelectedValue.ToString())
            {
                case "1":
                    ReadCheckList();
                    GeneratorTableScripts();
                    break;
                case "2":
                    MessageBox.Show("敬請期待...");
                    break;
                case "3":
                    MessageBox.Show("敬請期待...");
                    break;
                case "4":
                    MessageBox.Show("敬請期待...");
                    break;
            }
        }

        /// <summary>
        /// 複製結果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, txtResults.Text);
            MessageBox.Show("已複製到剪貼簿!", "提示");
        }

        /// <summary>
        /// 全選 / 非全選
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAllTable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAllTable.Checked)
            {
                foreach (DataGridViewRow row in dgvTableSchema.Rows)
                    row.Cells[3].Value = true;
            }
            else
            {
                foreach (DataGridViewRow row in dgvTableSchema.Rows)
                    row.Cells[3].Value = false;
            }
        }

        /// <summary>
        /// 讀取產生方法清單
        /// </summary>
        private void ReadMethod()
        {
            Dictionary<string, string> Datas = new Dictionary<string, string>();
            cobSelectMode.DisplayMember = "Key";
            cobSelectMode.ValueMember = "Value";

            Datas.Add("Microsoft SQL Database", "1");
            Datas.Add("Oracle MySQL", "2");
            Datas.Add("Oracle Database 10g", "3");
            Datas.Add("SAP Sybase", "4");

            cobSelectMode.DataSource = Datas.ToList();

            cobSelectMode.SelectedValue = "1";
        }

        /// <summary>
        /// 讀取 DB Schema Excel
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, List<TableSchema>> ReadDBSchemaExcel()
        {
            // DB Schema 整份資料
            Dictionary<string, List<TableSchema>> DBSchemaList = new Dictionary<string, List<TableSchema>>();

            // 開啟檔案
            using (FileStream fs = new FileStream(txtFilePath.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                // 載入 Excel 檔案
                using (ExcelPackage ep = new ExcelPackage(fs))
                {
                    // 分頁總數量 = 全部分頁數量 - 非Table (7)
                    int _SheetCount = ep.Workbook.Worksheets.Count() - 7;

                    // 走訪分頁「8」之後的分頁
                    for (int _CurrentSheet = 8; _CurrentSheet <= ep.Workbook.Worksheets.Count(); _CurrentSheet++)
                    {
                        ExcelWorksheet sheet = ep.Workbook.Worksheets[_CurrentSheet];

                        // 分頁結尾列
                        int _EndRowIndex = sheet.Dimension.End.Row;

                        // 資料表中文名稱
                        string _CTTableName = sheet.Cells["B2"].Text.ToString();

                        // 暫存 - 分頁資料
                        List<TableSchema> TableSchemaList = new List<TableSchema>();

                        for (int _CurrentRow = 7; _CurrentRow <= _EndRowIndex; _CurrentRow++)
                        {
                            if (sheet.Cells[_CurrentRow, 1].Text.ToString() != "")
                            {
                                // 暫存 - 列資料
                                TableSchema RowData = new TableSchema();

                                RowData.Name = sheet.Cells[_CurrentRow, 1].Text.ToString();
                                RowData.CTName = sheet.Cells[_CurrentRow, 2].Text.ToString();
                                RowData.Type = sheet.Cells[_CurrentRow, 3].Text.ToString();
                                RowData.Length = sheet.Cells[_CurrentRow, 4].Text.ToString();
                                RowData.IsKey = sheet.Cells[_CurrentRow, 5].Text.ToString();
                                RowData.IsNull = sheet.Cells[_CurrentRow, 6].Text.ToString();
                                RowData.Identity = sheet.Cells[_CurrentRow, 7].Text.ToString();
                                RowData.DefaultVal = sheet.Cells[_CurrentRow, 8].Text.ToString();
                                RowData.Description = sheet.Cells[_CurrentRow, 9].Text.ToString();
                                RowData.Notes = sheet.Cells[_CurrentRow, 10].Text.ToString();

                                // 塞入 暫存 - 分頁資料
                                TableSchemaList.Add(RowData);
                            }
                        }
                        // 塞入 DB Schema 整份資料
                        DBSchemaList.Add(sheet.Name + "," + _CTTableName, TableSchemaList);
                    }
                }
            }

            return DBSchemaList;
        }

        /// <summary>
        /// 讀取Excel檔案，並列出所有資料表清單
        /// </summary>
        private void ReadTableSchema()
        {
            // DB Schema 整份資料
            Dictionary<string, List<TableSchema>> DBSchemaList = new Dictionary<string, List<TableSchema>>();

            DBSchemaList = ReadDBSchemaExcel();

            // 清空資料表清單
            dgvTableSchema.Rows.Clear();

            int i = 1;

            foreach (var item in DBSchemaList)
            {
                // 資料表名稱
                string _TableName = item.Key.Substring(0, item.Key.IndexOf(","));

                // 資料表中文名稱
                string _CTTableName = "";
                if (item.Key.IndexOf(",") != item.Key.Length)
                {
                    _CTTableName = item.Key.Substring(item.Key.IndexOf(",") + 1, item.Key.Length - item.Key.IndexOf(",") - 1);
                }

                //標頭設定
                dgvTableSchema.ColumnCount = 3;

                //第 1 欄 - 編號
                dgvTableSchema.Columns[0].HeaderText = "編號";
                dgvTableSchema.Columns[0].Name = "number";
                dgvTableSchema.Columns[0].Width = 43;
                dgvTableSchema.Columns[0].HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                dgvTableSchema.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTableSchema.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTableSchema.Columns[0].ReadOnly = true;

                //第 2 欄 - 名稱
                dgvTableSchema.Columns[1].HeaderText = "名稱";
                dgvTableSchema.Columns[1].Name = "name";
                dgvTableSchema.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTableSchema.Columns[1].HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                dgvTableSchema.Columns[1].ReadOnly = true;

                //第 3 欄 - 描述
                dgvTableSchema.Columns[2].HeaderText = "描述";
                dgvTableSchema.Columns[2].Name = "description";
                dgvTableSchema.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTableSchema.Columns[2].HeaderCell.Style.WrapMode = DataGridViewTriState.False;
                dgvTableSchema.Columns[2].DefaultCellStyle.ForeColor = Color.DarkGreen;

                //標頭塞值
                dgvTableSchema.Rows.Add(i, _TableName, _CTTableName);

                //選擇欄位
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                dgvTableSchema.Columns.Add(chk);
                chk.HeaderText = "選擇";
                chk.Name = "chk";
                chk.Visible = true;
                dgvTableSchema.Columns[3].Width = 40;
                dgvTableSchema.Columns[3].HeaderCell.Style.WrapMode = DataGridViewTriState.False;

                i++;
            }
        }

        /// <summary>
        /// 讀取已被選擇的資料表
        /// </summary>
        private void ReadCheckList()
        {
            CheckList.Clear();
            foreach (DataGridViewRow row in dgvTableSchema.Rows)
            {
                bool _bSelectTable = (row.Cells[3].Value == null) ? false : ((bool)row.Cells[3].Value) ? true : false;
                string _CheckTableName = row.Cells[1].Value.ToString().Trim().ToLower();
                if (_bSelectTable)
                {
                    CheckList.Add(_CheckTableName);
                }
            }
        }

        /// <summary>
        /// 資料表結構
        /// </summary>
        public class TableSchema
        {
            /// <summary> 欄位名稱
            /// 
            /// </summary>
            public string Name { get; set; }

            /// <summary> 中文名稱
            /// 
            /// </summary>
            public string CTName { get; set; }

            /// <summary> 型態
            /// 
            /// </summary>
            public string Type { get; set; }

            /// <summary> 長度
            /// 
            /// </summary>
            public string Length { get; set; }

            /// <summary> 鍵值
            /// 
            /// </summary>
            public string IsKey { get; set; }

            /// <summary> 空值
            /// 
            /// </summary>
            public string IsNull { get; set; }

            /// <summary> Identity (自動+1)
            /// 
            /// </summary>
            public string Identity { get; set; }

            /// <summary> 預設值
            /// 
            /// </summary>
            public string DefaultVal { get; set; }

            /// <summary> 說明
            /// 
            /// </summary>
            public string Description { get; set; }

            /// <summary> 備註
            /// 
            /// </summary>
            public string Notes { get; set; }
        }

        /// <summary>
        /// 被選擇的資料表
        /// </summary>
        public List<string> CheckList = new List<string>();

        /// <summary>
        /// 資料庫與資料表 Script 建置語法 for MSSQL
        /// </summary>
        /// <returns></returns>
        private void GeneratorTableScripts()
        {
            // DB Schema 整份資料
            Dictionary<string, List<TableSchema>> DBSchemaList = new Dictionary<string, List<TableSchema>>();

            DBSchemaList = ReadDBSchemaExcel();

            #region 拼裝 SQL Scripts 語法
            // 使用資料庫
            string _Script = "Use [" + txtDBName.Text.Trim() + "] \r\nGO\r\n";

            foreach (var item in DBSchemaList)
            {
                
                // 資料表名稱
                string _TableName = item.Key.Substring(0,item.Key.IndexOf(","));

                // 檢查是否被選擇
                if (CheckList.Where(x => x == _TableName.ToLower().Trim()).Count() == 0)
                { 
                    continue;
                }

                // 資料表中文名稱
                string _CTTableName = "";
                if (item.Key.IndexOf(",") != item.Key.Length)
                {
                    _CTTableName = item.Key.Substring(item.Key.IndexOf(",") + 1, item.Key.Length - item.Key.IndexOf(",") - 1);
                }

                // 主鍵欄位
                string _PrimaryKey = "";

                // 欄位描述
                string _FieldDescription = "";

                // 資料表中文描述
                _Script += (_CTTableName != "")? "-- " + _CTTableName + "\r\n" : "";

                _Script += "Create Table [" + _TableName + "](\r\n";
                // 拼裝欄位
                foreach (var Field in item.Value)
                {
                    _PrimaryKey += (Field.IsKey == "PK") ? (_PrimaryKey != "") ? "," + Field.Name.Trim() : Field.Name.Trim() : "";
                    
                    _Script += FieldProcess(Field);

                    if (Field.CTName.Trim() != "")
                    {
                        _FieldDescription += "exec sp_addextendedproperty 'MS_Description', '" + ((Field.CTName.Trim() != "") ? Field.CTName.Trim() : "") + "', 'user', 'dbo', 'table', '" + _TableName + "', 'column', '" + Field.Name.Trim() + "'\r\n";
                    }
                }                
                _Script += "Primary Key(" + _PrimaryKey + ")\r\n)";

                _Script += (_FieldDescription != "") ? "\r\n-- 欄位描述\r\n" + _FieldDescription : "";

                // 資料表描述
                if (_CTTableName != "")
                {
                    _Script += "-- 資料表描述\r\n";
                    _Script += "exec sp_addextendedproperty 'MS_Description', '" + _CTTableName + "', 'user', 'dbo', 'table', '" + _TableName + "'";
                }

                _Script += "\r\nGO\r\n\r\n";
            }

            // 送出結果
            txtResults.Text = _Script;
            #endregion
        }

        /// <summary>
        /// 欄位處理
        /// </summary>
        /// <returns></returns>
        private string FieldProcess(TableSchema Field)
        {
            // 欄位名稱
            string _Name = "[" + Field.Name + "]";

            // 欄位類型
            string _Type = "[" + Field.Type + "]";

            // 欄位長度
            string _Length = "(" + Field.Length + ")";

            // 欄位是否空值
            string _IsNull = ((Field.IsNull == "V") ? "NULL" : "NOT NULL");

            // 欄位預設值
            string _DefaultVal = "";
                        
            switch (Field.DefaultVal)
            { 
                case "":
                    _DefaultVal = "DEFAULT ('')";
                    break;

                case "getdate()":
                    _DefaultVal = "DEFAULT (" + Field.DefaultVal + ")";
                    break;

                default:
                    _DefaultVal = "DEFAULT ('" + Field.DefaultVal + "')";
                    break;
            }

            // 數值預設值
            decimal checkDefaultVal = 0;
            if (decimal.TryParse(Field.DefaultVal, out checkDefaultVal))
            {
                _DefaultVal = "DEFAULT (" + Field.DefaultVal + ")";
            }

            // 欄位中文註解
            string _CTName = ((Field.CTName != "") ? "--" + Field.CTName : "");

            // 判斷資料類型處理語法
            if (Field.Type.ToLower().Trim() == "bigint" || Field.Type.ToLower().Trim() == "bit"
                || Field.Type.ToLower().Trim() == "date" || Field.Type.ToLower().Trim() == "datetime"
                || Field.Type.ToLower().Trim() == "float" || Field.Type.ToLower().Trim() == "geography"
                || Field.Type.ToLower().Trim() == "geometry" || Field.Type.ToLower().Trim() == "hierarchyid"
                || Field.Type.ToLower().Trim() == "image" || Field.Type.ToLower().Trim() == "int"
                || Field.Type.ToLower().Trim() == "money" || Field.Type.ToLower().Trim() == "ntext"
                || Field.Type.ToLower().Trim() == "real" || Field.Type.ToLower().Trim() == "smalldatetime"
                || Field.Type.ToLower().Trim() == "smallint" || Field.Type.ToLower().Trim() == "smallmoney"
                || Field.Type.ToLower().Trim() == "sql_variant" || Field.Type.ToLower().Trim() == "text"
                || Field.Type.ToLower().Trim() == "timestamp" || Field.Type.ToLower().Trim() == "tinyint"
                || Field.Type.ToLower().Trim() == "uniqueidentifier" || Field.Type.ToLower().Trim() == "xml"
                )
            {
                return "\t" + _Name + " " + _Type + " " + _IsNull + " " + _DefaultVal + ", " + _CTName + "\r\n";
            }
            else
            {
                return "\t" + _Name + " " + _Type + " " + _Length + " " + _IsNull + " " + _DefaultVal + ", " + _CTName + "\r\n";
            }
        }
        
    }
}
