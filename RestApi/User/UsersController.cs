using System.Web.Http;
using CFSE.Application.Users.Queries;
using CFSE.RestApi.Exceptions;
using CFSE.Application.Users.Queries.GetUserById;
using CFSE.Application.Users.Commands.CreateUser;
using CFSE.Application.Users.Commands.DeleteUser;
using CFSE.RestApi.GenericRest;
using CFSE.RestApi.Authorize;
using CFSE.Common.Permissions;
using CFSE.Application.Dto.Queries;
using System;

namespace CFSE.RestApi.UserController
{
    public class UsersController : GenericApiController
    {
        private readonly IGetUserListQuery _iGetUserListQuery;
        private readonly IGetUserByIdQuery _iGetUserByIdQuery;
        private readonly ICreateUserCommand _iCreateUserCommand;
        private readonly IDeleteUserCommand _iDeleteUserCommand;

        public UsersController(
            IGetUserListQuery iGetUserListQuery,
            IGetUserByIdQuery iGetUserByIdQuery,
            ICreateUserCommand iCreateUserCommand,
            IDeleteUserCommand iDeleteUserCommand)
        {
            _iGetUserListQuery = iGetUserListQuery;
            _iGetUserByIdQuery = iGetUserByIdQuery;
            _iCreateUserCommand = iCreateUserCommand;
            _iDeleteUserCommand = iDeleteUserCommand;
        }

        [AuthorizePermission(Permissions.GET_USERS)]
        [HttpGet]
        [Route("api/v1/users")]
        public IHttpActionResult GetList([FromUri] PaginationDTO pDTO, string sort = null)
        {
            var identity = User.Identity;
            
            Object result = _iGetUserListQuery.Execute(pDTO, sort);

            if (result == null) throw new NotFoundException();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/v1/users/{id}")]
        public IHttpActionResult GetById(int id)
        {
            UserDetailDTO user = _iGetUserByIdQuery.Execute(id);

            if (user == null) throw new NotFoundException();

            return Ok(user);
        }

        [HttpPost]
        [Route("api/v1/users")]
        public void createUser([FromBody] CreateUserDTO dto)
        {
            _iCreateUserCommand.Execute(dto);

        }

        [HttpPut]
        [Route("api/v1/users/{id}")]
        public IHttpActionResult update(int id)
        {


            return Ok();
        }

        [HttpDelete]
        [Route("api/v1/users/{id}")]
        public void delete(int id)
        {
            _iDeleteUserCommand.Execute(id);
        }
        
    }
}
