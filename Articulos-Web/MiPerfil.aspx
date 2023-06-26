﻿<%@ Page Title="" Language="C#" MasterPageFile="~/mimaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Articulos_Web.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <div class="row">
         <div class="col-md-4">

            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>


            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TxtNombre" />
            </div>

             <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TxtApellido" />
            </div>

             <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TxtContraseña" />
            </div>
        </div>

                 <div class="col-md-4">
                    <div class="mb-3">
                    <label class="form-label">Imagen Perfil</label>
                    <input type="file" id="txtImagen" runat="server" class="form-control" />
                    </div>
                    <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                    runat="server" CssClass="img-fluid mb-3" />

                </div>


         

    </div>
     <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary"   ID="btnGuardar" runat="server" />
            <a href="/">Regresar</a>
        </div>
    </div>
    
</asp:Content>
