namespace MusicSchoolApp.Forms
{
    partial class CourseDetailForm
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
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCourseName = new System.Windows.Forms.Label();
            this.groupBoxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.lblTeacher);
            this.groupBoxDetails.Controls.Add(this.lblType);
            this.groupBoxDetails.Controls.Add(this.lblDuration);
            this.groupBoxDetails.Controls.Add(this.lblAge);
            this.groupBoxDetails.Controls.Add(this.lblPrice);
            this.groupBoxDetails.Controls.Add(this.lblCourseName);
            this.groupBoxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxDetails.Location = new System.Drawing.Point(32, 15);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(403, 164);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Информация о курсе";
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Location = new System.Drawing.Point(6, 125);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(125, 18);
            this.lblTeacher.TabIndex = 5;
            this.lblTeacher.Text = "[Преподаватель]";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 105);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 18);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "[Тип]";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(6, 85);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(117, 18);
            this.lblDuration.TabIndex = 3;
            this.lblDuration.Text = "[Длительность]";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(6, 65);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(74, 18);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "[Возраст]";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(6, 45);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(51, 18);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "[Цена]";
            // 
            // lblCourseName
            // 
            this.lblCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCourseName.Location = new System.Drawing.Point(6, 21);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(448, 20);
            this.lblCourseName.TabIndex = 0;
            this.lblCourseName.Text = "[Название курса]";
            // 
            // CourseDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(478, 211);
            this.Controls.Add(this.groupBoxDetails);
            this.Name = "CourseDetailForm";
            this.Text = "Детали курса";
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label lblCourseName, lblPrice, lblAge, lblDuration, lblType, lblTeacher;
    }
}