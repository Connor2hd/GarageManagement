using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Trim
/// </summary>
public class Trim
{
    public string model_id { get; set; }
    public string model_make_id { get; set; }
    public string model_name { get; set; }
    public string model_trim { get; set; }
    public string model_year { get; set; }
    public string model_body { get; set; }
    public string model_engine_position { get; set; }
    public string model_engine_cc { get; set; }
    public string model_engine_cyl { get; set; }
    public string model_engine_type { get; set; }
    public string model_engine_valves_per_cyl { get; set; }
    public string model_engine_power_ps { get; set; }
    public object model_engine_power_rpm { get; set; }
    public string model_engine_torque_nm { get; set; }
    public object model_engine_torque_rpm { get; set; }
    public object model_engine_bore_mm { get; set; }
    public object model_engine_stroke_mm { get; set; }
    public string model_engine_compression { get; set; }
    public string model_engine_fuel { get; set; }
    public object model_top_speed_kph { get; set; }
    public object model_0_to_100_kph { get; set; }
    public string model_drive { get; set; }
    public string model_transmission_type { get; set; }
    public object model_seats { get; set; }
    public string model_doors { get; set; }
    public string model_weight_kg { get; set; }
    public object model_length_mm { get; set; }
    public object model_width_mm { get; set; }
    public object model_height_mm { get; set; }
    public object model_wheelbase_mm { get; set; }
    public string model_lkm_hwy { get; set; }
    public string model_lkm_mixed { get; set; }
    public string model_lkm_city { get; set; }
    public string model_fuel_cap_l { get; set; }
    public string model_sold_in_us { get; set; }
    public object model_co2 { get; set; }
    public string model_make_display { get; set; }
    public string make_display { get; set; }
    public string make_country { get; set; }

    public Trim(string model_id, string model_make_id, string model_name, string model_trim, string model_year, string model_body, string model_engine_position, string model_engine_cc, string model_engine_cyl, string model_engine_type, string model_engine_valves_per_cyl, string model_engine_power_ps, object model_engine_power_rpm, string model_engine_torque_nm, object model_engine_torque_rpm, object model_engine_bore_mm, object model_engine_stroke_mm, string model_engine_compression, string model_engine_fuel, object model_top_speed_kph, object model_0_to_100_kph, string model_drive, string model_transmission_type, object model_seats, string model_doors, string model_weight_kg, object model_length_mm, object model_width_mm, object model_height_mm, object model_wheelbase_mm, string model_lkm_hwy, string model_lkm_mixed, string model_lkm_city, string model_fuel_cap_l, string model_sold_in_us, object model_co2, string model_make_display, string make_display, string make_country)
    {
        this.model_id = model_id;
        this.model_make_id = model_make_id;
        this.model_name = model_name;
        this.model_trim = model_trim;
        this.model_year = model_year;
        this.model_body = model_body;
        this.model_engine_position = model_engine_position;
        this.model_engine_cc = model_engine_cc;
        this.model_engine_cyl = model_engine_cyl;
        this.model_engine_type = model_engine_type;
        this.model_engine_valves_per_cyl = model_engine_valves_per_cyl;
        this.model_engine_power_ps = model_engine_power_ps;
        this.model_engine_power_rpm = model_engine_power_rpm;
        this.model_engine_torque_nm = model_engine_torque_nm;
        this.model_engine_torque_rpm = model_engine_torque_rpm;
        this.model_engine_bore_mm = model_engine_bore_mm;
        this.model_engine_stroke_mm = model_engine_stroke_mm;
        this.model_engine_compression = model_engine_compression;
        this.model_engine_fuel = model_engine_fuel;
        this.model_top_speed_kph = model_top_speed_kph;
        this.model_0_to_100_kph = model_0_to_100_kph;
        this.model_drive = model_drive;
        this.model_transmission_type = model_transmission_type;
        this.model_seats = model_seats;
        this.model_doors = model_doors;
        this.model_weight_kg = model_weight_kg;
        this.model_length_mm = model_length_mm;
        this.model_width_mm = model_width_mm;
        this.model_height_mm = model_height_mm;
        this.model_wheelbase_mm = model_wheelbase_mm;
        this.model_lkm_hwy = model_lkm_hwy;
        this.model_lkm_mixed = model_lkm_mixed;
        this.model_lkm_city = model_lkm_city;
        this.model_fuel_cap_l = model_fuel_cap_l;
        this.model_sold_in_us = model_sold_in_us;
        this.model_co2 = model_co2;
        this.model_make_display = model_make_display;
        this.make_display = make_display;
        this.make_country = make_country;
    }
}

public class Trims
{
    public List<Trim> trims { get; set; }
}