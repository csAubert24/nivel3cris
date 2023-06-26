<%@ Page Title="" Language="C#" MasterPageFile="~/mimaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Articulos_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager3" runat="server"></asp:ScriptManager>

    <%--filtroAvanzado--%>
<%-- <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
                    <div class="row">
            <div class="col-2">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Tipo" />
                        <asp:ListItem Text="Precio" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-2">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-2">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" REQUIRED CssClass="form-control" />
                </div>
            </div>
        </div>
    <div class="row">
         <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary BotonBuscar" id="btnBuscar" OnClick="btnBuscar_Click"/>
                </div>
            </div>

    </div>
<%-- </ContentTemplate>
    </asp:UpdatePanel>--%>


   <%-- -------%>
    <div class="row row-cols-1 row-cols-md-3 g-4">

    <asp:Repeater runat="server" ID="IdRepetidor"  >
        <ItemTemplate>
            <div class="col">
                <div class="card">
                <img src="<%#Eval("Imagen") %>" class="card-img-top" style="height: 18rem;" alt="...">
                <div class="card-body">
                  <h5 class="card-title"> <%#Eval("Nombre") %>   </h5>
                  <p class="card-text"> <%#Eval("Codigo") %>   </p>
                  <p class="card-text">  <%#Eval("id") %>      </p>  
                  <p class="card-text"> <%#Eval("Precio") %> </p>  
                  <asp:Button Text="Ejemplo" runat="server" CssClass="btn btn_primary" ID="btnEjemplo" CommandArgument='<%#Eval("id") %>' CommandName="ArticuloId" OnClick="btnEjemplo_Click"/>
                </div>
                </div>
             </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>
    
</asp:Content>
