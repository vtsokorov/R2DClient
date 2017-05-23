using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace R2DClient
{
    public partial class AddHostDialog : Form
    {
        private SQLiteInterface SQL;
        private DataTable table;
        private DataRow currentRow;
        private bool isNewRow;
        private string newHost;
        private int SelectedIndexInDataTable;

        public AddHostDialog(SQLiteInterface SQLite)
        {
            InitializeComponent();

            SQL = SQLite;
            table = SQL.dataTable("hostdata");
            isNewRow = false;
            newHost = string.Empty;
        }

        private void IniDataBindingDialog(DataRow row)
        {
            SelectedIndexInDataTable = table.Rows.IndexOf(row);
            this.BindingContext[SQL.dataSet(), "hostdata"].Position = SelectedIndexInDataTable;

            tbHost.DataBindings.Add("Text", SQL.dataSet(), "hostdata.ip");
            tbPort.DataBindings.Add("Text", SQL.dataSet(), "hostdata.port");
            tbLogin.DataBindings.Add("Text", SQL.dataSet(), "hostdata.login");
            tbPassword.DataBindings.Add("Text", SQL.dataSet(), "hostdata.password");
        }

        public DialogResult ShowDialog(DataRow row)
        {
            currentRow = row;
            IniDataBindingDialog(currentRow);
            isNewRow = false;
            return base.ShowDialog();
        }

        public new DialogResult ShowDialog()
        {
            currentRow = SQL.dataTable("hostdata").NewRow();
            isNewRow = true;
            return base.ShowDialog();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (tbHost.Text == string.Empty) return;

            if (!isNewRow) currentRow.BeginEdit();

            newHost = tbHost.Text;
            currentRow["ip"] = tbHost.Text;
            currentRow["port"] = tbPort.Text;
            currentRow["login"] = tbLogin.Text;
            currentRow["password"] = Helper.XorString(tbPassword.Text, 45, true);

            if (isNewRow)
                SQL.dataTable("hostdata").Rows.Add(currentRow);
            else
                currentRow.EndEdit();

            SQL.save("hostdata");
        }

        public string getNewHost()
        {
            return newHost;
        }

        private void AddHostDialog_Load(object sender, EventArgs e)
        {
            cancelButton.Select();
        }
    }
}


            //tbPassword.DataBindings.Clear();
            //tbPassword.Text = Helper.XorString(currentRow["password"].ToString(), 45, true);
