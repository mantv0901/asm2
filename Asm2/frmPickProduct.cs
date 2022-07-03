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
        public class ProductInCart
        {
            public int ProductId { get; set; }
            public String Category { get; set; }
            public string ProductName { get; set; }
            public string Weight { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
        public Member Member { get; set; }

        IProductRepository productRepository = new ProductRepository();

        List<Product> products = new List<Product>();

        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        IOrderRepository orderRepository = new OrderRepository();

        BindingSource source;
        Dictionary<int, ProductInCart> cart = new Dictionary<int, ProductInCart>();

        public frmPickProduct()
        {
            InitializeComponent();
        }

        private void frmPickProduct_Load(object sender, EventArgs e)
        {
            var products = productRepository.GetProducts(x=> x.ProductId!= null).ToList();
            this.products = products;
            source = new BindingSource();
            source.DataSource = products;
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = source;

            btnCreateOrder.DialogResult = DialogResult.OK;

           
            dataGridView1.DataSource = null;

            txtEmail.Text = Member.Email;

            txtMemberID.Text = Member.MemberId.ToString();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void LoadDataCart()
        {
            dataGridView1.DataSource = cart.Values.ToList();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmPickMember form = new frmPickMember();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            Product product = products[index];
            if (cart.ContainsKey(product.ProductId))
            {
                if (cart[product.ProductId].Quantity == product.UnitsInStock)
                {
                    MessageBox.Show("Not enough products");
                    return;
                }
                cart[product.ProductId].Quantity++;
                LoadDataCart();
                return;
            }
            ProductInCart productInCart = new ProductInCart
            {
                ProductId = product.ProductId,
                Category = product.Category.CategoryName,
                Quantity = 1,
                Price = product.UnitPrice,
                ProductName = product.ProductName,
                Weight = product.Weight
            };
            cart.Add(productInCart.ProductId, productInCart);
            LoadDataCart();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("You Didn't select anything!");
                return ;
            }
            Order order = new Order()
            {
                Freight = 1000,
                MemberId = Member.MemberId,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(2),
                ShippedDate = DateTime.Now.AddDays(5),
                Status = true
            };
            orderRepository.Create(order);
            int orderId = orderRepository.GetMax();
            foreach(ProductInCart product in cart.Values)
            {
                OrderDetail detail = new OrderDetail
                {
                    OrderId = orderId,
                    Discount = 0.05,
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                    Status = true,
                    UnitPrice = product.Price,
                };
                Product product1 = productRepository.GetProduct(product.ProductId);
                product1.UnitsInStock -= product.Quantity;
                productRepository.Update(product1);
                orderDetailRepository.Create(detail);
            }
            MessageBox.Show("Create Order Success!");
        }
    }
}
