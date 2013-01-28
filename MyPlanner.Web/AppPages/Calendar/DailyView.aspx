<%@ Page Title="" Language="C#" MasterPageFile="~/AppPages/MasterPages/Site.Master"
    AutoEventWireup="true" CodeBehind="DailyView.aspx.cs" Inherits="MyPlanner.AppPages.DailyView" %>

<%@ Register Assembly="obout_Calendar2_Net" Namespace="OboutInc.Calendar2" TagPrefix="obout" %>
<%@ Register Src="../tasks/TaskListing.ascx" TagName="TaskListing" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 95%; min-height: 530px; padding: 5px 5px 5px 5px">
        <tr>
            <td style="width: 35%">
                <table>
                    <tr>
                        <td class="SelectedDayContainer">
                            <span class="form_settings">&nbsp;</span>
                            <asp:Label ID="lblSelectedDay" CssClass="SelectedDay" runat="server" Text="1"></asp:Label><obout:Calendar ID="calForDate" runat="server" DatePickerMode="true" DateFormat="dd/MM/yyyy"
                                ShowOtherMonthDays="false" DatePickerImagePath="../../App_Themes/treetops/arrow_select.png" CSSDatePickerButton="calendarbtnlocation"
                                AutoPostBack="True" OnDateChanged="calForDate_OnDateChanged">
                            </obout:Calendar>
                        </td>
                        <td class="SelectedDayDetails">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblDay"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblMonth"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblYear"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <uc1:TaskListing ID="TaskListing1" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;
            </td>
            <td style="width: 35%; vertical-align: top">
                <span class="form_settings">Appointments</span>
                <asp:TextBox ID="txtAppointments" Rows="25" Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td style="width: 20%; vertical-align: top">
                <span class="form_settings">Notes</span>
                <asp:TextBox ID="txtNotes" Rows="25" Width="95%" TextMode="MultiLine" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <input id="hdnCurrentDate" name="hdnCurrentDate" runat="server" type="hidden" />
    <asp:Label ID="lblMessage" runat="server" />
    <asp:LinkButton ID="lnkView" runat="server" Style="display: none" />
    <asp:LinkButton ID="lnkDelete" runat="server" Style="display: none" />
    <asp:HiddenField ID="fldProductID" runat="server" />
    <script type="text/javascript">
        function showCalendar() {
            ContentPlaceHolder1_calForDate.displayCalendar(event);
        }
    </script>
</asp:Content>
