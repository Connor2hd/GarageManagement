using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfileManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsPostBack == false)
            {
                Util.FillProvinces(ddlProvince, true);
                Util.FillCountries(ddlCountry, true);
                LoadData();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void LoadData()
    {
        try
        {
            UserManager user = (UserManager)HttpContext.Current.Session["user"];
            string sql = "";
            if (Util.SSC(user.Type) == "employee" || Util.SSC(user.Type) == "admin")
            {
                sql = "SELECT * FROM Employees WHERE userId=@userId";
            }
            else if (Util.SSC(user.Type) == "customer")
            {
                sql = "SELECT * FROM Customers WHERE userId=@userId";
            }

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@userId", Util.SGC(user.RowId)));
            DataTable dt = Util.DoQuery(sql, param);

            if (dt.Rows.Count < 1)
            {

            }

            DataRow dr = dt.Rows[0];
            txtFirstName.Text = Util.SSC(dr["firstName"]);
            txtLastName.Text = Util.SSC(dr["lastName"]);
            txtAddress.Text = Util.SSC(dr["address"]);
            txtCity.Text = Util.SSC(dr["city"]);
            txtPostalCode.Text = Util.SSC(dr["postalCode"]);
            ddlProvince.SelectedValue = Util.SSC(dr["province"]);
            ddlCountry.SelectedValue = Util.SSC(dr["country"]);
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            UserManager user = (UserManager)HttpContext.Current.Session["user"];
            string sql = "";
            if (Util.SSC(user.Type) == "employee" || Util.SSC(user.Type) == "admin")
            {
                sql = "UPDATE Employees SET firstName=@firstName, lastName=@lastName, address=@address, city=@city, " +
                    "province=@province, country=@country, postalCode=@postalCode where userId=@userId";
            }
            else if (Util.SSC(user.Type) == "customer")
            {
                sql = "UPDATE Customers SET firstName=@firstName, lastName=@lastName, address=@address, city=@city, " +
                    "province=@province, country=@country, postalCode=@postalCode where userId=@userId";
            }

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@userId", Util.SGC(user.RowId)));
            param.Add(new SqlParameter("@firstName", Util.SSC(txtFirstName.Text)));
            param.Add(new SqlParameter("@lastName", Util.SSC(txtLastName.Text)));
            param.Add(new SqlParameter("@address", Util.SSC(txtAddress.Text)));
            param.Add(new SqlParameter("@city", Util.SSC(txtCity.Text)));
            param.Add(new SqlParameter("@province", Util.SSC(ddlProvince.SelectedValue)));
            param.Add(new SqlParameter("@country", Util.SSC(ddlCountry.SelectedValue)));
            param.Add(new SqlParameter("@postalCode", Util.SSC(txtPostalCode.Text)));

            Util.DoQuery(sql, param);
        }
        catch (Exception ex)
        {

        }
    }
}