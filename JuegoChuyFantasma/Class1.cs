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
    internal abstract class Personaje
    {
        public abstract void Aparece(Point p);
        public abstract void Desaparece();
        public abstract void Grita();
}
}
