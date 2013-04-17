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
        //No need for this right now
        //string[] textStrings;
        int instruktioner = 0;
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
        public Form1(string[] stringsOne,string[] stringsTwo, int width, int height)
        {
            //TODO: Set the panels so they hide everything nicely
            InitializeComponent();
            //textStrings = stringsOne;
            this.Width = width != 0 ? width : 800;
            this.Height = height != 0 ? height : 600;
            //Debugging, wont be needed after finished
            foreach (string x in stringsOne)
            {
                if(x.StartsWith("Instruktioner"))
                {
                    instruktioner++;
                }
                textBox1.Text += x;
            }
            textBox1.Text += "\r\n";
            //foreach (string x in stringsTwo)
            //{
            //    textBox1.Text += x;
            //}
            controls = new Control[] { button1, button2, textBox1 };
            label1.Text = instruktioner.ToString();
            label2.Text = tabControl1.SelectedIndex.ToString();
            label3.Text = tabControl1.TabCount.ToString();
            button2.Location = new Point(this.Width - button2.Width-25, this.Height - button2.Height-50);
        }
        //Will mostlikely not be used at all
        public Form1(string[] stringsOne,string[] stringsTwo, bool fullscreen)
        {
            //No need for panels, and is set up nicely now
            InitializeComponent();
            //textStrings = stringsOne;
            Fullscreen();
        }
        //Sets up tabpages
        //Hides the controls and start timer 1
        private void button1_Click(object sender, EventArgs e)
        {
            setTabPages();
            hideChosenControls();
            timer1.Start();
        }
        //Hides the controls set in Control[] controls
        private void hideChosenControls()
        {
            foreach (Control control in controls)
            {
                control.Visible = false;
            }
        }
        //Background to black
        //Tab text to Instruction
        //Loop through all pages and add a label with the title text
        //Also sets the label in the middle and forecolor to red
        private void setTabPages()
        {
            tabControl1.SelectedIndex = 0;
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.BackColor = Color.Black;
                tab.Text = "Instruction";
            }
            for (int i = 0; i < instruktioner; i++)
            {
                Label title = new Label();
                title.Text = "Instruktioner";
                title.Location = new Point(tabControl1.TabPages[i].Width / 2 - title.Width / 2, tabControl1.TabPages[i].Height / 2 - title.Height / 2);
                title.ForeColor = Color.Red;
                tabControl1.TabPages[i].Controls.Add(title);
            }
        }
        //Closes the form
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Sets fullscreen mode on or off
        private void button3_Click(object sender, EventArgs e)
        {
            Fullscreen();
            fullscreen = !fullscreen;
        }
        //The function that button3 is controlling
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
        //The timer to change between the different tabpages
        //Changes tabpages and changes label 2 and 3
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
                tabControl1.SelectedIndex++;
            else
                tabControl1.SelectedIndex = 0;
            label2.Text = tabControl1.SelectedIndex.ToString();
            label3.Text = tabControl1.TabCount.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value+1;
        } 
    }
}
