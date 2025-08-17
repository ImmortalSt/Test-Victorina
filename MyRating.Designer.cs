namespace Test_Victorina
{
    partial class MyRating
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label_Name = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.DataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_CountAll = new System.Windows.Forms.Label();
            this.label_AllTest = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Name.Location = new System.Drawing.Point(90, -67);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(550, 39);
            this.label_Name.TabIndex = 20;
            this.label_Name.Text = "Рейтинг всех участников теста";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Exit.Location = new System.Drawing.Point(691, 98);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(160, 37);
            this.btn_Exit.TabIndex = 23;
            this.btn_Exit.Text = "Выход";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // DataGridViewUsers
            // 
            this.DataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridViewUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gabriola", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewUsers.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewUsers.Location = new System.Drawing.Point(33, 164);
            this.DataGridViewUsers.Name = "DataGridViewUsers";
            this.DataGridViewUsers.Size = new System.Drawing.Size(818, 458);
            this.DataGridViewUsers.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(259, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 39);
            this.label1.TabIndex = 21;
            this.label1.Text = "Мой Рейтинг тестов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(223, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = ")";
            // 
            // label_CountAll
            // 
            this.label_CountAll.AutoSize = true;
            this.label_CountAll.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CountAll.Location = new System.Drawing.Point(190, 98);
            this.label_CountAll.Name = "label_CountAll";
            this.label_CountAll.Size = new System.Drawing.Size(27, 25);
            this.label_CountAll.TabIndex = 25;
            this.label_CountAll.Text = "...";
            // 
            // label_AllTest
            // 
            this.label_AllTest.AutoSize = true;
            this.label_AllTest.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_AllTest.Location = new System.Drawing.Point(44, 98);
            this.label_AllTest.Name = "label_AllTest";
            this.label_AllTest.Size = new System.Drawing.Size(125, 25);
            this.label_AllTest.TabIndex = 24;
            this.label_AllTest.Text = "Всего тестов (";
            // 
            // MyRating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(876, 634);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_CountAll);
            this.Controls.Add(this.label_AllTest);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.DataGridViewUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Name);
            this.Name = "MyRating";
            this.Text = "MyRaring";
            this.Load += new System.EventHandler(this.MyRating_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.DataGridView DataGridViewUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_CountAll;
        private System.Windows.Forms.Label label_AllTest;
    }
}