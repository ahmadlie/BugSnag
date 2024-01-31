using DataAccess.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService : IBaseService<UserDTO,User>
    {
        void Login(UserDTO userDTO);  
        void SignUp(UserDTO userDTO);
    }
}
