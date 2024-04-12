namespace lab2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupsBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gradesBox = new System.Windows.Forms.ListBox();
            this.addGroup = new System.Windows.Forms.Button();
            this.editGroup = new System.Windows.Forms.Button();
            this.deleteGroup = new System.Windows.Forms.Button();
            this.addExam = new System.Windows.Forms.Button();
            this.editGrade = new System.Windows.Forms.Button();
            this.deleteGrade = new System.Windows.Forms.Button();
            this.exportGrade = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Группы";
            // 
            // groupsBox
            // 
            this.groupsBox.FormattingEnabled = true;
            this.groupsBox.ItemHeight = 15;
            this.groupsBox.Location = new System.Drawing.Point(12, 81);
            this.groupsBox.Name = "groupsBox";
            this.groupsBox.Size = new System.Drawing.Size(205, 169);
            this.groupsBox.TabIndex = 4;
            this.groupsBox.SelectedIndexChanged += new System.EventHandler(this.groupBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Оценки";
            // 
            // gradesBox
            // 
            this.gradesBox.FormattingEnabled = true;
            this.gradesBox.ItemHeight = 15;
            this.gradesBox.Location = new System.Drawing.Point(223, 81);
            this.gradesBox.Name = "gradesBox";
            this.gradesBox.Size = new System.Drawing.Size(832, 169);
            this.gradesBox.TabIndex = 4;
            // 
            // addGroup
            // 
            this.addGroup.Location = new System.Drawing.Point(12, 256);
            this.addGroup.Name = "addGroup";
            this.addGroup.Size = new System.Drawing.Size(205, 23);
            this.addGroup.TabIndex = 5;
            this.addGroup.Text = "Добавить класс";
            this.addGroup.UseVisualStyleBackColor = true;
            this.addGroup.Click += new System.EventHandler(this.addGroup_Click);
            // 
            // editGroup
            // 
            this.editGroup.Location = new System.Drawing.Point(12, 285);
            this.editGroup.Name = "editGroup";
            this.editGroup.Size = new System.Drawing.Size(205, 23);
            this.editGroup.TabIndex = 5;
            this.editGroup.Text = "Редактировать класс";
            this.editGroup.UseVisualStyleBackColor = true;
            this.editGroup.Click += new System.EventHandler(this.editGroup_Click);
            // 
            // deleteGroup
            // 
            this.deleteGroup.Location = new System.Drawing.Point(12, 314);
            this.deleteGroup.Name = "deleteGroup";
            this.deleteGroup.Size = new System.Drawing.Size(205, 23);
            this.deleteGroup.TabIndex = 5;
            this.deleteGroup.Text = "Удалить класс";
            this.deleteGroup.UseVisualStyleBackColor = true;
            this.deleteGroup.Click += new System.EventHandler(this.deleteGroup_Click);
            // 
            // addExam
            // 
            this.addExam.Location = new System.Drawing.Point(223, 256);
            this.addExam.Name = "addExam";
            this.addExam.Size = new System.Drawing.Size(832, 23);
            this.addExam.TabIndex = 5;
            this.addExam.Text = "Добавить оценку";
            this.addExam.UseVisualStyleBackColor = true;
            this.addExam.Click += new System.EventHandler(this.addGrade_Click);
            // 
            // editGrade
            // 
            this.editGrade.Location = new System.Drawing.Point(223, 285);
            this.editGrade.Name = "editGrade";
            this.editGrade.Size = new System.Drawing.Size(832, 23);
            this.editGrade.TabIndex = 5;
            this.editGrade.Text = "Редактировать оценку";
            this.editGrade.UseVisualStyleBackColor = true;
            this.editGrade.Click += new System.EventHandler(this.editGrade_Click);
            // 
            // deleteGrade
            // 
            this.deleteGrade.Location = new System.Drawing.Point(223, 314);
            this.deleteGrade.Name = "deleteGrade";
            this.deleteGrade.Size = new System.Drawing.Size(832, 23);
            this.deleteGrade.TabIndex = 5;
            this.deleteGrade.Text = "Удалить оценку";
            this.deleteGrade.UseVisualStyleBackColor = true;
            this.deleteGrade.Click += new System.EventHandler(this.deleteGrade_Click);
            // 
            // exportGrade
            // 
            this.exportGrade.Location = new System.Drawing.Point(223, 343);
            this.exportGrade.Name = "exportGrade";
            this.exportGrade.Size = new System.Drawing.Size(832, 23);
            this.exportGrade.TabIndex = 6;
            this.exportGrade.Text = "Экспортировать данные";
            this.exportGrade.UseVisualStyleBackColor = true;
            this.exportGrade.Click += new System.EventHandler(this.exportGrade_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Удалить Игоря";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 441);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exportGrade);
            this.Controls.Add(this.deleteGrade);
            this.Controls.Add(this.deleteGroup);
            this.Controls.Add(this.editGrade);
            this.Controls.Add(this.addExam);
            this.Controls.Add(this.editGroup);
            this.Controls.Add(this.addGroup);
            this.Controls.Add(this.gradesBox);
            this.Controls.Add(this.groupsBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private ListBox groupsBox;
        private Label label2;
        private ListBox gradesBox;
        private Button addGroup;
        private Button editGroup;
        private Button deleteGroup;
        private Button addExam;
        private Button editGrade;
        private Button deleteGrade;
        private Button exportGrade;
        private Button button1;
    }
}