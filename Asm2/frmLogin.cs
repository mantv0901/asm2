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
    public partial class frmLogin : Form
    {
        public IMemberRepository memberRepository { get; set; }
        public Member member { get; set; }
        public frmLogin()
        {
            memberRepository = new MemberRepository();
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Email = textBox2.Text;
            string Password = textBox1.Text;
            Member member;
            if (Email==AdminAccount.Email && Password == AdminAccount.Password)
            {
                frmAdmin frmAdmin = new frmAdmin();
                this.Hide();
                frmAdmin.ShowDialog();
                this.Show();
                
            }
            else if ((member = memberRepository.CheckLogin(Email, Password))!=null)
            {
                frmMember frmMember = new frmMember();
                this.Hide();
                frmMember.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Wrong Email or Password! ");
            }
        }
    }
}
