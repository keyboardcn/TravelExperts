using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TravelExperts
{
    public partial class agentLogged : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Logged"] != null && Session["logged"].Equals(true))
            {


                int pkgId = 1;

                pkgId = (Session["PackageID"] == null) ? 1 : int.Parse(Session["PackageID"].ToString());
                PackageProductSupplierDB.GetPackageProductSupplierDetailByPackageIdToGridview(pkgId, GridView4);
            } else
            {
                Response.Redirect("AgentLogin.aspx");
            }
        }

        // package gridview
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["PackageID"] = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
            PackageProductSupplierDB.GetPackageProductSupplierDetailByPackageIdToGridview(int.Parse(Session["PackageID"].ToString()), GridView4);

        }

        // ProductSupplier gridview
        //protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["ProductSupplierID"] = ((GridView)sender).SelectedRow.Cells[1].Text;
        //    if (Session["ProductSupplierID"] == null || Session["PackageID"] == null) return;

        //    PackageProductSupplier pps = new PackageProductSupplier();
        //    pps.PackageId = int.Parse(Session["PackageID"].ToString());
        //    pps.ProductSupplierId=int.Parse(Session["ProductSupplierID"].ToString());
        //    PackageProductSupplierDB.AddPackageProductSupplier(pps);
        //    GridView2.DataBind(); // package-product-supplier GridView
        //}

        protected void GridView3_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["ProductSupplierID"] = ((GridView)sender).SelectedRow.Cells[1].Text;
            if (Session["ProductSupplierID"] == null || Session["PackageID"] == null) return;

            PackageProductSupplier pps = new PackageProductSupplier();
            pps.PackageId = int.Parse(Session["PackageID"].ToString());
            pps.ProductSupplierId = int.Parse(Session["ProductSupplierID"].ToString());
            PackageProductSupplierDB.AddPackageProductSupplier(pps);

            int pkgId = 1;

            pkgId = (Session["PackageID"] == null) ? 1 : int.Parse(Session["PackageID"].ToString());
            PackageProductSupplierDB.GetPackageProductSupplierDetailByPackageIdToGridview(pkgId, GridView4);
        }


        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            PackageProductSupplier pps = new PackageProductSupplier();
            pps.PackageId = int.Parse(GridView4.Rows[e.RowIndex].Cells[1].Text);
            pps.ProductSupplierId = int.Parse(((GridView)sender).Rows[e.RowIndex].Cells[2].Text);

            int pkgId;

            pkgId = (Session["PackageID"] == null) ? 1 : int.Parse(Session["PackageID"].ToString());
            if (PackageProductSupplierDB.DeletePackageProductSupplier(pps) > 0)
                PackageProductSupplierDB.GetPackageProductSupplierDetailByPackageIdToGridview(pkgId, GridView4);
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView4_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            PackageProductSupplier pps = new PackageProductSupplier();
            pps.PackageId = int.Parse(GridView4.Rows[e.RowIndex].Cells[1].Text);
            pps.ProductSupplierId = int.Parse(((GridView)sender).Rows[e.RowIndex].Cells[2].Text);

            int pkgId;

            pkgId = (Session["PackageID"] == null) ? 1 : int.Parse(Session["PackageID"].ToString());
            if (PackageProductSupplierDB.DeletePackageProductSupplier(pps) > 0)
                PackageProductSupplierDB.GetPackageProductSupplierDetailByPackageIdToGridview(pkgId, GridView4);
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                //Label1.Text = "Data input in the worng format!";
                e.ExceptionHandled = true;
                lblStatus.Text = "Invalid Input, pleast try again!";
            }
            else
            {
                lblStatus.Text = "";
            }
           
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["PackageID"] = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;
            PackageProductSupplierDB.GetPackageProductSupplierDetailByPackageIdToGridview(int.Parse(Session["PackageID"].ToString()), GridView4);
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ProductSupplierID"] = ((GridView)sender).SelectedRow.Cells[1].Text;
            if (Session["ProductSupplierID"] == null || Session["PackageID"] == null) return;

            PackageProductSupplier pps = new PackageProductSupplier();
            pps.PackageId = int.Parse(Session["PackageID"].ToString());
            pps.ProductSupplierId = int.Parse(Session["ProductSupplierID"].ToString());
            PackageProductSupplierDB.AddPackageProductSupplier(pps);

            int pkgId = 1;

            pkgId = (Session["PackageID"] == null) ? 1 : int.Parse(Session["PackageID"].ToString());
            PackageProductSupplierDB.GetPackageProductSupplierDetailByPackageIdToGridview(pkgId, GridView4);
        }

        protected void GridView6_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/AgentLogin.aspx");
        }
    }
}