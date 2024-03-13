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
    public partial class Form1 : Form
    {
        SoundPlayer player;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            string rutaRelativa = Path.Combine(Application.StartupPath, "CancionMenu.wav");
            player= new SoundPlayer(rutaRelativa);
            player.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.Stop();
            player.Dispose();
            Form2 juego=new Form2();
            
            this.Hide();
            
            juego.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 tutorial = new Form4();

            this.Hide();

            tutorial.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 puntaje = new Form6();
            this.Hide();
            puntaje.Show(); 
        
        }
    }
}
