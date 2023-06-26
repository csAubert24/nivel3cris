﻿<%@ Page Title="" Language="C#" MasterPageFile="~/mimaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Articulos_Web.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <h2>  Registrarse  </h2>
                <label for="exampleFormControlInput1" class="form-label">Email</label>
                <asp:TextBox  ID="txtEmail" runat="server" placeHolder="Email" CssClass="form-control" />
            </div>
              </div>

    </div>
    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Contraseña</label>
                <asp:TextBox  ID="txtContraseña" runat="server" placeHolder="*******" CssClass="form-control" />
            </div>
              </div>

    </div>
    <div class="row">
        <div class="col-1">
            <asp:Button CssClass="btn btn-primary" ID="btnRegistrarse" Text ="Aceptar" runat="server" OnClick="btnRegistrarse_Click" />     
        </div>
        <div class="col-1">
            <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="btnCencelarRegistro" OnClick="btnCencelarRegistro_Click" />
        </div>

    </div>
  




</asp:Content>
