namespace MusicSchoolApp.Forms
{
    partial class CartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartForm));
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblStudentInfo = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnContinueShopping = new System.Windows.Forms.Button();
            this.lblEmptyCart = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(16, 62);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(560, 250);
            this.dgvCart.TabIndex = 0;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.LightGreen;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCheckout.Location = new System.Drawing.Point(436, 12);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(140, 35);
            this.btnCheckout.TabIndex = 1;
            this.btnCheckout.Text = "Оформить заказ";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.SystemColors.Control;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRemove.Location = new System.Drawing.Point(16, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 35);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblStudentInfo
            // 
            this.lblStudentInfo.AutoSize = true;
            this.lblStudentInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblStudentInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStudentInfo.Location = new System.Drawing.Point(12, 15);
            this.lblStudentInfo.Name = "lblStudentInfo";
            this.lblStudentInfo.Size = new System.Drawing.Size(89, 21);
            this.lblStudentInfo.TabIndex = 3;
            this.lblStudentInfo.Text = "Ученик: ...";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalPrice.Location = new System.Drawing.Point(441, 15);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(105, 25);
            this.lblTotalPrice.TabIndex = 4;
            this.lblTotalPrice.Text = "Итого: 0 ₽";
            // 
            // btnClearCart
            // 
            this.btnClearCart.BackColor = System.Drawing.SystemColors.Control;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClearCart.Location = new System.Drawing.Point(150, 13);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(120, 35);
            this.btnClearCart.TabIndex = 5;
            this.btnClearCart.Text = "Очистить";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // btnContinueShopping
            // 
            this.btnContinueShopping.BackColor = System.Drawing.SystemColors.Control;
            this.btnContinueShopping.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnContinueShopping.Location = new System.Drawing.Point(287, 12);
            this.btnContinueShopping.Name = "btnContinueShopping";
            this.btnContinueShopping.Size = new System.Drawing.Size(140, 35);
            this.btnContinueShopping.TabIndex = 6;
            this.btnContinueShopping.Text = "Продолжить";
            this.btnContinueShopping.UseVisualStyleBackColor = false;
            this.btnContinueShopping.Click += new System.EventHandler(this.btnContinueShopping_Click);
            // 
            // lblEmptyCart
            // 
            this.lblEmptyCart.AutoSize = true;
            this.lblEmptyCart.BackColor = System.Drawing.Color.Transparent;
            this.lblEmptyCart.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic);
            this.lblEmptyCart.ForeColor = System.Drawing.Color.Gray;
            this.lblEmptyCart.Location = new System.Drawing.Point(180, 180);
            this.lblEmptyCart.Name = "lblEmptyCart";
            this.lblEmptyCart.Size = new System.Drawing.Size(166, 30);
            this.lblEmptyCart.TabIndex = 7;
            this.lblEmptyCart.Text = "Корзина пуста";
            this.lblEmptyCart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmptyCart.Visible = false;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.lblStudentInfo);
            this.panelTop.Controls.Add(this.lblTotalPrice);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(584, 56);
            this.panelTop.TabIndex = 8;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.btnRemove);
            this.panelBottom.Controls.Add(this.btnClearCart);
            this.panelBottom.Controls.Add(this.btnContinueShopping);
            this.panelBottom.Controls.Add(this.btnCheckout);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 337);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(584, 55);
            this.panelBottom.TabIndex = 9;
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FormsMusicSchool.Properties.Resources.FonNot;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 392);
            this.Controls.Add(this.lblEmptyCart);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dgvCart);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Корзина";
            this.Load += new System.EventHandler(this.CartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblStudentInfo;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnContinueShopping;
        private System.Windows.Forms.Label lblEmptyCart;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
    }
}