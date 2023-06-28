using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using appWeb08.Models;
using System.Reflection;

namespace appWeb08.Controllers
{
    public class ConsultasController : Controller
    {
        string cadena = @"server=ab-win-host; database=Negocios2022; integrated security=true";

        IEnumerable<Cliente> clientes()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "eivicorp.database.windows.net";
            builder.UserID = "colbapnauj";
            builder.Password = "_";
            builder.InitialCatalog = "Negocios";

            

            List<Cliente> temporal = new List<Cliente>();

            // SqlConnection cn = new SqlConnection(builder.ConnectionString);
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();

            SqlCommand cmd = new SqlCommand("Select * from tb_clientes", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                temporal.Add(new Cliente()
                {

                    idcliente = dr.GetInt32(0).ToString(),
                    nombrecia = dr.GetString(1),
                    direccion = dr.GetString(2),
                    idpais = dr.GetString(3),
                    fono = dr.GetString(4),
                });
            }
            dr.Close();
            cn.Close();
            return temporal;
        }

        IEnumerable<Cliente> clientes_sp()
        {
            List<Cliente> temporal = new List<Cliente>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("exec usp_clientes", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                temporal.Add(new Cliente()
                {
                    idcliente = dr.GetString(0),
                    nombrecia = dr.GetString(1),
                    direccion = dr.GetString(2),
                    idpais = dr.GetString(3),
                    fono = dr.GetString(4),
                });
            }
            dr.Close();
            cn.Close();
            return temporal;
        }
        
        public ActionResult Listado()
        {
            return View(clientes());
            
        }

        public ActionResult Listado_sp()
        {
            return View(clientes_sp());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}