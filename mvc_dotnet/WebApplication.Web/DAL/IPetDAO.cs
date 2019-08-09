using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IPetDAO
    {
        IList<Pets> GetAllPets(int userId);

        int AddPet(Pets pet);

        Pets GetPetById(int userId);

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="user"></param>
        void DeletePet(Pets pet);
    }
}
