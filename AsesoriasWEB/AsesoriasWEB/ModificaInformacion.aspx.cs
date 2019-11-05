using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace AsesoriasWEB
{
    public partial class ModificaInformacion : System.Web.UI.Page
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

        public void llenaCombo(DropDownList cb)
        {
            cb.Items.Add("Correo");
            cb.Items.Add("Teléfono");
            cb.Items.Add("Contraseña");
            cb.SelectedIndex = 0;
        }

        public String modifica(String campo, String nuevo)
        {
            String resp;
            SqlConnection con = conectar();
            String query = String.Format("update usuario set {0} = '{1}' where cu = {2}",campo, nuevo, Session["cu"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
                resp = "Se ha modificado";
            else
                resp = "No se ha podido modificar";
            con.Close();
            return resp;
        }

        public void llenaCombo2(DropDownList cb)
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
        }

        public void llenaCombo3(DropDownList cb)
        {
            SqlConnection con = conectar();
            String query = String.Format("select nombre from materia where departamento = '{0}'", dlDepto.SelectedItem.Text);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
                cb.Items.Add(drd.GetString(0));
            if(cb.Items.Count > 0)
                cb.SelectedIndex = 0;
        }

        public void llenaCombo4(DropDownList cb)
        {
            SqlConnection con = conectar();
            String query = String.Format("select dia, hora from horario where cu = {0}", Session["cu"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
                cb.Items.Add(drd.GetString(0) +" "+drd.GetString(1));
            if (cb.Items.Count > 0)
                cb.SelectedIndex = 0;
        }

        public void llenaCombo5(DropDownList cb)
        {
            SqlConnection con = conectar();
            String query = String.Format("select nombre from materia, usuario_materia where materia.idMateria = usuario_materia.idMateria and usuario_materia.cu = {0}", Session["cu"].ToString());
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
                cb.Items.Add(drd.GetString(0));
            if (cb.Items.Count > 0)
                cb.SelectedIndex = 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenaCombo(dlCambia);
                llenaCombo2(dlDepto);
                llenaCombo4(dlHorario);
                llenaCombo5(dlMisMaterias);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void btCambia_Click(object sender, EventArgs e)
        {
            if (txCambia.Text == null || txCambia.Text.Equals(""))
                lbRespM.Text = "Se debe ingresar el nuevo correo/teléfono/contraseña";
            else
                lbRespM.Text = modifica(dlCambia.SelectedItem.Text, txCambia.Text);
        }

        protected void dlDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            dlMateria.Items.Clear();
            llenaCombo3(dlMateria);
        }

        public String altaMat(int cu, String idMateria)
        {
            String resp;
            SqlConnection con = conectar();
            String query = String.Format("insert into usuario_materia values({0},'{1}')", cu, idMateria);
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
                resp = "Se ha registrado exitosamente";
            else
                resp = "No se ha podido registrar";
            con.Close();
            dlMisMaterias.Items.Clear();
            llenaCombo5(dlMisMaterias);
            return resp;
        }

        public Boolean verificaTabla(int cu, String idMateria)
        {
            SqlConnection con = conectar();
            String query = String.Format("select * from usuario_materia where cu = {0} and idMateria = '{1}'", cu, idMateria);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            return !drd.HasRows;
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

        protected void btAgregar_Click(object sender, EventArgs e)
        {
            int cu = Int32.Parse(Session["cu"].ToString());
            String idMateria = encuentraIdMateria(dlMateria.SelectedItem.Text);
            if (verificaTabla(cu, idMateria))
                lbRespMat.Text = altaMat(cu, idMateria);
            else
                lbRespMat.Text = "Ya tiene ésta materia dada de alta";
        }

        public String bajaMat(int cu, String idMateria)
        {
            String resp;
            SqlConnection con = conectar();
            String query = String.Format("delete from usuario_materia where cu = {0} and idMateria = '{1}' ", cu, idMateria);
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
                resp = "Se ha dado de baja";
            else
                resp = "No se ha podido dar de baja";
            con.Close();
            dlMisMaterias.Items.Clear();
            llenaCombo5(dlMisMaterias);
            return resp;
        }

        protected void btQuitaMat_Click(object sender, EventArgs e)
        {
            int cu = Int32.Parse(Session["cu"].ToString());
            String idMateria = encuentraIdMateria(dlMisMaterias.SelectedItem.Text);
            lbRespMat.Text = bajaMat(cu, idMateria);
        }

        public String quitaHorario(int cu, String dia, String hora)
        {
            String resp;
            SqlConnection con = conectar();
            String query = String.Format("delete from horario where cu = {0} and dia = '{1}' and hora = '{2}' ", cu, dia, hora);
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
                resp = "Se ha dado de baja";
            else
                resp = "No se ha podido dar de baja";
            con.Close();
            dlHorario.Items.Clear();
            llenaCombo4(dlHorario);
            return resp;
        }

        protected void btQuita_Click(object sender, EventArgs e)
        {
            String dia = dlHorario.SelectedItem.Text;
            int primerEspacio = dia.IndexOf(" ");
            String hora = dia.Substring(primerEspacio + 1, dia.Length - primerEspacio-1);
            dia = dia.Substring(0, primerEspacio);
            lbRespH.Text = quitaHorario(Int32.Parse(Session["cu"].ToString()), dia, hora);
        }

        public Boolean verificaHorario(int cu, String dia, String hora)
        {
            SqlConnection con = conectar();
            String query = String.Format("select * from horario where cu = {0} and dia = '{1}' and hora = '{2}' ", cu, dia, hora);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            return !drd.HasRows;
        }

        public String altaHorario(int cu, String dia, String hora)
        {
            String resp;
            SqlConnection con = conectar();
            String query = String.Format("insert into horario values({0},'{1}', '{2}')", cu, dia, hora);
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
                resp = "Se ha registrado exitosamente";
            else
                resp = "No se ha podido registrar";
            con.Close();
            dlHorario.Items.Clear();
            llenaCombo4(dlHorario);
            return resp;
        }

        protected void btAgrega_Click(object sender, EventArgs e)
        {
            if (txDia.Text == null || txDia.Text.Equals("") || txHora.Text == null || txHora.Text.Equals(""))
                lbRespH.Text = "Existe algún dado faltante";
            else
            {
                int cu = Int32.Parse(Session["cu"].ToString());
                String dia = txDia.Text, hora = txHora.Text;
                if (verificaHorario(cu, dia, hora))
                    lbRespH.Text = altaHorario(cu, dia, hora);
                else
                    lbRespH.Text = "Este horario ya se encuentra dado de alta";
            }
        }

        protected void txHora_TextChanged(object sender, EventArgs e)
        {

        }

    }
}