using OnlineCVAPI.BusinessLayer.Interfaces;
using OnlineCVAPI.DataAccessLayer;
using OnlineCVAPI.Models;

namespace OnlineCVAPI.BusinessLayer
{
    public class PersonalProfileService : IPersonalProfileService
    {
        IGenericRepository<PersonalProfile> _repository;
        public PersonalProfileService(IGenericRepository<PersonalProfile> repository)
        {
            _repository=repository;
        }

        public int SavePersonalPrfile(PersonalProfile profile)
        {
            return _repository.Create(profile);
        }
    }
}