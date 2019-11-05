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
      SqlConnection con = new SqlConnection("Data Source=112SALAS24;Initial Catalog=usuariosAsesorias;User ID=sa;Password=sqladmin");
      con.Open();
      return con;
    }

    protected void llenarGridView(GridView gv)
    {
      SqlConnection con = conectar();
      String query = String.Format("select q1.fecha, q1.hora, q1.lugar,q3.nombre as 'Asesor', q2.nombre as 'Materia', q1.modalidad from(select estado, fecha, hora, lugar, modalidad, cuAsesorado from asesoria where cuAsesorado = {0}) as q1, (select nombre, cuAsesorado, hora from materia, asesoria where cuAsesorado = {0} and materia.idMateria = asesoria.idMateria) as q2, (select nombre, cuAsesorado, hora from usuario, asesoria where cuAsesorado = {0} and cuAsesor = cu) as q3 where q1.cuAsesorado = {0} and q2.cuAsesorado = {0} and q3.cuAsesorado = {0} and q1.hora = q2.hora and q3.hora = q2.hora and q1.estado = 'ac'", Session["cu"].ToString());
      SqlCommand cmd = new SqlCommand(query, con);
      SqlDataReader drd = cmd.ExecuteReader();
      gv.DataSource = drd;
      gv.DataBind();
    }

    protected void llenarGridView2(GridView gv)
    {
      SqlConnection con = conectar();
      String query = String.Format("select q1.fecha, q1.hora, q1.lugar,q3.nombre as 'Asesorado', q2.nombre as 'Materia', q1.modalidad from(select estado, fecha, hora, lugar, modalidad, cuAsesor from asesoria where cuAsesor = 181272) as q1, (select nombre, cuAsesor, hora from materia, asesoria where cuAsesor = {0} and materia.idMateria = asesoria.idMateria) as q2, (select nombre, cuAsesor, hora from usuario, asesoria where cuAsesor ={0} and cuAsesorado = cu) as q3 where q1.cuAsesor = {0} and q2.cuAsesor = {0} and q3.cuAsesor = {0} and q1.hora = q2.hora and q3.hora = q2.hora and q1.estado = 'ac'", Session["cu"].ToString());
      SqlCommand cmd = new SqlCommand(query, con);
      SqlDataReader drd = cmd.ExecuteReader();
      gv.DataSource = drd;
      gv.DataBind();
    }

    protected void llenarGridView3(GridView gv)
    {
      SqlConnection con = conectar();
      String query = String.Format("select calificacion, descripcion from review where cuRecibe = {0} and tipo = 'u'", Session["cu"].ToString());
      SqlCommand cmd = new SqlCommand(query, con);
      SqlDataReader drd = cmd.ExecuteReader();
      gv.DataSource = drd;
      gv.DataBind();
    }

    protected void llenarGridView4(GridView gv)
    {
      SqlConnection con = conectar();
      String query = String.Format("select calificacion, descripcion from review where cuRecibe = {0} and tipo = 'u'", Session["cu"].ToString());
      SqlCommand cmd = new SqlCommand(query, con);
      SqlDataReader drd = cmd.ExecuteReader();
      gv.DataSource = drd;
      gv.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      llenarGridView(gvAsesorado);
      llenarGridView2(gvAsesor);
      llenarGridView3(gvRAsesor);
      llenarGridView4(gvRAsesorado);
    }

    protected void btApuntes_Click(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btPide_Click(object sender, EventArgs e)
    {

    }
  }
}