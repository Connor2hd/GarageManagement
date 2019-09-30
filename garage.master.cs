using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Garage_garage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UserManager user = (UserManager)Session["user"];
            if(user == null)
            {
                Response.Redirect("../Default.aspx", false);
            }
        }
        catch(Exception ex)
        {

        }
    }
}
