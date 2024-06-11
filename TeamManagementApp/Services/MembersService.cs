using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;
using TeamManagementApp.Repositories;

namespace TeamManagementApp.Services
{
    public interface IMembersService
    {
        Task DeleteMemberById(int memberId);
        Task InsertNewMember(Member member);
        Task UpdateMember(Member member);
    }
    public class MembersService : IMembersService
    {
        private readonly IMembersRepository _membersRepository;
        public MembersService(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }

        public async Task DeleteMemberById(int memberId)
        {
            try
            {
                await _membersRepository.DeleteMemberById(memberId);
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("Can't delete member. It's being used in a project.");
            }
        }

        public async Task InsertNewMember(Member member)
        {
            await _membersRepository.InsertNewMember(member);
        }

        public async Task UpdateMember(Member member)
        {
            await _membersRepository.UpdateMember(member);
        }
    }
}
