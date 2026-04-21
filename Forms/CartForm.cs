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

        public CartForm(List<Course> cart, int studentId)
        {
            InitializeComponent();
            this.cart = cart;
            this.studentId = studentId;
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvCart.DataSource = cart.Select(c => new { c.Id, c.Name, c.Price }).ToList();
            dgvCart.Columns["Id"].Visible = false;
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            using (var service = new DataService())
                foreach (var c in cart)
                    service.AddContract(studentId, c.Id, c.Price);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.Index < cart.Count)
            {
                cart.RemoveAt(dgvCart.CurrentRow.Index);
                RefreshGrid();
            }
        }

        private void CartForm_Load(object sender, EventArgs e)
        {

        }
    }
}