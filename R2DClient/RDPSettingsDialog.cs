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
    public struct DesktopSize
    {
        public int DesktopWidth;
        public int DesktopHeight;
    }

    public partial class RDPSettingsDialog : Form
    {
        private DesktopSize ds = new DesktopSize();

        public RDPSettingsDialog()
        {
            InitializeComponent();
        }

        public void setSize(int index)
        {
            comboBoxSize.SelectedIndex = index;
        }

        public void setColor(int index)
        {
            comboBoxColor.SelectedIndex = index;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SettingsIni.IniWriteValue("RDP", "size", Convert.ToString(comboBoxSize.SelectedIndex));
            SettingsIni.IniWriteValue("RDP", "color", Convert.ToString(comboBoxColor.SelectedIndex));
            Close();
        }

        private void RDPSettingsDialog_Load(object sender, EventArgs e)
        {
            cancelButton.Select();
        }

        public int getColorDepth()
        {
            switch (comboBoxColor.SelectedIndex)
            {
                case 0: return 15;
                case 1: return 16;
                case 2: return 24;
                case 3: return 32;
                default: return 32;
            }
        }

        public DesktopSize getDesktopSize()
        {

            switch (comboBoxSize.SelectedIndex) 
            {
                case 0:
                    ds.DesktopWidth = 640;
                    ds.DesktopHeight = 480;
                    break;
                case 1:
                    ds.DesktopWidth = 800;
                    ds.DesktopHeight = 600;
                    break;
                case 2:
                    ds.DesktopWidth = 1024;
                    ds.DesktopHeight = 768;
                    break;
                case 3:
                    ds.DesktopWidth = 1120;
                    ds.DesktopHeight = 700;
                    break;
                case 4:
                    ds.DesktopWidth = 1280;
                    ds.DesktopHeight = 1024;
                    break;
                default:
                    ds.DesktopWidth = 1024;
                    ds.DesktopHeight = 768;
                    break;
            }
            return ds;
        }
    }
}
