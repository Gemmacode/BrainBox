using BrainBoxApplication.Data.DTO;

namespace BrainBoxApplication.Service.Interface
{
    public interface IUserService
    {
        Task<UserDto> AddUser(UserDto userDto);
        
    }
}
