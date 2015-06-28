using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Npgsql;
using System.Data;
using System.Text.RegularExpressions;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        check();
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        check();
    }

    void check()
    {
        GridView1.DataSource = null;
        GridView1.DataBind();

        if (Regex.IsMatch(TextBox1.Text, @"[A-Za-z]+$") && (Regex.IsMatch(TextBox2.Text, @"[0-9]\.[0-9]*$") || Regex.IsMatch(TextBox2.Text, @"[0-9]+$")))
        {
            String text = TextBox1.Text.ToLower();
            char[] text2 = text.ToCharArray();
            int num = Convert.ToInt32(text2[0]) - 32;
            text2[0] = Convert.ToChar(num);
            text = new String(text2);
            TextBox1.Text = text;
            connection();
        }
    }

    void connection()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            connection.Open();
            String search = "SELECT a.title, a.vote_average FROM movie AS a JOIN movie_genre AS b ON a.id = b.movie_id AND b.genre_id IN(SELECT id FROM genre WHERE name = '" + TextBox1.Text + "') AND a.vote_average > " + TextBox2.Text + " GROUP BY a.title, a.vote_average ORDER BY a.vote_average DESC";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(search, connection);
            connection.Close();

            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        check();
    }
}