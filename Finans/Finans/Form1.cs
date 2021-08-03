using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finans
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
                ModelTransacao modelo = new ModelTransacao();
                modelo.DataTrans = dateTimePicker1.Value;
                modelo.DescTrans = textBox2.Text;
                modelo.NotaTrans = textBox4.Text;
                modelo.ValorTrans = Convert.ToDouble(textBox3.Text);

                DALConexao cx = new DALConexao();
                BLLTransacao bll = new BLLTransacao(cx);

                bll.Incluir(modelo);
                MessageBox.Show("Registro incluido");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}