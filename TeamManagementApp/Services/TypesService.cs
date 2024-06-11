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
    public interface ITypesService
    {
        Task DeleteTypeById(int typeId);
        Task InsertNewType(ProjectType type);
        Task UpdateType(ProjectType type);
    }
    public class TypesService : ITypesService
    {
        private readonly ITypesRepository _typesRepository;
        public TypesService(ITypesRepository typesRepository)
        {
            _typesRepository = typesRepository;
        }

        public async Task DeleteTypeById(int typeId)
        {
            try
            {
                await _typesRepository.DeleteTypeById(typeId);
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("Can't delete type. It's being used in a project.");
            }
        }

        public async Task InsertNewType(ProjectType type)
        {
            await _typesRepository.InsertNewType(type);
        }

        public async Task UpdateType(ProjectType type)
        {
            await _typesRepository.UpdateType(type);
        }
    }
}
