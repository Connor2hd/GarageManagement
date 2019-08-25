using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblJobMonth.Text = DateTime.Now.ToString("MMMM");
            lblCustomersMonth.Text = DateTime.Now.ToString("MMMM");
            LoadData();
        }
        catch(Exception ex)
        {

        }
    }

    protected void LoadData()
    {
        try
        {
            //Current Jobs
            string sql = "SELECT COUNT(*) as 'count' FROM Jobs WHERE MONTH(dateCreated) = MONTH(GETDATE()) and deleted <> 1";
            DataTable dt = Util.DoQuery(sql, null);
            int currentJobs = Convert.ToInt32(dt.Rows[0]["count"]);
            lblJobCount.Text = Util.SSC(currentJobs);

            //Last Months Jobs
            sql = "SELECT COUNT(*) as 'count' FROM Jobs WHERE MONTH(dateCreated) = (MONTH(GETDATE()) -1) and deleted <> 1";
            dt = Util.DoQuery(sql, null);
            int previousJobs = Convert.ToInt32(dt.Rows[0]["count"]);
            int difference = currentJobs - previousJobs;
            if(difference >= 0)
                lblJobDifference.Text = "+" + Util.SSC(difference);
            else
                lblJobDifference.Text = "-" + Util.SSC(difference);

            //Current Customers
            sql = "SELECT COUNT(*) as 'count' FROM Customers WHERE MONTH(dateCreated) = MONTH(GETDATE()) and deleted <> 1";
            dt = Util.DoQuery(sql, null);
            int currentCustomers = Convert.ToInt32(dt.Rows[0]["count"]);
            lblCustomerCount.Text = Util.SSC(currentCustomers);

            //Last Months Customers
            sql = "SELECT COUNT(*) as 'count' FROM Customers WHERE MONTH(dateCreated) = (MONTH(GETDATE()) -1) and deleted <> 1";
            dt = Util.DoQuery(sql, null);
            int previousCustomers = Convert.ToInt32(dt.Rows[0]["count"]);
            difference = currentCustomers - previousCustomers;
            if (difference >= 0)
                lblCustomerDifference.Text = "+" + Util.SSC(difference);
            else
                lblCustomerDifference.Text = "-" + Util.SSC(difference);
        }
        catch(Exception ex)
        {

        }
    }
}