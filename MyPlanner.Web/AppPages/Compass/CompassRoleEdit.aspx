<%@ Page Title="" Language="C#" MasterPageFile="~/AppPages/MasterPages/Popup.Master" AutoEventWireup="true" CodeBehind="CompassRoleEdit.aspx.cs" Inherits="MyPlanner.AppPages.CompassRoleEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="popupContainer" style="width: 400px">
        <table class="popuptableClass">
            <tr>
                <td class="popuptableClass td label">
                    Role&nbsp;Name&nbsp;:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRoleName" Width="250px" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="popuptableClass td label">
                    Notes&nbsp;:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" Rows="9" Width="325px"
                        TabIndex="3"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <table class="popuptableClass" style="width: 95%">
                        <tr>
                            <td style="width: 200px">
                                &nbsp;<asp:Label runat="server" CssClass="popuptableClass td errorText" ID="lblErrorText">&nbsp;</asp:Label>
                            </td>
                            <td style="min-width: 120px">
                                <asp:Button runat="server" ID="btnSave" Text="Save" Width="50px" OnClick="btnSave_Click"
                                    TabIndex="4" />&nbsp;<asp:Button runat="server" ID="btnCancel" Text="Cancel" Width="50px"
                                        TabIndex="8" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="display: none">
                    <asp:TextBox runat="server" ID="txtItemID"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
