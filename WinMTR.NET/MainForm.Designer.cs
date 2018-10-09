namespace WinMTR.NET
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.startButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addressComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.exportHTMLButton = new System.Windows.Forms.Button();
            this.exportTEXTButton = new System.Windows.Forms.Button();
            this.copyHTMLButton = new System.Windows.Forms.Button();
            this.copyTextButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.hostsListView = new WinMTR.NET.ListViewNF();
            this.columnHeaderAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLoss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderReceived = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBestPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAvgPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWorstPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_TeamId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(223, 14);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 21);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "&Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1067, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel1.Text = "MTR";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel3.Text = "  ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel2.Text = "Version";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.addressComboBox);
            this.groupBox1.Controls.Add(this.startButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 43);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Host";
            // 
            // addressComboBox
            // 
            this.addressComboBox.FormattingEnabled = true;
            this.addressComboBox.Location = new System.Drawing.Point(41, 16);
            this.addressComboBox.Name = "addressComboBox";
            this.addressComboBox.Size = new System.Drawing.Size(176, 22);
            this.addressComboBox.TabIndex = 1;
            this.addressComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addressComboBox_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.exitButton);
            this.groupBox2.Controls.Add(this.optionsButton);
            this.groupBox2.Location = new System.Drawing.Point(325, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(735, 43);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(641, 14);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(88, 21);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "E&xit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Location = new System.Drawing.Point(6, 14);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(88, 21);
            this.optionsButton.TabIndex = 3;
            this.optionsButton.Text = "&Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.exportHTMLButton);
            this.groupBox3.Controls.Add(this.exportTEXTButton);
            this.groupBox3.Controls.Add(this.copyHTMLButton);
            this.groupBox3.Controls.Add(this.copyTextButton);
            this.groupBox3.Location = new System.Drawing.Point(3, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1057, 53);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // exportHTMLButton
            // 
            this.exportHTMLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportHTMLButton.Location = new System.Drawing.Point(963, 18);
            this.exportHTMLButton.Name = "exportHTMLButton";
            this.exportHTMLButton.Size = new System.Drawing.Size(88, 21);
            this.exportHTMLButton.TabIndex = 4;
            this.exportHTMLButton.Text = "Export &HTML";
            this.exportHTMLButton.UseVisualStyleBackColor = true;
            this.exportHTMLButton.Click += new System.EventHandler(this.exportHTMLButton_Click);
            // 
            // exportTEXTButton
            // 
            this.exportTEXTButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportTEXTButton.Location = new System.Drawing.Point(865, 18);
            this.exportTEXTButton.Name = "exportTEXTButton";
            this.exportTEXTButton.Size = new System.Drawing.Size(88, 21);
            this.exportTEXTButton.TabIndex = 3;
            this.exportTEXTButton.Text = "Export &TEXT";
            this.exportTEXTButton.UseVisualStyleBackColor = true;
            this.exportTEXTButton.Click += new System.EventHandler(this.exportTEXTButton_Click);
            // 
            // copyHTMLButton
            // 
            this.copyHTMLButton.Location = new System.Drawing.Point(148, 18);
            this.copyHTMLButton.Name = "copyHTMLButton";
            this.copyHTMLButton.Size = new System.Drawing.Size(152, 21);
            this.copyHTMLButton.TabIndex = 2;
            this.copyHTMLButton.Text = "Co&py HTML to clipboard";
            this.copyHTMLButton.UseVisualStyleBackColor = true;
            this.copyHTMLButton.Click += new System.EventHandler(this.copyHTMLButton_Click);
            // 
            // copyTextButton
            // 
            this.copyTextButton.Location = new System.Drawing.Point(11, 18);
            this.copyTextButton.Name = "copyTextButton";
            this.copyTextButton.Size = new System.Drawing.Size(131, 21);
            this.copyTextButton.TabIndex = 1;
            this.copyTextButton.Text = "&Copy text to clipboard";
            this.copyTextButton.UseVisualStyleBackColor = true;
            this.copyTextButton.Click += new System.EventHandler(this.copyTextButton_Click);
            // 
            // hostsListView
            // 
            this.hostsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddress,
            this.columnHeaderNumber,
            this.columnHeaderLoss,
            this.columnHeaderSent,
            this.columnHeaderReceived,
            this.columnHeaderBestPing,
            this.columnHeaderAvgPing,
            this.columnHeaderWorstPing,
            this.columnHeaderLastPing});
            this.hostsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostsListView.FullRowSelect = true;
            this.hostsListView.GridLines = true;
            this.hostsListView.Location = new System.Drawing.Point(0, 0);
            this.hostsListView.MultiSelect = false;
            this.hostsListView.Name = "hostsListView";
            this.hostsListView.Size = new System.Drawing.Size(1063, 430);
            this.hostsListView.TabIndex = 2;
            this.hostsListView.UseCompatibleStateImageBehavior = false;
            this.hostsListView.View = System.Windows.Forms.View.Details;
            this.hostsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.hostsListView_MouseDoubleClick);
            // 
            // columnHeaderAddress
            // 
            this.columnHeaderAddress.Text = "Hostname";
            this.columnHeaderAddress.Width = 140;
            // 
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.Text = "Nr";
            this.columnHeaderNumber.Width = 30;
            // 
            // columnHeaderLoss
            // 
            this.columnHeaderLoss.Text = "Loss %";
            this.columnHeaderLoss.Width = 45;
            // 
            // columnHeaderSent
            // 
            this.columnHeaderSent.Text = "Sent";
            this.columnHeaderSent.Width = 40;
            // 
            // columnHeaderReceived
            // 
            this.columnHeaderReceived.Text = "Recv";
            this.columnHeaderReceived.Width = 40;
            // 
            // columnHeaderBestPing
            // 
            this.columnHeaderBestPing.Text = "Best";
            this.columnHeaderBestPing.Width = 50;
            // 
            // columnHeaderAvgPing
            // 
            this.columnHeaderAvgPing.Text = "Avrg";
            this.columnHeaderAvgPing.Width = 50;
            // 
            // columnHeaderWorstPing
            // 
            this.columnHeaderWorstPing.Text = "Worst";
            this.columnHeaderWorstPing.Width = 50;
            // 
            // columnHeaderLastPing
            // 
            this.columnHeaderLastPing.Text = "Last";
            this.columnHeaderLastPing.Width = 50;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gc_TeamId,
            this.gridColumn1,
            this.gc,
            this.gridColumn15,
            this.gridColumn13});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsMenu.ShowSplitItem = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowSeparatorHeight = 4;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "车间";
            this.gridColumn2.FieldName = "workshopName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gc_TeamId
            // 
            this.gc_TeamId.Caption = "班组";
            this.gc_TeamId.FieldName = "TeamId";
            this.gc_TeamId.Name = "gc_TeamId";
            this.gc_TeamId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TeamId", "合计:")});
            this.gc_TeamId.Visible = true;
            this.gc_TeamId.VisibleIndex = 1;
            this.gc_TeamId.Width = 77;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "日期";
            this.gridColumn1.FieldName = "TitleDate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // gc
            // 
            this.gc.Caption = "产量（理重）";
            this.gc.FieldName = "LogicWeight";
            this.gc.Name = "gc";
            this.gc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LogicWeight", "{0:n3}")});
            this.gc.Visible = true;
            this.gc.VisibleIndex = 3;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "磅重";
            this.gridColumn15.FieldName = "PoundWeight";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PoundWeight", "{0:n3}")});
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 4;
            this.gridColumn15.Width = 77;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "公差率";
            this.gridColumn13.DisplayFormat.FormatString = "{0:0.##}%";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "ToleranceRate";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            this.gridColumn13.Width = 77;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsMenu.EnableFooterMenu = false;
            this.gridView2.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView2.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView2.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridView2.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView2.OptionsMenu.ShowSplitItem = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.RowSeparatorHeight = 4;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "车间";
            this.gridColumn3.FieldName = "workshopName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "班组";
            this.gridColumn4.FieldName = "TeamId";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TeamId", "合计:")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 77;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "日期";
            this.gridColumn5.FieldName = "TitleDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "产量（理重）";
            this.gridColumn6.FieldName = "LogicWeight";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LogicWeight", "{0:n3}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "磅重";
            this.gridColumn7.FieldName = "PoundWeight";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PoundWeight", "{0:n3}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 77;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "公差率";
            this.gridColumn8.DisplayFormat.FormatString = "{0:0.##}%";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "ToleranceRate";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 77;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.hostsListView);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1067, 540);
            this.splitContainerControl1.SplitterPosition = 101;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 280);
            this.Name = "MainForm";
            this.Text = "MTR.NET";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private ListViewNF hostsListView;
        private System.Windows.Forms.ColumnHeader columnHeaderAddress;
        private System.Windows.Forms.ColumnHeader columnHeaderLastPing;
        private System.Windows.Forms.ColumnHeader columnHeaderAvgPing;
        private System.Windows.Forms.ColumnHeader columnHeaderSent;
        private System.Windows.Forms.ColumnHeader columnHeaderReceived;
        private System.Windows.Forms.ColumnHeader columnHeaderLoss;
        private System.Windows.Forms.ColumnHeader columnHeaderBestPing;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox addressComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exportHTMLButton;
        private System.Windows.Forms.Button exportTEXTButton;
        private System.Windows.Forms.Button copyHTMLButton;
        private System.Windows.Forms.Button copyTextButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderWorstPing;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gc_TeamId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}

