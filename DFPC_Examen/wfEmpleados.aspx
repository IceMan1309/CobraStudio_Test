<%@ Page Title="Mantto. de Empleados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfEmpleados.aspx.cs" Inherits="DFPC_Examen.wfEmpleados" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ibtnNuevo" runat="server" BorderColor="#000099" BorderStyle="Outset" BorderWidth="2px" ImageUrl="~/Picts/add.png" OnClick="ibtnNuevo_Click" ToolTip="Adicionar" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="ibtnEdit" runat="server" BorderColor="#000099" BorderStyle="Outset" BorderWidth="2px" ImageUrl="~/Picts/text-editor.png" OnClick="ibtnEdit_Click" ToolTip="Editar" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="ibtnBorrar" runat="server" BorderColor="#000099" BorderStyle="Outset" BorderWidth="2px" Height="23px" ImageUrl="~/Picts/gtk-delete.png" OnClick="ibtnBorrar_Click" ToolTip="Eliminar" Width="23px" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="ibtnGuardar" runat="server" BorderColor="#000099" BorderStyle="Outset" BorderWidth="2px" ImageUrl="~/Picts/Save.png" OnClick="ibtnGuardar_Click" ToolTip="Guardar" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" class="nav-justified">
                            <tr>
                                <td class="text-right" style="text-align: right">
                                    <asp:Label ID="Label5" runat="server" Text="Nombre de Jefe :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlIdJefe" runat="server" Width="250px">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="text-right" style="text-align: right">
                                    <asp:Label ID="Label12" runat="server" Text="Area :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" Width="250px">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="text-right" style="text-align: right">
                                    <asp:Label ID="Label3" runat="server" Text="Nombre de Empleado :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNombre" runat="server" Width="250px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="text-right" style="text-align: right">
                                    <asp:Label ID="Label6" runat="server" Text="Cedula :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCedula" runat="server" Width="250px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="text-right" style="text-align: right">
                                    <asp:Label ID="Label7" runat="server" Text="Correo :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCorreo" runat="server" CausesValidation="True" Width="250px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCorreo" Display="Dynamic" ErrorMessage="Formato Incorecto" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="text-right" style="text-align: right">
                                    <asp:Label ID="Label8" runat="server" Text="Fecha de Ingreso :"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdFecIngreso" Runat="server" AutoPostBack="True" OnSelectedDateChanged="rdFecIngreso_SelectedDateChanged">
                                        <Calendar Culture="es-ES" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="text-right" style="text-align: right">
                                    <asp:Label ID="Label10" runat="server" Text="Años de Laboral :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAnioTrab" runat="server"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="text-right" style="text-align: right">
                                    <asp:Label ID="Label9" runat="server" Text="Fecha de Nacimiento :"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadDatePicker ID="rdFecNac" Runat="server" AutoPostBack="True" OnSelectedDateChanged="rdFecNac_SelectedDateChanged">
                                        <Calendar Culture="es-ES" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="text-right" style="text-align: right">
                                    <asp:Label ID="Label11" runat="server" Text="Edad :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEdad" runat="server"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="text-right" style="text-align: right">
                                    <asp:Label ID="Label4" runat="server" Text="Fotografia :"></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="text-right" colspan="2">
                                    <asp:Image ID="imgFoto" runat="server" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:GridView ID="gvEmpleados" runat="server" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" BorderStyle="Groove" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvEmpleados_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField />
                                <asp:BoundField DataField="IdEmpleado" HeaderText="Codigo" />
                                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre" />
                                <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                                <asp:BoundField DataField="Correo" HeaderText="Correo" />
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
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
