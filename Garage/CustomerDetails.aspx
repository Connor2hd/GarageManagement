<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerDetails.aspx.cs" Inherits="Garage_CustomerDetails" MasterPageFile="~/garage.master" %>
<%@ Register Src="~/Controls/JobTable.ascx" TagPrefix="cdm" TagName="JobTable"  %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <asp:UpdatePanel runat="server" ID="upPersonalInfo" UpdateMode="Conditional">
        <ContentTemplate>
            <h1 class="dash-title"><asp:Label runat="server" ID="lblPageTitle"></asp:Label></h1>
            <div class="card spur-card">
                <div class="card-header">
                    <div class="spur-card-icon">
                        <i class="fas fa-cog"></i>
                    </div>
                    <div class="spur-card-title">
                        Personal Information</div>
                </div>
                <div class="card-body">
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <label for="txtFirst">First Name</label>
                            <asp:TextBox runat="server" ID="txtFirst" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3">
                            <label for="txtLast">Last Name</label>
                            <asp:TextBox runat="server" ID="txtLast" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3">
                            <label for="txtAddress">Address</label>
                            <asp:TextBox runat="server" ID="txtAddress" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3">
                            <label for="txtCity">City</label>
                            <asp:TextBox runat="server" ID="txtCity" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <label for="txtPostalCode">Postal Code</label>
                            <asp:TextBox runat="server" ID="txtPostalCode" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3">
                            <label for="ddlProvince">Province</label>
                            <asp:DropDownList runat="server" ID="ddlProvince" Enabled="false" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-3">
                            <label for="ddlCountry">Country</label>
                            <asp:DropDownList runat="server" ID="ddlCountry" Enabled="false" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <asp:Button runat="server" ID="btnModify" Text="Modify" CssClass="btn btn-primary" OnClick="btnModify_Click" />
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" Visible="false" />
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" Visible="false" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <cdm:JobTable runat="server" id="JobTable" />
    <script src="https://code.jquery.com/jquery-3.4.1.js" integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>
</asp:Content>
