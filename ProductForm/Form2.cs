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

namespace ProductForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        IProductRepository fun = new ProductRepository();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Product> list = fun.GetAllProduct();
            foreach (Product p in list)
            {
                dataGridView1.Rows.Add(p.ProductId, p.CategoryId, p.ProductName, p.Weight, p.UnitPrice, p.UnitsInStock);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Product p = new Product();

            p.CategoryId = int.Parse(textBox2.Text);
            p.ProductName = textBox3.Text;
            p.Weight = textBox4.Text;
            p.UnitPrice = int.Parse(textBox5.Text);
            p.UnitsInStock = int.Parse(textBox6.Text);

            bool up = fun.CreateProduct(p);
            if (up == true)
            {
                MessageBox.Show("Add thanh cong");
                Form1_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Add that bai");
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.ProductId = int.Parse(textBox1.Text);
            p.CategoryId = int.Parse(textBox2.Text);
            p.ProductName = textBox3.Text;
            p.Weight = textBox4.Text;
            p.UnitPrice = int.Parse(textBox5.Text);
            p.UnitsInStock = int.Parse(textBox6.Text);

            bool up = fun.UpdateProduct(p);
            if (up == true)
            {
                MessageBox.Show("Update thanh cong");
                Form1_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Update that bai");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            bool kq = fun.DeleteProduct(id);
            if (kq == true)
            {
                MessageBox.Show("Delete thanh cong");
                Form1_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Delete that bai");
            }
        }

    }
}
