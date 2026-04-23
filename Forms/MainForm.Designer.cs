namespace MusicSchoolApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnPersonalInfo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.PnlForAdmin = new System.Windows.Forms.Panel();
            this.buttAllInfoforAdmin = new System.Windows.Forms.Button();
            this.PnlOthersButts = new System.Windows.Forms.Panel();
            this.PnlForAdmin.SuspendLayout();
            this.PnlOthersButts.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCourses
            // 
            this.btnCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCourses.Location = new System.Drawing.Point(29, 13);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Size = new System.Drawing.Size(197, 62);
            this.btnCourses.TabIndex = 0;
            this.btnCourses.Text = "Все курсы";
            this.btnCourses.UseVisualStyleBackColor = true;
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);
            // 
            // btnPersonalInfo
            // 
            this.btnPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPersonalInfo.Location = new System.Drawing.Point(29, 81);
            this.btnPersonalInfo.Name = "btnPersonalInfo";
            this.btnPersonalInfo.Size = new System.Drawing.Size(197, 62);
            this.btnPersonalInfo.TabIndex = 1;
            this.btnPersonalInfo.Text = "Личная информация";
            this.btnPersonalInfo.UseVisualStyleBackColor = true;
            this.btnPersonalInfo.Click += new System.EventHandler(this.btnPersonalInfo_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(114, 212);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(197, 62);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // PnlForAdmin
            // 
            this.PnlForAdmin.Controls.Add(this.buttAllInfoforAdmin);
            this.PnlForAdmin.Location = new System.Drawing.Point(82, 28);
            this.PnlForAdmin.Name = "PnlForAdmin";
            this.PnlForAdmin.Size = new System.Drawing.Size(252, 178);
            this.PnlForAdmin.TabIndex = 3;
            // 
            // buttAllInfoforAdmin
            // 
            this.buttAllInfoforAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttAllInfoforAdmin.Location = new System.Drawing.Point(32, 48);
            this.buttAllInfoforAdmin.Name = "buttAllInfoforAdmin";
            this.buttAllInfoforAdmin.Size = new System.Drawing.Size(197, 62);
            this.buttAllInfoforAdmin.TabIndex = 1;
            this.buttAllInfoforAdmin.Text = "Инфорамиция";
            this.buttAllInfoforAdmin.UseVisualStyleBackColor = true;
            this.buttAllInfoforAdmin.Click += new System.EventHandler(this.buttAllInfoforAdmin_Click);
            // 
            // PnlOthersButts
            // 
            this.PnlOthersButts.Controls.Add(this.btnCourses);
            this.PnlOthersButts.Controls.Add(this.btnPersonalInfo);
            this.PnlOthersButts.Location = new System.Drawing.Point(85, 25);
            this.PnlOthersButts.Name = "PnlOthersButts";
            this.PnlOthersButts.Size = new System.Drawing.Size(252, 178);
            this.PnlOthersButts.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FormsMusicSchool.Properties.Resources.FonNot;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(423, 303);
            this.Controls.Add(this.PnlOthersButts);
            this.Controls.Add(this.PnlForAdmin);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PnlForAdmin.ResumeLayout(false);
            this.PnlOthersButts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnPersonalInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel PnlForAdmin;
        private System.Windows.Forms.Button buttAllInfoforAdmin;
        private System.Windows.Forms.Panel PnlOthersButts;
    }
}