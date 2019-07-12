<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TravelExperts.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
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
  <div class="page-header header-filter" data-parallax="true" style="background-image: url('img/bg4.jpg')">
    <div class="container">
      <div class="row">
        <div class="col-md-8 ml-auto mr-auto">
          <div class="brand text-center">
            <h1>Welcome to Travel Experts</h1>
            <h3 class="title text-center">Come Explore</h3>
          </div>
        </div>
      </div>
    </div>
  </div>
  
</asp:Content>

