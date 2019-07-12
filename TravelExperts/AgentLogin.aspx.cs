using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelExperts
{
    public partial class AgentLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAsiginin_Click(object sender, EventArgs e)
        {
            try
            {
                int n = AgentsDB.getAgent(txtId.Text, txtPwd.Text);
                //int n = AgentDB.getAgent(txtId.Text, TextBox3.Text);

                if (n >= 0)
                {
                    //lblstatus.Text = "Logged in. " + " Customer ID is: " + n.ToString();
                    Session["logged"] = true;

                    Response.Redirect("PackageWeb.aspx");
                }
                else
                {
                    lblstatus.Text = "User does not exist";


                }
            }
            catch (Exception ex)
            {
                lblstatus.Text = "An error occured, please try again";
            }
        }

    }
}