﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GradeProject
{
    public partial class BankSearch : System.Web.UI.Page
    {
        SqlConnection con;
        void clear(string msg)
        {
            Response.Write("<script>alert( '" + msg + "' )</script>");
        }
        private void PopulateContinentsDropDownList()
        {
            DropDownList1.DataSource = SqlDataSource1;
            DropDownList1.DataBind();

            ListItem liCity = new ListItem("Select City", "-1");
            DropDownList1.Items.Insert(0, liCity);

            ListItem liZone = new ListItem("Select Zone", "-1");
            DropDownList2.Items.Insert(0, liZone);

            DropDownList2.Enabled = false;

        }

        protected void zones(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedValue == "-1")
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.Enabled = false;
            }
            else
            {
                DropDownList2.Enabled = true;
                SqlDataReader d = DataManager.GetDataReader("zones_search", out con, new SqlParameter("@city_id", DropDownList1.SelectedValue));
                DropDownList2.DataSource = d;
                DropDownList2.DataBind();
                ListItem liZone = new ListItem("Select Zone", "-1");
                DropDownList2.Items.Insert(0, liZone);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PopulateContinentsDropDownList();
            }
        }
        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlDataReader dr = DataManager.GetDataReader("search_bb", out con, new SqlParameter("@bb_city", DropDownList1.Text)
                                                                      , new SqlParameter("@bb_city", DropDownList1.Text));


            if (dr.HasRows)
            {
                DataList1.DataSource = dr;
                DataList1.DataBind();
            }
            else
            {
                clear("لايوجد بيانات");
            }
            con.Close();
        }
        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {

        }
    }
}