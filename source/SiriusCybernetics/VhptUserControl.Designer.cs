namespace SiriusCybernetics
{
    partial class VhptUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lastFloor = new System.Windows.Forms.TextBox();
            this.powerOn = new System.Windows.Forms.Button();
            this.powerOff = new System.Windows.Forms.Button();
            this.destination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passengerOnBoard = new System.Windows.Forms.CheckBox();
            this.transportingPassenger = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last Floor";
            // 
            // lastFloor
            // 
            this.lastFloor.Location = new System.Drawing.Point(64, 4);
            this.lastFloor.Name = "lastFloor";
            this.lastFloor.ReadOnly = true;
            this.lastFloor.Size = new System.Drawing.Size(100, 20);
            this.lastFloor.TabIndex = 1;
            // 
            // powerOn
            // 
            this.powerOn.Location = new System.Drawing.Point(459, 4);
            this.powerOn.Name = "powerOn";
            this.powerOn.Size = new System.Drawing.Size(75, 23);
            this.powerOn.TabIndex = 2;
            this.powerOn.Text = "Power On";
            this.powerOn.UseVisualStyleBackColor = true;
            this.powerOn.Click += new System.EventHandler(this.HandlePowerOnClick);
            // 
            // powerOff
            // 
            this.powerOff.Enabled = false;
            this.powerOff.Location = new System.Drawing.Point(459, 34);
            this.powerOff.Name = "powerOff";
            this.powerOff.Size = new System.Drawing.Size(75, 23);
            this.powerOff.TabIndex = 3;
            this.powerOff.Text = "Power Off";
            this.powerOff.UseVisualStyleBackColor = true;
            this.powerOff.Click += new System.EventHandler(this.HandlePowerOffClick);
            // 
            // destination
            // 
            this.destination.Location = new System.Drawing.Point(64, 30);
            this.destination.Name = "destination";
            this.destination.ReadOnly = true;
            this.destination.Size = new System.Drawing.Size(100, 20);
            this.destination.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Destination";
            // 
            // passengerOnBoard
            // 
            this.passengerOnBoard.AutoSize = true;
            this.passengerOnBoard.Enabled = false;
            this.passengerOnBoard.Location = new System.Drawing.Point(7, 56);
            this.passengerOnBoard.Name = "passengerOnBoard";
            this.passengerOnBoard.Size = new System.Drawing.Size(121, 17);
            this.passengerOnBoard.TabIndex = 6;
            this.passengerOnBoard.Text = "Passenger on board";
            this.passengerOnBoard.UseVisualStyleBackColor = true;
            // 
            // transportingPassenger
            // 
            this.transportingPassenger.AutoSize = true;
            this.transportingPassenger.Enabled = false;
            this.transportingPassenger.Location = new System.Drawing.Point(7, 79);
            this.transportingPassenger.Name = "transportingPassenger";
            this.transportingPassenger.Size = new System.Drawing.Size(201, 17);
            this.transportingPassenger.TabIndex = 7;
            this.transportingPassenger.Text = "Transporting or picking up passenger";
            this.transportingPassenger.UseVisualStyleBackColor = true;
            // 
            // VhptUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.transportingPassenger);
            this.Controls.Add(this.passengerOnBoard);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.powerOff);
            this.Controls.Add(this.powerOn);
            this.Controls.Add(this.lastFloor);
            this.Controls.Add(this.label1);
            this.Name = "VhptUserControl";
            this.Size = new System.Drawing.Size(556, 289);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lastFloor;
        private System.Windows.Forms.Button powerOn;
        private System.Windows.Forms.Button powerOff;
        private System.Windows.Forms.TextBox destination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox passengerOnBoard;
        private System.Windows.Forms.CheckBox transportingPassenger;
    }
}
