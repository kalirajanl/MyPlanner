<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="MyPlanner.AppPages.UserControls.Header" %>
<%@ Register Src="Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<div id="header">
    <div id="logo">
        <div id="logo_text">
            <h1>
                MyPlanner</h1>
        </div>
    </div>
    <uc1:Menu ID="Menu1" runat="server" />
</div>
