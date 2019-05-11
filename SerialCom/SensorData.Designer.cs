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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonDoor = new System.Windows.Forms.Button();
            this.buttonTemp = new System.Windows.Forms.Button();
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(132, 26);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(639, 402);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // buttonDoor
            // 
            this.buttonDoor.Location = new System.Drawing.Point(28, 26);
            this.buttonDoor.Name = "buttonDoor";
            this.buttonDoor.Size = new System.Drawing.Size(75, 23);
            this.buttonDoor.TabIndex = 2;
            this.buttonDoor.Text = "Door";
            this.buttonDoor.UseVisualStyleBackColor = true;
            // 
            // buttonTemp
            // 
            this.buttonTemp.Location = new System.Drawing.Point(28, 55);
            this.buttonTemp.Name = "buttonTemp";
            this.buttonTemp.Size = new System.Drawing.Size(75, 23);
            this.buttonTemp.TabIndex = 3;
            this.buttonTemp.Text = "Temperature";
            this.buttonTemp.UseVisualStyleBackColor = true;
            // 
            // SensorData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonTemp);
            this.Controls.Add(this.buttonDoor);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonBack);
            this.Name = "SensorData";
            this.Text = "SensorData";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SensorData_FormClosed);
            this.Load += new System.EventHandler(this.SensorData_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonDoor;
        private System.Windows.Forms.Button buttonTemp;
    }
}