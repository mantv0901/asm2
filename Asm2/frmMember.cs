using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Repository;
using BusinessLayer.Models;

namespace Asm2
{
    public partial class frmMember : Form
    {
        IMemberRepository memberRepository;
        IOrderRepository orderRepository;
        public Member member { get; set; }
        public frmMember()
        {
            InitializeComponent();
            memberRepository = new MemberRepository();
            orderRepository = new OrderRepository();
        }

        private void frmMember_Load(object sender, EventArgs e)
        {
            
        }
    }
}
