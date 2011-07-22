namespace SiriusCybernetics.JokeImport
{
    partial class JokeImportUserControl
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
            this.importJokes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // importJokes
            // 
            this.importJokes.Location = new System.Drawing.Point(3, 3);
            this.importJokes.Name = "importJokes";
            this.importJokes.Size = new System.Drawing.Size(75, 23);
            this.importJokes.TabIndex = 0;
            this.importJokes.Text = "Import Jokes";
            this.importJokes.UseVisualStyleBackColor = true;
            this.importJokes.Click += new System.EventHandler(this.HandleImportJokesClick);
            // 
            // JokeImportUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.importJokes);
            this.Name = "JokeImportUserControl";
            this.Size = new System.Drawing.Size(81, 29);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button importJokes;
    }
}
