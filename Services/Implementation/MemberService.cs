using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using OurModel;
using Services.Abstract;

namespace Services.Implementation
{
    public class MemberService : IMemberService
    {
        private readonly MusicDbContextProvider _contextProvider;

        public MemberService(MusicDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }


        public void AddMember(Member member)
        {
            if (member == null) return;
            var newMember = new Member
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Instrument = member.Instrument,
                Gender = member.Gender
            };
            _contextProvider.Context.Members.Add(newMember);
            _contextProvider.Context.SaveChanges();
        }

        public void DeleteMember(Member member)
        {
            _contextProvider.Context.Members.Remove(member);
            _contextProvider.Context.SaveChanges();
        }

        public Member GetMemberById(int? Id)
        {
            return _contextProvider.Context.Members.First(x => x.Id == Id);
        }
        /*
        public void EditStudio(int Id, Studio studio)
        {
            if (studio == null) return;
            Studio newStudio = GetStudioById(Id);

            _contextProvider.Context.Studios.AddOrUpdate(newStudio);
            _contextProvider.Context.SaveChanges();
        }*/
    }
}