using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocDeNotas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Documentos de texto|*.txt|Todos los archivos|*.*";
            abrir.Title = "Abrir archivo";
            abrir.FileName = "Sin titulo.txt";

            var resultado = abrir.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamReader leer = new StreamReader(abrir.FileName);
                richTextBox1.Text = leer.ReadToEnd();
                leer.Close();
            }

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Documentos de texto|*.txt|Otros|*.*";
            save.Title = "Guardar archivo";
            save.FileName = "Sin titulo.txt";

            var result = save.ShowDialog();
            if (result == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(save.FileName);
                foreach(object line in richTextBox1.Lines)
                {
                    write.WriteLine(line);
                }
                write.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "Desea guardar antes de salir?";
            string titulo = "Bloc de notas";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.Filter = "Documentos de texto|*.txt|Otros|*.*";
                guardar.Title = "Guardar archivo";
                guardar.FileName = "Sin titulo.txt";

                var resultado = guardar.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    StreamWriter escribir = new StreamWriter(guardar.FileName);
                    foreach (object line in richTextBox1.Lines)
                    {
                        escribir.WriteLine(line);
                    }
                    escribir.Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Focus();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
