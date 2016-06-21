using System.ComponentModel.DataAnnotations;

namespace CFSE.Application.Users.Commands.CreateUser
{
    public class CreateUserDTO
    {
        public int id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool Locked { get; set; }
        [Required]
        public bool Enabled { get; set; }

    }
}
