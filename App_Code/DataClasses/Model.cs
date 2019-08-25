using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Model
/// </summary>
public class Model
{
    public string model_name { get; set; }
    public string model_make_id { get; set; }

    public Model(string model_name, string model_make_id)
    {
        this.model_name = model_name;
        this.model_make_id = model_make_id;
    }
}

public class Models
{
    public List<Model> models { get; set; }
}