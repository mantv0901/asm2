using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public Member GetMember(int id);
        Member CheckLogin(string Email,String password);
        public IEnumerable<Member> GetMembers(Expression<Func<Member, bool>> ex);
        public void Create(Member member);
        public void Update(Member member);
        public void Delete(int id);
    }
}
