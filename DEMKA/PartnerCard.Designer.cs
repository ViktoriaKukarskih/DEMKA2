namespace DEMKA
{
    partial class PartnerCard
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHistory = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(21, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(143, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Тип и наименование";
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(21, 22);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(70, 16);
            this.lblDirector.TabIndex = 1;
            this.lblDirector.Text = "Директор";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(21, 38);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(67, 16);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Телефон";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(327, 38);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(54, 16);
            this.lblDiscount.TabIndex = 4;
            this.lblDiscount.Text = "Скидка";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(21, 54);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(61, 16);
            this.lblRating.TabIndex = 3;
            this.lblRating.Text = "Рейтинг";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnHistory);
            this.panel1.Controls.Add(this.lblDiscount);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblRating);
            this.panel1.Controls.Add(this.lblDirector);
            this.panel1.Controls.Add(this.lblPhone);
            this.panel1.Location = new System.Drawing.Point(22, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 113);
            this.panel1.TabIndex = 5;
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(15, 73);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(182, 23);
            this.btnHistory.TabIndex = 5;
            this.btnHistory.Text = "История продаж";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // PartnerCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PartnerCard";
            this.Size = new System.Drawing.Size(510, 158);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHistory;
    }
}
