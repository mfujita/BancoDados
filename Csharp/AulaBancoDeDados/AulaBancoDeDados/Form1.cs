using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AulaBancoDeDados
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if (txtNome.Text != "" && txtEndereco.Text != "" && txtCidade.Text != "" && txtBairro.Text != "" &&
            //    (rbFumanteNao.Checked || rbFumanteSim.Checked))
            //{
            //    btnEnviar.Enabled = true;
            //}
            txtNome.Text = "Zé das Couves";
            txtEndereco.Text = "Rua das Couves, 123";
            txtBairro.Text = "Pântano Profundo";
            txtCidade.Text = "Americana";
            mtbDataNascimento.Text = "31/10/1967";
            mtbTelefone.Text = "19987654321";
            cbSexo.Text = "Masculino";
            rbFumanteSim.Checked = true;
            cbItensCelular.Checked = true;
            cbItensInternet.Checked = true;
            cbItensGeladeira.Checked = true;

            txtBuscarNome.Text = "Ze";

            this.WindowState = FormWindowState.Maximized;
            
            dgv.Width = tab.Width * 94 / 100;
            dgv.Location = new Point(10, mtbBuscarTelefone.Bottom + 20);

            dgv.Columns[0].Width = 50;
            dgv.Columns[1].Width = 300;
            dgv.Columns[2].Width = 300;
            dgv.Columns[3].Width = 300;
            dgv.Columns[4].Width = 300;
            dgv.Columns[5].Width = 300;
            dgv.Columns[6].Width = 70;
            dgv.Columns[7].Width = 300;
            dgv.Columns[8].Width = 300;
            dgv.Columns[9].Width = 300;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string end = txtEndereco.Text;
            string bairro = txtBairro.Text;
            string cidade = txtCidade.Text;
            string telefone = mtbTelefone.Text;
            char sexo = ' ';
            if (cbSexo.Text == "Masculino")
                sexo = 'M';
            else if (cbSexo.Text == "Feminino")
                sexo = 'F';
            string getNascimento = mtbDataNascimento.Text;
            string[] campos = getNascimento.Split('/');
            string dia = campos[0];
            string mes = campos[1];
            string ano = campos[2];
            string nascimento = ano + "-" + mes + "-" + dia;
            bool fumante = rbFumanteSim.Checked ? true : false;
            List<string> posses = new List<string>();
            if (cbItensVeiculo.Checked) { posses.Add(cbItensVeiculo.Text); }
            if (cbItensGeladeira.Checked) { posses.Add(cbItensGeladeira.Text); }
            if (cbItensInternet.Checked) { posses.Add(cbItensInternet.Text); }
            if (cbItensTvAssinatura.Checked) { posses.Add(cbItensTvAssinatura.Text); }
            if (cbItensServicoStreaming.Checked) { posses.Add(cbItensServicoStreaming.Text); }
            if (cbItensComputadorDesktop.Checked) { posses.Add(cbItensComputadorDesktop.Text); }
            if (cbItensNotebook.Checked) { posses.Add(cbItensNotebook.Text); }
            if (cbItensCelular.Checked) { posses.Add(cbItensCelular.Text); }
            if (cbItensTablet.Checked) { posses.Add(cbItensTablet.Text); }
            Pessoa p = new Pessoa(nome, end, bairro, cidade, telefone, sexo, nascimento, fumante, posses);
            BancoDados bd = new BancoDados();
            if (bd.Armazenar(p))
                MessageBox.Show("Cadastro realizado com sucesso!");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nome = txtBuscarNome.Text;
            string endereco = txtBuscarEndereco.Text;
            string bairro = txtBuscarBairro.Text;
            string cidade = txtBuscarCidade.Text;
            string telefone = mtbBuscarTelefone.Text;
            char sexo = cbBuscarSexo.Text == "Masculino" ? 'M' : 'F';
            string dataNascimento = mtbBuscarNascimento.Text;
            bool fumante = rbBuscarFumanteSim.Checked ? true : false;

            BancoDados bd = new BancoDados();
            DataTable dt = bd.Buscar(nome);

            dgv.Controls.Clear();

            //int qtdeColunas = dt.Columns.Count;
            //int qtdeLinhas = dt.Rows.Count;
            dgv.ColumnCount = dt.Columns.Count; //qtdeColunas;
            dgv.RowCount = dt.Rows.Count; //qtdeLinhas;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Aqua;

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Endereço", typeof(string));
            dt.Columns.Add("Bairro", typeof(string));
            dt.Columns.Add("Cidade", typeof(string));
            dt.Columns.Add("Telefone", typeof(string));
            dt.Columns.Add("Sexo", typeof(char));
            dt.Columns.Add("Nascimento", typeof(DateTime));
            dt.Columns.Add("Fumante", typeof(bool));
            dt.Columns.Add("Propriedades", typeof(string));

            dt.Rows.Add(2, "Tião", "Rua 1", "Jd. Fogo", "Pira", "19 94321 1234", "M", new DateTime(2000,1,1), 1, "Celular");
        }
    }
}
