using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Microsoft.Win32;

namespace Image_to_ASCII_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var file_opening_dialog = new OpenFileDialog
                {
                    Filter = "Image files (*.*)|*.*",
                    Title = "Choose image for conversion to ASCII",
                    CheckFileExists = true
                };

                if (file_opening_dialog.ShowDialog() == DialogResult.OK) //после выбора файла с текстом для статистики
                {
                    var file_save_dialog = new SaveFileDialog
                    {
                        Filter = "Text file (*.txt)|*.txt",
                        Title = "Choose place where result will be saved"
                    };

                    if (file_save_dialog.ShowDialog() == DialogResult.OK)
                    {
                        ASCII_From_Image.Generate(file_opening_dialog.FileName, file_save_dialog.FileName);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
