using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DataManager
{

    #region Connection String
    public static string constr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString; 
    #endregion



    #region Parameters
    public static SqlParameter CreateParameter(string prm_name, SqlDbType type, object value)
    {
        SqlParameter prm = new SqlParameter(prm_name, type);
        prm.Value = value;
        return prm;
    }


    public static SqlParameter CreateParameter(string prm_name, SqlDbType type, ParameterDirection dir)
    {
        SqlParameter prm = new SqlParameter(prm_name, type);
        prm.Direction = dir;
        return prm;
    } 
    #endregion



    #region Disconnected
    public static DataSet GetDataSet(string stored_name, string table_name, params SqlParameter[] prmarr)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(stored_name, con);
        cmd.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter prm in prmarr)
        {
            cmd.Parameters.Add(prm);
        }
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds, table_name);
        return ds;
    } 
    #endregion



    #region Connected

    public static SqlDataReader GetDataReader(string stored_name, out SqlConnection conout, params SqlParameter[] prmarr)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(stored_name, con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        foreach (SqlParameter prm in prmarr)
        {
            cmd.Parameters.Add(prm);
        }
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        conout = con;
        return dr;

    }

    public static int ExecuteNonQuery(string stored_name, params SqlParameter[] prmarr)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(stored_name, con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        foreach (SqlParameter prm in prmarr)
        {
            cmd.Parameters.Add(prm);
        }
        con.Open();
        int x = cmd.ExecuteNonQuery();
        con.Close();
        return x;
    }

    public static object ExecuteScalar(string stored_name, params SqlParameter[] prmarr)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(stored_name, con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        foreach (SqlParameter prm in prmarr)
        {
            cmd.Parameters.Add(prm);
        }
        con.Open();
        object o = cmd.ExecuteScalar();
        con.Close();
        return o;
    }


    public static Hashtable ExecuteNonQueryOutPut(string stored_name, params SqlParameter[] prmarr)
    {
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand(stored_name, con);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        foreach (SqlParameter prm in prmarr)
        {
            cmd.Parameters.Add(prm);
        }
        con.Open();
        int x = cmd.ExecuteNonQuery();
        Hashtable ht = new Hashtable();
        foreach (SqlParameter prm in prmarr)
        {
            if (prm.Direction == ParameterDirection.Output)
            {
                ht.Add(prm.ParameterName, prm.Value);
            }
        }
        con.Close();
        return ht;
    } 
    #endregion

}

