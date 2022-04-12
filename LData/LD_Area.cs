using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LEntidad;

namespace LData
{
  public  class LD_Area
    {
        //public static void SelectTabla(StringBuilder strSQL)
        //{
        //    dt = Class.dbConexion.EjecutarConsulta
        //}

        public static DataTable SelectAreas()
        {
            DataTable dt = new DataTable();
            dt = dboConexion.EjecutarConsulta("dbo.sp_SelectAreas", CommandType.StoredProcedure);
            return dt;
        }

        public static bool ManttoArea(LEntidad.LArea aEntidad)
        {
            bool flag = false;
            SqlParameter[] parametros;

            parametros = new SqlParameter[4];

            parametros[0] = new SqlParameter("@Accion", aEntidad.Accion);
            parametros[1] = new SqlParameter("@IdArea", aEntidad.IdArea );
            parametros[2] = new SqlParameter("@Nombre", aEntidad.Nombre);
            parametros[3] = new SqlParameter("@Descripcion", aEntidad.Descripcion);

        
            flag = dboConexion.EjecutarOperacion("dbo.sp_ManttoAreas", CommandType.StoredProcedure, parametros);
          

                return flag;
        }


    }
}
