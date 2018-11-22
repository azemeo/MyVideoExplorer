using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Input;

namespace MyVideoExplorer
{
    public partial class MyTooltip : Form
    {
        private System.Windows.Forms.Timer closeTimer;
        private Control sourceControl;

        public event EventHandler<MyTooltipEventArgs> TooltipOpened;
        public event EventHandler<MyTooltipEventArgs> TooltipClosed;


        public class MyTooltipEventArgs : EventArgs
        {
            private string message;

            public string Message
            {
                get { return message; }
                set { message = value; }
            }
            public MyTooltipEventArgs(string message)
            {
                this.message = message;
            }

        }

        public MyTooltip()
        {
            InitializeComponent();
        }

        private void richTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            MyLink.OpenLink(e.LinkText);
        }


        private void OnTooltopOpened(MyTooltipEventArgs e)
        {
            if (TooltipOpened != null)
            {
                TooltipOpened(this, e);
            }
        }

        private void OnTooltopClosed(MyTooltipEventArgs e)
        {
            if (TooltipClosed != null)
            {
                TooltipClosed(this, e);
            }
        }

        private void sourceControl_MouseLeave(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                // this.Show();
            }
            else
            {
                this.CloseTooltip();
            }
        }

        private void sourceControl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Control control = (Control)sender;
            if (sourceControl.ClientRectangle.Contains(e.Location))
            {
                if (!this.Visible)
                {
                    this.Open();
                }
                else
                {
                    // this.Hide();
                }
            }
            else
            {
                if (!this.Visible)
                {
                    // this.Show();
                }
                else
                {
                    this.CloseTooltip();
                }
            }
        }

        private void Open()
        {
            Point position = Control.MousePosition;

            int left = Convert.ToInt32(position.X);
            int top = Convert.ToInt32(position.Y);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(left, top);

            this.Show();
            OnTooltopOpened(new MyTooltipEventArgs("test"));
        }

        private void CloseTooltip()
        {
            closeTimer = new System.Windows.Forms.Timer();
            closeTimer.Interval = 2000;
            closeTimer.Tick += closeTimer_Tick;
            closeTimer.Start();
            
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void SetToolTip(Control control, string tooltip)
        {


            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            // this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // no title bar
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //fm.Text = "Test";
            this.TopMost = true;
            // this.Show();

            richTextBox.Text = tooltip;

            sourceControl = control;
            sourceControl.MouseLeave += sourceControl_MouseLeave;
            sourceControl.MouseMove += new System.Windows.Forms.MouseEventHandler(sourceControl_MouseMove);
        }




    }
}
