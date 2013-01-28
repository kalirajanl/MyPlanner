<%@ Page Title="" Language="C#" MasterPageFile="~/AppPages/MasterPages/Popup.Master"
    AutoEventWireup="true" CodeBehind="GoalEdit.aspx.cs" Inherits="MyPlanner.AppPages.GoalEdit" %>

<%@ Register Assembly="obout_Calendar2_Net" Namespace="OboutInc.Calendar2" TagPrefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="popupContainer">
        <table class="popuptableClass">
            <tr>
                <td class="popuptableClass td label">
                    Subject :
                </td>
                <td colspan="4">
                    <asp:TextBox runat="server" ID="txtSubject" Width="300px" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="popuptableClass td label">
                    Reason Why :
                </td>
                <td colspan="4">
                    <asp:TextBox runat="server" ID="txtReason" Width="300px" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="popuptableClass td label">
                    Categories&nbsp;:
                </td>
                <td>
                    <asp:CheckBoxList runat="server" ID="chklstCategory" Width="250px" CellPadding="5"
                        RepeatColumns="2" RepeatDirection="Horizontal" CellSpacing="5" TabIndex="5">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="popuptableClass td label">
                    Notes :
                </td>
                <td colspan="4">
                    <asp:TextBox runat="server" ID="txtGoalNotes" TextMode="MultiLine" Rows="6" Width="300px"
                        TabIndex="6"></asp:TextBox>
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
                    <asp:TextBox runat="server" ID="txtGoalID"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
