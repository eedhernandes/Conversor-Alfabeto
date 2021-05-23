using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversorAlfabeto
{
    public partial class Form1 : Form
    {
        string regexLetra = "^[a-z]";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtTexto.Clear();
            txtResultado.Clear();

            txtTexto.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtTexto.Clear();
            txtResultado.Clear();

            txtTexto.Focus();
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            if (txtTexto.Text.Trim().Length == 0)
            {
                DialogResult mensagem;
                mensagem = MessageBox.Show("Preencha o campo em destaque e tente novamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (mensagem == DialogResult.OK)
                {
                    txtTexto.Focus();
                    return;
                }
            }
            else
            {
                string txt = txtTexto.Text;
                string textoLetras = "";
                string textoConvertido = "";

                var textoSemFormatacao = txt.Split(' ');

                for (int i = 0; i < textoSemFormatacao.Length; i++)
                {
                    if (textoLetras != "")
                    {
                        if (Regex.IsMatch(textoSemFormatacao[i], regexLetra))
                        {
                            textoLetras = textoLetras + " " + new String(textoSemFormatacao[i].Where(c => Char.IsLetter(c)).ToArray());
                        }
                    }
                    else
                    {
                        if (Regex.IsMatch(textoSemFormatacao[i], regexLetra))
                        {
                            textoLetras = new String(textoSemFormatacao[i].Where(c => Char.IsLetter(c)).ToArray());
                        }
                    }
                }

                textoConvertido = textoLetras;

                textoConvertido = textoConvertido.Replace("c", "3");
                textoConvertido = textoConvertido.Replace("f", "6");
                textoConvertido = textoConvertido.Replace("i", "9");
                textoConvertido = textoConvertido.Replace("l", "12");
                textoConvertido = textoConvertido.Replace("o", "15");
                textoConvertido = textoConvertido.Replace("r", "18");
                textoConvertido = textoConvertido.Replace("u", "21");
                textoConvertido = textoConvertido.Replace("x", "24");

                txtResultado.Text = textoConvertido;

                txtTexto.Focus();
            }
        }
    }
}