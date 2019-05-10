using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileByteTestTool
{
    using System.IO;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] fileBytes = null;
            using (var openFileDialog1 = new OpenFileDialog())
            {
                Stream fileStream;
                if (openFileDialog1.ShowDialog() == DialogResult.OK && (fileStream = openFileDialog1.OpenFile()) != null)
                {
                    using (fileStream)
                    {
                        using (var ms = new MemoryStream())
                        {
                            fileStream.CopyTo(ms);
                            fileBytes = ms.ToArray();
                            
                        }
                    }
                }
            }

            if (fileBytes != null)
            {
                var encodedString = Convert.ToBase64String(fileBytes);
                textBox1.MaxLength = encodedString.Length + 1;
                textBox1.Text = encodedString;
            }
        }
    }
}
