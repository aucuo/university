namespace Keylogger
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnControll = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.trackCursorCheck = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.notificationLabel = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.EmailHeader = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.versionLabel = new System.Windows.Forms.Label();
            this.btnClose = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.header = new System.Windows.Forms.Panel();
            this.controlBox = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.timePanel = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Label();
            this.WorkTimeHeader = new System.Windows.Forms.Label();
            this.workTimeDesc = new System.Windows.Forms.Label();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.textPanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.keyList = new System.Windows.Forms.Label();
            this.LastKeysHeader = new System.Windows.Forms.Label();
            this.LastKeysDesc = new System.Windows.Forms.Label();
            this.speedPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.typingSpeed = new System.Windows.Forms.Label();
            this.TypingSpeedHeader = new System.Windows.Forms.Label();
            this.TypingSpeedDesc = new System.Windows.Forms.Label();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.workTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.header.SuspendLayout();
            this.controlBox.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel14.SuspendLayout();
            this.timePanel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.textPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.speedPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnControll
            // 
            this.btnControll.BackColor = System.Drawing.Color.White;
            this.btnControll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnControll.FlatAppearance.BorderSize = 0;
            this.btnControll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControll.Font = new System.Drawing.Font("Qanelas SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnControll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnControll.Location = new System.Drawing.Point(10, 98);
            this.btnControll.Name = "btnControll";
            this.btnControll.Size = new System.Drawing.Size(205, 40);
            this.btnControll.TabIndex = 0;
            this.btnControll.Text = "START";
            this.btnControll.UseVisualStyleBackColor = false;
            this.btnControll.Click += new System.EventHandler(this.btnControll_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Qanelas SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(10, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(205, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // trackCursorCheck
            // 
            this.trackCursorCheck.AutoSize = true;
            this.trackCursorCheck.BackColor = System.Drawing.Color.Transparent;
            this.trackCursorCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackCursorCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.trackCursorCheck.FlatAppearance.BorderSize = 0;
            this.trackCursorCheck.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.trackCursorCheck.Font = new System.Drawing.Font("Qanelas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackCursorCheck.ForeColor = System.Drawing.Color.White;
            this.trackCursorCheck.Location = new System.Drawing.Point(10, 307);
            this.trackCursorCheck.Name = "trackCursorCheck";
            this.trackCursorCheck.Size = new System.Drawing.Size(113, 23);
            this.trackCursorCheck.TabIndex = 1;
            this.trackCursorCheck.Text = "Track cursor";
            this.trackCursorCheck.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(265, 408);
            this.panel1.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.notificationLabel);
            this.panel10.Controls.Add(this.panel13);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.btnSave);
            this.panel10.Controls.Add(this.trackCursorCheck);
            this.panel10.Controls.Add(this.btnControll);
            this.panel10.Controls.Add(this.btnClear);
            this.panel10.Controls.Add(this.btnSend);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(20, 20);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(10);
            this.panel10.Size = new System.Drawing.Size(225, 346);
            this.panel10.TabIndex = 4;
            // 
            // notificationLabel
            // 
            this.notificationLabel.AutoSize = true;
            this.notificationLabel.Font = new System.Drawing.Font("Qanelas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notificationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(214)))), ((int)(((byte)(64)))));
            this.notificationLabel.Location = new System.Drawing.Point(6, 282);
            this.notificationLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.notificationLabel.Name = "notificationLabel";
            this.notificationLabel.Size = new System.Drawing.Size(60, 19);
            this.notificationLabel.TabIndex = 6;
            this.notificationLabel.Text = "Paused";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.emailInput);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(10, 39);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(205, 53);
            this.panel13.TabIndex = 5;
            // 
            // emailInput
            // 
            this.emailInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.emailInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailInput.Font = new System.Drawing.Font("Qanelas SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailInput.ForeColor = System.Drawing.Color.White;
            this.emailInput.Location = new System.Drawing.Point(0, 18);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(205, 20);
            this.emailInput.TabIndex = 2;
            this.emailInput.Text = "example@gmail.com";
            this.emailInput.WordWrap = false;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.EmailHeader);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(10, 10);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(205, 29);
            this.panel11.TabIndex = 4;
            // 
            // EmailHeader
            // 
            this.EmailHeader.AutoSize = true;
            this.EmailHeader.BackColor = System.Drawing.Color.Transparent;
            this.EmailHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.EmailHeader.Font = new System.Drawing.Font("Qanelas", 16F);
            this.EmailHeader.ForeColor = System.Drawing.Color.White;
            this.EmailHeader.Location = new System.Drawing.Point(0, 0);
            this.EmailHeader.Margin = new System.Windows.Forms.Padding(0);
            this.EmailHeader.Name = "EmailHeader";
            this.EmailHeader.Size = new System.Drawing.Size(72, 26);
            this.EmailHeader.TabIndex = 3;
            this.EmailHeader.Text = "E-mail";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClear.FlatAppearance.BorderSize = 2;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Qanelas SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(10, 144);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(205, 40);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSend.FlatAppearance.BorderSize = 2;
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Qanelas SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(10, 236);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(205, 40);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.versionLabel);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(20, 366);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panel9.Size = new System.Drawing.Size(225, 22);
            this.panel9.TabIndex = 4;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionLabel.Font = new System.Drawing.Font("Qanelas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.versionLabel.Location = new System.Drawing.Point(5, 0);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(51, 19);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "v 1.2-r";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnClose.IconSize = 25;
            this.btnClose.Location = new System.Drawing.Point(44, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.UseGdi = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.CircleMinus;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnMinimize.IconSize = 25;
            this.btnMinimize.Location = new System.Drawing.Point(13, 8);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(25, 25);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.UseGdi = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.header.Controls.Add(this.controlBox);
            this.header.Controls.Add(this.label2);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Margin = new System.Windows.Forms.Padding(0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(936, 40);
            this.header.TabIndex = 4;
            this.header.Paint += new System.Windows.Forms.PaintEventHandler(this.header_Paint);
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown_Event);
            this.header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove_Event);
            this.header.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp_Event);
            // 
            // controlBox
            // 
            this.controlBox.BackColor = System.Drawing.Color.Transparent;
            this.controlBox.Controls.Add(this.btnClose);
            this.controlBox.Controls.Add(this.btnMinimize);
            this.controlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlBox.Location = new System.Drawing.Point(855, 0);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(81, 40);
            this.controlBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Qanelas SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Keylogger";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(936, 408);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.panel4.Controls.Add(this.panel14);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(265, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(20);
            this.panel4.Size = new System.Drawing.Size(671, 408);
            this.panel4.TabIndex = 4;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.timePanel);
            this.panel14.Controls.Add(this.textPanel);
            this.panel14.Controls.Add(this.speedPanel);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(20, 20);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(10);
            this.panel14.Size = new System.Drawing.Size(631, 368);
            this.panel14.TabIndex = 4;
            // 
            // timePanel
            // 
            this.timePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.timePanel.Controls.Add(this.panel7);
            this.timePanel.Controls.Add(this.iconPictureBox3);
            this.timePanel.Location = new System.Drawing.Point(20, 20);
            this.timePanel.Margin = new System.Windows.Forms.Padding(10);
            this.timePanel.Name = "timePanel";
            this.timePanel.Padding = new System.Windows.Forms.Padding(20);
            this.timePanel.Size = new System.Drawing.Size(305, 154);
            this.timePanel.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.WorkTimeHeader);
            this.panel7.Controls.Add(this.workTimeDesc);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(20, 20);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(192, 114);
            this.panel7.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.timer);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 26);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(192, 69);
            this.panel8.TabIndex = 3;
            // 
            // timer
            // 
            this.timer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.timer.AutoSize = true;
            this.timer.BackColor = System.Drawing.Color.Transparent;
            this.timer.Font = new System.Drawing.Font("Qanelas Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(209)))), ((int)(((byte)(220)))));
            this.timer.Location = new System.Drawing.Point(1, 20);
            this.timer.Margin = new System.Windows.Forms.Padding(0);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(115, 29);
            this.timer.TabIndex = 2;
            this.timer.Text = "00:00:00";
            // 
            // WorkTimeHeader
            // 
            this.WorkTimeHeader.AutoSize = true;
            this.WorkTimeHeader.BackColor = System.Drawing.Color.Transparent;
            this.WorkTimeHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.WorkTimeHeader.Font = new System.Drawing.Font("Qanelas", 16F);
            this.WorkTimeHeader.ForeColor = System.Drawing.Color.White;
            this.WorkTimeHeader.Location = new System.Drawing.Point(0, 0);
            this.WorkTimeHeader.Margin = new System.Windows.Forms.Padding(0);
            this.WorkTimeHeader.Name = "WorkTimeHeader";
            this.WorkTimeHeader.Size = new System.Drawing.Size(109, 26);
            this.WorkTimeHeader.TabIndex = 2;
            this.WorkTimeHeader.Text = "Work time";
            this.WorkTimeHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // workTimeDesc
            // 
            this.workTimeDesc.AutoSize = true;
            this.workTimeDesc.BackColor = System.Drawing.Color.Transparent;
            this.workTimeDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.workTimeDesc.Font = new System.Drawing.Font("Qanelas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.workTimeDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.workTimeDesc.Location = new System.Drawing.Point(0, 95);
            this.workTimeDesc.Margin = new System.Windows.Forms.Padding(0);
            this.workTimeDesc.Name = "workTimeDesc";
            this.workTimeDesc.Size = new System.Drawing.Size(177, 19);
            this.workTimeDesc.TabIndex = 2;
            this.workTimeDesc.Text = "Hours, minutes, seconds";
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.ClockFour;
            this.iconPictureBox3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconPictureBox3.IconSize = 70;
            this.iconPictureBox3.Location = new System.Drawing.Point(215, 20);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(70, 114);
            this.iconPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox3.TabIndex = 4;
            this.iconPictureBox3.TabStop = false;
            this.iconPictureBox3.UseGdi = true;
            // 
            // textPanel
            // 
            this.textPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.textPanel.Controls.Add(this.panel6);
            this.textPanel.Controls.Add(this.LastKeysHeader);
            this.textPanel.Controls.Add(this.LastKeysDesc);
            this.textPanel.Location = new System.Drawing.Point(345, 20);
            this.textPanel.Margin = new System.Windows.Forms.Padding(10);
            this.textPanel.Name = "textPanel";
            this.textPanel.Padding = new System.Windows.Forms.Padding(20);
            this.textPanel.Size = new System.Drawing.Size(266, 328);
            this.textPanel.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.keyList);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(20, 46);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panel6.Size = new System.Drawing.Size(226, 243);
            this.panel6.TabIndex = 3;
            // 
            // keyList
            // 
            this.keyList.AutoSize = true;
            this.keyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyList.Font = new System.Drawing.Font("Qanelas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.keyList.ForeColor = System.Drawing.Color.White;
            this.keyList.Location = new System.Drawing.Point(0, 10);
            this.keyList.Margin = new System.Windows.Forms.Padding(0);
            this.keyList.MaximumSize = new System.Drawing.Size(226, 223);
            this.keyList.MinimumSize = new System.Drawing.Size(226, 223);
            this.keyList.Name = "keyList";
            this.keyList.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.keyList.Size = new System.Drawing.Size(226, 223);
            this.keyList.TabIndex = 0;
            // 
            // LastKeysHeader
            // 
            this.LastKeysHeader.AutoSize = true;
            this.LastKeysHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.LastKeysHeader.Font = new System.Drawing.Font("Qanelas", 16F);
            this.LastKeysHeader.ForeColor = System.Drawing.Color.White;
            this.LastKeysHeader.Location = new System.Drawing.Point(20, 20);
            this.LastKeysHeader.Name = "LastKeysHeader";
            this.LastKeysHeader.Size = new System.Drawing.Size(100, 26);
            this.LastKeysHeader.TabIndex = 2;
            this.LastKeysHeader.Text = "Last keys";
            this.LastKeysHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LastKeysDesc
            // 
            this.LastKeysDesc.AutoSize = true;
            this.LastKeysDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LastKeysDesc.Font = new System.Drawing.Font("Qanelas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastKeysDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.LastKeysDesc.Location = new System.Drawing.Point(20, 289);
            this.LastKeysDesc.Name = "LastKeysDesc";
            this.LastKeysDesc.Size = new System.Drawing.Size(113, 19);
            this.LastKeysDesc.TabIndex = 2;
            this.LastKeysDesc.Text = "Last typed text";
            // 
            // speedPanel
            // 
            this.speedPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.speedPanel.Controls.Add(this.panel2);
            this.speedPanel.Controls.Add(this.iconPictureBox2);
            this.speedPanel.Location = new System.Drawing.Point(20, 194);
            this.speedPanel.Margin = new System.Windows.Forms.Padding(10);
            this.speedPanel.Name = "speedPanel";
            this.speedPanel.Padding = new System.Windows.Forms.Padding(20);
            this.speedPanel.Size = new System.Drawing.Size(305, 154);
            this.speedPanel.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.TypingSpeedHeader);
            this.panel2.Controls.Add(this.TypingSpeedDesc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(20, 20);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 114);
            this.panel2.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.typingSpeed);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(192, 69);
            this.panel5.TabIndex = 3;
            // 
            // typingSpeed
            // 
            this.typingSpeed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.typingSpeed.AutoSize = true;
            this.typingSpeed.BackColor = System.Drawing.Color.Transparent;
            this.typingSpeed.Font = new System.Drawing.Font("Qanelas Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typingSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(209)))), ((int)(((byte)(220)))));
            this.typingSpeed.Location = new System.Drawing.Point(1, 23);
            this.typingSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.typingSpeed.Name = "typingSpeed";
            this.typingSpeed.Size = new System.Drawing.Size(79, 29);
            this.typingSpeed.TabIndex = 2;
            this.typingSpeed.Text = "0 c/m";
            // 
            // TypingSpeedHeader
            // 
            this.TypingSpeedHeader.AutoSize = true;
            this.TypingSpeedHeader.BackColor = System.Drawing.Color.Transparent;
            this.TypingSpeedHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.TypingSpeedHeader.Font = new System.Drawing.Font("Qanelas", 16F);
            this.TypingSpeedHeader.ForeColor = System.Drawing.Color.White;
            this.TypingSpeedHeader.Location = new System.Drawing.Point(0, 0);
            this.TypingSpeedHeader.Margin = new System.Windows.Forms.Padding(0);
            this.TypingSpeedHeader.Name = "TypingSpeedHeader";
            this.TypingSpeedHeader.Size = new System.Drawing.Size(145, 26);
            this.TypingSpeedHeader.TabIndex = 2;
            this.TypingSpeedHeader.Text = "Typing speed";
            this.TypingSpeedHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypingSpeedDesc
            // 
            this.TypingSpeedDesc.AutoSize = true;
            this.TypingSpeedDesc.BackColor = System.Drawing.Color.Transparent;
            this.TypingSpeedDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TypingSpeedDesc.Font = new System.Drawing.Font("Qanelas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypingSpeedDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.TypingSpeedDesc.Location = new System.Drawing.Point(0, 95);
            this.TypingSpeedDesc.Margin = new System.Windows.Forms.Padding(0);
            this.TypingSpeedDesc.Name = "TypingSpeedDesc";
            this.TypingSpeedDesc.Size = new System.Drawing.Size(80, 19);
            this.TypingSpeedDesc.TabIndex = 2;
            this.TypingSpeedDesc.Text = "Chars/min";
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.GaugeSimpleHigh;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 70;
            this.iconPictureBox2.Location = new System.Drawing.Point(215, 20);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(70, 114);
            this.iconPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox2.TabIndex = 4;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.UseGdi = true;
            // 
            // workTimer
            // 
            this.workTimer.Interval = 10;
            this.workTimer.Tick += new System.EventHandler(this.workTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(936, 448);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.controlBox.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.timePanel.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            this.textPanel.ResumeLayout(false);
            this.textPanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.speedPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnControll;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox trackCursorCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label versionLabel;
        private FontAwesome.Sharp.IconPictureBox btnClose;
        private FontAwesome.Sharp.IconPictureBox btnMinimize;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Panel controlBox;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel speedPanel;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label TypingSpeedHeader;
        private System.Windows.Forms.Label typingSpeed;
        private System.Windows.Forms.Label TypingSpeedDesc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel textPanel;
        private System.Windows.Forms.Label LastKeysHeader;
        private System.Windows.Forms.Label LastKeysDesc;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.Label WorkTimeHeader;
        private System.Windows.Forms.Label workTimeDesc;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label keyList;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.Label EmailHeader;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Timer workTimer;
        private System.Windows.Forms.Label notificationLabel;
        private System.Windows.Forms.Button btnClear;
    }
}

