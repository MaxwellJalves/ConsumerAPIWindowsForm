using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumerApiCorreiosDesktop
{
    //Declarando Variaveis
   
    public partial class FormApi : Form
    {
   
      

        public FormApi()
        {

            InitializeComponent();
           
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnConsultaWs_Click(object sender, EventArgs e)
        {
            //Validando Campo de Consulta
            if (!string.IsNullOrEmpty(txtConsultaCep.Text))
            {
                //Bloco
                using ( var ws = new WSCorrerios.AtendeClienteClient())
                {
                    try
                    {
                        var url = ws.consultaCEP(txtConsultaCep.Text.Trim());                                                   //Adicionado o Trim Para garantir que não vai ser gravado no bando de dados nenhum espaço vazio no inicio e no fim do código.

                        txtEndereco.Text = url.end;
                        txtBairro.Text   = url.bairro;
                        txtCidade.Text   = url.cidade;
                        txtUf.Text       = url.uf;
                        txtIbge.Text = url.cep;

                    } catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message,$" Ops :( ! -  Ocorreu uma falha na Resposta do WS, Tente novamente {erro}",
                            MessageBoxButtons.OK,MessageBoxIcon.Error);
                       
                    }

                }
            }
            else
            {
                MessageBox.Show($"Informe um CEP Valido", this.Text, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtEndereco.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtUf.Text = string.Empty;
            txtIbge.Text = string.Empty;
            txtConsultaCep.Text = string.Empty;
        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
