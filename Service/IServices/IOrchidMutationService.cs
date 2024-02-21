using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;


namespace WebApp.Service.IServices
{
    public interface IOrchidMutationService
    {
        Task<List<OrchidMutation>> GetAllOrchidMutation();
        Task<OrchidMutation> GetOrchidMutationById(string id);
        Task AddOrchidMutaion(OrchidMutation orchidmutation);
        Task UpdateOrchidMutaion(OrchidMutation orchidmutation);
    }
}
