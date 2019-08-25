using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserManager
/// </summary>
public class UserManager
{
    public Guid RowId { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public bool Deleted { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Type { get; set; }

    public UserManager(Guid rowId, DateTime createdOn, DateTime updatedOn, bool deleted, string email, string password, string type)
    {
        RowId = rowId;
        CreatedOn = createdOn;
        UpdatedOn = updatedOn;
        Deleted = deleted;
        Email = email;
        Password = password;
        Type = type;
    }

    public static string LoginUser(string email, string password)
    {
        try
        {
            string sql = "select * from Users where email=@email";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@email", Util.SSC(email)));
            DataTable dt = Util.DoQuery(sql, param);

            if (dt.Rows.Count > 0)
            {
                string pass1 = Util.ConvertSHA512(password);
                string pass2 = Util.SSC(dt.Rows[0]["password"]);
                if (Util.ConvertSHA512(password) != Util.SSC(dt.Rows[0]["password"]))
                {
                    return "Wrong password.";
                }

                DataRow dr = dt.Rows[0];

                UserManager user = new UserManager(Util.SGC(dr["rowId"]), Util.SDTC(dr["dateCreated"]), Util.SDTC(dr["dateUpdated"]), Util.SBC(dr["deleted"], false), Util.SSC(dr["email"]), Util.SSC(dr["password"]), Util.SSC(dr["type"]));

                HttpContext.Current.Session["user"] = user;

                return "Success";
            }
            else
            {
                return "No account found.";
            }
        }
        catch (Exception ex)
        {
            return "Error occured.";
        }
    }

    public static bool LogoutUser()
    {
        try
        {
            HttpContext.Current.Session["user"] = null;
            HttpContext.Current.Response.Redirect("Default.aspx");
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static string GetHomePage()
    {
        try
        {
            UserManager user = (UserManager)HttpContext.Current.Session["user"];
            if(user == null)
            {
                return "../Default.aspx";
            }

            if(Util.SSC(user.Type) == "customer")
            {
                return "Customer/Customer.aspx";
            }

            if(Util.SSC(user.Type) == "admin")
            {
                return "Dashboard.aspx";
            }

            if (Util.SSC(user.Type) == "employee")
            {
                return "Dashboard.aspx";
            }

            return "Default.aspx";
        }
        catch(Exception ex)
        {
            return "Default.aspx";
        }
    }
}