using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurModel;

namespace Services.Abstract
{
    public interface IMemberService
    {
        void AddMember(Member member);
        Member GetMemberById(int? Id);
        void DeleteMember(Member member);
        //void EditBand(int Id, Band band);
    }
}
