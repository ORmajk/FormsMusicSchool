using System.Windows.Forms;

namespace MusicSchoolApp.Forms
{
    partial class CourseEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private TextBox txtName;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Label lblMinAge;
        private NumericUpDown numMinAge;
        private Label lblMaxAge;
        private NumericUpDown numMaxAge;
        private Label lblDuration;
        private NumericUpDown numDuration;
        private Label lblCourseType;
        private ComboBox cmbCourseType;
        private Label lblTeacher;
        private ComboBox cmbTeacher;
        private Button btnSave;
        private Button btnCancel;
        private Label lblMinutes;
        private Label lblRubles;
        private Label lblYears;
        private Label lblYears2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseEditForm));
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblMinAge = new System.Windows.Forms.Label();
            this.numMinAge = new System.Windows.Forms.NumericUpDown();
            this.lblMaxAge = new System.Windows.Forms.Label();
            this.numMaxAge = new System.Windows.Forms.NumericUpDown();
            this.lblDuration = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.lblCourseType = new System.Windows.Forms.Label();
            this.cmbCourseType = new System.Windows.Forms.ComboBox();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.cmbTeacher = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblRubles = new System.Windows.Forms.Label();
            this.lblYears = new System.Windows.Forms.Label();
            this.lblYears2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(26, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название курса:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(171, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(258, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(26, 56);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 13);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Цена:";
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(171, 55);
            this.numPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(103, 20);
            this.numPrice.TabIndex = 3;
            // 
            // lblMinAge
            // 
            this.lblMinAge.AutoSize = true;
            this.lblMinAge.Location = new System.Drawing.Point(26, 91);
            this.lblMinAge.Name = "lblMinAge";
            this.lblMinAge.Size = new System.Drawing.Size(127, 13);
            this.lblMinAge.TabIndex = 4;
            this.lblMinAge.Text = "Минимальный возраст:";
            // 
            // numMinAge
            // 
            this.numMinAge.Location = new System.Drawing.Point(171, 89);
            this.numMinAge.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numMinAge.Name = "numMinAge";
            this.numMinAge.Size = new System.Drawing.Size(69, 20);
            this.numMinAge.TabIndex = 5;
            this.numMinAge.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // lblMaxAge
            // 
            this.lblMaxAge.AutoSize = true;
            this.lblMaxAge.Location = new System.Drawing.Point(26, 126);
            this.lblMaxAge.Name = "lblMaxAge";
            this.lblMaxAge.Size = new System.Drawing.Size(133, 13);
            this.lblMaxAge.TabIndex = 6;
            this.lblMaxAge.Text = "Максимальный возраст:";
            // 
            // numMaxAge
            // 
            this.numMaxAge.Location = new System.Drawing.Point(171, 124);
            this.numMaxAge.Name = "numMaxAge";
            this.numMaxAge.Size = new System.Drawing.Size(69, 20);
            this.numMaxAge.TabIndex = 7;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(26, 160);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(83, 13);
            this.lblDuration.TabIndex = 8;
            this.lblDuration.Text = "Длительность:";
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(171, 159);
            this.numDuration.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(69, 20);
            this.numDuration.TabIndex = 9;
            this.numDuration.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // lblCourseType
            // 
            this.lblCourseType.AutoSize = true;
            this.lblCourseType.Location = new System.Drawing.Point(26, 195);
            this.lblCourseType.Name = "lblCourseType";
            this.lblCourseType.Size = new System.Drawing.Size(61, 13);
            this.lblCourseType.TabIndex = 10;
            this.lblCourseType.Text = "Тип курса:";
            // 
            // cmbCourseType
            // 
            this.cmbCourseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourseType.FormattingEnabled = true;
            this.cmbCourseType.Location = new System.Drawing.Point(171, 192);
            this.cmbCourseType.Name = "cmbCourseType";
            this.cmbCourseType.Size = new System.Drawing.Size(172, 21);
            this.cmbCourseType.TabIndex = 11;
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Location = new System.Drawing.Point(26, 230);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(89, 13);
            this.lblTeacher.TabIndex = 12;
            this.lblTeacher.Text = "Преподаватель:";
            // 
            // cmbTeacher
            // 
            this.cmbTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeacher.FormattingEnabled = true;
            this.cmbTeacher.Location = new System.Drawing.Point(171, 227);
            this.cmbTeacher.Name = "cmbTeacher";
            this.cmbTeacher.Size = new System.Drawing.Size(258, 21);
            this.cmbTeacher.TabIndex = 13;
            this.cmbTeacher.SelectedIndexChanged += new System.EventHandler(this.cmbTeacher_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(171, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(309, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(249, 160);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(37, 13);
            this.lblMinutes.TabIndex = 16;
            this.lblMinutes.Text = "минут";
            // 
            // lblRubles
            // 
            this.lblRubles.AutoSize = true;
            this.lblRubles.Location = new System.Drawing.Point(283, 56);
            this.lblRubles.Name = "lblRubles";
            this.lblRubles.Size = new System.Drawing.Size(27, 13);
            this.lblRubles.TabIndex = 17;
            this.lblRubles.Text = "руб.";
            // 
            // lblYears
            // 
            this.lblYears.AutoSize = true;
            this.lblYears.Location = new System.Drawing.Point(249, 91);
            this.lblYears.Name = "lblYears";
            this.lblYears.Size = new System.Drawing.Size(24, 13);
            this.lblYears.TabIndex = 18;
            this.lblYears.Text = "лет";
            // 
            // lblYears2
            // 
            this.lblYears2.AutoSize = true;
            this.lblYears2.Location = new System.Drawing.Point(249, 126);
            this.lblYears2.Name = "lblYears2";
            this.lblYears2.Size = new System.Drawing.Size(65, 13);
            this.lblYears2.TabIndex = 19;
            this.lblYears2.Text = "лет (0 - нет)";
            // 
            // CourseEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FormsMusicSchool.Properties.Resources.FonNot;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(471, 338);
            this.Controls.Add(this.lblYears2);
            this.Controls.Add(this.lblYears);
            this.Controls.Add(this.lblRubles);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbTeacher);
            this.Controls.Add(this.lblTeacher);
            this.Controls.Add(this.cmbCourseType);
            this.Controls.Add(this.lblCourseType);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.numMaxAge);
            this.Controls.Add(this.lblMaxAge);
            this.Controls.Add(this.numMinAge);
            this.Controls.Add(this.lblMinAge);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CourseEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование курса";
            this.Load += new System.EventHandler(this.CourseEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}