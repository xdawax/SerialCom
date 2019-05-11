namespace SerialCom
{
    partial class SensorData
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.richTextBoxhSensorData = new System.Windows.Forms.RichTextBox();
            this.buttonDoor = new System.Windows.Forms.Button();
            this.buttonTemp = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(28, 405);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // richTextBoxhSensorData
            // 
            this.richTextBoxhSensorData.Location = new System.Drawing.Point(132, 26);
            this.richTextBoxhSensorData.Name = "richTextBoxhSensorData";
            this.richTextBoxhSensorData.Size = new System.Drawing.Size(639, 402);
            this.richTextBoxhSensorData.TabIndex = 1;
            this.richTextBoxhSensorData.Text = "";
            // 
            // buttonDoor
            // 
            this.buttonDoor.Location = new System.Drawing.Point(28, 26);
            this.buttonDoor.Name = "buttonDoor";
            this.buttonDoor.Size = new System.Drawing.Size(75, 23);
            this.buttonDoor.TabIndex = 2;
            this.buttonDoor.Text = "Door";
            this.buttonDoor.UseVisualStyleBackColor = true;
            this.buttonDoor.Click += new System.EventHandler(this.buttonDoor_Click);
            // 
            // buttonTemp
            // 
            this.buttonTemp.Location = new System.Drawing.Point(28, 55);
            this.buttonTemp.Name = "buttonTemp";
            this.buttonTemp.Size = new System.Drawing.Size(75, 23);
            this.buttonTemp.TabIndex = 3;
            this.buttonTemp.Text = "Temperature";
            this.buttonTemp.UseVisualStyleBackColor = true;
            this.buttonTemp.Click += new System.EventHandler(this.buttonTemp_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.Location = new System.Drawing.Point(28, 84);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(75, 23);
            this.buttonAll.TabIndex = 4;
            this.buttonAll.Text = "All";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // SensorData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.buttonTemp);
            this.Controls.Add(this.buttonDoor);
            this.Controls.Add(this.richTextBoxhSensorData);
            this.Controls.Add(this.buttonBack);
            this.Name = "SensorData";
            this.Text = "SensorData";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SensorData_FormClosed);
            this.Load += new System.EventHandler(this.SensorData_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.RichTextBox richTextBoxhSensorData;
        private System.Windows.Forms.Button buttonDoor;
        private System.Windows.Forms.Button buttonTemp;
        private System.Windows.Forms.Button buttonAll;
    }
}