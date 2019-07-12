<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgentLogin.aspx.cs" Inherits="TravelExperts.AgentLogin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar navbar-transparent navbar-color-on-scroll fixed-top navbar-expand-lg" color-on-scroll="100" id="sectionsNav">
        <div class="container">
          <div class="navbar-translate">
              <button class="navbar-toggler" type="button" data-toggle="collapse" aria-expanded="false" aria-label="Toggle navigation">
              <span class="sr-only">Toggle navigation</span>
              <span class="navbar-toggler-icon"></span>
              <span class="navbar-toggler-icon"></span>
              <span class="navbar-toggler-icon"></span>
            </button>
          </div>
          <div class="collapse navbar-collapse">
            <ul class="navbar-nav ml-auto">
              <li class="dropdown nav-item">
                  
                <a href="#" class="dropdown-toggle nav-link" data-toggle="dropdown" style="background-color: #9900FF">
                  <i class="material-icons">airplanemode_active</i> <b>Login Here</b>
                </a>
                <div class="dropdown-menu dropdown-with-icons">
                  <a href="AgentLogin.aspx" class="dropdown-item">
                    <i class="material-icons">layers</i> Agent Login
                  </a><a href= "http://localhost:51470/Home/Login" class="dropdown-item">
                    <i class="material-icons">layers</i> Client Login
                  </a>
                 <a href="Index.aspx" class="dropdown-item">
                    <i class="material-icons">layers</i> Home
                 </a>
                  
                  
                </div>
              </li>
                            
            </ul>
          </div>
        </div>
      </nav>
    <div class="page-header header-filter" style="background-image:url('img/bg2.jpg'); background-size: cover; background-position: top center;">
    <div class="container">
      <div class="row">
        <div class="col-lg-4 col-md-6 ml-auto mr-auto">
          <div class="card card-login">
          
                <a href="Assets/"></a>
              <div class="card-header card-header-primary text-center">
                <h4 class="card-title">Travel Experts Agent Login</h4>
              </div>
              <p class="description text-center"></p>
              <div class="card-body">
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text">
                      <i class="material-icons">face</i>
                    </span>
                  </div>
             
                    <asp:TextBox ID="txtId" runat="server" class="form-control" placeholder="Agent ID..."></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtId" CssClass="text-danger" Display="Dynamic">*required</asp:RequiredFieldValidator>
                      </div>
 
                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text">
                      <i class="material-icons">lock_outline</i>
                    </span>
                  </div>
                  <asp:TextBox ID="txtPwd" runat="server" class="form-control" placeholder="Password..." TextMode="Password" ></asp:TextBox>
       
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" ErrorMessage="RequiredFieldValidator" CssClass="text-danger text-center" Display="Dynamic">*required</asp:RequiredFieldValidator>
         
                  </div>
                  
              </div>
              <div class="footer text-center">                                            
                  <asp:Label ID="lblstatus" runat="server" CssClass="text-danger"></asp:Label><br />
                  <asp:Button ID="btnAsignin" runat="server" Text="Sign In" class="btn btn-primary btn-link btn-wd btn-lg" OnClick="btnAsiginin_Click"/>
              </div>
       
          </div>
        </div>
      </div>
    </div>
      </div>
</asp:Content>
