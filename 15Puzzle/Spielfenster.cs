using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _15Puzzle
{
    public partial class Spielfenster : Form
    {
        public Plaettchen[,] plaetze = new Plaettchen[4, 4];                    // [,] - [4, 4] gleich == [][] - [][]
        public Spielfenster()
        {
            InitializeComponent();

            this.SuspendLayout();

            List<int> verfuegbareNummern = new List<int>();     // erstelle eine Liste mit der Variable "verfuegbareNummern"
            for (int i = 1; i < 16; ++i)                         // schleife zum befüllen der Nummern
            {
                verfuegbareNummern.Add(i);                      // Speichert die Nummern aus der Schleife in die Liste
            }
            Random random = new Random();

            //Font font = new System.Drawing.Font("Microsoft JhengHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        plaetze[i, j] = null;
                        continue;
                    }
                    //Plaettchen b = new Plaettchen(this, i, j, text);
                    /*
                    b.BackColor = System.Drawing.SystemColors.ControlDark;      // Funktioniert ohne "System.Drawing" weil Bibliothek "using System.Drawing;" vorhanden ist.
                    b.Font = font;
                    b.Location = new System.Drawing.Point(128 + 72 * i, 32 + 72 * j);
                    b.Name = "buttonPlaettchen" + i + "_" + j;
                    b.Size = new System.Drawing.Size(72, 72);
                    b.TabIndex = 4 * j + i; */

                    int index = random.Next(verfuegbareNummern.Count);
                    string text = "" + verfuegbareNummern[index];
                    //b.Text = "" + verfuegbareNummern[index];            // (4 * j + i); // TODO Nummern zufällig verteilen
                    verfuegbareNummern.RemoveAt(index);
                    Plaettchen b = new Plaettchen(this, i, j, text);
                    //b.UseVisualStyleBackColor = false;
                    //b.Click += new System.EventHandler(this.Bewegen);

                    // Das Fenster erstellt ein Plaettchen und installiert es bei sich
                    plaetze[i, j] = b;
                    this.Controls.Add(b);
                }
            }
            this.ResumeLayout(false);
        }

        public void ErfolgPruefen()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 3 && j == 3)
                    {
                        if (plaetze[i, j] != null)
                        {
                            //kein Loch woanders als in 3,3: falsch
                            return;
                        }
                    }
                    else
                    {
                        if (plaetze[i, j] == null)
                        {
                            //Loch woanders als in 3,3: falsch
                            return;
                        }
                        string erwarteterText = "" + (1 + 4 * j + i);
                        if (j == 3 && i == 2)   // kann auch vertauscht sein: 15 oder 14 sind OK
                        {
                            string andererText = "" + (4 * j + i);
                            if (plaetze[i, j].Text != erwarteterText && plaetze[i, j].Text != andererText)
                            {
                                //falscher Text
                                return;
                            }
                        }
                        else if(j == 3 && i == 1) // kann auch vertauscht sein: 14 oder 15 sind OK
                        {
                            string andererText = "" + (2 + 4 * j + i);
                            if(plaetze[i, j].Text != erwarteterText && plaetze[i, j].Text != andererText)
                            {
                                return;
                            }
                        }
                        else if (plaetze[i, j].Text != erwarteterText)
                        {
                            //falscher Text
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Alles korrekt!");
        }
    }
}
// ALTER CODE - In Plaettchen Klasse verschoben
/*
private void PlaettchenBewegen(Plaettchen b, int neuI, int neuJ)
{
    /*
    // Alte Position enthält jetzt das Loch
    plaetze[b.I, b.J] = null;
    // Plättchen graphisch umplatzieren
    b.Location = new System.Drawing.Point(128 + 72 * neuI, 32 + 72 * neuJ);
    // ihm sagen, wo er jetzt ist
    b.I = neuI;
    b.J = neuJ;
    // Da, wo das Loch war, ist jetzt dieses Plättchen
    plaetze[neuI, neuJ] = b;

}

public void Bewegen(object sender, EventArgs e)
{
    Plaettchen b = sender as Plaettchen;
    if (b.I > 0 && plaetze[b.I - 1, b.J] == null)
    {
        PlaettchenBewegen(b, b.I - 1, b.J);
    }
    else if (b.I + 1 < 4 && plaetze[b.I + 1, b.J] == null)
    {
        PlaettchenBewegen(b, b.I + 1, b.J);
    }
    else if (b.J > 0 && plaetze[b.I, b.J - 1] == null)
    {
        PlaettchenBewegen(b, b.I, b.J - 1);
    }
    else if (b.J + 1 < 4 && plaetze[b.I, b.J + 1] == null)
    {
        PlaettchenBewegen(b, b.I, b.J + 1);
    }
    else
    {
        Gewonnen();
    }
                                                                            // Dient zu Überprüfung - Gibt das Array der Felder aus
                                                                            //MessageBox.Show("Geklickt: " + b.Text + "i, j =" + b.I + "," + b.J);
}
private void buttonPlaettchen_Click(object sender, EventArgs e)
{
    Bewegen(sender, e);
}
*/