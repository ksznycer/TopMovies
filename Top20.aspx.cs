using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Npgsql;

public partial class Top20 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            connection.Open();

            connection.Close();
        }
    }
}