<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VehicleDetails.aspx.cs" Inherits="Garage_VehicleDetails" MasterPageFile="~/garage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <h1 class="dash-title"><asp:Label runat="server" ID="lblPageTitle"></asp:Label></h1>
    <div class="card spur-card">
        <div class="card-header">
            <div class="spur-card-icon">
                <i class="fas fa-cog"></i>
            </div>
            <div class="spur-card-title">Engine Specs</div>
        </div>
        <div class="card-body">
            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtEnginePosition">Position</label>
                    <asp:TextBox runat="server" ID="txtEnginePosition" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEngineCC">CCs</label>
                    <asp:TextBox runat="server" ID="txtEngineCC" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEngineCyl">Cylinders</label>
                    <asp:TextBox runat="server" ID="txtEngineCyl" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEngineType">Engine Type</label>
                    <asp:TextBox runat="server" ID="txtEngineType" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtEngineValvesPer">Valves Per Cylinder</label>
                    <asp:TextBox runat="server" ID="txtEngineValvesPer" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEgninePowerPS">Power - PS</label>
                    <asp:TextBox runat="server" ID="txtEgninePowerPS" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEnginePowerRPM">Power - RPM</label>
                    <asp:TextBox runat="server" ID="txtEnginePowerRPM" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEngineTorqueNM">Torque - NM</label>
                    <asp:TextBox runat="server" ID="txtEngineTorqueNM" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtEngineValvesPer">Torque - RPM</label>
                    <asp:TextBox runat="server" ID="txtEngineTorqueRPM" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEgninePowerPS">Bore - NM</label>
                    <asp:TextBox runat="server" ID="txtEngineBoreNM" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEnginePowerRPM">Stroke - NM</label>
                    <asp:TextBox runat="server" ID="txtEngineStrokeNM" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEngineTorqueNM">Compression</label>
                    <asp:TextBox runat="server" ID="txtEngineCompression" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtEngineValvesPer">Fuel</label>
                    <asp:TextBox runat="server" ID="txtEgnineFuel" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEgninePowerPS">Top Speed (KPH)</label>
                    <asp:TextBox runat="server" ID="txtEngineTopSpeed" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEnginePowerRPM">0 To 100 KPH</label>
                    <asp:TextBox runat="server" ID="txtEngineZeroTo" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtEngineTorqueNM">Drive</label>
                    <asp:TextBox runat="server" ID="txtEngineDrive" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <div class="card spur-card">
        <div class="card-header">
            <div class="spur-card-icon">
                <i class="fas fa-car"></i>
            </div>
            <div class="spur-card-title">Other Specs</div>
        </div>
        <div class="card-body">
            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtOtherTransmission">Transmission Type</label>
                    <asp:TextBox runat="server" ID="txtOtherTransmission" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtOtherSeats">Seats</label>
                    <asp:TextBox runat="server" ID="txtOtherSeats" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtOtherDoors">Doors</label>
                    <asp:TextBox runat="server" ID="txtOtherDoors" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtOtherWeight">Weight (KG)</label>
                    <asp:TextBox runat="server" ID="txtOtherWeight" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtOtherLength">Length (MM)</label>
                    <asp:TextBox runat="server" ID="txtOtherLength" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtOtherWidth">Width (MM)</label>
                    <asp:TextBox runat="server" ID="txtOtherWidth" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtOtherHeight">Height (MM)</label>
                    <asp:TextBox runat="server" ID="txtOtherHeight" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtOtherWheelbase">Wheelbase (MM)</label>
                    <asp:TextBox runat="server" ID="txtOtherWheelbase" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtOtherHighway">Fuel Efficiency (Highway)</label>
                    <asp:TextBox runat="server" ID="txtOtherHighway" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtOtherMixed">Fuel Efficiency (Mixed)</label>
                    <asp:TextBox runat="server" ID="txtOtherMixed" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtOtherCity">Fuel Efficiency (City)</label>
                    <asp:TextBox runat="server" ID="txtOtherCity" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtOtherFuelCap">Fuel Cap (L)</label>
                    <asp:TextBox runat="server" ID="txtOtherFuelCap" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.4.1.js" integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>
</asp:Content>
