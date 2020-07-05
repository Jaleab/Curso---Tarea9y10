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
            EvaluacionModel evaluacion = new EvaluacionModel();
            string consulta =
                "SELECT Eva.evaluacionId, Eva.notasTareas, Eva.notasComprobaciones, Eva.notasExamenesCortos, Eva.notasClases, ISNULL(Eva.participacionForos, 0) AS [Participacion foros], " +
                "ISNULL(Eva.notainvestigacion, 0) AS [Investigacion], ISNULL(Eva.notaPlanificacion, 0) AS [Planificacion], ISNULL(Eva.notaEjecucionReporte, 0) AS [Ejecucion reporte], "+
                "ISNULL(Eva.notaVideo, 0) AS [Video], ISNULL(T.notaCurso, 0) AS [Nota curso], ISNULL(Eva.notaCCQT, 0) AS [ClaComQuiTar], " +
                "ISNULL(Eva.notaPresentacion, 0) AS [Presentacion], ISNULL(Eva.notasExamenes, ' ') AS [Examenes], ISNULL(Eva.notasLaboratorios, ' ') AS [Laboratorios], " +
                "ISNULL(Eva.notaLabs, 0) AS [Nota Labs], ISNULL(Eva.notaParciales, 0) AS [Parciales] " +
                
                "FROM Evaluacion Eva " +
                "JOIN Tiene T "+
                "ON Eva.evaluacionId = T.evaluacionIdFK "+
                "WHERE T.carneEstudianteFK = @carne ";

            cmd.CommandText = consulta;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@carne", carne);

            sd.SelectCommand = cmd;

            SetDataTable();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                evaluacion.evaluacionId = Convert.ToInt32(dr["evaluacionId"]);
                evaluacion.notaCCQT = Convert.ToInt32(dr["ClaComQuiTar"]);
                evaluacion.notasTareas = Convert.ToString(dr["notasTareas"]);
                evaluacion.notasComprobaciones = Convert.ToString(dr["notasComprobaciones"]);
                evaluacion.notasLaboratorios = Convert.ToString(dr["Laboratorios"]);
                evaluacion.notasExamenesCortos = Convert.ToString(dr["notasExamenesCortos"]);
                evaluacion.notasExamenes = Convert.ToString(dr["Examenes"]);
                evaluacion.notasClases = Convert.ToString(dr["notasClases"]);
                evaluacion.participacionForos = Convert.ToInt32(dr["Participacion foros"]);
                evaluacion.notaInvestigacion = Convert.ToInt32(dr["Investigacion"]);
                evaluacion.notaPresentacion = Convert.ToInt32(dr["Presentacion"]);
                evaluacion.notaPlanificacion = Convert.ToInt32(dr["Planificacion"]);
                evaluacion.notaEjecucionReporte = Convert.ToInt32(dr["Ejecucion reporte"]);
                evaluacion.notaVideo = Convert.ToInt32(dr["Video"]);
                evaluacion.notaLabs = Convert.ToInt32(dr["Nota Labs"]);
                evaluacion.notaParciales = Convert.ToInt32(dr["Parciales"]);
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

            SetDataTable();
        }

        public void ModificarInvestigacion(EvaluacionModel evaluacion, string carne)
        {
            connection();
            string consulta =
               "UPDATE Evaluacion " +
               "SET notaInvestigacion = (@notaPlanificacion*0.2+@notaEjecucionReporte*0.3+@notaPresentacion*0.2+@notaVideo*0.3)*0.2, " +
               "notaPlanificacion = @notaPlanificacion, notaEjecucionReporte = @notaEjecucionReporte, notaPresentacion = @notaPresentacion, "+
               "notaVideo = @notaVideo " +
               "WHERE evaluacionId = (SELECT evaluacionIdFK FROM Tiene WHERE carneEstudianteFK = @carne) ";

            cmd.CommandText = consulta;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@carne", carne);
            cmd.Parameters.AddWithValue("@notaPlanificacion", evaluacion.notaPlanificacion);
            cmd.Parameters.AddWithValue("@notaEjecucionReporte", evaluacion.notaEjecucionReporte);
            cmd.Parameters.AddWithValue("@notaPresentacion", evaluacion.notaPresentacion);
            cmd.Parameters.AddWithValue("@notaVideo", evaluacion.notaVideo);

            sd.SelectCommand = cmd;

            SetDataTable();
        }

        public void ModificarParticipacion(EvaluacionModel evaluacion, string carne)
        {
            connection();
            string consulta =
               "UPDATE Evaluacion " +
               "SET participacionForos = @participacion*0.2 " +
               "WHERE evaluacionId = (SELECT evaluacionIdFK FROM Tiene WHERE carneEstudianteFK = @carne) ";

            cmd.CommandText = consulta;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@carne", carne);
            cmd.Parameters.AddWithValue("@participacion", evaluacion.participacionForos);

            sd.SelectCommand = cmd;

            SetDataTable();
        }

        public void ModificarExamenes(string[] notas, string carne)
        {
            connection();
            string consulta =
               "UPDATE Evaluacion " +
               "SET notaParciales = @notaParciales*0.2 " +
               "WHERE evaluacionId = (SELECT evaluacionIdFK FROM Tiene WHERE carneEstudianteFK = @carne) ";

            cmd.CommandText = consulta;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@carne", carne);
            cmd.Parameters.AddWithValue("@notaParciales", SacarPromedio(notas));

            sd.SelectCommand = cmd;

            SetDataTable();
        }

        public void ModificarLaboratorios(string[] notas, string carne)
        {
            connection();
            string consulta =
               "UPDATE Evaluacion " +
               "SET notaLabs = @notaLaboratorios*0.2 " +
               "WHERE evaluacionId = (SELECT evaluacionIdFK FROM Tiene WHERE carneEstudianteFK = @carne) ";

            cmd.CommandText = consulta;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@carne", carne);
            cmd.Parameters.AddWithValue("@notaLaboratorios", SacarPromedio(notas));

            sd.SelectCommand = cmd;

            SetDataTable();
        }

        public void ModificarCCQT(string[] notas, string carne)
        {
            connection();
            string consulta =
               "UPDATE Evaluacion " +
               "SET notaCCQT = @notas*0.2 " +
               "WHERE evaluacionId = (SELECT evaluacionIdFK FROM Tiene WHERE carneEstudianteFK = @carne) ";

            cmd.CommandText = consulta;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@carne", carne);
            cmd.Parameters.AddWithValue("@notas", SacarPromedio(notas));

            sd.SelectCommand = cmd;

            SetDataTable();
        }

        private int SacarPromedio(string[] notas) {
            int valor = 0;
            if(notas != null && notas.Length > 0) {
                for (var i = 0; i < notas.Length; ++i)
                {
                    if (notas[i] != "")
                    {
                        valor += int.Parse(notas[i]);
                    }
                }
                valor = valor / notas.Length;
            }
            
            return valor;
        }

        private void SetDataTable() {
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