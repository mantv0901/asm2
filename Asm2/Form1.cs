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

namespace SaleManagerment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IMemberRepository fun = new MemberRepository();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Member> list = fun.GetMembers(x=> x.Status == true).ToList();
            foreach (Member m in list)
            {
                dataGridView1.Rows.Add(m.MemberId, m.Email, m.CompanyName, m.City, m.Country, m.Password);
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

        private void button1_Click(object sender, EventArgs e)
        {
            int MemberId = int.Parse(textBox1.Text);
            Member m = fun.GetMember(MemberId);
            
            m.Email = textBox2.Text;
            m.CompanyName = textBox3.Text;
            m.City = textBox4.Text;
            m.Country = textBox5.Text;
            m.Password = textBox6.Text;

            fun.Update(m);
            bool up = true;
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

        private void button3_Click(object sender, EventArgs e)
        {
            Member m = new Member();
        
            m.Email = textBox2.Text;
            m.CompanyName = textBox3.Text;
            m.City = textBox4.Text;
            m.Country = textBox5.Text;
            m.Password = textBox6.Text;
            m.Status = true;
            fun.Create(m);
            bool up = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            bool kq = true;
            fun.Delete(id);
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
