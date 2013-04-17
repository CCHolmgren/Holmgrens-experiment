using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sida_1
{
    public partial class Form1 : Form
    {
        //If fullscreen is enabled or not
        //To be able to distingish in the function so no need for two functions
        bool fullscreen = false;
        int instruktioner = 9;
        double controlSize = -1;
        int controlSizeInt = 0;
        string[] stringOne;
        string[] stringTwo;
        string[] stringThree;
        bool setup = false;
        int randomNumber;
        int randomintthatwillkeeptrackoftimes = 0;
        int magicInt = 0;
        StreamWriter stream;
        Label[] labelList;
        TextBox[] textboxList;
        TextBox[] centerTextBoxList;
        //TextBox[] optionList;
        Button[] buttonList;
        int resolution;
        Size screenPrimary;
        Random random = new Random();
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
            resolution = Screen.PrimaryScreen.Bounds.Width * Screen.PrimaryScreen.Bounds.Height;
            stringOne = stringsOne;
            stringTwo = stringsTwo;
            stringThree = stringsThree;
            this.Width = width != 0 ? width : 800;
            this.Height = height != 0 ? height : 600;
            controls = new Control[] { bStartLoop, label1, label2, label3, button2, button7, bFullscreen, bStartLoop };
            labelList = new Label[] { label9, label4, label5, label6, 
            label7, label8, label15, label10, label11, label12, label13, label14,
            label22,label23,}; //Half the text size of the textboxes
            textboxList = new TextBox[] { textBox4, textBox3, textBox5, };
            centerTextBoxList = new TextBox[] { textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, };
            label1.Text = instruktioner.ToString();
            label2.Text = tabControl1.SelectedIndex.ToString();
            label3.Text = tabControl1.TabCount.ToString();
            tab100.Visible = false;
            tab100.Size = new Size(Screen.PrimaryScreen.Bounds.Y, Screen.PrimaryScreen.Bounds.X);
            buttonList = new Button[] {button1, button2, button3, button4, button5, button6, button7, startProgram, button9, };
            screenPrimary = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
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
            
            foreach (Label x in labelList)
            {
                x.Font = new Font("Microsoft Sans Serif", 15);
            }
            resolutionHandler();
            resolutionHandlerTwo();
            textBoxListHandler();
            centerTextBoxListHandler();
            buttonListHandler();
        }
        private void resolutionHandlerTwo()
        {
            switch (resolution)
            {
                case 2073600:
                    {
                        label9.Location = new Point(550, 325);
                        label4.Location = new Point(545, 375);
                        label5.Location = new Point(985, 375);
                        trackBar2.Location = new Point(550, 400);
                        button5.Location = new Point(800, 500);
                        label8.Location = new Point(500, 325);
                        label6.Location = new Point(545, 375);
                        label7.Location = new Point(1025, 375);
                        trackBar3.Location = new Point(550, 400);
                        button6.Location = new Point(800, 500);
                        label10.Location = new Point(400, 250);
                        textBox1.Location = new Point(400, 300);
                        label11.Location = new Point(400, 250);
                        label12.Location = new Point(400, 350);
                        label13.Location = new Point(400, 450);
                        trackBar4.Location = new Point(400, 300);
                        trackBar1.Location = new Point(400, 400);
                        trackBar5.Location = new Point(400, 500);
                        label22.Location = new Point(400, 600);
                        label14.Location = new Point(screenPrimary.Width / 2 - label14.Size.Width / 2, screenPrimary.Height / 2 - label14.Size.Height / 2);
                        button1.Location = new Point(400, 700);
                        button3.Location = new Point(600, 700);
                    }
                    break;
                case 1764000:
                    {
                        label9.Location = new Point(screenPrimary.Width / 2 - label9.Size.Width / 2, 325);
                        label4.Location = new Point(545, 375);
                        label5.Location = new Point(985, 375);
                        trackBar2.Location = new Point(550, 400);
                        button5.Location = new Point(800, 500);
                        label8.Location = new Point(500, 325);
                        label6.Location = new Point(545, 375);
                        label7.Location = new Point(1025, 375);
                        trackBar3.Location = new Point(550, 400);
                        button6.Location = new Point(800, 500);
                        label10.Location = new Point(400, 250);
                        textBox1.Location = new Point(400, 300);
                        label11.Location = new Point(400, 250);
                        label12.Location = new Point(400, 350);
                        label13.Location = new Point(400, 450);
                        trackBar4.Location = new Point(400, 300);
                        trackBar1.Location = new Point(400, 400);
                        trackBar5.Location = new Point(400, 500);
                        label22.Location = new Point(400, 600);
                        label14.Location = new Point(screenPrimary.Width / 2 - label14.Size.Width / 2, screenPrimary.Height / 2 - label14.Size.Height / 2);
                        button1.Location = new Point(400, 700);
                        button3.Location = new Point(600, 700);
                    }
                    break;
                case 1456000:
                    {
                        label4.Location = new Point(400, 400);
                        label5.Location = new Point(400, 400);
                        label9.Location = new Point(400, 400);
                        trackBar2.Location = new Point(400, 400);
                        button5.Location = new Point(400, 400);
                        label8.Location = new Point(400, 400);
                        label6.Location = new Point(400, 400);
                        label7.Location = new Point(400, 400);
                        trackBar3.Location = new Point(400, 400);
                        button6.Location = new Point(400, 400);
                        label10.Location = new Point(tab100.Width / 2 - label10.Width / 2, 50);
                        label11.Location = new Point(400, 400);
                        label12.Location = new Point(400, 400);
                        label13.Location = new Point(400, 400);
                        trackBar4.Location = new Point(400, 400);
                        trackBar1.Location = new Point(400, 400);
                        trackBar5.Location = new Point(400, 400);
                        label14.Location = new Point(400, 400);
                        button1.Location = new Point(tabPage13.Width / 4 - button1.Width / 2, 400);
                        button3.Location = new Point((tabPage13.Width / 4) * 3 - button1.Width / 2, 400);

                    }
                    break;
                case 1440000:
                    {
                        label4.Location = new Point(400, 400);
                        label5.Location = new Point(400, 400);
                        label9.Location = new Point(400, 400);
                        trackBar2.Location = new Point(400, 400);
                        button5.Location = new Point(400, 400);
                        label8.Location = new Point(400, 400);
                        label6.Location = new Point(400, 400);
                        label7.Location = new Point(400, 400);
                        trackBar3.Location = new Point(400, 400);
                        button6.Location = new Point(400, 400);
                        label10.Location = new Point(tab100.Width / 2 - label10.Width / 2, 50);
                        label11.Location = new Point(400, 400);
                        label12.Location = new Point(400, 400);
                        label13.Location = new Point(400, 400);
                        trackBar4.Location = new Point(400, 400);
                        trackBar1.Location = new Point(400, 400);
                        trackBar5.Location = new Point(400, 400);
                        label14.Location = new Point(400, 400);
                        button1.Location = new Point(tabPage13.Width / 4 - button1.Width / 2, 400);
                        button3.Location = new Point((tabPage13.Width / 4) * 3 - button1.Width / 2, 400);
                        break;
                    }
                case 1296000:
                    {
                        label4.Location = new Point(400, 400);
                        label5.Location = new Point(400, 400);
                        label9.Location = new Point(400, 400);
                        trackBar2.Location = new Point(400, 400);
                        button5.Location = new Point(400, 400);
                        label8.Location = new Point(400, 400);
                        label6.Location = new Point(400, 400);
                        label7.Location = new Point(400, 400);
                        trackBar3.Location = new Point(400, 400);
                        button6.Location = new Point(400, 400);
                        label10.Location = new Point(tab100.Width / 2 - label10.Width / 2, 50);
                        label11.Location = new Point(400, 400);
                        label12.Location = new Point(400, 400);
                        label13.Location = new Point(400, 400);
                        trackBar4.Location = new Point(400, 400);
                        trackBar1.Location = new Point(400, 400);
                        trackBar5.Location = new Point(400, 400);
                        label14.Location = new Point(400, 400);
                        button1.Location = new Point(tabPage13.Width / 4 - button1.Width / 2, 400);
                        button3.Location = new Point((tabPage13.Width / 4) * 3 - button1.Width / 2, 400);
                        break;
                    }
                case 1049088:
                    {
                        label4.Location = new Point(400, 400);
                        label5.Location = new Point(400, 400);
                        label9.Location = new Point(400, 400);
                        trackBar2.Location = new Point(400, 400);
                        button5.Location = new Point(400, 400);
                        label8.Location = new Point(400, 400);
                        label6.Location = new Point(400, 400);
                        label7.Location = new Point(400, 400);
                        trackBar3.Location = new Point(400, 400);
                        button6.Location = new Point(400, 400);
                        label10.Location = new Point(tab100.Width / 2 - label10.Width / 2, 50);
                        label11.Location = new Point(400, 400);
                        label12.Location = new Point(400, 400);
                        label13.Location = new Point(400, 400);
                        trackBar4.Location = new Point(400, 400);
                        trackBar1.Location = new Point(400, 400);
                        trackBar5.Location = new Point(400, 400);
                        label14.Location = new Point(400, 400);
                        button1.Location = new Point(tabPage13.Width / 4 - button1.Width / 2, 400);
                        button3.Location = new Point((tabPage13.Width / 4) * 3 - button1.Width / 2, 400);

                    }
                    break;
                default:
                    label4.Location = new Point(400, 400);
                    label5.Location = new Point(400, 400);
                    label9.Location = new Point(400, 400);
                    trackBar2.Location = new Point(400, 400);
                    button5.Location = new Point(400, 400);
                    label8.Location = new Point(400, 400);
                    label6.Location = new Point(400, 400);
                    label7.Location = new Point(400, 400);
                    trackBar3.Location = new Point(400, 400);
                    button6.Location = new Point(400, 400);
                    label10.Location = new Point(tab100.Width / 2 - label10.Width / 2, 50);
                    label11.Location = new Point(400, 400);
                    label12.Location = new Point(400, 400);
                    label13.Location = new Point(400, 400);
                    trackBar4.Location = new Point(400, 400);
                    trackBar1.Location = new Point(400, 400);
                    trackBar5.Location = new Point(400, 400);
                    label14.Location = new Point(400, 400);
                    button1.Location = new Point(tabPage13.Width / 4 - button1.Width / 2, 400);
                    button3.Location = new Point((tabPage13.Width / 4) * 3 - button1.Width / 2, 400);
                    break;
            }
        }
        private void resolutionHandler()
        {
            for (int i = 0; i < instruktioner + stringTwo.Length; i++)
            {
                TextBox text = new TextBox();
                if (i < instruktioner)
                {
                    text.Text = stringOne[i].Substring("Instruktioner".Length + 1);
                }
                else
                {
                    text.Text = this.stringTwo[i - instruktioner];
                }
                foreach (Button x in buttonList)
                {
                    x.Location = new Point(tab100.Width / 2 - x.Width / 2, tab100.Height / 2 - x.Height / 2);
                }

            switch (resolution)
            {
                case 2073600:
                    {
                        text.Size = new System.Drawing.Size(1350, 1000);
                        text.Location = new Point(400, 250);
                        text.ForeColor = Properties.Settings.Default.textColor;
                        text.BackColor = Properties.Settings.Default.tabPageBackColor;
                        text.Font = new Font("Microsoft Sans Serif", 30);
                        text.WordWrap = true;
                        text.ReadOnly = true;
                        text.Multiline = true;
                        text.Select(0, 0);
                        text.BorderStyle = BorderStyle.None;
                        text.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    }
                    break;
                case 1764000:
                    {
                        text.Size = new System.Drawing.Size(1350, 1000);
                        text.Location = new Point(250, 250);
                        text.ForeColor = Properties.Settings.Default.textColor;
                        text.BackColor = Properties.Settings.Default.tabPageBackColor;
                        text.Font = new Font("Microsoft Sans Serif", 30);
                        text.WordWrap = true;
                        text.ReadOnly = true;
                        text.Multiline = true;
                        text.Select(0, 0);
                        text.BorderStyle = BorderStyle.None;
                        text.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    }
                    break;
                case 1456000:
                    {
                        text.Size = new System.Drawing.Size(1000, 1000);
                        text.Location = new Point(300, 300);
                        text.ForeColor = Properties.Settings.Default.textColor;
                        text.BackColor = Properties.Settings.Default.tabPageBackColor;
                        text.Font = new Font("Microsoft Sans Serif", 30);
                        text.WordWrap = true;
                        text.ReadOnly = true;
                        text.Multiline = true;
                        text.Select(0, 0);
                        text.BorderStyle = BorderStyle.None;
                        text.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    }
                    break;
                case 1440000:
                    {
                        text.Size = new System.Drawing.Size(950, 1000);
                        text.Location = new Point(325, 125);
                        text.ForeColor = Properties.Settings.Default.textColor;
                        text.BackColor = Properties.Settings.Default.tabPageBackColor;
                        text.Font = new Font("Microsoft Sans Serif", 30);
                        text.WordWrap = true;
                        text.ReadOnly = true;
                        text.Multiline = true;
                        text.Select(0, 0);
                        text.BorderStyle = BorderStyle.None;
                        text.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    }
                    break;
                case 1296000:
                    {
                        text.Size = new System.Drawing.Size(1000, 1000);
                        text.Location = new Point(200, 150);
                        text.ForeColor = Properties.Settings.Default.textColor;
                        text.BackColor = Properties.Settings.Default.tabPageBackColor;
                        text.Font = new Font("Microsoft Sans Serif", 25);
                        text.WordWrap = true;
                        text.ReadOnly = true;
                        text.Multiline = true;
                        text.Select(0, 0);
                        text.BorderStyle = BorderStyle.None;
                        text.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    }
                    break;
                case 1049088:
                    {
                        text.Size = new System.Drawing.Size(1000, 1000);
                        text.Location = new Point(200, 200);
                        text.ForeColor = Properties.Settings.Default.textColor;
                        text.BackColor = Properties.Settings.Default.tabPageBackColor;
                        text.Font = new Font("Microsoft Sans Serif", 30);
                        text.WordWrap = true;
                        text.ReadOnly = true;
                        text.Multiline = true;
                        text.Select(0, 0);
                        text.BorderStyle = BorderStyle.None;
                        text.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    }
                    break;
                default:
                    text.Size = new System.Drawing.Size(950, 1000);
                    text.Location = new Point(325, 125);
                    text.ForeColor = Properties.Settings.Default.textColor;
                    text.BackColor = Properties.Settings.Default.tabPageBackColor;
                    text.Font = new Font("Microsoft Sans Serif", 30);
                    text.WordWrap = true;
                    text.ReadOnly = true;
                    text.Multiline = true;
                    text.Select(0, 0);
                    text.BorderStyle = BorderStyle.None;
                    text.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    break;
            }
            tabControl1.TabPages[i].Controls.Add(text);
            tabControl1.TabPages[i].Focus();
            }
        }
        private void buttonListHandler()
        {
            foreach (Button b in buttonList)
            {
                b.ForeColor = Color.Black;
            }
        }
        private void centerTextBoxListHandler()
        {
            foreach (TextBox x in centerTextBoxList)
            {
                switch (resolution)
                {
                    case 2073600:
                        {
                            x.Size = new System.Drawing.Size(1000, 1000);
                            x.Location = new Point(400, 250);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 30);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);

                        }
                        break;
                    case 1764000:
                        {
                            x.Size = new System.Drawing.Size(1000, 1000);
                            x.Location = new Point(250, 250);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 30);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);

                        }
                        break;
                    case 1456000:
                        {
                            x.Size = new System.Drawing.Size(1000, 1000);
                            x.Location = new Point(300, 300);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 30);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);

                        }
                        break;
                    case 1440000:
                        {
                            x.Size = new System.Drawing.Size(950, 1000);
                            x.Location = new Point(350, 300);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 25);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);

                        }
                        break;
                    case 1296000:
                        {
                            x.Size = new System.Drawing.Size(1000, 1000);
                            x.Location = new Point(350, 350);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 30);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);

                        }
                        break;
                    case 1049088:
                        {
                            x.Size = new System.Drawing.Size(1000, 1000);
                            x.Location = new Point(300, 300);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 30);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);

                        }
                        break;
                    default:
                        x.Size = new System.Drawing.Size(950, 1000);
                        x.Location = new Point(350, 300);
                        x.ForeColor = Properties.Settings.Default.textColor;
                        x.BackColor = Properties.Settings.Default.tabPageBackColor;
                        x.Font = new Font("Microsoft Sans Serif", 25);
                        x.WordWrap = true;
                        x.ReadOnly = true;
                        x.Multiline = true;
                        x.Select(0, 0);
                        x.BorderStyle = BorderStyle.None;
                        x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        break;
                }
            }
        }
        private void textBoxListHandler()
        {
            foreach (TextBox x in textboxList)
            {
                switch (resolution)
                {
                    case 2073600:
                        {
                            x.Size = new System.Drawing.Size(1150, 1000);
                            x.Location = new Point(400, 250);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 30);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        }
                        break;
                    case 1764000:
                        {
                            x.Size = new System.Drawing.Size(1150, 1000);
                            x.Location = new Point(250, 250);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 30);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        }
                        break;
                    case 1456000:
                        {
                            x.Size = new System.Drawing.Size(1000, 1000);
                            x.Location = new Point(300, 300);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 30);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        }
                        break;
                    case 1440000:
                        {
                            x.Size = new System.Drawing.Size(950, 1000);
                            x.Location = new Point(375, 250);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 30);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        }
                        break;
                    case 1296000:
                        {
                            x.Size = new System.Drawing.Size(1000, 1000);
                            x.Location = new Point(300, 300);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 30);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        }
                        break;
                    case 1049088:
                        {
                            x.Size = new System.Drawing.Size(1000, 1000);
                            x.Location = new Point(200, 200);
                            x.ForeColor = Properties.Settings.Default.textColor;
                            x.BackColor = Properties.Settings.Default.tabPageBackColor;
                            x.Font = new Font("Microsoft Sans Serif", 30);
                            x.WordWrap = true;
                            x.ReadOnly = true;
                            x.Multiline = true;
                            x.Select(0, 0);
                            x.BorderStyle = BorderStyle.None;
                            x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);

                        }
                        break;
                    default:
                        x.Size = new System.Drawing.Size(950, 1000);
                        x.Location = new Point(375, 250);
                        x.ForeColor = Properties.Settings.Default.textColor;
                        x.BackColor = Properties.Settings.Default.tabPageBackColor;
                        x.Font = new Font("Microsoft Sans Serif", 30);
                        x.WordWrap = true;
                        x.ReadOnly = true;
                        x.Multiline = true;
                        x.Select(0, 0);
                        x.BorderStyle = BorderStyle.None;
                        x.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                        break;
                }
            }
        }
        private void setupProgram()
        {
            if (!setup)
            {
                setTabPages();
                setup = !setup;
                foreach (TabPage tabpage in tab100.TabPages)
                {
                    foreach (Control tab in tabpage.Controls)
                    {
                        if(!Type.Equals(tab.GetType(), button1.GetType())){
                            tabpage.ForeColor = Properties.Settings.Default.textColor;
                            tabpage.BackColor = Properties.Settings.Default.tabPageBackColor;
                        }
                    }
                    tabControl1.TabPages.Add(tabpage);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            setupProgram();
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

        private void button4_Click(object sender, EventArgs e)
        {
            setFullscreen();
        }

        //The timer to change between the different tabpages
        //Changes tabpages and changes label 2 and 3
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount && tabControl1.SelectedIndex+1>instruktioner)
            {
                tabControl1.SelectedIndex++;
                tabControl1.TabPages[tabControl1.SelectedIndex].Focus();
            }
            if (tabControl1.SelectedIndex+1 > instruktioner)
            {
                timer1.Interval = 10000;
            }
            if (tabControl1.SelectedIndex == instruktioner + stringTwo.Length+1)
            {
                timer1.Stop();
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Focus();
            timer2.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
            timer4.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
            timer2.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (randomintthatwillkeeptrackoftimes == 0)
                handle_save();
            if (randomintthatwillkeeptrackoftimes >= 0)
            {
                save("Tryckt Ja " + (randomintthatwillkeeptrackoftimes + 1) + " gånger");
                save("Skriven text: " + textBox1.Text.ToString());
                save("Hur intressant var uppgiften? " + trackBar4.Value.ToString());
                save("Hur engagerad var du? " + trackBar1.Value.ToString());
                save("Hur nedstämd känner du dig? " + trackBar5.Value.ToString() + "\n");
            }
            if (randomintthatwillkeeptrackoftimes < 4)
            {
                panel1.Visible = false;
                timer2.Start();
                randomintthatwillkeeptrackoftimes += 1;
            }
            if (randomintthatwillkeeptrackoftimes == 3)
            {
                label22.Text = "Du har nu fortsatt så många gånger du kan. Tryck på knappen för att avsluta testet.";
                button3.Dispose();
                button1.Text = "Avsluta"; 
            }
            else if (randomintthatwillkeeptrackoftimes >= 4)
            {
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
                button9.Location = new Point(100, 100);
            }
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
                if(randomintthatwillkeeptrackoftimes == 0)
                    handle_save();
                button9.Location = new Point(100, 100);

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 7)
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
            else
            {
                if (tabControl1.SelectedTab == tabP106)
                {
                    randomNumber = RandomNumber(1, 3);
                    tabControl1.SelectedIndex = tabControl1.SelectedIndex + randomNumber;
                    timer4.Interval = 30000;
                }
                else
                {
                    tabControl1.SelectedTab = tabPage12;
                    timer4.Stop();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setFullscreen();
            setupProgram();
        }

        private int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Environment.SpecialFolder.MyDocuments + "/Holmgrens experiment/");
                try
                {
                    if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Holmgrenss experiment/"))
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Holmgrens experiment/");
                    stream = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"/Holmgrens experiment/"+textBox2.Text.ToString()+".txt");
                    panel2.Visible = false;
                    setFullscreen();
                    setupProgram();
                    hideChosenControls();
                    timer1.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show("Your identifier can only be numbers or letters.");
                }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            save_clicked();
        }
        private void save_clicked()
        {
            save("Tryckt Ja, och har avslutat");
            save("Skriven text: " + textBox1.Text.ToString());
            save("Hur intressant var uppgiften? " + trackBar4.Value.ToString());
            save("Hur engagerad var du? " + trackBar1.Value.ToString());
            save("Hur nedstämd känner du dig? " + trackBar5.Value.ToString());
            stream.Flush();
            stream.Close();
            this.Close();
        }
        private void handle_save()
        {
            save("Personens kod: " + textBox2.Text.ToString()+"\n");
            save("Sätt ett kryss på linjen som motsvarar hur nedstämd du känner dig:" + trackBar2.Value.ToString() + "\n");
            save(textboxList[randomNumber].Text.ToString() + "\n");
            save("Ange (genom att sätta ett kryss på linjen) hur vettig denna anledning till att skriva brevet låter för dig");
            save(trackBar3.Value.ToString() + "\n");
            save("Första delen av texten: " + textBox1.Text.ToString() + "\n");
            save("Hur intressant tyckte du skrivuppgiften kändes?" + trackBar4.Value.ToString() + "\n");
            save("Hur engagerad var du i skrivuppgiften?" + trackBar1.Value.ToString() + "\n");
            save("Hur nedstämd känner du dig?" + trackBar5.Value.ToString() + "\n");
        }
        private void save(string textToWrite)
        {
            stream.WriteLine(textToWrite);
        }

        private void more_to_save()
        {
                save(textBox1.Text.ToString());
                save(trackBar4.Value.ToString());
                save(trackBar1.Value.ToString());
                save(trackBar5.Value.ToString());
        }

        void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (tabControl1.SelectedIndex < instruktioner)
                    {
                        tabControl1.SelectedIndex++;
                        tabControl1.TabPages[tabControl1.SelectedIndex].Focus();
                    }
                    break;
                case Keys.Escape:
                    magicInt++;
                    if (magicInt == 3)
                        save_clicked();
                    break;
                default:
                    return;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
