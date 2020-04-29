using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
namespace DemoDapper
{
   public class Consulta
    {
       private string cadena = ConfigurationManager.ConnectionStrings["Conexion"].ToString();

        public Cliente ObtenerCliente(string NumeroDocumento)
        {
            using (IDbConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();

                var parametros = new DynamicParameters();
                parametros.Add("pNumeroDocumento", NumeroDocumento);

                var cliente = conexion.QuerySingle<Cliente>("SP_CLIENTE_OBTENER", param: parametros, commandType: CommandType.StoredProcedure);
                return cliente;
            }
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            using (IDbConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                var cliente = conexion.Query<Cliente>("SELECT * FROM Cliente",
                commandType: CommandType.Text);
                return cliente;
            }
        }

        public int Insertar(Cliente cliente)
        {
            using(IDbConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                string cmdText = "INSERT INTO [Cliente]([Nombre],[ApellidoPaterno],[ApellidoMaterno]) VALUES ('{0}','{1}','{2}')";
                string sentencia = string.Format(cmdText, cliente.Nombre, cliente.ApellidoPaterno, cliente.ApellidoMaterno);

                return conexion.Execute(sentencia);
            }
        }

        public int InsertarSP(Cliente cliente)
        {
            using (IDbConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@Nombre", cliente.Nombre);
                parametros.Add("@ApellidoPaterno", cliente.ApellidoPaterno);
                parametros.Add("@ApellidoMaterno", cliente.ApellidoMaterno);

                return conexion.Execute("SP_INSERTAR_CLIENTE", param:parametros,commandType:CommandType.StoredProcedure);

            }
        }

    }
}
