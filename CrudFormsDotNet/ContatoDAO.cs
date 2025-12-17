using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using CrudFormsDotNet;
using Contato2;

namespace AgendaBD
{
    public class ContatoDAO
    {
        // CREATE
        public void Adicionar(Contato c)
        {
            string sql = "INSERT INTO contatos (nome, telefone, email) VALUES (@nome, @telefone, @email)";

            try
            {
                using (MySqlConnection conn = ConnectionFactory.GetConnection())
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@nome", c.Nome);
                    cmd.Parameters.AddWithValue("@telefone", c.Telefone);
                    cmd.Parameters.AddWithValue("@email", c.Email);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Contato inserido com sucesso!");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao inserir: " + ex.Message);
            }
        }




        // READ ALL
        public List<Contato> ListarTodos()
        {
            List<Contato> lista = new List<Contato>();
            string sql = "SELECT * FROM contatos";

            try
            {
                using (MySqlConnection conn = ConnectionFactory.GetConnection())
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var c = new Contato()
                        {
                            Id = dr.GetInt32("id"),
                            Nome = dr.GetString("nome"),
                            Telefone = dr.GetString("telefone"),
                            Email = dr.GetString("email")
                        };
                        lista.Add(c);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao listar: " + ex.Message);
            }

            return lista;
        }

        // UPDATE
        public void Atualizar(Contato c)
        {
            string sql = "UPDATE contatos SET nome=@nome, telefone=@telefone, email=@email WHERE id=@id";

            try
            {
                using (MySqlConnection conn = ConnectionFactory.GetConnection())
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", c.Id);
                    cmd.Parameters.AddWithValue("@nome", c.Nome);
                    cmd.Parameters.AddWithValue("@telefone", c.Telefone);
                    cmd.Parameters.AddWithValue("@email", c.Email);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Contato atualizado com sucesso!");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message);
            }
        }
        // DELETE
        public void Remover(int id)
        {
            string sql = "DELETE FROM contatos WHERE id=@id";

            try
            {
                using (MySqlConnection conn = ConnectionFactory.GetConnection())
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Contato removido com sucesso!");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao remover: " + ex.Message);
            }
        }
    }
}
