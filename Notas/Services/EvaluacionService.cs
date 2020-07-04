using Notas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Notas.Services
{
    public class EvaluacionService
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

        public void AgregarEvaluacion(string carne) {
            connection();
            string consulta =
               "INSERT INTO Evaluacion(carneEstudianteFK, evaluacioIdFK) " +
               "VALUES(DEFAULT, DEFAULT); ";

            cmd.CommandText = consulta;
            cmd.Connection = con;

            sd.SelectCommand = cmd;

            con.Open();
            con.Close();
        } 

        public EvaluacionModel GetEvaluacionEstudiante(string carne)
        {
            connection();
            string consulta =
                "SELECT * "+
                "FROM Evaluacion Eva "+
                "JOIN Tiene T "+
                "ON Eva.evaluacionId = T.evaluacionIdFK "+
                "WHERE T.carneEstudianteFK = @carne ";

            cmd.CommandText = consulta;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@carne", carne);

            sd.SelectCommand = cmd;

            con.Open();
            sd.Fill(dt);
            con.Close();


            EvaluacionModel evaluacion = new EvaluacionModel();
            DataRow dr = dt.Rows[0]; 
            evaluacion.notasTareas = Convert.ToString(dr["notasTareas"]);
            evaluacion.notasComprobaciones = Convert.ToString(dr["notasTareas"]);
            evaluacion.notasExamenesCortos = Convert.ToString(dr["notasExamenesCortos"]);
            evaluacion.notasClases = Convert.ToString(dr["notasClases"]);
            evaluacion.participacionForos = Convert.ToInt32(dr["participacionForos"]);
            evaluacion.notainvestigacion = Convert.ToInt32(dr["notaInvestigacion"]);
            evaluacion.notaEjecucionReporte = Convert.ToInt32(dr["notaEjecucionReporte"]);
            evaluacion.notaVideo = Convert.ToInt32(dr["notaVideo"]);
            return evaluacion;
        }
    }
}