using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelExperts
{
    public partial class WebForm5 : System.Web.UI.Page
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
        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["PackageID"] = GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text;
        //    Session["ProductSupplierID"] = GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text;
        //}

        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    Session["PackageID"] = int.Parse(GridView1.Rows[e.NewEditIndex].Cells[0].Text);
        //}

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["PackageID"] = GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text;
            Session["ProductSupplierID"] = GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text;
        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            Session["PackageID"] = int.Parse(GridView1.Rows[e.NewEditIndex].Cells[1].Text);
            
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.AffectedRows < 0)
                Label1.Text = "";
            else
            {
                Session["PackageID"] = 1;
                Label1.Text = "Insert new package successfully";
            }
                
        }



        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void DetailsView1_ItemCreated(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void DetailsView1_Load(object sender, EventArgs e)
        {

        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();            
            Response.Redirect("~/AgentLogin.aspx");
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {

        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (e.Exception != null)
            {
                Label1.Text = "Data input in the worng format!";
                e.ExceptionHandled = true;
            }
                
        }
    }
}