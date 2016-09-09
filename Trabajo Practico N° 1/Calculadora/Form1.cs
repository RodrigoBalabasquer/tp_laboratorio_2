using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = " ";
            this.txtNumero1.Text = " ";
            this.txtNumero2.Text = " ";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double Resultado;
            Numero numero1 = new Numero(this.txtNumero1.Text);
            Numero numero2 = new Numero(this.txtNumero2.Text);
            Resultado = Calculadora.Operar(numero1, numero2, this.cmbOperacion.Text);
            this.lblResultado.Text = Resultado.ToString();
        }
    }
}
