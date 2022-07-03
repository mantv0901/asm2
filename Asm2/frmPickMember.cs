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
    public partial class frmPickMember : Form
    {
        public IMemberRepository MemberRepository { get; set; }
        BindingSource source;
        public frmPickMember()
        {
            InitializeComponent();
        }

        private void frmPickMember_Load(object sender, EventArgs e)
        {
            IEnumerable<Member> list = MemberRepository.GetMembers();
            source = new BindingSource();
            source.DataSource = list;
            dgvMembers.DataSource = null;
            dgvMembers.DataSource = source;
            btnSelect.Enabled = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int index = dgvMembers.CurrentCell.RowIndex;
            var a = dgvMembers.Rows[index];
            var list = a.Cells;
            int ID = int.Parse(list[0].Value.ToString());
            Member mem = MemberRepository.GetMember(ID);
            Form form = new frmPickProduct()
            {
                Member = mem,
            };
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                form.Close();
                this.Close();
            }
        }
    }
}
