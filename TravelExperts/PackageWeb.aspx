<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PackageWeb.aspx.cs" Inherits="TravelExperts.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .heading {
            color: white;
        }
        .auto-style1 {
            display: block;
            width: 100%;
            overflow-x: auto;
            -webkit-overflow-scrolling: touch;
            -ms-overflow-style: -ms-autohiding-scrollbar;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-right">
         <asp:Button ID="logoutbtn" runat="server" BackColor="#9900FF" ForeColor="White" OnClick="logoutbtn_Click" Text="Logout" margin-right="100px" BorderColor="Black" BorderStyle="Double" />
     <div class="container" >
       <!-- nav pills -->
       <h2 class="heading text-primary">
        Add new Packages here <i class="material-icons orange600">arrow_downward </i></h2>
       <br />
         
       <div class="card card-nav-tabs" >

               <div class="card-header card-header-primary">
                  <!-- colors: "header-primary", "header-info", "header-success", "header-warning", "header-danger" -->
                  <div class="nav-tabs-navigation">
                    <div class="nav-tabs-wrapper">
         
              <ul class="nav nav-tabs" role="tablist">
                <li class="nav-item">
                  <a class="nav-link active" href="PackageWeb.aspx" >
                    <i class="material-icons">flight_takeoff</i> New Packages
                  </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="packages.aspx" >
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
               <div class="row">
               <h2>Create a new Package Here:</h2>

            <div class="auto-style1">
        <br /> 
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="414px" AutoGenerateRows="False" DataSourceID="ObjectDataSource2" OnItemCreated="DetailsView1_ItemCreated" OnLoad="DetailsView1_Load" CssClass="table table-bordered table-striped" DefaultMode="Insert" OnItemInserted="DetailsView1_ItemInserted" OnItemInserting="DetailsView1_ItemInserting">
        <Fields>
            <asp:BoundField DataField="PkgName" HeaderText="Name" SortExpression="PkgName" />
            <asp:BoundField DataField="PkgStartDate" HeaderText="Start Date" SortExpression="PkgStartDate" ValidateRequestMode="Disabled" />
            <asp:BoundField DataField="PkgEndDate" HeaderText="End Date" SortExpression="PkgEndDate" ValidateRequestMode="Disabled" />
            <asp:BoundField DataField="PkgDesc" HeaderText="Description" SortExpression="PkgDesc" />
            <asp:BoundField DataField="PkgBasePrice" HeaderText="Base Price" SortExpression="PkgBasePrice" />
            <asp:BoundField DataField="PkgAgencyCommission" HeaderText="Commission" SortExpression="PkgAgencyCommission" />
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                   <%--<div class="table-responsive">--%>
                    <h2>Current Packages:</h2>

                

               
<%--    <div id="packages2" class="col-md-10 ml-auto">--%>
    <asp:GridView ID="GridView1" runat="server" AllowCustomPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowDeleted="GridView1_RowDeleted" OnRowEditing="GridView1_RowEditing1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" OnRowUpdated="GridView1_RowUpdated" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="PackageId" HeaderText="Package #" SortExpression="PackageId" />
            <asp:BoundField DataField="PkgName" HeaderText="Name" SortExpression="PkgName" />
            <asp:BoundField DataField="PkgStartDate" HeaderText="Start Date" SortExpression="PkgStartDate" DataFormatString="{0:d}" ApplyFormatInEditMode="true"/>
            <asp:BoundField DataField="PkgEndDate" HeaderText="End Date" SortExpression="PkgEndDate" DataFormatString="{0:d}" ApplyFormatInEditMode="true"/>
            <asp:BoundField DataField="PkgDesc" HeaderText="Description" SortExpression="PkgDesc" />
            <asp:BoundField DataField="PkgBasePrice" HeaderText="Base Price" SortExpression="PkgBasePrice" DataFormatString="{0:c}" />
            <asp:BoundField DataField="PkgAgencyCommission" HeaderText="Commission" SortExpression="PkgAgencyCommission" DataFormatString="{0:c}" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Data.Package" DeleteMethod="DeletePackage" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllPackage" TypeName="Data.PackageDB" UpdateMethod="UpdatePackage" ConflictDetection="CompareAllValues">
        <UpdateParameters>
            <asp:Parameter Name="original_Package" Type="Object" />
            <asp:Parameter Name="package" Type="Object" />
        </UpdateParameters>
    </asp:ObjectDataSource> 

    
       
                </div>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="Data.Package" InsertMethod="AddPackage" OldValuesParameterFormatString="original_{0}" SelectMethod="GetPackageByID" TypeName="Data.PackageDB" >
        <SelectParameters>
            <asp:SessionParameter DefaultValue="1" Name="packageID" SessionField="PackageID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
        </div>
    </div>
</div>
   </div>
         </div>
        </div>
    
</asp:Content>
