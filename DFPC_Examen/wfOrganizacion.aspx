<%@ Page Title="Despliegue de Organizacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfOrganizacion.aspx.cs" Inherits="DFPC_Examen.wfOrganizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 143px">&nbsp;</td>
                    <td>
                        <asp:Label ID="lblIdEmpleado" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 143px">
                        <asp:TreeView ID="tvOrganizacion" runat="server" ImageSet="Arrows" OnSelectedNodeChanged="tvOrganizacion_SelectedNodeChanged">
                            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Bold="False" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0" class="nav-justified">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlHabilidades" runat="server">
                                        <asp:ListItem Value="1">SQL</asp:ListItem>
                                        <asp:ListItem Value="2">Administracion</asp:ListItem>
                                        <asp:ListItem Value="3">Coordinacion</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ImageButton ID="ibtnNuevo" runat="server" BorderColor="#000099" BorderStyle="Outset" BorderWidth="2px" ImageUrl="~/Picts/add.png" OnClick="ibtnNuevo_Click" ToolTip="Adicionar Habilidad" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ListBox ID="lstHabilidades" runat="server"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 143px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 143px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
