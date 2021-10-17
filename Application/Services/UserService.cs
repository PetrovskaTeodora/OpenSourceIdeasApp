using Application.DTO_Models;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper=mapper;
        }
        public User LogIn(UserDTO user)
        {
            return _userRepository.GetByLogInInfo(user.Email, user.Password);
        }

        public User Register(UserDTO user)
        {
            var existingUser = _userRepository.GetByEmail(user.Email);
            if (existingUser!=null) return null;

            _userRepository.Insert(_mapper.Map<User>(user));

            return LogIn(user);
        }
    }
}
