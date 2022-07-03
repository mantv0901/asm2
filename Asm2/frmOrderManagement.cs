using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Models;
using DataAccess.Repository;

namespace Asm2
{
    public partial class frmOrderManagement : Form
    {
        BindingSource source;
        IMemberRepository memberRepository = new MemberRepository();
        IOrderRepository orderRepository = new OrderRepository();
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        public frmOrderManagement()
        {
            InitializeComponent();
        }

        private void frmOrderManagement_Load(object sender, EventArgs e)
        {
            LoadOrderList(orderRepository.GetAllOrders());
        }

        private void LoadOrderList(IEnumerable<Order> list)
        {
            source = new BindingSource();
            source.DataSource = list;
            dgvOrders.DataSource = null;
            dgvOrders.DataSource = source;
            if (list.Count() > 0) btnDeleteOrder.Enabled = true;
            else btnDeleteOrder.Enabled = false;
        }

        private void btnSearchOrderID_Click(object sender, EventArgs e)
        {
            LoadOrderList(orderRepository.GetOrdersBy(o => o.OrderId == int.Parse(txtSearchOrderID.Text)));
        }

        private void txtSearchOrderID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            int index = dgvOrders.CurrentCell.RowIndex;
            var a = dgvOrders.Rows[index];
            var list = a.Cells;
            int ID = int.Parse(list[0].Value.ToString());
            //orderDetailRepository.Delete(ID);
            orderRepository.Delete(ID);
            LoadOrderList(orderRepository.GetAllOrders());
        }

        private void btnAddNewOrder_Click(object sender, EventArgs e)
        {
            Form formPickMember = new frmPickMember()
            {
                MemberRepository = this.memberRepository
            };
            formPickMember.ShowDialog();
            if (formPickMember.DialogResult == DialogResult.OK)
            {
                formPickMember.Close();
                LoadOrderList(orderRepository.GetAllOrders());
            }
        }
    }
}
