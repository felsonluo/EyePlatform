namespace Eye.PhotoManager
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ETakeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ETakeLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESnapshotPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ETags1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ETags2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.Label();
            this.txtTags2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTags1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.button8 = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button13 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(385, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件夹";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(181, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "E:\\photo\\1980\\01";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(6, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 470);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(832, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "照片列表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(207, 197);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(407, 23);
            this.progressBar1.TabIndex = 58;
            this.progressBar1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EChecked,
            this.EId,
            this.EItemId,
            this.EName,
            this.ETakeTime,
            this.ETakeLocation,
            this.EPath,
            this.ESnapshotPath,
            this.ESize,
            this.ETags1,
            this.ETags2,
            this.EDescription});
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(822, 434);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // EChecked
            // 
            this.EChecked.HeaderText = "选择";
            this.EChecked.Name = "EChecked";
            this.EChecked.ReadOnly = true;
            // 
            // EId
            // 
            this.EId.HeaderText = "ID";
            this.EId.Name = "EId";
            this.EId.ReadOnly = true;
            this.EId.Visible = false;
            // 
            // EItemId
            // 
            this.EItemId.HeaderText = "EItemId";
            this.EItemId.Name = "EItemId";
            this.EItemId.Visible = false;
            // 
            // EName
            // 
            this.EName.HeaderText = "名称";
            this.EName.Name = "EName";
            this.EName.ReadOnly = true;
            // 
            // ETakeTime
            // 
            this.ETakeTime.HeaderText = "拍摄日期";
            this.ETakeTime.Name = "ETakeTime";
            this.ETakeTime.ReadOnly = true;
            // 
            // ETakeLocation
            // 
            this.ETakeLocation.HeaderText = "拍摄地点";
            this.ETakeLocation.Name = "ETakeLocation";
            this.ETakeLocation.ReadOnly = true;
            // 
            // EPath
            // 
            this.EPath.HeaderText = "原始路径";
            this.EPath.Name = "EPath";
            this.EPath.ReadOnly = true;
            // 
            // ESnapshotPath
            // 
            this.ESnapshotPath.HeaderText = "快照路径";
            this.ESnapshotPath.Name = "ESnapshotPath";
            this.ESnapshotPath.ReadOnly = true;
            // 
            // ESize
            // 
            this.ESize.HeaderText = "大小";
            this.ESize.Name = "ESize";
            this.ESize.ReadOnly = true;
            // 
            // ETags1
            // 
            this.ETags1.HeaderText = "人物";
            this.ETags1.Name = "ETags1";
            this.ETags1.ReadOnly = true;
            // 
            // ETags2
            // 
            this.ETags2.HeaderText = "标签";
            this.ETags2.Name = "ETags2";
            this.ETags2.ReadOnly = true;
            // 
            // EDescription
            // 
            this.EDescription.HeaderText = "描述";
            this.EDescription.Name = "EDescription";
            this.EDescription.ReadOnly = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(832, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "照片树";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(175, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(654, 423);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(7, 7);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(162, 423);
            this.treeView1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(668, 513);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 25);
            this.button2.TabIndex = 4;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(764, 14);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 25);
            this.button3.TabIndex = 5;
            this.button3.Text = "加载";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(11, 516);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(51, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "全选";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(889, 393);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(160, 113);
            this.textBox10.TabIndex = 48;
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = true;
            this.txtDescription.Location = new System.Drawing.Point(847, 395);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(32, 17);
            this.txtDescription.TabIndex = 47;
            this.txtDescription.Text = "描述";
            // 
            // txtTags2
            // 
            this.txtTags2.Location = new System.Drawing.Point(889, 362);
            this.txtTags2.Name = "txtTags2";
            this.txtTags2.ReadOnly = true;
            this.txtTags2.Size = new System.Drawing.Size(137, 23);
            this.txtTags2.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(847, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 45;
            this.label9.Text = "标签";
            // 
            // txtTags1
            // 
            this.txtTags1.Location = new System.Drawing.Point(889, 333);
            this.txtTags1.Name = "txtTags1";
            this.txtTags1.ReadOnly = true;
            this.txtTags1.Size = new System.Drawing.Size(137, 23);
            this.txtTags1.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(847, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 43;
            this.label8.Text = "人物";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(892, 299);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(160, 23);
            this.txtLocation.TabIndex = 36;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(850, 301);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(32, 17);
            this.lblLocation.TabIndex = 35;
            this.lblLocation.Text = "地点";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(847, 272);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(32, 17);
            this.lblDate.TabIndex = 33;
            this.lblDate.Text = "日期";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(889, 241);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 23);
            this.txtName.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(847, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "名称";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(896, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 147);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1003, 514);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(49, 25);
            this.button5.TabIndex = 49;
            this.button5.Text = "应用";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(578, 513);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 25);
            this.button6.TabIndex = 50;
            this.button6.Text = "删除";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(134, 515);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 23);
            this.textBox2.TabIndex = 51;
            this.textBox2.Text = "E:\\photo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 517);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "目标文件夹";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(304, 514);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(36, 25);
            this.button7.TabIndex = 53;
            this.button7.Text = "...";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(346, 515);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(84, 25);
            this.button8.TabIndex = 54;
            this.button8.Text = "图片整理";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // txtDate
            // 
            this.txtDate.CustomFormat = "yyyy-MM-dd";
            this.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDate.Location = new System.Drawing.Point(889, 270);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(160, 23);
            this.txtDate.TabIndex = 55;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(1032, 333);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(20, 25);
            this.button9.TabIndex = 56;
            this.button9.Text = "...";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1032, 360);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(20, 25);
            this.button10.TabIndex = 57;
            this.button10.Text = "...";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(889, 514);
            this.button13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(79, 25);
            this.button13.TabIndex = 60;
            this.button13.Text = "批量应用";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(15, 13);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(63, 21);
            this.checkBox2.TabIndex = 61;
            this.checkBox2.Text = "文件夹";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(84, 13);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(63, 21);
            this.checkBox3.TabIndex = 62;
            this.checkBox3.Text = "数据库";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(5, 6);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(63, 21);
            this.checkBox4.TabIndex = 63;
            this.checkBox4.Text = "已入库";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(69, 6);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(63, 21);
            this.checkBox5.TabIndex = 64;
            this.checkBox5.Text = "未入库";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(147, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 32);
            this.panel1.TabIndex = 65;
            this.panel1.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(758, 513);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 25);
            this.button4.TabIndex = 66;
            this.button4.Text = "整理并保存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 542);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTags2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTags1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片处理器";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.TextBox txtTags2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTags1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn EId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETakeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETakeLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn EPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESnapshotPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETags1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ETags2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDescription;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
    }
}

