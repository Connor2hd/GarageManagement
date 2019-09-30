<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Jobs.aspx.cs" Inherits="Garage_Jobs" MasterPageFile="~/garage.master" %>

<%@ Register Src="~/Controls/JobTable.ascx" TagPrefix="cdm" TagName="JobTable" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <h1 class="dash-title">Jobs</h1>
    <cdm:JobTable runat="server" ID="JobTable" />
    <div class="row">
        <div class="col-xl-12">
            <div class="card spur-card">
                <div class="card-header">
                    <div class="spur-card-icon">
                        <i class="fas fa-chart-bar"></i>
                    </div>
                    <div class="spur-card-title">New Job</div>
                </div>
                <div class="card-body ">
                    <asp:UpdatePanel runat="server" ID="upDropdowns" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="txtCustomerSearch">Customer</label>
                                    <asp:TextBox runat="server" ID="txtCustomerSearch" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="btnCustomerSearch">Select</label>
                                    <asp:Button runat="server" ID="btnCustomerSearch" Text="Search" CssClass="form-control btn btn-info" OnClick="btnCustomerSearch_Click" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList runat="server" ID="ddlCustomer" CssClass="form-control" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="ddlVehicle">Vehicle</label>
                                <asp:DropDownList runat="server" ID="ddlVehicle" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="txtEmployeeSearch">Employee</label>
                                    <asp:TextBox runat="server" ID="txtEmployeeSearch" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="btnEmployeeSearch">Select</label>
                                    <asp:Button runat="server" ID="btnEmployeeSearch" Text="Search" CssClass="form-control btn btn-info" OnClick="btnEmployeeSearch_Click" />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList runat="server" ID="ddlEmployee" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <label for="txtCustomerSearch">Issue/Description</label>
                        <asp:TextBox runat="server" ID="txtIssueDescription" TextMode="MultiLine" Rows="10" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
