<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfileManager.aspx.cs" Inherits="ProfileManager" MasterPageFile="~/garage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <h1 class="dash-title">Manage User Account</h1>
    <div class="row">
        <div class="col-xl-12">
            <div class="card spur-card">
                <div class="card-header">
                    <div class="spur-card-icon">
                        <i class="fas fa-chart-bar"></i>
                    </div>
                    <div class="spur-card-title">Manage User Account</div>
                </div>
                <div class="card-body ">
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="txtFirstName">First Name</label>
                            <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtLastName">Last Name</label>
                            <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputAddress">Address</label>
                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <label for="txtCity">City</label>
                            <asp:TextBox runat="server" ID="txtCity" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2">
                            <label for="txtPostalCode">Postal Code</label>
                            <asp:TextBox runat="server" ID="txtPostalCode" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <label for="ddlProvince">Province</label>
                            <asp:DropDownList runat="server" ID="ddlProvince" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-2">
                            <label for="ddlCountry">Country</label>
                            <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
