using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoChuyFantasma
{
    public partial class Form5 : Form
    {
        SoundPlayer player;
        public Form5()
        {
            InitializeComponent();
            string rutaRelativa = Path.Combine(Application.StartupPath, "Sonidos/Ganaste.wav");
            player = new SoundPlayer(rutaRelativa);
            player.Play();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            menu.Show();
            this.Hide();
            this.Dispose();

            

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
