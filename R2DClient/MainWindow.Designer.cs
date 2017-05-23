namespace R2DClient
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rdpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsRDPMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vncMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendKeysVNCMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_alt_delVNCMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrl_escVNCMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alt_f4VNCMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlVNCMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altVNCMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyClipboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addHostButton = new System.Windows.Forms.ToolStripButton();
            this.editHostBotton = new System.Windows.Forms.ToolStripButton();
            this.deleteHostBotton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.connectBotton = new System.Windows.Forms.ToolStripButton();
            this.disconnectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cbVariantClient = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addHostMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editHostStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rdpConnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vncConnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.ipList = new R2DClient.IListBox();
            this.tabControl = new R2DClient.CloseableTabControl();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.clientMenuItem,
            this.helpMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(856, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileMenuItem.Text = "Файл";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openMenuItem.Image")));
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openMenuItem.Text = "Открыть";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitMenuItem.Image")));
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitMenuItem.Text = "Выход";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // clientMenuItem
            // 
            this.clientMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rdpMenuItem,
            this.vncMenuItem});
            this.clientMenuItem.Name = "clientMenuItem";
            this.clientMenuItem.Size = new System.Drawing.Size(58, 20);
            this.clientMenuItem.Text = "Клиент";
            // 
            // rdpMenuItem
            // 
            this.rdpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsRDPMenuItem});
            this.rdpMenuItem.Name = "rdpMenuItem";
            this.rdpMenuItem.Size = new System.Drawing.Size(98, 22);
            this.rdpMenuItem.Text = "RDP";
            // 
            // settingsRDPMenuItem
            // 
            this.settingsRDPMenuItem.Name = "settingsRDPMenuItem";
            this.settingsRDPMenuItem.Size = new System.Drawing.Size(166, 22);
            this.settingsRDPMenuItem.Text = "Свойства экрана";
            this.settingsRDPMenuItem.Click += new System.EventHandler(this.settingsRDPMenuItem_Click);
            // 
            // vncMenuItem
            // 
            this.vncMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendKeysVNCMenuItem,
            this.copyClipboardMenuItem});
            this.vncMenuItem.Name = "vncMenuItem";
            this.vncMenuItem.Size = new System.Drawing.Size(98, 22);
            this.vncMenuItem.Text = "VNC";
            // 
            // sendKeysVNCMenuItem
            // 
            this.sendKeysVNCMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrl_alt_delVNCMenuItem,
            this.ctrl_escVNCMenuItem,
            this.alt_f4VNCMenuItem,
            this.ctrlVNCMenuItem,
            this.altVNCMenuItem});
            this.sendKeysVNCMenuItem.Name = "sendKeysVNCMenuItem";
            this.sendKeysVNCMenuItem.Size = new System.Drawing.Size(232, 22);
            this.sendKeysVNCMenuItem.Text = "Отправть сочитание клавиш";
            // 
            // ctrl_alt_delVNCMenuItem
            // 
            this.ctrl_alt_delVNCMenuItem.Name = "ctrl_alt_delVNCMenuItem";
            this.ctrl_alt_delVNCMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ctrl_alt_delVNCMenuItem.Text = "CTRL + ALT + DEL";
            this.ctrl_alt_delVNCMenuItem.Click += new System.EventHandler(this.ctrl_alt_delVNCMenuItem_Click);
            // 
            // ctrl_escVNCMenuItem
            // 
            this.ctrl_escVNCMenuItem.Name = "ctrl_escVNCMenuItem";
            this.ctrl_escVNCMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ctrl_escVNCMenuItem.Text = "CTRL + ESC";
            this.ctrl_escVNCMenuItem.Click += new System.EventHandler(this.ctrl_escVNCMenuItem_Click);
            // 
            // alt_f4VNCMenuItem
            // 
            this.alt_f4VNCMenuItem.Name = "alt_f4VNCMenuItem";
            this.alt_f4VNCMenuItem.Size = new System.Drawing.Size(171, 22);
            this.alt_f4VNCMenuItem.Text = "ALT + F4";
            this.alt_f4VNCMenuItem.Click += new System.EventHandler(this.alt_f4VNCMenuItem_Click);
            // 
            // ctrlVNCMenuItem
            // 
            this.ctrlVNCMenuItem.Name = "ctrlVNCMenuItem";
            this.ctrlVNCMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ctrlVNCMenuItem.Text = "CTRL";
            this.ctrlVNCMenuItem.Click += new System.EventHandler(this.ctrlVNCMenuItem_Click);
            // 
            // altVNCMenuItem
            // 
            this.altVNCMenuItem.Name = "altVNCMenuItem";
            this.altVNCMenuItem.Size = new System.Drawing.Size(171, 22);
            this.altVNCMenuItem.Text = "ALT";
            this.altVNCMenuItem.Click += new System.EventHandler(this.altVNCMenuItem_Click);
            // 
            // copyClipboardMenuItem
            // 
            this.copyClipboardMenuItem.Name = "copyClipboardMenuItem";
            this.copyClipboardMenuItem.Size = new System.Drawing.Size(232, 22);
            this.copyClipboardMenuItem.Text = "Копировать буффер обмена";
            this.copyClipboardMenuItem.Click += new System.EventHandler(this.copyClipboardMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpMenuItem.Text = "Справка";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutMenuItem.Image")));
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutMenuItem.Text = "О программе";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 554);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(856, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addHostButton,
            this.editHostBotton,
            this.deleteHostBotton,
            this.toolStripSeparator1,
            this.connectBotton,
            this.disconnectButton,
            this.toolStripSeparator2,
            this.cbVariantClient});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(856, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // addHostButton
            // 
            this.addHostButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addHostButton.Image = ((System.Drawing.Image)(resources.GetObject("addHostButton.Image")));
            this.addHostButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addHostButton.Name = "addHostButton";
            this.addHostButton.Size = new System.Drawing.Size(23, 22);
            this.addHostButton.Text = "Добавить данные хоста";
            this.addHostButton.Click += new System.EventHandler(this.addHostButton_Click);
            // 
            // editHostBotton
            // 
            this.editHostBotton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editHostBotton.Image = ((System.Drawing.Image)(resources.GetObject("editHostBotton.Image")));
            this.editHostBotton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editHostBotton.Name = "editHostBotton";
            this.editHostBotton.Size = new System.Drawing.Size(23, 22);
            this.editHostBotton.Text = "Редактировать данные хоста";
            this.editHostBotton.Click += new System.EventHandler(this.editHostBotton_Click);
            // 
            // deleteHostBotton
            // 
            this.deleteHostBotton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteHostBotton.Image = ((System.Drawing.Image)(resources.GetObject("deleteHostBotton.Image")));
            this.deleteHostBotton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteHostBotton.Name = "deleteHostBotton";
            this.deleteHostBotton.Size = new System.Drawing.Size(23, 22);
            this.deleteHostBotton.Text = "Удалить данные хоста";
            this.deleteHostBotton.Click += new System.EventHandler(this.deleteHostBotton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // connectBotton
            // 
            this.connectBotton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.connectBotton.Image = ((System.Drawing.Image)(resources.GetObject("connectBotton.Image")));
            this.connectBotton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectBotton.Name = "connectBotton";
            this.connectBotton.Size = new System.Drawing.Size(23, 22);
            this.connectBotton.Text = "Осуществить соединение с хостом";
            this.connectBotton.Click += new System.EventHandler(this.connectBotton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.disconnectButton.Image = ((System.Drawing.Image)(resources.GetObject("disconnectButton.Image")));
            this.disconnectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(23, 22);
            this.disconnectButton.Text = "Разорвать соединение";
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cbVariantClient
            // 
            this.cbVariantClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariantClient.Items.AddRange(new object[] {
            "RDP",
            "VNC"});
            this.cbVariantClient.Name = "cbVariantClient";
            this.cbVariantClient.Size = new System.Drawing.Size(121, 25);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(0, 49);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer.Panel1MinSize = 0;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl);
            this.splitContainer.Panel2MinSize = 600;
            this.splitContainer.Size = new System.Drawing.Size(856, 505);
            this.splitContainer.SplitterDistance = 147;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ipList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(147, 505);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список хостов";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addHostMenuItem,
            this.editHostStripMenuItem,
            this.deleteMenuItem,
            this.rdpConnectMenuItem,
            this.vncConnectMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 114);
            // 
            // addHostMenuItem
            // 
            this.addHostMenuItem.Name = "addHostMenuItem";
            this.addHostMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addHostMenuItem.Text = "Добавить хост";
            this.addHostMenuItem.Click += new System.EventHandler(this.addHostMenuItem_Click);
            // 
            // editHostStripMenuItem
            // 
            this.editHostStripMenuItem.Name = "editHostStripMenuItem";
            this.editHostStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editHostStripMenuItem.Text = "Редактировать хост";
            this.editHostStripMenuItem.Click += new System.EventHandler(this.editHostStripMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteMenuItem.Text = "Удалить хост";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // rdpConnectMenuItem
            // 
            this.rdpConnectMenuItem.Name = "rdpConnectMenuItem";
            this.rdpConnectMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rdpConnectMenuItem.Text = "RDP соединение";
            this.rdpConnectMenuItem.Click += new System.EventHandler(this.rdpConnectMenuItem_Click);
            // 
            // vncConnectMenuItem
            // 
            this.vncConnectMenuItem.Name = "vncConnectMenuItem";
            this.vncConnectMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vncConnectMenuItem.Text = "VNC соединение";
            this.vncConnectMenuItem.Click += new System.EventHandler(this.vncConnectMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "generic_pc.png");
            // 
            // ipList
            // 
            this.ipList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipList.ContextMenuStrip = this.contextMenuStrip;
            this.ipList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ipList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipList.ImageList = this.imageList;
            this.ipList.ItemHeight = 15;
            this.ipList.Location = new System.Drawing.Point(1, 30);
            this.ipList.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.ipList.Name = "ipList";
            this.ipList.Size = new System.Drawing.Size(156, 469);
            this.ipList.TabIndex = 2;
            this.ipList.DoubleClick += new System.EventHandler(this.openHostEdit);
            // 
            // tabControl
            // 
            this.tabControl.ButtonWidth = 16;
            this.tabControl.CloseButtonColor = System.Drawing.Color.Red;
            this.tabControl.CrossOffset = 3;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.ItemSize = new System.Drawing.Size(0, 24);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(16, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(707, 505);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabStop = false;
            this.tabControl.TabClosing += new R2DClient.CloseableTabControl.TabClosingDelegate(this.closeTab);
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.selectTab);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 576);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "R2DClient";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SplitContainer splitContainer;
        private R2DClient.CloseableTabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rdpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsRDPMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vncMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendKeysVNCMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctrl_alt_delVNCMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctrl_escVNCMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alt_f4VNCMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctrlVNCMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altVNCMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addHostMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editHostStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ImageList imageList;
        //private R2DClient.IListBox ipList;
        private System.Windows.Forms.ToolStripMenuItem rdpConnectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vncConnectMenuItem;
        private System.Windows.Forms.ToolStripButton addHostButton;
        private System.Windows.Forms.ToolStripButton editHostBotton;
        private System.Windows.Forms.ToolStripButton deleteHostBotton;
        private System.Windows.Forms.ToolStripButton connectBotton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton disconnectButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox cbVariantClient;
        private System.Windows.Forms.ToolStripMenuItem copyClipboardMenuItem;
        private IListBox ipList;
    }
}

