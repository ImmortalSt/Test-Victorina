namespace Test_Victorina
{
    partial class Admin
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
            this.label_Admin = new System.Windows.Forms.Label();
            this.label_Thema = new System.Windows.Forms.Label();
            this.textBox_Thema = new System.Windows.Forms.TextBox();
            this.cB_Cataloge = new System.Windows.Forms.ComboBox();
            this.btn_Cataloge = new System.Windows.Forms.Button();
            this.btn_DelThema = new System.Windows.Forms.Button();
            this.textBox_Ques = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Ques = new System.Windows.Forms.Button();
            this.btn_Answ = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tB_Answ1 = new System.Windows.Forms.TextBox();
            this.tB_Answ3 = new System.Windows.Forms.TextBox();
            this.tB_Answ2 = new System.Windows.Forms.TextBox();
            this.tB_RAnsw2 = new System.Windows.Forms.TextBox();
            this.btn_RAnsw = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tB_RAnsw1 = new System.Windows.Forms.TextBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Admin
            // 
            this.label_Admin.AutoSize = true;
            this.label_Admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Admin.Location = new System.Drawing.Point(53, 9);
            this.label_Admin.Name = "label_Admin";
            this.label_Admin.Size = new System.Drawing.Size(346, 31);
            this.label_Admin.TabIndex = 0;
            this.label_Admin.Text = "Раздел Администратора";
            // 
            // label_Thema
            // 
            this.label_Thema.AutoSize = true;
            this.label_Thema.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Thema.Location = new System.Drawing.Point(22, 112);
            this.label_Thema.Name = "label_Thema";
            this.label_Thema.Size = new System.Drawing.Size(112, 24);
            this.label_Thema.TabIndex = 1;
            this.label_Thema.Text = "Тема теста";
            // 
            // textBox_Thema
            // 
            this.textBox_Thema.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Thema.Location = new System.Drawing.Point(164, 107);
            this.textBox_Thema.Name = "textBox_Thema";
            this.textBox_Thema.Size = new System.Drawing.Size(214, 29);
            this.textBox_Thema.TabIndex = 2;
            this.textBox_Thema.TextChanged += new System.EventHandler(this.textBox_Thema_TextChanged);
            // 
            // cB_Cataloge
            // 
            this.cB_Cataloge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cB_Cataloge.FormattingEnabled = true;
            this.cB_Cataloge.Location = new System.Drawing.Point(607, 103);
            this.cB_Cataloge.Name = "cB_Cataloge";
            this.cB_Cataloge.Size = new System.Drawing.Size(231, 32);
            this.cB_Cataloge.TabIndex = 3;
            this.cB_Cataloge.SelectedIndexChanged += new System.EventHandler(this.cB_Cataloge_SelectedIndexChanged);
            // 
            // btn_Cataloge
            // 
            this.btn_Cataloge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Cataloge.Location = new System.Drawing.Point(412, 103);
            this.btn_Cataloge.Name = "btn_Cataloge";
            this.btn_Cataloge.Size = new System.Drawing.Size(170, 32);
            this.btn_Cataloge.TabIndex = 4;
            this.btn_Cataloge.Text = "Добавить тему";
            this.btn_Cataloge.UseVisualStyleBackColor = true;
            this.btn_Cataloge.Click += new System.EventHandler(this.btn_Cataloge_Click);
            // 
            // btn_DelThema
            // 
            this.btn_DelThema.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_DelThema.Location = new System.Drawing.Point(875, 25);
            this.btn_DelThema.Name = "btn_DelThema";
            this.btn_DelThema.Size = new System.Drawing.Size(170, 100);
            this.btn_DelThema.TabIndex = 5;
            this.btn_DelThema.Text = "Переход в раздел\r\nУдаления";
            this.btn_DelThema.UseVisualStyleBackColor = true;
            this.btn_DelThema.Click += new System.EventHandler(this.btn_DelThema_Click);
            // 
            // textBox_Ques
            // 
            this.textBox_Ques.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Ques.Location = new System.Drawing.Point(26, 200);
            this.textBox_Ques.Multiline = true;
            this.textBox_Ques.Name = "textBox_Ques";
            this.textBox_Ques.Size = new System.Drawing.Size(812, 101);
            this.textBox_Ques.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Добавьте вопрос для выбранной темы";
            // 
            // btn_Ques
            // 
            this.btn_Ques.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Ques.Location = new System.Drawing.Point(875, 217);
            this.btn_Ques.Name = "btn_Ques";
            this.btn_Ques.Size = new System.Drawing.Size(170, 59);
            this.btn_Ques.TabIndex = 8;
            this.btn_Ques.Text = "Добавить вопрос";
            this.btn_Ques.UseVisualStyleBackColor = true;
            this.btn_Ques.Click += new System.EventHandler(this.btn_Ques_Click);
            // 
            // btn_Answ
            // 
            this.btn_Answ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Answ.Location = new System.Drawing.Point(875, 397);
            this.btn_Answ.Name = "btn_Answ";
            this.btn_Answ.Size = new System.Drawing.Size(170, 59);
            this.btn_Answ.TabIndex = 11;
            this.btn_Answ.Text = "Добавить \r\nответы";
            this.btn_Answ.UseVisualStyleBackColor = true;
            this.btn_Answ.Click += new System.EventHandler(this.btn_Answ_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(26, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Добавьте 3 варианта ответа ";
            // 
            // tB_Answ1
            // 
            this.tB_Answ1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_Answ1.Location = new System.Drawing.Point(30, 350);
            this.tB_Answ1.Multiline = true;
            this.tB_Answ1.Name = "tB_Answ1";
            this.tB_Answ1.Size = new System.Drawing.Size(808, 37);
            this.tB_Answ1.TabIndex = 9;
            // 
            // tB_Answ3
            // 
            this.tB_Answ3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_Answ3.Location = new System.Drawing.Point(30, 469);
            this.tB_Answ3.Multiline = true;
            this.tB_Answ3.Name = "tB_Answ3";
            this.tB_Answ3.Size = new System.Drawing.Size(808, 37);
            this.tB_Answ3.TabIndex = 12;
            // 
            // tB_Answ2
            // 
            this.tB_Answ2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_Answ2.Location = new System.Drawing.Point(30, 411);
            this.tB_Answ2.Multiline = true;
            this.tB_Answ2.Name = "tB_Answ2";
            this.tB_Answ2.Size = new System.Drawing.Size(808, 37);
            this.tB_Answ2.TabIndex = 13;
            // 
            // tB_RAnsw2
            // 
            this.tB_RAnsw2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_RAnsw2.Location = new System.Drawing.Point(386, 588);
            this.tB_RAnsw2.Multiline = true;
            this.tB_RAnsw2.Name = "tB_RAnsw2";
            this.tB_RAnsw2.Size = new System.Drawing.Size(163, 37);
            this.tB_RAnsw2.TabIndex = 17;
            // 
            // btn_RAnsw
            // 
            this.btn_RAnsw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_RAnsw.Location = new System.Drawing.Point(621, 536);
            this.btn_RAnsw.Name = "btn_RAnsw";
            this.btn_RAnsw.Size = new System.Drawing.Size(170, 89);
            this.btn_RAnsw.TabIndex = 16;
            this.btn_RAnsw.Text = "Добавить\r\nправильные\r\nответы";
            this.btn_RAnsw.UseVisualStyleBackColor = true;
            this.btn_RAnsw.Click += new System.EventHandler(this.btn_RAnsw_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(239, 551);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Добавьте правильный ответ";
            // 
            // tB_RAnsw1
            // 
            this.tB_RAnsw1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tB_RAnsw1.Location = new System.Drawing.Point(179, 588);
            this.tB_RAnsw1.Multiline = true;
            this.tB_RAnsw1.Name = "tB_RAnsw1";
            this.tB_RAnsw1.Size = new System.Drawing.Size(163, 37);
            this.tB_RAnsw1.TabIndex = 14;
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Exit.Location = new System.Drawing.Point(875, 620);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(170, 48);
            this.button_Exit.TabIndex = 22;
            this.button_Exit.Text = "Выход";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(179, 648);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(349, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "* Возможны 2 варианта правильных ответов";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Reset.Location = new System.Drawing.Point(875, 551);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(170, 48);
            this.btn_Reset.TabIndex = 24;
            this.btn_Reset.Text = "<-";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 686);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.tB_RAnsw2);
            this.Controls.Add(this.btn_RAnsw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tB_RAnsw1);
            this.Controls.Add(this.tB_Answ2);
            this.Controls.Add(this.tB_Answ3);
            this.Controls.Add(this.btn_Answ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tB_Answ1);
            this.Controls.Add(this.btn_Ques);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Ques);
            this.Controls.Add(this.btn_DelThema);
            this.Controls.Add(this.btn_Cataloge);
            this.Controls.Add(this.cB_Cataloge);
            this.Controls.Add(this.textBox_Thema);
            this.Controls.Add(this.label_Thema);
            this.Controls.Add(this.label_Admin);
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Admin;
        private System.Windows.Forms.Label label_Thema;
        private System.Windows.Forms.TextBox textBox_Thema;
        private System.Windows.Forms.ComboBox cB_Cataloge;
        private System.Windows.Forms.Button btn_Cataloge;
        private System.Windows.Forms.Button btn_DelThema;
        private System.Windows.Forms.TextBox textBox_Ques;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Ques;
        private System.Windows.Forms.Button btn_Answ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tB_Answ1;
        private System.Windows.Forms.TextBox tB_Answ3;
        private System.Windows.Forms.TextBox tB_Answ2;
        private System.Windows.Forms.TextBox tB_RAnsw2;
        private System.Windows.Forms.Button btn_RAnsw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tB_RAnsw1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Reset;
    }
}