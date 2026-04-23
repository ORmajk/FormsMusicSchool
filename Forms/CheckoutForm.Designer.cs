namespace MusicSchoolApp.Forms
{
    partial class CheckoutForm
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
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblContractDate = new System.Windows.Forms.Label();
            this.dtpContractDate = new System.Windows.Forms.DateTimePicker();
            this.panelCourses = new System.Windows.Forms.Panel();
            this.lblBenefitInfo = new System.Windows.Forms.Label();
            this.lblDiscountInfo = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkDiscount = new System.Windows.Forms.CheckBox();
            this.nudDiscountSum = new System.Windows.Forms.NumericUpDown();
            this.lblDiscountSum = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountSum)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.BackColor = System.Drawing.SystemColors.Control;
            this.lblStudentName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStudentName.Location = new System.Drawing.Point(12, 15);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(89, 21);
            this.lblStudentName.TabIndex = 0;
            this.lblStudentName.Text = "Ученик: ...";
            // 
            // lblContractDate
            // 
            this.lblContractDate.AutoSize = true;
            this.lblContractDate.BackColor = System.Drawing.SystemColors.Control;
            this.lblContractDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblContractDate.Location = new System.Drawing.Point(12, 50);
            this.lblContractDate.Name = "lblContractDate";
            this.lblContractDate.Size = new System.Drawing.Size(105, 19);
            this.lblContractDate.TabIndex = 1;
            this.lblContractDate.Text = "Дата договора:";
            // 
            // dtpContractDate
            // 
            this.dtpContractDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpContractDate.Location = new System.Drawing.Point(130, 47);
            this.dtpContractDate.Name = "dtpContractDate";
            this.dtpContractDate.Size = new System.Drawing.Size(180, 25);
            this.dtpContractDate.TabIndex = 2;
            // 
            // panelCourses
            // 
            this.panelCourses.AutoScroll = true;
            this.panelCourses.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelCourses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCourses.Location = new System.Drawing.Point(12, 145);
            this.panelCourses.Name = "panelCourses";
            this.panelCourses.Size = new System.Drawing.Size(580, 180);
            this.panelCourses.TabIndex = 3;
            // 
            // lblBenefitInfo
            // 
            this.lblBenefitInfo.AutoSize = true;
            this.lblBenefitInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblBenefitInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBenefitInfo.Location = new System.Drawing.Point(12, 85);
            this.lblBenefitInfo.Name = "lblBenefitInfo";
            this.lblBenefitInfo.Size = new System.Drawing.Size(60, 19);
            this.lblBenefitInfo.TabIndex = 10;
            this.lblBenefitInfo.Text = "Льгота:";
            // 
            // lblDiscountInfo
            // 
            this.lblDiscountInfo.AutoSize = true;
            this.lblDiscountInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscountInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiscountInfo.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblDiscountInfo.Location = new System.Drawing.Point(12, 110);
            this.lblDiscountInfo.Name = "lblDiscountInfo";
            this.lblDiscountInfo.Size = new System.Drawing.Size(0, 19);
            this.lblDiscountInfo.TabIndex = 11;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.BackColor = System.Drawing.SystemColors.Control;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtotal.Location = new System.Drawing.Point(12, 340);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(152, 19);
            this.lblSubtotal.TabIndex = 12;
            this.lblSubtotal.Text = "Сумма без скидки: 0 ₽";
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.BackColor = System.Drawing.SystemColors.Control;
            this.lblDiscountAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiscountAmount.ForeColor = System.Drawing.Color.Green;
            this.lblDiscountAmount.Location = new System.Drawing.Point(12, 365);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(0, 19);
            this.lblDiscountAmount.TabIndex = 13;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalPrice.Location = new System.Drawing.Point(12, 395);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(190, 25);
            this.lblTotalPrice.TabIndex = 14;
            this.lblTotalPrice.Text = "Итого к оплате: 0 ₽";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Location = new System.Drawing.Point(447, 12);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(145, 35);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "Оформить заказ";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(340, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkDiscount
            // 
            this.chkDiscount.AutoSize = true;
            this.chkDiscount.BackColor = System.Drawing.Color.Transparent;
            this.chkDiscount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkDiscount.Location = new System.Drawing.Point(12, 295);
            this.chkDiscount.Name = "chkDiscount";
            this.chkDiscount.Size = new System.Drawing.Size(147, 23);
            this.chkDiscount.TabIndex = 4;
            this.chkDiscount.Text = "Применить скидку";
            this.chkDiscount.UseVisualStyleBackColor = false;
            this.chkDiscount.Visible = false;
            this.chkDiscount.CheckedChanged += new System.EventHandler(this.chkDiscount_CheckedChanged);
            // 
            // nudDiscountSum
            // 
            this.nudDiscountSum.Enabled = false;
            this.nudDiscountSum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudDiscountSum.Location = new System.Drawing.Point(310, 293);
            this.nudDiscountSum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudDiscountSum.Name = "nudDiscountSum";
            this.nudDiscountSum.Size = new System.Drawing.Size(100, 25);
            this.nudDiscountSum.TabIndex = 5;
            this.nudDiscountSum.Visible = false;
            this.nudDiscountSum.ValueChanged += new System.EventHandler(this.nudDiscountSum_ValueChanged);
            // 
            // lblDiscountSum
            // 
            this.lblDiscountSum.AutoSize = true;
            this.lblDiscountSum.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscountSum.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiscountSum.Location = new System.Drawing.Point(180, 295);
            this.lblDiscountSum.Name = "lblDiscountSum";
            this.lblDiscountSum.Size = new System.Drawing.Size(123, 19);
            this.lblDiscountSum.TabIndex = 9;
            this.lblDiscountSum.Text = "Сумма скидки (₽):";
            this.lblDiscountSum.Visible = false;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.lblStudentName);
            this.panelTop.Controls.Add(this.lblContractDate);
            this.panelTop.Controls.Add(this.dtpContractDate);
            this.panelTop.Controls.Add(this.lblBenefitInfo);
            this.panelTop.Controls.Add(this.lblDiscountInfo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(604, 140);
            this.panelTop.TabIndex = 15;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnConfirm);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 430);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(604, 55);
            this.panelBottom.TabIndex = 16;
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FormsMusicSchool.Properties.Resources.FonNot;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(604, 485);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblDiscountAmount);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.panelCourses);
            this.Controls.Add(this.lblDiscountSum);
            this.Controls.Add(this.nudDiscountSum);
            this.Controls.Add(this.chkDiscount);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Оформление заказа";
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountSum)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblContractDate;
        private System.Windows.Forms.DateTimePicker dtpContractDate;
        private System.Windows.Forms.Panel panelCourses;
        private System.Windows.Forms.CheckBox chkDiscount;
        private System.Windows.Forms.NumericUpDown nudDiscountSum;
        private System.Windows.Forms.Label lblDiscountSum;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblBenefitInfo;
        private System.Windows.Forms.Label lblDiscountInfo;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
    }
}