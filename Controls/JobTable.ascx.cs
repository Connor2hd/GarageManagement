using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_JobTable : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["customerId"] = Util.SGC(Request["customerId"]);
        LoadData();
    }

    public void LoadData()
    {
        try
        {
            string sql = "SELECT *, C.firstName as 'employeeFirst', C.lastName as 'employeeLast', B.firstName as 'customerFirst', B.lastName as 'customerLast' " +
                "FROM Jobs as A left join Customers as B on A.customerRowId = B.rowId left join Employees as C on A.employeeRowId = C.rowId left join Vehicles as D on A.vehicleRowId = D.rowId " +
                "WHERE A.deleted <> 1";
            List<SqlParameter> param = new List<SqlParameter>();

            if (Util.SGC(ViewState["customerId"]) != Guid.Empty)
            {
                sql += " AND customerRowId=@customerRowId";
                param.Add(new SqlParameter("@customerRowId", Util.SGC(ViewState["customerId"])));
            }

            DataTable dt = Util.DoQuery(sql, param);
            rptJobs.DataSource = dt;
            rptJobs.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
}