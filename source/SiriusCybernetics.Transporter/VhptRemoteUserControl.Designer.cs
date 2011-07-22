namespace SiriusCybernetics
{
    partial class VhptRemoteUserControl
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
            this.requestTransportationButton = new System.Windows.Forms.Button();
            this.requestDestinationButton = new System.Windows.Forms.Button();
            this.transportationFloor = new System.Windows.Forms.NumericUpDown();
            this.destinationFloor = new System.Windows.Forms.NumericUpDown();
            this.vhptNameLabel = new System.Windows.Forms.Label();
            this.vhptNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.transportationFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationFloor)).BeginInit();
            this.SuspendLayout();
            // 
            // requestTransportationButton
            // 
            this.requestTransportationButton.Location = new System.Drawing.Point(17, 43);
            this.requestTransportationButton.Name = "requestTransportationButton";
            this.requestTransportationButton.Size = new System.Drawing.Size(177, 23);
            this.requestTransportationButton.TabIndex = 0;
            this.requestTransportationButton.Text = "Request Transportation on Floor";
            this.requestTransportationButton.UseVisualStyleBackColor = true;
            this.requestTransportationButton.Click += new System.EventHandler(this.HandleRequestTransportationButtonClicked);
            // 
            // requestDestinationButton
            // 
            this.requestDestinationButton.Location = new System.Drawing.Point(17, 72);
            this.requestDestinationButton.Name = "requestDestinationButton";
            this.requestDestinationButton.Size = new System.Drawing.Size(177, 23);
            this.requestDestinationButton.TabIndex = 1;
            this.requestDestinationButton.Text = "Request Destination to Floor";
            this.requestDestinationButton.UseVisualStyleBackColor = true;
            this.requestDestinationButton.Click += new System.EventHandler(this.HandleRequestDestinationButtonClicked);
            // 
            // transportationFloor
            // 
            this.transportationFloor.Location = new System.Drawing.Point(215, 45);
            this.transportationFloor.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.transportationFloor.Name = "transportationFloor";
            this.transportationFloor.Size = new System.Drawing.Size(53, 20);
            this.transportationFloor.TabIndex = 2;
            // 
            // destinationFloor
            // 
            this.destinationFloor.Location = new System.Drawing.Point(215, 71);
            this.destinationFloor.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.destinationFloor.Name = "destinationFloor";
            this.destinationFloor.Size = new System.Drawing.Size(53, 20);
            this.destinationFloor.TabIndex = 2;
            // 
            // vhptNameLabel
            // 
            this.vhptNameLabel.AutoSize = true;
            this.vhptNameLabel.Location = new System.Drawing.Point(18, 20);
            this.vhptNameLabel.Name = "vhptNameLabel";
            this.vhptNameLabel.Size = new System.Drawing.Size(75, 13);
            this.vhptNameLabel.TabIndex = 3;
            this.vhptNameLabel.Text = "Name of Vpht:";
            // 
            // vhptNameTextBox
            // 
            this.vhptNameTextBox.Location = new System.Drawing.Point(99, 17);
            this.vhptNameTextBox.Name = "vhptNameTextBox";
            this.vhptNameTextBox.ReadOnly = true;
            this.vhptNameTextBox.Size = new System.Drawing.Size(169, 20);
            this.vhptNameTextBox.TabIndex = 4;
            // 
            // VhptUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vhptNameTextBox);
            this.Controls.Add(this.vhptNameLabel);
            this.Controls.Add(this.destinationFloor);
            this.Controls.Add(this.transportationFloor);
            this.Controls.Add(this.requestDestinationButton);
            this.Controls.Add(this.requestTransportationButton);
            this.Name = "VhptRemoteUserControl";
            this.Size = new System.Drawing.Size(289, 148);
            ((System.ComponentModel.ISupportInitialize)(this.transportationFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationFloor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button requestTransportationButton;
        private System.Windows.Forms.Button requestDestinationButton;
        private System.Windows.Forms.NumericUpDown transportationFloor;
        private System.Windows.Forms.NumericUpDown destinationFloor;
        private System.Windows.Forms.Label vhptNameLabel;
        private System.Windows.Forms.TextBox vhptNameTextBox;
    }
}
