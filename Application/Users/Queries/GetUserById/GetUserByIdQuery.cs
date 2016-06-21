using System.Linq;
using CFSE.Application.Interface;
using CFSE.Application.CommandQuery;
using System.Globalization;
using CFSE.Common.Language;

namespace CFSE.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : GenericCQ, IGetUserByIdQuery
    {
        public GetUserByIdQuery(IDBContextCFSE db) : base(db){}
        

        public UserDetailDTO Execute(int id)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            UserDetailDTO user = _db.Users.Select(u => new UserDetailDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Username = u.Username,
                RoleDTO = u.MtmUser2Role.Select(u2r => new RoleDTO
                {
                    Id = u2r.Role.Id,
                    Enabled = u2r.Role.Enabled,
                    Name = (ci.Name.Equals(Language.ES)) ? u2r.Role.NameEs : u2r.Role.NameEn,
                    PermissionsDTO = u2r.Role.MtmRole2Permission.Select(r2p => new PermissionDTO
                                    {
                                        Id = r2p.Permission.Id,
                                        Name = (ci.Name.Equals(Language.EN)) ? r2p.Permission.NameEn : r2p.Permission.NameEs
                                    }).ToList()
                }).FirstOrDefault()
            }).Where(u => u.Id == id).First();

            return user;
        }
    }
}
