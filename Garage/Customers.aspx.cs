using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Garage_Customers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            LoadData();
            Util.FillProvinces(ddlProvince, true);
            Util.FillCountries(ddlCountry, true);
        }
    }

    protected void LoadData()
    {
        try
        {
            string sql = "SELECT * FROM Customers where deleted <> 1";
            DataTable dt = Util.DoQuery(sql, null);
            rptCustomers.DataSource = dt;
            rptCustomers.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "INSERT INTO Customers (firstName, lastName, address, city, province, country, postalCode) " +
                "VALUES (@firstName, @lastName, @address, @city, @province, @country, @postalCode)";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@firstName", Util.SSC(txtFirstName.Text)));
            param.Add(new SqlParameter("@lastName", Util.SSC(txtLastName.Text)));
            param.Add(new SqlParameter("@address", Util.SSC(txtAddress.Text)));
            param.Add(new SqlParameter("@city", Util.SSC(txtCity.Text)));
            param.Add(new SqlParameter("@province", Util.SSC(ddlProvince.SelectedValue)));
            param.Add(new SqlParameter("@postalCode", Util.SSC(txtPostalCode.Text)));
            param.Add(new SqlParameter("@country", Util.SSC(ddlCountry.SelectedValue)));

            if (Util.DoNonQuery(sql, param) > 0)
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtAddress.Text = "";
                txtCity.Text = "";
                ddlProvince.SelectedValue = "";
                ddlCountry.SelectedValue = "";
                txtPostalCode.Text = "";
                LoadData();
            }
        }
        catch(Exception ex)
        {

        }
    }
}