<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="packages.aspx.cs" Inherits="TravelExperts.agentLogged" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .heading {
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-right">
        <asp:Button ID="logoutbtn" runat="server" BackColor="#9900FF" ForeColor="White" OnClick="logoutbtn_Click" Text="Logout" margin-right="100px" BorderColor="Black" BorderStyle="Double" />
   <div class="container" >
       <!-- nav pills -->
       <h2 class="heading text-primary">
        Modify Your Packages here <i class="material-icons orange600">arrow_downward </i></h2>
       <br />

       <div class="card card-nav-tabs" >

               <div class="card-header card-header-primary">
                  <!-- colors: "header-primary", "header-info", "header-success", "header-warning", "header-danger" -->
                  <div class="nav-tabs-navigation">
                    <div class="nav-tabs-wrapper">
         
              <ul class="nav nav-tabs" role="tablist">
                <li class="nav-item">
                  <a class="nav-link" href="PackageWeb.aspx" >
                    <i class="material-icons">flight_takeoff</i> New Packages
                  </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link active" href="packages.aspx" >
                    <i class="material-icons">flight_land</i> Edit Packages
                  </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="Products.aspx" >
                    <i class="material-icons">wallpaper</i> Products
                  </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="ProductSupplier.aspx" >
                    <i class="material-icons">favorite</i> Products-Suppliers
                  </a>
                </li>
                <li class="nav-item">
                <a class="nav-link" href="Suppliers.aspx">
                <i class="material-icons">fingerprint</i> Suppliers
                </a>
                </li>
              </ul>
                    </div>
                  </div>
                </div>

           <div class="card-body "> 
               <%--package tab--%>
     <div class="tab-content">
                <div class="tab-pane active" id="packages">

               <br />
                    <h2>Select an existing Package Here:</h2>
        <div id="packages2" class="text-left">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowUpdated="GridView1_RowUpdated" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                        <asp:BoundField DataField="PackageId" HeaderText=" #" SortExpression="PackageId" >
                        <ControlStyle Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PkgName" HeaderText="Name" SortExpression="PkgName" >
                        <ControlStyle Width="140px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PkgStartDate" HeaderText="Start Date" SortExpression="PkgStartDate" DataFormatString="{0:d}" ApplyFormatInEditMode="true" >
                        <ControlStyle Width="120%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PkgEndDate" HeaderText="End Date" SortExpression="PkgEndDate" DataFormatString="{0:d}" ApplyFormatInEditMode="true" >
                        <ControlStyle Width="110%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PkgDesc" HeaderText="Description" SortExpression="PkgDesc" >
                        <ControlStyle Width="300px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PkgBasePrice" HeaderText="Base Price" SortExpression="PkgBasePrice" ApplyFormatInEditMode="true" >
                        <ControlStyle Width="110%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PkgAgencyCommission" HeaderText="Commission" SortExpression="PkgAgencyCommission" ApplyFormatInEditMode="true" >
                        <ControlStyle Width="85%" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblStatus" runat="server" CssClass="text-danger"></asp:Label>
          <br />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Data.Package" DeleteMethod="DeletePackage" InsertMethod="AddPackage" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllPackage" TypeName="Data.PackageDB" UpdateMethod="UpdatePackage" ConflictDetection="CompareAllValues">
                    <UpdateParameters>
                        <asp:Parameter Name="original_Package" Type="Object" />
                        <asp:Parameter Name="package" Type="Object" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            <h2>See the products in your Package Here:</h2>
          <asp:GridView ID="GridView4" runat="server" OnRowDeleting="GridView4_RowDeleting1" OnSelectedIndexChanged="GridView4_SelectedIndexChanged" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
          <br />
            <h2>Add new Products for your Package Here:</h2> 


           
          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" CssClass="table table-striped table-bordered" AllowPaging="True">
              <Columns>
                  <asp:CommandField ShowSelectButton="True" />
                  <asp:BoundField DataField="ProductSupplierId" HeaderText="Product Supplier #" SortExpression="ProductSupplierId" />
                  <asp:BoundField DataField="ProductId" HeaderText="Product #" SortExpression="ProductId" />
                  <asp:BoundField DataField="ProdName" HeaderText="Product" SortExpression="ProdName" />
                  <asp:BoundField DataField="SupplierId" HeaderText="Supplier #" SortExpression="SupplierId" />
                  <asp:BoundField DataField="SupName" HeaderText="Supplier" SortExpression="SupName" />
              </Columns>
        </asp:GridView>

                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllProductSupplierDetails" TypeName="Data.ProductSupplierDetailDB" ConflictDetection="CompareAllValues"></asp:ObjectDataSource>
            </div>
            </div>
         </div>
               </div>
           </div>
       </div></div>
    
         
</asp:Content>