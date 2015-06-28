using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Npgsql;
using System.Data;

public partial class Top20 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            connection.Open();
            String chart_select = "SELECT title, vote_average FROM movie LIMIT 20";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(chart_select, connection);
            connection.Close();

            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();               
        }

    }
}