using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace SerialCom
{

    public partial class SensorData : Form
    {
        private const int REED = 0;
        private const int TEMP = 1;

        private byte selectedSensor = 255;
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
            populateSensorList();
        }

        private void SensorData_FormClosed(object sender, FormClosedEventArgs e)
        {
           /* if (this.mainForm.serialPort1.IsOpen)
            {
                this.mainForm.serialPort1.Close();
            }*/
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
                richTextBoxhSensorData.AppendText("The database contains the following packets:\n(Address, Type, " +
                    "Data, Sequence, Empty Checksum, Creation Date)\n");

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
            richTextBoxhSensorData.AppendText(packet.Contents + '\n');
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


        private void populateSensorList()
        {
            List<byte> addresses = new List<byte>();
            addresses = SensorDataAccess.ListSensorAddresses();

            foreach (byte address in addresses)
            {
                listBoxSensors.Items.Add(address.ToString());
            }
        }

        private void listBoxSensors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSensors.SelectedItem != null)
            {
                string selected = listBoxSensors.SelectedItem.ToString();
                selectedSensor = Byte.Parse(selected);
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            List<Packet> packetList = new List<Packet>();
            packetList = SensorDataAccess.ListByAddress(selectedSensor);
            displayPacketList(packetList);
        }
    }
}
