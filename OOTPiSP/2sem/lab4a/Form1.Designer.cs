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
            this.subscribersBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.paymentsBox = new System.Windows.Forms.ListBox();
            this.addSubscriber = new System.Windows.Forms.Button();
            this.editSubscriber = new System.Windows.Forms.Button();
            this.deleteSubscriber = new System.Windows.Forms.Button();
            this.addPayment = new System.Windows.Forms.Button();
            this.editPayment = new System.Windows.Forms.Button();
            this.deletePayment = new System.Windows.Forms.Button();
            this.formatText = new System.Windows.Forms.Button();
            this.formatHTML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Subscribers";
            // 
            // subscribersBox
            // 
            this.subscribersBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.subscribersBox.FormattingEnabled = true;
            this.subscribersBox.ItemHeight = 15;
            this.subscribersBox.Location = new System.Drawing.Point(12, 31);
            this.subscribersBox.Name = "subscribersBox";
            this.subscribersBox.Size = new System.Drawing.Size(513, 169);
            this.subscribersBox.TabIndex = 4;
            this.subscribersBox.SelectedIndexChanged += new System.EventHandler(this.groupBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Payments";
            // 
            // paymentsBox
            // 
            this.paymentsBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.paymentsBox.FormattingEnabled = true;
            this.paymentsBox.ItemHeight = 15;
            this.paymentsBox.Location = new System.Drawing.Point(12, 227);
            this.paymentsBox.Name = "paymentsBox";
            this.paymentsBox.Size = new System.Drawing.Size(513, 169);
            this.paymentsBox.TabIndex = 4;
            // 
            // addSubscriber
            // 
            this.addSubscriber.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addSubscriber.Location = new System.Drawing.Point(531, 31);
            this.addSubscriber.Name = "addSubscriber";
            this.addSubscriber.Size = new System.Drawing.Size(221, 23);
            this.addSubscriber.TabIndex = 5;
            this.addSubscriber.Text = "Добавить абонента";
            this.addSubscriber.UseVisualStyleBackColor = false;
            this.addSubscriber.Click += new System.EventHandler(this.addSubscriber_Click);
            // 
            // editSubscriber
            // 
            this.editSubscriber.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.editSubscriber.Location = new System.Drawing.Point(531, 60);
            this.editSubscriber.Name = "editSubscriber";
            this.editSubscriber.Size = new System.Drawing.Size(221, 23);
            this.editSubscriber.TabIndex = 5;
            this.editSubscriber.Text = "Редактировать абонента";
            this.editSubscriber.UseVisualStyleBackColor = false;
            this.editSubscriber.Click += new System.EventHandler(this.editSubscriber_Click);
            // 
            // deleteSubscriber
            // 
            this.deleteSubscriber.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.deleteSubscriber.Location = new System.Drawing.Point(531, 89);
            this.deleteSubscriber.Name = "deleteSubscriber";
            this.deleteSubscriber.Size = new System.Drawing.Size(221, 23);
            this.deleteSubscriber.TabIndex = 5;
            this.deleteSubscriber.Text = "Удалить абонента";
            this.deleteSubscriber.UseVisualStyleBackColor = false;
            this.deleteSubscriber.Click += new System.EventHandler(this.deleteSubscriber_Click);
            // 
            // addPayment
            // 
            this.addPayment.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addPayment.Location = new System.Drawing.Point(531, 227);
            this.addPayment.Name = "addPayment";
            this.addPayment.Size = new System.Drawing.Size(221, 23);
            this.addPayment.TabIndex = 5;
            this.addPayment.Text = "Добавить платеж";
            this.addPayment.UseVisualStyleBackColor = false;
            this.addPayment.Click += new System.EventHandler(this.addGrade_Click);
            // 
            // editPayment
            // 
            this.editPayment.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.editPayment.Location = new System.Drawing.Point(531, 256);
            this.editPayment.Name = "editPayment";
            this.editPayment.Size = new System.Drawing.Size(221, 23);
            this.editPayment.TabIndex = 5;
            this.editPayment.Text = "Редактировать платеж";
            this.editPayment.UseVisualStyleBackColor = false;
            this.editPayment.Click += new System.EventHandler(this.editPayment_Click);
            // 
            // deletePayment
            // 
            this.deletePayment.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.deletePayment.Location = new System.Drawing.Point(531, 285);
            this.deletePayment.Name = "deletePayment";
            this.deletePayment.Size = new System.Drawing.Size(221, 23);
            this.deletePayment.TabIndex = 5;
            this.deletePayment.Text = "Удалить платеж";
            this.deletePayment.UseVisualStyleBackColor = false;
            this.deletePayment.Click += new System.EventHandler(this.deletePayment_Click);
            // 
            // formatText
            // 
            this.formatText.BackColor = System.Drawing.SystemColors.HotTrack;
            this.formatText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.formatText.Location = new System.Drawing.Point(531, 118);
            this.formatText.Name = "formatText";
            this.formatText.Size = new System.Drawing.Size(221, 23);
            this.formatText.TabIndex = 6;
            this.formatText.Text = "Представить текстом";
            this.formatText.UseVisualStyleBackColor = false;
            this.formatText.Click += new System.EventHandler(this.formatText_Click);
            // 
            // formatHTML
            // 
            this.formatHTML.BackColor = System.Drawing.Color.OrangeRed;
            this.formatHTML.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.formatHTML.Location = new System.Drawing.Point(531, 147);
            this.formatHTML.Name = "formatHTML";
            this.formatHTML.Size = new System.Drawing.Size(221, 23);
            this.formatHTML.TabIndex = 6;
            this.formatHTML.Text = "Представить html";
            this.formatHTML.UseVisualStyleBackColor = false;
            this.formatHTML.Click += new System.EventHandler(this.formatHTML_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(761, 408);
            this.Controls.Add(this.formatHTML);
            this.Controls.Add(this.formatText);
            this.Controls.Add(this.deletePayment);
            this.Controls.Add(this.deleteSubscriber);
            this.Controls.Add(this.editPayment);
            this.Controls.Add(this.addPayment);
            this.Controls.Add(this.editSubscriber);
            this.Controls.Add(this.addSubscriber);
            this.Controls.Add(this.paymentsBox);
            this.Controls.Add(this.subscribersBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Sonya Zirka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private ListBox subscribersBox;
        private Label label2;
        private ListBox paymentsBox;
        private Button addSubscriber;
        private Button editSubscriber;
        private Button deleteSubscriber;
        private Button addPayment;
        private Button editPayment;
        private Button deletePayment;
        private Button formatText;
        private Button formatHTML;
    }
}