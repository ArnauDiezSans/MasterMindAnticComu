using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MasterMind
{
    class Methods
    {
        // ATRIBUTOS
        // inicializamos objeto form Master Mind
        Master_Mind masterMind = new Master_Mind();
        Organitzador organitzador = new Organitzador();
        // array de colores posibles
        Color[] colors = new Color[] {Color.Red, Color.Orange, Color.Green, Color.Blue, Color.Yellow, Color.Pink};
        // número máximo de casillas disponibles en cada juego, en este caso es constante 4
        
        private int casillasTotales = 4;
        //dificultades - 0:sin inicializar, 1:principiante, 2:medio, 3:avanzado
        private int dificultad=0;

        public int _CasillasTotales { get; set; }
        public int _Dificultad { get; set; }

        



        // variables globales para las bolas
        const int bolaAmple = 26;
        const int bolaAltura = 26;
        const int bolaMarginTop = 12;
        const int bolaMarginLeft = 12;
        const int bolaMarginRight = 12;
        const int bolaMarginBottom = 12;




        public PictureBox[] crear_colores(int numeroColores) 
        {
            // Crearem un generador d'aleatoris
            Random r = new Random();

            // Crearem un vector de boles de colors
            PictureBox[] bolascolores = new PictureBox[numeroColores];
            // Per cada posició li asignem una bola de color
            for (int i = 0; i < bolascolores.Length; i++)
            {
                bolascolores[i] = crear_bola(colors[r.Next(0, numeroColores)]);
            }
            return bolascolores;
        }
        public PictureBox[] crear_solucion()
        {
            // Crearem un generador d'aleatoris
            Random r = new Random();

            // Crearem un vector de boles de colors com a solucions
            PictureBox[] bolassolucion = new PictureBox[casillasTotales];

            // Per cada posició li asignem una bola de color
            for (int i = 0; i < bolassolucion.Length; i++)
            {
                bolassolucion[i] = crear_bola(colors[r.Next(0, 6)]);
            }
            return bolassolucion;

        }

        public void crear_linea_bola()
        {
            // método para generar cuatro bolas vacias para que el jugador pueda seleccionar el color
            // y enviar el contenido a revisar

            Button enviar = new Button();
            PictureBox[] bolasVacias = new PictureBox[casillasTotales];

            for (int i = 0; i <= casillasTotales; i++)
            {
                bolasVacias[i] = crear_bola(Color.White);
                bolasVacias[i].Click += new System.EventHandler(organitzador.bola_Click);
            }

            enviar.Text = "Enviar";
            enviar.Click += (sender, EventArgs) => { organitzador.enviar_Click(sender, EventArgs, bolasVacias);  };

        }

        public PictureBox crear_bola(Color color)
        {
            // método per crear una bola con el color pasado por parámetro

            PictureBox bola = new PictureBox();

            bola.Width = 50;
            bola.Height = 350;
            bola.BorderStyle = BorderStyle.FixedSingle;
            bola.Margin = new System.Windows.Forms.Padding(bolaMarginLeft, bolaMarginTop, bolaMarginRight, bolaMarginBottom);
            bola.BackColor = color;
            bola.Left = 300;
            
            return bola;

        }

        public PictureBox[] CheckResults(PictureBox[] linea, PictureBox[] solucio)
        {
            //Creo las variables de cantidad de negras y blancas, ademas de un array de bolas para dar de resultado
            int negras = 0;
            int blancas = 0;
            PictureBox[] resultat = new PictureBox[casillasTotales];

            for (int i=0; i < casillasTotales; i++)
            {
                if (linea[i].BackColor == solucio[i].BackColor)
                {
                    negras++;
                }
                else
                {
                    for (int x=i; x< casillasTotales; x++)
                    {
                        if (linea[x].BackColor == solucio[x].BackColor)
                        {
                            blancas++;
                        }
                    }
                }
            }
            for (int i=0; i<casillasTotales; i++)
            {
                if (negras > 0)
                {
                    resultat[i].BackColor = Color.Black;
                    negras--;
                }
                else if (blancas > 0)
                    {
                    resultat[i].BackColor = Color.White;
                    blancas--;
                    }
                else
                {
                    resultat[i].BackColor = Color.Gray;
                }
            }
            return resultat;
        }
        // retorna un PictureBox[casillasTotales] ple amb el resultat de blanques i negres de la linea que li pasem
    }
}
