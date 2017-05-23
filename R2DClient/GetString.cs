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
    public partial class GetString : Form
    {
        public GetString()
        {
            InitializeComponent();
        }

        public string StringData
        {
            get { return tbStringData.Text;  }
            set { tbStringData.Text = value; }
        }

        public DialogResult ShowDialog(string title)
        {
            this.Text = title;
            return base.ShowDialog();
        }

        public void inputPassword(bool flag)
        {
            tbStringData.UseSystemPasswordChar = flag;
        }
    }

    public class GetStringData
    {
        private static string title;

        public static string dataTitle
        {
            get { return title;  }
            set { title = value; }
        }

        public static string getPassword()
        { 
            GetString dlg = new GetString();
            dlg.inputPassword(true);
            DialogResult result = dlg.ShowDialog(title);
            if(result == DialogResult.OK)
                return dlg.StringData;
            return string.Empty;
        }

        public static string getUserName()
        {
            GetString dlg = new GetString();
            DialogResult result = dlg.ShowDialog(title);
            if (result == DialogResult.OK)
                return dlg.StringData;
            return string.Empty;
        }

        public static string getPort()
        {
            GetString dlg = new GetString();
            DialogResult result = dlg.ShowDialog(title);
            if (result == DialogResult.OK)
                return dlg.StringData;
            return string.Empty;
        }
    }
}
