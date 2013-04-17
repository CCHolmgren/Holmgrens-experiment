using System;
using System.Strings;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using CommandLine.Utility;

namespace Sida_1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application
        /// </summary>
        [STAThread]
        static int Main(string[] Args)
        {
            int width = 800;
            int height = 600;
            bool fullscreen = false;
            Arguments CommandLine = new Arguments(Args);
            //TODO: Should probably fix the annoying popups
            if (CommandLine["input1"] == null)
            { MessageBox.Show("Default.txt will be used as input file,\nit's recommended that you choose a custom files for input;"); }
            if (CommandLine["input2"] == null)
            { MessageBox.Show("Default.txt will be used as input file,\nit's recommended that you choose a custom files for input;"); }
            if (CommandLine["height"] != null)
                height = Int32.Parse(CommandLine["height"]);
            if (CommandLine["width"] != null)
                width = Int32.Parse(CommandLine["width"]);
            if (CommandLine["native"] != null)
            {
                width = Screen.PrimaryScreen.Bounds.Width;
                height = Screen.PrimaryScreen.Bounds.Height;
            }
            if (CommandLine["fullscreen"] != null)
                fullscreen = true;
            //Reads a file from C:\\
            //And passes it to Form1
            StreamReader streamOne;
            StreamReader streamTwo;
            string streamOneText;
            string streamTwoText;
            if(System.IO.File.Exists(CommandLine["input1"]))
            {
                streamOne = new StreamReader(CommandLine["input1"], System.Text.Encoding.Default);
                streamOneText = streamOne.ReadToEnd();
                streamOne.Close();
            }
            else
            {
                FileStream fd = new FileStream("Default.txt",FileMode.OpenOrCreate);
                fd.Close();
                streamOne = new StreamReader("Default.txt", System.Text.Encoding.Default);
                streamOneText = streamOne.ReadToEnd();
                streamOne.Close();
            } 
            if (System.IO.File.Exists(CommandLine["input2"]))
            {
                streamTwo = new StreamReader(CommandLine["input2"], System.Text.Encoding.Default);
                streamTwoText = streamTwo.ReadToEnd();
                streamTwo.Close();
            }
            else
            {
                FileStream fd = new FileStream("Default.txt", FileMode.OpenOrCreate);
                fd.Close();
                streamTwo = new StreamReader("Default.txt",System.Text.Encoding.Default);
                streamTwoText = streamTwo.ReadToEnd();
                streamTwo.Close();
            }
            //Splits the string into several with a extension to string
            //Fixed no with regex, not the fastest, but easiest
            string[] streamOneSplit = streamOneText.stripWhite();
            string[] streamTwoSplit = streamTwoText.stripWhite();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Passes the read splitted strings to Form1
            if (fullscreen)
            {
                Application.Run(new Form1(streamOneSplit,streamTwoSplit, fullscreen));
            }
            else 
            {
                Application.Run(new Form1(streamOneSplit,streamTwoSplit, width, height));
            }
            return 0;
        }
    }
}
namespace System.Strings
{
    public static class Extensions
    {
        /// <summary>
        /// Shouldnt be used right now
        /// </summary>
        /// <param name="s"></param>
        /// <returns>s split into string arrays</returns>
        public static string[] StripStart(this string s)
        {
            string[] placeholder;
            placeholder = s.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return placeholder;
        }
        //Strips the double linebreaks so that normal linebreaks will still work
        //Ignores empty
        public static string[] stripWhite(this string ss)
        {
            string[] placeholder;
            placeholder = Regex.Split(ss, "\r\n\r\n").Where(s => !string.IsNullOrEmpty(s)).ToArray();
            return placeholder;
        }
    }
}
