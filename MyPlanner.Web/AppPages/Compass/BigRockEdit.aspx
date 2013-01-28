<%@ Page Title="" Language="C#" MasterPageFile="~/AppPages/MasterPages/Popup.Master" AutoEventWireup="true" CodeBehind="BigRockEdit.aspx.cs" Inherits="MyPlanner.AppPages.BigRockEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="popupContainer">
        <table class="popuptableClass">
             <tr>
                <td class="popuptableClass td label">
                    As Role :
                </td>
                <td colspan="4">
                    <asp:DropDownList runat="server" Width="100px" ID="ddlCompassRoles" TabIndex="1">
                    </asp:DropDownList>
                </td>
            </tr>
           <tr>
                <td class="popuptableClass td label">
                    Big Rock :
                </td>
                <td colspan="4">
                    <asp:TextBox runat="server" ID="txtBigRockName" Width="300px" TabIndex="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="5" align="left">
                    <table class="popuptableClass" style="width: 95%">
                        <tr>
                            <td style="width: 250px">
                                &nbsp;<asp:Label runat="server" CssClass="popuptableClass td errorText" ID="lblErrorText">&nbsp;</asp:Label>
                            </td>
                            <td style="min-width: 120px">
                                <asp:Button runat="server" ID="btnSave" Text="Save" Width="50px" OnClick="btnSave_Click"
                                    TabIndex="7" />&nbsp;<asp:Button runat="server" ID="btnCancel" Text="Cancel" Width="50px"
                                        TabIndex="8" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="display: none">
                    <asp:TextBox runat="server" ID="txtItemID"></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtCurrentDate"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
