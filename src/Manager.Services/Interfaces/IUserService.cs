using System.Threading.Tasks;
using System.Collections.Generic;
using Manager.Services.DTO;

namespace Manager.Services.interfaces{
    public interface IUserService{
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task Remove(long Id);
        Task<UserDTO> Get(long Id);
         Task<List<UserDTO>> Get();
        Task<List<UserDTO>> SearchByName(string name);
        Task<List<UserDTO>> SearchByEmail(string email);
        Task<UserDTO> GetByEmail(string email);
    }

}