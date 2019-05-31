<%@ Control Language="C#" AutoEventWireup="true" CodeFile="JobTable.ascx.cs" Inherits="Controls_JobTable" %>
    <div class="card spur-card">
        <div class="card-header">
            <div class="spur-card-icon">
                <i class="fas fa-table"></i>
            </div>
            <div class="spur-card-title">Jobs</div>
        </div>
        <div class="card-body ">
            <table class="table table-hover table-in-card">
                <thead>
                    <tr>
                        <th scope="col">Customer</th>
                        <th scope="col">Year</th>
                        <th scope="col">Make</th>
                        <th scope="col">Model</th>
                        <th scope="col">Color</th>
                        <th scope="col">VIN</th>
                        <th scope="col">Assigned Employee</th>
                        <th scope="col">Status</th>
                        <th scope="col"></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="rptJobs">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("customerFirst") + " " + Eval("customerLast") %></th>
                                <td><%# Eval("year") %></td>
                                <td><%# Eval("make") %></td>
                                <td><%# Eval("model") %></td>
                                <td><%# Eval("color") %></td>
                                <td><%# Eval("vin") %></td>
                                <td><%# Eval("employeeFirst") + " " + Eval("employeeLast") %></td>
                                <td><%# Eval("status") %></td>
                                <td>
                                    <a href='JobDetails?jobId=<%# Eval("rowId") %>' class="fas fa-eye"></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>