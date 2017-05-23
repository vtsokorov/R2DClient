using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using VncSharp;

#region
/// <summary>
/// WRITTEN BY TSOKOROV V.V. 22/02/2016
/// </summary>
#endregion

using VNCClientWidget = VncSharp.RemoteDesktop;

namespace R2DClient
{
    public abstract class RemoteAbstractWidget
    {
        protected string password;
        protected string login;
        protected string host;
        protected string port;

        public RemoteAbstractWidget() { }

        public abstract void connect();
        public abstract void disconnect();
        public abstract string isClient();

        public virtual bool setData(DataRow row)
        {
            host = Convert.ToString(row["ip"]);
            port = Convert.ToString(row["port"]); 
            login = Convert.ToString(row["login"]);
            password = Helper.XorString(Convert.ToString(row["password"]), 45, true);

            return true;
        }

        public virtual bool isSendKeysEnable()
        {
            return false;
        }

        public string getPassword()
        {
            return password; 
        }

        public string getLogin()
        {
            return login;
        }

        public string getPort()
        {
            return port;
        }

        public string getHost()
        {
            return host;
        }
    }

    public class RemoteRDPClient : RemoteAbstractWidget
    {
        private RdpClientWidget rdpDesktop;

        public RemoteRDPClient() : base()
        {
            System.ComponentModel.ComponentResourceManager resources
                = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            rdpDesktop = new RdpClientWidget();
            ((System.ComponentModel.ISupportInitialize)(this.rdpDesktop)).BeginInit();
            rdpDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            rdpDesktop.Enabled = true;
            rdpDesktop.Visible = true;
            rdpDesktop.Location = new System.Drawing.Point(0, 0);
            rdpDesktop.Name = "rdpDesktop";
            rdpDesktop.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdpDesktop.OcxState")));
            rdpDesktop.TabIndex = 0;
        }

        public RdpClientWidget Widget
        {
            get { return rdpDesktop; }
        }

        public override void connect()
        {
            try
            {
                rdpDesktop.Server = this.getHost();
                rdpDesktop.AdvancedSettings2.ClearTextPassword = this.getPassword();
                rdpDesktop.UserName = this.getLogin();
                rdpDesktop.AdvancedSettings2.DisableCtrlAltDel = 0;
                rdpDesktop.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Unable to connect to host.  Error was: {0}", ex.Message),
                                string.Format("Unable to Connect to {0}", host),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        public override void disconnect()
        {
            rdpDesktop.Disconnect();
        }

        public override string isClient()
        {
            return "RDP";
        }

        public void setColorDepth(int colorDepth)
        {
            rdpDesktop.ColorDepth = colorDepth;
        }

        public void setDesktopSize(DesktopSize size)
        {
            rdpDesktop.DesktopWidth = size.DesktopWidth;
            rdpDesktop.DesktopHeight = size.DesktopHeight;
        }

        public override bool setData(DataRow row)
        {
            base.setData(row);

            if (login == string.Empty){
                GetStringData.dataTitle = "Введите имя пользователя";
                login = GetStringData.getUserName();
            }

            if (password == string.Empty){ 
                GetStringData.dataTitle = "Введите пароль пользователя";
                password = GetStringData.getPassword();
            }

            return login != string.Empty && password != string.Empty ? true : false;
        }
    }

    public class RemoteVNCClient : RemoteAbstractWidget
    {
        private VNCClientWidget vncDesktop;

        public RemoteVNCClient() : base()
        {
            vncDesktop = new VNCClientWidget();
            vncDesktop.Enabled = true;
            vncDesktop.Visible = true;
            vncDesktop.AutoScroll = true;
            vncDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            vncDesktop.Location = new System.Drawing.Point(0, 0);
            vncDesktop.Name = "vncDesktop";
            vncDesktop.TabIndex = 0;
            vncDesktop.GetPassword = base.getPassword;
            vncDesktop.SetScalingMode(true);
        }

        public VNCClientWidget Widget
        {
            get { return vncDesktop; }
        }

        public override void connect()
        {
            if (host != null)
            {
                try
                {
                    vncDesktop.VncPort = Convert.ToInt32(base.getPort());
                    vncDesktop.Connect(host, false, true);
                    if (vncDesktop.IsConnected)
                    {
                        vncDesktop.SetScalingMode(true);
                        vncDesktop.FullScreenUpdate();

                    }
                    else
                        MessageBox.Show("Не удается осуществить соединение. Проверьте правильность ввода пароля", "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (VncProtocolException vex)
                {
                    MessageBox.Show(string.Format("Unable to connect to VNC host:\n\n{0}.\n\nCheck that a VNC host is running there.", vex.Message),
                                    string.Format("Unable to Connect to {0}", host),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Unable to connect to host.  Error was: {0}", ex.Message),
                                    string.Format("Unable to Connect to {0}", host),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }

        public override void disconnect()
        {
            if (vncDesktop.IsConnected)  vncDesktop.Disconnect();
        }

        public override string isClient()
        {
            return "VNC";
        }

        public override bool setData(DataRow row)
        {
            base.setData(row);

            if (port == string.Empty)
            {
                GetStringData.dataTitle = "Введите номер порта";
                port = GetStringData.getPort();
            }

            if (password == string.Empty)
            {
                GetStringData.dataTitle = "Введите пароль VNC сервер";
                password = GetStringData.getPassword();
            }

            return port != string.Empty && password != string.Empty ? true : false;
        }

        public override bool isSendKeysEnable()
        {
            return true;
        }

    }
}
