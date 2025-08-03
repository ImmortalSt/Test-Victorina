namespace Test_Victorina
{
    partial class AllRating
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
            this.DataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label_CountAll = new System.Windows.Forms.Label();
            this.label_All = new System.Windows.Forms.Label();
            this.btn_UpDate = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Name.Location = new System.Drawing.Point(126, 9);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(550, 39);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "Рейтинг всех участников теста";
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
            this.DataGridViewUsers.Location = new System.Drawing.Point(27, 136);
            this.DataGridViewUsers.Name = "DataGridViewUsers";
            this.DataGridViewUsers.Size = new System.Drawing.Size(818, 458);
            this.DataGridViewUsers.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(215, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = ")";
            // 
            // label_CountAll
            // 
            this.label_CountAll.AutoSize = true;
            this.label_CountAll.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CountAll.Location = new System.Drawing.Point(168, 85);
            this.label_CountAll.Name = "label_CountAll";
            this.label_CountAll.Size = new System.Drawing.Size(27, 25);
            this.label_CountAll.TabIndex = 16;
            this.label_CountAll.Text = "...";
            // 
            // label_All
            // 
            this.label_All.AutoSize = true;
            this.label_All.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_All.Location = new System.Drawing.Point(22, 85);
            this.label_All.Name = "label_All";
            this.label_All.Size = new System.Drawing.Size(150, 25);
            this.label_All.TabIndex = 15;
            this.label_All.Text = "Всего участиков (";
            // 
            // btn_UpDate
            // 
            this.btn_UpDate.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_UpDate.Location = new System.Drawing.Point(501, 79);
            this.btn_UpDate.Name = "btn_UpDate";
            this.btn_UpDate.Size = new System.Drawing.Size(160, 37);
            this.btn_UpDate.TabIndex = 20;
            this.btn_UpDate.Text = "Обновить";
            this.btn_UpDate.UseVisualStyleBackColor = true;
            this.btn_UpDate.Click += new System.EventHandler(this.btn_UpDate_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Exit.Location = new System.Drawing.Point(685, 79);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(160, 37);
            this.btn_Exit.TabIndex = 19;
            this.btn_Exit.Text = "Выход";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // AllRating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(869, 606);
            this.Controls.Add(this.btn_UpDate);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_CountAll);
            this.Controls.Add(this.label_All);
            this.Controls.Add(this.DataGridViewUsers);
            this.Controls.Add(this.label_Name);
            this.Name = "AllRating";
            this.Text = "AllRating";
            this.Load += new System.EventHandler(this.AllRating_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.DataGridView DataGridViewUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_CountAll;
        private System.Windows.Forms.Label label_All;
        private System.Windows.Forms.Button btn_UpDate;
        private System.Windows.Forms.Button btn_Exit;
    }
}