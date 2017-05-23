using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

namespace R2DClient
{
    /// <summary>
    /// A tab control that can be used to close tabs with a custom drawn button.
    /// </summary>
    public class CloseableTabControl : System.Windows.Forms.TabControl
    {
        public CloseableTabControl()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            TabStop = false;
            DrawMode = TabDrawMode.OwnerDrawFixed;
            _closeButtonBrush = new SolidBrush(_closeButtonColor);
            ItemSize = new Size(ItemSize.Width, 24);
            // used to expand the tab header, find a better way
            Padding = new Point(16, 0);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _stringFormat.Dispose();
                _closeButtonBrush.Dispose();
            }
            base.Dispose(disposing);
        }

        public delegate void TabClosedDelegate(object sender, ClosedEventArgs e);
        public delegate void TabClosingDelegate(object sender, ClosingEventArgs e);
        public event TabClosedDelegate TabClosed;
        public event TabClosingDelegate TabClosing;
        private int _buttonWidth = 16;

        public int ButtonWidth
        {
            get { return _buttonWidth; }
            set { _buttonWidth = value; }
        }

        private int _crossOffset = 3;

        public int CrossOffset
        {
            get { return _crossOffset; }
            set { _crossOffset = value; }
        }

        private readonly StringFormat _stringFormat = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };

        private Color _closeButtonColor = Color.Red;
        private Brush _closeButtonBrush;

        public Color CloseButtonColor
        {
            get { return _closeButtonColor; }
            set
            {
                _closeButtonBrush.Dispose();
                _closeButtonColor = value;
                _closeButtonBrush = new SolidBrush(_closeButtonColor);
                Invalidate();
            }

        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Bounds != RectangleF.Empty)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                for (int nIndex = 0; nIndex < TabCount; nIndex++)
                {
                    Rectangle tabArea = GetTabRect(nIndex);
                    Rectangle closeBtnRect = GetCloseBtnRect(tabArea);
                    if (nIndex != SelectedIndex)
                    {
                        e.Graphics.DrawRectangle(Pens.DarkGray, closeBtnRect);
                        DrawCross(e, closeBtnRect, Color.DarkGray);
                    }
                    else
                    {
                       //Drawing Close Button
                        e.Graphics.FillRectangle(_closeButtonBrush, closeBtnRect);
                        e.Graphics.DrawRectangle(Pens.White, closeBtnRect);
                        DrawCross(e, closeBtnRect, Color.White);
                    }

                    string str = TabPages[nIndex].Text;
                    e.Graphics.DrawString(str, Font, new SolidBrush(TabPages[nIndex].ForeColor), tabArea, _stringFormat);
                }
            }
        }

        private void DrawCross(DrawItemEventArgs e, Rectangle btnRect, Color color)
        {
            using (Pen pen = new Pen(color, 2))
            {
                float x1 = btnRect.X + CrossOffset;
                float x2 = btnRect.Right - CrossOffset;
                float y1 = btnRect.Y + CrossOffset;
                float y2 = btnRect.Bottom - CrossOffset;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                e.Graphics.DrawLine(pen, x1, y2, x2, y1);
            }
        }

        private Rectangle GetCloseBtnRect(Rectangle tabRect)
        {
            Rectangle rect = new Rectangle(tabRect.X + tabRect.Width - ButtonWidth - 4, (tabRect.Height - ButtonWidth) / 2, ButtonWidth, ButtonWidth);
            return rect;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!DesignMode)
            {
                Rectangle rect = GetTabRect(SelectedIndex);
                rect = GetCloseBtnRect(rect);
                Point pt = new Point(e.X, e.Y);
                if (rect.Contains(pt))
                {
                    CloseTab(SelectedTab);
                }
            }
        }

        public void CloseTab(int tabindex)
        {
            CloseTab(TabPages[tabindex]);
        }

        public void CloseTab(TabPage tp)
        {
            ClosingEventArgs args = new ClosingEventArgs(TabPages.IndexOf(tp));
            OnTabClosing(args);
            //Remove the tab and fir the event tot he client
            if (!args.Cancel)
            {
                // close and remove the tab, dispose it too
                TabPages.Remove(tp);
                OnTabClosed(new ClosedEventArgs(tp));
                tp.Dispose();
            }
        }

        protected void OnTabClosed(ClosedEventArgs e)
        {
            if (TabClosed != null) {
                TabClosed(this, e);
            }
        }

        protected void OnTabClosing(ClosingEventArgs e)
        {
            if (TabClosing != null)
                TabClosing(this, e);
        }
    }

    public class ClosingEventArgs
    {

        private readonly int _nTabIndex = -1;
        public ClosingEventArgs(int nTabIndex)
        {
            _nTabIndex = nTabIndex;
            Cancel = false;
        }

        public bool Cancel { get; set; }

        /// <summary>
        /// Get/Set the tab index value where the close button is clicked
        /// </summary>
        public int TabIndex
        {
            get {
                return _nTabIndex;
            }
        }
    }

    public class ClosedEventArgs : EventArgs
    {
        private readonly TabPage _tab;
        public ClosedEventArgs(TabPage tab) {
            _tab = tab;
        }

        /// <summary>
        /// Get/Set the tab index value where the close button is clicked
        /// </summary>
        public TabPage Tab{
            get{
                return _tab;
            }
        }
    }
}
