<%@ Page Title="" Language="C#" MasterPageFile="~/AppPages/MasterPages/Site.Master"
    AutoEventWireup="true" CodeBehind="CompassRoles.aspx.cs" Inherits="MyPlanner.AppPages.CompassRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView runat="server" CssClass="tableClass" AutoGenerateColumns="False" SkinID="TaskList"
            PageSize="25" ID="gvMyCompassRoles" OnRowDataBound="gvMyCompassRoles_OnRowDataBound">
            <PagerStyle CssClass="hideControl" />
            <Columns>
                <asp:BoundField DataField="CompassRoleID" HeaderText="Campass Role ID">
                    <ItemStyle CssClass="hideControl" />
                    <HeaderStyle CssClass="hideControl" />
                    <FooterStyle CssClass="hideControl" />
                    <ControlStyle CssClass="hideControl" />
                </asp:BoundField>
                <asp:BoundField DataField="CompassRoleName" HeaderText="Campass Role">
                    <ControlStyle Width="275px" />
                    <ItemStyle Width="275px" />
                    <HeaderStyle Width="275px" />
                    <FooterStyle Width="275px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    <input id="hdnCompassRoleID" name="hdnCompassRoleID" runat="server" type="hidden" />
    <div id="myMenu" class="contextMenu" >
        <table style='width: 100%;'>
            <tr>
                <td onclick="fnAdd();">
                    Add&nbsp;Campass&nbsp;Role&nbsp;
                </td>
            </tr>
            <tr>
                <td onclick="fnEdit();">
                    Edit&nbsp;Campass&nbsp;Role&nbsp;
                </td>
            </tr>
            <tr>
                <td onclick="fnDelete();">
                    Delete&nbsp;Campass&nbsp;Role&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <script language="javascript" type="text/javascript">

    var rowid = 0;

    function fnAdd() {
        hideMenus();
        var returnValue = showAddCompassRole();
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('addCompassRole', rowid)
        }
    }

    function hideMenus() {
        $.each($('.contextMenu'), function () {
            $(this).hide();
        });
    }

    hideMenus();

    function fnEdit() {
        hideMenus();
        if (rowid.substring(0, 1) == '-') 
        {
            alert('you cannot edit a blank row');
        }
        else 
        {
            var returnValue = showEditCompassRole(rowid);
            if ((returnValue == 1) || (Boolean(window.chrome))) {
                __doPostBack('editCompassRole', rowid);
            }
        }
    }

    function fnDelete() {
        hideMenus();
        if (rowid.substring(0, 1) == '-') {
            alert('you cannot delete a blank row');
        }
        else {
            document.getElementById('ContentPlaceHolder1_hdnCompassRoleID').value = rowid;
            __doPostBack('deleteCompassRole', rowid);
        }
    }

    $(document).ready(function () {
        hideMenus();
        var gridID = 'ContentPlaceHolder1_gvMyCompassRoles';
        $("table[id$='" + gridID + "'] > tbody > tr").bind('contextmenu', function (e) {
            hideMenus();
            e.preventDefault();
            rowid = $(this).children(':first-child').text();
            if (!isNaN(rowid)) {
                $("#myMenu").css({
                    top: e.pageY + "px",
                    left: e.pageX + "px",
                    position: 'absolute'
                });
                $("#myMenu").show();
            }
        });
    });

    </script>
</asp:Content>
