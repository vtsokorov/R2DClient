using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RDPFileReader;
using VncSharp;

namespace R2DClient
{
    public partial class MainWindow : Form
    {
        private RDPSettingsDialog RDPSettingsDlg = new RDPSettingsDialog();
        private SQLiteInterface SQL = new SQLiteInterface();
        private List<RemoteAbstractWidget> widgets;

        public MainWindow()
        {
            InitializeComponent();

            widgets = new List<RemoteAbstractWidget>();

            cbVariantClient.SelectedIndex = 0;

            closeMenu();
            
            RDPSettingsDlg.setSize(Convert.ToInt32(SettingsIni.IniReadValue("RDP", "size")));
            RDPSettingsDlg.setColor(Convert.ToInt32(SettingsIni.IniReadValue("RDP", "color")));

            SQL.connectionString = "Data Source=hosts.db; Version=3;";
            SQL.addTable("hostdata");
            SQL.fill("hostdata");
            DataTable table = SQL.dataTable("hostdata");
            for (int i = 0; i < table.Rows.Count; ++i)
                ipList.Items.Add(new IListBoxItem(table.Rows[i][1].ToString(), 0));
            ipList.SelectedIndex = 0;
        }

        private void settingsRDPMenuItem_Click(object sender, EventArgs e)
        {
            RDPSettingsDlg.setSize(Convert.ToInt32(SettingsIni.IniReadValue("RDP", "size")));
            RDPSettingsDlg.setColor(Convert.ToInt32(SettingsIni.IniReadValue("RDP", "color")));
            RDPSettingsDlg.ShowDialog();
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            DataTable table = SQL.dataTable("hostdata");
            table.Rows[ipList.SelectedIndex].Delete();
            SQL.save("hostdata");
            ipList.Items.RemoveAt(ipList.SelectedIndex);
        }

        private void deleteHostBotton_Click(object sender, EventArgs e)
        {
            deleteMenuItem_Click(sender, e);
        }

        private void addHostMenuItem_Click(object sender, EventArgs e)
        {
            AddHostDialog HostDlg = new AddHostDialog(SQL);
            HostDlg.ShowDialog();
            string newHost = HostDlg.getNewHost();
            if (newHost != string.Empty)
                ipList.Items.Add(new IListBoxItem(newHost, 0));
        }

        private void addHostButton_Click(object sender, EventArgs e)
        {
            addHostMenuItem_Click(sender, e);
        }

        private void editHostStripMenuItem_Click(object sender, EventArgs e)
        {
            AddHostDialog HostDlg = new AddHostDialog(SQL);
            DataTable table = SQL.dataTable("hostdata");
            DataRow row = table.Rows[ipList.SelectedIndex];
            HostDlg.ShowDialog(row);
            string newHost = HostDlg.getNewHost();
            if (newHost != string.Empty)
                ipList.Items[ipList.SelectedIndex] = new IListBoxItem(newHost, 0);
        }

        private void openHostEdit(object sender, EventArgs e)
        {
            editHostStripMenuItem_Click(sender, e);
        }

        private void editHostBotton_Click(object sender, EventArgs e)
        {
            editHostStripMenuItem_Click(sender, e);
        }

        private void rdpConnectMenuItem_Click(object sender, EventArgs e)
        {
            RemoteRDPClient client = new RemoteRDPClient();
            widgets.Add(client);

            TabPage NewPage = new TabPage();
            NewPage.Text = Convert.ToString(ipList.Items[ipList.SelectedIndex]);

            NewPage.Controls.Add(client.Widget);
            tabControl.TabPages.Add(NewPage);
            tabControl.SelectedIndex = tabControl.TabCount - 1;

            DataTable table = SQL.dataTable("hostdata");
            DataRow row = table.Rows[ipList.SelectedIndex];

            if (client.setData(row))
            {
                closeMenu(client);
                client.setColorDepth(RDPSettingsDlg.getColorDepth());
                client.setDesktopSize(RDPSettingsDlg.getDesktopSize());
                client.connect();
            }
            else disconnectButton_Click(sender, e);
        }

