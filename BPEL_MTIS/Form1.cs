using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPEL_MTIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var referencia = textBox1.Text;
            var parseOk = int.TryParse(unidades.Text, out int unidadesResult);

            if (string.IsNullOrEmpty(referencia) || !parseOk)
            {
                MessageBox.Show("Hay campos vacíos");
            }
            else
            {
                var request = new ProcesoCompra.ProcesoCompraRequest
                {
                    referenciaProducto = referencia,
                    unidades = unidadesResult
                };
                var endpoint = new ProcesoCompra.ProcesoCompra
                {
                    Url = "http://localhost:8080/ode/processes/ProcesoCompra?wsdl"
                };

                var response = endpoint.process(request);

                if (response.result)
                {
                    MessageBox.Show("Compra realizada correctamente");
                }
                else
                {
                    MessageBox.Show("Error al realizar la compra");
                }
            }
        }
    }
}
