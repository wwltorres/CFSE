using System;
using CFSE.Application.Interface;
using CFSE.Application.CommandQuery;
using CFSE.Domain.CFSE;
using CFSE.Common.Security;

namespace CFSE.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : GenericCQ, ICreateUserCommand
    {
        public CreateUserCommand(IDBContextCFSE db) : base(db){}
        
        public void Execute(CreateUserDTO cuDTO)
        {
            User user = new User()
            {
                Username = cuDTO.Username,
                Password = Encryption.Encrypt("test"),
                Name = cuDTO.Name,
                Email = cuDTO.Email,
                Locked = cuDTO.Locked,
                Enabled = cuDTO.Enabled,
                LoginAttempts = 0,
                Confirmed = false,
                CreateDate = DateTime.Now,
                CreatedBy = "Super",
                UpdateDate = DateTime.Now,
                UpdatedBy = "super"
            };
            
            _db.Users.Add(user);

            _db.Save();

            cuDTO.id = user.Id;
        }
    }
}
