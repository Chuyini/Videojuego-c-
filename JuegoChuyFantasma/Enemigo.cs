using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoChuyFantasma
{
    internal class Enemigo : Actor
    {
        private int  movimiento = 0;
        private int movimientoY = 0;

        public Enemigo(int _velocidad,int _dañoP,List<SoundPlayer> sonido,List<Image> listaImagenes,PictureBox pc,ProgressBar nivelDeDesgaste):base(_velocidad,_dañoP,sonido,listaImagenes,pc,nivelDeDesgaste)
         {
         }

        public void setMovimiento(int movimiento)
        {
            this.movimiento = movimiento;
        }
        public void setMovimientoY(int movimiento)
        {
            this.movimientoY = movimiento;
        }

        public void ataca(PictureBox cuerpoJugador)//acercarse al jugador
        {
            int x= movimiento;
            int y = movimientoY;
            
            Point point = new Point(x, y);
            base.GetPictureBox().Location = point;
            if(cuerpoJugador.Location.X-base.GetPictureBox().Location.X>0)
            {
                movimiento = movimiento + base.getVelocidad();
            }
            if (cuerpoJugador.Location.X - base.GetPictureBox().Location.X < 0)
            {
                movimiento = movimiento - base.getVelocidad();

            }
            if (cuerpoJugador.Location.Y - base.GetPictureBox().Location.Y < 0)
            {
                movimientoY = movimientoY - this.getVelocidad();
            }
            if (cuerpoJugador.Location.Y - base.GetPictureBox().Location.Y > 0)
            {
                movimientoY = movimientoY + this.getVelocidad();
            }
        } 

    }
}
