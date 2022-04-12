<%@ Page Title="Mantto. de Areas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfAreas.aspx.cs" Inherits="DFPC_Examen.wfAreas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table __designer:mapid="17" cellpadding="0" cellspacing="0">
    <tr __designer:mapid="18">
        <td __designer:mapid="19" colspan="2">&nbsp;</td>
    </tr>
    <tr __designer:mapid="1a">
        <td __designer:mapid="1b">
            <table __designer:mapid="1c">
                <tr __designer:mapid="1d">
                    <td __designer:mapid="1e">&nbsp;</td>
                    <td __designer:mapid="1f">&nbsp;</td>
                    <td __designer:mapid="20">&nbsp;</td>
                    <td __designer:mapid="21">&nbsp;</td>
                </tr>
            </table>
            <table __designer:mapid="22">
                <tr __designer:mapid="23">
                    <td __designer:mapid="24">
                        <asp:ImageButton ID="ibtnNuevo" runat="server" BorderColor="#000099" BorderStyle="Outset" BorderWidth="2px" ImageUrl="~/Picts/add.png" OnClick="ibtnNuevo_Click" ToolTip="Adicionar" />
                    </td>
                    <td __designer:mapid="26">
                        <asp:ImageButton ID="ibtnEdit" runat="server" BorderColor="#000099" BorderStyle="Outset" BorderWidth="2px" ImageUrl="~/Picts/text-editor.png" OnClick="ibtnEdit_Click" ToolTip="Editar" />
                    </td>
                    <td __designer:mapid="28">
                        <asp:ImageButton ID="ibtnBorrar" runat="server" BorderColor="#000099" BorderStyle="Outset" BorderWidth="2px" Height="23px" ImageUrl="~/Picts/gtk-delete.png" OnClick="ibtnBorrar_Click" ToolTip="Eliminar" Width="23px" />
                    </td>
                    <td __designer:mapid="2a">
                        <asp:ImageButton ID="ibtnGuardar" runat="server" BorderColor="#000099" BorderStyle="Outset" BorderWidth="2px" ImageUrl="~/Picts/Save.png" OnClick="ibtnGuardar_Click" ToolTip="Guardar" />
                    </td>
                </tr>
            </table>
        </td>
        <td __designer:mapid="2c">
            <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr __designer:mapid="2e">
        <td __designer:mapid="2f">
            <table __designer:mapid="30" cellpadding="0" cellspacing="0" class="nav-justified">
                <tr __designer:mapid="31">
                    <td __designer:mapid="32">
                        <asp:Label ID="Label3" runat="server" Text="Nombre : "></asp:Label>
                    </td>
                    <td __designer:mapid="34">
                        <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr __designer:mapid="36">
                    <td __designer:mapid="37">&nbsp;</td>
                    <td __designer:mapid="38">&nbsp;</td>
                </tr>
                <tr __designer:mapid="36">
                    <td __designer:mapid="37">
                        <asp:Label ID="Label4" runat="server" Text="Descripcion :"></asp:Label>
                    </td>
                    <td __designer:mapid="38">
                        <asp:TextBox ID="txtDescripcion" runat="server" Height="52px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr __designer:mapid="39">
                    <td __designer:mapid="3a" colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <td __designer:mapid="3c">
            <asp:GridView ID="gvAreas" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" BorderStyle="Groove" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvAreas_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField />
                    <asp:BoundField DataField="IdArea" HeaderText="Codigo" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </td>
    </tr>
    <tr __designer:mapid="4d">
        <td __designer:mapid="4e">&nbsp;</td>
        <td __designer:mapid="4f">&nbsp;</td>
    </tr>
</table>
</asp:Content>
