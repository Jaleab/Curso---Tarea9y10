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

        public EvaluacionModel GetEvaluacionEstudiante(string carne)
        {
            connection();
            string consulta =
                "SELECT Eva.evaluacionId, Eva.notasTareas, Eva.notasComprobaciones, Eva.notasExamenesCortos, Eva.notasClases, ISNULL(Eva.participacionForos, 0) AS [Participacion foros], " +
                "ISNULL(Eva.notainvestigacion, 0) AS [Investigacion], ISNULL(Eva.notaPlanificacion, 0) AS [Planificacion], ISNULL(Eva.notaEjecucionReporte, 0) AS [Ejecucion reporte], "+
                "ISNULL(Eva.notaVideo, 0) AS [Video], ISNULL(T.notaCurso, 0) AS [Nota curso], ISNULL(Eva.notaCCQT, 0) AS [ClaComQuiTar] " +
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
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                evaluacion.evaluacionId = Convert.ToInt32(dr["evaluacionId"]);
                evaluacion.notaCCQT = Convert.ToInt32(dr["ClaComQuiTar"]);
                evaluacion.notasTareas = Convert.ToString(dr["notasTareas"]);
                evaluacion.notasComprobaciones = Convert.ToString(dr["notasComprobaciones"]);
                evaluacion.notasExamenesCortos = Convert.ToString(dr["notasExamenesCortos"]);
                evaluacion.notasClases = Convert.ToString(dr["notasClases"]);
                evaluacion.participacionForos = Convert.ToInt32(dr["Participacion foros"]);
                evaluacion.notainvestigacion = Convert.ToInt32(dr["Investigacion"]);
                evaluacion.notaPlanificacion = Convert.ToInt32(dr["Planificacion"]);
                evaluacion.notaEjecucionReporte= Convert.ToInt32(dr["Ejecucion reporte"]);
                evaluacion.notaVideo= Convert.ToInt32(dr["Video"]);

                evaluacion.Tienes.Add(new TieneModel
                {
                    carneEstudianteFK = carne,
                    evaluacionIdFK = evaluacion.evaluacionId,
                    notaCurso = Convert.ToInt32(dr["Nota curso"]),
            });
            }
            return evaluacion;

        }

        public void AgregarEvaluacion(string carne)
        {
            connection();
            string consulta =
               "INSERT INTO Evaluacion(notaCCQT) " +
               "VALUES(NULL); " +
               "INSERT INTO Tiene(carneEstudianteFK, evaluacionIdFK) " +
               "VALUES(@carne, (SELECT IDENT_CURRENT('Evaluacion'))); ";

            cmd.CommandText = consulta;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@carne", carne);

            sd.SelectCommand = cmd;

            con.Open();
            sd.Fill(dt);
            con.Close();
        }
    }
}