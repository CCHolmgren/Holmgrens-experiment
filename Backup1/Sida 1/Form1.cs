using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sida_1
{
    public partial class Form1 : Form
    {
        //If fullscreen is enabled or not
        //To be able to distingish in the function so no need for two functions
        bool fullscreen = false;
        int instruktioner = 10;
        double controlSize = -1;
        int controlSizeInt = 0;
        string[] stringOne;
        string[] stringTwo;
        string[] stringThree;
        bool setup = false;
        //Saves information about the form for fullscreen
        struct clientRect
        {
            public Point location;
            public int width;
            public int height;
            public int tabWidth;
            public int tabHeight;
            public Point tabLocation;
        }
        //The controls to hide in hideChosenControls()
        Control[] controls;
        clientRect restore;
        public Form1(string[] stringsOne,string[] stringsTwo,string[] stringsThree, int width, int height)
        {
            InitializeComponent();
            using (Graphics g = this.CreateGraphics())
            {
                controlSize = g.DpiX / 2.54d;
                controlSizeInt = (int)controlSize;
            }
            stringOne = stringsOne;
            stringTwo = stringsTwo;
            stringThree = stringsThree;
            this.Width = width != 0 ? width : 800;
            this.Height = height != 0 ? height : 600;
            controls = new Control[] { bStartLoop, label1, label2, label3, };
            label1.Text = instruktioner.ToString();
            label2.Text = tabControl1.SelectedIndex.ToString();
            label3.Text = tabControl1.TabCount.ToString();
            tab100.Visible = false;
        }
        //Hides the controls set in Control[] controls
        private void hideChosenControls()
        {
            foreach (Control control in controls)
            {
                control.Visible = false;
            }
        }
        //Sets up tabpages
        //Hides the controls and start timer1
        private void button1_Click(object sender, EventArgs e)
        {
            hideChosenControls();
            timer1.Start();
        }
        //Button1.Click calls this
        //Background to black
        //Tab text to Instruction
        //Loop through all pages and add a label with the title text
        //Also sets the label in the middle and forecolor to red
        private void setTabPages()
        {
            tabControl1.SelectedIndex = 0;
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.BackColor = Properties.Settings.Default.tabPageBackColor;
            }
            for (int i = 0; i < this.stringTwo.Length; i++)
            {
                TabPage tabpage = new TabPage("Statement") { BackColor = Properties.Settings.Default.tabPageBackColor, };
                tabControl1.TabPages.Add(tabpage);

            }
            for (int i = 0; i < instruktioner + stringTwo.Length; i++)
            {
                if (i < instruktioner)
                {
                    Label title = new Label();
                    title.Text = "Instruktioner";
                    title.Width = 400;
                    title.Height = 40;
                    title.Location = new Point(tabControl1.TabPages[0].Width / 2 - title.Width / 2, tabControl1.TabPages[0].Height / 8 - title.Height);
                    title.ForeColor = Properties.Settings.Default.textColor;
                    title.Font = new Font("Microsoft Sans Serif", 20);
                    tabControl1.TabPages[i].Controls.Add(title);
                }
                TextBox text = new TextBox();
                if(i >= instruktioner){
                    text.Text = this.stringTwo[i-instruktioner];
                }
                else
                {
                    text.Text = stringOne[i].Substring("Instruktioner".Length);
                }
                    text.Location = new Point(tabControl1.TabPages[0].Width / 4 - text.Width / 2, tabControl1.TabPages[0].Height / 8 - text.Height);
                    text.ForeColor = Properties.Settings.Default.textColor;
                    text.BackColor = Properties.Settings.Default.tabPageBackColor;
                    text.Font = new Font("Microsoft Sans Serif", 40);
                    text.WordWrap = true;
                    text.ReadOnly = true;
                    text.Multiline = true;
                    text.Select(0, 0);
                    text.BorderStyle = BorderStyle.None;
                    text.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    text.Size = new System.Drawing.Size(1000, 1000);
                tabControl1.TabPages[i].Controls.Add(text);
                tabControl1.TabPages[i].Focus();
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!setup)
            {
                setTabPages();
                setup = !setup;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void Fullscreen()
        {
            if (fullscreen == false)
            {
                this.restore.location = this.Location;
                this.restore.width = this.Width;
                this.restore.height = this.Height;
                this.restore.tabWidth = this.tabControl1.Width;
                this.restore.tabHeight = this.tabControl1.Height;
                this.restore.tabLocation = this.tabControl1.Location;
                this.tabControl1.Location = new Point(-10, -25);
                this.TopMost = true;
                this.Location = new Point(0, 0);
                this.FormBorderStyle = FormBorderStyle.None;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;
                this.tabControl1.Height = Screen.PrimaryScreen.Bounds.Height + 50;
                this.tabControl1.Width = Screen.PrimaryScreen.Bounds.Width + 50;

                BclsForm.Location = new Point(0, this.Height - BclsForm.Height);
            }
            else
            {
                //restores all variables changed
                //so that it looks nice again after
                //exiting fullscreen
                this.TopMost = false;
                this.Location = this.restore.location;
                this.Width = this.restore.width;
                this.Height = this.restore.height;
                this.tabControl1.Width = this.restore.tabWidth;
                this.tabControl1.Height = this.restore.tabHeight;
                this.tabControl1.Location = this.restore.tabLocation;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }
        private void setFullscreen()
        {
            Fullscreen();
            fullscreen = !fullscreen;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            setFullscreen();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            setFullscreen();
        }
        //The timer to change between the different tabpages
        //Changes tabpages and changes label 2 and 3
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount)
            {
                tabControl1.SelectedIndex++;
                tabControl1.TabPages[tabControl1.SelectedIndex].Focus();
            }
            if (tabControl1.SelectedIndex >= instruktioner)
            {
                timer1.Interval = 120;
            }
            if (tabControl1.SelectedIndex == instruktioner + stringTwo.Length-1)
            {
                timer1.Stop();
                tabControl1.TabPages.Clear();
                foreach (TabPage tabpage in tab100.TabPages)
                    tabControl1.TabPages.Add(tabpage);
            }
            label2.Text = tabControl1.SelectedIndex.ToString();
            label3.Text = tabControl1.TabCount.ToString();
        }
        private void showTabPage(TabControl tabcontrol)
        {
            tabcontrol.Location = new Point(-10, -10);
            tabcontrol.Size = new System.Drawing.Size(3000, 3000);
            foreach (Control x in tabcontrol.Controls)
            {
                if (typeof(Label).Equals(x))
                {

                }
            }
            tabcontrol.Show();
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X - 10;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
