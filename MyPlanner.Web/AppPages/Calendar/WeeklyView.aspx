<%@ Page Title="" Language="C#" MasterPageFile="~/AppPages/MasterPages/Site.Master"
    AutoEventWireup="true" CodeBehind="WeeklyView.aspx.cs" Inherits="MyPlanner.AppPages.WeeklyView" %>

<%@ Register Assembly="obout_Calendar2_Net" Namespace="OboutInc.Calendar2" TagPrefix="obout" %>
<%@ Register Src="WeekView.ascx" TagName="WeekView" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="hdnShowWorkWeekOnly" name="hdnShowWorkWeekOnly" runat="server" type="hidden" />
    <table style="width: 95%; min-height: 530px; padding: 5px 5px 5px 5px">
        <tr>
            <td>
                For the week :<asp:Label runat="server" ID="lblDay"></asp:Label>
                <obout:Calendar ID="calForDate" runat="server" DatePickerMode="true" DateFormat="dd/MM/yyyy"
                    ShowOtherMonthDays="false" DatePickerImagePath="../../App_Themes/treetops/arrow_select.png"
                    AutoPostBack="True" OnDateChanged="calForDate_OnDateChanged">
                </obout:Calendar>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:WeekView ID="WeekView1" runat="server" />
            </td>
        </tr>
    </table>
    <input id="hdnCurrentDate" name="hdnCurrentDate" runat="server" type="hidden" />
    <script type="text/javascript">
        function showCalendar() {
            ContentPlaceHolder1_calForDate.displayCalendar(event);
        }
    </script>
</asp:Content>
