using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriasWEB
{
    public partial class EscribirResenia : System.Web.UI.Page
    {
        public SqlConnection conectar()
        {
            try
            {
                //SqlConnection con = new SqlConnection("Data Source=DESKTOP-285NFBG\\SQLEXPRESS;Initial Catalog=usuariosAsesorias;User ID=sa;Password=sqladmin");
                //SqlConnection con = new SqlConnection("Data Source=112SALAS24;Initial Catalog=usuariosAsesorias;User ID=sa;Password=sqladmin");
                SqlConnection con = new SqlConnection("Driver={SQL Server Native Client 11.0};Server=localhost;Database=usuariosAsesorias; trusted_connection=Yes");
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int ultimoIDUsuario()
        {
            SqlConnection con = conectar();
            String query1 = "select count(*) from reviewUsuario";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlDataReader drd1 = cmd1.ExecuteReader();
            drd1.Read();
            if (drd1.GetInt32(0) == 0)
                return 0;
            drd1.Close();
            String query = "select Max(idReview) from reviewUsuario";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            drd.Read();
            return drd.GetInt32(0);
        }

        public int ultimoIDApunte()
        {
            SqlConnection con = conectar();
            String query1 = "select count(*) from reviewApunte";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlDataReader drd1 = cmd1.ExecuteReader();
            drd1.Read();
            if (drd1.GetInt32(0) == 0)
                return 0;
            drd1.Close();
            String query = "select Max(idReview) from reviewApunte";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            drd.Read();
            return drd.GetInt32(0);
        }

        protected String altaNota(int calificacion, String descripcion)
        {
            String resp;
            SqlConnection con = conectar();
            int id = 1 + ultimoIDApunte();
            String query = String.Format("insert into reviewApunte values({0},{1}, '{2}', '{3}')", id, calificacion, descripcion, Session["url"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
                resp = "Se ha registrado exitosamente";
            else
                resp = "No se ha podido registrar";
            con.Close();
            return resp;
        }

        protected String altaRUsuario(int calificacion, String descripcion)
        {
            String resp;
            SqlConnection con = conectar();
            int id = 1 + ultimoIDUsuario();
            String query = String.Format("insert into reviewUsuario values({0},'{1}', {2}, '{3}', {4}, {5}, '{6}')", id, Session["tipo"].ToString(), calificacion, descripcion, Session["cuEscribe"].ToString(), Session["cuRecibe"].ToString(), Session["idMateria"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
                resp = "Se ha registrado exitosamente";
            else
                resp = "No se ha podido registrar";
            con.Close();
            return resp;
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

        public Boolean valida()
        {
            Boolean resp = true;
            if (txCalif.Text == null || txCalif.Text.Equals("") || txDescripcion.Text == null || txDescripcion.Text.Equals(""))
            {
                lbResp.Text = "Hace falta alguno de los datos";
                resp = false;
            }
            return resp;
        }

        protected void btHecho_Click(object sender, EventArgs e)
        {
            int calificacion = Int32.Parse(txCalif.Text);
            String descripcion = txDescripcion.Text;
            if (valida())
            {
                if (Session["tipo"].ToString().ElementAt(0) == 'n')
                    lbResp.Text = altaNota(calificacion, descripcion);
                else
                    lbResp.Text = altaRUsuario(calificacion, descripcion);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

    }
}