using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AsesoriasWEB
{
    public partial class Asesorias : System.Web.UI.Page
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

        public void llenaCombo(DropDownList cb)
        {
            cb.Items.Add("Actuaría y Seguros");
            cb.Items.Add("Administración");
            cb.Items.Add("Ciencia Política");
            cb.Items.Add("Computación");
            cb.Items.Add("Contabilidad");
            cb.Items.Add("Economía");
            cb.Items.Add("Estadística");
            cb.Items.Add("Estudios Generales");
            cb.Items.Add("Estudios Internacionales");
            cb.Items.Add("Ingeniería Industrial y Operaciones");
            cb.Items.Add("Lenguas");
            cb.Items.Add("Matemáticas");
            cb.Items.Add("Sistemas Digitales");
            cb.SelectedIndex = 0;
            dlMateria.Items.Clear();
            llenaCombo2(dlMateria);
        }

        public void llenaCombo2(DropDownList cb)
        {
            SqlConnection con = conectar();
            String query = String.Format("select nombre from materia where departamento = '{0}'", dlDepto.SelectedItem.Text);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
            cb.Items.Add(drd.GetString(0));
            if (cb.Items.Count > 0)
            {
                cb.SelectedIndex = 0;
                String idMateria = encuentraIdMateria(dlMateria.SelectedItem.Text);
                dlAsesor.Items.Clear();
                llenaCombo3(dlAsesor, idMateria);
            }
        }

        public void llenaCombo3(DropDownList cb, String idMateria)
        {
            SqlConnection con = conectar();
            int miCu = Int32.Parse(Session["cu"].ToString());
            String query = String.Format("select nombre from usuario, usuario_materia where idMateria = '{0}' and usuario.cu = usuario_materia.cu and usuario.cu != {1}", idMateria, miCu);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
                cb.Items.Add(drd.GetString(0));
            if (cb.Items.Count > 0)
            {
                cb.SelectedIndex = 0;
                int cu = encuentraIdAsesor(dlAsesor.SelectedItem.Text);
                llenaReseniasAsesor(gvResenias, cu);
                llenaCalificacionesAsesor(gvCalif, cu);
            }
        }

        public void llenaCombo4(DropDownList cb)
        {
            for (int i = 1; i <= 31; ++i)
                cb.Items.Add(i+"");
            cb.SelectedIndex = 0;
        }

        public void llenaCombo5(DropDownList cb)
        {
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

        public void llenaCombo6(DropDownList cb)
        {
            cb.Items.Add("Dinero");
            cb.Items.Add("Asesoría por asesoría");
            cb.SelectedIndex = 0;
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

        protected void llenaReseniasAsesor(GridView gv, int cu)
        {
            SqlConnection con = conectar();
            String query = String.Format("select calificacion, nombre, descripcion from reviewUsuario, materia where cuRecibe = {0} and tipo = 'a' and materia.idMateria = reviewUsuario.idMateria", cu);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            gv.DataSource = drd;
            gv.DataBind();
        }

        protected void llenaCalificacionesAsesor(GridView gv, int cu)
        {
            SqlConnection con = conectar();
            String query = String.Format("select nombre, avg(calificacion) as 'Calificación promedio' from reviewUsuario, materia where materia.idMateria = reviewUsuario.idMateria and reviewUsuario.cuRecibe = {0} group by nombre", cu);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            gv.DataSource = drd;
            gv.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenaCombo(dlDepto);
                llenaCombo4(dlDia);
                llenaCombo5(dlMes);
                llenaCombo6(dlModalidad);
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dlDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            dlMateria.Items.Clear();
            dlAsesor.Items.Clear();
            llenaCombo2(dlMateria);
        }

        protected void dlAsesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cu = encuentraIdAsesor(dlAsesor.SelectedItem.Text);
            llenaReseniasAsesor(gvResenias, cu);
            llenaCalificacionesAsesor(gvCalif, cu);
        }

        protected void dlMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            String idMateria = encuentraIdMateria(dlMateria.SelectedItem.Text);
            dlAsesor.Items.Clear();
            llenaCombo3(dlAsesor, idMateria);
        }

        protected void dlDia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btRegresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        public Boolean valida()
        {
            Boolean resp = true;
            if (txHora.Text == null || txHora.Text.Equals("") || txLugar.Text == null || txLugar.Text.Equals(""))
            {
                lbResp.Text = "Hace falta alguno de los datos";
                resp = false;
            }
            int mesAct = Int32.Parse(DateTime.Now.ToString("MM"));
            int diaAct = Int32.Parse(DateTime.Now.ToString("dd"));
            int mes = dlMes.SelectedIndex + 1;
            int dia = Int32.Parse(dlDia.SelectedItem.Text);
            if (mes < mesAct || (mes == mesAct && dia < diaAct))
            {
                lbResp.Text = "No se puede poner una fecha anterior a la de hoy";
                resp = false;
            }
            if (txDescripcion.Text == null)
                txDescripcion.Text = "";
            return resp;
        }

        public int ultimoID()
        {
            SqlConnection con = conectar();
            String query1 = "select count(*) from asesoria";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlDataReader drd1 = cmd1.ExecuteReader();
            drd1.Read();
            if (drd1.GetInt32(0) == 0)
                return 0;
            drd1.Close();
            String query = "select Max(idAsesoria) from asesoria";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            drd.Read();
            return drd.GetInt32(0);
        }

        public String altaAsesoria(String fecha, String hora, String lugar, String modalidad, String estado, int cuAsesor, int cuAsesorado, String idMateria)
        {
            String resp;
            int id = 1 + ultimoID();
            SqlConnection con = conectar();
            String query = String.Format("insert into asesoria values({0},'{1}', '{2}', '{3}', '{4}', '{5}', {6},{7}, '{8}')", id, fecha, hora, lugar, modalidad, estado, cuAsesor, cuAsesorado, idMateria);
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
                resp = "Se ha mandado la petición";
            else
                resp = "No se ha podido concretar la petición";
            con.Close();
            return resp;
        }

        protected int cuentaAsesorias(int cuAsesor, int cuAsesorado)
        {
            SqlConnection con = conectar();
            String query = String.Format("select count(*) from asesoria where cuAsesor = {0} and cuAsesorado = {1}",cuAsesor, cuAsesorado);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            drd.Read();
            return drd.GetInt32(0);
        }

        protected void btAsesoria_Click(object sender, EventArgs e)
        {
            if (valida())
            {
                String fecha = DateTime.Now.ToString("yyyy") + (dlMes.SelectedIndex+1) + dlDia.SelectedItem.Text;
                int cuAsesor = encuentraIdAsesor(dlAsesor.SelectedItem.Text);
                int cuAsesorado = Int32.Parse(Session["cu"].ToString());
                String idMateria = encuentraIdMateria(dlMateria.SelectedItem.Text);
                if (cuentaAsesorias(cuAsesor, cuAsesorado) < 5)
                    lbResp.Text = altaAsesoria(fecha, txHora.Text, txLugar.Text, dlModalidad.SelectedItem.Text, "pa", cuAsesor, cuAsesorado, idMateria);
                else
                    lbResp.Text = "Sólo se puede tener hasta 5 asesorías pendientes con el mismo asesor";
            }
        }

    }
}