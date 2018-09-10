using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            var connection = "Data Source=.;Initial Catalog=sample1;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            Label3.Visible = false;
            Label2.Visible = false;

            SqlCommand cmd = new SqlCommand("select COUNT(*)FROM Authentication WHERE Email='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'",con);
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.ExecuteNonQuery();
            if (a > 0)     
            {
                Session["email-id"] = txtUsername.Text;
                Label3.Visible = true;
                Response.Redirect("Profile.aspx");
            }
            else
            {
                Label2.Visible = true;
            }

            con.Close();
           
        }

       
    }
}