using System.Linq;
using CFSE.Application.CommandQuery;
using CFSE.Application.Interface;
using CFSE.Domain.CFSE;

namespace CFSE.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : GenericCQ, IDeleteUserCommand
    {
        public DeleteUserCommand(IDBContextCFSE db) : base(db){}

        public void Execute(int userId)
        {
            User user = _db.Users.Where(u => u.Id == userId).First();

            _db.Users.Remove(user);
            _db.Save();
        }
    }
}
