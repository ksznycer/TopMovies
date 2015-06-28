using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Npgsql;
using System.Data;

public partial class TopGenre : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            connection.Open();
            String best = "SELECT a.name, COUNT( b.genre_id ) AS percent FROM genre AS a JOIN movie_genre AS b ON a.id = b.genre_id GROUP BY a.name";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(best, connection);
            connection.Close();

            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            Chart1.Series.First().XValueMember = "name";
            Chart1.Series.First().YValueMembers = "percent";
            Chart1.DataSource = dt;
            Chart1.DataBind();
            
        }
    }
    protected void Chart1_Load(object sender, EventArgs e)
    {

    }
}