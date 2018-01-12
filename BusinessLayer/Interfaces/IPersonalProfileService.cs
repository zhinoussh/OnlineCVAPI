using OnlineCVAPI.Models;

namespace OnlineCVAPI.BusinessLayer.Interfaces
{
    public interface IPersonalProfileService
    {
        int SavePersonalPrfile(PersonalProfile profile);
    }
}