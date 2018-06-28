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
    public partial class hospital : System.Web.UI.Page
    {
        public static string constr = @"Data Source=.;Initial Catalog=project;Integrated Security=True";
        SqlConnection con = new SqlConnection(constr);
        string lat, lng;
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

            ListItem liCity = new ListItem("إختر المدينة", "-1");
            cityname.Items.Insert(0, liCity);

            ListItem liZone = new ListItem("إختر المنطقة", "-1");
            zonename.Items.Insert(0, liZone);

            zonename.Enabled = false;

            specli.DataSource = GetData("getSpecializations", null);
            specli.DataBind();

            ListItem liSpecial = new ListItem("إختر التخصص", "-1");
            specli.Items.Insert(0, liSpecial);
        }

        private DataSet GetData(string SPName, SqlParameter SPParameter)
        {
           // SqlConnection con = new SqlConnection(constr);
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

                ListItem liZone = new ListItem("اختر المنطقة", "-1");
                zonename.Items.Insert(0, liZone);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string lathospital = Page.Request.Form["lath"].ToString();
            string lnghospital = Page.Request.Form["lngh"].ToString();
            Label1.Visible = false;
            Label2.Visible = false;
            Label1.Text = lathospital;
            Label2.Text = lnghospital;
        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert_pharmacy", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pharm_name", SqlDbType.NVarChar).Value = txtname.Text;
            cmd.Parameters.Add("@pharm_city", SqlDbType.NVarChar).Value = cityname.Text;
            cmd.Parameters.Add("@pharm_zone", SqlDbType.NVarChar).Value = zonename.Text;
            cmd.Parameters.Add("@pharm_address", SqlDbType.NVarChar).Value = addresstxt.Text;
            cmd.Parameters.Add("@pharm_phone", SqlDbType.BigInt).Value = phone.Text;
            cmd.Parameters.Add("@pharm_link", SqlDbType.NVarChar).Value = link.Text;
            cmd.Parameters.Add("@pharm_lat", SqlDbType.NVarChar).Value = Label1.Text;
            cmd.Parameters.Add("@pharm_lng", SqlDbType.NVarChar).Value = Label2.Text;
            int x = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}