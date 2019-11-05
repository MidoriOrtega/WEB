﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsesoriasWEB
{
    public partial class SubirApunte : System.Web.UI.Page
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

        public void llenaDDL(DropDownList ddl)
        {
            ddl.Items.Add("Actuaría y Seguros");
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
            SqlConnection miConexion = conectar();
            if (miConexion != null)
            {
                dlMateria.Items.Clear();
                String query = String.Format("select nombre from materia where departamento='{0}'", dlDepto.SelectedItem.Text);
                SqlCommand cmd = new SqlCommand(query, miConexion);
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                    dlMateria.Items.Add(rd.GetString(0));
                if (dlMateria.Items.Count > 0)
                    dlMateria.SelectedIndex = 0;
                rd.Close();
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
            Response.Redirect("Inicio.aspx");
        }

        public Boolean valida()
        {
            Boolean resp = true;
            if (txURL.Text == null || txURL.Text.Equals("") || txProfesor.Text == null || txProfesor.Text.Equals(""))
            {
                lbResp.Text = "Hay algún dato faltante";
                resp = false;
            }
            return resp;
        }

        public Boolean verificaLink(String url)
        {
            SqlConnection con = conectar();
            String query = String.Format("select url from apunte where url = '{0}'", url);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader drd = cmd.ExecuteReader();
            return !drd.HasRows;
        }

        public String altaNota(String url, String profesor, String idMateria)
        {
            String resp;
            SqlConnection con = conectar();
            String fecha = DateTime.Now.ToString("yyyyMMdd");
            String query = String.Format("insert into apunte values('{0}','{1}','{2}','{3}')", url, profesor, fecha, idMateria);
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

        protected void btSubir_Click(object sender, EventArgs e)
        {
            if (valida())
            {
                if (verificaLink(txURL.Text))
                {
                    String idMateria = encuentraIdMateria(dlMateria.SelectedItem.Text);
                    lbResp.Text = altaNota(txURL.Text, txProfesor.Text, idMateria);
                }
                else
                    lbResp.Text = "El url ya se encuentra dado de alta";
            }
        }

        protected void dlDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenaDDLMat(dlMateria);
        }

  }
}