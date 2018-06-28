using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GradeProject
{
    public partial class hoptialSearch : System.Web.UI.Page
    {
        public static string constr = @"Data Source=.;Initial Catalog=project;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                DataTable dt = this.GetData("select * from hospitals");
                rpeatmarkers.DataSource = dt;
                rpeatmarkers.DataBind();
            }
        }
        private DataTable GetData(string query)
        {
            //string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}