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
    String chart_select = "SELECT id AS id, title AS title, vote_average AS vote FROM movie ORDER BY vote_average DESC LIMIT 20";
    protected void Page_Load(object sender, EventArgs e)
    {
        connection();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ConfigurationSettings.AppSettings["urlId"] = 
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Newest")
        {
            chart_select = "SELECT id AS id, title AS title, vote_average AS vote FROM movie ORDER BY release_date DESC LIMIT 20";
            connection();
            Button1.Text = "Best";
        }
        else
        {
            chart_select = "SELECT id AS id, title AS title, vote_average AS vote FROM movie ORDER BY vote_average DESC LIMIT 20";
            connection();
            Button1.Text = "Newest";
        }
    }

    void connection()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            connection.Open();

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