using BusinessLayer.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asm2
{
    public partial class frmPickProduct : Form
    {
        public Member Member { get; set; }
        IProductRepository productRepository = new ProductRepository();
        List<Product> products = new List<Product>();
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        IOrderRepository orderRepository = new OrderRepository();
        BindingSource source;

        public frmPickProduct()
        {
            InitializeComponent();
        }

        private void frmPickProduct_Load(object sender, EventArgs e)
        {
            var products = productRepository.GetProducts();
            source = new BindingSource();
            source.DataSource = products;
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = source;
            btnCreateOrder.DialogResult = DialogResult.OK;
            txtEmail.Text = Member.Email;
            txtMemberID.Text = Member.MemberId.ToString();
            btnCreateOrder.Enabled = false;
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtOrderID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtOrderID.Text.Length <= 1 && e.KeyChar == (char)Keys.Back)
            {
                btnCreateOrder.Enabled = false;
            }
            else btnCreateOrder.Enabled = true;
            btnCreateOrder.Enabled = false;
        }
    }
}
