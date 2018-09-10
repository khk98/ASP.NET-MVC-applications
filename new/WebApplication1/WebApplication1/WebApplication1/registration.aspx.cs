using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            var connection = "Data Source=.;Initial Catalog=sample1;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            Label1.Visible = false;
            var Query = "Insert INTO RegistrationTable(Name,AddressLine1,AddressLine2,Country,State,City) values ('" + txtUsername.Text+ "','" + txtAddressLine1.Text + "','" + txtAddressLine2.Text + "','" + dropdownCountry.Text + "','" + dropdownState.Text + "','" + dropdownCity.Text + "')";
            SqlCommand cmd = new SqlCommand(Query,con);
            cmd.ExecuteNonQuery();
           
            SqlCommand uid =new SqlCommand("Select top 1 UserId from RegistrationTable order by UserId DESC", con);
            string uid_str = uid.ExecuteScalar().ToString();
            int UID = Convert.ToInt32(uid_str);
            uid.ExecuteNonQuery();
           
            con.Close();
            SqlConnection con1 = new SqlConnection(connection);
            con1.Open();
            var Query1 = "Insert INTO Authentication(userId,Email,Password) values ('" + UID + "','" + txtEmail.Text + "','" + txtPassword.Text + "')";
            SqlCommand cmd3 = new SqlCommand(Query1, con1);
            
            cmd3.ExecuteNonQuery();
            Label1.Visible = true;
            con1.Close();
            Response.Redirect("Login.aspx");
        }
    }
}