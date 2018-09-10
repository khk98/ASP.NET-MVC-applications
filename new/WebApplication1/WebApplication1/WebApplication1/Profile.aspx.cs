using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Connection = "Data Source=.;Initial Catalog=sample1;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            var email ="";
            if(Session["email-id"] != null)
            {
               email = Session["email-id"].ToString();
            }
            

            SqlCommand com = new SqlCommand("Select UserId from Authentication where Email = '"+ email +"' ",con);
             int uid = Convert.ToInt32(com.ExecuteScalar().ToString());
            txtEmail.Text = email;

            SqlCommand com1 = new SqlCommand("Select Name from RegistrationTable where userId ='"+uid+"'",con);
            string name = com1.ExecuteScalar().ToString();
            com1.ExecuteNonQuery();
            txtUsername.Text = name;


            SqlCommand com2 = new SqlCommand("Select  AddressLine1 from RegistrationTable where userId ='"+uid+"'", con);
            string AddressLine1 = com2.ExecuteScalar().ToString();
            com2.ExecuteNonQuery();
            txtAddressLine1.Text = AddressLine1;

            SqlCommand com3 = new SqlCommand("Select AddressLine2 from RegistrationTable where userId = '"+uid+"' ", con);
            string AddressLine2 = com3.ExecuteScalar().ToString();
            com3.ExecuteNonQuery();
            txtAddressLine2.Text = AddressLine2;

            SqlCommand com4 = new SqlCommand("Select Country from RegistrationTable where userId = '"+uid+"' ", con);
            string country = com4.ExecuteScalar().ToString();
            com4.ExecuteNonQuery();
            txtCountry.Text = country;

            SqlCommand com5 = new SqlCommand("Select State from RegistrationTable where userId = '"+uid+"' ", con);
            string state = com5.ExecuteScalar().ToString();
            com5.ExecuteNonQuery();
            txtState.Text = state;

            SqlCommand com6 = new SqlCommand("Select City from RegistrationTable where userId = '"+uid+"' ", con);
            string city = com6.ExecuteScalar().ToString();
            com6.ExecuteNonQuery();
            txtCity.Text = city;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");

            txtEmail.ReadOnly = false;
            txtUsername.ReadOnly = false;
            txtAddressLine1.ReadOnly = false;
            txtAddressLine2.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtCountry.ReadOnly = false;

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=sample1;Integrated Security=True");
            con.Open();
             string mail = txtEmail.Text.ToString();
           
            SqlCommand com = new SqlCommand("Select UserId from Authentication where Email = '" + mail + "' ", con);
            int uid = Convert.ToInt32(com.ExecuteScalar().ToString());

            SqlCommand com1 = new SqlCommand("Update Authentication set Email='" + mail + "' where userId ='"+uid+"' ", con);
            com1.ExecuteNonQuery();

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

            SqlCommand com7 = new SqlCommand("Update RegistrationTable set City='" + txtCity.Text.ToString() + "' where userId ='" + uid + "' ", con);
            com7.ExecuteNonQuery();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["e-mail"] = "";
            Response.Redirect("Login.aspx");
        }
    }
}