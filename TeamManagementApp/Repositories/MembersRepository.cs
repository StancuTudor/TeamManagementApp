using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repositories
{
    public interface IMembersRepository
    {
        Task DeleteMemberById(int memberId);
        Task InsertNewMember(Member member);
        Task UpdateMember(Member member);
    }
    public class MembersRepository : IMembersRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public MembersRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }

        public async Task DeleteMemberById(int memberId)
        {
            var query = @"delete from Members where MemberId = @memberId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                await connection.ExecuteAsync(query, new { memberId });
            }
        }

        public async Task InsertNewMember(Member member)
        {
            var query = @"insert into Members (Name, active, classid, UserId) values (@name, @active, @classId, @userId)";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                await connection.ExecuteAsync(query, new
                {
                    name = member.Name, active = member.Active, classId = member.ClassId, userId = member.UserId
                });
            }
        }

        public async Task UpdateMember(Member member)
        {
            var query = @"update Members set name = @name, active = @active, classId = @classId, userId = @userId where memberId = @memberId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                await connection.ExecuteAsync(query, new
                {
                    name = member.Name, active = member.Active, classId = member.ClassId, userId = member.UserId, memberId = member.MemberId
                });
            }
        }
    }
}
