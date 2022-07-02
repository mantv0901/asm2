using BusinessLayer;
using DataAcess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public class MemberRepository : IMemberRepository
    {
      
        public bool CreateMember(Member member)
        {
            return MemberDAO.Instance.Create(member);
        }

        public bool DeleteMember(int id)
        {
            return MemberDAO.Instance.Delete(id);
        }

        public List<Member> GetAllMember()
        {
            return MemberDAO.Instance.GetAllMember();
        }


        public bool UpdateMember(Member member)
        {
            return MemberDAO.Instance.Update(member);
        }
    }
}
