using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
namespace JuegoChuyFantasma
{
    public partial class Form6 : Form
    {
        List<int> digitos = new List<int>();
        public Form6()
        {
            InitializeComponent();
            leerArchivo();
           
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        void leerArchivo()
        {
            string filePath = "puntaje.txt";

            // Leer el contenido del archivo
            string contenido = File.ReadAllText(filePath);

            // Dividir el contenido por espacios para obtener cada número como una cadena
            string[] numerosString = contenido.Split(' ');

            // Crear un arreglo de enteros para almacenar los números
            int[] numeros = new int[numerosString.Length];

            // Convertir cada cadena de número a su valor entero correspondiente
            for (int i = 0; i < numerosString.Length; i++)
            {
                if (int.TryParse(numerosString[i], out int numero))
                {
                    if(numero!=0)//esta condicion hace que no haya 0 en el label
                    {
                        numeros[i] = numero;
                    }
                    
                }
                
                
            }
            Array.Reverse(numeros);
            // Mostrar los números en el Label separados por comas
            label1.Text = string.Join(Environment.NewLine, numeros);

            Array.Sort(numeros);//de mayor a menor
            Array.Reverse(numeros);//voltearlo
            label4.Text= string.Join(Environment.NewLine, numeros);



        }


       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Menu = new Form1();
            Menu.Show();
            this.Hide();
            this.Dispose();


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