        private void vncConnectMenuItem_Click(object sender, EventArgs e)
        {
            RemoteVNCClient client = new RemoteVNCClient();
            widgets.Add(client);

            TabPage NewPage = new TabPage();
            NewPage.Text = Convert.ToString(ipList.Items[ipList.SelectedIndex]);
            NewPage.Controls.Add(client.Widget);
            tabControl.TabPages.Add(NewPage);
            tabControl.SelectedIndex = tabControl.TabCount - 1;

            DataTable table = SQL.dataTable("hostdata");
            DataRow row = table.Rows[ipList.SelectedIndex];

            if (client.setData(row))
            {
                closeMenu(client);
                client.connect();
            }
            else
                disconnectButton_Click(sender, e);
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpenFileDialog;
            myOpenFileDialog = new OpenFileDialog();
            myOpenFileDialog.Filter = "RDP File|*.rdp";
            myOpenFileDialog.Title = "Выбор файла с настройками RDP";
            myOpenFileDialog.ShowDialog();

            if (myOpenFileDialog.FileNames.Count() > 0)
            {
                RDPFile MyRdpFile = new RDPFile();
                MyRdpFile.Read(myOpenFileDialog.FileName);

                if (MyRdpFile.FullAddress != string.Empty)
                {
                    DataRow row = SQL.newRow("hostdata");
                    row["ip"] = MyRdpFile.FullAddress;
                    row["port"] = string.Empty;
                    row["login"] = MyRdpFile.Username;
                    row["password"] = Helper.XorString(MyRdpFile.Password, 45, true);
                    SQL.addNewRow("hostdata", row);
                    ipList.Items.Add(new IListBoxItem(MyRdpFile.FullAddress, 0));
                }
            }
        }

        private void closeTab(object sender, ClosingEventArgs e)
        {
            if (tabControl.SelectedIndex >= 0)
            {
                RemoteAbstractWidget aWidget = widgets[tabControl.SelectedIndex];
                aWidget.disconnect();
                widgets.RemoveAt(tabControl.SelectedIndex);
                tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex >= 0)
            {
                RemoteAbstractWidget aWidget = widgets[tabControl.SelectedIndex];
                aWidget.disconnect();
                widgets.RemoveAt(tabControl.SelectedIndex);
                tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
            }

            if (tabControl.SelectedIndex != -1)
            {
                RemoteAbstractWidget aWidget = widgets[tabControl.SelectedIndex];
                closeMenu(aWidget);
            }
            else closeMenu();
        }

        private void connectBotton_Click(object sender, EventArgs e)
        {
            if(cbVariantClient.SelectedIndex == 0)
                rdpConnectMenuItem_Click(sender, e);
            if (cbVariantClient.SelectedIndex == 1)
                vncConnectMenuItem_Click(sender, e);
        }

        private void ctrl_alt_delVNCMenuItem_Click(object sender, EventArgs e)
        {
            RemoteAbstractWidget aWidget = widgets[tabControl.SelectedIndex];
            if (aWidget.isClient() == "VNC")
            {
                RemoteVNCClient client = (RemoteVNCClient)aWidget;
                if (client.Widget.IsConnected)
                    client.Widget.SendSpecialKeys(SpecialKeys.CtrlAltDel);

            }
        }

        private void ctrl_escVNCMenuItem_Click(object sender, EventArgs e)
        {
            RemoteAbstractWidget aWidget = widgets[tabControl.SelectedIndex];
            if (aWidget.isClient() == "VNC")
            {
                RemoteVNCClient client = (RemoteVNCClient)aWidget;
                if (client.Widget.IsConnected)
                    client.Widget.SendSpecialKeys(SpecialKeys.CtrlEsc);

            }
        }

        private void alt_f4VNCMenuItem_Click(object sender, EventArgs e)
        {
            RemoteAbstractWidget aWidget = widgets[tabControl.SelectedIndex];
            if (aWidget.isClient() == "VNC")
            {
                RemoteVNCClient client = (RemoteVNCClient)aWidget;
                if (client.Widget.IsConnected)
                    client.Widget.SendSpecialKeys(SpecialKeys.AltF4);

            }
        }

