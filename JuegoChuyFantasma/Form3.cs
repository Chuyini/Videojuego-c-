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
    public partial class Form3 : Form
    {
        SoundPlayer player1;
        public Form3()
        {
            InitializeComponent();
            
            string rutaRelativa = Path.Combine(Application.StartupPath, "Sonidos/Perdida.wav");
            player1 = new SoundPlayer(rutaRelativa);
            
            player1.Play();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player1.Stop();
            player1.Dispose();
            Form1 form = new Form1();
            
            form.Show();
            this.Dispose();
            this.Close();

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
