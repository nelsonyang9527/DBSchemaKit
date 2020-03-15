using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSchema
{
    /// <summary>
    /// 程式框架
    /// </summary>
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            clsCommon.f_ShowfWelcome(this);
        }

        /// <summary>
        /// DB To Schema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDBToSchema_Click(object sender, EventArgs e)
        {
            clsCommon.f_ShowfDBToSchema(this);
        }

        /// <summary>
        /// Schema To DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSchemaToDB_Click(object sender, EventArgs e)
        {
            clsCommon.f_ShowfSchemaToDB(this);
        }

        /// <summary>
        /// 關於軟體
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbout_Click(object sender, EventArgs e)
        {
            clsCommon.f_ShowfAbout(this);
        }

    }
}
