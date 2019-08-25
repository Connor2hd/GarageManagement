using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Garage_VehicleDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Page.IsPostBack == false)
        {
            ViewState["modelId"] = Request["modelId"];
            LoadData();
        }
    }

    protected void LoadData()
    {
        try
        {
            string url = "https://www.carqueryapi.com/api/0.3/?cmd=getModel&model=" + Util.SSC(ViewState["modelId"]);
            string json = Util.GetJson(url);
            ExactModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<ExactModel>(json.TrimStart('[').TrimEnd(']'));

            lblPageTitle.Text = Util.SSC(model.make_display + " " + model.model_name + " " + model.model_trim);

            txtEnginePosition.Text = Util.SSC(model.model_engine_position);
            txtEngineCC.Text = Util.SSC(model.model_engine_cc);
            txtEngineCyl.Text = Util.SSC(model.model_engine_cyl);
            txtEngineType.Text = Util.SSC(model.model_engine_type);
            txtEngineValvesPer.Text = Util.SSC(model.model_engine_valves_per_cyl);
            txtEgninePowerPS.Text = Util.SSC(model.model_engine_power_ps);
            txtEnginePowerRPM.Text = Util.SSC(model.model_engine_power_rpm);
            txtEngineTorqueNM.Text = Util.SSC(model.model_engine_torque_nm);
            txtEngineTorqueRPM.Text = Util.SSC(model.model_engine_torque_rpm);
            txtEngineBoreNM.Text = Util.SSC(model.model_engine_bore_mm);
            txtEngineStrokeNM.Text = Util.SSC(model.model_engine_stroke_mm);
            txtEngineCompression.Text = Util.SSC(model.model_engine_compression);
            txtEgnineFuel.Text = Util.SSC(model.model_engine_fuel);
            txtEngineTopSpeed.Text = Util.SSC(model.model_top_speed_kph);
            txtEngineZeroTo.Text = Util.SSC(model.model_0_to_100_kph);
            txtEngineDrive.Text = Util.SSC(model.model_drive);

            txtOtherTransmission.Text = Util.SSC(model.model_transmission_type);
            txtOtherSeats.Text = Util.SSC(model.model_seats);
            txtOtherDoors.Text = Util.SSC(model.model_doors);
            txtOtherWeight.Text = Util.SSC(model.model_weight_kg);
            txtOtherLength.Text = Util.SSC(model.model_length_mm);
            txtOtherWidth.Text = Util.SSC(model.model_width_mm);
            txtOtherHeight.Text = Util.SSC(model.model_height_mm);
            txtOtherWheelbase.Text = Util.SSC(model.model_wheelbase_mm);
            txtOtherHighway.Text = Util.SSC(model.model_lkm_hwy);
            txtOtherMixed.Text = Util.SSC(model.model_lkm_mixed);
            txtOtherCity.Text = Util.SSC(model.model_lkm_city);
            txtOtherFuelCap.Text = Util.SSC(model.model_fuel_cap_l);
        }
        catch(Exception ex)
        {

        }
    }
}