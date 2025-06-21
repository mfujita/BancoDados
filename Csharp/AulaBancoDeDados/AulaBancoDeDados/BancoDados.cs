using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaBancoDeDados
{
    class BancoDados
    {
        private string stringConnection = @"server=127.0.0.1;uid=root;pwd=;database=dsvd2";

        public bool Armazenar(Pessoa pes)
        {
            string sql = "INSERT INTO bd1 (nome, endereco, bairro, cidade, telefone, sexo, nascimento, fumante, propriedades) VALUES (@nome, @endereco, @bairro, @cidade, @telefone, @sexo, @nascimento, @fumante, @propriedades)";
            try
            {
                using (var conn = new MySqlConnection(stringConnection))
                {
                    conn.Open();
                    using (var command = new MySqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@nome", pes.nomeCompleto);
                        command.Parameters.AddWithValue("endereco", pes.endereco);
                        command.Parameters.AddWithValue("@bairro", pes.bairro);
                        command.Parameters.AddWithValue("@cidade", pes.cidade);
                        command.Parameters.AddWithValue("@telefone", pes.telefone);
                        command.Parameters.AddWithValue("@sexo", pes.sexo);
                        command.Parameters.AddWithValue("@nascimento", pes.nascimento);
                        command.Parameters.AddWithValue("@fumante", pes.fumante);
                        string itens = "";
                        foreach (var item in pes.posses)
                        {
                            itens += item + "|";
                        }
                        command.Parameters.AddWithValue("@propriedades", itens);
                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public DataTable Buscar(string name, string endereco, string bairro, string cidade, string telefone, String sexo, string nascimento)
        {
            
            try
            {
                string sql = "SELECT * FROM bd1 where nome like '%" + name + "%'";
                sql += "and endereco like '%" + endereco + "%'";
                sql += "and bairro like '%" + bairro + "%'";
                sql += "and cidade like '%" + cidade + "%'";
                sql += "and telefone like '%" + telefone + "%'";
                sql += "and sexo like '%" + sexo + "%'";
                sql += "and nascimento like '%" + nascimento + "%'";

                var dt = new DataTable();
                MySqlConnection conn = new MySqlConnection(stringConnection);
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql, conn);

                MySqlDataReader reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                //    int id = reader.GetInt32(0);
                //    string nome = reader.GetString(1);
                //    string endereco = reader.GetString(2);
                //    string bairro = reader.GetString(3);
                //    string cidade = reader.GetString(4);
                //    string telefone = reader.GetString(5);
                //    char sexo = reader.GetChar(6);
                //    DateTime nasc = reader.GetDateTime(7);
                //    bool fum = reader.GetBoolean(8);
                //    string prop = reader.GetString(9);
                //}
                dt.Load(reader);
                reader.Close();
                conn.Close();
                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
