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
    internal class Actor:Personaje
    {
        //atributos con setters y getters simplicados y aplicados
        private List<Image> listaImagenes { set; get; }
        private int velocidad { set; get; }
        public List<SoundPlayer> player { set; get; }
        private int dañoPoder { set; get; }
        private PictureBox pictureBox;
        private ProgressBar nivelDeDesgaste;
        //constructor
        public Actor(int _velocidad, int _dañoP, List<SoundPlayer> sonido, List<Image> listaImagenes_, PictureBox pictureBox, ProgressBar nivelDeDesgaste)
        {
            velocidad = _velocidad;
            dañoPoder = _dañoP;
            player = sonido;

            listaImagenes = listaImagenes_;
            this.pictureBox = pictureBox;
            this.nivelDeDesgaste = nivelDeDesgaste;
        }
        //setter y getters
        public void setNivelDeDesgaste(ProgressBar nivelDesgaste)
        {
            this.nivelDeDesgaste = nivelDesgaste;
        }
        public ProgressBar getNivelDeDesgaste()
        {
            return (this.nivelDeDesgaste);
        }
        public void setPictureBox(PictureBox pc)
        {
            this.pictureBox = pc;   
        }
        public PictureBox GetPictureBox()
        {
            return(this.pictureBox);

        }


        public void setVelocidad(int velocidad)
        {
            this.velocidad = velocidad;
        }
        public void setDañoPoder(int daño)
        {
            this.dañoPoder = daño;
        }
        public void setListaImagenes(List<Image> imagenes)
        {
            this.listaImagenes = imagenes;
        }
        public int getVelocidad()
        {
            return(this.velocidad);
        }
        public int getDañoPoder()
        {
            return (this.dañoPoder);
        }

        public List<Image> getImagenes()
        {
            return (this.listaImagenes);
        }

        //metodos

        public override void Desaparece()
        {


            this.pictureBox.Location = new System.Drawing.Point(2000, 2000);
        }
        public override void Aparece(Point p)
        {
            pictureBox.Image = this.getImagenes()[0];
            pictureBox.SizeMode= PictureBoxSizeMode.StretchImage;
            pictureBox.Location = p;
           pictureBox.Show();


        }
        public override void Grita()
        {
            System.Threading.Thread.Sleep(100);
            this.player[0].Play();
            System.Threading.Thread.Sleep(100);
        }

    }
}
