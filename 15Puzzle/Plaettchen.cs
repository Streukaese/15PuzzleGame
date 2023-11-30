using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15Puzzle
{
    public class Plaettchen : Button
    {
        static Font font = new System.Drawing.Font("Microsoft JhengHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public Spielfenster Fenster { get; }
        public int I { get; set; }
        public int J { get; set; }

        public Plaettchen(Spielfenster fenster, int i, int j, string text) : base()
        {
            Fenster = fenster;
            I = i;
            J = j;
            BackColor = System.Drawing.SystemColors.ControlDark;      // Funktioniert ohne "System.Drawing" weil Bibliothek "using System.Drawing;" vorhanden ist.
            Font = font;
            Location = new System.Drawing.Point(128 + 72 * i, 32 + 72 * j);
            Name = "buttonPlaettchen" + i + "_" + j;
            Size = new System.Drawing.Size(72, 72);
            TabIndex = 4 * j + i;
            Text = text;
            UseVisualStyleBackColor = false;
            Click += new System.EventHandler(this.buttonPlaettchen_Click);
        }

        public void buttonPlaettchen_Click(object sender, EventArgs e)
        {
            if (I > 0 && Fenster.plaetze[I - 1, J] == null)
            {
                Bewegen(I - 1, J);
            }
            else if (I + 1 < 4 && Fenster.plaetze[I + 1, J] == null)
            {
                Bewegen(I + 1, J);
            }
            else if (J > 0 && Fenster.plaetze[I, J - 1] == null)
            {
                Bewegen(I, J - 1);
            }
            else if (J + 1 < 4 && Fenster.plaetze[I, J + 1] == null)
            {
                Bewegen(I, J + 1);
            }
            // Dient zu Überprüfung - Gibt das Array der Felder aus
            //MessageBox.Show("Geklickt: " + b.Text + "i, j =" + b.I + "," + b.J);
        }
        private void Bewegen(int neuI, int neuJ)
        {
            // Alte Position enthält jetzt das Loch
            Fenster.plaetze[I, J] = null;
            // Plättchen graphisch umplatzieren
            Location = new System.Drawing.Point(128 + 72 * neuI, 32 + 72 * neuJ);
            // ihm sagen, wo er jetzt ist
            I = neuI;
            J = neuJ;
            // Da, wo das Loch war, ist jetzt dieses Plättchen
            Fenster.plaetze[neuI, neuJ] = this;
        }
    }
}
