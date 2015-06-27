using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Top20 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            //connection.ConnectionString = "Server=ec2-54-217-202-110.eu-west-1.compute.amazonaws.com;Port=5432;User Id=iwzexazhfjxbbt;Password=4JVMJFooosyfdM5Y79Si-c691D;Database=d8u6uelvine6d6;Ssl=true";
            connection.Open();
        }
    }
}