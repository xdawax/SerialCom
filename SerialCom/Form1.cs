using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialCom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (!mySerialPort.IsOpen)
            {
                mySerialPort.Open();
                richTextBoxRX.Text = "Serial port is open :)";
            } 
            else
            {
                richTextBoxRX.Text = "Serial port is busy :(";
            }
        }


        private string rxString;
        private void mySerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            rxString = mySerialPort.ReadExisting();
            this.Invoke(new EventHandler(displayText));
        }

        private void displayText(object o, EventArgs e)
        {
            richTextBoxRX.AppendText(rxString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            mySerialPort.Write(richTextBoxTX.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxTX.Clear();
            richTextBoxRX.Clear();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mySerialPort.Close();
        }

        private void richTextBoxTX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mySerialPort.IsOpen && checkBoxIM.Checked)
            {
                char[] ch = new char[1];
                ch[0] = e.KeyChar;
                mySerialPort.Write(ch, 0, 1);
            }
        }
    }
}
