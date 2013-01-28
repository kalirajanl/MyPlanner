<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoalsAndSteps.ascx.cs"
    Inherits="MyPlanner.AppPages.GoalsAndSteps" %>
<%@ Register Assembly="Obout.Ajax.UI" Namespace="Obout.Ajax.UI.TreeView" TagPrefix="obout" %>
<style type="text/css">
    body
    {
        font-family: Verdana;
        font-size: 11px;
        margin: 0px;
        padding: 20px;
    }
    .title
    {
        font-size: X-Large;
        padding: 20px;
        border-bottom: 2px solid gray;
    }
    .tdText
    {
        font: 11px Verdana;
        color: #333333;
    }
    .myroot .ic
    {
        display: none !important;
        height: 0px !important;
        width: 0px !important;
    }
    .myroot
    {
        background: none !important;
        padding-left: 0px !important;
    }
    .mycontainer
    {
        padding-left: 0px !important;
        margin-left: -2px !important;
    }
</style>
<script language="javascript" type="text/javascript">

    //Event will get fired while a mouse is hovered out on a node
    function clientOnNodeSelect(sender, args) {
        //alert("'OnNodeSelect' event is fired on '" + sender.getNodeText(args.node) + "'");
        var nodeText = sender.getNodeText(args.node);
        if (nodeText == 'Add Goal') {
            showAddGoal();
            __doPostBack('datechange', null);
        }
        else if (nodeText == 'Add Step') {
            var value = sender.getParentNode(args.node);
            var goalID = sender.getNodeValue(value);
            showAddGoalStep(goalID);
            __doPostBack('datechange', null);
        }
        else if (nodeText == 'My Goals') {
            alert('This action is not allowed');
        }
        else {
            var clientid = sender.getNodeValue(args.node);
            data = args.node.id;
            var goalStepID = data.substring(1);
            if (data.substring(0, 1) == 'S') {
                showEditGoalStep(clientid, goalStepID);
            }
            else {
                goalID = data.substring(1);
                //alert('editing Goal ' + goalID);
                showEditGoal(goalID);
            }
            __doPostBack('datechange', null);
        }
    }
</script>
<obout:Tree Width="300px" runat="server" RootNodeStyle-NodeCSS="myroot" RootNodeStyle-SubNodeContainerCSS="mycontainer"
    OnNodeSelect="clientOnNodeSelect" ID="ObTree" CssClass="default" />
<asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" />
<input id="hdnGoalID" name="hdnGoalID" runat="server" type="hidden" />
<input id="hdnGoalStepID" name="hdnGoalStepID" runat="server" type="hidden" />
<div id="goalMenu" class="contextMenu">
    <table style='width: 100%;'>
        <tr>
            <td onclick="fnAddGoalStep();">
                Add Step
            </td>
        </tr>
        <tr>
            <td onclick="fnEditGoal();">
                Edit Goal
            </td>
        </tr>
        <tr>
            <td onclick="fnDeleteGoal();">
                Delete Goal
            </td>
        </tr>
    </table>
</div>
<div id="goalStepMenu" class="contextMenu">
    <table style='width: 100%;'>
        <tr>
            <td onclick="fnEditGoalStep();">
                Edit Goal Step
            </td>
        </tr>
        <tr>
            <td onclick="fnDeleteGoalStep();">
                Delete Goal Step
            </td>
        </tr>
    </table>
</div>
<script language="javascript" type="text/javascript">

    var goalid = "";
    var goalstepid = "";

    function fnAddGoal() {
        hideMenus();
        var returnValue = showAddGoal();
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('addgoal', null)
        }
    }

    function fnEditGoal() {
        hideMenus();
        var returnValue = showEditGoal(goalid);
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('editgoal', null);
        }
    }

    function fnDeleteGoal() {
        hideMenus();
        document.getElementById('<%=this.ClientID%>_hdnGoalID').value = goalid;
        __doPostBack('deletegoal', goalid);
    }

    function fnAddGoalStep() {
        hideMenus();
        var returnValue = showAddGoalStep(goalid);
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('addgoalstep', null)
        }
    }

    function fnEditGoalStep() {
        hideMenus();
        var returnValue = showEditGoalStep(goalid, goalstepid);
        if ((returnValue == 1) || (Boolean(window.chrome))) {
            __doPostBack('editgoalstep', null);
        }
    }

    function fnDeleteGoalStep() {
        hideMenus();
        document.getElementById('<%=this.ClientID%>_hdnGoalStepID').value = goalstepid;
        __doPostBack('deletegoalstep', goalstepid);
    }

    function hideMenus() {
        $.each($('.contextMenu'), function () {
            $(this).hide();
        });
    }

    hideMenus();

    function showCalendar() {
        ContentPlaceHolder1_calForDate.displayCalendar(event);
    }

    function showGoalMenu(ctrlid) {
        $(document).ready(function () {
            $("#" + ctrlid).bind('contextmenu', function (e) {
                e.preventDefault();
                goalid = ctrlid.substring(1); ;
                $("#goalMenu").css({
                    top: e.pageY + "px",
                    left: e.pageX + "px",
                    position: 'absolute'
                });
                $("#goalMenu").show();
            });

        });
    }

    function showGoalStepMenu(goal, stepid, ctrlid) {
        $(document).ready(function () {
            $("#" + ctrlid).bind('contextmenu', function (e) {
                e.preventDefault();
                goalstepid = stepid;
                goalid = goal;
                $("#goalStepMenu").css({
                    top: e.pageY + "px",
                    left: e.pageX + "px",
                    position: 'absolute'
                });
                $("#goalStepMenu").show();
            });

        });
    }

    //hide when left mouse is clicked
    $(document).bind('click', function (e) {
        hideMenus();
    });

</script>
