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
            String best = "SELECT title, vote_average FROM movie LIMIT 20";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(best, connection);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            int d = dt.Rows.Count;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            connection.Close();       
        }

    }
}