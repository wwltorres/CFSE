using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CFSE.Domain;
using CFSE.Application;
using CFSE.Application.Interface;
using CFSE.Domain.CFSE;

namespace CFSE.Persistance
{
  
    public partial class DBContextCFSE : DbContext, IDBContextCFSE
    {
        public DBContextCFSE() : base("name=CFSE")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
        
        public virtual DbSet<AccountConfirmationToken> AccountConfirmationTokens { get; set; }
        public virtual DbSet<MtmRole2Permission> MtmRole2Permission { get; set; }
        public virtual DbSet<MtmUser2Role> MtmUser2Role { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SecurityAnswer> SecurityAnswers { get; set; }
        public virtual DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
