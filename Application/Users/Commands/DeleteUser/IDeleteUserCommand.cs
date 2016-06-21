using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSE.Application.Users.Commands.DeleteUser
{
    public interface IDeleteUserCommand
    {
        void Execute(int userId);
    }
}