        private void ctrlVNCMenuItem_Click(object sender, EventArgs e)
        {
            RemoteAbstractWidget aWidget = widgets[tabControl.SelectedIndex];
            if (aWidget.isClient() == "VNC")
            {
                RemoteVNCClient client = (RemoteVNCClient)aWidget;
                if (client.Widget.IsConnected)
                    client.Widget.SendSpecialKeys(SpecialKeys.Ctrl, false /* don't release CTRL */);

            }
        }

        private void altVNCMenuItem_Click(object sender, EventArgs e)
        {
            RemoteAbstractWidget aWidget = widgets[tabControl.SelectedIndex];
            if (aWidget.isClient() == "VNC")
            {
                RemoteVNCClient client = (RemoteVNCClient)aWidget;
                if (client.Widget.IsConnected)
                    client.Widget.SendSpecialKeys(SpecialKeys.Alt, false /* don't release ALT */);

            }
        }

        private void copyClipboardMenuItem_Click(object sender, EventArgs e)
        {
            RemoteAbstractWidget aWidget = widgets[tabControl.SelectedIndex];
            if (aWidget.isClient() == "VNC")
            {
                RemoteVNCClient client = (RemoteVNCClient)aWidget;
                if (client.Widget.IsConnected)
                {
                    client.Widget.FillServerClipboard();

                    MessageBox.Show(this, "Буффер обмена скопированн на локальный хост",
                                    "Копирование буффера обмена",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                }
            }
        }

        private void closeMenu(RemoteAbstractWidget aWidget)
        {
            if (aWidget.isClient() == "RDP")
            {
                vncMenuItem.Enabled = false;
                sendKeysVNCMenuItem.Enabled = false;
                ctrl_alt_delVNCMenuItem.Enabled = false;
                ctrl_escVNCMenuItem.Enabled = false;
                alt_f4VNCMenuItem.Enabled = false;
                ctrlVNCMenuItem.Enabled = false;
                altVNCMenuItem.Enabled = false;
                copyClipboardMenuItem.Enabled = false;

                rdpMenuItem.Enabled = true;
                settingsRDPMenuItem.Enabled = true;

                cbVariantClient.SelectedIndex = 0;
            }

            if (aWidget.isClient() == "VNC")
            {
                vncMenuItem.Enabled = true;
                vncMenuItem.Enabled = true;
                sendKeysVNCMenuItem.Enabled = true;
                ctrl_alt_delVNCMenuItem.Enabled = true;
                ctrl_escVNCMenuItem.Enabled = true;
                alt_f4VNCMenuItem.Enabled = true;
                ctrlVNCMenuItem.Enabled = true;
                altVNCMenuItem.Enabled = true;
                copyClipboardMenuItem.Enabled = true;

                rdpMenuItem.Enabled = false;
                settingsRDPMenuItem.Enabled = false;

                cbVariantClient.SelectedIndex = 1;
            }

        }

        private void closeMenu()
        {
            vncMenuItem.Enabled = false;
            sendKeysVNCMenuItem.Enabled = false;
            ctrl_alt_delVNCMenuItem.Enabled = false;
            ctrl_escVNCMenuItem.Enabled = false;
            alt_f4VNCMenuItem.Enabled = false;
            ctrlVNCMenuItem.Enabled = false;
            altVNCMenuItem.Enabled = false;
            copyClipboardMenuItem.Enabled = false;
            rdpMenuItem.Enabled = true;
            settingsRDPMenuItem.Enabled = true;
        }

        private void selectTab(object sender, TabControlEventArgs e)
        {
            if (tabControl.SelectedIndex != -1)
            {
                RemoteAbstractWidget aWidget = widgets[tabControl.SelectedIndex];
                closeMenu(aWidget);

                if (aWidget.isClient() == "RDP"){
                    RemoteRDPClient client = (RemoteRDPClient)aWidget;
                    tabControl.TabPages[tabControl.SelectedIndex].Update();
                    client.Widget.Update();
                }
                if (aWidget.isClient() == "VNC"){
                    RemoteVNCClient client = (RemoteVNCClient)aWidget;
                    client.Widget.Update();
                }
            }
            else closeMenu();
     
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tabControl.TabCount; ++i)
                disconnectButton_Click(sender, e);
            Close();
        }
    }
}
