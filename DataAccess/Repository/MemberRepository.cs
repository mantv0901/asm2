using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using System.Linq.Expressions;


namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private PRN211_DB_ASMContext context;
        public MemberRepository()
        {
            context = new PRN211_DB_ASMContext();
        }

        public Member CheckLogin(string email,string password)
        {
            return context.Members.FirstOrDefault(m => m.Email == email && m.Password == password);
        }

        public void Create(Member member)
        {
            context.Members.Add(member);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Member member = context.Members.FirstOrDefault(x=> x.MemberId == id);
            member.Status = false;
            Update(member);
        }

        public Member GetMember(int id)
        {
            return context.Members.FirstOrDefault(x=> x.MemberId == id);
        }

        public IEnumerable<Member> GetMembers(Expression<Func<Member, bool>> ex)
        {
            return context.Members.Where(ex);
        }

        public void Update(Member member)
        {
            context.Update(member);
            context.SaveChanges();
        }
    }
}
