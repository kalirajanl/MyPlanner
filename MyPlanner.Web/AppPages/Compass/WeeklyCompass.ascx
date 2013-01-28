<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WeeklyCompass.ascx.cs"
    Inherits="MyPlanner.AppPages.WeeklyCompass" %>
<table style="width: 95%; padding: 5px 5px 5px 5px">
    <tr>
        <td>
            <asp:GridView runat="server" CssClass="tableClass" AutoGenerateColumns="False" SkinID="TaskList"
                PageSize="25" ID="gvMyWeeklyCompass" OnRowDataBound="gvMyWeeklyCompass_OnRowDataBound">
                <PagerStyle CssClass="hideControl" />
                <Columns>
                    <asp:BoundField DataField="BigRockID" HeaderText="BigRock ID">
                        <ItemStyle CssClass="hideControl" />
                        <HeaderStyle CssClass="hideControl" />
                        <FooterStyle CssClass="hideControl" />
                        <ControlStyle CssClass="hideControl" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AsCompassRole.CompassRoleName" HeaderText="Compass Role">
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BigRockName" HeaderText="BigRock">
                        <ControlStyle Width="600px" />
                        <ItemStyle Width="600px" />
                        <HeaderStyle Width="600px" />
                        <FooterStyle Width="600px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<input id="hdnCurrentDate" name="hdnCurrentDate" runat="server" type="hidden" />
<input id="hdnShowWorkWeekOnly" name="hdnShowWorkWeekOnly" runat="server" type="hidden" />
<input id="hdnBigRockID" name="hdnBigRockID" runat="server" type="hidden" />
<div id="<%=this.ClientID%>myMenu" class="contextMenu">
    <table style='width: 100%;'>
        <tr>
            <td onclick="<%=this.ClientID%>fnAdd();">
                Add Big Rock
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnEdit();">
                Edit Big Rock
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnDelete();">
                Delete Big Rock
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnAddCompassRole();">
                Add Compass Role
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript">

var rowid = 0;

 function <%=this.ClientID%>fnAddCompassRole() {
        hideMenus();
        var returnValue = showAddCompassRole();
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('addCompassRole', rowid)
        }
    }


    function <%=this.ClientID%>fnAdd() {
        hideMenus();
        var returnValue = showAddBigRock(document.getElementById('<%=this.ClientID%>_hdnCurrentDate').value);
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('addBigRock', rowid)
        }
    }

    function hideMenus() {
        $.each($('.contextMenu'), function () {
            $(this).hide();
        });
    }

    hideMenus();

        function <%=this.ClientID%>fnEdit() {
        hideMenus();
        if (rowid.substring(0, 1) == '-') 
        {
            alert('you cannot edit a blank row');
        }
        else 
        {
        var returnValue = showEditBigRock(rowid);
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('editbigrock', rowid);
        }
        }
    }

    function <%=this.ClientID%>fnDelete() {
        hideMenus();
        if (rowid.substring(0, 1) == '-') 
        {
            alert('you cannot edit a blank row');
        }
        else 
        {
        document.getElementById('<%=this.ClientID%>_hdnBigRockID').value = rowid;
        __doPostBack('deletebigrock', rowid);
        }
    }

    $(document).ready(function () {
        hideMenus();
        var gridID = '<%=this.ClientID%>' + '_gvMyWeeklyCompass';
        $("table[id$='" + gridID + "'] > tbody > tr").bind('contextmenu', function (e) {
            hideMenus();
            e.preventDefault();
            rowid = $(this).children(':first-child').text();
            if (!isNaN(rowid)) {
                $("#<%=this.ClientID%>myMenu").css({
                    top: e.pageY + "px",
                    left: e.pageX + "px",
                    position: 'absolute'
                });
                $("#<%=this.ClientID%>myMenu").show();
            }
        });
    });
</script>
