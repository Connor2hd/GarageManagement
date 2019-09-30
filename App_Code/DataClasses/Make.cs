using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Make
/// </summary>
public class Make
{
    public string make_id { get; set; }
    public string make_display { get; set; }
    public string make_is_common { get; set; }
    public string make_country { get; set; }

    public Make(string make_id, string make_display, string make_is_common, string make_country)
    {
        this.make_id = make_id;
        this.make_display = make_display;
        this.make_is_common = make_is_common;
        this.make_country = make_country;
    }
}

public class Makes
{
    public List<Make> makes { get; set; }
}