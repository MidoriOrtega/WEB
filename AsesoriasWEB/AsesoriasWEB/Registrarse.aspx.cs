using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriasWEB
{
    public partial class Registrarse : System.Web.UI.Page
    {
        public object Conexion { get; private set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lbResp.ForeColor = System.Drawing.Color.Red;
        }

        public SqlConnection conectar()
        {
            try
            {
                //SqlConnection con = new SqlConnection("Data Source=DESKTOP-285NFBG\\SQLEXPRESS;Initial Catalog=usuariosAsesorias;User ID=sa;Password=sqladmin");
                //SqlConnection con = new SqlConnection("Data Source=112SALAS24;Initial Catalog=usuariosAsesorias;User ID=sa;Password=sqladmin");
                SqlConnection con = new SqlConnection("Server=localhost;Database=usuariosAsesorias; trusted_connection=Yes");
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean valida()
        {
            Boolean resp = true;
            if (txCU.Text == null || txCU.Text.Equals("") ||
                  txCorreo.Text == null || txCorreo.Text.Equals("") ||
                  txContra.Text == null || txContra.Text.Equals("") ||
                  txNombre.Text == null || txNombre.Text.Equals("") ||
                  txTel.Text == null || txTel.Text.Equals(""))
            {
                lbResp.Text = "Hay algún dato faltante";
                resp = false;
            }
            if(txContra.Text.Length < 3)
            {
                lbResp.Text = "La contraseña debe tener al menos 4 caracteres";
                resp = false;
            }
            if (txCU.Text.Length != 6)
            {
                lbResp.Text = "La clave única ingresada no es válida";
                resp = false;
            }
            return resp;
        }

        public Boolean verificaCU(int cu)
        {
            SqlConnection con = conectar();
            String query = String.Format("select cu from usuario where cu = {0}", cu);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            return !drd.HasRows;
        }

        public String alta(int cu, String nombre, String correo, String telefono, String password)
        {
            String resp;
            SqlConnection con = conectar();
            if (verificaCU(cu))
            {
                String query = String.Format("insert into usuario values({0},'{1}', '{2}', '{3}', '{4}')", cu, nombre, correo, telefono, password);
                SqlCommand cmd = new SqlCommand(query, con);
                if (cmd.ExecuteNonQuery() > 0)
                    resp = "Se ha registrado exitosamente";
                else
                    resp = "No se ha podido registrar";
                con.Close();
            }
            else
                resp = "La clave única ya se encuentra dada de alta";
            return resp;
        }

        protected void btAlta_Click(object sender, EventArgs e)
        {
            if (valida())
                lbResp.Text = alta(Int32.Parse(txCU.Text), txNombre.Text, txCorreo.Text, txTel.Text, txContra.Text);
        }

        protected void btRegresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entrar.aspx");
        }
    
    }
}