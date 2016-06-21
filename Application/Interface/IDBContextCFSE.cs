using System.Data.Entity;
using CFSE.Domain.CFSE;

namespace CFSE.Application.Interface
{
    public interface IDBContextCFSE
    {
        DbSet<AccountConfirmationToken> AccountConfirmationTokens { get; set; }
        DbSet<MtmRole2Permission> MtmRole2Permission { get; set; }
        DbSet<MtmUser2Role> MtmUser2Role { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<SecurityAnswer> SecurityAnswers { get; set; }
        DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        DbSet<User> Users { get; set; }

        void Save();
    }
}
