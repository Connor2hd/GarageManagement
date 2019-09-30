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
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int lastYear;
            int lastMonth;

            if(month == 1)
            {
                lastMonth = 12;
                lastYear = year - 1;
            }
            else
            {
                lastMonth = month - 1;
                lastYear = year;
            }

            //Current Jobs
            string sql = "SELECT COUNT(*) AS 'count' FROM Jobs WHERE MONTH(dateCreated) = " + month.ToString() + " AND YEAR(dateCreated) = " + year.ToString() + " AND deleted <> 1";
            DataTable dt = Util.DoQuery(sql, null);
            int currentJobs = Convert.ToInt32(dt.Rows[0]["count"]);
            lblJobCount.Text = Util.SSC(currentJobs);

            //Last Months Jobs
            sql = "SELECT COUNT(*) AS 'count' FROM Jobs WHERE MONTH(dateCreated) = " + lastMonth.ToString() + " AND YEAR(dateCreated) = " + lastYear.ToString() + " AND deleted <> 1";
            dt = Util.DoQuery(sql, null);
            int previousJobs = Convert.ToInt32(dt.Rows[0]["count"]);
            int difference = currentJobs - previousJobs;
            if(difference >= 0)
                lblJobDifference.Text = "+" + Util.SSC(difference);
            else
                lblJobDifference.Text = "-" + Util.SSC(difference);

            //Current Customers
            sql = "SELECT COUNT(*) AS 'count' FROM Customers WHERE MONTH(dateCreated) = " +  month.ToString() + " AND YEAR(dateCreated) = " + year.ToString() + " AND deleted <> 1";
            dt = Util.DoQuery(sql, null);
            int currentCustomers = Convert.ToInt32(dt.Rows[0]["count"]);
            lblCustomerCount.Text = Util.SSC(currentCustomers);

            //Last Months Customers
            sql = "SELECT COUNT(*) AS 'count' FROM Customers WHERE MONTH(dateCreated) = " + lastMonth.ToString() + " AND YEAR(dateCreated) = " + lastYear.ToString() + " AND deleted <> 1";
            dt = Util.DoQuery(sql, null);
            int previousCustomers = Convert.ToInt32(dt.Rows[0]["count"]);
            difference = currentCustomers - previousCustomers;
            if (difference >= 0)
                lblCustomerDifference.Text = "+" + Util.SSC(difference);
            else
                lblCustomerDifference.Text = "-" + Util.SSC(difference);

            //Current Month Gross revnue
            sql = "SELECT SUM(partsBillable) + SUM(labourBillable) AS 'totalGross' FROM JobBillables WHERE MONTH(dateCreated) = " + month.ToString() + " AND YEAR(dateCreated) = " + year.ToString() + " AND deleted <> 1";
            dt = Util.DoQuery(sql, null);
            decimal currentGross = Util.SDC(dt.Rows[0]["totalGross"]);
            lblGrossRevenue.Text = currentGross.ToString("C");

            //Last Month Gross Revenue
            sql = "SELECT SUM(partsBillable) + SUM(labourBillable) AS 'totalGross' FROM JobBillables WHERE MONTH(dateCreated) = " + lastMonth.ToString() + " AND YEAR(dateCreated) = " + lastYear.ToString() + " AND deleted <> 1";
            dt = Util.DoQuery(sql, null);
            decimal previousGross = Util.SDC(dt.Rows[0]["totalGross"]);

            decimal grossDifference = currentGross - previousGross;
            if(grossDifference >= 0)
                lblGrossRevenueDifference.Text = "+" + grossDifference.ToString("C");
            else
                lblGrossRevenueDifference.Text = "-" + grossDifference.ToString("C");
        }
        catch (Exception ex)
        {

        }
    }
}