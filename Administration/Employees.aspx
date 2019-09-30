<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employees.aspx.cs" Inherits="Garage_Employees" MasterPageFile="~/garage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <h1 class="dash-title">Workshop</h1>
    <div class="card spur-card">
        <div class="card-header">
            <div class="spur-card-icon">
                <i class="fas fa-table"></i>
            </div>
            <div class="spur-card-title">Employees</div>
        </div>
        <div class="card-body ">
            <table class="table table-hover table-in-card">
                <thead>
                    <tr>
                        <th scope="col">First</th>
                        <th scope="col">Last</th>
                        <th scope="col">Address</th>
                        <th scope="col">City</th>
                        <th scope="col">Province</th>
                        <th scope="col">Country</th>
                        <th scope="col">Postal Code</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rptEmployees">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("firstName") %></td>
                                <td><%# Eval("lastName") %></td>
                                <td><%# Eval("address") %></td>
                                <td><%# Eval("city") %></td>
                                <td><%# Eval("province") %></td>
                                <td><%# Eval("country") %></td>
                                <td><%# Eval("postalCode") %></td>
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
                    <div class="spur-card-title">Add New Employee</div>
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
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="txtEmailAddress">Email Address</label>
                            <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtAddress">Address</label>
                            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"></asp:TextBox>
                        </div>
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
