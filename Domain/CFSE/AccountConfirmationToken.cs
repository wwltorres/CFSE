namespace CFSE.Domain.CFSE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountConfirmationToken")]
    public partial class AccountConfirmationToken
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        [StringLength(50)]
        public string Token { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual User User { get; set; }
    }
}
