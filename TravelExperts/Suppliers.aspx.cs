using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelExperts
{
    public partial class WebForm2 : System.Web.UI.Page
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Supplier s = new Supplier();
            //psd.ProductSupplierId = int.Parse(GridView1.SelectedRow.Cells[2].Text);

            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = 3;
            string name = "text";
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/AgentLogin.aspx");
        }
    }
}