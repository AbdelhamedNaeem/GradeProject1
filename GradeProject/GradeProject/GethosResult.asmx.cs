using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace GradeProject
{
    /// <summary>
    /// Summary description for GethosResult
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GethosResult : System.Web.Services.WebService
    {
        public static string constr = @"Data Source=.;Initial Catalog=project;Integrated Security=True";
        //SqlConnection con = new SqlConnection(constr);

        [WebMethod]
        public void getHospitals()
        {

        //    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<hospitals> nearhospitals = new List<hospitals>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("search_hospital", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    hospitals hospital = new hospitals();
                    hospital.hospital_id = Convert.ToInt32(rdr["Id"]);
                    hospital.hospital_name = rdr["Name"].ToString();
                    hospital.hospital_city = rdr["City"].ToString();
                    hospital.hospital_zone = rdr["Zone"].ToString();
                    hospital.hospital_address = rdr["Address"].ToString();
                    hospital.hospital_phone = Convert.ToInt32(rdr["Salary"]);
                    hospital.hospital_link = rdr["Link"].ToString();
                    hospital.hospital_kind = rdr["Kind"].ToString();
                    hospital.hospital_lat = Convert.ToInt32(rdr["lat"]);
                    hospital.hospital_lng = Convert.ToInt32(rdr["long"]);


                    nearhospitals.Add(hospital);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(nearhospitals));
        }
    }
}
