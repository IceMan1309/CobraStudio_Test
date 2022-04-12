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
   public class LD_Empleado
    {
        public static void SelectTabla(StringBuilder strSQL)
        {
            strSQL.Append("Select * From Empleado AS e");
        }
        public static DataTable SelectEmpleados()
        {
            DataTable dt = new DataTable();
            dt = dboConexion.EjecutarConsulta("Select * From Empleado AS e ", CommandType.Text);
            return dt;
        }

        public static bool GetEmpleado(LEntidad.LEmpleado aEntidad)
        {
            bool flag = false;
            DataTable dt = new DataTable();
            StringBuilder strSQL = new StringBuilder();
            SelectTabla(strSQL);
            SqlParameter[] parametros;

            parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdEmpleado", aEntidad.IdEmpleado);

            strSQL.Append(" Where e.IdEmpleado=@IdEmpleado ");

            dt =dboConexion.EjecutarConsulta(strSQL.ToString(), CommandType.Text,parametros);
            if (dt.Rows.Count > 0)
            {
               aEntidad.IdArea = Convert.ToInt32(dt.Rows[0]["IdArea"].ToString());
               aEntidad.IdJefe = Convert.ToInt32(string.IsNullOrEmpty(dt.Rows[0]["IdJefe"].ToString()) ? "0" : dt.Rows[0]["IdJefe"].ToString());
               aEntidad.NombreCompleto  = dt.Rows[0]["NombreCompleto"].ToString();
                aEntidad.Correo = dt.Rows[0]["Correo"].ToString();
                aEntidad.Cedula = dt.Rows[0]["Cedula"].ToString();
                aEntidad.FechaIngreso = Convert.ToDateTime(dt.Rows[0]["FechaIngreso"].ToString());
                aEntidad.FechaNacimiento = Convert.ToDateTime(dt.Rows[0]["FechaNacimiento"].ToString());
                aEntidad.IdEmpleado = Convert.ToInt32( dt.Rows[0]["IdEmpleado"].ToString());
                aEntidad.Foto = Encoding.ASCII.GetBytes(dt.Rows[0]["Foto"].ToString());
                flag = true;

            }
            return flag;
        }

        public static bool ManttoEmpleado(LEmpleado aEntidad)
        {
            bool flag = false;
            StringBuilder strSQL = new StringBuilder();
            SqlParameter[] parametros;

            parametros = new SqlParameter[9];

            parametros[0] = new SqlParameter("@foto", aEntidad.Foto);
            parametros[1] = new SqlParameter("@IdArea", aEntidad.IdArea);
            parametros[2] = new SqlParameter("@NombreCompleto", aEntidad.NombreCompleto);
            parametros[3] = new SqlParameter("@IdJefe", aEntidad.IdJefe);
            parametros[4] = new SqlParameter("@FechaIngreso", aEntidad.FechaIngreso);
            parametros[5] = new SqlParameter("@FechaNacimiento", aEntidad.FechaNacimiento);
            parametros[6] = new SqlParameter("@Cedula", aEntidad.Cedula);
            parametros[7] = new SqlParameter("@Correo", aEntidad.Correo);
            parametros[8] = new SqlParameter("@IdEmpleado", aEntidad.IdEmpleado);

            switch (aEntidad.Accion)
            {
                case "I":
                    strSQL.Append("Insert Into Empleado ");
                    strSQL.Append(" (NombreCompleto,	Cedula,	Correo,	FechaNacimiento,	FechaIngreso,	IdJefe,	IdArea, Foto) ");
                    strSQL.Append(" VALUES ");
                    strSQL.Append(" (@NombreCompleto,	@Cedula,	@Correo,	@FechaNacimiento,	@FechaIngreso, case when @IdJefe=0 then null else @IdJefe end,	@IdArea, @Foto) ");
                    break;
                case "U":
                    strSQL.Append("Update Empleado Set ");
                    strSQL.Append(" NombreCompleto=@NombreCompleto,	Cedula=@Cedula,	Correo=@Correo,	FechaNacimiento=@FechaNacimiento,	FechaIngreso=@FechaIngreso,	IdJefe=case when @IdJefe=0 then null else @IdJefe end,	IdArea=@IdArea ");
                    strSQL.Append(" Where IdEmpleado=@IdEmpleado ");
                    break;
                case "D":
                    strSQL.Append(" Delete FROM Empleado ");
                    strSQL.Append(" Where IdEmpleado=@IdEmpleado ");
                    break;

            }

            flag = dboConexion.EjecutarOperacion(strSQL.ToString(), CommandType.Text, parametros);
            return flag;
        }
    }
}
