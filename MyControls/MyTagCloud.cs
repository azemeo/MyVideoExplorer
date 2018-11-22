using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVideoExplorer
{

    public partial class MyTagCloud : UserControl
    {
        public class TagItem
        {
            public string Name;
            public int Value;
            public int Index;

            public TagItem(string name, int value)
            {
                Name = name;
                Value = value;
                Index = 0;
            }
        }

        public class TagClickedEventArgs : EventArgs
        {
            private TagItem item;
            public TagItem Item
            {
                get { return item; }
            }

            public TagClickedEventArgs(TagItem item)
            {
                this.item = item;
            }
        }


        public delegate void TagClickedHandler(object sender, TagClickedEventArgs e);
        public event TagClickedHandler TagClicked;
        private List<TagItem> values = new List<TagItem>();
        private List<TagItem> selected = new List<TagItem>();
        public int MinFontSize;
        public int MaxFontSize;
        public Color selectedTagColor = Color.SlateBlue;
        public Color unselectedTagColor = Color.SlateBlue;
        public Color zeroTagColor = Color.SlateGray;


        public MyTagCloud()
        {
            InitializeComponent();

            flowLayoutPanel.BackColor = System.Drawing.Color.LightYellow;
            flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.HorizontalScroll.Visible = false;
            flowLayoutPanel.WrapContents = true;

            MinFontSize = 7;
            MaxFontSize = 15;

            textBoxTags.Hide();

            labelTagType.Text = "";
            labelTagType.ForeColor = System.Drawing.Color.DarkGoldenrod;

            // mouse wheelz
            flowLayoutPanel.MouseWheel += new MouseEventHandler(flowLayoutPanel_MouseWheel);
        }

        private void MyTagCloud_Load(object sender, EventArgs e)
        {

        }

         private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

         }


         private void buttonToggle_Click(object sender, EventArgs e)
         {
             if (textBoxTags.Visible)
             {
                 textBoxTags.Hide();
             }
             else
             {
                 int textBoxWidth = flowLayoutPanel.Width - MyDPI.ScaleDPIDimension(buttonToggle.Width) - MyDPI.ScaleDPIDimension(25);

                 // count is fall back in case extern call doesnt work
                 int nbrControls = flowLayoutPanel.Controls.Count;
                 if (MyUser32_GetWindow.IsVerticalScrollbarVisible(flowLayoutPanel.Handle) || nbrControls > 8)
                 {
                     textBoxWidth -= MyDPI.ScaleDPIDimension(20);
                 }

                 textBoxTags.Width = textBoxWidth;
                 textBoxTags.Show();
             }
         }

         private void textBoxTags_TextChanged(object sender, EventArgs e)
         {
             // fires per keypress             
         }

         private void textBoxTags_Leave(object sender, EventArgs e)
         {
             // highlight tags based on text box text
             // text may not match any tag


             string[] names = textBoxTags.Text.Split(',');
             // names = names.OrderBy(s => s).ToArray();
             selected.Clear();
             foreach (string name in names)
             {
                 
                 TagItem item = values.Find(s => s.Name == name);
                 if (item != null)
                 {
                     AddSelected(item);
                 }
             }
             RefreshTags();

         }





        protected virtual void OnTagClicked(TagClickedEventArgs e)
        {
            // bubble up event
            if (TagClicked != null)
            {
                TagClicked(this, e);
            }
        }

        public void SetTagType(string tagType)
        {
            labelTagType.Text = tagType;
        }

        // Adds name TagItem to controls collection
        public void AddItem(TagItem item)
        {
            values.Add(item);
            AddLabel(item);
            
            RefreshTags();
        }

        public void AddItems(List<TagItem> items)
        {
            AddItems(items, null);
        }

        public void AddItems(List<TagItem> items, string selectedTags)
        {
            flowLayoutPanel.SuspendLayout();

            List<string> tags = new List<string>{};
            if (selectedTags != null)
            {
                tags = selectedTags.Split(',').ToList();
                textBoxTags.Text = selectedTags;
            }
            foreach (TagItem item in items)
            {
                values.Add(item);
                AddLabel(item);

                foreach (string tag in tags)
                {
                    if (tag == item.Name)
                    {
                        AddSelected(item);
                    }
                }
            }

            flowLayoutPanel.ResumeLayout();
            
            RefreshTags();            
        }

        public void Sort()
        {
            this.Controls.Clear();
            foreach (var item in values.OrderBy(o => o.Name))
            {
                AddLabel(item);
            }
        }

        public void Empty()
        {
            flowLayoutPanel.SuspendLayout();

            values.Clear();
            selected.Clear();

            flowLayoutPanel.Controls.Clear();

            flowLayoutPanel.ResumeLayout();
        }

        public void ClearSelected()
        {
            selected.Clear();
        }

        public List<TagItem> GetSelectedTags()
        {
            return selected;
        }

        // Calculates size of each item accoriding to all input values
        // smaller values => smaller font and bigger values => larger font
        // input values (item.Value) are grouped in n groups where n is MaxFontSize - MinFontSize
        public void Calculate()
        {
            if (values.Count == 0)
            {
                return;
            }
            int min = values.Min(p => p.Value);
            int max = values.Max(p => p.Value);
            decimal factor = (max - min) / (decimal)(MaxFontSize - MinFontSize);

            if (factor == 0)
            {
                return;
            }
            foreach (var item in values)
            {
                item.Index = (int)Math.Floor((item.Value - min) / factor);
            }
        }

        public void RefreshTags()
        {
            flowLayoutPanel.SuspendLayout();

            Calculate();
            foreach (Label label in flowLayoutPanel.Controls.OfType<Label>())
            {
                TagItem item = (TagItem)label.Tag;

                if (item == null)
                {
                    continue;
                }

                if (selected.Contains(item))
                {
                    // selected tag
                    label.Font = new Font(FontFamily.GenericSansSerif, MinFontSize + item.Index, FontStyle.Underline | FontStyle.Bold);
                    if (item.Value == 0)
                    {
                        label.ForeColor = zeroTagColor;
                    }
                    else
                    {
                        label.ForeColor = selectedTagColor;
                    }
                }
                else
                {
                    // un-selected tag
                    label.Font = new Font(label.Font.FontFamily, MinFontSize + item.Index, FontStyle.Regular);
                    if (item.Value == 0)
                    {
                        label.ForeColor = zeroTagColor;
                    }
                    else
                    {
                        label.ForeColor = unselectedTagColor;
                    }
                }
            }
            flowLayoutPanel.ResumeLayout();
        }

        // Adds label to Control, and hooks events for hover effect and click
        private void AddLabel(TagItem item)
        {

            Label label = new Label();
            label.Text = item.Name;
            label.Font = new Font(label.Font.FontFamily, MinFontSize + item.Index);
            label.AutoSize = true;
            label.MinimumSize = new System.Drawing.Size(0, 30);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Tag = item;
            label.Click += label_Click;
            label.Cursor = Cursors.Hand;
            label.ForeColor = Color.SteelBlue;
            //lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label.Margin = new Padding(0);
            label.Padding = new Padding(0);
            label.MouseEnter += label_MouseEnter;
            label.MouseLeave += label_MouseLeave;

            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipIcon = ToolTipIcon.None;
            toolTip.UseAnimation = false;
            toolTip.UseFading = false;
            toolTip.IsBalloon = false;
            toolTip.AutoPopDelay = 30000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.ToolTipTitle = null;
            toolTip.SetToolTip(label, item.Value.ToString() + " occurrences");

            flowLayoutPanel.Controls.Add(label);


        }

        private void AddSelected(TagItem item)
        {
            selected.Add(item);
        }

        private void AddTextBoxText(TagItem item)
        {
            if (textBoxTags.Text == "")
            {
                textBoxTags.Text = item.Name;
            }
            else
            {
                textBoxTags.Text += "," + item.Name;

                // rest of this not need if not sorting .. but eh
                string[] names = textBoxTags.Text.Split(',');
                // names = names.OrderBy(s => s).ToArray();
                string tags = "";
                foreach (string name in names)
                {
                    tags += "," + name;
                }
                tags = tags.Substring(1);
                textBoxTags.Text = tags;


            }
        }

        private void RemoveSelected(TagItem item)
        {
            selected.Remove(item);
        }

        private void RemoveTextBoxText(TagItem item)
        {
             // could do a replace .. but in case enable sort .. prob needs to be a user option
            string[] names = textBoxTags.Text.Split(',');
            // names = names.OrderBy(s => s).ToArray();
            string tags = "";
            foreach (string name in names)
            {
                if (item.Name == name)
                {
                    continue;
                }
                tags += "," + name;
            }
            tags = tags.TrimStart(',').Trim();
            textBoxTags.Text = tags;
        }

        void label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            TagItem item = ((Control)sender).Tag as TagItem;

            if (selected.Contains(item))
            {
                label.Font = new Font(label.Font, FontStyle.Regular);

                if (item.Value == 0)
                {
                    label.ForeColor = zeroTagColor;
                }
                else
                {
                    label.ForeColor = unselectedTagColor;
                }

                RemoveSelected(item);
                RemoveTextBoxText(item);
            }
            else
            {
                label.Font = new Font(label.Font, FontStyle.Underline | FontStyle.Bold);

                if (item.Value == 0)
                {
                    label.ForeColor = zeroTagColor;
                }
                else
                {
                    label.ForeColor = selectedTagColor;
                }

                AddSelected(item);
                AddTextBoxText(item);
            }

            OnTagClicked(new TagClickedEventArgs(item));
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label == null) return;

            TagItem item = (TagItem)label.Tag;


        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label == null) return;
        }


        private void flowLayoutPanel_MouseWheel(object sender, MouseEventArgs e)
        {
        }

        private void flowLayoutPanel_MouseLeave(object sender, EventArgs e)
        {
            // so mouse wheel will not scroll panel
            this.Focus();
        }

        private void flowLayoutPanel_MouseEnter(object sender, EventArgs e)
        {
            // mouse wheel doesnt trigger scroll event, so mimic uhm scroll event

            // so mouse wheel will scroll panel
            flowLayoutPanel.Focus();
        }





    }

}
