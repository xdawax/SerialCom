namespace SerialCom
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.richTextBoxTX = new System.Windows.Forms.RichTextBox();
            this.richTextBoxRX = new System.Windows.Forms.RichTextBox();
            this.checkBoxIM = new System.Windows.Forms.CheckBox();
            this.mySerialPort = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxComPorts = new System.Windows.Forms.ListBox();
            this.buttonSelectCom = new System.Windows.Forms.Button();
            this.buttonDisplaySensors = new System.Windows.Forms.Button();
            this.buttonDebug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(640, 12);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(295, 414);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // richTextBoxTX
            // 
            this.richTextBoxTX.Location = new System.Drawing.Point(54, 12);
            this.richTextBoxTX.Name = "richTextBoxTX";
            this.richTextBoxTX.Size = new System.Drawing.Size(557, 40);
            this.richTextBoxTX.TabIndex = 2;
            this.richTextBoxTX.Text = "";
            this.richTextBoxTX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxTX_KeyPress);
            // 
            // richTextBoxRX
            // 
            this.richTextBoxRX.Location = new System.Drawing.Point(54, 58);
            this.richTextBoxRX.Name = "richTextBoxRX";
            this.richTextBoxRX.Size = new System.Drawing.Size(557, 350);
            this.richTextBoxRX.TabIndex = 3;
            this.richTextBoxRX.Text = "";
            // 
            // checkBoxIM
            // 
            this.checkBoxIM.AutoSize = true;
            this.checkBoxIM.Location = new System.Drawing.Point(640, 42);
            this.checkBoxIM.Name = "checkBoxIM";
            this.checkBoxIM.Size = new System.Drawing.Size(38, 17);
            this.checkBoxIM.TabIndex = 4;
            this.checkBoxIM.Text = "IM";
            this.checkBoxIM.UseVisualStyleBackColor = true;
            // 
            // mySerialPort
            // 
            this.mySerialPort.BaudRate = 38400;
            this.mySerialPort.PortName = "UNDEFINED";
            this.mySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.mySerialPort_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(637, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Com Ports";
            // 
            // listBoxComPorts
            // 
            this.listBoxComPorts.FormattingEnabled = true;
            this.listBoxComPorts.Location = new System.Drawing.Point(640, 284);
            this.listBoxComPorts.Name = "listBoxComPorts";
            this.listBoxComPorts.Size = new System.Drawing.Size(75, 95);
            this.listBoxComPorts.TabIndex = 6;
            this.listBoxComPorts.SelectedIndexChanged += new System.EventHandler(this.listBoxComPorts_SelectedIndexChanged);
            // 
            // buttonSelectCom
            // 
            this.buttonSelectCom.Location = new System.Drawing.Point(640, 385);
            this.buttonSelectCom.Name = "buttonSelectCom";
            this.buttonSelectCom.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectCom.TabIndex = 7;
            this.buttonSelectCom.Text = "Connect";
            this.buttonSelectCom.UseVisualStyleBackColor = true;
            this.buttonSelectCom.Click += new System.EventHandler(this.buttonSelectCom_Click);
            // 
            // buttonDisplaySensors
            // 
            this.buttonDisplaySensors.Location = new System.Drawing.Point(640, 104);
            this.buttonDisplaySensors.Name = "buttonDisplaySensors";
            this.buttonDisplaySensors.Size = new System.Drawing.Size(75, 23);
            this.buttonDisplaySensors.TabIndex = 8;
            this.buttonDisplaySensors.Text = "Sensor Data";
            this.buttonDisplaySensors.UseVisualStyleBackColor = true;
            this.buttonDisplaySensors.Click += new System.EventHandler(this.buttonDisplaySensors_Click);
            // 
            // buttonDebug
            // 
            this.buttonDebug.Location = new System.Drawing.Point(640, 168);
            this.buttonDebug.Name = "buttonDebug";
            this.buttonDebug.Size = new System.Drawing.Size(75, 40);
            this.buttonDebug.TabIndex = 9;
            this.buttonDebug.Text = "Send Debug Packet";
            this.buttonDebug.UseVisualStyleBackColor = true;
            this.buttonDebug.Click += new System.EventHandler(this.buttonDebug_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDebug);
            this.Controls.Add(this.buttonDisplaySensors);
            this.Controls.Add(this.buttonSelectCom);
            this.Controls.Add(this.listBoxComPorts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxIM);
            this.Controls.Add(this.richTextBoxRX);
            this.Controls.Add(this.richTextBoxTX);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSend);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.RichTextBox richTextBoxTX;
        private System.Windows.Forms.RichTextBox richTextBoxRX;
        private System.Windows.Forms.CheckBox checkBoxIM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxComPorts;
        private System.Windows.Forms.Button buttonSelectCom;
        private System.Windows.Forms.Button buttonDisplaySensors;
        public System.IO.Ports.SerialPort mySerialPort;
        private System.Windows.Forms.Button buttonDebug;
    }
}

