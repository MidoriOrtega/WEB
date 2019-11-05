using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriasWEB
{
  public partial class Apuntes : System.Web.UI.Page
  {
    public SqlConnection conectarBD()
    {
      SqlConnection con = new SqlConnection("Data Source=DESKTOP-285NFBG\\SQLEXPRESS;Initial Catalog=usuariosAsesorias;User ID=sa;Password=sqladmin");
      //SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=usuariosAsesorias;User ID=sa;Password=sqladmin;");
      con.Open();
      return con;
    }

    public void llenaDDL(DropDownList ddl)
    {
      ddl.Items.Add("Actuaria y Seguros");
      ddl.Items.Add("Administración");
      ddl.Items.Add("Ciencia Política");
      ddl.Items.Add("Computación");
      ddl.Items.Add("Contabilidad");
      ddl.Items.Add("Economía");
      ddl.Items.Add("Estadística");
      ddl.Items.Add("Estudios Generales");
      ddl.Items.Add("Estudios Internacionales");
      ddl.Items.Add("Ingeniería Industrial y Operaciones");
      ddl.Items.Add("Lenguas");
      ddl.Items.Add("Matemáticas");
      ddl.Items.Add("Sistemas Digitales");
      ddl.SelectedIndex = 0;
      llenaDDLMat(dlMateria);
    }

    public void llenaDDLMat(DropDownList ddl)
    {
      SqlConnection miConexion = conectarBD();
      if (miConexion != null)
      {
        dlMateria.Items.Clear();
        String query = String.Format("select nombre from materia where departamento='{0}'",dlDepto.SelectedItem.Text);
        SqlCommand cmd = new SqlCommand(query, miConexion);
        SqlDataReader rd;
        rd = cmd.ExecuteReader();
        while (rd.Read())
          dlMateria.Items.Add(rd.GetString(0));
        if (dlMateria.Items.Count > 0)
        {
          dlMateria.SelectedIndex = 0;
          llenarGVApuntes(gvNotas);
        }
        rd.Close();
      }
      miConexion.Close();
    }

    public void llenarGVApuntes(GridView gv)
    {
      SqlConnection miConexion = conectarBD();
      if (miConexion != null)
      {
        String query = String.Format("select fecha, profesor, url from apunte, materia where materia.idMateria = apunte.idMateria and materia.nombre='{0}'", dlMateria.SelectedItem.Text);
        SqlCommand com = new SqlCommand(query, miConexion);
        SqlDataReader rd = com.ExecuteReader();
        gv.DataSource = rd;
        gv.DataBind();
      }
      miConexion.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
        llenaDDL(dlDepto);
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
      Response.Redirect("SubirApunte.aspx");
    }


    protected void dlDepto_SelectedIndexChanged(object sender, EventArgs e)
    {
      llenaDDLMat(dlMateria);
    }

    protected void dlMateria_SelectedIndexChanged(object sender, EventArgs e)
    {
      llenarGVApuntes(gvNotas);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
      Response.Redirect("Inicio.aspx");
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
      
      if (txLink.Text == null || txLink.Text.Equals(""))
        lbResp.Text = "Por favor, introduce el link de las notas antes de dirigirte a escribir la reseña";
      else
      {
        Session["tipo"] = 'n';
        Session["url"] = txLink.Text;
        Response.Redirect("EscribirResenia.aspx");
      }
    }
  }
}