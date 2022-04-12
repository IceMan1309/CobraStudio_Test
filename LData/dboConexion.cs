using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LData
{
  public  class dboConexion
    {

        public static String Cadena_Conexion = ConfigurationManager.ConnectionStrings["xConSQL"].ConnectionString;

        // SQL Server
        private static SqlConnection CnGeneral = new SqlConnection(Cadena_Conexion);
        private static SqlCommand Comando = new SqlCommand();
        private static SqlDataAdapter adaptador = new SqlDataAdapter();

        #region "Conexion"
        public static void Conectar()
        {
            try
            {

                CnGeneral.Open();

            }
            catch (Exception)
            {

            }
        }

        public static void DesFull()
        {
            CnGeneral.Close();

        }
        #endregion

        #region "Transacciones"

        protected static SqlTransaction MTransaccion;
        protected static bool EnTransaccion;


        public static void IniciarTransaccion()
        {
            try
            {
                Conectar();


                MTransaccion = CnGeneral.BeginTransaction();

                EnTransaccion = true;
            } //end try
            finally
            {
                EnTransaccion = false;
            }
        }// end IniciarTransaccion


        //Confirma la transacción activa. 
        public static void TerminarTransaccion()
        {
            try
            {
                MTransaccion.Commit();

            }
            finally
            {
                MTransaccion = null;

                EnTransaccion = false;
                DesFull();

            }// end finally
        }// end TerminarTransaccion


        //Cancela la transacción activa.
        public static void AbortarTransaccion()
        {
            try
            {
                MTransaccion.Rollback();

            }
            finally
            {
                MTransaccion = null;

                EnTransaccion = false;
                DesFull();
            }// end finally
        }// end AbortarTransaccion

        #endregion

        #region "Operaciones CRUD"
        public static bool EjecutarOperacion(string sQuerry, CommandType tipoComando)
        {
            bool Flag = false;

            try
            {

                if (CnGeneral.State != ConnectionState.Open)
                {
                    Conectar();
                }
                else
                {
                    SqlCommand Comtra = new SqlCommand(sQuerry, CnGeneral, MTransaccion);
                    Comtra.ExecuteNonQuery();
                }

                Flag = true;
            }
            catch (Exception e)
            {

            }

            return Flag;
        }
        public static bool EjecutarOperacion(string sQuerry, CommandType tipoComando, SqlParameter[] parametros)
        {
            bool Flag = false;

            try
            {

                if (CnGeneral.State != ConnectionState.Open)
                {
                    Conectar();
                }
                else
                {
                    SqlCommand Comtra = new SqlCommand(sQuerry, CnGeneral, MTransaccion);
                    Comtra.CommandType = tipoComando;
                    Comtra.Parameters.AddRange(parametros);

                    Comtra.ExecuteNonQuery();
                }

                Flag = true;
            }
            catch (Exception e)
            {

            }

            return Flag;
        }



        public static DataTable EjecutarConsulta(string sQuerry, CommandType tipoComando, SqlParameter[] parametros)
        {
            //METODO DESCONECTADO
            DataSet resultado = new DataSet();

            try
            {
                SqlCommand Comtra = new SqlCommand(sQuerry, CnGeneral);
                Comtra.Parameters.AddRange(parametros);
                adaptador.SelectCommand = Comtra;
                adaptador.SelectCommand.CommandTimeout = 0;
                adaptador.SelectCommand.CommandType = tipoComando;
                adaptador.Fill(resultado);
                return resultado.Tables[0];
            }
            catch (Exception e)
            {

                return null;
            }
        }



        public static DataTable EjecutarConsulta(string sQuerry, CommandType tipoComando)
        {
            //METODO DESCONECTADO
            DataSet resultado = new DataSet();

            try
            {

                adaptador.SelectCommand = new SqlCommand(sQuerry, CnGeneral);
                adaptador.SelectCommand.CommandTimeout = 0;
                adaptador.SelectCommand.CommandType = tipoComando;

                adaptador.Fill(resultado);

                return resultado.Tables[0];
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static DataTable EjecutarConsTran(string sQuerry, CommandType tipoComando)
        {
            DataSet resultado = new DataSet();

            try
            {
                SqlCommand Comtra = new SqlCommand(sQuerry, CnGeneral, MTransaccion);
                adaptador.SelectCommand = Comtra;
                adaptador.SelectCommand.CommandTimeout = 0;
                adaptador.SelectCommand.CommandType = tipoComando;
                adaptador.Fill(resultado);


            }
            catch
            {
                return null;
            }

            return resultado.Tables[0];
        }
        #endregion
    }
}
