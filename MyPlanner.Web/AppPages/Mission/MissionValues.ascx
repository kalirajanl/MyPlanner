<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MissionValues.ascx.cs"
    Inherits="MyPlanner.AppPages.ReviewMission" %>
<table style="width: 95%; min-height: 530px; padding: 5px 5px 5px 5px">
    <tr>
        <td style="width: 50%;">
            <table style="width: 100%">
                <tr>
                    <td style="min-width: 600px">
                        <div>
                            <asp:GridView runat="server" CssClass="tableClass" AutoGenerateColumns="False" SkinID="GridView"
                                PageSize="25" ID="gvMyMission" Width="100%" OnRowDataBound="OnMissionRowDataBound">
                                <PagerStyle CssClass="hideControl" />
                                <Columns>
                                    <asp:BoundField DataField="MissionID" HeaderText="Mission ID">
                                        <ItemStyle CssClass="hideControl" />
                                        <HeaderStyle CssClass="hideControl" />
                                        <FooterStyle CssClass="hideControl" />
                                        <ControlStyle CssClass="hideControl" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MissionTitle" HeaderText="Title"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
        <td>
            &nbsp;
        </td>
        <td style="width: 50%">
            <table style="width: 100%">
                <tr>
                    <td style="min-width: 600px">
                        <div>
                            <asp:GridView runat="server" CssClass="tableClass" AutoGenerateColumns="False" SkinID="GridView"
                                PageSize="25" ID="gvMyValues" Width="100%" OnRowDataBound="OnValueRowDataBound">
                                <PagerStyle CssClass="hideControl" />
                                <Columns>
                                    <asp:BoundField DataField="ValueID" HeaderText="Value ID">
                                        <ItemStyle CssClass="hideControl" />
                                        <HeaderStyle CssClass="hideControl" />
                                        <FooterStyle CssClass="hideControl" />
                                        <ControlStyle CssClass="hideControl" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ValueTitle" HeaderText="Title"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<input id="hdnMissionID" name="hdnMissionID" runat="server" type="hidden" />
<input id="hdnValueID" name="hdnValueID" runat="server" type="hidden" />
<div id="<%=this.ClientID%>myMissionMenu" class="contextMenu">
    <table style='width: 100%;'>
        <tr>
            <td onclick="<%=this.ClientID%>fnAddMission();">
                Add Mission
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnEditMission();">
                Edit Mission
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnDeleteMission();">
                Delete Mission
            </td>
        </tr>
    </table>
</div>
<div id="<%=this.ClientID%>myValueMenu" class="contextMenu">
    <table style='width: 100%;'>
        <tr>
            <td onclick="<%=this.ClientID%>fnAddValue();">
                Add Value
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnEditValue();">
                Edit Value
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnDeleteValue();">
                Delete Value
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript">

    var rowid = 0;

    function hideMenus() {
        $.each($('.contextMenu'), function () {
            $(this).hide();
        });
    }

    hideMenus();

    function <%=this.ClientID%>fnAddMission() {
        hideMenus();
        var returnValue = showAddMission();
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('addmission', rowid);
        }
    }

    function <%=this.ClientID%>fnEditMission() {
        hideMenus();
        if (rowid.substring(0, 1) == '-') 
        {
            alert('you cannot edit a blank row');
        }
        else 
        {
        var returnValue = showEditMission(rowid);
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('editmission', rowid);
        }
        }
    }

    function <%=this.ClientID%>fnDeleteMission() {
        hideMenus();
        if (rowid.substring(0, 1) == '-') 
        {
            alert('you cannot edit a blank row');
        }
        else 
        {
        document.getElementById('<%=this.ClientID%>_hdnMissionID').value = rowid;
        __doPostBack('deletemission', rowid);
        }
    }

        function <%=this.ClientID%>fnAddValue() {
        hideMenus();
        var returnValue = showAddValue();
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('addvalue', rowid)
        }
        }
    

    function <%=this.ClientID%>fnEditValue() {
        hideMenus();
        if (rowid.substring(0, 1) == '-') 
        {
            alert('you cannot edit a blank row');
        }
        else 
        {
        var returnValue = showEditValue(rowid);
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('editvalue', rowid);
        }
        }
    }

    function <%=this.ClientID%>fnDeleteValue() {
        hideMenus();
        if (rowid.substring(0, 1) == '-') 
        {
            alert('you cannot edit a blank row');
        }
        else 
        {
        document.getElementById('<%=this.ClientID%>_hdnValueID').value = rowid;
        __doPostBack('deletevalue', rowid);
        }
    }

     $(document).ready(function () {
        hideMenus();
        var gridID = '<%=this.ClientID%>' + '_gvMyMission';
        $("table[id$='" + gridID + "'] > tbody > tr").bind('contextmenu', function (e) {
            hideMenus();
            e.preventDefault();
            rowid = $(this).children(':first-child').text();
            if (!isNaN(rowid)) {
                $("#<%=this.ClientID%>myMissionMenu").css({
                    top: e.pageY + "px",
                    left: e.pageX + "px",
                    position: 'absolute'
                });
                $("#<%=this.ClientID%>myMissionMenu").show();
            }
        });
        gridID = '<%=this.ClientID%>' + '_gvMyValues';
        $("table[id$='" + gridID + "'] > tbody > tr").bind('contextmenu', function (e) {
            hideMenus();
            e.preventDefault();
            rowid = $(this).children(':first-child').text();
            if (!isNaN(rowid)) {
                $("#<%=this.ClientID%>myValueMenu").css({
                    top: e.pageY + "px",
                    left: e.pageX + "px",
                    position: 'absolute'
                });
                $("#<%=this.ClientID%>myValueMenu").show();
            }
        });
    });

    

</script>
