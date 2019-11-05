using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriasWEB
{
  public partial class AltaMateria : System.Web.UI.Page
  {
    public SqlConnection conectar()
    {
      SqlConnection con = new SqlConnection("Data Source=112SALAS24;Initial Catalog=usuariosAsesorias;User ID=sa;Password=sqladmin");
      con.Open();
      return con;
    }

    public static void llenaCombo(DropDownList cb)
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

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        llenaCombo(dlDepto);
      }
    }

    public Boolean valida()
    {
      Boolean resp = true;
      if (txClave.Text == null || txClave.Text.Equals("") ||
          txNombre.Text == null || txNombre.Text.Equals(""))
      {
        lbResp.Text = "Hace falta alguno de los datos.";
        resp = false;
      }

      return resp;
    }

    public Boolean verificaClave(String clave)
    {
      SqlConnection con = conectar();
      String query = String.Format("select idMateria from materia where idMateria = '{0}'", clave);
      SqlCommand cmd = new SqlCommand(query, con);
      SqlDataReader drd = cmd.ExecuteReader();
      return !drd.HasRows;
    }

    public String alta(String clave, String depto, String nombre)
    {
      String resp;
      SqlConnection con = conectar();
        String query = String.Format("insert into materia values('{0}','{1}', '{2}')", clave, depto, nombre);
        SqlCommand cmd = new SqlCommand(query, con);
        if (cmd.ExecuteNonQuery() > 0)
          resp = "registro exitoso";
        else
          resp = "no se registró";
        con.Close();
      return resp;
    }

    protected void btAlta_Click(object sender, EventArgs e)
    {
      lbResp.Text = txClave.Text;
      if (valida()) {
        if (verificaClave(txClave.Text))
        {
          lbResp.Text = alta(txClave.Text, dlDepto.SelectedItem.Text, txNombre.Text);
        }
        else
          lbResp.Text = "Ya hay una materia con esa clave";
      } else
        lbResp.Text = "Los campos no estan llenos";
    }

    protected void btRegresar_Click(object sender, EventArgs e)
    {
      Response.Redirect("Inicio.aspx");
    }
  }
}