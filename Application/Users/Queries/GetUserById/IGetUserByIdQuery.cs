namespace CFSE.Application.Users.Queries.GetUserById
{
    public interface IGetUserByIdQuery
    {
        UserDetailDTO Execute(int id);
    }
}
