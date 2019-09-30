<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vehicles.aspx.cs" Inherits="Garage_Vehicles" MasterPageFile="~/garage.master" EnableEventValidation="false" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <h1 class="dash-title">Vehicles</h1>
    <div class="card spur-card">
        <div class="card-header">
            <div class="spur-card-icon">
                <i class="fas fa-table"></i>
            </div>
            <div class="spur-card-title">Vehicles</div>
        </div>
        <div class="card-body">
            <table class="table table-hover table-in-card">
                <thead>
                    <tr>
                        <th scope="col">VIN</th>
                        <th scope="col">Year</th>
                        <th scope="col">Make</th>
                        <th scope="col">Model</th>
                        <th scope="col">Trim</th>
                        <th scope="col">Color</th>
                        <th scope="col">Customer</th>
                        <th scope="col"></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rptCustomers">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("vin") %></th>
                                <td><%# Eval("year") %></td>
                                <td><%# Eval("make") %></td>
                                <td><%# Eval("model") %></td>
                                <td><%# Eval("trim") %></td>
                                <td><%# Eval("color") %></td>
                                <td><%# Eval("firstName") + " " + Eval("lastName") %></td>
                                <td>
                                    <a href='VehicleDetails?modelId=<%# Eval("apiModelId") %>' class="fas fa-eye"></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <div class="row">
        <div class="col-xl-12">
            <div class="card spur-card">
                <div class="card-header">
                    <div class="spur-card-icon">
                        <i class="fas fa-chart-bar"></i>
                    </div>
                    <div class="spur-card-title">Add New Vehicle </div>
                </div>
                <div class="card-body ">
                    <asp:UpdatePanel runat="server" ID="upDropdowns" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="ddlYear">Year</label>
                                    <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control" ClientIDMode="Static" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="ddlMake">Make</label>
                                    <asp:DropDownList runat="server" ID="ddlMake" CssClass="form-control" ClientIDMode="Static" OnSelectedIndexChanged="ddlMake_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="ddlModel">Model</label>
                                    <asp:DropDownList runat="server" ID="ddlModel" CssClass="form-control" ClientIDMode="Static" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="ddlTrim">Trim</label>
                                    <asp:DropDownList runat="server" ID="ddlTrim" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="txtColor">Color</label>
                            <asp:TextBox runat="server" ID="txtColor" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtVIN">VIN</label>
                            <asp:TextBox runat="server" ID="txtVIN" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="txtColor">Customer</label>
                            <asp:TextBox runat="server" ID="txtCustomerSearch" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtVIN">Search</label>
                            <asp:Button runat="server" ID="btnCustomerSearch" Text="Search" CssClass="form-control btn btn-info" OnClick="btnCustomerSearch_Click" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:DropDownList runat="server" ID="ddlCustomer" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" ClientIDMode="Static" />
                </div>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.4.1.js" integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>
</asp:Content>
