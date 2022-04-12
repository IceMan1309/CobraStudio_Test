using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Text;

namespace DFPC_Examen
{
    public partial class wfOrganizacion : System.Web.UI.Page
    {
        DataTable dtt = new DataTable();
        StringBuilder strSQL = new StringBuilder();
        string codigoJs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTreeView();
                CargaDDL();
            }
        }
        #region "Carga Datos"
        void CargarTreeView()
        {
            string grupo = "", modulo = "";

            TreeNode nodoG = new TreeNode();
            TreeNode nodoM = new TreeNode();


            dtt = Class.dbConexion.EjecutarConsulta("Select * From v_Organizacion Order By 1,3 ", CommandType.Text);

            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                DataRow filaM = dtt.Rows[i];

                if (modulo != filaM[1].ToString())
                {
                    grupo = filaM[3].ToString();
                    nodoG = new TreeNode(grupo, filaM[2].ToString());

                    modulo = filaM[1].ToString();
                    nodoM = new TreeNode(modulo, filaM[0].ToString());

                    nodoG.ChildNodes.Add(new TreeNode(filaM[5].ToString(), filaM[4].ToString(), ""));
                    nodoM.ChildNodes.Add(nodoG);
                    tvOrganizacion.Nodes.Add(nodoM);
                }
                else
                {
                    if (grupo != filaM[3].ToString())
                    {
                        grupo = filaM[3].ToString();
                        nodoG = new TreeNode(grupo, filaM[2].ToString());
                        nodoM.ChildNodes.Add(nodoG);
                    }
                    nodoG.ChildNodes.Add(new TreeNode(filaM[5].ToString(), filaM[4].ToString(), ""));
                }
            }
            dtt.Dispose();
            dtt = null;
        }

        void CargaDDL()
        {
            dtt = Class.dbConexion.EjecutarConsulta("Select * From Habilidades AS e ", CommandType.Text);
            ddlHabilidades.DataTextField = "Descripcion";
            ddlHabilidades.DataValueField = "IdHabilidad";
            ddlHabilidades.DataBind();
        }


        void CargarHabilidades()
        {
            SqlParameter[] parametros;

            parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdEmpleado", string.IsNullOrEmpty(lblIdEmpleado.Text) ? "0" : lblIdEmpleado.Text);
            dtt = Class.dbConexion.EjecutarConsulta("Select IdHabilidad, NombreHabilidad From Empleado_Habilidad AS e Where e.IdEmpleado=@IdEmpleado ", CommandType.Text, parametros);

            


            lstHabilidades.DataSource = dtt;
            lstHabilidades.DataValueField = "IdHabilidad"; //dtt.Rows[0]["IdHabilidad"].ToString();
            lstHabilidades.DataTextField = "NombreHabilidad"; // dtt.Rows[0]["NombreHabilidad"].ToString();
            lstHabilidades.DataBind();
        }

        void AdicionaHabilidad()
        {
            Class.dbConexion.DesFull();
            bool flag = false;
            //txtHabilidad.Text += ddlHabilidades.SelectedItem.Text + ", ";
            strSQL.Append(" Insert into Empleado_Habilidad(IdEmpleado, NombreHabilidad) VALUES ");
            strSQL.Append("(@IdEmpleado, @NombreHabilidad) ");
            SqlParameter[] parametros;

            parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@IdEmpleado", string.IsNullOrEmpty(lblIdEmpleado.Text) ? "0" : lblIdEmpleado.Text);
            parametros[1] = new SqlParameter("@NombreHabilidad", ddlHabilidades.SelectedItem.Text);

            Class.dbConexion.IniciarTransaccion();
            flag = Class.dbConexion.EjecutarOperacion(strSQL.ToString(), CommandType.Text, parametros);
            if (flag == true)
            {
                Class.dbConexion.TerminarTransaccion();
                //CargarHabilidades();
            }
            else
            {
                Class.dbConexion.AbortarTransaccion();
                Class.dbConexion.DesFull();
            }
        }

        #endregion

        protected void ibtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblIdEmpleado.Text))
            {
                AdicionaHabilidad();
                CargarHabilidades();
               
            }
            else
            { codigoJs = "<script language='javascript'>alert('Seleccione Empleado')</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tempJS", codigoJs, false);
            }

            
        }

        protected void tvOrganizacion_SelectedNodeChanged(object sender, EventArgs e)
        {

            lblIdEmpleado.Text = tvOrganizacion.SelectedValue;
            CargarHabilidades();

           
        }
    }
    }
