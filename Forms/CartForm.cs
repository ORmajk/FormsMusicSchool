using MusicSchoolApp.Models;
using MusicSchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MusicSchoolApp.Forms
{
    public partial class CartForm : Form
    {
        private List<Course> cart;
        private int studentId;
        private DataService dataService;

        public CartForm(List<Course> cart, int studentId)
        {
            InitializeComponent();
            this.cart = cart ?? new List<Course>();
            this.studentId = studentId;
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            UpdateTotalPrice();
        }

        private void RefreshGrid()
        {
            if (cart.Count == 0)
            {
                dgvCart.DataSource = null;
                lblEmptyCart.Visible = true;
                btnCheckout.Enabled = false;
                btnRemove.Enabled = false;
            }
            else
            {
                dgvCart.DataSource = cart.Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Price,
                    PriceFormatted = $"{c.Price:N0} ₽"
                }).ToList();

                if (dgvCart.Columns["Id"] != null)
                    dgvCart.Columns["Id"].Visible = false;

                if (dgvCart.Columns["Price"] != null)
                    dgvCart.Columns["Price"].Visible = false;

                if (dgvCart.Columns["PriceFormatted"] != null)
                    dgvCart.Columns["PriceFormatted"].HeaderText = "Цена";

                if (dgvCart.Columns["Name"] != null)
                    dgvCart.Columns["Name"].HeaderText = "Название курса";

                lblEmptyCart.Visible = false;
                btnCheckout.Enabled = true;
                btnRemove.Enabled = true;
            }
        }

        private void UpdateTotalPrice()
        {
            int total = cart.Sum(c => c.Price);
            lblTotalPrice.Text = $"Итого: {total:N0} ₽";
        }

        private void LoadStudentInfo()
        {
            try
            {
                var student = dataService.GetUserById(studentId);
                if (student != null)
                {
                    lblStudentInfo.Text = $"Ученик: {student.Surname} {student.Name}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных ученика: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.Index < cart.Count)
            {
                var courseName = cart[dgvCart.CurrentRow.Index].Name;
                var result = MessageBox.Show($"Удалить курс \"{courseName}\" из корзины?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    cart.RemoveAt(dgvCart.CurrentRow.Index);
                    RefreshGrid();
                    UpdateTotalPrice();
                }
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (cart.Count > 0)
            {
                var result = MessageBox.Show("Очистить корзину?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    cart.Clear();
                    RefreshGrid();
                    UpdateTotalPrice();
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Корзина пуста!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Показываем форму с выбором параметров договора
            using (var checkoutForm = new CheckoutForm(studentId, cart))
            {
                if (checkoutForm.ShowDialog() == DialogResult.OK)
                {
                    cart.Clear();
                    RefreshGrid();
                    UpdateTotalPrice();

                    MessageBox.Show("Заказ успешно оформлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void btnContinueShopping_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}