using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class EditProducts : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["TheShoeShopDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
            PopulateGridview();
        }
    }

    void PopulateGridview()
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tblProducts", con);
            da.Fill(dt);
        }
        gvProduct.DataSource = dt;
        gvProduct.DataBind();
    }

    protected void gvProduct_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvProduct.EditIndex = e.NewEditIndex;
        PopulateGridview();
    }

    protected void gvProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvProduct.EditIndex = -1;
        PopulateGridview();
    }

    protected void gvProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try 
        {
            using(SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                string query = "UPDATE tblProducts SET PName=@PName, PPrice=@PPrice, PSelPrice=@PSelPrice, PDescription=@PDescription, PProductDetails=@PProductDetails , PMaterialCare=@PMaterialCare WHERE PID=@ID";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@PName", (gvProduct.Rows[e.RowIndex].FindControl("txtPName") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@PPrice", (gvProduct.Rows[e.RowIndex].FindControl("txtPPrice") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@PSelPrice", (gvProduct.Rows[e.RowIndex].FindControl("txtPSelPrice") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@PDescription", (gvProduct.Rows[e.RowIndex].FindControl("txtPDescription") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@PProductDetails", (gvProduct.Rows[e.RowIndex].FindControl("txtPProductDetails") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@PMaterialCare", (gvProduct.Rows[e.RowIndex].FindControl("txtPMaterialCare") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@ID",Convert.ToInt32(gvProduct.DataKeys[e.RowIndex].Value.ToString()));
                cmd.ExecuteNonQuery();
                gvProduct.EditIndex = -1;
                PopulateGridview();
                lblSuccessMessage.Text = "Selected Record Updated";
                lblErrorMessage.Text = "";
            }
        
        }
        catch (Exception ex)
        {
            lblSuccessMessage.Text = "";
            lblErrorMessage.Text = ex.Message;
        }
    }
}