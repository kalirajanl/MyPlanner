<%@ Page Title="" Language="C#" MasterPageFile="~/AppPages/MasterPages/Site.Master"
    AutoEventWireup="true" CodeBehind="MissionView.aspx.cs" Inherits="MyPlanner.AppPages.MissionView" %>

<%@ Register src="MissionValues.ascx" tagname="MissionValues" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MissionValues ID="MissionValues1" runat="server" />
</asp:Content>
