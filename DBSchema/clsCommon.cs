using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSchema
{
    /// <summary>
    /// 元件定義
    /// </summary>
    class clsCommon
    {

        /// <summary>
        /// DB To Schema
        /// </summary>
        public static frmDBToSchema fDBToSchema;

        /// <summary>
        /// DB To Schema
        /// </summary>
        public static void f_ShowfDBToSchema(frmMain _mdi)
        {
            fDBToSchema = new frmDBToSchema();
            fDBToSchema.MdiParent = _mdi;
            fDBToSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            fDBToSchema.Show();
        }

        /// <summary>
        /// DB To Schema
        /// </summary>
        public static void f_ClosefDBToSchema()
        {
            fDBToSchema.Close();
        }

        /// <summary>
        /// Schema To DB
        /// </summary>
        public static frmSchemaToDB fSchemaToDB;

        /// <summary>
        /// Schema To DB
        /// </summary>
        public static void f_ShowfSchemaToDB(frmMain _mdi)
        {
            fSchemaToDB = new frmSchemaToDB();
            fSchemaToDB.MdiParent = _mdi;
            fSchemaToDB.Dock = System.Windows.Forms.DockStyle.Fill;
            fSchemaToDB.Show();
        }

        /// <summary>
        /// Schema To DB
        /// </summary>
        public static void f_ClosefSchemaToDB()
        {
            fSchemaToDB.Close();
        }

        /// <summary>
        /// 歡迎頁面
        /// </summary>
        public static frmWelcome fWelcome;

        /// <summary>
        /// 歡迎頁面
        /// </summary>
        public static void f_ShowfWelcome(frmMain _mdi)
        {
            fWelcome = new frmWelcome();
            fWelcome.MdiParent = _mdi;
            fWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            fWelcome.Show();
        }

        /// <summary>
        /// 歡迎頁面
        /// </summary>
        public static void f_ClosefWelcome()
        {
            fWelcome.Close();
        }

        /// <summary>
        /// 關於軟體
        /// </summary>
        public static frmAbout fAbout;

        /// <summary>
        /// 關於軟體
        /// </summary>
        public static void f_ShowfAbout(frmMain _mdi)
        {
            fAbout = new frmAbout();
            fAbout.MdiParent = _mdi;
            fAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            fAbout.Show();
        }

        /// <summary>
        /// 關於軟體
        /// </summary>
        public static void f_ClosefAbout()
        {
            fAbout.Close();
        }

    }
}
