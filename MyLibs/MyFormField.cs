using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace MyVideoExplorer
{
    class MyFormField
    {
        private static System.Windows.Forms.Timer buttonTimer = new System.Windows.Forms.Timer();

        public static void SetRichTextBoxText(RichTextBox richTextBox, string text)
        {
            if (text != null)
            {
                richTextBox.Text = text;
            }
            else
            {
                richTextBox.Text = "";
            }
        }

        public static void SetTextBoxText(TextBox textBox, string text)
        {
            if (text != null)
            {
                textBox.Text = text;
            }
            else
            {
                textBox.Text = "";
            }
        }

        public static void SetLabelText(Label label, string text)
        {
            if (text != null)
            {
                label.Text = text;
            }
            else
            {
                label.Text = "";
            }
        }

        public static void SetLabelText(Label label, DateTime dateTime)
        {
            label.Tag = dateTime;    
            if (dateTime != null && dateTime != DateTime.MinValue)
            {
                
                if (dateTime.Date == DateTime.UtcNow.Date)
                {
                    label.Text = dateTime.ToLocalTime().ToShortTimeString();
                }
                else
                {
                    label.Text = dateTime.ToLocalTime().ToShortDateString();
                }                            
            }
            else
            {
                label.Text = "";
            }
        }

        public static void SetCheckBoxChecked(CheckBox checkBox, bool check)
        {
            checkBox.Checked = check;
        }


        public static void SetComboBoxValue(ComboBox comboBox, string value)
        {
            if (value != null && value != "")
            {
                int existingIndex = comboBox.FindStringExact(value);
                if (existingIndex != -1)
                {
                    comboBox.SelectedIndex = existingIndex;
                }
                else
                {
                    comboBox.Items.Insert(0, value);
                    comboBox.SelectedIndex = 0;
                }
            }
            else
            {
                comboBox.SelectedIndex = -1;
            }
        }

        public static void SetComboBoxValue(ComboBox comboBox, int value)
        {
            if (value > 0)
            {
                int existingIndex = comboBox.FindStringExact(value.ToString());
                if (existingIndex != -1)
                {
                    comboBox.SelectedIndex = existingIndex;
                }
                else
                {
                    comboBox.Items.Insert(0, value);
                    comboBox.SelectedIndex = 0;
                }
            }
            else
            {
                comboBox.SelectedIndex = -1;
            }
        }

        public static void SetLinkLabel(LinkLabel linkLabel, string path, string query)
        {
            if (query != null && query.Length > 0)
            {
                linkLabel.LinkBehavior = LinkBehavior.AlwaysUnderline;
                linkLabel.LinkColor = Color.Blue;
                linkLabel.Links[0].LinkData = path + query;
            }
            else
            {
                linkLabel.LinkBehavior = LinkBehavior.NeverUnderline;
                linkLabel.LinkVisited = false;
                linkLabel.LinkColor = Color.Gray;
                linkLabel.Links[0].LinkData = null;
            }
        }



        public static void DelayButtonClick(Button button)
        {
            DelayButtonClick(button, null, 3000);
        }
        public static void DelayButtonClick(Button button, string text)
        {
            DelayButtonClick(button, text, 3000);
        }
        public static void DelayButtonClick(Button button, string text, int howLong)
        {
            buttonTimer.Interval = howLong;
            buttonTimer.Tick += (sender, e) => buttonTimer_Tick(sender, e, button, text);
            buttonTimer.Start();
            button.Enabled = false;
        }
        private static void buttonTimer_Tick(object sender, System.EventArgs e, Button button, string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                button.Text = text;
            }
            button.Enabled = true;
            buttonTimer.Stop();
        }


        public static List<Control> GetControlsOfTypes(List<Type> types, Control parent)
        {
            List<Control> controls = new List<Control> { };
            foreach (Control control in parent.Controls)
            {
                // MyLog.Add("control : " + control.Name + " " +control.GetType().ToString());
                if (types.Contains(control.GetType()))
                {
                    controls.Add(control);
                }
                if (control.HasChildren)
                {
                    List<Control> subControls = GetControlsOfTypes(types, control);
                    controls.AddRange(subControls);
                }
            }
            return controls;
        }

        public static void HighlightFormFieldsOnFocus(Control parent)
        {
            List<Type> types = new List<Type> { typeof(TextBox), typeof(ListBox), typeof(ComboBox), typeof(DataGridView) };
            foreach (Control control in GetControlsOfTypes(types, parent))
            {
                // MyLog.Add("control : " + control.Name);
                if (control.GetType() == typeof(TextBox))
                {
                    control.Enter += new EventHandler(HighlightTextBoxesOnFocus_Enter);
                    control.Leave += new EventHandler(HighlightTextBoxesOnFocus_Leave);
                }
                else
                {
                    control.Enter += new EventHandler(HighlightFieldOnFocus_Enter);
                    control.Leave += new EventHandler(HighlightFieldOnFocus_Leave);
                }
            }
        }

        public static void HighlightTextBoxesOnFocus(Control parent)
        {
            List<Type> types = new List<Type>{typeof(TextBox)};
            foreach (Control control in GetControlsOfTypes(types, parent))
            {
                // MyLog.Add("control : " + control.Name);
                control.Enter += new EventHandler(HighlightTextBoxesOnFocus_Enter);
                control.Leave += new EventHandler(HighlightTextBoxesOnFocus_Leave);

            }
        }

        private static void HighlightFieldOnFocus_Enter(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = Color.LightYellow;
        }

        private static void HighlightFieldOnFocus_Leave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = Color.White;
        }

        private static void HighlightTextBoxesOnFocus_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.SelectAll();
            textBox.BackColor = Color.LightYellow;  
        }

        private static void HighlightTextBoxesOnFocus_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        public static bool IsControlVisible(Control parent, Control child)
        {
            return child.Bounds.IntersectsWith(parent.ClientRectangle);
        }
    }
}
