<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="container">
  <br />
  <br />
  <br />

    <div>
        <h1>Sales Reports</h1>
    </div>
    <hr />

    <%-- Crystal Report Start ---%>

    <asp:Button ID="Button1" runat="server" Height="37px" OnClick="Button1_Click" Text="Load Report" Width="94px" />
    <br />
    <asp:GridView ID="GridView4" runat="server">
    </asp:GridView>
    <br />
    <div>

        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />

    </div>

    <%-- Crystal Report End ---%>


    <asp:FormView ID="FormView1" runat="server">
        <ItemTemplate>
    <div class="ReportViewer">
        <span class="ReportDaily"><p><b>DAILY</b></p>Rs.<%# Eval ("DailySale","{0:0,00}") %></span><hr /><span class="ReportMonthly"><p><b>MONTHLY</b></p>Rs.<%# Eval ("MonthlySale","{0:0,00}") %></span><hr /><span class="ReportYearly"><p><b>YEARLY</b></p>Rs.<%# Eval ("YearlySale","{0:0,00}") %></span></div>
            </ItemTemplate>
        </asp:FormView>

        <asp:GridView ID="GridView3" runat="server" CssClass="table table-condensed table-hover" CellPadding="4" ForeColor="#333333" GridLines="None" Height="152px" Width="228px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

    <br />
    <div class="panel panel-primary">
      <div class="panel-heading"><h2>Product Sells Reports</h2>  </div>
      <div class="panel-body">
          <div class="row">
             <div class="col-md-12">
                <div class="">
                    <asp:GridView ID="GridView1" CssClass="table table-condensed table-hover" runat="server" BackColor="White" 
                        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="6" CellSpacing="5">
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                
                </div>
             
             </div>
          </div>
      
      
      </div>
      <div class="panel-footer">
       <div class="panel-heading"><h2> Quantity Start Report</h2>  </div>
      <div class="panel-body">
          <div class="row">
             <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="GridView2" runat="server" CssClass="table table-condensed table-hover">
                    </asp:GridView>
                
                </div>
             
             </div>
          </div>
      
      
      </div>
      
      </div>
    </div>
    
</div>


</asp:Content>

