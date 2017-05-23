using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;

#region
/// <summary>
/// WRITTEN BY TSOKOROV V.V. 22/02/2016
/// How to use this class:
/// SQLiteInterface SQL = new SQLiteInterface();
/// SQL.connectionString = "Data Source=database.db; Version=3;";
/// SQL.addTable(tableName);
/// SQL.fill(tableName);
/// DataTable table = SQL.dataTable(tableName);
/// </summary>
#endregion

namespace R2DClient
{
    public class  SQLiteInterface
    {
        private List<SQLiteDataAdapter> adapters;
        private SQLiteConnection connection;
        private DataSet memory_db;

        public SQLiteConnection ConnectionObject
        {
            get { return connection; }
        }

        public SQLiteInterface()
        {
            connection = new SQLiteConnection();
            adapters = new List<SQLiteDataAdapter>();
            memory_db = new DataSet();
        }

        public string connectionString
        {
            get { return connection.ConnectionString;  }
            set { connection.ConnectionString = value; }
        }

        public SQLiteInterface(string connectionString)
        {
            connection = new SQLiteConnection(connectionString);
            adapters = new List<SQLiteDataAdapter>();
            memory_db = new DataSet();
        }

        private bool openDataBase()
        {
            try
            {
                if (connection.ConnectionString.Length > 0)
                    connection.Open();
                else
                    throw new System.Exception("Строка соединения с БД не корректна.");
            }
            catch (System.Exception Except)
            {
                MessageBox.Show(Except.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return false;
            }
            return connection.State == System.Data.ConnectionState.Open ? true : false;
        }

        private bool closeDataBase()
        {
            try { connection.Close(); }
            catch (System.Exception Except)
            {
                MessageBox.Show(Except.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return connection.State == System.Data.ConnectionState.Closed ? true : false;
        }

        private bool isOpen()
        {
            return connection.State == System.Data.ConnectionState.Open ? true : false;
        }

        public void addTable(string tableName)
        {
            adapters.Add(new SQLiteDataAdapter());
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(adapters.Last());
            commandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
            memory_db.Tables.Add(new DataTable(tableName));
        }  

        public int tableIndex(string name)
        {
            try
            {
                int index = memory_db.Tables.IndexOf(name);
                if (index == -1)
                    throw new Exception("Таблицы с данным именем не существует");
                return index;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public string tableName(int index)
        {
            try
            {
                if (index >= 0 && index <= memory_db.Tables.Count - 1)
                    return memory_db.Tables[index].TableName;
                else
                    throw new Exception("Таблицы с данным индексом не существует");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public DataTable dataTable(string tableName)
        {
            int index = tableIndex(tableName);
            if (index != -1)
                return memory_db.Tables[index];
            else
                return null;
        }

        public SQLiteDataAdapter tableAdapter(string tableName)
        {
            int index = tableIndex(tableName);
            if (index != -1)
                return adapters[index];
            else
                return null;
        }

        public DataSet dataSet()
        {
            return memory_db;
        }

        private void fillSchema(string tableName)
        {
            try
            {
                int index = memory_db.Tables.IndexOf(tableName);
                if (index >= 0)
                {
                    adapters[index].SelectCommand = new SQLiteCommand("SELECT * FROM " + tableName, connection);
                    adapters[index].FillSchema(memory_db, System.Data.SchemaType.Mapped);
                }
                else
                    throw new Exception("Ошибка! Не верное имя таблици или строка соединения");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool fill(string tableName)
        {
            try
            {
                int index = memory_db.Tables.IndexOf(tableName);
                if (index >= 0 && index <= memory_db.Tables.Count - 1)
                {
                    if (memory_db.Tables.Contains(tableName))
                        memory_db.Tables[index].Clear();

                    if (!isOpen()) this.openDataBase();

                    this.fillSchema(tableName);
                    adapters[index].Fill(memory_db.Tables[tableName]);

                    this.closeDataBase();

                    return true;
                }
                else return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.closeDataBase();
                return false;
            }
        }

        public bool refill(string tableName)
        {
            try
            {
                int index = memory_db.Tables.IndexOf(tableName);
                if (index >= 0 && index <= memory_db.Tables.Count - 1)
                {
                    if (!isOpen()) this.openDataBase();

                    adapters[index].Fill(memory_db, tableName);

                    this.closeDataBase();

                    return true;
                }
                else return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.closeDataBase();
                return false;
            }
        }

        public bool save(string tableName)
        {
            if (!isOpen()) this.openDataBase();

            DataTable currentTable = dataTable(tableName);
            if (currentTable.GetChanges() == null) return false;

            try
            {
                tableAdapter(tableName).Update(currentTable.GetChanges());
                currentTable.AcceptChanges();
                this.closeDataBase();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удается сохранить запись", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentTable.RejectChanges();
                this.closeDataBase();
                return false;
            }
        }

        public DataTable executeQuery(string strQuery)
        {
            DataTable table = new DataTable("QUERY");
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(strQuery, connection);
            adapter.Fill(table);
            return table;
        }

        public void setRelation(string relationName, string parentTable, string primaryKey, string childrenTable, string forigenKey)
        {
            try {
                memory_db.Relations.Add(new DataRelation(relationName, dataTable(parentTable).Columns[primaryKey], dataTable(childrenTable).Columns[forigenKey], true));
            }
            catch (Exception e) {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearAll()
        {
            adapters.Clear();
            memory_db.Relations.Clear();
            memory_db.Tables.Clear();
            memory_db.Clear();
        }

        public void clear(int index)
        {
            try
            {
                string item = tableName(index);
                if (item != string.Empty)
                {
                    adapters.Remove(adapters[index]);
                    memory_db.Tables[index].Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clear(string tableName)
        {
            try
            {
                int index = tableIndex(tableName);
                if (index != -1)
                {
                    adapters.Remove(adapters[index]);
                    memory_db.Tables[index].Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataRow newRow(string table)
        {
            return this.dataTable(table).NewRow();
        }

        public bool addNewRow(string table, DataRow row)
        {
            this.dataTable(table).Rows.Add(row);
            return this.save(table);
        }

        public DataRow beginEditRow(string table, int indexRow)
        {
            DataRow currentRow = this.dataTable(table).Rows[indexRow];
            currentRow.BeginEdit();
            return currentRow;
        }

        public bool endEditRow(string table, DataRow row)
        {
            row.EndEdit();
            return this.save(table);
        }
    }
}
