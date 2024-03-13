using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoChuyFantasma
{
    
    internal  class Protagonista : Actor
    {
        int x2;
        int y2;
        private int vida { set; get; }
        private int pergamino { set; get; }
        private Actor antorcha;

        protected int movimiento = 0;
       
       
        private ToolStripProgressBar toolStrip;//corresponde a la vida
        private ToolStripProgressBar toolStrip1;//corresponde a los pergaminos
        //constructor
        public Protagonista(int _vida, int _pergamino, int _velocidad, int daño, List<SoundPlayer> sonido, List<Image> listaImagenes, PictureBox pictureBox, ToolStripProgressBar toolStrip, ToolStripProgressBar toolStrip1,Actor Antorcha,ProgressBar nivelDeDesgate) : base(_velocidad, daño, sonido,listaImagenes,pictureBox, nivelDeDesgate)
        {
            this.vida = _vida;
            this.pergamino = _pergamino;
            this.toolStrip = toolStrip;
            this.toolStrip1 = toolStrip1;
            
            this.antorcha = Antorcha;

            toolStrip1.Minimum = 0;
            toolStrip1.Maximum = 10;

            toolStrip.Minimum = 0;
            toolStrip.Maximum = 10;

            x2 = base.GetPictureBox().Location.X;
            y2 = base.GetPictureBox().Location.Y;




        }

        



        public void setLinterna(int linterna)
        {
            this.antorcha.getNivelDeDesgaste().Value = linterna;
        }
        public int getLinterna()
        {
            return (this.antorcha.getNivelDeDesgaste().Value);
        }
        public void setToolStripVida(int vida)
        {
            if (toolStrip.Value<0||vida==-1)
            {
                toolStrip.Value = 0;
            }
            else
            {
                toolStrip.Value = vida;
            }

        }
        public void setToolStripPergamino(int pergamino)
        {
            
            toolStrip1.Value = pergamino;
        }
        public ToolStripProgressBar getToolStripVida()
        {
            return (toolStrip);
        }
        public ToolStripProgressBar getToolStripPergamino()
        {
            return (toolStrip1);
        }
        //setter y getters
        public void setVida(int vida)
        {

            this.vida = vida;
        }
        public void setPergamino(int pergamino)
        {

            this.pergamino = pergamino;

        }
        public int  getVida()
        {

            return (this.vida);
        }
        public int getPergamino()
        {

            return (this.pergamino);
        }
        


        //metodos


   
        public void caminaCambia(PreviewKeyDownEventArgs e,List<Keys> teclas)
        {


            int x = base.GetPictureBox().Location.X;
            int y = base.GetPictureBox().Location.Y;
            

            if (e.KeyCode == teclas[0])  {
                y  -= this.getVelocidad();
                base.GetPictureBox().Image = base.getImagenes()[11];
                base.GetPictureBox().SizeMode = PictureBoxSizeMode.StretchImage;
                

            }
            if (e.KeyCode == teclas[1]) {
                y += this.getVelocidad();
                base.GetPictureBox().Image = base.getImagenes()[12];
                base.GetPictureBox().SizeMode = PictureBoxSizeMode.StretchImage;
                

            }
            if (e.KeyCode == teclas[2]) {
                x += this.getVelocidad();
                
                if (movimiento>9||movimiento<4)
                {
                    movimiento = 4; 
                }
                movimiento++;
                base.GetPictureBox().Image = base.getImagenes()[movimiento-1];            
            }
            if (e.KeyCode == teclas[3]) { 
                x -= this.getVelocidad();
                if(movimiento>20||movimiento<17)
                {
                    movimiento = 17;
                }
                movimiento++;
                base.GetPictureBox().Image = base.getImagenes()[movimiento-1];
                

            }
            if (e.KeyCode == teclas[4])
            {
                base.GetPictureBox().Image = base.getImagenes()[21];
                if (this.antorcha.getNivelDeDesgaste().Value==1)
                {

                    base.GetPictureBox().Image=base.getImagenes()[21];
                   
                    this.antorcha.getNivelDeDesgaste().Value = 0;
                }
            }


            Point point = new Point(x, y);
            base.GetPictureBox().Location = point;
            


        }

        public void quieto()
        {
           
            if(movimiento>3)
            {
                movimiento = 0;

            }
            movimiento++;

            base.GetPictureBox().Image = base.getImagenes()[movimiento-1];
            base.GetPictureBox().SizeMode = PictureBoxSizeMode.StretchImage;//ajustar la relacion de aspecto del picturebox con la imagen

        }

        public void recogeAntorchas()
        {
            antorcha.getNivelDeDesgaste().Value = 1;
            antorcha.GetPictureBox().Location=new Point(10000,0);
            
            
        }

       

        public void izquierda()
        {
            x2 += this.getVelocidad();

            if (movimiento > 9 || movimiento < 4)
            {
                movimiento = 4;
            }
            movimiento++;
            base.GetPictureBox().Image = base.getImagenes()[movimiento - 1];
            Point point = new Point(x2, y2);
            base.GetPictureBox().Location = point;

        }
        public void derecha()
        {
            x2 -= this.getVelocidad();
            if (movimiento > 20 || movimiento < 17)
            {
                movimiento = 17;
            }
            movimiento++;
            base.GetPictureBox().Image = base.getImagenes()[movimiento - 1];
            Point point = new Point(x2, y2);
            base.GetPictureBox().Location = point;



        }

        public void arriba()
        {
            y2 -= this.getVelocidad();
            base.GetPictureBox().Image = base.getImagenes()[11];
            base.GetPictureBox().SizeMode = PictureBoxSizeMode.StretchImage;
            Point point = new Point(x2, y2);
            base.GetPictureBox().Location = point;

        }
        public void abajo()
        {
            y2 += this.getVelocidad();
            base.GetPictureBox().Image = base.getImagenes()[12];
            base.GetPictureBox().SizeMode = PictureBoxSizeMode.StretchImage;
            Point point = new Point(x2, y2);
            base.GetPictureBox().Location = point;

        }




    }


}

