namespace _15Puzzle
{
    partial class Spielfenster
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPlaettchen00 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPlaettchen00
            // 
            this.buttonPlaettchen00.Location = new System.Drawing.Point(12, 12);
            this.buttonPlaettchen00.Name = "buttonPlaettchen00";
            this.buttonPlaettchen00.Size = new System.Drawing.Size(75, 23);
            this.buttonPlaettchen00.TabIndex = 0;
            this.buttonPlaettchen00.Visible = false;
            // 
            // Spielfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonPlaettchen00);
            this.Name = "Spielfenster";
            this.Text = "15 Puzzle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlaettchen00;
    }
}

