<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="TravelExperts.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container">
  <div class="jumbotron" style="background-color: darkslategrey">
    <h1 class="auto-style1">Modify Your Packages here <i class="material-icons">
arrow_downward
</i></h1>      
   </div>
  
</div>
  <div class="main main-raised" style="background-color: lightgrey">
    <div class="profile-content">
      <div class="container">
        <div class="row">
          <div class="col-md-6 ml-auto mr-auto">
            <div class="profile">
              <%--<div class="avatar">
                <img src="\img\city.jpg" alt="Circle Image" class="img-fluid">
              </div>--%>
              
            </div>
          </div>
        </div>
        
        <div class="row">
          <div class="col-md-8 ml-auto mr-auto">
            <div class="profile-tabs">
              <ul class="nav nav-pills nav-pills-icons justify-content-center" role="tablist">
                <li class="nav-item">
                  <a class="nav-link active" href="#studio" role="tab" data-toggle="tab">
                    <i class="material-icons">flight_land</i> Packages
                  </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#works" role="tab" data-toggle="tab">
                    <i class="material-icons">wallpaper</i> Products
                  </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#favorite" role="tab" data-toggle="tab">
                    <i class="material-icons">favorite</i> Products-Suppliers
                  </a>
                </li>
                <li class="nav-item">
                <a class="nav-link" href="#favorite" role="tab" data-toggle="tab">
                <i class="material-icons">fingerprint</i> Suppliers
                </a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#favorite" role="tab" data-toggle="tab">
                     <i class="material-icons">explore</i> Packages-Products-Suppliers
                    </a>
                </li>
              </ul>
            </div>
          </div>
        </div>
        <div class="tab-content tab-space">
          <div class="tab-pane active text-center gallery" id="studio">
            <div class="row">
                <asp:Button ID="Button4" type="button" runat="server" style="height: 100px" PostBackUrl="~/Agent.aspx" Text="Agent Login" />
                <asp:Button ID="Button5" type="button" runat="server" style="height: 100px" PostBackUrl="~/Customer.aspx" Text="Customer Login" />
                <div class="col-md-4 ml-auto">
                <img src="img\examples\1.jpg" class="rounded">
                <img src="img\examples\2.jpg" class="rounded">
              </div>
              <%--<div class="col-md-3 mr-auto">
                <img src="img\examples\3.jpg" class="rounded">
                <img src="img\examples\4.jpg" class="rounded">
              </div>--%>
            </div>
          </div>
          <div class="tab-pane text-center gallery" id="works">
            <div class="row">
              <div class="col-md-3 ml-auto">
                <img src="img\examples\5.jpg" class="rounded">
                <img src="img\examples\6.jpg" class="rounded">
                <img src="img\examples\7.jpg" class="rounded">
              </div>
              <div class="col-md-3 mr-auto">
                <img src="img\examples\8.jpg" class="rounded">
                <img src="img\examples\9.jpg" class="rounded">
              </div>
            </div>
          </div>
          <div class="tab-pane text-center gallery" id="favorite">
            <div class="row">
              <div class="col-md-3 ml-auto">
                <img src="../assets/img/examples/mariya-georgieva.jpg" class="rounded">
                <img src="../assets/img/examples/studio-3.jpg" class="rounded">
              </div>
              <div class="col-md-3 mr-auto">
                <img src="../assets/img/examples/clem-onojeghuo.jpg" class="rounded">
                <img src="../assets/img/examples/olu-eletu.jpg" class="rounded">
                <img src="../assets/img/examples/studio-1.jpg" class="rounded">
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
