using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Util
/// </summary>
public class Util
{
    public Util()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static DataTable DoQuery(string sql, List<SqlParameter> param)
    {
        try
        {
            string connString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                if (param != null)
                {
                    foreach (SqlParameter prm in param)
                    {
                        cmd.Parameters.Add(prm);
                    }
                }

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                da.Dispose();
                return dt;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static int DoNonQuery(string sql, List<SqlParameter> param)
    {
        try
        {
            string connString = "Server=tcp:connor1234.database.windows.net,1433;Initial Catalog=connor;Persist Security Info=False;User ID=connor;Password=Rising!Sun55;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                if (param != null)
                {
                    foreach (SqlParameter prm in param)
                    {
                        cmd.Parameters.Add(prm);
                    }
                }

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows;
            }
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    public static string SSC(object unsafeString)
    {
        try
        {
            if (unsafeString == null)
            {
                return "";
            }

            return unsafeString.ToString().Replace("'", "''");
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public static DateTime SDTC(object unsafeDate)
    {
        try
        {
            DateTime value = new DateTime();
            DateTime.TryParse(unsafeDate.ToString(), out value);
            return value;
        }
        catch (Exception ex)
        {
            return new DateTime();
        }
    }

    public static Guid SGC(object unsafeGuid)
    {
        try
        {
            Guid value = Guid.Empty;
            Guid.TryParse(unsafeGuid.ToString(), out value);
            return value;
        }
        catch (Exception ex)
        {
            return Guid.Empty;
        }
    }

    public static bool SBC(object unsafeBool, bool defaultValue)
    {
        try
        {
            bool value = defaultValue;
            Boolean.TryParse(unsafeBool.ToString(), out value);
            return value;
        }
        catch (Exception ex)
        {
            return defaultValue;
        }
    }

    public static string ConvertSHA512(string input)
    {
        try
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static void FillProvinces(DropDownList ddl, bool addBlank)
    {
        ddl.Items.Clear();

        ddl.Items.Add(new ListItem("Newfoundland and Labrador", "NL"));
        ddl.Items.Add(new ListItem("Prince Edward Island", "PE"));
        ddl.Items.Add(new ListItem("Prince Edward Island", "NS"));
        ddl.Items.Add(new ListItem("New Brunswick", "NB"));
        ddl.Items.Add(new ListItem("Quebec", "QC"));
        ddl.Items.Add(new ListItem("Ontario", "ON"));
        ddl.Items.Add(new ListItem("Manitoba", "MB"));
        ddl.Items.Add(new ListItem("Saskatchewan", "SK"));
        ddl.Items.Add(new ListItem("Alberta", "AB"));
        ddl.Items.Add(new ListItem("British Columbia", "BC"));
        ddl.Items.Add(new ListItem("Yukon", "YT"));
        ddl.Items.Add(new ListItem("Northwest Territories", "NT"));
        ddl.Items.Add(new ListItem("Nunavut", "NU"));

        if(addBlank == true)
        {
            ddl.Items.Add(new ListItem("", ""));
        }
    }

    public static void FillCountries(DropDownList ddl, bool addBlank)
    {
        ddl.Items.Clear();

        ddl.Items.Add(new ListItem("Canada", "Canada"));
        ddl.Items.Add(new ListItem("USA", "USA"));

        if (addBlank == true)
        {
            ddl.Items.Add(new ListItem("", ""));
        }
    }

    public static void FillCustomers(DropDownList ddl, bool addBlank)
    {
        ddl.Items.Clear();

        string sql = "SELECT * FROM Customers WHERE deleted <> 1";
        DataTable dt = Util.DoQuery(sql, null);

        foreach(DataRow dr in dt.Rows)
        {
            ddl.Items.Add(new ListItem(Util.SSC(dr["firstName"]) + " " + Util.SSC(dr["lastName"]), Util.SSC(dr["rowId"])));
        }

        if (addBlank == true)
        {
            ddl.Items.Add(new ListItem("", ""));
        }
    }

    public static string GetJson(string url)
    {
        var client = new RestSharp.RestClient(url);

        var response = client.Execute(new RestSharp.RestRequest());

        return response.Content;
    }
}