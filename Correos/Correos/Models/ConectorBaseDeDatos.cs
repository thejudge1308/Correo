using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correos.Models
{
    public class ConectorBaseDeDatos
    {
        public static string path = "Server=127.0.0.1;User Id=postgres;" +
                                   "Password=postgres;Database=correo;";
        NpgsqlConnection conn;

        public ConectorBaseDeDatos() {
            this.conn = new NpgsqlConnection(path);
            conn.Open();
        }

        public NpgsqlDataReader RealizarConsulta(string query) {
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public void CerrarConexion() {
            this.conn.Close();
        }
    }
}
