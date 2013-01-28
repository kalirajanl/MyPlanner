<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WeekView.ascx.cs" Inherits="MyPlanner.AppPages.Calendar.WeekView" %>
<%@ Register Src="../Tasks/TaskListing.ascx" TagName="TaskListing" TagPrefix="uc1" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%" runat="server" id="tblLayout">
    <tr>
        <td>
            <fieldset>
                <legend>
                    <asp:Label runat="server" ID="lblDayTitle1"></asp:Label>
                </legend>
            </fieldset>
        </td>
        <td>
            <fieldset>
                <legend>
                    <asp:Label runat="server" ID="lblDayTitle2"></asp:Label>
                </legend>
            </fieldset>
        </td>
        <td>
            <fieldset>
                <legend>
                    <asp:Label runat="server" ID="lblDayTitle3"></asp:Label>
                </legend>
            </fieldset>
        </td>
        <td>
            <fieldset>
                <legend>
                    <asp:Label runat="server" ID="lblDayTitle4"></asp:Label>
                </legend>
            </fieldset>
        </td>
        <td>
            <fieldset>
                <legend>
                    <asp:Label runat="server" ID="lblDayTitle5"></asp:Label>
                </legend>
            </fieldset>
        </td>
        <td>
            <fieldset>
                <legend>
                    <asp:Label runat="server" ID="lblDayTitle6"></asp:Label>
                </legend>
            </fieldset>
        </td>
        <td>
            <fieldset>
                <legend>
                    <asp:Label runat="server" ID="lblDayTitle7"></asp:Label>
                </legend>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td>
            <uc1:TaskListing ID="TaskListing1" runat="server" />
        </td>
        <td>
            <uc1:TaskListing ID="TaskListing2" runat="server" />
        </td>
        <td>
            <uc1:TaskListing ID="TaskListing3" runat="server" />
        </td>
        <td>
            <uc1:TaskListing ID="TaskListing4" runat="server" />
        </td>
        <td>
            <uc1:TaskListing ID="TaskListing5" runat="server" />
        </td>
        <td>
            <uc1:TaskListing ID="TaskListing6" runat="server" />
        </td>
        <td>
            <uc1:TaskListing ID="TaskListing7" runat="server" />
        </td>
    </tr>
</table>

    <input id="hdnCurrentDate" name="hdnCurrentDate" runat="server" type="hidden" />
    <input id="hdnShowWorkWeekOnly" name="hdnShowWorkWeekOnly" runat="server" type="hidden" />

