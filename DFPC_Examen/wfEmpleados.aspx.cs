using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;
using LEntidad;
using LLog;

namespace DFPC_Examen
{
    public partial class wfEmpleados : System.Web.UI.Page
    {
        Class.entEmpleado aEntidad = new Class.entEmpleado();
        DataTable dt = new DataTable();
        private string codigoJs;
        StringBuilder strSQL = new StringBuilder();


        void CargarDatos()
        {

            //Cargando Jefes
            Operaciones.DDL_Jefe(ddlIdJefe);


            //Cargando Areas
            Operaciones.DDL_Area(ddlArea);
           

            //Cargando Empleados
            dt.Clear();
            dt = Operaciones.SelectEmpleados();  
            gvEmpleados.DataSource = dt;
            gvEmpleados.DataBind();

        }

        void CargaEmpleado(string IdEmpleado)
        {
            LEmpleado aEntid = new LEmpleado();
         
            aEntid.IdEmpleado = Convert.ToInt32(IdEmpleado);

            if (LLog.Operaciones.GetEmpleado(aEntid) == true)
            {

                ddlArea.SelectedValue = aEntid.IdArea.ToString();
                ddlIdJefe.SelectedValue = aEntid.IdJefe.ToString();
                txtNombre.Text = aEntid.NombreCompleto;
                txtCorreo.Text = aEntid.Correo;
                txtCedula.Text = aEntid.Cedula;
                rdFecIngreso.SelectedDate = aEntid.FechaIngreso;
                rdFecNac.SelectedDate = aEntid.FechaNacimiento;
                lblID.Text = aEntid.IdEmpleado.ToString();
            }
               

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Accion"] = "";
                Habilita(false);
                CargarDatos();
            }
        }
        private byte[] GetStreamAsByteArray(Stream stream)
        {
            int streamLength = Convert.ToInt32(stream.Length);
            byte[] fileData = new byte[streamLength + 1];

            stream.Read(fileData, 0, streamLength);
            stream.Close();

            return fileData;
        }

        private Boolean ValidarExtension(string sExtension)
        {
            Boolean verif = false;
            switch (sExtension)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".bmp":
                    verif = true;
                    break;
                default:
                    verif = false;
                    break;
            }
            return verif;
        }

        void Habilita(bool flag)
        {

            ddlIdJefe.Enabled = flag;
            txtNombre.Enabled = flag;
            txtCorreo.Enabled = flag;
            txtCedula.Enabled = flag;
            rdFecIngreso.Enabled = flag;
            rdFecNac.Enabled = flag;

        }

        #region "Btns Secundarios"
        protected void ibtnBorrar_Click(object sender, ImageClickEventArgs e)
        {
            Session["Accion"] = "D";
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            Session["Accion"] = "U";
            Habilita(true);
        }

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Session["Accion"] = "I";
            Habilita(true);
        }


        #endregion

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            //Utilizando Entidades
            LEmpleado aEnti = new LEmpleado();
            aEnti.IdEmpleado = string.IsNullOrEmpty(lblID.Text) ? 0 : Convert.ToInt32(lblID.Text);
            aEnti.IdArea = Convert.ToInt32( ddlArea.SelectedValue);
            aEnti.IdJefe = Convert.ToInt32(ddlIdJefe.SelectedValue);
            aEnti.NombreCompleto = txtNombre.Text.ToUpper().Trim();
            aEnti.FechaIngreso = rdFecIngreso.SelectedDate.Value;
            aEnti.FechaNacimiento = rdFecNac.SelectedDate.Value;
            aEnti.Cedula = txtCedula.Text;
            aEnti.Correo = txtCorreo.Text;

            //Tratando Imagen
           string Nombre = FileUpload1.FileName;
           string Extension = Path.GetExtension(Nombre);

            if (!ValidarExtension(Extension))
            {
                codigoJs = "<script language='javascript'>alert('Archivo no es Imagen')</script>";
            }
            else
            {
                try
                {
                    if (!FileUpload1.HasFile)
                        return;

                    byte[] Imagen = GetStreamAsByteArray(FileUpload1.PostedFile.InputStream);

                    aEnti.Foto = Imagen;
                }
                catch (Exception ex)
                {
                }
                //

                bool flag = false;
                aEnti.Accion = Session["Accion"].ToString();
                strSQL.Clear();
                if ( !string.IsNullOrEmpty(txtNombre.Text) && ddlArea.SelectedValue.ToString()!="0")
                {
                  
                    
                    flag = Operaciones.ManttoEmpleado(aEnti);
                    if (flag == true)
                    {
                        

                        codigoJs = "<script language='javascript'>alert('Registro Guardado')</script>";
                        Habilita(false);
                        CargarDatos();

                    }
                    else
                    {
                        

                        codigoJs = "<script language='javascript'>alert('Error!! Verifique')</script>";
                    }
                }
                else
                {
                    codigoJs = "<script language='javascript'>alert('Ingrese Nombre y/ Seleccione Area')</script>";
                }
            }
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tempJS", codigoJs, false);


        }




        #region "Iteracciones de Objetos"
        protected void gvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblID.Text = gvEmpleados.SelectedRow.Cells[2].Text;
            CargaEmpleado(lblID.Text);
        }
        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlParameter[] parametros;
            dt.Clear();

            if (ddlArea.SelectedValue == "0")
            {
                dt.Clear();
                dt = Operaciones.SelectEmpleados();
                gvEmpleados.DataSource = dt;
                gvEmpleados.DataBind();
            }
            else
            {
                parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@IdArea", ddlArea.SelectedValue);

                dt = Class.dbConexion.EjecutarConsulta("Select * From Empleado AS e Where e.IdArea=@IdArea ", CommandType.Text, parametros);

                if (dt.Rows.Count > 0)
                {
                    gvEmpleados.DataSource = dt;
                    gvEmpleados.DataBind();
                }
            }
        }

        protected void rdFecIngreso_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            SqlParameter[] parametros;
            dt.Clear();
            parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@dFec", rdFecIngreso.SelectedDate);

            dt = Class.dbConexion.EjecutarConsulta("Select Anio= dbo.F_CalcEdad(@dFec, Getdate()) ", CommandType.Text, parametros);
            if (dt.Rows.Count > 0)
            {
                lblAnioTrab.Text = dt.Rows[0]["Anio"].ToString();
            }
        }

        protected void rdFecNac_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            SqlParameter[] parametros;
            dt.Clear();
            parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@dFec", rdFecNac.SelectedDate);

            dt = Class.dbConexion.EjecutarConsulta("Select Anio= dbo.F_CalcEdad(@dFec, Getdate()) ", CommandType.Text, parametros);
            if (dt.Rows.Count > 0)
            {
                lblEdad.Text = dt.Rows[0]["Anio"].ToString();
            }
        }
        #endregion
    }
}