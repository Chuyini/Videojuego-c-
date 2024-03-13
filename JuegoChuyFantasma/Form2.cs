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


    public partial class Form2 : Form
    {
        Protagonista jugador,jugador2;
        Enemigo enemigo, enemigo2,enemigo3;
        Actor pergamino,linterna;
        List<Keys> keysPressed = new List<Keys>();
        bool aparecer, aparecePergamino, aparecerLinterna, autorizacion, derecha,izquierda,arriba,abajo,autorizacion2 = false;
        int ok=0;//decir si el personaje tiene la linterna =1 o si no= 0
        int nivel = 1;
        List<PictureBox> obstaculos;
        int cantidadObs = 5;
        int puntaje = 0;
       
        PreviewKeyDownEventArgs presiona;





        public Form2()
        {

           
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            inicializaPictureBox();
            inicializaLinterna();
            InicializarProta();
            inicializaAlEnemigo();
            inicializaPergaminos();
            inicializaObstaculos();
           
            
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();
            timer6.Start();
            timer7.Start();
            timer8.Start();
            timer9.Start();

            



           

        }
        
        void inicializaLinterna()
        {
            List<Image> listaImagenes = new List<Image>();
            listaImagenes.Add(Image.FromFile("Imagenes/fuego.png"));
            linterna = new Actor(0, 0, null, listaImagenes, pictureBox5, progressBar1);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 1;
        }

        void inicializaPictureBox()
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;
            pictureBox7.BackColor = Color.Transparent;
            label2.Location = new Point(0, 5000);
            pictureBox5.BackColor = Color.Transparent;
            pictureBox1.BringToFront();//personaje

            pictureBox7.Parent = this;
            pictureBox1.Parent = this;
            pictureBox2.Parent = this;
            pictureBox3.Parent = this;
            pictureBox4.Location = new Point(5000, 0);
            pictureBox6.Location = new Point(-5000, 0);
            derecha = false;
            izquierda = false;
            arriba = false; 
            abajo = false;  

            

        }
        private void inicializaObstaculos()
        {
            Random random = new Random();
            obstaculos = new List<PictureBox>();

            for (int i = 0; i < cantidadObs; i++)
            {
                PictureBox obstaculo = new PictureBox();
                obstaculo.Image = Image.FromFile("Imagenes/tumba.png");
                obstaculo.SizeMode= PictureBoxSizeMode.StretchImage;
                obstaculo.Size = new Size(50, 50); // Ajusta el tamaño según tus necesidades
                obstaculo.Location = new Point(random.Next(0, Width), random.Next(0, Height));
                obstaculo.Show();

                obstaculos.Add(obstaculo);
                Controls.Add(obstaculo); // Agrega el obstáculo al formulario
            }
        }
        void chocaObstaculos()
        {
            foreach (PictureBox obstaculo in obstaculos)
            {
                if (jugador.GetPictureBox().Bounds.IntersectsWith(obstaculo.Bounds))
                {
                    // Se detectó una colisión entre el jugador y el obstáculo
                    // Ajusta la posición del jugador para evitar la colisión

                    int distanciaX = 50;
                    int distanciaY = 50;

                    // Ajustar posición horizontal
                    if (distanciaX > 0)
                    {
                        // Mover hacia la izquierda
                        jugador.GetPictureBox().Left -= distanciaX;
                    }
                    else
                    {
                        // Mover hacia la derecha
                        jugador.GetPictureBox().Left += (distanciaX);
                    }

                    // Ajustar posición vertical
                    if (distanciaY > 0)
                    {
                        // Mover hacia arriba
                        jugador.GetPictureBox().Top -= distanciaY;
                    }
                    else
                    {
                        // Mover hacia abajo
                        jugador.GetPictureBox().Top += (distanciaY);
                    }
                }
            }
        }
        void InicializarProta()
        {
            string rutaRelativa ;
            List<Image> listaImagenes = new List<Image>();
            List<SoundPlayer> sonidos = new List<SoundPlayer>();

            rutaRelativa = Path.Combine(Application.StartupPath, "Sonidos/Golpe.wav");
            sonidos.Add(new SoundPlayer(rutaRelativa));
            rutaRelativa = Path.Combine(Application.StartupPath, "Sonidos/lamento.wav");
            sonidos.Add(new SoundPlayer(rutaRelativa));
            rutaRelativa = Path.Combine(Application.StartupPath, "Sonidos/caminando.wav");
            sonidos.Add(new SoundPlayer(rutaRelativa));
            listaImagenes.Add(Image.FromFile("Imagenes/1Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/2Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/3Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/4Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/5Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/6Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/7Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/8Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/9Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/10Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/11Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/12Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/13Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/14Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/15Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/16Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/17Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/18Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/19Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/20Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/21Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/22Pa.png"));
            listaImagenes.Add(Image.FromFile("Imagenes/23Pa.png"));
            pictureBox3.Location = new Point(Width/2, Height/2);
            jugador2 = new Protagonista(10, 1, 20, 3, sonidos, listaImagenes, pictureBox7, new ToolStripProgressBar(),new ToolStripProgressBar(),new Actor(0,0,null,null,null,null),new ProgressBar());
            jugador = new Protagonista(10,1,10,3,sonidos,listaImagenes, pictureBox1, toolStripProgressBar2, toolStripProgressBar1,linterna,null);
            jugador.setLinterna(0);
            //10, 1, 10, 3,sonidos, listaImagenes, pictureBox1, toolStripProgressBar2,toolStripProgressBar1,pictureBox4,progressBar1,linterna,null

            jugador.setToolStripVida(10);
            jugador2.quieto();

        }
        void inicializaPergaminos()
        {
            string rutaRelativa;
            List<SoundPlayer> sonidos = new List<SoundPlayer>();
            rutaRelativa = Path.Combine(Application.StartupPath, "Sonidos/moneda.wav");
            sonidos.Add(new SoundPlayer(rutaRelativa));

            List<Image> listaImagenes = new List<Image>();
            listaImagenes.Add(Image.FromFile("Imagenes/pergamino.png"));
            pictureBox3.Image = listaImagenes[0];
            pictureBox3.Location = new Point((Width / 2) , (Height/2)-200);
            
            pergamino = new Actor(0, 0, sonidos, listaImagenes, pictureBox3,null);

        }


        void inicializaAlEnemigo()
        {
            string rutaRelativa;
            List<SoundPlayer> sonidos = new List<SoundPlayer>();
            rutaRelativa = Path.Combine(Application.StartupPath, "Sonidos/FantasmaGrito.wav");
            sonidos.Add(new SoundPlayer(rutaRelativa));
            rutaRelativa = Path.Combine(Application.StartupPath, "Sonidos/FantasmaPresencia.wav");
            sonidos.Add(new SoundPlayer(rutaRelativa));
            


            List<Image> listaImagenes = new List<Image>();
            listaImagenes.Add(Image.FromFile("Gifts/fantasmaPose.gif"));
            pictureBox2.Location = new Point(0, 1000);
            enemigo = new Enemigo(10, 2,sonidos, listaImagenes, pictureBox2,null);
            //segundo enemigo
            pictureBox4.Location = new Point(0, 1000);
            enemigo2 = new Enemigo(10, 2, sonidos, listaImagenes, pictureBox4, null);
            //tercer enemigo
            pictureBox6.Location = new Point(0, 1000);
            enemigo3 = new Enemigo(10, 2, sonidos, listaImagenes, pictureBox6, null);
        }   
       




        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //TIMER DEL JUGADOR
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            jugador.quieto();
            

        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            





        }

        
        //CADA CIERTO TIEMPO ATACA
        private void timer2_Tick(object sender, EventArgs e)
        {
            

            if (aparecer == true)
            {
                
                enemigo.ataca(jugador.GetPictureBox());
               

            }
            if (aparecer == true&&autorizacion==true)
            {

                enemigo2.ataca(jugador.GetPictureBox());

            }
            if (aparecer == true && autorizacion2 == true)
            {

                enemigo3.ataca(jugador.GetPictureBox());

            }





        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar2_Click(object sender, EventArgs e)
        {

        }
        //revisa cada cierto tiempo que el fantasma y el personaje chocan y el pergamino
        private void timer3_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int x = enemigo.GetPictureBox().Location.X - jugador.GetPictureBox().Location.X;
            int y = enemigo.GetPictureBox().Location.Y - jugador.GetPictureBox().Location.Y;
            int x2 = enemigo2.GetPictureBox().Location.X - jugador.GetPictureBox().Location.X;
            int y2 = enemigo2.GetPictureBox().Location.Y - jugador.GetPictureBox().Location.Y;
            int x3 = enemigo3.GetPictureBox().Location.X - jugador.GetPictureBox().Location.X;
            int y3 = enemigo3.GetPictureBox().Location.Y - jugador.GetPictureBox().Location.Y;
            int xi = pergamino.GetPictureBox().Location.X - jugador.GetPictureBox().Location.X;
            int yi = pergamino.GetPictureBox().Location.Y - jugador.GetPictureBox().Location.Y;
            int xi2 = linterna.GetPictureBox().Location.X - jugador.GetPictureBox().Location.X;
            int yi2 = linterna.GetPictureBox().Location.Y - jugador.GetPictureBox().Location.Y;
            int xJugador2 = pergamino.GetPictureBox().Location.X - jugador2.GetPictureBox().Location.X;
            int yJugador2 = pergamino.GetPictureBox().Location.Y - jugador2.GetPictureBox().Location.Y;
            if (yJugador2 < 0) { yJugador2 = yJugador2 * -1; }
            if (xJugador2 < 0) { xJugador2 = xJugador2 * -1; }
            if (y < 0) { y = y * -1; }
            if (x < 0) { x = x * -1; }
            if (y2 < 0) { y2 = y2 * -1; }
            if (x2 < 0) { x2 = x2 * -1; }
            if (y3 < 0) { y3 = y3 * -1; }
            if (x3 < 0) { x3 = x3 * -1; }
            if (yi < 0) { yi = yi * -1; }
            if (xi < 0) { xi = xi * -1; }
            if (yi2 < 0) { yi2 = yi2 * -1; }
            if (xi2 < 0) { xi2 = xi2 * -1; }
            if (x<50&&y<50)
            {
                jugador.setToolStripVida(jugador.getVida() - 1);
                jugador.setVida(jugador.getVida() - 1);
                jugador.GetPictureBox().Image = jugador.getImagenes()[14];
                jugador.Grita();
                enemigo.setMovimiento(jugador.GetPictureBox().Location.X - 100);//aqui se le da el valor para que aparezca enfrente
                enemigo.setMovimientoY(jugador.GetPictureBox().Location.Y);// y este para que aparez tambien
            }
            
            if (x2 < 50 && y2 < 50)
            {
                jugador.setToolStripVida(jugador.getVida() - 1);
                jugador.setVida(jugador.getVida() - 1);
                jugador.GetPictureBox().Image = jugador.getImagenes()[14];
                jugador.Grita();
                enemigo2.setMovimiento(jugador.GetPictureBox().Location.X - 100);//aqui se le da el valor para que aparezca enfrente
                enemigo2.setMovimientoY(jugador.GetPictureBox().Location.Y);// y este para que aparez tambien
            }
            if (x3 < 50 && y3 < 50)
            {
                jugador.setToolStripVida(jugador.getVida() - 1);
                jugador.setVida(jugador.getVida() - 1);
                jugador.GetPictureBox().Image = jugador.getImagenes()[14];
                jugador.Grita();
                enemigo3.setMovimiento(jugador.GetPictureBox().Location.X - 100);//aqui se le da el valor para que aparezca enfrente
                enemigo3.setMovimientoY(jugador.GetPictureBox().Location.Y);// y este para que aparez tambien
            }
            if (xi < 100 && yi  < 100|| (xJugador2 < 50 && yJugador2 < 50))
            {
                jugador.setToolStripPergamino(jugador.getPergamino() + 1);
                jugador.setPergamino(jugador.getPergamino() +1);
                pergamino.Grita();
                enemigo.setVelocidad(enemigo.getVelocidad() + 1);
                aparecePergamino = false;
                pergamino.Aparece(new Point(10000, 0));
            }
            if (xi2 < 100 && yi2 < 100)
            {
                jugador.recogeAntorchas();
                
                ok =jugador.getLinterna();

            }
          
            if (jugador.getToolStripVida().Value==0)
            {
                jugador.player[1].PlaySync();
                Form3 perdistePantalla=new Form3();
                AgregarAlarchivo();
                perdistePantalla.Show();
                this.Dispose();
                this.Close();
            }
            if(jugador.getPergamino()>9)
            {
                
                jugador.getToolStripPergamino().Value = 0;
                siguienteNivel();
            }
            

        }

        //define cada cuanto aparecera el fantasma
        private void timer4_Tick(object sender, EventArgs e)
        {
            

            aparecer = true;
            
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        //esta funcion hace que aparezca el pergamino en un tiempo determinado en zonas aleatorias

        private void timer5_Tick(object sender, EventArgs e)
        {
            
            if (aparecePergamino==true)
            {
                Random random = new Random();

                pergamino.Aparece(new Point(random.Next(0,Width), random.Next(0,Height-20)));
            }

            
            
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }
        //dira que cada tanto aparecera un libro
        private void timer6_Tick(object sender, EventArgs e)
        {
            if (jugador.getLinterna() == 0 &&aparecerLinterna==true)
            {

                Random random = new Random();

                linterna.Aparece(new Point(random.Next(100, Width), random.Next(100, Height)));



            }

        }
        //para la musica
        private void timer7_Tick(object sender, EventArgs e)
        {
           aparecerLinterna = true; 
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {



        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Form1 menu=new Form1();
            menu.Show();
            this.Dispose();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            Form4 tutorial=new Form4();
            tutorial.Show();this.Dispose();
        }

        private void PictureBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            


        }

        private void Form2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            List<Keys> teclasJugador1;
            teclasJugador1 = new List<Keys>();
            presiona = e;
            

            teclasJugador1.Add(Keys.W);
            teclasJugador1.Add(Keys.S);
            teclasJugador1.Add(Keys.D);
            teclasJugador1.Add(Keys.A);
            teclasJugador1.Add(Keys.L);



            timer1.Stop();
            jugador.caminaCambia(e, teclasJugador1);

            timer1.Start();

            int x1 = enemigo2.GetPictureBox().Location.X - jugador.GetPictureBox().Location.X;
            int y1 = enemigo2.GetPictureBox().Location.Y - jugador.GetPictureBox().Location.Y;
            if (y1 < 0) { y1 = y1 * -1; }
            if (x1 < 0) { x1 = x1 * -1; }
            int x2 = enemigo3.GetPictureBox().Location.X - jugador.GetPictureBox().Location.X;
            int y2 = enemigo3.GetPictureBox().Location.Y - jugador.GetPictureBox().Location.Y;
            if (y2 < 0) { y2 = y2 * -1; }
            if (x2 < 0) { x2 = x2 * -1; }
            int x3 = enemigo.GetPictureBox().Location.X - jugador.GetPictureBox().Location.X;
            int y3 = enemigo.GetPictureBox().Location.Y - jugador.GetPictureBox().Location.Y;
            if (y3 < 0) { y3 = y3 * -1; }
            if (x3 < 0) { x3 = x3 * -1; }


            if (x3 < 100 && y3 < 100 && e.KeyCode == teclasJugador1[4] && ok == 1)
            {
                Random randoim = new Random();
                enemigo.Grita();
                puntaje++;
                enemigo.setMovimiento(randoim.Next(-1000, 4000));
                enemigo.setMovimientoY(randoim.Next(-1000, 4000));
                ok = 0;

            }
            if (x2 < 100 && y2 < 100 && e.KeyCode== teclasJugador1[4] && ok == 1)
            {
                Random randoim = new Random();
                enemigo3.Grita();
                puntaje++;
                enemigo3.setMovimiento(randoim.Next(-1000, 4000));
                enemigo3.setMovimientoY(randoim.Next(-1000, 4000));
                ok = 0;

            }
            if (x1 < 100 && y1 < 100 && e.KeyCode == teclasJugador1[4] && ok == 1)
            {
                Random randoim = new Random();
                enemigo2.Grita();
                puntaje++;
                enemigo2.setMovimiento(randoim.Next(-1000, 4000));
                enemigo2.setMovimientoY(randoim.Next(-1000, 4000));
                ok = 0;

            }

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
           

        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            
            
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            aparecePergamino = true;
        }
        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            




        }
        void siguienteNivel()
        {
            switch (nivel)
            {
                case 1:
                    
                    label2.Show();
                    this.SetDesktopLocation(0, 0);
                    this.Width = Screen.PrimaryScreen.Bounds.Width;
                    this.Height = Screen.PrimaryScreen.Bounds.Height;
                    string rutaRelativa = Path.Combine(Application.StartupPath, "Sonidos/risaMala.wav");
                   SoundPlayer player2 = new SoundPlayer(rutaRelativa);
                    label2.Location = new Point(Width / 2, 0);
                    
                    cantidadObs = 20;
                    inicializaObstaculos();

                    jugador.setToolStripPergamino(0);
                    jugador.setPergamino(0);
                    jugador.getToolStripPergamino().Value = 0;
                    jugador.getToolStripVida().Value = 10;
                    jugador.setVelocidad(18);
                    jugador.setVida(10);
                    jugador.GetPictureBox().Location = new Point(Width / 2, Height / 2);
                    enemigo.setMovimiento(1000);
                    enemigo.setVelocidad(7);
                    enemigo2.setVelocidad(6);
                    player2.PlaySync();
                    
                    autorizacion = true;

                    nivel++;




                    break;
                case 2:
                    label2.Text = "NIVEL 3";
                    label2.Show();
                   ;
                    string rutaRelativa2 = Path.Combine(Application.StartupPath, "Sonidos/risaMala.wav");
                    SoundPlayer player22 = new SoundPlayer(rutaRelativa2);
                    label2.Location = new Point(Width / 2, 0);

                    cantidadObs = 20;
                    inicializaObstaculos();
                    jugador.setToolStripPergamino(0);
                    jugador.setPergamino(0);
                    jugador.getToolStripPergamino().Value = 0;
                    jugador.getToolStripVida().Value = 10;
                    jugador.setVelocidad(18);
                    jugador.setVida(10);
                    jugador.GetPictureBox().Location = new Point(Width / 2, Height / 2);
                    enemigo.setMovimiento(1000);
                    enemigo.setVelocidad(8);
                    enemigo2.setVelocidad(7);
                    enemigo3.setVelocidad(9);
                    player22.PlaySync();
                    label2.Show();
                    autorizacion2 = true;

                    nivel++;
                    break;
                case 3:
                    string rutaRelativa22 = Path.Combine(Application.StartupPath, "Sonidos/risaMala.wav");
                    SoundPlayer player222 = new SoundPlayer(rutaRelativa22);
                    player222.PlaySync();
                    Form5 ganastePantalla = new Form5();
                    AgregarAlarchivo();
                    ganastePantalla.Show();
                    this.Dispose();
                    this.Close();
                    break;
              

            }


        }

        void AgregarAlarchivo()
        {
            string filePath = "puntaje.txt";

            // Escribir números separados por espacios en el archivo


            string l = puntaje.ToString();
            // Agregar contenido al archivo

            File.AppendAllText(filePath, l+" ");
        }
        


        private void timer9_Tick(object sender, EventArgs e)
        {
            chocaObstaculos();
            
            if(presiona!=null)
            {
                switch(presiona.KeyCode)
                {
                    case Keys.Right:
                        derecha = true;
                        izquierda = false;
                        arriba = false;
                        abajo = false;  

                        break;
                    case Keys.Left:

                        derecha = false;
                        izquierda = true;
                        arriba = false;
                        abajo = false;
                        break;
                    case Keys.Down:
                        derecha = false;
                        izquierda = false;
                        arriba = false;
                        abajo = true;
                        break;
                    case Keys.Up:
                        derecha = false;
                        izquierda = false;
                        arriba = true;
                        abajo = false;
                        break;
                }
                
            }
            if(derecha)
            {
                jugador2.izquierda();
            }if(izquierda)
            {
                jugador2.derecha();
            }if(arriba)
            {
                jugador2.arriba();
            }
            if(abajo)
            {
                jugador2.abajo();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_2(object sender, EventArgs e)
        {

        }

        

    }
}
