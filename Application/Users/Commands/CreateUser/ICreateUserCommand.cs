using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFSE.Application.CommandQuery;

namespace CFSE.Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        void Execute(CreateUserDTO cuDTO);
    }
}
