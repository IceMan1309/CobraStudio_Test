using System;
using System.Data.SqlClient;
using System.Data;
using LEntidad;
using LData;
using System.Web.UI.WebControls;

namespace LLog
{
    public class Operaciones
    {
        #region "Areas"

        public static DataTable SelecArea()
        {
            return LD_Area.SelectAreas();
        }

        public static DropDownList DDL_Area(DropDownList ddl)
        {
            DataTable dt = new DataTable();

            dt = SelecArea();
            dt.Rows.Add(0, "Seleccione...");
            ddl.DataSource = dt;
            ddl.DataValueField = "IdArea";
            ddl.DataTextField = "Nombre";
            ddl.DataBind();
            ddl.SelectedValue = "0";

            return ddl;

        }

        public static bool ManttoAreas(LArea aEntidad)
        {
            bool Flag = false;
           dboConexion.IniciarTransaccion();
            Flag = LD_Area.ManttoArea(aEntidad);
           
            if (Flag == true)
            {
                dboConexion.TerminarTransaccion();
            }
            else
            {
                dboConexion.AbortarTransaccion();
            }
            return Flag;

        }

        #endregion

        #region "Empleado"
        public static DataTable SelectEmpleados()
        {
            return LD_Empleado.SelectEmpleados();
        }


        public static DropDownList DDL_Jefe(DropDownList ddl)
        {
            DataTable dt = new DataTable();

            dt = SelectEmpleados();
            dt.Rows.Add(0, "Seleccione...");
            ddl.DataSource = dt;
            ddl.DataValueField = "IdEmpleado";
            ddl.DataTextField = "NombreCompleto";
            ddl.DataBind();
            ddl.SelectedValue = "0";

            return ddl;

        }

        public static bool GetEmpleado(LEmpleado aEntidad)
        {
            bool flag = false;
          
            flag = LD_Empleado.GetEmpleado(aEntidad);
            return flag;
        }


        public static bool ManttoEmpleado(LEmpleado aEntidad)
        {
            bool flag = false;
            dboConexion.IniciarTransaccion();
            flag = LD_Empleado.ManttoEmpleado(aEntidad);
            if (flag == true)
            {
                dboConexion.TerminarTransaccion();
            }
            else
            {
                dboConexion.AbortarTransaccion();
            }

            return flag;
        }
     


        #endregion
    }
}
