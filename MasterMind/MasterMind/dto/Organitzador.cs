using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMind
{
    class Organitzador
    {
        Methods metodos = new Methods();

        public bool Iniciar(bool principiante, bool medio, bool avanzado)
        {
            
            metodos._Dificultad = 0;
            if (principiante)
            {
                metodos._Dificultad = 4;
            }
            else if (medio)
            {
                metodos._Dificultad = 5;
            }
            else if (avanzado)
            {
                metodos._Dificultad = 6;
            }
            else
            {
                MessageBox.Show("Has d'escollir una dificultat per poder iniciar...");
                return false;
            }
            return true;
        }

        public void Constructor()
        {
            PictureBox[] solucio = metodos.crear_solucion();

        }


        public void enviar_Click(object sender, EventArgs e, PictureBox[] bolasNuevas)
        {

            //metodos.CheckResults(bolasNuevas, solucio);
        }

        public void bola_Click(object sender, EventArgs e)
        {
            PictureBox box = sender as PictureBox;

            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = box.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                box.BackColor = MyDialog.Color;
            }
        }





    }
}
