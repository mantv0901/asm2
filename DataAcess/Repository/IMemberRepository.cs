using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public interface IMemberRepository
    {
        
        bool CreateMember(Member member);
        bool UpdateMember(Member member);
        bool DeleteMember(int id);
        List<Member> GetAllMember();
    }
}
