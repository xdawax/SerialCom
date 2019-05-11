using System;
using System.Windows.Forms;

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
    }
}
