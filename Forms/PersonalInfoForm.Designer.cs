namespace MusicSchoolApp.Forms
{
    partial class PersonalInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalInfoForm));
            this.groupBoxPersonal = new System.Windows.Forms.GroupBox();
            this.lblBenefit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAchievements = new System.Windows.Forms.DataGridView();
            this.groupBoxStudentTeacher = new System.Windows.Forms.GroupBox();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.panelTeacherButtons = new System.Windows.Forms.Panel();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.btnEditCourse = new System.Windows.Forms.Button();
            this.btnDeleteCourse = new System.Windows.Forms.Button();
            this.butt_exit = new System.Windows.Forms.Button();
            this.groupBoxPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievements)).BeginInit();
            this.groupBoxStudentTeacher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.panelTeacherButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPersonal
            // 
            this.groupBoxPersonal.Controls.Add(this.lblBenefit);
            this.groupBoxPersonal.Controls.Add(this.label5);
            this.groupBoxPersonal.Controls.Add(this.lblEmail);
            this.groupBoxPersonal.Controls.Add(this.label4);
            this.groupBoxPersonal.Controls.Add(this.lblPhone);
            this.groupBoxPersonal.Controls.Add(this.label3);
            this.groupBoxPersonal.Controls.Add(this.lblName);
            this.groupBoxPersonal.Controls.Add(this.label1);
            this.groupBoxPersonal.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPersonal.Name = "groupBoxPersonal";
            this.groupBoxPersonal.Size = new System.Drawing.Size(550, 100);
            this.groupBoxPersonal.TabIndex = 0;
            this.groupBoxPersonal.TabStop = false;
            this.groupBoxPersonal.Text = "Личная информация";
            // 
            // lblBenefit
            // 
            this.lblBenefit.AutoSize = true;
            this.lblBenefit.Location = new System.Drawing.Point(300, 22);
            this.lblBenefit.Name = "lblBenefit";
            this.lblBenefit.Size = new System.Drawing.Size(49, 13);
            this.lblBenefit.TabIndex = 7;
            this.lblBenefit.Text = "[Льгота]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Льгота:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(90, 68);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "[Email]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(90, 45);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(58, 13);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "[Телефон]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Телефон:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(90, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "[ФИО]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО:";
            // 
            // dgvAchievements
            // 
            this.dgvAchievements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAchievements.Location = new System.Drawing.Point(21, 435);
            this.dgvAchievements.Name = "dgvAchievements";
            this.dgvAchievements.Size = new System.Drawing.Size(535, 102);
            this.dgvAchievements.TabIndex = 1;
            this.dgvAchievements.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAchievements_CellContentClick);
            // 
            // groupBoxStudentTeacher
            // 
            this.groupBoxStudentTeacher.Controls.Add(this.dgvSchedule);
            this.groupBoxStudentTeacher.Controls.Add(this.dgvCourses);
            this.groupBoxStudentTeacher.Location = new System.Drawing.Point(12, 118);
            this.groupBoxStudentTeacher.Name = "groupBoxStudentTeacher";
            this.groupBoxStudentTeacher.Size = new System.Drawing.Size(550, 300);
            this.groupBoxStudentTeacher.TabIndex = 2;
            this.groupBoxStudentTeacher.TabStop = false;
            this.groupBoxStudentTeacher.Text = "Курсы и расписание";
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(6, 159);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.Size = new System.Drawing.Size(538, 120);
            this.dgvSchedule.TabIndex = 1;
            // 
            // dgvCourses
            // 
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Location = new System.Drawing.Point(6, 19);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.Size = new System.Drawing.Size(538, 120);
            this.dgvCourses.TabIndex = 0;
            // 
            // panelTeacherButtons
            // 
            this.panelTeacherButtons.Controls.Add(this.btnAddCourse);
            this.panelTeacherButtons.Controls.Add(this.btnEditCourse);
            this.panelTeacherButtons.Controls.Add(this.btnDeleteCourse);
            this.panelTeacherButtons.Location = new System.Drawing.Point(77, 549);
            this.panelTeacherButtons.Name = "panelTeacherButtons";
            this.panelTeacherButtons.Size = new System.Drawing.Size(409, 46);
            this.panelTeacherButtons.TabIndex = 4;
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Location = new System.Drawing.Point(14, 6);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(120, 28);
            this.btnAddCourse.TabIndex = 0;
            this.btnAddCourse.Text = "Добавить курс";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            // 
            // btnEditCourse
            // 
            this.btnEditCourse.Location = new System.Drawing.Point(140, 6);
            this.btnEditCourse.Name = "btnEditCourse";
            this.btnEditCourse.Size = new System.Drawing.Size(120, 28);
            this.btnEditCourse.TabIndex = 1;
            this.btnEditCourse.Text = "Редактировать";
            this.btnEditCourse.UseVisualStyleBackColor = true;
            this.btnEditCourse.Click += new System.EventHandler(this.btnEditCourse_Click);
            // 
            // btnDeleteCourse
            // 
            this.btnDeleteCourse.Location = new System.Drawing.Point(271, 6);
            this.btnDeleteCourse.Name = "btnDeleteCourse";
            this.btnDeleteCourse.Size = new System.Drawing.Size(120, 28);
            this.btnDeleteCourse.TabIndex = 2;
            this.btnDeleteCourse.Text = "Удалить курс";
            this.btnDeleteCourse.UseVisualStyleBackColor = true;
            this.btnDeleteCourse.Click += new System.EventHandler(this.btnDeleteCourse_Click);
            // 
            // butt_exit
            // 
            this.butt_exit.Location = new System.Drawing.Point(568, 24);
            this.butt_exit.Name = "butt_exit";
            this.butt_exit.Size = new System.Drawing.Size(90, 32);
            this.butt_exit.TabIndex = 5;
            this.butt_exit.Text = "Закрыть";
            this.butt_exit.UseVisualStyleBackColor = true;
            this.butt_exit.Click += new System.EventHandler(this.butt_exit_Click);
            // 
            // PersonalInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FormsMusicSchool.Properties.Resources.FonNot;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(683, 611);
            this.Controls.Add(this.butt_exit);
            this.Controls.Add(this.panelTeacherButtons);
            this.Controls.Add(this.groupBoxStudentTeacher);
            this.Controls.Add(this.groupBoxPersonal);
            this.Controls.Add(this.dgvAchievements);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PersonalInfoForm";
            this.Text = "Личная информация";
            this.Load += new System.EventHandler(this.PersonalInfoForm_Load);
            this.groupBoxPersonal.ResumeLayout(false);
            this.groupBoxPersonal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievements)).EndInit();
            this.groupBoxStudentTeacher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.panelTeacherButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBoxPersonal;
        private System.Windows.Forms.Label lblName, label1, lblPhone, label3, lblEmail, label4, lblBenefit, label5;
        private System.Windows.Forms.DataGridView dgvAchievements;
        private System.Windows.Forms.GroupBox groupBoxStudentTeacher;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Panel panelTeacherButtons;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Button btnEditCourse;
        private System.Windows.Forms.Button btnDeleteCourse;
        private System.Windows.Forms.Button butt_exit;
    }
}