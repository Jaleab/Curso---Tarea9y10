using Notas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Notas.Services
{
    public class EstudianteService
    {
        private SqlConnection con;
        private SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter sd = new SqlDataAdapter();
        private DataTable dt = new DataTable();

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

            cmd.CommandText = consulta;
            cmd.Connection = con;
            sd.SelectCommand = cmd;

            SetDataTable();

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
            string consulta =
               "INSERT INTO Estudiante(carne, nombre, apellido, apellido2) " +
               "VALUES(@carne, @nombre, @apellido, @apellido2) ";

            cmd.CommandText = consulta;
            cmd.Connection = con;
            sd.SelectCommand = cmd;

            cmd.Parameters.AddWithValue("@carne", estudiante.carne);

            char[] separadores = { ' ', ',' };
            int n = 3;
            string[] infoEstudiante = estudiante.nombreCompleto.Split(separadores, n);
            if (infoEstudiante != null && infoEstudiante.Length > 0) {
                cmd.Parameters.AddWithValue("@nombre", infoEstudiante[0]);
                if (infoEstudiante.Length > 2)
                {
                    cmd.Parameters.AddWithValue("@apellido", infoEstudiante[1]);
                    cmd.Parameters.AddWithValue("@apellido2", infoEstudiante[2]);
                }
                else
                {
                    if (infoEstudiante.Length == 2)
                    {
                        cmd.Parameters.AddWithValue("@apellido", infoEstudiante[1]);
                        cmd.Parameters.AddWithValue("@apellido2", " ");
                    }
                }
            }

            SetDataTable();
        }

        private void SetDataTable()
        {
            con.Open();
            try
            {
                sd.Fill(dt);
            }
            catch (Exception e)
            {

            }
            con.Close();
        }
    }
}