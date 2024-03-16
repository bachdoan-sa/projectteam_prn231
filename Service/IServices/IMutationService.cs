using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.MutationModels;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IMutationService
    {
        Task<List<MutationModel>> GetAllMutations();
        Task<MutationModel> GetMutationById(string id);
        Task<string> CreateMutaion(MutationModel mutation);
        Task<string> UpdateMutaion(MutationModel mutation);
        Task<string> DeleteMutaion(string id);
    }
}
