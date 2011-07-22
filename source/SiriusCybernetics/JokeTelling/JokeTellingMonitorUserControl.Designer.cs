namespace SiriusCybernetics.JokeTelling
{
    partial class JokeTellingMonitorUserControl
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
            this.numberOfToldJokesCaption = new System.Windows.Forms.Label();
            this.numberOfJokes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // numberOfToldJokesCaption
            // 
            this.numberOfToldJokesCaption.AutoSize = true;
            this.numberOfToldJokesCaption.Location = new System.Drawing.Point(4, 4);
            this.numberOfToldJokesCaption.Name = "numberOfToldJokesCaption";
            this.numberOfToldJokesCaption.Size = new System.Drawing.Size(121, 39);
            this.numberOfToldJokesCaption.TabIndex = 0;
            this.numberOfToldJokesCaption.Text = "Number of told jokes \r\nsince start of monitoring \r\napplication";
            // 
            // numberOfJokes
            // 
            this.numberOfJokes.Location = new System.Drawing.Point(7, 47);
            this.numberOfJokes.Name = "numberOfJokes";
            this.numberOfJokes.ReadOnly = true;
            this.numberOfJokes.Size = new System.Drawing.Size(100, 20);
            this.numberOfJokes.TabIndex = 1;
            // 
            // JokeTellingMonitorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numberOfJokes);
            this.Controls.Add(this.numberOfToldJokesCaption);
            this.Name = "JokeTellingMonitorUserControl";
            this.Size = new System.Drawing.Size(126, 73);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberOfToldJokesCaption;
        private System.Windows.Forms.TextBox numberOfJokes;
    }
}
