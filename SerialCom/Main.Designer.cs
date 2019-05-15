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
            this.buttonClear = new System.Windows.Forms.Button();
            this.richTextBoxRX = new System.Windows.Forms.RichTextBox();
            this.buttonDisplaySensors = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(292, 383);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // richTextBoxRX
            // 
            this.richTextBoxRX.Location = new System.Drawing.Point(54, 27);
            this.richTextBoxRX.Name = "richTextBoxRX";
            this.richTextBoxRX.Size = new System.Drawing.Size(557, 350);
            this.richTextBoxRX.TabIndex = 3;
            this.richTextBoxRX.Text = "";
            // 
            // buttonDisplaySensors
            // 
            this.buttonDisplaySensors.Location = new System.Drawing.Point(617, 337);
            this.buttonDisplaySensors.Name = "buttonDisplaySensors";
            this.buttonDisplaySensors.Size = new System.Drawing.Size(75, 40);
            this.buttonDisplaySensors.TabIndex = 8;
            this.buttonDisplaySensors.Text = "Sensor Data";
            this.buttonDisplaySensors.UseVisualStyleBackColor = true;
            this.buttonDisplaySensors.Click += new System.EventHandler(this.buttonDisplaySensors_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDisplaySensors);
            this.Controls.Add(this.richTextBoxRX);
            this.Controls.Add(this.buttonClear);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.RichTextBox richTextBoxRX;
        private System.Windows.Forms.Button buttonDisplaySensors;
    }
}

