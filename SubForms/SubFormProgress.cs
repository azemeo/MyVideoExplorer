using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace MyVideoExplorer
{
    public partial class SubFormProgress : UserControl
    {

        public SubFormProgress()
        {
            InitializeComponent();
        }

        private void SubFormProgress_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(160, 60);

            progressBar.Width = 160;
            progressBar.Dock = DockStyle.Bottom;

            SetTextAlignment(ContentAlignment.MiddleLeft);

            Text("");
        }


        private void labelProgress_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// sets max value for percentage bar
        /// </summary>
        /// <param name="value"></param>
        public void Maximum(int value)
        {
            ProgressBar_SetMaximum(value);
        }
        private void ProgressBar_SetMaximum(int value)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = value;
        }

        /// <summary>
        /// sets progress percentage complete
        /// </summary>
        /// <param name="value"></param>
        public void Value(int value)
        {
            ProgressBar_UpdateValue(value);
        }
        private void ProgressBar_UpdateValue(int value) 
        {
            if (progressBar == null || progressBar.IsDisposed)
            {
                return;
            }
            try
            {
                progressBar.Value = value;
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return;
            }
            if (value > 0)
            {
                try
                {

                    int percent = (int)(((double)progressBar.Value / (double)progressBar.Maximum) * 100);


                    progressBar.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar.Width / (float)2.5, progressBar.Height / 2 - 7));
                }
                catch (Exception e)
                {
                    MyLog.Add(e.ToString());
                    return;
                }
            }
        }

        /// <summary>
        /// set label to result of curent action
        /// does override UserControl.Text
        /// </summary>
        /// <param name="text"></param>
        public new void Text(string text)
        {
            // new allows override of existing Text method

            ProgressLabel_SetText(text);
        }
        private void ProgressLabel_SetText(string text)
        {
            labelProgress.Text = text;
        }

        public void SetTextAlignment(ContentAlignment align)
        {
            labelProgress.TextAlign = align;
        }



    }
}
