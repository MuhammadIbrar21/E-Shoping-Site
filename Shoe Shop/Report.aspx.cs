using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WinForms;

public partial class Report : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["TheShoeShopDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"] != null)
            {
                bindGrid1();
                bindGrid2();
                bindSale();
            }
            else
            {
                Response.Redirect("Signin.aspx");
            }
        } 
    }

    private void bindSale()
    {
        SqlConnection con = new SqlConnection(CS);
        SqlCommand cmd = new SqlCommand("select sum(case when year(DateOfPurchase) = year(getdate()) and Day(DateOfPurchase) = Day(getdate()) then TotalPaid end) as DailySale,sum(case when year(DateOfPurchase) = year(getdate()) and month(DateOfPurchase) = month(getdate()) then TotalPaid end) as MonthlySale, sum(case when year(DateOfPurchase) = year(getdate()) then TotalPaid end) as YearlySale FROM tblOrders", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        FormView1.DataSource = dt;
        FormView1.DataBind();
        
    }

    private void bindGrid1()
    {

        SqlConnection con = new SqlConnection(CS);
        string qr = "select t1.OrderID,t3.Name,t2.PName,t1.Quantity as QtySell,t4.Quantity as StockOpening,t4.Quantity-t1.Quantity as Available  from tblOrderProducts as t1 inner join tblProducts as t2 on t2.PID=t1.PID inner join tblUsers as t3 on t3.Uid=t1.UserID inner join tblProductSizeQuantity as t4 on t4.PID=t1.PID";
        SqlCommand cmd = new SqlCommand(qr, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    private void bindGrid2()
    {

        SqlConnection con = new SqlConnection(CS);
        string qr = "select  distinct t2.PName,t1.Quantity from tblProductSizeQuantity as t1 inner join tblProducts as t2 on t2.PID=t1.PID";
        SqlCommand cmd = new SqlCommand(qr, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

    //protected void btnLoadReport_Click(object sender, EventArgs e)
    //{
    //    DateTime d = DateTime.Parse(txtLoadReport.Text);
    //    SqlConnection con = new SqlConnection(CS);
    //    SqlCommand cmd = new SqlCommand("select * from tblPurchase where DateofPurchase >= '"+ d.Date +"' ", con);
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet s = new DataSet();
    //    da.Fill(s);

    //    GridView3.DataSource = s;
    //    GridView3.DataBind();
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(CS);
        SqlCommand cmd = new SqlCommand("select * from tblOrders", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet s = new DataSet();
        sda.Fill(s);

        GridView4.DataSource = s;
        GridView4.DataBind();
    }
}