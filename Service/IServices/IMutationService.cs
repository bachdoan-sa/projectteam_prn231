using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IMutationService
    {
        Task<List<Mutation>> GetAllMutations();
        Task<Mutation> GetMutationById(string id);
        Task CreateMutaion(Mutation mutation);
        Task UpdateMutaion(Mutation mutation);
    }
}
