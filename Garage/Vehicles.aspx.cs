using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Garage_Vehicles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            LoadData();
            LoadDropdowns();
            Util.FillCustomers(ddlCustomer, true);
        }
    }

    protected void LoadDropdowns()
    {
        string json = "";
        if(ddlYear.Items.Count < 1)
        {
            json = Util.GetJson("https://www.carqueryapi.com/api/0.3/?callback=?&cmd=getYears");
            int min = Convert.ToInt32(json.Substring(26, 4));
            int max = Convert.ToInt32(json.Substring(45, 4));
            while (min < max)
            {
                ddlYear.Items.Add(new ListItem(Util.SSC(min), Util.SSC(min)));
                min++;
            }
        }

        string selectedYear = "2001";
        string selectedMake = "honda";
        string selectedModel = "civic";

        json = Util.GetJson("https://www.carqueryapi.com/api/0.3/?cmd=getMakes&year=" + selectedYear + "&sold_in_us=1");
        Makes makes = Newtonsoft.Json.JsonConvert.DeserializeObject<Makes>(json);
        foreach (Make make in makes.makes)
        {
            ddlMake.Items.Add(new ListItem(make.make_display, make.make_id));
        }

        json = Util.GetJson("https://www.carqueryapi.com/api/0.3/?cmd=getModels&make=" + selectedMake + "&year=" + selectedYear + "&sold_in_us=1");
        Models models = Newtonsoft.Json.JsonConvert.DeserializeObject<Models>(json);
        foreach (Model model in models.models)
        {
            ddlModel.Items.Add(new ListItem(model.model_name, model.model_name));
        }

        json = Util.GetJson("https://www.carqueryapi.com/api/0.3/?cmd=getTrims&make=" + selectedMake + "&year=" + selectedYear + "&model=" + selectedModel);
        Trims trims = Newtonsoft.Json.JsonConvert.DeserializeObject<Trims>(json);
        foreach (Trim trim in trims.trims)
        {
            ddlTrim.Items.Add(new ListItem(trim.model_trim, trim.model_id));
        }

        ddlYear.SelectedValue = "2001";
        ddlMake.SelectedValue = "honda";
        ddlModel.SelectedIndex = 1;
    }

    protected void LoadData()
    {
        string sql = "SELECT * FROM Vehicles as A left join Customers as B on A.customerRowId=B.rowId where A.deleted <> 1";
        DataTable dt = Util.DoQuery(sql, null);
        rptCustomers.DataSource = dt;
        rptCustomers.DataBind();
    }

    protected void FillDropDowns()
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "INSERT INTO Vehicles (vin, make, model, trim, year, color, customerRowId, apiModelId) " +
            "VALUES (@vin, @make, @model, @trim, @year, @color, @customerRowId, @apiModelId)";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@vin", Util.SSC(txtVIN.Text)));
            param.Add(new SqlParameter("@make", Util.SSC(ddlMake.SelectedItem.Text)));
            param.Add(new SqlParameter("@model", Util.SSC(ddlModel.SelectedItem.Text)));
            param.Add(new SqlParameter("@trim", Util.SSC(ddlTrim.SelectedItem.Text)));
            param.Add(new SqlParameter("@year", Util.SSC(ddlYear.SelectedItem.Text)));
            param.Add(new SqlParameter("@color", Util.SSC(txtColor.Text)));
            param.Add(new SqlParameter("@customerRowId", Util.SGC(ddlCustomer.SelectedItem.Value)));
            param.Add(new SqlParameter("@apiModelId", Util.SSC(ddlTrim.SelectedItem.Value)));

            if (Util.DoNonQuery(sql, param) > 0)
            {
                txtVIN.Text = "";
                ddlMake.SelectedIndex = 0;
                ddlModel.SelectedIndex = 0;
                ddlTrim.SelectedIndex = 0;
                ddlYear.SelectedIndex = 0;
                txtColor.Text = "";
                LoadData();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnCustomerSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = "SELECT *, firstName + ' ' + lastName as 'fullName' FROM Customers where firstName + ' ' + lastName like '%' + @fullName + '%'";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@fullName", Util.SSC(txtCustomerSearch.Text)));
            DataTable dt = Util.DoQuery(sql, param);
            ddlCustomer.DataSource = dt;
            ddlCustomer.DataTextField = "fullName";
            ddlCustomer.DataValueField = "rowId";
            ddlCustomer.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnViewVehicle_Click(object sender, EventArgs e)
    {
        Response.Redirect("VehicleDetails.aspx", false);
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMake.Items.Clear();
        ddlModel.Items.Clear();
        ddlTrim.Items.Clear();
        string json = Util.GetJson("https://www.carqueryapi.com/api/0.3/?cmd=getMakes&year=" + Util.SSC(ddlYear.SelectedValue) + "&sold_in_us=1");
        Makes makes = Newtonsoft.Json.JsonConvert.DeserializeObject<Makes>(json);
        foreach (Make make in makes.makes)
        {
            ddlMake.Items.Add(new ListItem(make.make_display, make.make_id));
        }

        json = Util.GetJson("https://www.carqueryapi.com/api/0.3/?cmd=getModels&make=" + Util.SSC(ddlMake.SelectedValue) + "&year=" + Util.SSC(ddlYear.SelectedValue) + "&sold_in_us=1");
        Models models = Newtonsoft.Json.JsonConvert.DeserializeObject<Models>(json);
        foreach (Model model in models.models)
        {
            ddlModel.Items.Add(new ListItem(model.model_name, model.model_name));
        }

        json = Util.GetJson("https://www.carqueryapi.com/api/0.3/?cmd=getTrims&make=" + Util.SSC(ddlMake.SelectedValue) + "&year=" + Util.SSC(ddlYear.SelectedValue) + "&model=" + Util.SSC(ddlModel.SelectedValue));
        Trims trims = Newtonsoft.Json.JsonConvert.DeserializeObject<Trims>(json);
        foreach (Trim trim in trims.trims)
        {
            ddlTrim.Items.Add(new ListItem(trim.model_trim, trim.model_id));
        }
    }

    protected void ddlMake_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlModel.Items.Clear();
        ddlTrim.Items.Clear();
        string json = Util.GetJson("https://www.carqueryapi.com/api/0.3/?cmd=getModels&make=" + Util.SSC(ddlMake.SelectedValue) + "&year=" + Util.SSC(ddlYear.SelectedValue) + "&sold_in_us=1");
        Models models = Newtonsoft.Json.JsonConvert.DeserializeObject<Models>(json);
        foreach (Model model in models.models)
        {
            ddlModel.Items.Add(new ListItem(model.model_name, model.model_name));
        }

        json = Util.GetJson("https://www.carqueryapi.com/api/0.3/?cmd=getTrims&make=" + Util.SSC(ddlMake.SelectedValue) + "&year=" + Util.SSC(ddlYear.SelectedValue) + "&model=" + Util.SSC(ddlModel.SelectedValue));
        Trims trims = Newtonsoft.Json.JsonConvert.DeserializeObject<Trims>(json);
        foreach (Trim trim in trims.trims)
        {
            ddlTrim.Items.Add(new ListItem(trim.model_trim, trim.model_id));
        }
    }

    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTrim.Items.Clear();
        string json = Util.GetJson("https://www.carqueryapi.com/api/0.3/?cmd=getTrims&make=" + Util.SSC(ddlMake.SelectedValue) + "&year=" + Util.SSC(ddlYear.SelectedValue) + "&model=" + Util.SSC(ddlModel.SelectedValue));
        Trims trims = Newtonsoft.Json.JsonConvert.DeserializeObject<Trims>(json);
        foreach (Trim trim in trims.trims)
        {
            ddlTrim.Items.Add(new ListItem(trim.model_trim, trim.model_id));
        }
    }
}