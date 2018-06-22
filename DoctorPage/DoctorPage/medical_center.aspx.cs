using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorPage
{
    public partial class medical_center : System.Web.UI.Page
    {
        public static string constr = @"Data Source=.;Initial Catalog=project;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                addressDropDownList();

            }
        }

        private void addressDropDownList()
        {
            cityname.DataSource = GetData("getCities", null);
            cityname.DataBind();

            ListItem liCity = new ListItem("Select City", "-1");
            cityname.Items.Insert(0, liCity);

            ListItem liZone = new ListItem("Select Zone", "-1");
            zonename.Items.Insert(0, liZone);

            zonename.Enabled = false;

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
        protected void Button1_Click(object sender, EventArgs e)
        {
            string bblat = Page.Request.Form["clat"].ToString();
            string bblng = Page.Request.Form["clng"].ToString();
            Label1.Text = bblat;
            Label2.Text = bblng;
        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("insert_med_cen", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@med_cent_name", SqlDbType.NVarChar).Value = txtname.Text;
            cmd.Parameters.Add("@med_cent_city", SqlDbType.NVarChar).Value = cityname.Text;
            cmd.Parameters.Add("@med_cent_zone", SqlDbType.NVarChar).Value = zonename.Text;
            cmd.Parameters.Add("@med_cent_address", SqlDbType.NVarChar).Value = addresstxt.Text;
            cmd.Parameters.Add("@med_cent_phone", SqlDbType.BigInt).Value = phone.Text;
            cmd.Parameters.Add("@med_cent_link", SqlDbType.NVarChar).Value = link.Text;
            cmd.Parameters.Add("@med_cent_lat", SqlDbType.NVarChar).Value = Label1.Text;
            cmd.Parameters.Add("@med_cent_lng", SqlDbType.NVarChar).Value = Label2.Text;
            int x = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}