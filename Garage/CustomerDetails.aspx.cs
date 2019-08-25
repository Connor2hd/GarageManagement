using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Garage_CustomerDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Util.FillProvinces(ddlProvince, true);
            Util.FillCountries(ddlCountry, true);
            ViewState["customerId"] = Util.SGC(Request["customerId"]);
            LoadData();
        }
    }

    protected void LoadData()
    {
        try
        {
            string sql = "SELECT * FROM Customers where rowId=@rowId";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@rowId", Util.SGC(ViewState["customerId"])));
            DataTable dt = Util.DoQuery(sql, param);

            DataRow dr = dt.Rows[0];

            lblPageTitle.Text = Util.SSC(dr["firstName"] + " " + dr["lastName"]);

            txtFirst.Text = Util.SSC(dr["firstName"]);
            txtLast.Text = Util.SSC(dr["lastName"]);
            txtAddress.Text = Util.SSC(dr["address"]);
            txtCity.Text = Util.SSC(dr["city"]);
            ddlProvince.SelectedValue = Util.SSC(dr["province"]);
            ddlCountry.SelectedValue = Util.SSC(dr["country"]);
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        btnModify.Visible = false;
        btnSave.Visible = true;
        btnCancel.Visible = true;

        txtFirst.Enabled = true;
        txtLast.Enabled = true;
        txtAddress.Enabled = true;
        txtCity.Enabled = true;
        txtPostalCode.Enabled = true;
        ddlProvince.Enabled = true;
        ddlCountry.Enabled = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnModify.Visible = true;
        btnSave.Visible = false;
        btnCancel.Visible = false;

        txtFirst.Enabled = false;
        txtLast.Enabled = false;
        txtAddress.Enabled = false;
        txtCity.Enabled = false;
        txtPostalCode.Enabled = false;
        ddlProvince.Enabled = false;
        ddlCountry.Enabled = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            btnModify.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            txtFirst.Enabled = false;
            txtLast.Enabled = false;
            txtAddress.Enabled = false;
            txtCity.Enabled = false;
            txtPostalCode.Enabled = false;
            ddlProvince.Enabled = false;
            ddlCountry.Enabled = false;

            string sql = "UPDATE Customers SET firstName=@firstName, lastName=@lastName, address=@address, city=@city, " +
                "province=@province, country=@country, postalCode=@postalCode where rowId=@rowId";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@rowId", Util.SGC(ViewState["customerId"])));
            param.Add(new SqlParameter("@firstName", Util.SSC(txtFirst.Text)));
            param.Add(new SqlParameter("@lastName", Util.SSC(txtLast.Text)));
            param.Add(new SqlParameter("@address", Util.SSC(txtAddress.Text)));
            param.Add(new SqlParameter("@city", Util.SSC(txtCity.Text)));
            param.Add(new SqlParameter("@province", Util.SSC(ddlProvince.SelectedValue)));
            param.Add(new SqlParameter("@country", Util.SSC(ddlCountry.SelectedValue)));
            param.Add(new SqlParameter("@postalCode", Util.SSC(txtPostalCode.Text)));

            if (Util.DoNonQuery(sql, param) > 0)
            {
                LoadData();
            }
        }
        catch(Exception ex)
        {

        }
    }
}