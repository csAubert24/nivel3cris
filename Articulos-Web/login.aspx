<%@ Page Title="" Language="C#" MasterPageFile="~/mimaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Articulos_Web.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-5">
            <h2> Ingresar   </h2>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Usuario</label>
                <asp:TextBox  ID="txtUser" runat="server" placeHolder="User name" CssClass="form-control" />
            </div>
              </div>

    </div>
    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Contraseña</label>
                <asp:TextBox  ID="txtPass" runat="server" placeHolder="*******" CssClass="form-control" />
            </div>
              </div>

    </div>
    <div class="row">
        <div class="col-4">
            <asp:Button CssClass="btn btn-primary" ID="btnIngreso" Text ="Ingresar" runat="server" OnClick="btnIngreso_Click" />     
        </div>

    </div>

</asp:Content>
