using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LEntidad;
using LLog;

namespace DFPC_Examen
{
    public partial class wfAreas : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        private string codigoJs;
        LEntidad.LArea aEntidad = new LArea();
        void btns(bool flag)
        {
            ibtnEdit.Enabled = !flag;
            ibtnBorrar.Enabled = !flag;
            ibtnGuardar.Enabled = !flag;
            ibtnNuevo.Enabled = flag;

        }
        void Habilita(bool flag)
        {
            txtNombre.Enabled = flag;
            txtDescripcion.Enabled = flag;
            
        }

        void CargarGrid()
        {

            dt = LLog.Operaciones.SelecArea();
            gvAreas.DataSource = dt;
            gvAreas.DataBind();
        }

        void Limpia()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Accion"] = "";
                CargarGrid();
                lblID.Text = "";
                btns(true);
                Habilita(false);
                Limpia();

            }
        }

        #region 'Btns'
        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Session["Accion"] = "I";
            btns(true);
            ibtnGuardar.Enabled = true;
            Habilita(true);
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            Session["Accion"] = "U";
            Habilita(true);
            btns(false);
            ibtnGuardar.Enabled = true;
            ibtnBorrar.Enabled = false;
            
        }

        protected void ibtnBorrar_Click(object sender, ImageClickEventArgs e)
        {
            Session["Accion"] = "D";
            btns(false);
            ibtnEdit.Enabled = false;
        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            bool flag = false;
            string accion = Session["Accion"].ToString();
            if (txtNombre.Text.Length > 0)
            {
               
                aEntidad.Accion = accion;
                aEntidad.IdArea = string.IsNullOrEmpty(lblID.Text) ? 0 : Convert.ToInt32(lblID.Text);
                aEntidad.Nombre = txtNombre.Text.Trim().ToUpper();
                aEntidad.Descripcion = txtDescripcion.Text.Trim().ToUpper();
               
                flag = LLog.Operaciones.ManttoAreas(aEntidad);
                if (flag == true)
                {
                                   
                    codigoJs = "<script language='javascript'>alert('Registro Guardado')</script>";
                    CargarGrid();
                    Session["Accion"] = "";
                    Limpia();
                    lblID.Text = "";
                    btns(true);
                    Habilita(false);
                }
                else
                {
                    Class.dbConexion.AbortarTransaccion();
                
                    codigoJs = "<script language='javascript'>alert('Error!! Verifique')</script>";
                }
            }
            else
            { 
                codigoJs = "<script language='javascript'>alert('Ingrese Nombre')</script>";
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tempJS", codigoJs, false);
        }
        #endregion

        protected void gvAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            lblID.Text = gvAreas.SelectedRow.Cells[2].Text;
            txtNombre.Text = gvAreas.SelectedRow.Cells[3].Text;
            txtDescripcion.Text = gvAreas.SelectedRow.Cells[4].Text;
            btns(false);
            ibtnGuardar.Enabled = false;


        }

        
    }
}