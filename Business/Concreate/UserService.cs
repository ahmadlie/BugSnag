using AutoMapper;
using Business.Abstract;
using DataAccess;
using DataAccess.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class UserService : BaseService<UserDTO, User>, IUserService
    {
        public UserService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public void Login(UserDTO dto)
        {
            var user = _dbContext.Users.ToList().Where
                (x => (x.UserName == dto.UserName) && (x.Password == dto.Password)).FirstOrDefault();

            var users = _dbContext.Users.ToList();

            if(!users.Any()) { throw new Exception("User Not Found"); }
            if (user == null) { throw new Exception("Incorrect Username or Password!"); }                                
        }

        public void SignUp(UserDTO dto)
        {
            CheckUsernamePassword(dto);
            var users = _dbContext.Users.Where(x => x.UserName == dto.UserName);

            if (!users.Any()) { Create(dto); }
            else { throw new Exception("This Username Already been used"); }
        }

        public void CheckUsernamePassword(UserDTO userDTO)
        {
            if (!(userDTO.UserName.Length > 0 && userDTO.Password.Length > 0))
                throw new Exception("Username Or Password cannot be empty!");
        }
    }
}
