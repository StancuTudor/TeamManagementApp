using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repositories
{
    public interface IMemberClassesRepository
    {
        Task DeleteMemberClassById(long memberClassId);
        Task InsertNewMemberClass(MemberClass memberClass);
        Task UpdateMemberClass(MemberClass memberClass);
    }
    public class MemberClassesRepository : IMemberClassesRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public MemberClassesRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }

        public async Task DeleteMemberClassById(long memberClassId)
        {
            var query = @"delete from MemberClasses where MemberClassId = @memberClassId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                await connection.ExecuteAsync(query, new { memberClassId });
            }
        }

        public async Task InsertNewMemberClass(MemberClass memberClass)
        {
            var query = @"insert into MemberClasses (ClassName, Active) values (@className, @active)";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                await connection.ExecuteAsync(query, new
                {
                    className = memberClass.ClassName, active = memberClass.Active
                });
            }
        }

        public async Task UpdateMemberClass(MemberClass memberClass)
        {
            var query = @"update MemberClasses set ClassName = @className, Active = @active where ClassId = @classId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                await connection.ExecuteAsync(query, new
                {
                    className = memberClass.ClassName, active = memberClass.Active, classId = memberClass.ClassId
                });
            }
        }
    }
}
