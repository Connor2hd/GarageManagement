using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Garage_JobDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ViewState["jobId"] = Util.SGC(Request["jobId"]);
            if(Util.SGC(ViewState["jobId"]) == Guid.Empty)
            {
                Response.Redirect("Jobs.aspx");
            }

            if(Page.IsPostBack == false)
            {
                LoadNotes();
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
            string sql = "select B.firstName + ' ' + B.lastName as 'customerName', C.firstName + ' ' + C.lastName as 'employeeName', CAST(D.year as nvarchar) + ' ' + D.make + ' ' + D.model + ' ' + D.trim as 'vehicleName', * from Jobs as A " +
                "left join Customers as B on A.customerRowId=B.rowId " +
                "left join Employees as C on A.employeeRowId=C.rowId " +
                "left join Vehicles as D on A.vehicleRowId=D.rowId " +
                "where A.rowId=@jobId;";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@jobId", ViewState["jobId"]));
            DataTable dt = Util.DoQuery(sql, param);
            DataRow dr = dt.Rows[0];

            txtCustomerName.Text = Util.SSC(dr["customerName"]);
            txtEmployeeName.Text = Util.SSC(dr["employeeName"]);
            txtVehicle.Text = Util.SSC(dr["vehicleName"]);
        }
        catch(Exception ex)
        { 

        }
    }

    protected void LoadNotes()
    {
        try
        {
            string sql = "select C.firstName + ' ' + C.lastName as 'fullName', A.dateCreated as 'dateEntered', * from JobNotes as A " +
                "left join Users as B on A.employeeRowId=B.rowId " +
                "left join Employees as C on A.rowId=C.userId " +
                "where A.jobRowId = @jobId;";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@jobId", ViewState["jobId"]));
            DataTable dt = Util.DoQuery(sql, param);

            rptJobNotes.DataSource = dt;
            rptJobNotes.DataBind();
        }
        catch(Exception ex)
        {

        }
    }

    protected void btnSubmitNewNote_Click(object sender, EventArgs e)
    {
        try
        {
            UserManager user = (UserManager)HttpContext.Current.Session["user"];
            string sql = "insert into JobNotes (jobRowId, employeeRowId, text) values (@jobRowId, @employeeRowId, @text)";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@jobRowId", ViewState["jobId"]));
            param.Add(new SqlParameter("@employeeRowId", user.RowId));
            param.Add(new SqlParameter("@text", txtNewNote.Text.ToString()));

            if(Util.DoNonQuery(sql, param) > 0)
            {
                LoadNotes();
                txtNewNote.Text = "";
            }
        }
        catch (Exception ex)
        {

        }
    }
}