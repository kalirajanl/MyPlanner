function showAddTask(currentdate) {
    return window.showModalDialog('/AppPages/Tasks/TaskEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&currentdate=' + currentdate + '&mode=Add', null, "dialogWidth:430px;dialogHeight:275px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showEditTask(taskID) {
    return window.showModalDialog('/AppPages/Tasks/TaskEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&mode=Edit&taskid=' + taskID, null, "dialogWidth:430px;dialogHeight:260px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showForwardTask(taskID) {
    return window.showModalDialog('/AppPages/Tasks/TaskEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&mode=Forward&taskid=' + taskID, null, "dialogWidth:430px;dialogHeight:260px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showAddMission() {
    return window.showModalDialog('/AppPages/Mission/MissionValueEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&type=Mission&mode=Add', null, "dialogWidth:430px;dialogHeight:275px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showEditMission(missionID) {
    return window.showModalDialog('/AppPages/Mission/MissionValueEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&type=Mission&mode=Edit&itemid=' + missionID , null, "dialogWidth:430px;dialogHeight:275px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showAddValue() {
    return window.showModalDialog('/AppPages/Mission/MissionValueEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&type=Value&mode=Add', null, "dialogWidth:430px;dialogHeight:275px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showEditValue(valueID) {
    return window.showModalDialog('/AppPages/Mission/MissionValueEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&type=Value&mode=Edit&itemid=' + valueID, null, "dialogWidth:430px;dialogHeight:275px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showAddGoal() {
    return window.showModalDialog('/AppPages/Goals/GoalEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&mode=Add', null, "dialogWidth:430px;dialogHeight:275px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showEditGoal(goalID) {
    return window.showModalDialog('/AppPages/Goals/GoalEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&mode=Edit&goalid=' + goalID, null, "dialogWidth:430px;dialogHeight:260px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showAddGoalStep(goalID) {
    return window.showModalDialog('/AppPages/Goals/GoalStepEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&mode=Add&goalid=' + goalID + '', null, "dialogWidth:430px;dialogHeight:275px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showEditGoalStep(goalID,goalStepID) {
    return window.showModalDialog('/AppPages/Goals/GoalStepEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&mode=Edit&goalid=' + goalID + '&goalstepid=' + goalStepID, null, "dialogWidth:430px;dialogHeight:275px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showAddCompassRole() {
    return window.showModalDialog('/AppPages/Compass/CompassRoleEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&mode=Add', null, "dialogWidth:430px;dialogHeight:275px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showEditCompassRole(compassroleid) {
    return window.showModalDialog('/AppPages/Compass/CompassRoleEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&mode=Edit&itemid=' + compassroleid, null, "dialogWidth:430px;dialogHeight:275px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showAddBigRock(currentdate) {
    return window.showModalDialog('/AppPages/Compass/BigRockEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&currentdate=' + currentdate + '&mode=Add', null, "dialogWidth:430px;dialogHeight:140px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}

function showEditBigRock(bigRockID) {
    return window.showModalDialog('/AppPages/Compass/BigRockEdit.Aspx?rand=' + Math.floor(Math.random() * 100) + '&mode=Edit&itemid=' + bigRockID, null, "dialogWidth:430px;dialogHeight:140px;help:no;resizable:no;scroll:no;status:no;statusbar:no;toolbar:no;menubar:no;addressbar:no;titlebar:no;");
}
