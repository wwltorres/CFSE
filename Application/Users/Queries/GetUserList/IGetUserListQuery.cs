using CFSE.Application.Dto.Queries;
using CFSE.Application.Users.Queries.GetUserList;
using System;
using System.Collections.Generic;


namespace CFSE.Application.Users.Queries
{
    public interface IGetUserListQuery
    {
        Object Execute(PaginationDTO pDTO, string sort);
    }
}
