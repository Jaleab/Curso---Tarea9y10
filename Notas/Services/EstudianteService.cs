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
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["NotasDBEntities1"].ToString();
            con = new SqlConnection(constring);
        }

        public List<EstudianteModel> GetEstudiantes() {
            Connection();
            string consulta =
               "SELECT E.carne, E.nombre, E.apellido, E.apellido2 " +
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
                    });
            }
            return listaEstudiantes;
        }
    }
}