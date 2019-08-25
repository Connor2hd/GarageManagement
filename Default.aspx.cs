using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string error = UserManager.LoginUser(Util.SSC(txtEmail.Text), Util.SSC(txtPassword.Text));
            if (error == "Success")
            {
                Response.Redirect(UserManager.GetHomePage(), false);
            }
            else
            {
                lblError.Text = error;
            }
        }
        catch(Exception ex)
        {
            lblError.Text = ex.ToString();
        }
    }
}