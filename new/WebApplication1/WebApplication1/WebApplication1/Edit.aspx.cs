using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var email = "";
            if (Session["email-id"] != null)
            {
                email = Session["email-id"].ToString();
            }
            txtEmail.Text = email;

           txtEmail.ReadOnly = true;
            txtUsername.ReadOnly = false;
            txtAddressLine1.ReadOnly = false;
            txtAddressLine2.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtCountry.ReadOnly = false;
            txtState.ReadOnly = false;

           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var email = "";
            if (Session["email-id"] != null)
            {
                email = Session["email-id"].ToString();
            }

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=sample1;Integrated Security=True");
            con.Open();
           
            
            SqlCommand com = new SqlCommand("Select UserId from Authentication where Email = '" + email + "' ", con);
            int uid = Convert.ToInt32(com.ExecuteScalar().ToString());

            SqlCommand com2 = new SqlCommand("Update RegistrationTable set Name='" + txtUsername.Text.ToString() + "' where userId ='" + uid + "' ", con);
            com2.ExecuteNonQuery();

            SqlCommand com3 = new SqlCommand("Update RegistrationTable set AddressLine1='" + txtAddressLine1.Text.ToString() + "' where userId ='" + uid + "' ", con);
            com3.ExecuteNonQuery();

            SqlCommand com4 = new SqlCommand("Update RegistrationTable set AddressLine2='" + txtAddressLine2.Text.ToString() + "' where userId ='" + uid + "' ", con);
            com4.ExecuteNonQuery();

            SqlCommand com5 = new SqlCommand("Update RegistrationTable set Country='" + txtCountry.Text.ToString() + "' where userId ='" + uid + "' ", con);
            com5.ExecuteNonQuery();

            SqlCommand com6 = new SqlCommand("Update RegistrationTable set State='" + txtState.Text.ToString() + "' where userId ='" + uid + "' ", con);
            com6.ExecuteNonQuery();

            SqlCommand com7 = new SqlCommand("Update RegistrationTable set City='" + txtCountry.Text.ToString() + "' where userId ='" + uid + "' ", con);
            com7.ExecuteNonQuery();

            Label1.Visible = true;
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}