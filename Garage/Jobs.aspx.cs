using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Garage_Jobs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            LoadDropdowns();
        }
    }

    protected void LoadDropdowns()
    {
        try
        {
            string sql = "SELECT *, firstName + ' ' + lastName as 'fullName' FROM Customers WHERE deleted <> 1";
            List<SqlParameter> param = new List<SqlParameter>();
            if (Util.SSC(txtCustomerSearch.Text) != "")
            {
                sql += " AND 'fullName' LIKE '%' + @customerName + '%'";
                param.Add(new SqlParameter("@customerName", Util.SSC(txtCustomerSearch.Text)));
            }
            DataTable dt = Util.DoQuery(sql, param);
            ddlCustomer.DataSource = dt;
            ddlCustomer.DataValueField = "rowId";
            ddlCustomer.DataTextField = "fullName";
            ddlCustomer.DataBind();

            sql = "SELECT *, firstName + ' ' + lastName as 'fullName' FROM Employees WHERE DELETED <> 1";
            param = new List<SqlParameter>();
            if (Util.SSC(txtEmployeeSearch.Text) != "")
            {
                sql += " AND 'fullName' LIKE '%' + @employeeName + '%'";
                param.Add(new SqlParameter("@employeeName", Util.SSC(txtEmployeeSearch.Text)));
            }
            dt = Util.DoQuery(sql, null);
            ddlEmployee.DataSource = dt;
            ddlEmployee.DataValueField = "rowId";
            ddlEmployee.DataTextField = "fullName";
            ddlEmployee.DataBind();

            loadVehicles();
        }
        catch (Exception ex)
        {

        }
    }

    protected void loadVehicles()
    {
        try
        {
            string sql = "SELECT *, CAST(year as nvarchar) + ' ' + make + ' ' + model as 'fullName' FROM Vehicles WHERE Deleted <> 1 and customerRowId = @customerRowID";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@customerRowID", Util.SGC(ddlCustomer.SelectedValue)));
            DataTable dt = Util.DoQuery(sql, param);
            ddlVehicle.DataSource = dt;
            ddlVehicle.DataValueField = "rowId";
            ddlVehicle.DataTextField = "fullName";
            ddlVehicle.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnCustomerSearch_Click(object sender, EventArgs e)
    {
        LoadDropdowns();
    }

    protected void btnEmployeeSearch_Click(object sender, EventArgs e)
    {
        LoadDropdowns();
    }

    protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadVehicles();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "INSERT INTO Jobs (vehicleRowId, customerRowId, employeeRowId, description, status) " +
                "VALUES (@vehicleRowId, @customerRowId, @employeeRowId, @description, @status)";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@vehicleRowId", Util.SGC(ddlVehicle.SelectedValue)));
            param.Add(new SqlParameter("@customerRowId", Util.SGC(ddlCustomer.SelectedValue)));
            param.Add(new SqlParameter("@employeeRowId", Util.SGC(ddlEmployee.SelectedValue)));
            param.Add(new SqlParameter("@description", Util.SGC(txtIssueDescription.Text)));
            param.Add(new SqlParameter("@status", "Pending"));

            if (Util.DoNonQuery(sql, param) > 0)
            {
                JobTable.LoadData();
            }
        }
        catch (Exception ex)
        {

        }
    }
}