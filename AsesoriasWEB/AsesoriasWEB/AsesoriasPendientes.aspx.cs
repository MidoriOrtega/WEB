using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriasWEB
{
    public partial class AsesoriasPendientes : System.Web.UI.Page
    {
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

        public String encuentraIdMateria(String nombre)
        {
            SqlConnection con = conectar();
            String query = String.Format("select idMateria from materia where nombre = '{0}'", nombre);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            drd.Read();
            return drd.GetString(0);
        }

        public int encuentraIdAsesor(String nombre)
        {
            SqlConnection con = conectar();
            String query = String.Format("select cu from usuario where nombre = '{0}'", nombre);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            drd.Read();
            return drd.GetInt32(0);
        }

        public void llenaCombo(DropDownList cb, int cuAsesor)
        {
            SqlConnection con = conectar();
            String query = String.Format("select nombre from materia, asesoria where cuAsesor = {0} and estado = 'pa' and materia.idMateria = asesoria.idMateria", cuAsesor);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
                cb.Items.Add(drd.GetString(0));
            if (cb.Items.Count > 0)
            {
                cb.SelectedIndex = 0;
                String idMateria = encuentraIdMateria(dlMateria.SelectedItem.Text);
                llenaCombo2(dlAsesorado,cuAsesor, idMateria);
            }
        }

        public void llenaCombo2(DropDownList cb, int cuAsesor, String idMateria)
        {
            SqlConnection con = conectar();
            String query = String.Format("select nombre from usuario, asesoria where cuAsesor = {0} and estado = 'pa' and idMateria = '{1}' and cuAsesorado = cu", cuAsesor, idMateria);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
                cb.Items.Add(drd.GetString(0));
            if (cb.Items.Count > 0)
            {
                cb.SelectedIndex = 0;
                llenaDatos();
            }
        }

        public void llenaCombo3(DropDownList cb)
        {
            cb.Items.Add("No modificar");
            cb.Items.Add("Enero");
            cb.Items.Add("Febrero");
            cb.Items.Add("Marzo");
            cb.Items.Add("Abril");
            cb.Items.Add("Mayo");
            cb.Items.Add("Junio");
            cb.Items.Add("Julio");
            cb.Items.Add("Agosto");
            cb.Items.Add("Septiembre");
            cb.Items.Add("Octubre");
            cb.Items.Add("Noviembre");
            cb.Items.Add("Diciembre");
            cb.SelectedIndex = 0;
        }

        public void llenaCombo4(DropDownList cb)
        {
            cb.Items.Add("No modificar");
            for (int i = 1; i <= 31; ++i)
                cb.Items.Add(i + "");
            cb.SelectedIndex = 0;
        }

        public void llenaCombo5(DropDownList cb)
        {
            cb.Items.Add("No modificar");
            cb.Items.Add("Dinero");
            cb.Items.Add("Asesoría por asesoría");
            cb.SelectedIndex = 0;
        }

        public void llenaDatos()
        {
            SqlConnection con = conectar();
            String nombre = dlAsesorado.SelectedItem.Text;
            String query = String.Format("select correo, fecha, hora, lugar, modalidad from usuario, asesoria where nombre = '{0}' and estado = 'pa' and cu = cuAsesorado", nombre);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            drd.Read();
            lbCorreo.Text = drd.GetString(0);
            lbFechaPedida.Text = drd.GetDateTime(1).ToString();
            lbHoraProp.Text = drd.GetString(2);
            lbLugarProp.Text = drd.GetString(3);
            lbModalidad.Text = drd.GetString(4);
            drd.Close();

            query = String.Format("select avg(calificacion) from usuario, reviewUsuario where nombre = '{0}' and tipo = 'u' and cu = cuRecibe", nombre);
            cmd = new SqlCommand(query, con);
            drd = cmd.ExecuteReader();
            try
            {
                lbCalif.Text = drd.GetString(0);
            }
            catch (Exception ex)
            {
                lbCalif.Text = "No hay reseñas";
            }
            drd.Close();

            int cuRecibe = encuentraIdAsesor(nombre);
            query = String.Format("select calificacion, nombre, descripcion from reviewUsuario, materia where cuRecibe = {0} and tipo = 'u' and materia.idMateria = reviewUsuario.idMateria", cuRecibe);
            cmd = new SqlCommand(query, con);
            drd = cmd.ExecuteReader();
            gvAsesorado.DataSource = drd;
            gvAsesorado.DataBind();
            drd.Close();
            con.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenaCombo(dlMateria, Int32.Parse(Session["cu"].ToString()));
                llenaCombo3(dlMes);
                llenaCombo4(dlDia);
                llenaCombo5(dlModalidad);
            }
        }

        protected void dlMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            String idMateria = encuentraIdMateria(dlMateria.SelectedItem.Text);
            dlAsesorado.Items.Clear();
            int cuAsesor = Int32.Parse(Session["cu"].ToString());
            llenaCombo2(dlAsesorado, cuAsesor, idMateria);
        }

        protected void dlAsesorado_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenaDatos();
        }

        protected void btRegresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = conectar();
            int cuAsesor = Int32.Parse(Session["cu"].ToString());
            int cuAsesorado = encuentraIdAsesor(dlAsesorado.SelectedItem.Text);
            String query = String.Format("update asesoria set estado = 'ac' where cuAsesor = {0} and cuAsesorado ={1} and  fecha = '{2}' and hora = '{3}'",cuAsesor, cuAsesorado,lbFechaPedida.Text, lbHoraProp.Text );
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
                lbResp.Text = "La solicitud ha sido aceptada";
            else
                lbResp.Text = "No se ha podido aceptar la solicitud";
            llenaCombo(dlMateria, Int32.Parse(Session["cu"].ToString()));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = conectar();
            int cuAsesor = Int32.Parse(Session["cu"].ToString());
            int cuAsesorado = encuentraIdAsesor(dlAsesorado.SelectedItem.Text);
            String query = String.Format("delete from asesoria where cuAsesor = {0} and cuAsesorado ={1} and  fecha = '{2}' and hora = '{3}'", cuAsesor, cuAsesorado, lbFechaPedida.Text, lbHoraProp.Text);
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
                lbResp.Text = "La solicitud ha sido rechazada";
            else
                lbResp.Text = "No se ha podido rechazar la solicitud";
            llenaCombo(dlMateria, Int32.Parse(Session["cu"].ToString()));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = conectar();
            int cuAsesor = Int32.Parse(Session["cu"].ToString());
            int cuAsesorado = encuentraIdAsesor(dlAsesorado.SelectedItem.Text);
            String fecha = (dlDia.SelectedIndex == 0 || dlMes.SelectedIndex == 0)? lbFechaPedida.Text : DateTime.Now.ToString("yyyy") + dlMes.SelectedIndex + dlDia.SelectedItem.Text;
            String hora = (txHora.Text == null || txHora.Text.Equals(""))? lbHoraProp.Text : txHora.Text;
            String lugar = txLugar.Text == null || txLugar.Text.Equals("") ? lbLugarProp.Text : txLugar.Text;
            String modalidad = dlModalidad.SelectedIndex == 0 ? lbModalidad.Text : dlModalidad.SelectedItem.Text;
            String query = String.Format("update asesoria set estado = 'pu', fecha = '{0}', hora = '{1}', lugar = '{2}', modalidad = '{3}'   where cuAsesor = {4} and cuAsesorado ={5} and  fecha = '{6}' and hora = '{7}'", fecha, hora, lugar, modalidad, cuAsesor, cuAsesorado, lbFechaPedida.Text, lbHoraProp.Text); ;
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
                lbResp.Text = "La solicitud ha sido modificada";
            else
                lbResp.Text = "No se ha podido modificar la solicitud";
            llenaCombo(dlMateria, Int32.Parse(Session["cu"].ToString()));
        }

    }
}