using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Garage_Employees : System.Web.UI.Page
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
            string sql = "SELECT * FROM Employees where deleted <> 1";
            DataTable dt = Util.DoQuery(sql, null);
            rptEmployees.DataSource = dt;
            rptEmployees.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //Create a record to handle user login
            Guid userId = Guid.NewGuid();
            string sql = "INSERT INTO Users (rowId, email, password, type) VALUES (@rowId, @email, @password, 'employee')";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@rowId", Util.SGC(userId)));
            param.Add(new SqlParameter("@email", Util.SSC(txtEmailAddress.Text)));
            param.Add(new SqlParameter("@password", Util.ConvertSHA512(Util.SSC(System.Web.Security.Membership.GeneratePassword(12, 4)))));

            if (Util.DoNonQuery(sql, param) > 0)
            {
                //Create a record to store employee information
                sql = "INSERT INTO Employees (firstName, lastName, address, city, province, country, postalCode, userId) " +
                "VALUES (@firstName, @lastName, @address, @city, @province, @country, @postalCode, @userId)";

                param = new List<SqlParameter>();
                param.Add(new SqlParameter("@firstName", Util.SSC(txtFirstName.Text)));
                param.Add(new SqlParameter("@lastName", Util.SSC(txtLastName.Text)));
                param.Add(new SqlParameter("@address", Util.SSC(txtAddress.Text)));
                param.Add(new SqlParameter("@city", Util.SSC(txtCity.Text)));
                param.Add(new SqlParameter("@province", Util.SSC(ddlProvince.SelectedValue)));
                param.Add(new SqlParameter("@postalCode", Util.SSC(txtPostalCode.Text)));
                param.Add(new SqlParameter("@country", Util.SSC(ddlCountry.SelectedValue)));
                param.Add(new SqlParameter("@userId", Util.SGC(userId)));

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
        }
        catch (Exception ex)
        {

        }
    }
}