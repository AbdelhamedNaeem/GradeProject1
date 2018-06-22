using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorPage
{
    public partial class clinic : System.Web.UI.Page
    {
        public static string constr = @"Data Source=.;Initial Catalog=project;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateContinentsDropDownList();
               
            }
        }
        private void PopulateContinentsDropDownList()
        {
            cityname.DataSource = GetData("getCities", null);
            cityname.DataBind();

            ListItem liCity = new ListItem("Select City", "-1");
            cityname.Items.Insert(0, liCity);
           
            ListItem liZone = new ListItem("Select Zone", "-1");
            zonename.Items.Insert(0, liZone);

            zonename.Enabled = false;

            specli.DataSource = GetData("getSpecializations", null);
            specli.DataBind();

            ListItem liSpecial = new ListItem("Select Specialization", "-1");
            specli.Items.Insert(0, liSpecial);
        }

        private DataSet GetData(string SPName, SqlParameter SPParameter)
        {
            //string CS = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
           SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter(SPName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (SPParameter != null)
            {
                da.SelectCommand.Parameters.Add(SPParameter);
            }
            DataSet DS = new DataSet();
            da.Fill(DS);
            return DS;
        }
        protected void cityname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cityname.SelectedValue == "-1")
            {
                zonename.SelectedIndex = 0;
                zonename.Enabled = false;
            }
            else
            {
                zonename.Enabled = true;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@city_id";
                parameter.Value = cityname.SelectedValue;

                zonename.DataSource = GetData("getZonesbycitiesID", parameter);
                zonename.DataBind();

                ListItem liZone = new ListItem("Select Zone", "-1");
                zonename.Items.Insert(0, liZone);
            }
        }
        protected void btn_insert_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert_clinic", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@clinic_name", SqlDbType.NVarChar).Value = txtname.Text;
            cmd.Parameters.Add("@clinic_city ", SqlDbType.NVarChar).Value = cityname.Text;
            cmd.Parameters.Add("@clinic_zone", SqlDbType.NVarChar).Value = zonename.Text;
            cmd.Parameters.Add("@clinic_address", SqlDbType.NVarChar).Value = addresstxt.Text;
            cmd.Parameters.Add("@clinic_phone", SqlDbType.BigInt).Value = phone.Text;
            cmd.Parameters.Add("@clinic_link", SqlDbType.NVarChar).Value = link.Text;
            cmd.Parameters.Add("@doc_spec", SqlDbType.NVarChar).Value = specli.Text;
            cmd.Parameters.Add("@clinic_lat", SqlDbType.NVarChar).Value = Label1.Text; //label1 is th e
            cmd.Parameters.Add("@clinic_long", SqlDbType.NVarChar).Value = Label2.Text;
            int x = cmd.ExecuteNonQuery();
            con.Close();
        }

        //To confirom location 
        protected void Button1_Click(object sender, EventArgs e)
        {
            string cliniclat = Page.Request.Form["clat"].ToString();
            string cliniclng = Page.Request.Form["clng"].ToString();
            Label1.Text = cliniclat;
            Label2.Text = cliniclng;

        }
      

    }
}