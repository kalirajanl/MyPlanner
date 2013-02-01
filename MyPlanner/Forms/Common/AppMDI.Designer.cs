namespace MyPlanner
{
    partial class AppMDI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolDayView = new System.Windows.Forms.ToolStripButton();
            this.toolWorkWeekView = new System.Windows.Forms.ToolStripButton();
            this.toolWeekView = new System.Windows.Forms.ToolStripButton();
            this.toolMonthView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolWeeklyPlanning = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.weeklyplanning = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dayViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workWeekViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weekViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.missionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goalsStepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 516);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(793, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDayView,
            this.toolWorkWeekView,
            this.toolWeekView,
            this.toolMonthView,
            this.toolStripSeparator1,
            this.toolWeeklyPlanning,
            this.toolStripSeparator2,
            this.btnExit});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(793, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolDayView
            // 
            this.toolDayView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDayView.Image = global::MyPlanner.Properties.Resources.daily_16X16;
            this.toolDayView.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolDayView.Name = "toolDayView";
            this.toolDayView.Size = new System.Drawing.Size(23, 22);
            this.toolDayView.Text = "Day View";
            this.toolDayView.ToolTipText = "Day View";
            this.toolDayView.Click += new System.EventHandler(this.toolDayView_Click);
            // 
            // toolWorkWeekView
            // 
            this.toolWorkWeekView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolWorkWeekView.Image = global::MyPlanner.Properties.Resources.workweek_16X16;
            this.toolWorkWeekView.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolWorkWeekView.Name = "toolWorkWeekView";
            this.toolWorkWeekView.Size = new System.Drawing.Size(23, 22);
            this.toolWorkWeekView.Text = "Work Week View";
            this.toolWorkWeekView.Click += new System.EventHandler(this.toolWorkWeekView_Click);
            // 
            // toolWeekView
            // 
            this.toolWeekView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolWeekView.Image = global::MyPlanner.Properties.Resources.week_16X16;
            this.toolWeekView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolWeekView.Name = "toolWeekView";
            this.toolWeekView.Size = new System.Drawing.Size(23, 22);
            this.toolWeekView.Text = "Week View";
            this.toolWeekView.Click += new System.EventHandler(this.toolWeekView_Click);
            // 
            // toolMonthView
            // 
            this.toolMonthView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMonthView.Image = global::MyPlanner.Properties.Resources.month_16X16;
            this.toolMonthView.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolMonthView.Name = "toolMonthView";
            this.toolMonthView.Size = new System.Drawing.Size(23, 22);
            this.toolMonthView.Text = "Month View";
            this.toolMonthView.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolWeeklyPlanning
            // 
            this.toolWeeklyPlanning.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolWeeklyPlanning.Image = global::MyPlanner.Properties.Resources.plan_16X16;
            this.toolWeeklyPlanning.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolWeeklyPlanning.Name = "toolWeeklyPlanning";
            this.toolWeeklyPlanning.Size = new System.Drawing.Size(23, 22);
            this.toolWeeklyPlanning.Text = "Weekly Planning";
            this.toolWeeklyPlanning.Click += new System.EventHandler(this.toolWeeklyPlanning_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Image = global::MyPlanner.Properties.Resources.exit_16X16;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(23, 22);
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.toolStripMenuItem1,
            this.viewMenu,
            this.mastersToolStripMenuItem,
            this.toolsMenu,
            this.windowsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(793, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weeklyplanning,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "&File";
            // 
            // weeklyplanning
            // 
            this.weeklyplanning.Image = global::MyPlanner.Properties.Resources.plan_16X16;
            this.weeklyplanning.Name = "weeklyplanning";
            this.weeklyplanning.Size = new System.Drawing.Size(189, 22);
            this.weeklyplanning.Text = "&Start Weekly Planning";
            this.weeklyplanning.Click += new System.EventHandler(this.weeklyplanning_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(186, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::MyPlanner.Properties.Resources.exit_16X16;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dayViewToolStripMenuItem,
            this.workWeekViewToolStripMenuItem,
            this.weekViewToolStripMenuItem,
            this.monthViewToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem1.Text = "Calendar";
            // 
            // dayViewToolStripMenuItem
            // 
            this.dayViewToolStripMenuItem.Image = global::MyPlanner.Properties.Resources.daily_16X16;
            this.dayViewToolStripMenuItem.Name = "dayViewToolStripMenuItem";
            this.dayViewToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.dayViewToolStripMenuItem.Text = "Day View";
            this.dayViewToolStripMenuItem.Click += new System.EventHandler(this.dayViewToolStripMenuItem_Click);
            // 
            // workWeekViewToolStripMenuItem
            // 
            this.workWeekViewToolStripMenuItem.Image = global::MyPlanner.Properties.Resources.workweek_16X16;
            this.workWeekViewToolStripMenuItem.Name = "workWeekViewToolStripMenuItem";
            this.workWeekViewToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.workWeekViewToolStripMenuItem.Text = "Work Week View";
            this.workWeekViewToolStripMenuItem.Click += new System.EventHandler(this.workWeekViewToolStripMenuItem_Click);
            // 
            // weekViewToolStripMenuItem
            // 
            this.weekViewToolStripMenuItem.Image = global::MyPlanner.Properties.Resources.week_16X16;
            this.weekViewToolStripMenuItem.Name = "weekViewToolStripMenuItem";
            this.weekViewToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.weekViewToolStripMenuItem.Text = "Week View";
            this.weekViewToolStripMenuItem.Click += new System.EventHandler(this.weekViewToolStripMenuItem_Click);
            // 
            // monthViewToolStripMenuItem
            // 
            this.monthViewToolStripMenuItem.Image = global::MyPlanner.Properties.Resources.month_16X16;
            this.monthViewToolStripMenuItem.Name = "monthViewToolStripMenuItem";
            this.monthViewToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.monthViewToolStripMenuItem.Text = "Month View";
            this.monthViewToolStripMenuItem.Visible = false;
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(44, 20);
            this.viewMenu.Text = "&View";
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.toolBarToolStripMenuItem.Text = "&Toolbar";
            this.toolBarToolStripMenuItem.Click += new System.EventHandler(this.ToolBarToolStripMenuItem_Click);
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.statusBarToolStripMenuItem.Text = "&Status Bar";
            this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // mastersToolStripMenuItem
            // 
            this.mastersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.missionToolStripMenuItem,
            this.valueToolStripMenuItem,
            this.goalsStepsToolStripMenuItem});
            this.mastersToolStripMenuItem.Name = "mastersToolStripMenuItem";
            this.mastersToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.mastersToolStripMenuItem.Text = "Planning";
            // 
            // missionToolStripMenuItem
            // 
            this.missionToolStripMenuItem.Name = "missionToolStripMenuItem";
            this.missionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.missionToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.missionToolStripMenuItem.Text = "Mission";
            this.missionToolStripMenuItem.Click += new System.EventHandler(this.missionToolStripMenuItem_Click);
            // 
            // valueToolStripMenuItem
            // 
            this.valueToolStripMenuItem.Name = "valueToolStripMenuItem";
            this.valueToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.valueToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.valueToolStripMenuItem.Text = "Value";
            this.valueToolStripMenuItem.Click += new System.EventHandler(this.valueToolStripMenuItem_Click);
            // 
            // goalsStepsToolStripMenuItem
            // 
            this.goalsStepsToolStripMenuItem.Name = "goalsStepsToolStripMenuItem";
            this.goalsStepsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.goalsStepsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.goalsStepsToolStripMenuItem.Text = "Goals And Steps";
            this.goalsStepsToolStripMenuItem.Click += new System.EventHandler(this.goalsStepsToolStripMenuItem_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(61, 20);
            this.toolsMenu.Text = "&Options";
            this.toolsMenu.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(68, 20);
            this.windowsMenu.Text = "&Windows";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newWindowToolStripMenuItem.Text = "&New Window";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeAllToolStripMenuItem.Text = "C&lose All";
            this.closeAllToolStripMenuItem.Visible = false;
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(147, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.aboutToolStripMenuItem.Text = "&About ... ...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // AppMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(793, 538);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppMDI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppMDI_FormClosed);
            this.Load += new System.EventHandler(this.AppMDI_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripButton toolDayView;
        private System.Windows.Forms.ToolStripButton toolWorkWeekView;
        private System.Windows.Forms.ToolStripButton toolMonthView;
        private System.Windows.Forms.ToolStripButton toolWeeklyPlanning;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem mastersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem missionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goalsStepsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dayViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workWeekViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weekViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolWeekView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripMenuItem weeklyplanning;
    }
}



