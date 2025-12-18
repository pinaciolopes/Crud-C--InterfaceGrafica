using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using AgendaBD;
using Contato2;

namespace CrudFormsDotNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Informe o Email");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                MessageBox.Show("Informe o telefone");
                return;
            }

            ContatoDAO contatoDao = new ContatoDAO();

            string nome = txtNome.Text.Trim();
            string telefone = txtTelefone.Text.Trim();
            string email = txtEmail.Text.Trim();

            Contato contato = new Contato(0, nome, telefone, email);

            contatoDao.Adicionar(contato);
            ListarComboBox();
            LimparCamposEditar();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarComboBox();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {


            ContatoDAO contatoDao = new ContatoDAO();

            contatoDao.ListarTodos();
            dataGridContatos.DataSource = contatoDao.ListarTodos();

            if (dataGridContatos.Rows.Cast<DataGridViewRow>()
            .All(r => r.IsNewRow))
            {
                MessageBox.Show("Nenhum contato cadastrado.");
            }

            ListarComboBox();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (cbmDeletar.SelectedItem != null)
            {
                Contato contatoSelecionado = (Contato)cbmDeletar.SelectedItem;
                int id = contatoSelecionado.Id;


                ContatoDAO dao = new ContatoDAO();
                dao.Remover(id);

                // Limpar campos e atualizar lista
                ListarComboBox();

            }
            else
            {
                MessageBox.Show("Selecione um contato para deletar.");
            }



        }

        private void ListarComboBox()
        {
            ContatoDAO dao = new ContatoDAO();

            cbmDeletar.DataSource = null;
            cbmDeletar.DataSource = dao.ListarTodos();

            cbmDeletar.DisplayMember = "Nome"; // o que aparece
            cbmDeletar.ValueMember = "Id";     // valor real (ID)

            cbmDeletar.SelectedIndex = -1; // nada selecionado

            ContatoDAO dao2 = new ContatoDAO();

            cbmEditar.DataSource = null;
            cbmEditar.DataSource = dao2.ListarTodos();

            cbmEditar.DisplayMember = "Nome"; // o que aparece
            cbmEditar.ValueMember = "Id";     // valor real (ID)

            cbmEditar.SelectedIndex = -1; // nada selecionado
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cbmEditar.SelectedItem == null)
            {
                MessageBox.Show("Selecione um contato");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEditarNome.Text))
            {
                MessageBox.Show("Informe o nome");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEditarEmail.Text))
            {
                MessageBox.Show("Informe o Email");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEditarTelefone.Text))
            {
                MessageBox.Show("Informe o telefone");
                return;
            }

            Contato contato = new Contato();
            contato.Id = Convert.ToInt32(cbmEditar.SelectedValue);
            contato.Nome = txtEditarNome.Text;
            contato.Email = txtEditarEmail.Text;
            contato.Telefone = txtEditarTelefone.Text;

            ContatoDAO dao = new ContatoDAO();
            dao.Atualizar(contato);

            // Atualiza ComboBox e Grid
            ListarComboBox();
            LimparCamposEditar();
        }

        private void cbmDeletar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LimparCamposEditar()
        {
            txtEditarNome.Clear();
            txtEditarEmail.Clear();
            txtEditarTelefone.Clear();
            cbmEditar.SelectedIndex = -1; // limpa seleção
        }

    }
}


