using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriasWEB
{
    public partial class Inicio1 : System.Web.UI.Page
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

        protected void llenarGridView(GridView gv)
        {
            gv.DataSource = null;
            gv.DataBind();
            SqlConnection con = conectar();
            String query = String.Format("select q1.fecha, q1.hora, q1.lugar,q3.nombre as 'Asesor', q2.nombre as 'Materia', q1.modalidad from(select estado, fecha, hora, lugar, modalidad, cuAsesorado from asesoria where cuAsesorado = {0}) as q1, (select nombre, cuAsesorado, hora, fecha from materia, asesoria where cuAsesorado = {0} and materia.idMateria = asesoria.idMateria) as q2, (select nombre, cuAsesorado, hora, fecha from usuario, asesoria where cuAsesorado = {0} and cuAsesor = cu) as q3 where q1.cuAsesorado = {0} and q2.cuAsesorado = {0} and q3.cuAsesorado = {0} and q1.hora = q2.hora and q3.hora = q2.hora and q1.fecha = q2.fecha and q3.fecha = q2.fecha and q1.estado = 'ac'", Session["cu"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            gv.DataSource = drd;
            gv.DataBind();
        }

        protected void llenarGridView2(GridView gv)
        {
      gv.DataSource = null;
      gv.DataBind();
      SqlConnection con = conectar();
            String query = String.Format("select q1.fecha, q1.hora, q1.lugar,q3.nombre as 'Asesorado', q2.nombre as 'Materia', q1.modalidad from(select estado, fecha, hora, lugar, modalidad, cuAsesor from asesoria where cuAsesor = 181272) as q1, (select nombre, cuAsesor, hora, fecha from materia, asesoria where cuAsesor = {0} and materia.idMateria = asesoria.idMateria) as q2, (select nombre, cuAsesor, hora, fecha from usuario, asesoria where cuAsesor ={0} and cuAsesorado = cu) as q3 where q1.cuAsesor = {0} and q2.cuAsesor = {0} and q3.cuAsesor = {0} and q1.hora = q2.hora and q3.hora = q2.hora and q1.fecha = q2.fecha and q3.fecha = q2.fecha and q1.estado = 'ac'", Session["cu"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            gv.DataSource = drd;
            gv.DataBind();
        }

        protected void llenarGridView3(GridView gv)
        {
      gv.DataSource = null;
      gv.DataBind();
      SqlConnection con = conectar();
            String query = String.Format("select calificacion, nombre, descripcion from reviewUsuario, materia where cuRecibe = {0} and tipo = 'a' and materia.idMateria = reviewUsuario.idMateria", Session["cu"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            gv.DataSource = drd;
            gv.DataBind();
        }

        protected void llenarGridView4(GridView gv)
        {
      gv.DataSource = null;
      gv.DataBind();
      SqlConnection con = conectar();
            String query = String.Format("select calificacion, nombre, descripcion from reviewUsuario, materia where cuRecibe = {0} and tipo = 'u' and materia.idMateria = reviewUsuario.idMateria", Session["cu"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            gv.DataSource = drd;
            gv.DataBind();
        }

        public void escribeReseniasAsesor()
        {
            SqlConnection con = conectar();
            String query = String.Format("select cuAsesorado, idMateria from asesoria where estado = 'ac' and fecha < cast (GETDATE() as DATE) and cuAsesor = {0}", Session["cu"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
            {
                int cuAsesor = Int32.Parse(Session["cu"].ToString());
                int cuAsesorado = drd.GetInt32(0);
                String idMateria = drd.GetString(1);
                String query2 = String.Format("update asesoria set estado = 're' where estado = 'ac' and cuAsesor = {2} and cuAsesorado = {0} and idMateria = '{1}' and fecha < cast (GETDATE() as DATE)", cuAsesorado, idMateria, cuAsesor);
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.ExecuteNonQuery(); 
                Session["tipo"] = 'u';
                Session["cuEscribe"] = cuAsesor;
                Session["cuRecibe"] = cuAsesorado;
                Session["idMateria"] = idMateria;
                drd.Close();
                con.Close();
                Response.Redirect("EscribirResenia.aspx");
            }
            drd.Close();
            con.Close();
        }

        public void escribeReseniasAsesorado()
        {
            SqlConnection con = conectar();
            String query = String.Format("select cuAsesor, idMateria from asesoria where estado = 'ac' and fecha < cast (GETDATE() as DATE) and cuAsesorado = {0}", Session["cu"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            if(drd.Read())
            {
                int cuAsesorado = Int32.Parse(Session["cu"].ToString());
                int cuAsesor = drd.GetInt32(0); 
                String idMateria = drd.GetString(1);
                drd.Close();
                String query2 = String.Format("update asesoria set estado = 're' where estado = 'ac' and cuAsesor = {2} and cuAsesorado = {0} and idMateria = '{1}' and fecha < cast (GETDATE() as DATE)", cuAsesorado,idMateria, cuAsesor) ;
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.ExecuteNonQuery();
                Session["tipo"] = 'a';
                Session["cuEscribe"] = cuAsesorado;
                Session["cuRecibe"] = cuAsesor;
                Session["idMateria"] = idMateria;
                
                con.Close();
                Response.Redirect("EscribirResenia.aspx");
            }
            drd.Close();
            con.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            escribeReseniasAsesor();
            escribeReseniasAsesorado();
            llenarGridView(gvAsesorado);
            llenarGridView2(gvAsesor);
            llenarGridView3(gvRAsesor);
            llenarGridView4(gvRAsesorado);
        }

        protected void btApuntes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Apuntes.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btPide_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asesorias.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaMateria.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificaInformacion.aspx");
        }

        protected void btModificaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificacionesDeAsesorias.aspx");
        }

        protected void btPeticiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsesoriasPendientes.aspx");
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Redirect("Entrar.aspx");
        }
    }
}