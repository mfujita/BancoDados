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
            
            dgv.Size = new Size(tab.Width * 94 / 100, this.Height*70/100);
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

//https://stackoverflow.com/questions/1027360/datagridview-capturing-user-row-selection
            dgv.CellClick += Dgv_CellClick;

            //MessageBox.Show(tcAtualizar.);

            foreach (Control control in tab.TabPages[2].Controls)
            {
                MessageBox.Show(control.Text);
            }
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = Convert.ToInt32((dgv.SelectedCells[e.RowIndex].Value));
            BancoDados bd = new BancoDados();
            DataTable dt = bd.Atualizar(indice);
            
            txtAtualizarNome.Text = dt.Rows[0][1].ToString();
            txtAtualizarEndereco.Text= dt.Rows[0][2].ToString();
            txtAtualizarBairro.Text = dt.Rows[0][3].ToString();
            txtAtualizarCidade.Text = dt.Rows[0][4].ToString();
            mtbAtualizarTelefone.Text = dt.Rows[0][5].ToString();
            cbAtualizarSexo.Text = dt.Rows[0][6].ToString();
            mtbAtualizarDataNascimento.Text = dt.Rows[0][7].ToString();
            if (Convert.ToBoolean(dt.Rows[0][8]))
                rbAtualizarFumanteSim.Checked = true;
            else
                rbAtualizarFumanteNao.Checked = true;

            string posses = dt.Rows[0][9].ToString();
            string[] cam = posses.Split('|');
            //for (int i = 0; i < cam.Length; i++)
            //{
            foreach (Control control in tab.TabPages[2].Controls)
            {
                //if ()
            }
            //}
            //if (cam[0] == cbAtualizarVeiculos.Text) { cbAtualizarVeiculos.Checked = true; }
            //if (cam[1] == cbAtualizarGeladeira.Text) { cbAtualizarVeiculos.Checked = true; }
            //if (cam[2] == cbAtualizarInternet.Text) { cbAtualizarInternet.Checked = true; }
            //if (cam[3] == cbAtualizarTVassinatura.Text) { cbAtualizarTVassinatura.Checked = true; }
            //if (cam[4] == cbAtualizarServicoStreaming.Text) { cbAtualizarServicoStreaming.Checked = true; }
            //if (cam[5] == cbAtualizarComputadorDesktop.Text) { cbAtualizarComputadorDesktop.Checked = true; }
            //if (cam[6] == cbAtualizarNotebook.Text) { cbAtualizarNotebook.Checked = true; }
            //if (cam[7] == cbAtualizarCelular.Text) { cbAtualizarCelular.Checked = true; }
            //if (cam[8] == cbAtualizarTablet.Text) { cbAtualizarTablet.Checked = true; }
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

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Aqua;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            dgv.DataSource = dt;
        }
    }
}
