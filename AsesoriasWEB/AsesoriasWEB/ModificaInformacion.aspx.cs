using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriasWEB
{
  public partial class ModificaInformacion : System.Web.UI.Page
  {
    public SqlConnection conectar()
    {
      SqlConnection con = new SqlConnection("Data Source=112SALAS24;Initial Catalog=usuariosAsesorias;User ID=sa;Password=sqladmin");
      con.Open();
      return con;
    }

    public void llenaCombo(DropDownList cb)
    {
      cb.Items.Add("correo");
      cb.Items.Add("teléfono");
      cb.Items.Add("contraseña");
      cb.SelectedIndex = 0;
    }

    public void llenaCombo2(DropDownList cb)
    {
      cb.Items.Add("Actuaria y Seguros");
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
      cb.SelectedIndex = 0;
    }

    public void llenaCombo4(DropDownList cb)
    {
      SqlConnection con = conectar();
      String query = String.Format("select dia, hora from horario where cu = {0}", Session["cu"].ToString());
      SqlCommand cmd = new SqlCommand(query, con);
      SqlDataReader drd = cmd.ExecuteReader();
      while (drd.Read())
        cb.Items.Add(drd.GetString(0));
      cb.SelectedIndex = 0;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        llenaCombo(dlCambia);
        llenaCombo2(dlDepto);
      }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
      Response.Redirect("Inicio.aspx");
    }

    protected void btCambia_Click(object sender, EventArgs e)
    {

    }

    protected void dlDepto_SelectedIndexChanged(object sender, EventArgs e)
    {
      dlMateria.Items.Clear();
      llenaCombo3(dlMateria);
    }
  }
}