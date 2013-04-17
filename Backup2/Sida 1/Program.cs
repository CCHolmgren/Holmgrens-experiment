using System;
using System.Strings;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using CommandLine.Utility;
using System.Drawing;

namespace Sida_1
{
    static class Program
    {
        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        static int Main(string[] Args)
        {
            int width = 800;
            int height = 600;
            StreamReader streamOne;
            StreamReader streamTwo;
            StreamReader streamThree;
            string streamOneText;
            string streamTwoText;
            string streamThreeText;
            Arguments CommandLine = new Arguments(Args);
            if (CommandLine["height"] != null)
                height = Int32.Parse(CommandLine["height"]);
            if (CommandLine["width"] != null)
                width = Int32.Parse(CommandLine["width"]);
            if (CommandLine["native"] != null)
            {
                width = Screen.PrimaryScreen.Bounds.Width;
                height = Screen.PrimaryScreen.Bounds.Height;
            }
            //Reads a file from C:\\
            //And passes it to Form1
            {
                streamOne = new StreamReader("Default.txt", System.Text.Encoding.Default);
                streamOneText = streamOne.ReadToEnd();
                streamOne.Close();
            }
            {
                streamTwo = new StreamReader("DefaultStatement.txt", System.Text.Encoding.Default);
                streamTwoText = streamTwo.ReadToEnd();
                streamTwo.Close();
            }
            {
                streamThree = new StreamReader("Brevet.txt", System.Text.Encoding.Default);
                streamThreeText = streamThree.ReadToEnd();
                streamThree.Close();
            }
            //Splits the string into several with a extension to string
            //Fixed now with regex, not the fastest, but easiest
            string[] streamOneSplit = streamOneText.stripWhite();
            string[] streamTwoSplit = streamTwoText.stripWhite("\r\n");
            string[] streamThreeSplit = streamThreeText.stripWhite();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(streamOneSplit, streamTwoSplit,streamThreeSplit, width, height));
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
        /// <summary>
        /// Will strip out double line breaks
        /// Ignores empty lines
        /// </summary>
        /// <param name="ss"></param>
        /// <returns></returns>
        public static string[] stripWhite(this string ss)
        {
            string[] placeholder;
            placeholder = Regex.Split(ss, "\r\n\r\n").Where(s => !string.IsNullOrEmpty(s)).ToArray();
            return placeholder;
        }
        /// <summary>
        /// Used for arbitrary split
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="stripper"></param>
        /// <returns></returns>
        public static string[] stripWhite(this string ss,string stripper)
        {
            string[] placeholder;
            placeholder = Regex.Split(ss, stripper).Where(s => !string.IsNullOrEmpty(s)).ToArray();
            return placeholder;
        }
    }
}
