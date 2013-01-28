<%@ Page Title="" Language="C#" MasterPageFile="~/AppPages/MasterPages/Site.Master"
    AutoEventWireup="true" CodeBehind="ViewGoals.aspx.cs" Inherits="MyPlanner.AppPages.ViewGoals" %>

<%@ Register src="GoalsAndSteps.ascx" tagname="GoalsAndSteps" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:GoalsAndSteps ID="GoalsAndSteps1" runat="server" />
<asp:ScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
</asp:Content>
