using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search : System.Web.UI.Page
{
    void clear(string msg)
    {
        TextBox1.Text = TextBox2.Text = TextBox3.Text = " ";
        Response.Write("<script>alert('Data "+ msg+"')</script>");
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con;
        SqlDataReader dr = DataManager.GetDataReader("search_hospital", out con, new SqlParameter("@hospital_city", TextBox1.Text)
                                                     , new SqlParameter("@hospital_zone", TextBox2.Text)
                                                     , new SqlParameter("@hospital_kind", TextBox3.Text));
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                Label1.Text = "search results:" + "<br>" + "name:" + dr["hospital_name"].ToString() + "<br>" + "<br>" + "adress:" + dr["hospital_address"].ToString() + "<br>" + "<br>" + "phone:" + dr["hospital_phone"].ToString() + "<br>" + "<br>" + "link" + dr["hospital_link"].ToString();
            }
        }
        else
        {
            clear("not found");
        }

    }
}