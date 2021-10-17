using Application.DTO_Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        User LogIn(UserDTO user);
        User Register(UserDTO user);
    }
}
