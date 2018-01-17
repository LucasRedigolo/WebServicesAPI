using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebServicesCidades.Models {
    public class DAOCidades {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;

        string conexao = @"Data Source -.\SqlExpress; Initial Catalog = projetocidades; user id= sa; password=senai@123";
        public List<Cidades> Listar () {
            List<Cidades> cidades = new List<Cidades> ();

            try {
                con = new SqlConnection ();
                con.ConnectionString = conexao;
                con.Open ();
                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from tbcidades";
                rd = cmd.ExecuteReader ();

                while (rd.Read ()) {
                    cidades.Add (new Cidades () { ID = rd.GetInt32 (0), Nome = rd.GetString (1), Estado = rd.GetString (2), Habitantes = rd.GetInt32 (3) });
                }
            } catch (SqlException se) {
                throw new Exception (se.Message);
            }
            catch (SystemException ex) {
                throw new Exception (ex.Message);
            }
        }
    }
}