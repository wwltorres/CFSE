using CFSE.Application.CommandQuery;
using CFSE.Application.Dto.Queries;
using CFSE.Application.Interface;
using CFSE.Application.Users.Queries.GetUserList;
using CFSE.Common.Language;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CFSE.Application.Users.Queries
{
    public class GetUserListQuery : GenericQuery, IGetUserListQuery
    {
        public GetUserListQuery(IDBContextCFSE db) : base(db) {}


        public Object Execute(PaginationDTO pDTO, string sort)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            
            var query = _db.Users;

            Init(query, pDTO, sort);
           
            List<UserDTO> uList = query.Select(u => new UserDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Username = u.Username,
                Roles = u.MtmUser2Role.Select(u2r => new RoleDTO
                        {
                            Name = (ci.Name.Equals(Language.EN)) ? u2r.Role.NameEn : u2r.Role.NameEs
                }).ToList()
            }).ToList();


            return BuildResult(uList);
        }
    }
}
