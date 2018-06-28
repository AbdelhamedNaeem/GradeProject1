using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GradeProject;
using System.Configuration;


public partial class search : System.Web.UI.Page
{
  
   // public static string constr = @"Data Source=.;Initial Catalog=project;Integrated Security=True";
   // SqlConnection con = new SqlConnection(constr);
     
   //[System.Web.Services.WebMethod]
   // public static hospitals Gethospitalbycity(string h_city, string h_zone, string h_kind)
   //     {
   //         hospitals hospital = new hospitals();
   //         using (SqlConnection con = new SqlConnection(constr))
   //         {
   //             SqlCommand cmd = new SqlCommand("search_hospital", con);
   //             cmd.CommandType = CommandType.StoredProcedure;
   //             cmd.Parameters.Add(new SqlParameter()
   //             {
   //                 ParameterName = "@hospital_city",
   //                 Value = h_city
   //             });
   //             cmd.Parameters.Add(new SqlParameter()
   //             {
   //                 ParameterName = "@hospital_zone",
   //                 Value = h_zone
   //             });
   //             cmd.Parameters.Add(new SqlParameter()
   //             {
   //                 ParameterName = "@hospital_kind",
   //                 Value = h_kind
   //             });

   //             con.Open();
   //             SqlDataReader rdr = cmd.ExecuteReader();
   //             while (rdr.Read())
   //             {
   //                 hospital.hospital_id = Convert.ToInt32(rdr["hospital_id"]);
   //                 hospital.hospital_name = rdr["hospital_name"].ToString();
   //                 hospital.hospital_city = rdr["hospital_city"].ToString();
        
   //                 hospital.hospital_zone = rdr["hospital_zone"].ToString();
   //                 hospital.hospital_address = rdr["hospital_address"].ToString();
   //                 hospital.hospital_phone = Convert.ToInt32(rdr["hospital_phone"]);
   //                 hospital.hospital_link = rdr["hospital_link"].ToString();
   //                 hospital.hospital_kind = rdr["hospital_kind"].ToString();
   //                 hospital.hospital_lat = Convert.ToInt32(rdr["hospital_lat"]);
   //                 hospital.hospital_lng = Convert.ToInt32(rdr["hospital_lng"]);

   //             }
   //         }

   //         return hospital;
        
   // }   
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!this.IsPostBack)
        //{
        //    DataTable dt = this.GetData("select * from hospitals");
        //    Repeater1.DataSource = dt;
        //    Repeater1.DataBind();
        //}
      
    }
    private DataTable GetData(string query)
    {
        string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(conString))
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