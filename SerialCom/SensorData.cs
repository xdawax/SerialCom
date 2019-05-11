using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace SerialCom
{

    public partial class SensorData : Form
    {
        private const int REED = 0;
        private const int TEMP = 1;

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
            List<Packet> packetList = new List<Packet>();
            packetList = SensorDataAccess.ListAll();
            displayPacketList(packetList);
        }

        public void displayPacketList(List<Packet> packetList)
        {
            richTextBoxhSensorData.Clear();
            if (packetList.Count > 0)
            {
                richTextBoxhSensorData.AppendText("The database contains the following packets: \n");

                foreach (Packet packet in packetList)
                {
                    Packet dePack = packet;
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
                case Packet.Sensor_t.REED:
                    sens = "REED";
                    break;
                case Packet.Sensor_t.TEMP:
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
            List<Packet> packetList = new List<Packet>();
            packetList = SensorDataAccess.ListSensorTypeData(TEMP);
            displayPacketList(packetList);
        }

        private void buttonDoor_Click(object sender, EventArgs e)
        {
            List<Packet> packetList = new List<Packet>();
            packetList = SensorDataAccess.ListSensorTypeData(REED);
            displayPacketList(packetList);
        }
    }
}
