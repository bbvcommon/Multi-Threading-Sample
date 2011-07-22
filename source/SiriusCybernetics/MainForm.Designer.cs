namespace SiriusCybernetics
{
    partial class MainForm
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
            this.vhpts = new System.Windows.Forms.TabControl();
            this.jokeImport = new SiriusCybernetics.JokeImport.JokeImportUserControl();
            this.jokeTellingMonitorUserControl = new SiriusCybernetics.JokeTelling.JokeTellingMonitorUserControl();
            this.SuspendLayout();
            // 
            // vhpts
            // 
            this.vhpts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vhpts.Location = new System.Drawing.Point(255, 12);
            this.vhpts.Name = "vhpts";
            this.vhpts.SelectedIndex = 0;
            this.vhpts.Size = new System.Drawing.Size(533, 473);
            this.vhpts.TabIndex = 0;
            // 
            // jokeImport
            // 
            this.jokeImport.Location = new System.Drawing.Point(12, 12);
            this.jokeImport.Name = "jokeImport";
            this.jokeImport.Size = new System.Drawing.Size(81, 29);
            this.jokeImport.TabIndex = 1;
            // 
            // jokeTellingMonitorUserControl1
            // 
            this.jokeTellingMonitorUserControl.Location = new System.Drawing.Point(12, 47);
            this.jokeTellingMonitorUserControl.Name = "jokeTellingMonitorUserControl";
            this.jokeTellingMonitorUserControl.Size = new System.Drawing.Size(155, 89);
            this.jokeTellingMonitorUserControl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.jokeTellingMonitorUserControl);
            this.Controls.Add(this.jokeImport);
            this.Controls.Add(this.vhpts);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl vhpts;
        private JokeImport.JokeImportUserControl jokeImport;
        private JokeTelling.JokeTellingMonitorUserControl jokeTellingMonitorUserControl;

    }
}

