using MusicSchoolApp.Models;
using MusicSchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MusicSchoolApp.Forms
{
    public partial class CheckoutForm : Form
    {
        private int studentId;
        private List<Course> courses;
        private DataService dataService;
        private Dictionary<int, NumericUpDown> monthSelectors;
        private User student;
        private Benefit studentBenefit;
        private int discountPercent = 0;

        public CheckoutForm(int studentId, List<Course> courses)
        {
            InitializeComponent();

            chkDiscount.Visible = false;
            nudDiscountSum.Visible = false;
            lblDiscountSum.Visible = false;

            this.studentId = studentId;
            this.courses = courses;
            this.dataService = new DataService();
            this.monthSelectors = new Dictionary<int, NumericUpDown>();

            LoadStudentInfo();
            LoadStudentBenefit();
            CreateCoursePanels();
            UpdateTotalPrice();

            
        }

        private void LoadStudentInfo()
        {
            student = dataService.GetUserById(studentId);
            if (student != null)
            {
                lblStudentName.Text = $"{student.Surname} {student.Name}";
                if (!string.IsNullOrEmpty(student.Patronymic))
                    lblStudentName.Text += $" {student.Patronymic}";
            }

            dtpContractDate.Value = DateTime.Now;
        }

        private void LoadStudentBenefit()
        {
            if (student?.BenefitId.HasValue == true)
            {
                studentBenefit = dataService.GetBenefitById(student.BenefitId.Value);

                if (studentBenefit != null)
                {
                    // Определяем процент скидки по ID льготы
                    switch (studentBenefit.Id)
                    {
                        case 1:
                            discountPercent = 30;
                            break;
                        case 2:
                            discountPercent = 35;
                            break;
                        default:
                            discountPercent = 0;
                            break;
                    }

                    // Отображаем информацию о льготе
                    lblBenefitInfo.Text = $"Льгота: {studentBenefit.BenefitName}";
                    lblBenefitInfo.ForeColor = Color.Green;

                    if (discountPercent > 0)
                    {
                        lblDiscountInfo.Text = $"Скидка: {discountPercent}%";
                        lblDiscountInfo.ForeColor = Color.DarkGreen;
                    }
                }
            }
            else
            {
                lblBenefitInfo.Text = "Льгота: отсутствует";
                lblBenefitInfo.ForeColor = Color.Gray;
                lblDiscountInfo.Text = "";
            }
        }

        private void CreateCoursePanels()
        {
            int yOffset = 10;

            foreach (var course in courses)
            {
                var panel = new Panel
                {
                    Location = new Point(10, yOffset),
                    Size = new Size(panelCourses.Width - 25, 40),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White
                };

                var lblCourse = new Label
                {
                    Text = course.Name,
                    Location = new Point(10, 10),
                    Size = new Size(200, 20),
                    Font = new Font("Segoe UI", 10, FontStyle.Regular)
                };
                panel.Controls.Add(lblCourse);

                var lblPrice = new Label
                {
                    Text = $"{course.Price:N0} ₽",
                    Location = new Point(220, 10),
                    Size = new Size(80, 20),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleRight
                };
                panel.Controls.Add(lblPrice);

                var lblMonths = new Label
                {
                    Text = "Месяцев:",
                    Location = new Point(310, 10),
                    Size = new Size(70, 20)
                };
                panel.Controls.Add(lblMonths);

                var numMonths = new NumericUpDown
                {
                    Location = new Point(380, 8),
                    Size = new Size(60, 20),
                    Minimum = 1,
                    Maximum = 12,
                    Value = 1
                };
                numMonths.ValueChanged += (s, e) => UpdateTotalPrice();
                panel.Controls.Add(numMonths);

                monthSelectors[course.Id] = numMonths;

                panelCourses.Controls.Add(panel);
                yOffset += 45;
            }
        }

        private void UpdateTotalPrice()
        {
            // Расчет полной суммы без скидки
            int subtotal = 0;
            foreach (var course in courses)
            {
                if (monthSelectors.ContainsKey(course.Id))
                {
                    subtotal += course.Price * (int)monthSelectors[course.Id].Value;
                }
            }

            // Расчет суммы скидки
            int discountAmount = 0;
            if (discountPercent > 0)
            {
                discountAmount = (int)(subtotal * discountPercent / 100.0);
            }

            // Итоговая сумма
            int total = subtotal - discountAmount;
            if (total < 0) total = 0;

            // Отображение информации
            lblSubtotal.Text = $"Сумма без скидки: {subtotal:N0} ₽";

            if (discountAmount > 0)
            {
                lblDiscountAmount.Text = $"Скидка ({discountPercent}%): -{discountAmount:N0} ₽";
                lblDiscountAmount.ForeColor = Color.Green;
            }
            else
            {
                lblDiscountAmount.Text = "";
            }

            lblTotalPrice.Text = $"Итого к оплате: {total:N0} ₽";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                // Рассчитываем полную сумму для распределения скидки
                int subtotal = 0;
                foreach (var course in courses)
                {
                    if (monthSelectors.ContainsKey(course.Id))
                    {
                        subtotal += course.Price * (int)monthSelectors[course.Id].Value;
                    }
                }

                int totalDiscount = 0;
                if (discountPercent > 0)
                {
                    totalDiscount = (int)(subtotal * discountPercent / 100.0);
                }

                // Создаем договоры для каждого курса
                foreach (var course in courses)
                {
                    int months = monthSelectors.ContainsKey(course.Id)
                        ? (int)monthSelectors[course.Id].Value
                        : 1;

                    int coursePrice = course.Price * months;

                    // Распределяем скидку пропорционально стоимости курса
                    int courseDiscount = 0;
                    if (totalDiscount > 0 && subtotal > 0)
                    {
                        courseDiscount = (int)((long)totalDiscount * coursePrice / subtotal);
                    }

                    var contract = new Contract
                    {
                        CourseId = course.Id,
                        UserId = studentId,
                        ContractDate = dtpContractDate.Value,
                        AmountMonth = months.ToString(),
                        Discount = discountPercent > 0,
                        DiscountSum = courseDiscount > 0 ? (int?)courseDiscount : null
                    };

                    dataService.AddContract(contract);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оформлении заказа: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Эти методы больше не нужны, но оставляем для совместимости с дизайнером
        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            // Не используется - скидка применяется автоматически
        }

        private void nudDiscountSum_ValueChanged(object sender, EventArgs e)
        {
            // Не используется - скидка применяется автоматически
        }
    }
}