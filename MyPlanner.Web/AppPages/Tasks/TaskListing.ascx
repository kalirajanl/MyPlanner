<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaskListing.ascx.cs"
    Inherits="MyPlanner.AppPages.TaskListing" %>
<div>
    <asp:GridView runat="server" CssClass="tableClass" AutoGenerateColumns="False" SkinID="TaskList"
        PageSize="25" ID="gvMyTasks" OnRowDataBound="gvMyTasks_OnRowDataBound">
        <PagerStyle CssClass="hideControl" />
        <Columns>
            <asp:BoundField DataField="TaskID" HeaderText="Task ID">
                <ItemStyle CssClass="hideControl" />
                <HeaderStyle CssClass="hideControl" />
                <FooterStyle CssClass="hideControl" />
                <ControlStyle CssClass="hideControl" />
            </asp:BoundField>
            <asp:BoundField DataField="StatusText" HeaderText="Status">
                <ControlStyle Width="75px" />
                <ItemStyle Width="75px" />
                <HeaderStyle Width="75px" />
                <FooterStyle Width="75px" />
            </asp:BoundField>
            <asp:BoundField DataField="PriorityText" HeaderText="ABC">
                <ControlStyle Width="30px" />
                <ItemStyle Width="30px" />
                <HeaderStyle Width="30px" />
                <FooterStyle Width="30px" />
            </asp:BoundField>
            <asp:BoundField DataField="TaskName" HeaderText="Task">
                <ControlStyle Width="275px" />
                <ItemStyle Width="275px" />
                <HeaderStyle Width="275px" />
                <FooterStyle Width="275px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</div>
<input id="hdnTaskID" name="hdnTaskID" runat="server" type="hidden" />
<input id="hdnTaskStatusID" name="hdnTaskStatusID" runat="server" type="hidden" />
<input id="hdnCurrentDate" name="hdnCurrentDate" runat="server" type="hidden" />
<input id="hdnShowPriority" name="hdnShowPriority" runat="server" type="hidden" />
<input id="hdnShowStatus" name="hdnShowStatus" runat="server" type="hidden" />
<div id="<%=this.ClientID%>myMenu" class="contextMenu">
    <table style='width: 100%;'>
        <tr>
            <td onclick="<%=this.ClientID%>fnAdd();">
                Add Task
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnEdit();">
                Edit Task
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnDelete();">
                Delete Task
            </td>
        </tr>
    </table>
</div>
<div id="<%=this.ClientID%>goalStatusMenu" class="contextMenu">
    <table style='width: 100%;'>
        <tr>
            <td onclick="<%=this.ClientID%>fnupdateStatus(1);">
                Normal
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnupdateStatus(2);">
                In Progress
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnupdateStatus(3);">
                Forwarded
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnupdateStatus(4);">
                Completed
            </td>
        </tr>
        <tr>
            <td onclick="<%=this.ClientID%>fnupdateStatus(5);">
                Delegated
            </td>
        </tr>
    </table>
</div>
<script language="javascript" type="text/javascript">

    var rowid = 0;

    function <%=this.ClientID%>fnAdd() {
        hideMenus();
        var returnValue = showAddTask(document.getElementById('<%=this.ClientID%>_hdnCurrentDate').value);
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('addtask', rowid)
        }
    }

    function hideMenus() {
        $.each($('.contextMenu'), function () {
            $(this).hide();
        });
    }

    hideMenus();

    function <%=this.ClientID%>fnupdateStatus(statusid) {
        hideMenus();
        if (statusid != '3') {
            document.getElementById('<%=this.ClientID%>_hdnTaskID').value = rowid;
            document.getElementById( '<%=this.ClientID%>_hdnTaskStatusID').value = statusid;
            __doPostBack('updatetaskstatus', rowid);
        }
        else {
            var returnValue = showForwardTask(rowid);
            if ((returnValue == 1) || (Boolean(window.chrome))) {
                __doPostBack('edittask', rowid);
            }
        }
    }

    function <%=this.ClientID%>fnEdit() {
        hideMenus();
        if (rowid.substring(0, 1) == '-') 
        {
            alert('you cannot edit a blank row');
        }
        else 
        {
        var returnValue = showEditTask(rowid);
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('edittask', rowid);
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
        document.getElementById('<%=this.ClientID%>_hdnTaskID').value = rowid;
        __doPostBack('deletetask', rowid);
        }
    }

    $(document).ready(function () {
        hideMenus();
        var gridID = '<%=this.ClientID%>' + '_gvMyTasks';
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

    function <%=this.ClientID%>showStatusMenu(ctrlid) {
        $(document).ready(function () {
            $("#" + ctrlid).bind('click', function (e) {
                hideMenus();

                e.preventDefault();
                rowid = ctrlid.substring(1);
                $("#<%=this.ClientID%>goalStatusMenu").css({
                    top: e.pageY + "px",
                    left: e.pageX + "px",
                    position: 'absolute'
                });
                $("#<%=this.ClientID%>goalStatusMenu").show();
            });
        });
    }

</script>
