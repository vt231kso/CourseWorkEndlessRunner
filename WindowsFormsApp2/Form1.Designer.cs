namespace WindowsFormsApp2
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
            this.label1 = new System.Windows.Forms.Label();
            this.back_to_menu = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox2gameover = new System.Windows.Forms.PictureBox();
            this.pause = new System.Windows.Forms.PictureBox();
            this.restart_1 = new System.Windows.Forms.PictureBox();
            this.continue_1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2gameover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restart_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.continue_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(76, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Привіт";
            // 
            // back_to_menu
            // 
            this.back_to_menu.BackColor = System.Drawing.Color.Yellow;
            this.back_to_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_to_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.back_to_menu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.back_to_menu.Location = new System.Drawing.Point(522, 186);
            this.back_to_menu.Name = "back_to_menu";
            this.back_to_menu.Size = new System.Drawing.Size(138, 62);
            this.back_to_menu.TabIndex = 4;
            this.back_to_menu.Text = "MENU";
            this.back_to_menu.UseVisualStyleBackColor = false;
            this.back_to_menu.Click += new System.EventHandler(this.back_to_menu_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::WindowsFormsApp2.Properties.Resources.кубок;
            this.pictureBox2.Location = new System.Drawing.Point(689, 51);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox2gameover
            // 
            this.pictureBox2gameover.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2gameover.Image = global::WindowsFormsApp2.Properties.Resources.gameover;
            this.pictureBox2gameover.Location = new System.Drawing.Point(259, 44);
            this.pictureBox2gameover.Name = "pictureBox2gameover";
            this.pictureBox2gameover.Size = new System.Drawing.Size(282, 136);
            this.pictureBox2gameover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2gameover.TabIndex = 7;
            this.pictureBox2gameover.TabStop = false;
            this.pictureBox2gameover.Visible = false;
            // 
            // pause
            // 
            this.pause.BackColor = System.Drawing.Color.Transparent;
            this.pause.Image = global::WindowsFormsApp2.Properties.Resources.pause_removebg_preview;
            this.pause.Location = new System.Drawing.Point(12, 12);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(78, 39);
            this.pause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pause.TabIndex = 5;
            this.pause.TabStop = false;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // restart_1
            // 
            this.restart_1.BackColor = System.Drawing.Color.Transparent;
            this.restart_1.Image = global::WindowsFormsApp2.Properties.Resources.restart_removebg_preview;
            this.restart_1.Location = new System.Drawing.Point(352, 186);
            this.restart_1.Name = "restart_1";
            this.restart_1.Size = new System.Drawing.Size(102, 62);
            this.restart_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.restart_1.TabIndex = 3;
            this.restart_1.TabStop = false;
            this.restart_1.Click += new System.EventHandler(this.restart_1_Click_1);
            // 
            // continue_1
            // 
            this.continue_1.BackColor = System.Drawing.Color.Transparent;
            this.continue_1.Image = global::WindowsFormsApp2.Properties.Resources.cont;
            this.continue_1.Location = new System.Drawing.Point(141, 186);
            this.continue_1.Name = "continue_1";
            this.continue_1.Size = new System.Drawing.Size(115, 62);
            this.continue_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.continue_1.TabIndex = 2;
            this.continue_1.TabStop = false;
            this.continue_1.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::WindowsFormsApp2.Properties.Resources.onecoin;
            this.pictureBox1.Location = new System.Drawing.Point(12, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(830, 353);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox2gameover);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.back_to_menu);
            this.Controls.Add(this.restart_1);
            this.Controls.Add(this.continue_1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ENdless Runner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2gameover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restart_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.continue_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox continue_1;
        private System.Windows.Forms.PictureBox restart_1;
        private System.Windows.Forms.Button back_to_menu;
        private System.Windows.Forms.PictureBox pause;
        private System.Windows.Forms.PictureBox pictureBox2gameover;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

