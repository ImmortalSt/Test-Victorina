namespace Test_Victorina
{
    partial class AdminDelete
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
            this.label_Thema = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.btn_DelThema = new System.Windows.Forms.Button();
            this.cB_Cataloge = new System.Windows.Forms.ComboBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_DelQuest = new System.Windows.Forms.Button();
            this.label_Quest = new System.Windows.Forms.Label();
            this.checkedLB_Quest = new System.Windows.Forms.CheckedListBox();
            this.label_Admin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Thema
            // 
            this.label_Thema.AutoSize = true;
            this.label_Thema.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Thema.Location = new System.Drawing.Point(11, 86);
            this.label_Thema.Name = "label_Thema";
            this.label_Thema.Size = new System.Drawing.Size(135, 25);
            this.label_Thema.TabIndex = 1;
            this.label_Thema.Text = "Выбор темы";
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Exit.Location = new System.Drawing.Point(881, 606);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(170, 36);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.Text = "Выход";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // btn_DelThema
            // 
            this.btn_DelThema.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_DelThema.Location = new System.Drawing.Point(872, 79);
            this.btn_DelThema.Name = "btn_DelThema";
            this.btn_DelThema.Size = new System.Drawing.Size(170, 32);
            this.btn_DelThema.TabIndex = 6;
            this.btn_DelThema.Text = "Удалить тест";
            this.btn_DelThema.UseVisualStyleBackColor = true;
            this.btn_DelThema.Click += new System.EventHandler(this.btn_DelThema_Click);
            // 
            // cB_Cataloge
            // 
            this.cB_Cataloge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cB_Cataloge.FormattingEnabled = true;
            this.cB_Cataloge.Location = new System.Drawing.Point(170, 79);
            this.cB_Cataloge.Name = "cB_Cataloge";
            this.cB_Cataloge.Size = new System.Drawing.Size(671, 32);
            this.cB_Cataloge.TabIndex = 5;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Reset.Location = new System.Drawing.Point(685, 607);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(170, 36);
            this.btn_Reset.TabIndex = 25;
            this.btn_Reset.Text = "<-";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_DelQuest
            // 
            this.btn_DelQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_DelQuest.Location = new System.Drawing.Point(872, 212);
            this.btn_DelQuest.Name = "btn_DelQuest";
            this.btn_DelQuest.Size = new System.Drawing.Size(170, 32);
            this.btn_DelQuest.TabIndex = 27;
            this.btn_DelQuest.Text = "Удалить вопрос";
            this.btn_DelQuest.UseVisualStyleBackColor = true;
            this.btn_DelQuest.Click += new System.EventHandler(this.btn_DelQuest_Click);
            // 
            // label_Quest
            // 
            this.label_Quest.AutoSize = true;
            this.label_Quest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Quest.Location = new System.Drawing.Point(11, 158);
            this.label_Quest.Name = "label_Quest";
            this.label_Quest.Size = new System.Drawing.Size(106, 25);
            this.label_Quest.TabIndex = 26;
            this.label_Quest.Text = "Вопросы:";
            // 
            // checkedLB_Quest
            // 
            this.checkedLB_Quest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedLB_Quest.FormattingEnabled = true;
            this.checkedLB_Quest.Location = new System.Drawing.Point(170, 150);
            this.checkedLB_Quest.Name = "checkedLB_Quest";
            this.checkedLB_Quest.Size = new System.Drawing.Size(671, 364);
            this.checkedLB_Quest.TabIndex = 32;
            // 
            // label_Admin
            // 
            this.label_Admin.AutoSize = true;
            this.label_Admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Admin.Location = new System.Drawing.Point(50, 9);
            this.label_Admin.Name = "label_Admin";
            this.label_Admin.Size = new System.Drawing.Size(547, 31);
            this.label_Admin.TabIndex = 35;
            this.label_Admin.Text = "Раздел Удаления тем и вопросов теста";
            // 
            // AdminDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 654);
            this.Controls.Add(this.label_Admin);
            this.Controls.Add(this.checkedLB_Quest);
            this.Controls.Add(this.btn_DelQuest);
            this.Controls.Add(this.label_Quest);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_DelThema);
            this.Controls.Add(this.cB_Cataloge);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.label_Thema);
            this.Name = "AdminDelete";
            this.Text = "AdminDelete";
            this.Load += new System.EventHandler(this.AdminDelete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Thema;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button btn_DelThema;
        private System.Windows.Forms.ComboBox cB_Cataloge;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_DelQuest;
        private System.Windows.Forms.Label label_Quest;
        private System.Windows.Forms.CheckedListBox checkedLB_Quest;
        private System.Windows.Forms.Label label_Admin;
    }
}