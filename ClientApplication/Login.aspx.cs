using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ClientApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("select * from userdetails where username=@username and password=@password", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", TextBox1.Text);
                sqlCommand.Parameters.AddWithValue("@password", TextBox2.Text);
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
                sda.Fill(dt);
                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
            }

            if (dt.Rows.Count > 0)
            {
                string email = dt.Rows[0]["emaiID"].ToString();
                Response.Redirect("Default.aspx?username=" + email);
                 
            }
            else
            {
                Label1.Text = "Your username and word is incorrect";
                Label1.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
}