using Notas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Notas.Services
{
    public class EstudianteService
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["NotasDBEntities"].ToString();
            con = new SqlConnection(constring);
        }

        public List<EstudianteModel> GetEstudiantes() {
            connection();
            string consulta =
               "SELECT E.carne, E.nombre, E.apellido, E.apellido2, E.nombre + ' ' + E.apellido + ' ' + E.apellido2 AS [nombre completo] " +
               "FROM Estudiante E " +
               "ORDER BY E.carne ";

            SqlCommand cmd = new SqlCommand(consulta, con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            List<EstudianteModel> listaEstudiantes = new List<EstudianteModel>();

            foreach (DataRow dr in dt.Rows)
            {
                listaEstudiantes.Add(
                    new EstudianteModel
                    {
                        carne = Convert.ToString(dr["carne"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        apellido = Convert.ToString(dr["apellido"]),
                        apellido2 = Convert.ToString(dr["apellido2"]),
                        nombreCompleto = Convert.ToString(dr["nombre completo"]),
                    });
            }
            return listaEstudiantes;
        }

        public void AgregarEstudiante(EstudianteModel estudiante)
        {
            connection();

            String[] infoEstudiante = estudiante.nombreCompleto.Split();
            string consulta =
               "INSERT INTO Estudiante(carne, nombre, apellido, apellido2) " +
               "VALUES(@carne, @nombre, @apellido, @apellido2) ";

            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@carne", estudiante.carne);
            cmd.Parameters.AddWithValue("@nombre", infoEstudiante[0]);
            cmd.Parameters.AddWithValue("@apellido", infoEstudiante[1]);
            cmd.Parameters.AddWithValue("@apellido2", infoEstudiante[2]);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
        }
    }
}