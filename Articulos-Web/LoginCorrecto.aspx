<%@ Page Title="" Language="C#" MasterPageFile="~/mimaster.Master" AutoEventWireup="true" CodeBehind="LoginCorrecto.aspx.cs" Inherits="Articulos_Web.LoginCorrecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-4" style="margin-top:50px">
            <asp:Button Text="Ingresar 1" runat="server" ID="btnOpcion1" OnClick="btnOpcion1_Click" CssClass="btn btn-primary"/>
        </div>
          <div class="col-4" style="margin-top:50px">
            <asp:Button Text="Ingresar 2" CssClass="btn btn-primary" ID="btnOpcion2" runat="server" OnClick="btnOpcion2_Click"/>
        </div>

    </div>


</asp:Content>
