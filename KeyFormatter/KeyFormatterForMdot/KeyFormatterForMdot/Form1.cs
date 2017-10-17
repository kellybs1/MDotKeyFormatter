using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyFormatterForMdot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //runs conversion
        private void button1_Click(object sender, EventArgs e)
        {
            //pull value
            string startKey = textBoxServerKey.Text;

            //convert key
            string resultKey = KeyChanger.FormatKey(startKey);

            //set output
            textBoxMDotKey.Text = resultKey;
        }

        //pastes from clipboard to textbox if possible
        private void button2_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
                textBoxServerKey.Text = Clipboard.GetText();
        }
    }
}
