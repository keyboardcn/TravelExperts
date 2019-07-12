<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductSupplier.aspx.cs" Inherits="TravelExperts.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-right">
        <asp:Button ID="logoutbtn" runat="server" BackColor="#9900FF" ForeColor="White" OnClick="logoutbtn_Click" Text="Logout" margin-right="100px" BorderColor="Black" BorderStyle="Double" />
     <div class="container" >
       <!-- nav pills -->
       <h2 class="heading text-primary">
        Create a new Product/Supplier ID <i class="material-icons orange600">arrow_downward </i></h2>
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
                  <a class="nav-link active" href="ProductSupplier.aspx" >
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
           <div class="card-body ">
                <div class="row justify-content-center">
                    <div class="table-responsive">
                        

                       
    <h2> Your available Product-Suppliers are here</h2>
                        
                        
    
                            
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="ProductSupplierId" HeaderText="Product Supplier #" SortExpression="ProductSupplierId" />
            <asp:BoundField DataField="ProductId" HeaderText="Product #" SortExpression="ProductId" />
            <asp:BoundField DataField="ProdName" HeaderText="Product" SortExpression="ProdName" />
            <asp:BoundField DataField="SupplierId" HeaderText="Supplier #" SortExpression="SupplierId" />
            <asp:BoundField DataField="SupName" HeaderText="Supplier" SortExpression="SupName" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllProductSupplierDetails" TypeName="Data.ProductSupplierDetailDB" ConflictDetection="CompareAllValues" DataObjectTypeName="Data.ProductSupplierDetail" DeleteMethod="DeleteProductSupplierDetail"></asp:ObjectDataSource>
    <br />
         
    <p>
        &nbsp;</p>
                        
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource2" DataTextField="ProdName" DataValueField="ProductID" CssClass ="btn btn-outline-primary btn-link btn-wd btn-lg" AutoPostBack="True">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetProducts" TypeName="Data.ProductsDB" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
    <br />
    <p>
        
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource3" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" OnSelectedIndexChanging="GridView3_SelectedIndexChanging" CssClass="table table-striped table-bordered" AllowPaging="True">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="SupplierId" HeaderText="Supplier #" SortExpression="SupplierId" />
                <asp:BoundField DataField="SupName" HeaderText="Supplier" SortExpression="SupName" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" DataObjectTypeName="Data.Supplier" InsertMethod="AddSupplier" SelectMethod="GetAllSuppliersHavingNoSpecificProduct" TypeName="Data.SuppliersDB" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="1" Name="productId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
                        </div>
                    </div>
               </div>
           </div>
         </div>
    </div>
    
</asp:Content>
