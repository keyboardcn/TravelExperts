
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Suppliers.aspx.cs" Inherits="TravelExperts.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="text-right">
        <asp:Button ID="logoutbtn" runat="server" BackColor="#9900FF" margin-right="100px" ForeColor="White" OnClick="logoutbtn_Click" Text="Logout" BorderColor="Black" BorderStyle="Double" />
   <div class="container" >
       <!-- nav pills -->
       <h2 class="heading text-primary">
        Modify Your Suppliers here <i class="material-icons orange600">arrow_downward </i></h2>
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
                  <a class="nav-link" href="packages.aspx" >
                    <i class="material-icons">flight_land</i> Edit Packages
                  </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="products.aspx" >
                    <i class="material-icons">wallpaper</i> Products
                  </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="ProductSupplier.aspx" >
                    <i class="material-icons">favorite</i> Products-Suppliers
                  </a>
                </li>
                <li class="nav-item">
                <a class="nav-link active" href="Suppliers.aspx">
                <i class="material-icons">fingerprint</i> Suppliers
                </a>
                </li>
              </ul>
                    </div>
                  </div>
                </div>

           <div class="card-body ">
               <div class="row justify-content-center">

              
               <div class="col-lg-6">
                   <div class="table-responsive">

       
                       <h2>Suppliers
                       </h2>
                       <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" CssClass="table table-striped table-bordered">
                           <Columns>
                               <asp:CommandField ShowEditButton="True" />
                               <asp:BoundField DataField="SupplierId" HeaderText="Supplier #" SortExpression="SupplierId" />
                               <asp:BoundField DataField="SupName" HeaderText="Supplier" SortExpression="SupName" />
                           </Columns>
                           </asp:GridView>
                           &nbsp;
                       

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"  DataObjectTypeName="Data.Supplier" ConflictDetection="CompareAllValues" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllSuppliers" TypeName="Data.SuppliersDB" UpdateMethod="UpdateSupplier" InsertMethod="AddSupplier">
            <UpdateParameters>
                <asp:Parameter Name="original_Supplier" Type="Object" />
                <asp:Parameter Name="supplier" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
                       </div>
                                   </div>
                   <div class="col-lg-6">
                       <h2>Add New Supplier</h2>
                       <br />
                       <br />
                       
                    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource1" DefaultMode="Insert" Height="50px" Width="452px" CssClass="table table-bordered table-hover">
                        <Fields>
                            <asp:BoundField DataField="SupplierId" HeaderText="Supplier # " SortExpression="SupplierId" />
                            <asp:BoundField DataField="SupName" HeaderText="Supplier" SortExpression="SupName" />
                            <asp:CommandField ShowInsertButton="True" />
                        </Fields>
                    </asp:DetailsView>
                       <br />
                       
                       </div>
               </div>
                </div>
           </div>
       </div>
    </asp:Content>
