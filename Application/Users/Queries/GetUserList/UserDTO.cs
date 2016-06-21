using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSE.Application.Users.Queries.GetUserList
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<RoleDTO> Roles { get; set; }

    }

    public class RoleDTO
    {
        public string Name { get; set; }
    }
}
