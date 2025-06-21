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
            //txtNome.Text = "Zé das Couves";
            //txtEndereco.Text = "Rua das Couves, 123";
            //txtBairro.Text = "Pântano Profundo";
            //txtCidade.Text = "Americana";
            //mtbDataNascimento.Text = "31/10/1967";
            //mtbTelefone.Text = "19987654321";
            //cbSexo.Text = "Masculino";
            //rbFumanteSim.Checked = true;
            //cbItensCelular.Checked = true;
            //cbItensInternet.Checked = true;
            //cbItensGeladeira.Checked = true;

            txtBuscarNome.Text = "Ze";

            this.WindowState = FormWindowState.Maximized;
            
            dgv.Size = new Size(tab.Width * 94 / 100, this.Height*50/100);
            dgv.Location = new Point(10, mtbBuscarTelefone.Bottom + 20);

            //dgv.Columns[0].Width = 50;
            //dgv.Columns[1].Width = 300;
            //dgv.Columns[2].Width = 300;
            //dgv.Columns[3].Width = 300;
            //dgv.Columns[4].Width = 300;
            //dgv.Columns[5].Width = 300;
            //dgv.Columns[6].Width = 70;
            //dgv.Columns[7].Width = 300;
            //dgv.Columns[8].Width = 300;
            //dgv.Columns[9].Width = 300;
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
            string telefone = mtbBuscarTelefone.Text == "(  )" ? mtbBuscarTelefone.Text : "";
            string sexo = "";
            if (cbBuscarSexo.Text == "M")
                sexo = "M";
            else if (cbBuscarSexo.Text == "F")
                sexo = "F";
            else
                sexo = "";
            string dataNascimento = mtbBuscarNascimento.Text == "(  )" ? mtbBuscarTelefone.Text : "";
            bool fumante = rbBuscarFumanteSim.Checked ? true : false;

            BancoDados bd = new BancoDados();
            DataTable dt = bd.Buscar(nome,endereco, bairro,cidade, telefone, sexo, dataNascimento);

            dgv.Controls.Clear();

            //int qtdeColunas = dt.Columns.Count;
            //int qtdeLinhas = dt.Rows.Count;
            //dgv.ColumnCount = dt.Columns.Count; //qtdeColunas;
            //dgv.RowCount = dt.Rows.Count; //qtdeLinhas;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Aqua;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            //dgv.Columns[0].Name = "ID";
            //dgv.Columns[0].HeaderText = "ID";
            //dgv.Columns[0].DataPropertyName = "ID";

            //dgv.Columns[0].Name = "nome";
            //dgv.Columns[0].HeaderText = "Nome";
            //dgv.Columns[0].DataPropertyName = "nome";

            //dgv.Columns[0].Name = "endereco";
            //dgv.Columns[0].HeaderText = "endereco";
            //dgv.Columns[0].DataPropertyName = "endereco";

            //dgv.Columns[0].Name = "bairro";
            //dgv.Columns[0].HeaderText = "bairro";
            //dgv.Columns[0].DataPropertyName = "bairro";

            //dgv.Columns[0].Name = "cidade";
            //dgv.Columns[0].HeaderText = "cidade";
            //dgv.Columns[0].DataPropertyName = "cidade";

            //dgv.Columns[0].Name = "telefone";
            //dgv.Columns[0].HeaderText = "telefone";
            //dgv.Columns[0].DataPropertyName = "telefone";

            //dgv.Columns[0].Name = "sexo";
            //dgv.Columns[0].HeaderText = "sexo";
            //dgv.Columns[0].DataPropertyName = "sexo";

            //dgv.Columns[0].Name = "nascimento";
            //dgv.Columns[0].HeaderText = "nascimento";
            //dgv.Columns[0].DataPropertyName = "nascimento";

            //dgv.Columns[0].Name = "fumante";
            //dgv.Columns[0].HeaderText = "fumante";
            //dgv.Columns[0].DataPropertyName = "fumante";

            //dgv.Columns[0].Name = "propriedades";
            //dgv.Columns[0].HeaderText = "propriedades";
            //dgv.Columns[0].DataPropertyName = "propriedades";

            dgv.DataSource = dt;
        }
    }
}
