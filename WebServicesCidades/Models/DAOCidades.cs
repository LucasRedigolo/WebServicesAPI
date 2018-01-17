using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebServicesCidades.Models {
    public class DAOCidades {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;

        string conexao = @"Data Source =.\SqlExpress; Initial Catalog = projetocidades; user id= sa; password=senai@123";
        public List<Cidades> Listar () {
            List<Cidades> cidades = new List<Cidades> ();

            try {
                con = new SqlConnection ();
                con.ConnectionString = conexao;
                con.Open ();
                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Cidades";
                rd = cmd.ExecuteReader ();

                while (rd.Read ()) {
                    cidades.Add (new Cidades () { ID = rd.GetInt32 (0), Nome = rd.GetString (1), Estado = rd.GetString (2), Habitantes = rd.GetInt32 (3) });
                }
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (SystemException ex) {
                throw new Exception (ex.Message);
            }
            return cidades;
        }

        public bool Cadastro (Cidades cidades) {
            bool resultado = false;
            try {
                con = new SqlConnection (conexao);
                con.Open ();
                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Cidades (nome, estado, habitantes) values(@n, @e, @h)";
                cmd.Parameters.AddWithValue ("@n", cidades.Nome);
                cmd.Parameters.AddWithValue ("@e", cidades.Estado);
                cmd.Parameters.AddWithValue ("@h", cidades.Habitantes);

                int r = cmd.ExecuteNonQuery ();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear ();

            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (SystemException ex) {
                throw new Exception (ex.Message);
            } finally {
                con.Close ();
            }
            return resultado;
        }

        public bool Atualizar (Cidades cid) {
            bool retorno = false;

            try {
                con = new SqlConnection (conexao);
                con.Open ();
                cmd = new SqlCommand ();
                cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Cidades nome=@n, estado=@e, habitantes=@h where id=@i";
                cmd.Parameters.AddWithValue ("@n", cid.Nome);
                cmd.Parameters.AddWithValue ("@e", cid.Estado);
                cmd.Parameters.AddWithValue ("@h", cid.Habitantes);
                cmd.Parameters.AddWithValue ("@i", cid.ID);

                int r = cmd.ExecuteNonQuery ();
                if (r > 0)
                    retorno = true;

                cmd.Parameters.Clear ();

            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar atualizar." + se.Message); // mostrar erro para o usuario caso não der certo o try
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado!!" + ex.Message);
            } finally {
                con.Close ();
            }
            return retorno;
        }
        public bool Apagar (Cidades cid) {
            bool retorno = false;

            try {
                con = new SqlConnection (conexao);
                con.Open ();
                cmd = new SqlCommand ();
                cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.Text; // o metodo que vai ser incluido os valores no banco de dados
                cmd.CommandText = "delete from Cidades where idcategoria=@vi"; // .text para incluir um valor no banco de dados conforme comando (DELETE)
                cmd.Parameters.AddWithValue ("@vi", cid.ID);

                int r = cmd.ExecuteNonQuery (); // isso retorna quantas linhas foram modificadas (igual no SQL MANAGER)
                if (r > 0)
                    retorno = true;

                cmd.Parameters.Clear ();

            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar apagar." + se.Message); // mostrar erro para o usuario caso não der certo o try
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado!!" + ex.Message);
            } finally {
                con.Close ();
            }
            return retorno;
        }
    }
}