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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.btn_DelThema = new System.Windows.Forms.Button();
            this.cB_Cataloge = new System.Windows.Forms.ComboBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(165, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Раздел Удаления тем и вопросов теста";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Выбор темы";
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Exit.Location = new System.Drawing.Point(883, 558);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(170, 47);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.Text = "Выход";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // btn_DelThema
            // 
            this.btn_DelThema.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_DelThema.Location = new System.Drawing.Point(644, 127);
            this.btn_DelThema.Name = "btn_DelThema";
            this.btn_DelThema.Size = new System.Drawing.Size(170, 32);
            this.btn_DelThema.TabIndex = 6;
            this.btn_DelThema.Text = "Удалить тему";
            this.btn_DelThema.UseVisualStyleBackColor = true;
            this.btn_DelThema.Click += new System.EventHandler(this.btn_DelThema_Click);
            // 
            // cB_Cataloge
            // 
            this.cB_Cataloge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cB_Cataloge.FormattingEnabled = true;
            this.cB_Cataloge.Location = new System.Drawing.Point(181, 128);
            this.cB_Cataloge.Name = "cB_Cataloge";
            this.cB_Cataloge.Size = new System.Drawing.Size(424, 32);
            this.cB_Cataloge.TabIndex = 5;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Reset.Location = new System.Drawing.Point(883, 487);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(170, 48);
            this.btn_Reset.TabIndex = 25;
            this.btn_Reset.Text = "<-";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // AdminDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 631);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_DelThema);
            this.Controls.Add(this.cB_Cataloge);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdminDelete";
            this.Text = "AdminDelete";
            this.Load += new System.EventHandler(this.AdminDelete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button btn_DelThema;
        private System.Windows.Forms.ComboBox cB_Cataloge;
        private System.Windows.Forms.Button btn_Reset;
    }
}