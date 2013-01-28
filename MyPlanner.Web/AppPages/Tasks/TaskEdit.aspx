<%@ Page Title="" Language="C#" MasterPageFile="~/AppPages/MasterPages/Popup.Master"
    AutoEventWireup="true" CodeBehind="TaskEdit.aspx.cs" Inherits="MyPlanner.AppPages.TaskEdit" %>

<%@ Register Assembly="obout_Calendar2_Net" Namespace="OboutInc.Calendar2" TagPrefix="obout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="popupContainer">
        <table class="popuptableClass">
            <tr>
                <td class="popuptableClass td label">
                    Task :
                </td>
                <td colspan="4">
                    <asp:TextBox runat="server" ID="txtTaskName" Width="300px" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="popuptableClass td label">
                    Status :
                </td>
                <td>
                    <asp:DropDownList runat="server" Width="100px" ID="ddlTaskStatus" TabIndex="2">
                    </asp:DropDownList>
                </td>
                <td rowspan="3" class="popuptableClass td label">
                    Categories :
                </td>
                <td rowspan="3">
                    <asp:CheckBoxList runat="server" ID="chklstCategory" Width="100px" CellPadding="5"
                        CellSpacing="5" TabIndex="5">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="popuptableClass td label">
                    Priority :
                </td>
                <td>
                    <asp:DropDownList runat="server" Width="100px" ID="ddlTaskPriority" TabIndex="3">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="popuptableClass td label">
                    For Date :
                </td>
                <td>
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
                    <asp:TextBox runat="server" ID="txtTaskID"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
