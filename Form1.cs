using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer; // Importa la biblioteca PdfiumViewer para trabajar con archivos PDF.
using WinRT.Controls; // Importa la biblioteca WinRT.Controls para utilizar controles WinRT.
using AxWMPLib; // Importa la biblioteca AxWMPLib para trabajar con el reproductor de medios Windows Media Player.

namespace ARCHIVO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; // Suscribe el evento Load del formulario para realizar acciones cuando el formulario se carga.
        }

        private void btnAbrirPDF_Click(object sender, EventArgs e)
        {
            // Abre un cuadro de diálogo para seleccionar un archivo PDF.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdfFilePath = openFileDialog.FileName;
                // Llama a la función MostrarPDF para cargar y mostrar el archivo PDF seleccionado.
                MostrarPDF(pdfFilePath); 
            }
        }

        private void MostrarPDF(string filePath)
        {
            try
            {
                // Carga un archivo PDF desde la ubicación especificada.
                PdfDocument pdfDocument = PdfDocument.Load(filePath);
                // Asigna el documento PDF al control PdfViewer para su visualización.
                pdfViewer1.Document = pdfDocument; 
            }
            catch (Exception ex)
            {
                // En caso de error al abrir el archivo PDF, muestra un mensaje de error.
                MessageBox.Show("Error al abrir el archivo PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cargar y reproducir un archivo multimedia
            string rutaDelArchivoMultimedia = @"C:\Users\Asus\Downloads\musica\Bob Marley - Is This Love (320 kbps).mp3";
            axWindowsMediaPlayer1.URL = rutaDelArchivoMultimedia;


            // Cargar una página web en el WebBrowser
            webBrowser1.Navigate("https://www.google.com");


        }
    }
}
