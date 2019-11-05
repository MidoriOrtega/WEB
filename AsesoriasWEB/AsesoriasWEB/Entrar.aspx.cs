using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriasWEB
{
  public partial class Inicio : System.Web.UI.Page
  {
    public static SqlConnection conectar()
    {
      SqlConnection con = new SqlConnection("Data Source=112SALAS24;Initial Catalog=usuariosAsesorias;User ID=sa;Password=sqladmin");
      con.Open();
      return con;
    }

    public static Boolean verificaContra(String usuario, String contra)
    {
      Boolean resp = false;
      SqlConnection con = conectar();
      String query = String.Format("select password from usuario where cu = {0}", usuario);
      SqlCommand cmd = new SqlCommand(query, con);
      SqlDataReader drd = cmd.ExecuteReader();
      if (drd.Read())
        resp = contra.Equals(drd.GetString(0));
      return resp;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      lbResp.ForeColor = System.Drawing.Color.Red;
    }

    protected void btRegistra_Click(object sender, EventArgs e)
    {
      if (txUsuario.Text == null || txContra.Text == null || txUsuario.Text.Equals("") || txContra.Text.Equals(""))
        lbResp.Text = "Falta alguno de los datos.";
      else
      {
        if (verificaContra(txUsuario.Text, txContra.Text))
        {
          Session["cu"] = txUsuario.Text;
          Response.Redirect("Inicio.aspx");
        }
        else
          lbResp.Text = "Alguno de los datos es incorrecto.";
      }
    }

    protected void btRegristra_Click(object sender, EventArgs e)
    {
      Response.Redirect("Registrarse.aspx");
    }
  }
}