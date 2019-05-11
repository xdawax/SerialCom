﻿using System;
using System.Windows.Forms;
using System.Collections;

namespace SerialCom
{



    public partial class Main : Form
    {
        private static int BUF_ADDRESS = 0;
        private static int BUF_TYPE = 1;
        private static int BUF_DATA0 = 2;
        private static int BUF_DATA1 = 3;
        private static int BUF_DATA2 = 4;
        private static int BUF_DATA3 = 5;
        private static int BUF_STAMP0 = 6;
        private static int BUF_STAMP1 = 7;
        private static int BUF_STAMP2 = 8;
        private static int BUF_STAMP3 = 9;
        private static int BUF_STAMP4 = 10;
        private const int REED = 0;
        private const int TEMP = 1;

        public Queue packetQueue = new Queue();
        private byte packetSize = 6;
        private string comPort = "UNDEFINED";

        public Main()
        {
            InitializeComponent();

            populateComPorts();

            buttonSend.Enabled = false;
            checkBoxIM.Enabled = false;
        }

        private void populateComPorts()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();

            // Display each port name to the console.
            foreach (string port in ports)
            {
                listBoxComPorts.Items.Add(port);
            }
        }

        private void mySerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte received = 0;
            byte[] rxBuf = new byte[255];

            for (int i = 0; i < packetSize; i++)
            {
                received = (byte)mySerialPort.ReadByte();
                rxBuf[i] = received;
            }

            handleData(rxBuf);
            this.Invoke(new EventHandler(displayText));
        }

        private void handleData(byte[] buf)
        {
            Packet packet = new Packet();

            packet.Address = buf[BUF_ADDRESS];
            packet.Type = buf[BUF_TYPE];

            packet.Data = BitConverter.ToInt32(buf, BUF_DATA0);

            SensorDataAccess.SaveData(packet);
        }

        private void displayPacketContent(Packet packet)
        {
            string sens;

            switch (packet.Type)
            {
                case REED:
                    sens = "REED";
                    break;
                case TEMP:
                    sens = "TEMP";
                    break;
                default:
                    sens = "UNDEFINED";
                    break;
            }

            richTextBoxRX.AppendText("Packet contents: \n");
            richTextBoxRX.AppendText("Address: " + (packet.Address).ToString() + "\n");
            richTextBoxRX.AppendText("Type: " + sens + "\n");
            richTextBoxRX.AppendText("Data: " + (packet.Data).ToString() + "\n");
        }

        private string bufToString(byte[] buf)
        {
            string bufString = string.Empty;

            foreach (byte b in buf)
            {
                bufString += (Char)b;
            }

            return bufString;
        }

        private void displayText(object o, EventArgs e)
        {
            // visa data för samtliga element i kön
            richTextBoxRX.Clear();

            if (packetQueue.Count > 0)
            {
                richTextBoxRX.AppendText("The queue contains the following packets: \n");

                foreach (Packet packet in packetQueue)
                {
                    displayPacketContent(packet);
                }
            }
            else
            {
                richTextBoxRX.AppendText("There is nothing in the queue!!");
            }
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

        private void listBoxComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPort = listBoxComPorts.SelectedItem.ToString();
        }

        private void buttonSelectCom_Click(object sender, EventArgs e)
        {
            string port = comPort;
            if (comPort == "UNDEFINED")
            {
                MessageBox.Show("No com port selected!");
            }
            else
            {
                if (mySerialPort.IsOpen)
                {
                    mySerialPort.Close();
                }
                mySerialPort.PortName = comPort;
                mySerialPort.Open();
                buttonSend.Enabled = true;
                checkBoxIM.Enabled = true;
            }
        }

        private void buttonDisplaySensors_Click(object sender, EventArgs e)
        {
            this.Hide();
            SensorData sensData = new SensorData(this);
            sensData.Show();
        }

        public void closeSerialPort()
        {
            mySerialPort.Close();
        }
    }

}