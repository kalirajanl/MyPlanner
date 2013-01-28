<%@ Page Title="" Language="C#" MasterPageFile="~/AppPages/MasterPages/Popup.Master"
    AutoEventWireup="true" CodeBehind="GoalStepEdit.aspx.cs" Inherits="MyPlanner.AppPages.Goals.GoalStepEdit" %>

<%@ Register Assembly="obout_Calendar2_Net" Namespace="OboutInc.Calendar2" TagPrefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="popupContainer">
        <table class="popuptableClass">
            <tr>
                <td class="popuptableClass td label">
                    Step :
                </td>
                <td colspan="4">
                    <asp:TextBox runat="server" ID="txtTaskName" Width="300px" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="popuptableClass td label">
                    Due On :
                </td>
                <td colspan="3" >
                    <asp:TextBox runat="server" ID="txtForDate" Width="75px" TabIndex="4"></asp:TextBox>
                    <obout:Calendar ID="calForDate" runat="server" DatePickerMode="true" TextBoxId="txtForDate"
                        DateFormat="dd/MM/yyyy" DatePickerImagePath="../../App_Themes/treetops/images/date_picker1.gif"
                        DatePickerSynchronize="true">
                    </obout:Calendar>
                </td>
            </tr>
            <tr>
                <td class="popuptableClass td label">
                    Notes :
                </td>
                <td colspan="4">
                    <asp:TextBox runat="server" ID="txtTaskNotes" TextMode="MultiLine" Rows="6" Width="300px"
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
                    <asp:TextBox runat="server" ID="txtGoalStepID"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
