<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobDetails.aspx.cs" Inherits="Garage_JobDetails" MasterPageFile="~/garage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <h1 class="dash-title">
        <asp:Label runat="server" ID="lblPageTitle"></asp:Label></h1>
    <div class="card spur-card">
        <div class="card-header">
            <div class="spur-card-icon">
                <i class="fas fa-cog"></i>
            </div>
            <div class="spur-card-title">
                Job Information
            </div>
        </div>
        <div class="card-body">
            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="txtFirst">Customer</label>
                    <asp:TextBox runat="server" ID="txtCustomerName" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtLast">Vehiclee</label>
                    <asp:TextBox runat="server" ID="txtVehicle" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                    <label for="txtAddress">Assigned Employee</label>
                    <asp:TextBox runat="server" ID="txtEmployeeName" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="upJobNotes" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="card spur-card">
                <div class="card-header">
                    <div class="spur-card-icon">
                        <i class="fas fa-table"></i>
                    </div>
                    <div class="spur-card-title">Job Notes</div>
                </div>
                <div class="card-body ">
                    <table class="table table-hover table-in-card">
                        <thead>
                            <tr>
                                <th scope="col">Technician Name</th>
                                <th scope="col">Date Entered</th>
                                <th scope="col">Note</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptJobNotes">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("fullName") %></td>
                                        <td><%# Eval("dateEntered") %></td>
                                        <td><%# Eval("text") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="card spur-card">
                <div class="card-header">
                    <div class="spur-card-icon">
                        <i class="fas fa-table"></i>
                    </div>
                    <div class="spur-card-title">New Note</div>
                </div>
                <div class="card-body">
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <label for="txtFirst">New Note</label>
                            <asp:TextBox runat="server" ID="txtNewNote" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button runat="server" ID="btnSubmitNewNote" Text="Submit" OnClick="btnSubmitNewNote_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="https://code.jquery.com/jquery-3.4.1.js" integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>
</asp:Content>
