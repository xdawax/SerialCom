using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace SerialCom
{

    public partial class SensorData : Form
    {
        private Main mainForm = null;
        public SensorData()
        {
            InitializeComponent();
        }

        public SensorData(Form callingForm)
        {
            mainForm = callingForm as Main;
            InitializeComponent();
        }

        private void SensorData_Load(object sender, EventArgs e)
        {

        }

        private void SensorData_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.mainForm.mySerialPort.IsOpen)
            {
                this.mainForm.mySerialPort.Close();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show();
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            // visa data för samtliga element i kön
            richTextBoxhSensorData.Clear();
            List<Packet> packetList = new List<Packet>();
            packetList = SensorDataAccess.LoadAll();

            if (packetList.Count > 0)
            {
                richTextBoxhSensorData.AppendText("The database contains the following packets: \n");

                foreach (Packet packet in packetList)
                {
                    displayPacketContent(packet);
                }
            }
            else
            {
                richTextBoxhSensorData.AppendText("There is nothing in the queue!!");
            }
        }

        public void displayPacketContent(Packet packet)
        {
            string sens;

            switch (packet.Type)
            {
                case 0:
                    sens = "REED";
                    break;
                case 1:
                    sens = "TEMP";
                    break;
                default:
                    sens = "UNDEFINED";
                    break;
            }

            richTextBoxhSensorData.AppendText("Packet contents: \n");
            richTextBoxhSensorData.AppendText("Address: " + (packet.Address).ToString() + "\n");
            richTextBoxhSensorData.AppendText("Type: " + sens + "\n");
            richTextBoxhSensorData.AppendText("Data: " + (packet.Data).ToString() + "\n");
        }

        private void buttonTemp_Click(object sender, EventArgs e)
        {

        }
    }
}
