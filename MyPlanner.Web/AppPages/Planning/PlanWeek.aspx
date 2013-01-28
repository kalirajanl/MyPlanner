<%@ Page Title="" Language="C#" MasterPageFile="~/AppPages/MasterPages/Site.Master"
    AutoEventWireup="true" CodeBehind="PlanWeek.aspx.cs" Inherits="MyPlanner.AppPages.PlanWeek" %>

<%@ Register Assembly="obout_Calendar2_Net" Namespace="OboutInc.Calendar2" TagPrefix="obout" %>
<%@ Register Src="../Mission/MissionValues.ascx" TagName="ReviewMission" TagPrefix="uc1" %>
<%@ Register Src="../Goals/GoalsAndSteps.ascx" TagName="GoalsAndSteps" TagPrefix="uc2" %>
<%@ Register Src="../Compass/WeeklyCompass.ascx" TagName="WeeklyCompass" TagPrefix="uc3" %>
<%@ Register Src="../Calendar/WeekView.ascx" TagName="WeekView" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #wizHeader li .prevStep
        {
            background-color: #669966;
        }
        #wizHeader li .prevStep:after
        {
            border-left-color: #669966 !important;
        }
        #wizHeader li .currentStep
        {
            background-color: #C36615;
        }
        #wizHeader li .currentStep:after
        {
            border-left-color: #C36615 !important;
        }
        #wizHeader li .nextStep
        {
            background-color: #C2C2C2;
        }
        #wizHeader li .nextStep:after
        {
            border-left-color: #C2C2C2 !important;
        }
        #wizHeader
        {
            list-style: none;
            overflow: hidden;
            font: 15px Helvetica, Arial, Sans-Serif;
            margin: 0px;
            margin-top: 10px;
            padding: 0px;
        }
        #wizHeader li
        {
            float: left;
        }
        #wizHeader li a
        {
            color: white;
            text-decoration: none;
            padding: 5px 0 5px 25px;
            background: brown; /* fallback color */
            background: hsla(34,85%,35%,1);
            position: relative;
            display: block;
            float: left;
        }
        #wizHeader li a:after
        {
            content: " ";
            display: block;
            width: 0;
            height: 0;
            border-top: 50px solid transparent; /* Go big on the size, and let overflow hide */
            border-bottom: 50px solid transparent;
            border-left: 30px solid hsla(34,85%,35%,1);
            position: absolute;
            top: 50%;
            margin-top: -50px;
            left: 100%;
            z-index: 2;
        }
        #wizHeader li a:before
        {
            content: " ";
            display: block;
            width: 0;
            height: 0;
            border-top: 50px solid transparent;
            border-bottom: 50px solid transparent;
            border-left: 30px solid white;
            position: absolute;
            top: 50%;
            margin-top: -50px;
            margin-left: 1px;
            left: 100%;
            z-index: 1;
        }
        #wizHeader li:first-child a
        {
            padding-left: 10px;
        }
        #wizHeader li:last-child
        {
            padding-right: 50px;
        }
        #wizHeader li a:hover
        {
            background: #FE9400;
        }
        #wizHeader li a:hover:after
        {
            border-left-color: #FE9400 !important;
        }
        .content
        {
            height: 150px;
            padding-top: 75px;
            text-align: center;
            background-color: #F9F9F9;
            font-size: 48px;
        }
        .wizardcontent
        {
            min-height: 300px;
            min-width: 1200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <table style="width: 95%; padding: 5px 5px 5px 5px">
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
                <asp:Wizard ID="wzPlanWeek" runat="server" DisplaySideBar="false" 
                    ActiveStepIndex="0" onfinishbuttonclick="wzPlanWeek_Click">
                    <WizardSteps>
                        <asp:WizardStep ID="WizardStep1" runat="server" Title="Review Mission & Goals">
                            <div class="wizardcontent">
                                <uc1:ReviewMission ID="ReviewMission1" runat="server" />
                            </div>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep2" runat="server" Title="Schedule Goals">
                            <div class="wizardcontent">
                                <uc2:GoalsAndSteps ID="GoalsAndSteps1" runat="server" />
                            </div>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep3" runat="server" Title="Schedule Compass">
                            <div class="wizardcontent">
                                <uc3:WeeklyCompass ID="WeeklyCompass1" runat="server" />
                            </div>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep4" runat="server" Title="Schedule Tasks">
                            <div class="wizardcontent">
                                <uc4:WeekView ID="WeekView1" runat="server" />
                            </div>
                        </asp:WizardStep>
                    </WizardSteps>
                    <HeaderTemplate>
                        <ul id="wizHeader">
                            <asp:Repeater ID="SideBarList" runat="server">
                                <ItemTemplate>
                                    <li><a class="<%# GetClassForWizardStep(Container.DataItem) %>" title="<%#Eval("Name")%>">
                                        <%# Eval("Name")%></a> </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </HeaderTemplate>
                </asp:Wizard>
            </td>
        </tr>
    </table>
    <input id="hdnCurrentDate" name="hdnCurrentDate" runat="server" type="hidden" />
    <input id="hdnShowWorkWeekOnly" name="hdnShowWorkWeekOnly" runat="server" type="hidden" />
    <script type="text/javascript">
        function showCalendar() {
            ContentPlaceHolder1_calForDate.displayCalendar(event);
        }
    </script>
</asp:Content>
