using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelExperts
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"] != null && Session["logged"].Equals(true))
            {

            }
            else
            {
                Response.Redirect("AgentLogin.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ProductSupplierID"] = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
            ProductSupplierDB.GetProductSupplierDetailByProductSupplierIdToGridview(int.Parse(Session["ProductSupplierID"].ToString()), GridView1);
        }

        //protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    ProductSupplier pps = new ProductSupplier();
        //    pps.SupplierId = int.Parse(GridView4.Rows[e.RowIndex].Cells[1].Text);
        //    pps.ProductSupplierId = int.Parse(((GridView)sender).Rows[e.RowIndex].Cells[2].Text);

        //    int pkgId;

        //    pkgId = (Session["ProductSupplierID"] == null) ? 1 : int.Parse(Session["ProductSupplierID"].ToString());
        //    if (ProductSupplierDB.DeleteProductSupplier(pps) > 0)
        //        ProductSupplierDB.GetProductSupplierDetailByProductSupplierIdToGridview(pkgId, GridView4);
        //}

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView3_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)//suppliers
        {


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = int.Parse(((DropDownList)sender).SelectedValue);
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supplier s = new Supplier();
            s.SupplierId = int.Parse(GridView3.SelectedRow.Cells[1].Text);
            s.SupName = GridView3.SelectedRow.Cells[2].Text;

            Product p = new Product();
            p.ProductId = int.Parse(DropDownList1.SelectedValue);
            p.ProdName = DropDownList1.SelectedItem.Text;

            // write the info to the supplier-product table
            ProductSupplier ps = new ProductSupplier();
            ps.ProductId = p.ProductId;
            ps.SupplierId = s.SupplierId;
            Data.ProductSupplierDB.AddProductSupplier(ps);

            // reload gridview4;
            //ProductSupplierDB.GetProductSupplierDetailByProductSupplierIdToGridview(prodSupId, GridView4);
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            ProductSupplierDetail psd = new ProductSupplierDetail();
            //psd.ProductSupplierId = int.Parse(GridView1.SelectedRow.Cells[2].Text);

            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ProductSupplierDetail psd = new ProductSupplierDetail();
            //psd.ProductSupplierId = int.Parse(GridView1.SelectedRow.Cells[2].Text);
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/AgentLogin.aspx");
        }
    }
}