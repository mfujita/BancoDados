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
        int indice = 0;

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
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int indice = Convert.ToInt32((dgv.SelectedCells[e.RowIndex].Value));
            indice = Convert.ToInt32((dgv.SelectedCells[e.RowIndex].Value));
            BancoDados bd = new BancoDados();
            DataTable dt = bd.RecuperarDadosPeloIndice(indice);
            
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
            for (int i = 0; i < cam.Length; i++)
            {
                if (cam[i] != "")
                    SelecionaCheckboxChecked(cam[i]);
            }
        }

        private void SelecionaCheckboxChecked(string procura)
        {
            foreach (var abas in tab.TabPages[2].Controls)
            {
                if (abas is GroupBox gbExterno && gbExterno.Tag.ToString() == "oinf") // gbExterno.Text == "Outras informações")
                {
                    foreach (var gbInterno in gbExterno.Controls)
                    {
                        if (gbInterno is GroupBox cbox && cbox.Tag.ToString() == "prop") // cbox.Text == "Assinale os itens que possui:")
                        {
                            foreach (var item in cbox.Controls)
                            {
                                if (item is CheckBox cb && cb.Text == procura)
                                {
                                    cb.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id = indice;
            string nome = txtAtualizarNome.Text;
            string end = txtAtualizarEndereco.Text;
            string bairro = txtAtualizarBairro.Text;
            string cidade = txtAtualizarCidade.Text;
            string telefone = mtbAtualizarTelefone.Text;
            char sexo = ' ';
            if (cbAtualizarSexo.Text == "Masculino" || cbAtualizarSexo.Text == "M")
                sexo = 'M';
            else
                sexo = 'F';
            string nasc = mtbAtualizarDataNascimento.Text;
            string[] campos = nasc.Split('/');
            string dia = campos[0];
            string mes = campos[1];
            string ano = campos[2];
            string nascimento = ano + "-" + mes + "-" + dia;

            bool fumante = false;
            if (rbAtualizarFumanteSim.Checked)
                fumante = true;

            List<string> posses = new List<string>();
            if (cbAtualizarVeiculo.Checked) { posses.Add(cbItensVeiculo.Text); }
            if (cbAtualizarGeladeira.Checked) { posses.Add(cbItensGeladeira.Text); }
            if (cbAtualizarInternet.Checked) { posses.Add(cbItensInternet.Text); }
            if (cbAtualizarTvAssinatura.Checked) { posses.Add(cbItensTvAssinatura.Text); }
            if (cbAtualizarServicoStreaming.Checked) { posses.Add(cbItensServicoStreaming.Text); }
            if (cbAtualizarComputadorDesktop.Checked) { posses.Add(cbItensComputadorDesktop.Text); }
            if (cbAtualizarNotebook.Checked) { posses.Add(cbItensNotebook.Text); }
            if (cbAtualizarCelular.Checked) { posses.Add(cbItensCelular.Text); }
            if (cbAtualizarTablet.Checked) { posses.Add(cbItensTablet.Text); }
            Pessoa p = new Pessoa(id, nome, end, bairro, cidade, telefone, sexo, nascimento, fumante, posses);
            BancoDados bd = new BancoDados();
            if (bd.Atualiza(indice, p))
                MessageBox.Show("Registros atualizados com sucesso.");
            else
                MessageBox.Show("Erro na atualização dos dados.");
        }
    }
}
