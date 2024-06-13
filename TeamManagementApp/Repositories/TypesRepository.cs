using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repositories
{
    public interface ITypesRepository
    {
        Task DeleteTypeById(long typeId);
        Task InsertNewType(ProjectType type);
        Task UpdateType(ProjectType type);
    }
    public class TypesRepository : ITypesRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public TypesRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }

        public async Task DeleteTypeById(long typeId)
        {
            var query = @"delete from ProjectTypes where TypeId = @typeId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                await connection.ExecuteAsync(query, new { typeId });
            }
        }

        public async Task InsertNewType(ProjectType type)
        {
            var query = @"insert into ProjectTypes (Type, Active) values (@type, @active)";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                await connection.ExecuteAsync(query, new
                {
                    type = type.Type, active = type.Active
                });
            }
        }

        public async Task UpdateType(ProjectType type)
        {
            var query = @"update ProjectTypes set Type = @type, Active = @active where typeId = @typeId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                await connection.ExecuteAsync(query, new
                {
                    type = type.Type, active = type.Active, typeId = type.TypeId
                });
            }
        }
    }
}
